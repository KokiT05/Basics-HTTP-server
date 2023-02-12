using MyServer.MvcFramework;
using MyServer.HTTP;

namespace MyFirstMvcApp.Controllers
{
    public class CarsController : Controller
    {
        public HttpResponse Add(HttpRequest httpRequest)
        {
            return View();
        }

        public HttpResponse AddUser(HttpRequest httpRequest)
        {
            return this.Redirect("/");
        }

        public HttpResponse All (HttpRequest httpRequest)
        {
            return this.View();
        }
    }
}
