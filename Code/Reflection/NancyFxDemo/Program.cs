using Nancy.Hosting.Self;
using System;

namespace NancyFxDemo
{
    class Program
    {
        static void Main()
        {
            using (var host = new NancyHost(new Uri("http://localhost:1234")))
            {
                host.Start();
                Console.WriteLine("Running on http://localhost:1234");
                Console.ReadLine();
            }
        }
    }
}
