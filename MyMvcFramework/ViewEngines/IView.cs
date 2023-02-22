using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServer.MvcFramework.ViewEngines
{
    public interface IView
    {
        string ExecuteTemplate(object viewModel);
    }
}
