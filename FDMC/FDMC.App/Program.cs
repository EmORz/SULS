
using System;
using SIS.MvcFramework;

namespace FDMC.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
