using System.Net;
using System.Net.Sockets;
using System.Text;

var ipEndpoint = new IPEndPoint(new IPAddress(new byte[] {127,0,0,1}), 1234);
using Socket listener = new(ipEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

listener.Bind(ipEndpoint);
listener.Listen(100);

var handler = await listener.AcceptAsync();
while(true)
{
    var buffer = new byte[1_024];
    var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
    var response = Encoding.UTF8.GetString(buffer, 0, received);
}