using MyServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController
    {
        public HttpResponse HomePage(HttpRequest httpRequest)
        {
            string responseHtml = "<h1>Home Page</h1>";
            byte[] responseHtmlBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse httpResponse = new HttpResponse("text/html", responseHtmlBytes);
            httpResponse.Headers.Add(new Header("Server", "MyFirstServer"));
            httpResponse.Cookies.Add(new ResponseCookie("sid", "TestCookieSid1") { HttpOnly = true, MaxAge = (3 * 24 * 60 * 60) });

            return httpResponse;
        }

        public HttpResponse Favicon(HttpRequest httpRequest)
        {
            byte[] favIconAsByte = File.ReadAllBytes("wwwroot\\favicon.ico");

            HttpResponse httpResponse = new HttpResponse("image/vnd.microsoft.icon", favIconAsByte);

            return httpResponse;
        }
    }
}
