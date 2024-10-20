using EstudosDockerServicoTheWork.Services;

namespace EstudosDockerServicoTheWork
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMessageService _message;

        public Worker(ILogger<Worker> logger, IMessageService message)
        {
            _logger = logger;
            _message = message;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                await Task.Delay(1000, stoppingToken);

                _message.Enqueue();
            }
        }
    }
}
