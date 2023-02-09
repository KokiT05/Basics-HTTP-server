using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServer.HTTP
{
    public class Cookie
    {
        public Cookie(string cookieName, string cookieValue)
        {
            this.CookieName = cookieName;
            this.CookieValue = cookieValue;
        }

        public Cookie(string cookieAsString)
        {
            string[] splitCookiteData = cookieAsString.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
            this.CookieName= splitCookiteData[0];
            this.CookieValue= splitCookiteData[1];
        }

        public string CookieName { get; set; }

        public string CookieValue { get; set; }

        public override string ToString()
        {
            return $"{this.CookieName}={this.CookieValue}";
        }
    }
}
