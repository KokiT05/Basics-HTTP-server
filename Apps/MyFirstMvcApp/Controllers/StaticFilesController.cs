using MyServer.HTTP;
using MyServer.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest httpRequest)
        {
            return this.File("wwwroot/favicon.ico", "image/vnd.microsoft.icon");
        }

        public HttpResponse CustomCss(HttpRequest httpRequest)
        {
            return this.File("wwwroot/css/custom.css", "text/css");
        }

        public HttpResponse BoostrapCss(HttpRequest httpRequest)
        {
            return this.File("wwwroot/css/bootstrap.min.css", "text/css");
        }

        public HttpResponse BoostrapJs(HttpRequest httpRequest)
        {
            return this.File("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
        }

        public HttpResponse CustomJs(HttpRequest httpRequest)
        {
            return this.File("wwwroot/js/custom.js", "text/javascript");
        }
        //        routeTable.Add(new Route("/css/custom.css", new StaticFilesController().CustomCss));
        //routeTable.Add(new Route("/css/bootstrap.min.css", new StaticFilesController().BoostrapCss));
        //routeTable.Add(new Route("/js/bootstrap.bundle.min.js", new StaticFilesController().));
        //routeTable.Add(new Route("/js/custom.js", new StaticFilesController().CustomJs));
    }
}
