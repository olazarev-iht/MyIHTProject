﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SharedComponents.IhtData.DataProvider;
using SharedComponents.IhtDev;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static SharedComponents.IhtDev.IhtDevices;

namespace IhtApcWebServer.Pages
{
    public partial class DynDataModificationCNC
    {
        [Inject] public IJSRuntime? JS { get; set; }

        private IJSObjectReference? _module;
        private DotNetObjectReference<DynDataModificationCNC>? _selfReference;

        private bool _isSumTorchesActive = false;

        private const string DEFAULT_COM_PORT = "COM3";

        private bool _isTorchUpActive
        {
            get => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsTorchUpActive;
            set => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsTorchUpActive = value;
        }

        private bool _isTorchDownActive
        {
            get => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsTorchDownActive;
            set => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsTorchDownActive = value;
        }

        private bool _isHCTorchUpActive
        {
            get => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsHCTorchUpActive;
            set => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsHCTorchUpActive = value;
        }

        private bool _isHCTorchDownActive
        {
            get => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsHCTorchDownActive;
            set => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsHCTorchDownActive = value;
        }

        private bool _isCalibrationActive
        {
            get => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsCalibrationActive;
            set => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsCalibrationActive = value;
        }

        private bool _isStartPiercingActive
        {
            get => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsStartPiercingActive;
            set => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsStartPiercingActive = value;
        }

        private bool _isReloadPreHeatingTimeActive
        {
            get => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsReloadPreHeatingTimeActive;
            set => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsReloadPreHeatingTimeActive = value;
        }

        private bool _isFlameOnEndActive
        {
            get => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsFlameOnEndActive;
            set => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsFlameOnEndActive = value;
        }

        private bool _isFlameOn
        {
            get => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsFlameOn;
            set => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsFlameOn = value;
        }

        private bool _isLedPreHeating
        {
            get => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsLedPreHeating;
            set => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsLedPreHeating = value;
        }

        public bool IsLedPreHeating
        {
            get
            {

                if (!_isLedPreHeating && ihtDevices.GetDataProcessInfo(CurrentSlaveId).IsLedPreHeating)
                {
                    SetMaxHeatTimeProgressValue(ihtDevices.GetDataProcessInfo(CurrentSlaveId).CurrHeatTime);
                }

                _isLedPreHeating = ihtDevices.GetDataProcessInfo(CurrentSlaveId).IsLedPreHeating;

                return _isLedPreHeating;
            }
            set { }
        }

        private bool _isHCOnOffActive
        {
            get => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsHCOnOffActive;
            set => ihtDevices.GetDataCmdExecution(CurrentSlaveId).IsHCOnOffActive = value;
        }

        private bool _isProcessModeClearenceCtrlOff
        {
            get => ihtDevices.IsClearenceCtrlOffCommon;
            set => ihtDevices.IsClearenceCtrlOffCommon = value;
        }

        private bool _isManHeightActive
        {
            get => ihtDevices.IsManHeightActive;
            set => ihtDevices.IsManHeightActive = value;
        }

        private bool _isPreheatHeightActive
        {
            get => ihtDevices.IsPreheatHeightActive;
            set => ihtDevices.IsPreheatHeightActive = value;
        }

        private Stopwatch stopwatch = new Stopwatch();

        [JSInvokable]
        public async Task Deactivate(string eventName)
        {
            var en = eventName;

            await DeactiveButton(eventName);
        }

