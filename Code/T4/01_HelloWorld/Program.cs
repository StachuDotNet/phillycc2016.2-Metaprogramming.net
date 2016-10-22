using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloWorld
{
    class Program
    {
        static void Main()
        {
            Console.Write(File.ReadAllText("HelloWorld.txt"));
            Console.ReadKey();
        }
    }
}
