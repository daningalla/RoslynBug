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
        }

        static void OutputTokens(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var id = 0;
            
            foreach (var token in syntaxTree.GetRoot().DescendantTokens())
            {
                Console.WriteLine($"{id++:D2} {token.Kind(),-20} '{token}'");
            }
        }
    }
}