using BlazorServerHost.Features.Models;
using BlazorServerHost.Services.APCWorkerService;
using SharedComponents.Models;
using SharedComponents.Services;

namespace BlazorServerHost.Features.HeightControlFeature.Services
{
	public class DynamicAPCParamsDataProvider : IDisposable
	{
		public event EventHandler? DynamicAPCParamsDataChanged;
		public DynamicAPCParamsModel CurrentDynamicAPCParams { get; set; } = new();

		private readonly IAPCWorkerService _apcWorkerService;

		private readonly IHardwareAPCServise _hardwareAPCServise;

		public DynamicAPCParamsDataProvider(IAPCWorkerService apcWorkerService, IHardwareAPCServise hardwareAPCServise)
		{
			_apcWorkerService = apcWorkerService ?? throw new ArgumentNullException(nameof(apcWorkerService));

			_hardwareAPCServise = hardwareAPCServise ?? throw new ArgumentNullException(nameof(hardwareAPCServise));

			_apcWorkerService.DynamicDataChanged += _apcWorkerService_DymanicDataChanged;


		}

		public async void dynamicParamsDysplay_DynamicAPCParamsClientChanged(object? sender, EventArgs e)
        {
			await _hardwareAPCServise.UpdateDynamicDataAsync(CurrentDynamicAPCParams.DynamicParamsInfos, CancellationToken.None);

			await _apcWorkerService.RefreshDynamicDataAsync();
		}

		private void _apcWorkerService_DymanicDataChanged(object? sender, EventArgs e)
		{
			var singletonAPCDynamicParamsDictionary = _apcWorkerService.CurrentState.HardwareAPCList.Select(apc =>
				new { Id = int.Parse(apc.DeviceName?.Last().ToString() ?? "0"), apc.DynamicParams }).ToDictionary(lp => lp.Id);

			for (var i = 1; i < singletonAPCDynamicParamsDictionary.Count + 1; i++)
			{
				if (CurrentDynamicAPCParams.DynamicParamsInfos.Count == 0
					|| singletonAPCDynamicParamsDictionary[i].DynamicParams?.DynamicParam1 != (CurrentDynamicAPCParams.DynamicParamsInfos[i]?.DynamicParam1 ?? 0)
					|| singletonAPCDynamicParamsDictionary[i].DynamicParams?.DynamicParam1 != (CurrentDynamicAPCParams.DynamicParamsInfos[i]?.DynamicParam2 ?? 0)
					|| singletonAPCDynamicParamsDictionary[i].DynamicParams?.DynamicParam1 != (CurrentDynamicAPCParams.DynamicParamsInfos[i]?.DynamicParam3 ?? 0))
				{
					CurrentDynamicAPCParams.DynamicParamsInfos.ToList().ForEach(kvp =>
					{
						kvp.Value.DynamicParam1 = singletonAPCDynamicParamsDictionary[kvp.Key]?.DynamicParams?.DynamicParam1 ?? 0;
						kvp.Value.DynamicParam2 = singletonAPCDynamicParamsDictionary[kvp.Key]?.DynamicParams?.DynamicParam2 ?? 0;
						kvp.Value.DynamicParam3 = singletonAPCDynamicParamsDictionary[kvp.Key]?.DynamicParams?.DynamicParam3 ?? 0;
					});

					OnDynamicAPCParamsDataChanged();

					break;
				}
			}
		}

		public void Dispose()
		{
			_apcWorkerService.DynamicDataChanged -= _apcWorkerService_DymanicDataChanged;
		}

		protected virtual void OnDynamicAPCParamsDataChanged()
		{
			DynamicAPCParamsDataChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}

