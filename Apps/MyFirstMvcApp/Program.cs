namespace MyFirstMvcApp
{
    using Microsoft.Win32;
    using MyFirstMvcApp.Controllers;
    using MyServer.HTTP;
    using MyServer.MvcFramework;

    public class Program
    {
        static async Task Main(string[] args)
        {
            List<Route> routeTable = new List<Route>();
            routeTable.Add(new Route("/", new HomeController().Index));
            routeTable.Add(new Route("/favicon.ico", new StaticFilesController().Favicon));
            routeTable.Add(new Route("/css/custom.css", new StaticFilesController().CustomCss));
            routeTable.Add(new Route("/css/bootstrap.min.css", new StaticFilesController().BoostrapCss));
            routeTable.Add(new Route("/js/bootstrap.bundle.min.js", new StaticFilesController().BoostrapJs));
            routeTable.Add(new Route("/js/custom.js", new StaticFilesController().CustomJs));
            routeTable.Add(new Route("/Users/Login", new UsersController().Login));
            routeTable.Add(new Route("/Users/Register", new UsersController().Register));
            routeTable.Add(new Route("/Cars/Add", new CarsController().Add));
            routeTable.Add(new Route("/Cars/All", new CarsController().All));

            await WebHost.CreateHostAsync(routeTable, 1522);
        }
    }
}