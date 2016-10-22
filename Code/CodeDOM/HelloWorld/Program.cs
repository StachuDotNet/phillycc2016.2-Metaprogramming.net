using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main()
        {
            var prgNamespace = new CodeNamespace("MetaWorld");

            var systemImport = new CodeNamespaceImport("System");
            prgNamespace.Imports.Add(systemImport);

            var programClass = new CodeTypeDeclaration("Program");
            prgNamespace.Types.Add(programClass);

            var methodMain = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Static,
                Name = "Main"
            };
            methodMain.Statements.Add(new CodeMethodInvokeExpression(
                    new CodeSnippetExpression("Console"), 
                    "WriteLine", 
                    new CodePrimitiveExpression("Hello, world")
                )
            );

            programClass.Members.Add(methodMain);



            var compilerOptions = new CodeGeneratorOptions
            {
                IndentString = "\t",
                BracingStyle = "C",
                BlankLinesBetweenMembers = false
            };

            var codeText = new StringBuilder();

            using (var codeWriter = new StringWriter(codeText))
            {
                CodeDomProvider.CreateProvider("c#")
                    .GenerateCodeFromNamespace(prgNamespace, codeWriter, compilerOptions);
            }

            var script = codeText.ToString();

            File.WriteAllText("G:/output.cs", script);
            Console.WriteLine(script);
            Console.ReadKey();
        }
    }
}

























