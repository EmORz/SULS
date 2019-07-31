using SIS.MvcFramework;

namespace Musaca.AppRT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
