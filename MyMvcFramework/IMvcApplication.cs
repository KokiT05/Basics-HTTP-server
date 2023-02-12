using MyServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServer.MvcFramework
{
    public interface IMvcApplication
    {
        void ConfigureService();

        void Configure(List<Route> routeTable);
    }
}
