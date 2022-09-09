﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorServerHost.Pages
{
    public partial class DynDataModificationCNC
    {
        [Inject] public IJSRuntime? JS { get; set; }

        private IJSObjectReference? _module;
        private DotNetObjectReference<DynDataModificationCNC>? _selfReference;
        private bool _isTorchUpActive = false;
        private bool _isTorchDownActive = false;

        private bool _isFlameOn = false;
        //private bool _isFlameOff = true;

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

        private async Task MoveTorchDownAsync(string newEventName)
        {
            if (!_isTorchUpActive && !_isTorchDownActive)
            {
                _isTorchDownActive = true;

                await ActivatateAsync(newEventName);
            }
        }

        private async Task ActivatateAsync(string newEventName)
        {
            if (_module != null)
            {
                await _module.InvokeVoidAsync("registerMoveEvents", newEventName, _selfReference);
            }

            if (!string.IsNullOrWhiteSpace(newEventName))
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
    }
}
