using BlazorServerHost.Features.Models;
using BlazorServerHost.Services.APCWorkerService;
using SharedComponents.Models;

namespace BlazorServerHost.Features.HeightControlFeature.Services
{
	public class LiveAPCParamsDataProvider : IDisposable
	{
		public event EventHandler? LiveAPCParamsDataChanged;
		public LiveAPCParamsModel CurrentLiveAPCParams { get; set; } = new();

		private readonly IAPCWorkerService _apcWorkerService;

		public LiveAPCParamsDataProvider(IAPCWorkerService apcWorkerService)
		{
			_apcWorkerService = apcWorkerService ?? throw new ArgumentNullException(nameof(apcWorkerService));

			_apcWorkerService.WorkerStatusChanged += _apcWorkerService_WorkerStatusChanged;
		}

		private void _apcWorkerService_WorkerStatusChanged(object? sender, EventArgs e)
		{
			var singletonAPCLiveParamsDictionary = _apcWorkerService.CurrentState.HardwareAPCList.Select(apc =>
				new { Id = int.Parse(apc.DeviceName?.Last().ToString() ?? "0"), apc.LiveParams }).ToDictionary(lp => lp.Id);

			for (var i = 1; i < singletonAPCLiveParamsDictionary.Count+1; i++)
			{
				if (CurrentLiveAPCParams.LiveParamsInfos.Count == 0 
					|| singletonAPCLiveParamsDictionary[i].LiveParams?.LiveParam1 != (CurrentLiveAPCParams.LiveParamsInfos[i]?.LiveParam1 ?? 0)
					|| singletonAPCLiveParamsDictionary[i].LiveParams?.LiveParam2 != (CurrentLiveAPCParams.LiveParamsInfos[i]?.LiveParam2 ?? 0)
					|| singletonAPCLiveParamsDictionary[i].LiveParams?.LiveParam3 != (CurrentLiveAPCParams.LiveParamsInfos[i]?.LiveParam3 ?? 0))
				{
					CurrentLiveAPCParams.LiveParamsInfos.ToList().ForEach(kvp =>
						{
							kvp.Value.LiveParam1 = singletonAPCLiveParamsDictionary[kvp.Key]?.LiveParams?.LiveParam1 ?? 0;
							kvp.Value.LiveParam2 = singletonAPCLiveParamsDictionary[kvp.Key]?.LiveParams?.LiveParam2 ?? 0;
							kvp.Value.LiveParam3 = singletonAPCLiveParamsDictionary[kvp.Key]?.LiveParams?.LiveParam3 ?? 0;
						});

					OnLiveAPCParamsDataChanged();

					break;
				}
			}
		}

		public void Dispose()
		{
			_apcWorkerService.WorkerStatusChanged -= _apcWorkerService_WorkerStatusChanged;
		}

		protected virtual void OnLiveAPCParamsDataChanged()
		{
			LiveAPCParamsDataChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
