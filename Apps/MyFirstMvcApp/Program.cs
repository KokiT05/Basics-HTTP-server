namespace MyFirstMvcApp
{
    using MyServer.HTTP;
    using System.Text;

    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpServer httpServer = new HttpServer();
            httpServer.AddRoute("/Home", HomePage);
            httpServer.AddRoute("/favicon.ico", Favicon);
            httpServer.AddRoute("/Login", Login);
            await httpServer.StartAsync(1522);
        }

        static HttpResponse HomePage(HttpRequest httpRequest)
        {
            string responseHtml = "<h1>Home Page</h1>";
            byte[] responseHtmlBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse httpResponse = new HttpResponse("text/html", responseHtmlBytes);
            httpResponse.Headers.Add(new Header("Server", "MyFirstServer"));
            httpResponse.Cookies.Add(new ResponseCookie("sid", "123") { HttpOnly = true, MaxAge = (3 * 24 * 60 * 60) });
            return httpResponse;
        }

        static HttpResponse Login(HttpRequest httpRequest)
        {
            string responseHtml = "<h1>Login</h1>";
            byte[] responseHtmlBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse httpResponse = new HttpResponse("text/html", responseHtmlBytes);
            httpResponse.Headers.Add(new Header("Server", "MyFirstServer"));
            httpResponse.Cookies.Add(new ResponseCookie("sid", "123") { HttpOnly = true, MaxAge = (3 * 24 * 60 * 60) });
            return httpResponse;
        }

        static HttpResponse Favicon(HttpRequest httpRequest)
        {
            byte[] favIconAsByte = File.ReadAllBytes("wwwroot\\favicon.ico");

            HttpResponse httpResponse = new HttpResponse("image/vnd.microsoft.icon", favIconAsByte);
            return httpResponse;
        }
    }
}