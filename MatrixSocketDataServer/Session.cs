using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using NetCoreServer;

namespace MatrixSocketDataServer {
    class Session : TcpSession
    {
        public Session(TcpServer server) : base(server) {}

        protected override void OnConnected()
        {
            Program.Logger.Debug($"TCP session with Id {Id} connected!");
        }

        protected override void OnDisconnected()
        {
            Program.Logger.Debug($"TCP session with Id {Id} disconnected!");
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            Program.Logger.Information($"{Id} Incoming: ");
            var data = buffer.Skip((int) offset).Take((int) size).ToArray();
            Program.Logger.Information(BitConverter.ToString(data));
            Program.Logger.Information("-------------");
        }

        protected override void OnError(SocketError error)
        {
            Program.Logger.Debug($"TCP session {Id} caught an error with code {error}");
        }
    }
}