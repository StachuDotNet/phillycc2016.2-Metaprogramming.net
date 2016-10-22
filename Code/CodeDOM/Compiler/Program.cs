using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.IO;

namespace Compiler
{
    class Program
    {
        static void Main()
        {
            var source = File.ReadAllText(@"G:/output.cs");

            var references = new[] { "System.Dll", "System.Core.Dll" };

            var results = CompileCsharpSource(new[] { source }, "App.exe", references);

            if (results.Errors.Count == 0)
                Console.WriteLine("No Errors");
            else
                foreach (CompilerError error in results.Errors)
                    Console.WriteLine(error.ErrorText);

            Console.ReadLine();
        }

        static CompilerResults CompileCsharpSource(string[] sources, string output, params string[] references)
        {
            var parameters = new CompilerParameters(references, output)
            {
                GenerateExecutable = true
            };

            using (var provider = new CSharpCodeProvider())
                return provider.CompileAssemblyFromSource(parameters, sources);
        }
    }
}
