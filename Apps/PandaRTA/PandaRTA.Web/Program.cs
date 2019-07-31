using System;
using System.Globalization;
using System.Threading;
using SIS.MvcFramework;

namespace PandaRTA.Web
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
