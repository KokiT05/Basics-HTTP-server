using MyServer.HTTP;
using MyServer.HTTP.Interfaces;
using System;

using System.Threading.Tasks;

namespace MyServer.MvcFramework
{
    public static class WebHost
    {
        public static async Task CreateHostAsync(IMvcApplication mvcApplication, int port = 80)
        {
            List<Route> routeTable = new List<Route>();
            mvcApplication.ConfigureService();
            mvcApplication.Configure(routeTable);

            IHttpServer httpServer = new HttpServer(routeTable);


            await httpServer.StartAsync(port);
        }
    }
}
