using MyServer.HTTP;
using MyServer.HTTP.Interfaces;
using System;

using System.Threading.Tasks;

namespace MyServer.MvcFramework
{
    public static class WebHost
    {
        public static async Task CreateHostAsync(List<Route> routeTable, int port = 80)
        {
            IHttpServer httpServer = new HttpServer(routeTable);


            await httpServer.StartAsync(port);
        }
    }
}
