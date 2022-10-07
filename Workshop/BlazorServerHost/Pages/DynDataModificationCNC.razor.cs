using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SharedComponents.IhtDev;
using System.Diagnostics;

namespace BlazorServerHost.Pages
{
    public partial class DynDataModificationCNC
    {
        [Inject] public IJSRuntime? JS { get; set; }

        private IJSObjectReference? _module;
        private DotNetObjectReference<DynDataModificationCNC>? _selfReference;
        //private bool _isTorchUpActive = false;
        //private bool _isTorchDownActive = false;
        //private bool _isHCTorchUpActive = false;
        //private bool _isHCTorchDownActive = false;
        //private bool _isCalibrationActive = false;
        //private bool _isStartPiercingActive = false;
        //private bool _isReloadPreHeatingTimeActive = false;
        //private bool _isFlameOnEndActive = false;
        //private bool _isFlameOn = false;

        private bool _isSumTorchesActive = false;

        private bool _isTorchUpActive
        {
            get => ihtDevices.GetDataCmdExecution(SlaveId).IsTorchUpActive;
            set => ihtDevices.GetDataCmdExecution(SlaveId).IsTorchUpActive = value;
        }

        private bool _isTorchDownActive
        {
            get => ihtDevices.GetDataCmdExecution(SlaveId).IsTorchDownActive;
            set => ihtDevices.GetDataCmdExecution(SlaveId).IsTorchDownActive = value;
        }

        private bool _isHCTorchUpActive
        {
            get => ihtDevices.GetDataCmdExecution(SlaveId).IsHCTorchUpActive;
            set => ihtDevices.GetDataCmdExecution(SlaveId).IsHCTorchUpActive = value;
        }

        private bool _isHCTorchDownActive
        {
            get => ihtDevices.GetDataCmdExecution(SlaveId).IsHCTorchDownActive;
            set => ihtDevices.GetDataCmdExecution(SlaveId).IsHCTorchDownActive = value;
        }

        private bool _isCalibrationActive
        {
            get => ihtDevices.GetDataCmdExecution(SlaveId).IsCalibrationActive;
            set => ihtDevices.GetDataCmdExecution(SlaveId).IsCalibrationActive = value;
        }

        private bool _isStartPiercingActive
        {
            get => ihtDevices.GetDataCmdExecution(SlaveId).IsStartPiercingActive;
            set => ihtDevices.GetDataCmdExecution(SlaveId).IsStartPiercingActive = value;
        }

        private bool _isReloadPreHeatingTimeActive
        {
            get => ihtDevices.GetDataCmdExecution(SlaveId).IsReloadPreHeatingTimeActive;
            set => ihtDevices.GetDataCmdExecution(SlaveId).IsReloadPreHeatingTimeActive = value;
        }

        private bool _isFlameOnEndActive
        {
            get => ihtDevices.GetDataCmdExecution(SlaveId).IsFlameOnEndActive;
            set => ihtDevices.GetDataCmdExecution(SlaveId).IsFlameOnEndActive = value;
        }

        private bool _isFlameOn
        {
            get => ihtDevices.GetDataCmdExecution(SlaveId).IsFlameOn;
            set => ihtDevices.GetDataCmdExecution(SlaveId).IsFlameOn = value;
        }

        private bool _isLedPreHeating = false;
        public bool IsLedPreHeating
        {
            get
            {

                if (!_isLedPreHeating && ihtDevices.GetDataProcessInfo(SlaveId).IsLedPreHeating)
                {
                    SetMaxHeatTimeProgressValue(ihtDevices.GetDataProcessInfo(SlaveId).CurrHeatTime);
                }

                _isLedPreHeating = ihtDevices.GetDataProcessInfo(SlaveId).IsLedPreHeating;

                return _isLedPreHeating;
            }
            set { }
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

            await ihtDevices.SetupCtrl_SetStartAsync(dynDataModificationCNCDataProvider.CurrentSlaveId);
        }

        private async Task TurnFlameOffAsync()
        {
            if (_isFlameOn)
            {
                _isFlameOn = false;
            }

            await InvokeAsync(StateHasChanged);

            await ihtDevices.SetupCtrl_SetOffAsync(dynDataModificationCNCDataProvider.CurrentSlaveId);
        }
        int SlaveId => dynDataModificationCNCDataProvider.CurrentSlaveId;
        int BroadCastId => dynDataModificationCNCDataProvider.CurrentBroadCastId;

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
                        _ = ihtDevices.StopCalibrationAsync(SlaveId);
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
                    //if (ihtDevice.dataCmdExecution.IsCalibrationActive)
                    {
                        ihtDevice.dataCmdExecution.IsCalibrationActive = false;
                        _ = ihtDevices.StopCalibrationAsync(ihtDevice.SlaveId);
                    }
                }
            }

            //return _isCalibrationActive ? "central_btn active" : "central_btn";
        }

        private async Task Calibration_StartCalibration()
        {
            stopwatch.Restart();

            _isCalibrationActive = true;
            if (IsBroadCastMode)
            {
                var devices = ihtDevices.GetOnDevices();
                foreach (IhtDevice device in devices)
                {
                    await ihtDevices.StartCalibrationAsync(device.SlaveId);
                }
            }
            else
            {
                await ihtDevices.StartCalibrationAsync(SlaveId);
            }

        }
        private async Task Calibration_StopCalibration()
        {
            _isCalibrationActive = false;
            if (IsBroadCastMode)
            {
                var devices = ihtDevices.GetOnDevices();
                foreach (IhtDevice device in devices)
                {
                    await ihtDevices.StopCalibrationAsync(device.SlaveId);
                }
            }
            else
            {
                await ihtDevices.StopCalibrationAsync(SlaveId);
            }

        }

        private async Task Exhibition_StartProcess()
        {
            //_isProcessBtnActive = true;
            await ihtDevices.StartProcessOnCommonAsync();

        }
        private async Task Exhibition_StopProcess()
        {
            //_isProcessBtnActive = false;
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
