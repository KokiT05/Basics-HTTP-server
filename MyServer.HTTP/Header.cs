using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServer.HTTP
{
    public class Header
    {
        public Header(string headerName, string headerValue)
        {
            this.HeaderName = headerName;
            this.HeaderValue = headerValue;
        }

        public Header(string headerLine)
        {
            string[] headerParts = headerLine.Split(new string[] { ": " }, 2, StringSplitOptions.None);
            this.HeaderName = headerParts[0];
            this.HeaderValue = headerParts[1];
            // Canche
        }

        public string HeaderName { get; set; }

        public string HeaderValue { get; set; }

        public override string ToString()
        {
            return $"{this.HeaderName}: {this.HeaderValue}";
        }
    }
}
