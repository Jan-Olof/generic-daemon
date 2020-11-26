using functional.common.messages;
using functional.common.time;
using functional.common.unique_Identifier;
using functional.core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace functional.daemon
{
    public class Daemon : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IMessageHandling _messageHandling;
        private readonly IGuid _guid;
        private readonly INow _now;

        /// <summary>
        /// Initializes a new instance of the <see cref="Daemon" /> class.
        /// </summary>
        public Daemon(ILogger<Daemon> logger, IMessageHandling messageHandling, INow now, IGuid guid)
        {
            _logger = logger;
            _messageHandling = messageHandling;
            _guid = guid;
            _now = now;
        }

        /// <inheritdoc />
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Daemon is running ExecuteAsync.");
            _logger.LogDebug("Extra debug logging is shown.");

            _messageHandling.HandleMessages(ProcessMessage.Process(_now.Now, _guid.GetGuid));

            await Task.CompletedTask;
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
            _logger.LogInformation("Daemon is disposed.");
        }
    }
}