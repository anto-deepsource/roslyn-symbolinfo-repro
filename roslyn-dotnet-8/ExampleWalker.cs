using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynDotnet8;

public class ExampleWalker(SemanticModel semanticModel) : CSharpSyntaxWalker
{
  public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
  {
    Console.WriteLine($"Symbol is: {semanticModel.GetSymbolInfo(node.Type).Symbol?.ContainingNamespace.Name}");
  }
}
