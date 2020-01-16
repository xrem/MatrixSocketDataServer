using System;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace MatrixSocketDataServer
{
    public static class Program {
        private static bool _running = true;
        public static readonly Logger Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console()
            .WriteTo.File("log.txt", LogEventLevel.Information)
            .CreateLogger();

        public static void Main(string[] args) {
            var server = new Server();

            Logger.Debug("Server starting...");
            server.Start();

            Console.CancelKeyPress += (sender, e) => {
                e.Cancel = true;
                Program._running = false;
            };

            while (Program._running) {
                //
            }

            Logger.Debug("Shutting down server...");
            server.Stop();
        }
    }
}
