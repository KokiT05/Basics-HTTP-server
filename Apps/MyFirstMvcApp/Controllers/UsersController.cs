using MyServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController
    {
        public HttpResponse Login(HttpRequest httpRequest)
        {
            string responseHtml = "<h1>Login Page</h1>";
            byte[] responseHtmlBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse httpResponse = new HttpResponse("text/html", responseHtmlBytes);
            httpResponse.Headers.Add(new Header("Server", "MyFirstServer"));
            httpResponse.Cookies.Add(new ResponseCookie("sid", "TestCookieSid1") { HttpOnly = true, MaxAge = (3 * 24 * 60 * 60) });

            return httpResponse;
        }

        public HttpResponse Register(HttpRequest httpRequest)
        {
            string responseHtml = "<h1>Register Page</h1>";
            byte[] responseHtmlBytes = Encoding.UTF8.GetBytes(responseHtml);

            HttpResponse httpResponse = new HttpResponse("text/html", responseHtmlBytes);
            httpResponse.Headers.Add(new Header("Server", "MyFirstServer"));
            httpResponse.Cookies.Add(new ResponseCookie("sid", "TestCookieSid1") { HttpOnly = true, MaxAge = (3 * 24 * 60 * 60) });

            return httpResponse;
        }
    }
}
