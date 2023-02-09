using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServer.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string cookieName, string cookieValue) : base(cookieName, cookieValue)
        {
            Path = "/";
        }
        //Nice

        public int MaxAge { get; set; }

        public bool HttpOnly { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{this.CookieName}={this.CookieValue}; Path={this.Path};");

            if (MaxAge != 0)
            {
                stringBuilder.Append($" Max-Age={this.MaxAge};");
            }

            if (this.HttpOnly)
            {
                stringBuilder.Append(" HttpOnly;");
            }

            return stringBuilder.ToString();
        }
    }
}
