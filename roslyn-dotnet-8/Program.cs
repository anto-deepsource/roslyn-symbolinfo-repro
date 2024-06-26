﻿using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis;

namespace RoslynDotnet8;

internal class Program
{
  public static async Task Main(string[] args)
  {
    MSBuildLocator.RegisterDefaults();
    using var workspace = MSBuildWorkspace.Create();
    var project = await workspace.OpenProjectAsync("test-project/test-project.csproj");
    var compilation = await project.GetCompilationAsync();

    var metadataReference = MetadataReference.CreateFromFile(typeof(Thread).Assembly.Location);
    compilation = compilation?.AddReferences(metadataReference);

    foreach (var doc in project.Documents)
    {
      var root = await doc.GetSyntaxRootAsync();
      var tree = await doc.GetSyntaxTreeAsync();
      var semanticModel = tree != null ? compilation?.GetSemanticModel(tree) : null;

      if (semanticModel != null)
      {
        var walker = new ExampleWalker(semanticModel);
        walker.Visit(root);
      }
    }
  }
}
