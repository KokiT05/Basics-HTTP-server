using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServer.MvcFramework.ViewEngines
{
    public class ErrorView : IView
    {
        private readonly IEnumerable<string> _errors;
        private readonly string _csharpCode;

        public ErrorView(IEnumerable<string> errors, string csharpCode)
        {
            this._errors = errors;
            this._csharpCode = csharpCode;
        }

        public string GetHtml(object viewModel)
        {
            StringBuilder html = new StringBuilder();
            html.Append($@"<h1>View compile {this._errors.Count()} errors:</h1>");
            html.Append("<ul>");
            foreach (string error in this._errors)
            {
                html.Append($"<li>{error}</li>");
            }
            html.Append("</ul>");
            html.Append($"<p>{this._csharpCode}</p>");
            return html.ToString();
        }
    }
}
