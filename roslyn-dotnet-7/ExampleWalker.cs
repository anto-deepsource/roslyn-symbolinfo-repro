using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynDotnet7;

public class ExampleWalker : CSharpSyntaxWalker
{
  private readonly SemanticModel semanticModel;

  public ExampleWalker(SemanticModel semanticModel)
  {
    this.semanticModel = semanticModel;
  }
  public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
  {
    Console.WriteLine($"Symbol is: {semanticModel.GetSymbolInfo(node.Type).Symbol?.ContainingNamespace.Name}");
  }
}
