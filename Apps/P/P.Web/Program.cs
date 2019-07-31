using SIS.MvcFramework;
using System.Globalization;
using System.Threading;

namespace P.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            WebHost.Start(new Startup());
        }
    }
}
