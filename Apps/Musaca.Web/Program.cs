using SIS.MvcFramework;

namespace Musaca.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
