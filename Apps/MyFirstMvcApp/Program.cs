namespace MyFirstMvcApp
{
    using Microsoft.Win32;
    using MyFirstMvcApp.Controllers;
    using MyServer.HTTP;


    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpServer httpServer = new HttpServer();
            httpServer.AddRoute("/Home", new HomeController().HomePage);
            httpServer.AddRoute("/favicon.ico", new HomeController().Favicon);
            httpServer.AddRoute("/Login", new UsersController().Login);
            httpServer.AddRoute("/Register", new UsersController().Register);
            await httpServer.StartAsync(1522);
        }
    }
}