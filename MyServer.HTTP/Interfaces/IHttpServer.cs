using System.Net.Sockets;
using System.Net;

namespace MyServer.HTTP.Interfaces
{
    public interface IHttpServer
    {
        void AddRoute(string routeName, Func<HttpRequest, HttpResponse> action);

        Task StartAsync(int port = 80);

        //void Stop();
    }
}
