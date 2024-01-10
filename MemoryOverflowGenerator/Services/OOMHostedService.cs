
using System.Collections.Concurrent;

namespace MemoryOverflowGenerator.Services
{
    public class OOMHostedService : IHostedService
    {
        public static volatile bool OnOff = false;
        public static ConcurrentBag<byte[]> MEMORY = new ConcurrentBag<byte[]>();

        private int executionCount = 0;
        private readonly ILogger<OOMHostedService> _logger;
        private Timer? _timer = null;

        public OOMHostedService(ILogger<OOMHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            if (OnOff)
            {
                var count = Interlocked.Increment(ref executionCount);
                OOMHostedService.MEMORY.Add(new byte[10 * 1024 * 1024]);
                _logger.LogInformation(
                    "Timed Hosted Service is working. Count: {Count}", count);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
