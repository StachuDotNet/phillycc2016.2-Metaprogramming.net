using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_PregeneratedTemplates
{
    class Program
    {
        static void Main()
        {
            var tmpl = new RuntimeTextTemplate1();
            var result = tmpl.TransformText();

            Console.Write(result);
            Console.ReadKey();
        }
    }
}
