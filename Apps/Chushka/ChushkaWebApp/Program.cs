using SIS.MvcFramework;
using System;

namespace ChushkaWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
