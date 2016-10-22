using System.CodeDom.Compiler;

namespace Exploration
{
    class Program
    {
        static void Main()
        {
            foreach (var ci in CodeDomProvider.GetAllCompilerInfo())
            {
                foreach (var language in ci.GetLanguages())
                    System.Console.Write("{0}, ", language);

                System.Console.WriteLine();
            }

            System.Console.ReadKey();
        }
    }
}
















