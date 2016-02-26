<p align="center">
    <a href="#socket">
        <img alt="logo" src="Assets/logo.png">
    </a>
</p>

# Socket

[![][build-img]][build]
[![][nuget-img]][nuget]

A minimalist wrapper around a .NET's [Stream]&nbsp;[IPv4]&nbsp;[TCP]&nbsp;[Socket].
Everything is synchronous.

[build]:     https://ci.appveyor.com/project/TallesL/net-socket
[build-img]: https://ci.appveyor.com/api/projects/status/github/tallesl/net-socket?svg=true
[nuget]:     https://www.nuget.org/packages/Socket
[nuget-img]: https://badge.fury.io/nu/Socket.svg
[Stream]:    http://msdn.microsoft.com/library/System.Net.Sockets.AddressFamily
[IPv4]:      http://msdn.microsoft.com/library/System.Net.Sockets.SocketType
[TCP]:       http://msdn.microsoft.com/library/System.Net.Sockets.ProtocolType
[Socket]:    http://msdn.microsoft.com/library/System.Net.Sockets.Socket

## Usage

An stupid echo server:

```cs
using (var listener = new SocketListener(1337)) // Start listening
{
    for (;;)
    {
        using (var remote = listener.Accept()) // Accepts a connection (blocks execution)
        {
            var data = remote.Receive(); // Receives data (blocks execution)
            remote.Send(data); // Sends the received data back
        }
    }
}
```

And its client:

```cs
using (var socket = new ConnectedSocket("127.0.0.1", 1337)) // Connects to 127.0.0.1 on port 1337
{
    socket.Send("Hello world!"); // Sends some data
    var data = socket.Receive(); // Receives some data back (blocks execution)
}
```
