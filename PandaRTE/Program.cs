using System.Globalization;
using System.Threading;
using SIS.MvcFramework;

namespace PandaRTE.Web
{
    public static class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            WebHost.Start(new Startup());
        }
    }
}
