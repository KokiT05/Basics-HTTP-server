using MyServer.HTTP;
using MyServer.MvcFramework;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest httpRequest)
        {
            return this.View();
        }

        public HttpResponse Register(HttpRequest httpRequest)
        {
            return this.View();
        }
    }
}
