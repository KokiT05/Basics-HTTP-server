using System.Net.Sockets;
using System.Net;

namespace MyServer.HTTP.Interfaces
{
    public interface IHttpServer
    {

        Task StartAsync(int port = 80);

        //void Stop();
    }
}
