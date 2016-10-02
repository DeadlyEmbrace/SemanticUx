using System;
using Microsoft.Owin.Hosting;

namespace AdminConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string url = "http://localhost:8000";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running on {0}", url);
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
}
