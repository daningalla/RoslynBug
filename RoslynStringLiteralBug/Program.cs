using System;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynStringLiteralBug
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = string.Join(Environment.NewLine, new[]
            {
                "var list = new List<string>();",
                "list.Add(\"found a bug?\");"
            });
            OutputTokens(code);
            
            code = string.Join(Environment.NewLine, new[]
            {
                "var list = new List<string>();",
                "var bug = \"found a bug?\";",
                "list.Add(bug);"
            });
            OutputTokens(code);
        }

        static void OutputTokens(string code)
        {
            Console.WriteLine($"Output tokens for:");
            Console.WriteLine(code);
            Console.WriteLine();
            
            var syntaxTree = CSharpSyntaxTree.ParseText(code);

            foreach (var token in syntaxTree.GetRoot().DescendantTokens())
            {
                Console.WriteLine($"{token.Kind()}: '{token}'");
            }
        }
    }
}