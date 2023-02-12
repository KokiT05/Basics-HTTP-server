namespace MyFirstMvcApp
{
    using Microsoft.Win32;
    using MyFirstMvcApp.Controllers;
    using MyServer.HTTP;
    using MyServer.MvcFramework;

    public class Program
    {
        public static async Task Main(string[] args)
        {


            await WebHost.CreateHostAsync(new Startup(), 1522);
        }
    }
}