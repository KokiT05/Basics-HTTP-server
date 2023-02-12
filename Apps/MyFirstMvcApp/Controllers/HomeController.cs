using MyServer.HTTP;
using MyServer.MvcFramework;
using System.Text;

namespace MyFirstMvcApp.Controllers     
{
    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest httpRequest)
        {
            //string responseHtml = File.ReadAllText("Views/Home/Index.cshtml");
            //byte[] responseHtmlBytes = Encoding.UTF8.GetBytes(responseHtml);

            //HttpResponse httpResponse = new HttpResponse("text/html", responseHtmlBytes);
            //httpResponse.Headers.Add(new Header("Server", "MyFirstServer"));
            //httpResponse.Cookies.Add(new ResponseCookie("sid", "TestCookieSid1") { HttpOnly = true, MaxAge = (3 * 24 * 60 * 60) });

            //return httpResponse;

            return this.View();
        }
    }
}
