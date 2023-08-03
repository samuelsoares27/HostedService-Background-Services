namespace HostedService.HostedService
{
    public class TimerHostedService : IHostedService
    {
        private readonly ILogger _logger;

        public TimerHostedService (ILogger<TimerHostedService> logger)
        {
            _logger = logger;
        }
        private void ExecuteProcess(object? state)
        {
            _logger.LogInformation("### Process executing ###");
            _logger.LogInformation(DateTime.Now.ToString());
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("### Process stoping ###");
            _logger.LogInformation(DateTime.Now.ToString());
            return Task.CompletedTask;
        }
    }
}
