namespace SocketLibrary
{
    using System;
    using System.Net;
    using System.Net.Sockets;

    /// <summary>
    /// An IPv4 TCP socket listener.
    /// </summary>
    public class SocketListener : IDisposable
    {
        /// <summary>
        /// Constructs and listens in the given port.
        /// </summary>
        /// <param name="port">Port to listen</param>
        /// <param name="ip">IP to listen (defaults to 127.0.0.1)</param>
        /// <param name="backlog">Number of incoming connections that can be queued for acceptance</param>
        /// <exception cref="ArgumentException">ip contains Unicode characters.</exception>
        /// <exception cref="ArgumentException">ip is null.</exception>
        /// <exception cref="FormatException">ip is not a valid IP address</exception>
        /// <exception cref="SocketException">An error occurred when attempting to access the socket.</exception>
        public SocketListener(int port, string ip = "127.0.0.1", int backlog = 10)
        {
            var _ip = IPAddress.Parse(ip);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(_ip, port));
            _socket.Listen(backlog);
        }

        /// <summary>
        /// The underlying socket.
        /// </summary>
        private readonly Socket _socket;

        /// <summary>
        /// Accepts a connection.
        /// This blocks the execution until a connection is made.
        /// </summary>
        /// <returns>The connected socket</returns>
        /// <exception cref="SocketException">An error occurred when attempting to access the socket.</exception>
        public ConnectedSocket Accept()
        {
            return new ConnectedSocket(_socket.Accept());
        }

        /// <summary>
        /// Disposes the listener.
        /// </summary>
        public void Dispose()
        {
            _socket.Dispose();
        }
    }
}
