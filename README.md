**This repo has two projects, one based on .NET 7 and another based on .NET 8 to demonstrate differences in the Symbol resolutions.**
More details in [this issue](https://github.com/dotnet/roslyn/issues/74148).

## Running the .NET 7 project
1. `dotnet build roslyn-dotnet-7/roslyn-dotnet-7.csproj`
2. `dotnet ./roslyn-dotnet-7/bin/Debug/net7.0/roslyn-dotnet-7.dll`

You will see the output for [this](https://github.com/anto-deepsource/roslyn-symbolinfo-repro/blob/main/roslyn-dotnet-7/ExampleWalker.cs#L17) console line coming as:
`Symbol is: System`, which is accurate.

## Running the .NET 8 project
1. `dotnet build roslyn-dotnet-8/roslyn-dotnet-8.csproj`
2. `dotnet ./roslyn-dotnet-8/bin/Debug/net8.0/roslyn-dotnet-8.dll`

You will see the output for [this](https://github.com/anto-deepsource/roslyn-symbolinfo-repro/blob/main/roslyn-dotnet-8/ExampleWalker.cs#L11) console line coming as:
`Symbol is: `, which is inaccurate since Symbol was resolved to `null` here.
