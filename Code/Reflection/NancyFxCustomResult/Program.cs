using System;
using System.Linq;

namespace NancyFxCustomResult
{
    class Program
    {
        static void Main()
        {
            var type = typeof(BaseModule);

            var routes =
                AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsSubclassOf(type))
                .Select(t => Activator.CreateInstance(t) as BaseModule)
                .Select(i => i.Routes)
                .SelectMany(i => i)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            var inputString = Console.ReadLine();
            var context = new Context();

            while (inputString != "q")
            {
                if (routes.ContainsKey(inputString))
                    Console.WriteLine(routes[inputString](context));
                else
                    Console.WriteLine("No route found");

                inputString = Console.ReadLine().ToLower();
            }
        }
    }
}