        /// <summary>
        /// 4.
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            ++TestCounter;
            if (firstRender)
            {
                try
                {
                    Console.WriteLine("Register debounce JS Event");
                    _selfReference = DotNetObjectReference.Create(this);
                    if (_module == null)
                    {
                        _module = await JS.InvokeAsync<IJSObjectReference>("import", "./Pages/DynDataModificationCNC.razor.js");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task MoveTorchUpAsync(string newEventName)
        {
            if (!_isTorchUpActive && !_isTorchDownActive)
            {
                _isTorchUpActive = true;

                await ActivatateAsync(newEventName);
            }
        }

        private async Task HCMoveTorchUpAsync(string newEventName)
        {
            if (!_isHCTorchUpActive && !_isHCTorchDownActive)
            {
                _isHCTorchUpActive = true;

                await ActivatateAsync(newEventName);
            }
        }

        private async Task HCMoveTorchDownAsync(string newEventName)
        {
            if (!_isHCTorchUpActive && !_isHCTorchDownActive)
            {
                _isHCTorchDownActive = true;

                await ActivatateAsync(newEventName);
            }
        }

        private async Task GoPreheatHeightAsync()
        {
            if (_isManHeightActive)
            {
                _isPreheatHeightActive = true;

                await ihtDevices.SetClearenceCtrlManualHeightCommonAsync();
            }
        }

        private async Task TurnHCOnOffAsync()
        {
            if (!_isHCOnOffActive)
            {
                if (IsBroadCastMode)
                {
                   var devices = ihtDevices.GetEnabledDevices();
                  foreach (IhtDevice device in devices)
                  {
                    // If calibration is active then cancel it
                    if (device.dataCmdExecution.IsCalibrationActive)
                    {
                      await Calibration_StopCalibration();
                      break;
                    }
                  }
                }
                await TurnHCOnAsync();
            }
            else
            {
                await TurnHCOffAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task ProcessModeClearenceCtrlOffAsync()
        {
          if (_isProcessModeClearenceCtrlOff == false)
          {
              _isProcessModeClearenceCtrlOff = true;
              await ihtDevices.SetClearenceCtrlOffCommonAsync();
          }
          else
          {
              _isProcessModeClearenceCtrlOff = false;
              await ihtDevices.ClrClearenceCtrlOffCommonAsync();
          }
        }

        private async Task ToggleManHeightAsync()
        {
            if (!_isManHeightActive)
            {
                _isManHeightActive = true;
                _isPreheatHeightActive = false;

                await ihtDevices.SetClearenceCtrlManualCommonAsync();
            }
            else
            {
                _isManHeightActive = false;
                await ihtDevices.ClrClearenceCtrlManualCommonAsync();
            }
        }

        private async Task TurnHCOnAsync()
        {
            _isHCOnOffActive = true;

            await SetParamsType(CurrentParamsType);
        }

        private async Task TurnHCOffAsync(bool turnHCOffAllEnabledDevices=false)
        {
            await ExecHeightCtrlAsync(ihtDevices.HeightControlOffAsync, IsHCOnOffActive: false, turnHCOffAllEnabledDevices);
        }

        private async Task MoveTorchDownAsync(string newEventName)
        {
            if (!_isTorchUpActive && !_isTorchDownActive)
            {
                _isTorchDownActive = true;

                await ActivatateAsync(newEventName);
            }
        }

        private async Task StartPiercingActivateAsync(string newEventName)
        {
            if (!_isStartPiercingActive)
            {
                _isStartPiercingActive = true;

                await ActivatateAsync(newEventName);
            }
        }

        private async Task ReloadPreHeatingTimeActivateAsync(string newEventName)
        {
            if (!_isReloadPreHeatingTimeActive)
            {
                _isReloadPreHeatingTimeActive = true;

                await ActivatateAsync(newEventName);
            }
        }

        private async Task ActivatateAsync(string newEventName)
        {
            if (_module != null)
            {
                await _module.InvokeVoidAsync("registerMoveEvents", newEventName, _selfReference);
            }

            if (!string.IsNullOrWhiteSpace(newEventName) && newEventName != "StartPiercing" && newEventName != "ReloadPreHeatingTime")
            {
                // If we press second button when first is down
                if (isTorchStartedMoving)
                {
                    StopTorchMoving();
                    return;
                }

                currentTorchEventName = newEventName;

                StartMovingTorch(currentTorchEventName);
            }

        }

        private async Task DeactiveButton(string eventName)
        {
            if (eventName == "MoveTorchUp" && _isTorchUpActive)
            {
                _isTorchUpActive = false;
                await StopTorchMovingAndRefreshAsync(eventName);
            }
            else if (eventName == "MoveTorchDown" && _isTorchDownActive)
            {
                _isTorchDownActive = false;
                await StopTorchMovingAndRefreshAsync(eventName);
            }
            else if (eventName == "HCMoveTorchUp" && _isHCTorchUpActive)
            {
                _isHCTorchUpActive = false;
                await StopTorchMovingAndRefreshAsync(eventName);
            }
            else if (eventName == "HCMoveTorchDown" && _isHCTorchDownActive)
            {
                _isHCTorchDownActive = false;
                await StopTorchMovingAndRefreshAsync(eventName);
            }
            //else if (eventName == "GoPreheatHeight" && _isPreheatHeightActive)
            //{
            //    _isPreheatHeightActive = false;
            //    //await StopTorchMovingAndRefreshAsync(eventName);
            //}
            else if (eventName == "StartPiercing" && _isStartPiercingActive)
            {
                _isStartPiercingActive = false;
            }
            else if (eventName == "ReloadPreHeatingTime" && _isReloadPreHeatingTimeActive)
            {
                _isReloadPreHeatingTimeActive = false;
            }
        }

        private async Task StopTorchMovingAndRefreshAsync(string eventName)
        {
            if (isTorchStartedMoving)
            {
                StopTorchMoving();
            }
            Console.WriteLine($"Deactivate {eventName} Button");
            await InvokeAsync(StateHasChanged);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        private async Task TurnFlameOnAsync()
        {
            if (!_isFlameOn)
            {
                if (IsBroadCastMode)
                {
                    var devices = ihtDevices.GetEnabledDevices();
                    foreach (IhtDevice device in devices)
                    {
                      // If calibration is active then cancel it
                      if (device.dataCmdExecution.IsCalibrationActive)
                      {
                        await Calibration_StopCalibration();
                        break;
                      }
                    }
                    // This is necessary so that all torches ignite simultaneously
                    await ihtDevices.SetupCtrl_SetStartCommonAsync();
                    foreach (IhtDevice device in devices)
                    {
                      device.dataCmdExecution.IsFlameOn = true;
                    }
                }
                else
                {
                  await ihtDevices.SetupCtrl_SetStartAsync(CurrentSlaveId);
                }
                _isFlameOn = true;

                await SetParamsType(IGNITION);
            }
        }

        private async Task TurnFlameOffAsync(bool turnFlameOffAllEnabledDevices=false)
        {
            //if (_isFlameOn || turnFlameOffAllEnabledDevices)
            {
                // This is necessary so that all torches stops simultaneously
                await ihtDevices.SetupCtrl_SetOffCommonAsync();
                var devices = ihtDevices.GetEnabledDevices();
                foreach (IhtDevice device in devices)
                {
                  ihtDevices.GetDataCmdExecution(device.SlaveId).IsFlameOn = false;
                  // And now for every torch
                  await ihtDevices.SetupCtrl_SetOffAsync(device.SlaveId);
                }
                _isFlameOn = false;
            }
            
            if (!turnFlameOffAllEnabledDevices)
            { 
              if (   dynDataModificationCNCDataProvider.CurrentParamsType == IGNITION
                  || dynDataModificationCNCDataProvider.CurrentParamsType == HEATTING
                 )
              {
                dynDataModificationCNCDataProvider.CurrentParamsType = PRE_HEAT;
                await dynDataModificationCNCDataProvider.RefreshDynamicDataModelToDisplayAsync();
                await InvokeAsync(StateHasChanged);
              }
            }
        }

        int CurrentSlaveId => dynDataModificationCNCDataProvider.CurrentSlaveId;
        int BroadCastId => dynDataModificationCNCDataProvider.CurrentBroadCastId;
        string CurrentParamsType => dynDataModificationCNCDataProvider.CurrentParamsType;

        bool IsBroadCastMode => dynDataModificationCNCDataProvider.IsBroadCastMode;
        private async Task CalibrationProcessAsync()
        {
            if (!_isCalibrationActive)
            {
                await Calibration_StartCalibration();
            }
            else
            {
                await Calibration_StopCalibration();
            }
        }

        private async Task StartProcessAsync()
        {
            if (!_isProcessBtnActive)
            {
                await Exhibition_StartProcess();
            }
            else
            {
                await Exhibition_StopProcess();
            }
        }

        private async Task ClickFlameOnEndAsync()
        {
            if (!_isFlameOnEndActive)
            {
              _isFlameOnEndActive = true;
              var devices = ihtDevices.GetEnabledDevices();
              foreach (IhtDevice device in devices)
              {
                device.dataCmdExecution.IsFlameOnAtProcessEnd = true;
                device.dataCmdExecution.IsFlameOnEndActive    = true;
              }
              await ihtDevices.SetFlameOnAtProcessEndCommonAsync();
            }
            else
            {
              _isFlameOnEndActive = false;
              var devices = ihtDevices.GetEnabledDevices();
              foreach (IhtDevice device in devices)
              {
                device.dataCmdExecution.IsFlameOnAtProcessEnd = false;
                device.dataCmdExecution.IsFlameOnEndActive    = false;
              }
              await ihtDevices.ClrFlameOnAtProcessEndCommonAsync();
            }
        }

        private async Task ClickSumTorchesAsync()
        {
            if (!_isSumTorchesActive)
            {
              _isSumTorchesActive = true;
              dynDataModificationCNCDataProvider.IsBroadCastMode = true;
            }
            else
            {
              _isSumTorchesActive = false;
              dynDataModificationCNCDataProvider.IsBroadCastMode = false;
            }

            // Only if the Manual-Mode is active
            if (_isSumTorchesActive && ComponentMode==MANUAL_MODE)
            { 
              bool isAtLeastOneFlameOn           = false;
              bool isAtLeastOneCalibrationActive = false;
              bool isAtLeastOneHeightCtrlActive  = false;
              var devices = ihtDevices.GetEnabledDevices();
              foreach (IhtDevice device in devices)
              {
                if (device.dataCmdExecution.IsFlameOn)
                { 
                  isAtLeastOneFlameOn = true;
                }
                if (device.dataCmdExecution.IsCalibrationActive)
                { 
                  isAtLeastOneCalibrationActive = true;
                }
                if (device.dataCmdExecution.IsHCOnOffActive)
                { 
                  isAtLeastOneHeightCtrlActive = true;
                }
              }
              
              // If at least in one device is calibration active
              if (isAtLeastOneCalibrationActive)
              { 
                // If at least in one device is flame or height control active, then stop all actives calibration,
                // because flame and/or height control for all other devices will be activated
                if (isAtLeastOneFlameOn || isAtLeastOneHeightCtrlActive)
                { 
                  await Calibration_StopCalibration();
                }
                // start calibration for all other devices
                else
                {
                  await Calibration_StartCalibration();
                }
              }

              // If at least in one device is flame active, then activate flame for all other devices
              if (isAtLeastOneFlameOn)
              { 
                // This is necessary so that all torches ignite simultaneously
                await ihtDevices.SetupCtrl_SetStartCommonAsync();
                //devices = ihtDevices.GetEnabledDevices();
                foreach (IhtDevice device in devices)
                {
                  device.dataCmdExecution.IsFlameOn = true;
                }
              }

              // If at least in one device is height control active, then activate height control for all other devices
              if (isAtLeastOneHeightCtrlActive)
              { 
                await TurnHCOnAsync();
              }
            }
        }

        private string GetCalibrationClass()
        {
            /*
            if (IsBroadCastMode)
            {
                var devices = ihtDevices.GetEnabledDevices();
                var dataClass = "central_btn";

                if (devices.Cast<IhtDevice>().Any(d => d.dataCmdExecution.IsCalibrationActive))
                {
                    dataClass = "central_btn active";
                }

                return dataClass;
            }
            else
            */
            {
                var CurrentDevice_IsCalibrationActive = false;

                if (CurrentDevice != null && CurrentDevice.dataProcessInfo != null)
                {
                    CurrentDevice_IsCalibrationActive = CurrentDevice.dataProcessInfo.IsCalibrationActive;
                }

                if (!CurrentDevice_IsCalibrationActive)
                {
                    if (_isCalibrationActive && stopwatch.ElapsedMilliseconds > 2000)
                    {
                        _isCalibrationActive = false;
                        _ = ihtDevices.StopCalibrationAsync(CurrentSlaveId);
                    }
                }

                return _isCalibrationActive ? "central_btn active" : "central_btn";
            }
        }

        private void GetDeviceCalibrationState(IhtDevice ihtDevice)
        {
            var ProcessInfo_IsCalibrationActive = false;

            if (ihtDevice != null && ihtDevice.dataProcessInfo != null)
            {
                ProcessInfo_IsCalibrationActive = ihtDevice.dataProcessInfo.IsCalibrationActive;

                if (!ProcessInfo_IsCalibrationActive)
                {
                    if (ihtDevice.dataCmdExecution.IsCalibrationActive && stopwatch.ElapsedMilliseconds > 2000)
                    {
                        ihtDevice.dataCmdExecution.IsCalibrationActive = false;
                        _ = ihtDevices.StopCalibrationAsync(ihtDevice.SlaveId);
                    }
                }
            }
        }

        private async Task Calibration_StartCalibration()
        {
            stopwatch.Restart();

            if (IsBroadCastMode)
            {
                var devices = ihtDevices.GetEnabledDevices();
                foreach (IhtDevice device in devices)
                {
                    device.dataCmdExecution.IsCalibrationActive = true;

                    await ihtDevices.StartCalibrationAsync(device.SlaveId);
                }
            }
            else
            {
                _isCalibrationActive = true;

                await ihtDevices.StartCalibrationAsync(CurrentSlaveId);
            }

        }

        private async Task Calibration_StopCalibration()
        {
            if (IsBroadCastMode)
            {
                var devices = ihtDevices.GetEnabledDevices();
                foreach (IhtDevice device in devices)
                {
                    device.dataCmdExecution.IsCalibrationActive = false;

                    await ihtDevices.StopCalibrationAsync(device.SlaveId);
                }
            }
            else
            {
                _isCalibrationActive = false;

                await ihtDevices.StopCalibrationAsync(CurrentSlaveId);
            }

        }

        private async Task Exhibition_StartProcess()
        {
            await ihtDevices.StartProcessOnCommonAsync();

        }
        private async Task Exhibition_StopProcess()
        {
            await ihtDevices.StopProcessOnCommonAsync();
        }

        private async Task StartPiercingAsync()
        {
            if (_isStartPiercingActive)
            {
                await ihtDevices.StopPreHeatTimeCommonAsync();

                _isStartPiercingActive = false;
            }
        }

        private async Task ReloadPreHeatingTimeAsync()
        {
            if (_isReloadPreHeatingTimeActive)
            {
                await ihtDevices.ReloadPreHeatTimeCommonAsync();

                _isReloadPreHeatingTimeActive = false;
            }
        }

        private bool IsStartPiercingDisabled()
        {
            return !IsLedPreHeating;
        }
        private bool IsReloadPreHeatingTimeDisabled()
        {
            return !IsLedPreHeating;
        }

        public bool IsControlsActive { get; set; }
        public void DataProviderIsControlsActive(object sender, ProcessInfoEventArgs<bool> e)
        {
          Console.WriteLine($"OldValue = {e.OldValue}, NewValue = {e.NewValue}");
          IsControlsActive = e.NewValue;
        }

        public bool IsProcessesActive { get; set; }
        public void DataProviderIsProcessesActive(object sender, ProcessInfoEventArgs<bool> e)
        {
          Console.WriteLine($"OldValue = {e.OldValue}, NewValue = {e.NewValue}");
          IsProcessesActive = e.NewValue;
          if (_isProcessModeClearenceCtrlOff && !e.NewValue)
          {
            _isProcessModeClearenceCtrlOff = false;
            _ = ihtDevices.ClrClearenceCtrlOffCommonAsync();
          }
          if (!IsStartProcessDisabled() && !e.NewValue)
          { 
            _ = ihtDevices.StopProcessOnCommonAsync();
          }

          if (ComponentMode != PROCESS_MODE)
          {
            GoToPage(PROCESS_MODE);
          }
        }

        public bool IsClearanceControlsManual { get; set; }
        public void DataProviderIsClearanceControlsManual(object sender, ProcessInfoEventArgs<bool> e)
        {
          Console.WriteLine($"OldValue = {e.OldValue}, NewValue = {e.NewValue}");
          IsClearanceControlsManual = e.NewValue;
          if (!_isManHeightActive.Equals(e.NewValue))
          {
            _isManHeightActive = e.NewValue;
          }
        }

        public void DataProviderIsCuttingDataBaseIdChanged(object sender, ProcessInfoEventArgs<int> e)
        {
          //CuttingDataBaseId = e.NewValue;
          InvokeAsync(StateHasChanged);
        }
    }
}