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

        public HttpResponse All (HttpRequest httpRequest)
        {
            return View();
        }
    }
}
