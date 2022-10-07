using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics;

namespace BlazorServerHost.Pages
{
    public partial class DynDataModificationCNC
    {
        [Inject] public IJSRuntime? JS { get; set; }

        private IJSObjectReference? _module;
        private DotNetObjectReference<DynDataModificationCNC>? _selfReference;
        private bool _isTorchUpActive = false;
        private bool _isTorchDownActive = false;
        private bool _isHCTorchUpActive = false;
        private bool _isHCTorchDownActive = false;
        private bool _isCalibrationActive = false;
        private bool _isStartPiercingActive = false;
        private bool _isReloadPreHeatingTimeActive = false;
        private bool _isFlameOnEndActive = false;

        private bool _isFlameOn = false;
        //private bool _isFlameOff = true;

        private bool _isLedPreHeating = false;
        public bool IsLedPreHeating
        {
            get {

                if(!_isLedPreHeating && ihtDevices.GetDataProcessInfo(SlaveId).IsLedPreHeating)
                {
                    SetMaxHeatTimeProgressValue(ihtDevices.GetDataProcessInfo(SlaveId).CurrHeatTime);
                }

                _isLedPreHeating = ihtDevices.GetDataProcessInfo(SlaveId).IsLedPreHeating;

                return _isLedPreHeating; 
            }
            set {}
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

        private string GetCalibrationClass()
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
                }
            }

            return _isCalibrationActive ? "central_btn active" : "central_btn";
        }

        private async Task Calibration_StartCalibration()
        {
            stopwatch.Restart();

            _isCalibrationActive = true;
            await ihtDevices.StartCalibrationAsync(SlaveId);

        }
        private async Task Calibration_StopCalibration()
        {
            _isCalibrationActive = false;
            await ihtDevices.StopCalibrationAsync(SlaveId);

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
