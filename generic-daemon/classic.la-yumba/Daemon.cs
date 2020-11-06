using classic.common.messages;
using classic.core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace c_sharp_la_yumba
{
    public class Daemon : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IMessageHandling _messageHandling;

        /// <summary>
        /// Initializes a new instance of the <see cref="Daemon" /> class.
        /// </summary>
        public Daemon(ILogger<Daemon> logger, IMessageHandling messageHandling)
        {
            _logger = logger;
            _messageHandling = messageHandling;
        }

        /// <inheritdoc />
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Daemon is running ExecuteAsync.");
            _logger.LogDebug("Extra debug logging is shown.");

            _messageHandling.HandleMessages(ProcessMessage.Process());

            await Task.CompletedTask;
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();

            _logger.LogInformation("Daemon is disposed.");
        }
    }
}