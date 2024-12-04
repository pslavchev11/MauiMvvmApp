using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    internal class FileLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _logFilePath;

        public FileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
            _logMessages = new ConcurrentDictionary<int, string>();
        }

        public IDisposable? BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            var formattedMessage = $"[{logLevel}] [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";

            File.AppendAllText(_logFilePath, formattedMessage);

            _logMessages[eventId.Id] = message;
        }
    }
}
