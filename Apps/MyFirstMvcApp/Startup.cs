using MyFirstMvcApp.Controllers;
using MyServer.HTTP;
using MyServer.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    public class Startup : IMvcApplication
    {
        public void ConfigureService()
        {
            
        }

        public void Configure(List<Route> routeTable)
        {
            
            routeTable.Add(new Route("/", HttpMethodEnum.GET ,new HomeController().Index));
            routeTable.Add(new Route("/favicon.ico", HttpMethodEnum.GET, new StaticFilesController().Favicon));
            routeTable.Add(new Route("/css/custom.css", HttpMethodEnum.GET, new StaticFilesController().CustomCss));
            routeTable.Add(new Route("/css/bootstrap.min.css", HttpMethodEnum.GET, new StaticFilesController().BoostrapCss));
            routeTable.Add(new Route("/js/bootstrap.bundle.min.js", HttpMethodEnum.GET, new StaticFilesController().BoostrapJs));
            routeTable.Add(new Route("/js/custom.js", HttpMethodEnum.GET, new StaticFilesController().CustomJs));
            routeTable.Add(new Route("/Users/Login", HttpMethodEnum.GET, new UsersController().Login));
            routeTable.Add(new Route("/Users/Register", HttpMethodEnum.GET, new UsersController().Register));
            routeTable.Add(new Route("/Cars/Add", HttpMethodEnum.GET, new CarsController().Add));
            routeTable.Add(new Route("/Cars/Add", HttpMethodEnum.POST, new CarsController().AddUser));
            routeTable.Add(new Route("/Cars/All", HttpMethodEnum.GET, new CarsController().All));
        }
    }
}
