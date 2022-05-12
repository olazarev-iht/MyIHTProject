using BlazorServerHost.Features.Models;
using BlazorServerHost.Services.APCWorkerService;
using SharedComponents.Models;

namespace BlazorServerHost.Features.HeightControlFeature.Services
{
	public class DynamicAPCParamsDataProvider : IDisposable
	{
		public event EventHandler? DynamicAPCParamsDataChanged;
		public DynamicAPCParamsModel CurrentDynamicAPCParams { get; set; } = new();

		private readonly IAPCWorkerService _apcWorkerService;

		public DynamicAPCParamsDataProvider(IAPCWorkerService apcWorkerService)
		{
			_apcWorkerService = apcWorkerService ?? throw new ArgumentNullException(nameof(apcWorkerService));

			_apcWorkerService.WorkerStatusChanged += _apcWorkerService_WorkerStatusChanged;
		}

		private void _apcWorkerService_WorkerStatusChanged(object? sender, EventArgs e)
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
			_apcWorkerService.WorkerStatusChanged -= _apcWorkerService_WorkerStatusChanged;
		}

		protected virtual void OnDynamicAPCParamsDataChanged()
		{
			DynamicAPCParamsDataChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}

