namespace MyServer.HTTP
{
    using Interfaces;
    using System.Text;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            Headers = new List<Header>();
            Cookies= new List<Cookie>();

            var lines = requestString.Split(HttpConstants.NewLine, StringSplitOptions.None);
            var headerLine = lines[0];
            var headerLineParts = headerLine.Split(HttpConstants.SpaceSeparato);
            this.Method = (HttpMethodEnum)Enum.Parse(typeof(HttpMethodEnum), headerLineParts[0], true);
            this.Path = headerLineParts[1];
            this.Version= headerLineParts[2];

            int lineIndex = 1;
            bool isinHeaders = true;
            StringBuilder bodyBuilder = new StringBuilder();
            while (lineIndex < lines.Length)
            {
                var line = lines[lineIndex];
                lineIndex++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    isinHeaders = false;
                    continue;

                }

                if (isinHeaders)
                {
                    this.Headers.Add(new Header(line));
                    //read header
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                    //read body
                }
            }

            if (Headers.Any(x => x.HeaderName.ToLower() == HttpConstants.RequestCookieHeader))
            {
                string cookiesAsSring = this.Headers.
                                        FirstOrDefault
                                        (x => x.HeaderName.ToLower() == HttpConstants.RequestCookieHeader).HeaderValue;
                string[] cookies = cookiesAsSring.Split("; ", StringSplitOptions.RemoveEmptyEntries);

                foreach (string cookie in cookies)
                {
                    this.Cookies.Add(new Cookie(cookie));
                }
            }

            this.Body = bodyBuilder.ToString();

            //GetInformationOfRequestString(requestString);

            //string[] lines = requestString.Split(new string[] { HttpConstants.NewLine }, StringSplitOptions.None);

            //// do tova
            //string headerLine = lines[0];
        }

        public string Path { get; set; }

        public HttpMethodEnum Method { get; set; }

        public string Version { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public string Body { get; set; }

        //private void SplitHeaderLine(string headerLine)
        //{
        //    string[] headerLineParts = headerLine.Split(HttpConstants.SpaceSeparato);

        //    this.Method= headerLineParts[0];
        //    this.Path= headerLineParts[1];
        //    this.Version = headerLineParts[2];
        //}

        //private void GetBodyOfRequest(string lines)
        //{
        //    this.Body = lines;
        //}

        //private void GetInformationOfRequestString(string requestString)
        //{
        //    string[] lines = requestString.Split(new string[] { HttpConstants.NewLine }, StringSplitOptions.None);

        //    string headerLine = lines[0];
        //    SplitHeaderLine(headerLine);

        //    int indexLine = 1;
        //    bool IsBody = false;

        //    while (indexLine < lines.Length)
        //    {
        //        string currentLine = lines[indexLine];

        //        if (currentLine == HttpConstants.NewLine)
        //        {
        //            IsBody = true;
        //            indexLine++;
        //            GetBodyOfRequest(lines[indexLine]);
        //            break;
        //        }

        //        indexLine++;
        //    }
        //}
    }
}
