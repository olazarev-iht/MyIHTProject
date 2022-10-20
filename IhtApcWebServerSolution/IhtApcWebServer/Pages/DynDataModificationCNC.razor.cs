using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SharedComponents.IhtDev;
using System.Diagnostics;

namespace IhtApcWebServer.Pages
{
    public partial class DynDataModificationCNC
    {
        [Inject] public IJSRuntime? JS { get; set; }

        private IJSObjectReference? _module;
        private DotNetObjectReference<DynDataModificationCNC>? _selfReference;

        private bool _isSumTorchesActive = false;

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

        
        private Stopwatch stopwatch = new Stopwatch();

        [JSInvokable]
        public async Task Deactivate(string eventName)
        {
            var en = eventName;

            await DeactiveButton(eventName);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
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

        private async Task TurnHCOnOffAsync()
        {
            if (!_isHCOnOffActive)
            {
                await TurnHCOnAsync();
            }
            else
            {
                await TurnHCOffAsync();
            }
        }

        private async Task TurnHCOnAsync()
        {
            _isHCOnOffActive = true;

            await SetParamsType(CurrentParamsType);
        }

        private async Task TurnHCOffAsync()
        {
            await ExecHeightCtrlAsync(ihtDevices.HeightControlOffAsync, IsHCOnOffActive: false);
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
                _isFlameOn = true;
            }

            await InvokeAsync(StateHasChanged);

            if (IsBroadCastMode)
            {
                var devices = ihtDevices.GetOnDevices();
                foreach (IhtDevice device in devices)
                {
                  ihtDevices.GetDataCmdExecution(device.SlaveId).IsFlameOn = _isFlameOn;
                  await ihtDevices.SetupCtrl_SetStartAsync(device.SlaveId);
                }
            }
            else
            {
              await ihtDevices.SetupCtrl_SetStartAsync(CurrentSlaveId);
            }

            await SetParamsType(IGNITION);

        }

        private async Task TurnFlameOffAsync()
        {
            if (_isFlameOn)
            {
                _isFlameOn = false;
            }

            await InvokeAsync(StateHasChanged);

            var devices = ihtDevices.GetOnDevices();
            foreach (IhtDevice device in devices)
            {
                ihtDevices.GetDataCmdExecution(device.SlaveId).IsFlameOn = _isFlameOn;
                await ihtDevices.SetupCtrl_SetOffAsync(device.SlaveId);
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

        private async Task StartFlameOnEndAsync()
        {
            if (!_isFlameOnEndActive)
            {
                _isFlameOnEndActive = true;
                await ihtDevices.SetFlameOnAtProcessEndCommonAsync();
            }
            else
            {
                _isFlameOnEndActive = false;
                await ihtDevices.ClrFlameOnAtProcessEndCommonAsync();
            }
        }

        private async Task StartSumTorchesAsync()
        {
            if (!_isSumTorchesActive)
            {
                _isSumTorchesActive = true;
                dynDataModificationCNCDataProvider.IsBroadCastMode = true;

                await ihtDevices.SetFlameOnAtProcessEndCommonAsync();
            }
            else
            {
                _isSumTorchesActive = false;
                dynDataModificationCNCDataProvider.IsBroadCastMode = false;

                await ihtDevices.ClrFlameOnAtProcessEndCommonAsync();
            }
        }

        private string GetCalibrationClass()
        {
            if (IsBroadCastMode)
            {
                var devices = ihtDevices.GetOnDevices();
                var dataClass = "central_btn";

                if (devices.Cast<IhtDevice>().Any(d => d.dataCmdExecution.IsCalibrationActive))
                {
                    dataClass = "central_btn active";
                }

                return dataClass;
            }
            else
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
                var devices = ihtDevices.GetOnDevices();
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
                var devices = ihtDevices.GetOnDevices();
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
    }
}
