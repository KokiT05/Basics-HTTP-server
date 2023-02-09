namespace MyServer.HTTP
{
    using Interfaces;
    using System.Text;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse(string contentType, byte[] body, HttpStatusCode httpStatusCode = HttpStatusCode.OK, string version = "HTTP/1.1")
        {
            Cookies = new List<Cookie>();

            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            this.StatusCode = httpStatusCode;
            this.Body = body;
            this.Version = version;

            this.Headers = new List<Header>
            {
                {new Header("Content-Type", contentType) },
                {new Header("Content-Length", Body.Length.ToString()) }
            };
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{Version} {(int)StatusCode} {StatusCode.ToString()}" + HttpConstants.NewLine);
            foreach (Header header in Headers)
            {
                stringBuilder.Append(header.ToString() + HttpConstants.NewLine);
            }

            foreach (Cookie cookie in this.Cookies)
            {
                stringBuilder.Append("Set-Cookie:" + cookie.ToString() + HttpConstants.NewLine);
            }
            stringBuilder.Append(HttpConstants.NewLine);
            return stringBuilder.ToString();
        }

        public string Version { get; private set; }

        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public byte[] Body { get; set; }
    }
}
