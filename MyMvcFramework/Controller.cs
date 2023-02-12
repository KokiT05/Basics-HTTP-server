using MyServer.HTTP;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyServer.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName] string methodName = null)
        {
            string view = System.IO.File.ReadAllText("Views/" +
                this.GetType().Name.Replace("Controller", string.Empty) + "/" + methodName + ".cshtml");

            string _layoutHtml = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");

            string finalHtml = _layoutHtml.Replace("@RenderBody()", view);

            byte[] responseHtmlBytes = Encoding.UTF8.GetBytes(finalHtml);

            HttpResponse httpResponse = new HttpResponse("text/html", responseHtmlBytes);

            return httpResponse; 
        }

        public HttpResponse File(string filePath, string contentType)
        {
            byte[] responseHtmlBytes = System.IO.File.ReadAllBytes(filePath);

            HttpResponse httpResponse = new HttpResponse(contentType, responseHtmlBytes);

            return httpResponse;
        }

        public HttpResponse Redirect(string url)
        {
            HttpResponse httpResponse = new HttpResponse("text/html", new byte[0], HttpStatusCode.Found);
            httpResponse.Headers.Add(new Header("Location", url));
            return httpResponse;
        }
    }
}
