using System.Net;
using System.Net.Sockets;
using NetCoreServer;

namespace MatrixSocketDataServer {
    class Server : TcpServer
    {
        public Server() : base(IPAddress.Any, 5555) {}

        protected override TcpSession CreateSession() {
            return new Session(this);
        }

        protected override void OnStarted() {
            Program.Logger.Debug($"Listening on {this.Endpoint}");
        }

        protected override void OnStopped() {
            Program.Logger.Debug("Server stopped.");
        }

        protected override void OnError(SocketError error)
        {
            Program.Logger.Debug($"TCP server caught an error with code {error}");
        }
    }
}