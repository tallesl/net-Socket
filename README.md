<p align="center">
    <a href="#socketthat">
        <img alt="logo" src="logo.png">
    </a>
</p>

# SocketThat

[![nuget package](https://badge.fury.io/nu/SocketThat.png)](http://badge.fury.io/nu/SocketThat)

A minimalist wrapper around a .NET's [Stream][Stream] [IPv4][IPv4] [TCP][TCP] [Socket][Socket].

Everything is synchronous.

[Stream]: http://msdn.microsoft.com/library/system.net.sockets.addressfamily
[IPv4]:   http://msdn.microsoft.com/library/system.net.sockets.sockettype
[TCP]:    http://msdn.microsoft.com/library/system.net.sockets.protocoltype
[Socket]: http://msdn.microsoft.com/library/system.net.sockets.socket

## An stupid echo server

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

## And its client

```cs
using (var socket = new ConnectedSocket("127.0.0.1", 1337)) // Connects to 127.0.0.1 on port 1337
{
    socket.Send("Hello world!"); // Sends some data
    var data = socket.Receive(); // Receives some data back (blocks execution)
}
```
