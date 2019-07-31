using SIS.MvcFramework;

namespace MishMashWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
