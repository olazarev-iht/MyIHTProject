namespace BlazorServerHost.Services.APCWorkerService
{
    public class APCWorkerBackgroundService : BackgroundService
    {
        private readonly ILogger<APCWorkerBackgroundService> _logger;
        //public IHostApplicationLifetime _hostApplicationLifetime;
        public static CancellationTokenSource? _stoppingCts;
        //private CancellationToken _stoppingToken;
        private Task? _executeTask;

        public APCWorkerBackgroundService(IServiceProvider services,
            ILogger<APCWorkerBackgroundService> logger)
        {
            Services = services;
            _logger = logger;

        }

        public IServiceProvider Services { get; }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            // Create linked token to allow cancelling executing task from provided token
            _stoppingCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            // Store the task we're executing
            _executeTask = ExecuteAsync(_stoppingCts.Token);

            // If the task is completed then return it, this will bubble cancellation and failure to the caller
            if (_executeTask.IsCompleted)
            {
                return _executeTask;
            }

            // Otherwise it's running
            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consume Scoped Service Hosted Service running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consume Scoped Service Hosted Service is working.");

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IAPCWorker>();

                await scopedProcessingService.DoWork(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consume Scoped Service Hosted Service is stopping.");

            _stoppingCts?.Cancel();

            //await base.StopAsync(stoppingToken);
        }

        //public override async Task StopAsync(CancellationToken cancellationToken)
        //{
        //    // Stop called without start
        //    if (_executeTask == null)
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        // Signal cancellation to the executing method
        //        _stoppingCts!.Cancel();
        //    }
        //    finally
        //    {
        //        // Wait until the task completes or the stop token triggers
        //        var tcs = new TaskCompletionSource<object>();
        //        using CancellationTokenRegistration registration = cancellationToken.Register(s => ((TaskCompletionSource<object>)s!).SetCanceled(), tcs);
        //        // Do not await the _executeTask because cancelling it will throw an OperationCanceledException which we are explicitly ignoring
        //        await Task.WhenAny(_executeTask, tcs.Task).ConfigureAwait(false);
        //    }

        //}

    }
}
