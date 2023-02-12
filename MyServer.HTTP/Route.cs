using MyServer.HTTP;

namespace MyServer.HTTP
{
    public class Route
    {
        public Route(string path, HttpMethodEnum httpMethod ,Func<HttpRequest, HttpResponse> action)
        {
            this.Path = path;
            this.HttpMethod = httpMethod;
            this.Action = action;
        }

        public string Path { get; set; }

        public HttpMethodEnum HttpMethod { get; set; }    
        
        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
