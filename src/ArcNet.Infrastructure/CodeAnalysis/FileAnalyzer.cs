using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ArcNet.Infrastructure.CodeAnalysis;

public class FileAnalyzer : IFileAnalyzer
{
    private IDirectoryAnalyzer _directoryAnalyzer;

    public FileAnalyzer(IDirectoryAnalyzer directotryAnalyzer)
    {
        _directoryAnalyzer = directotryAnalyzer;
    }

    public async Task<string> Analyze(string fullPath)
    {
        var fileNode = _directoryAnalyzer.GetFileNode(fullPath);

        var code = await File.ReadAllTextAsync(fileNode.FullPath);

        var tree = CSharpSyntaxTree.ParseText(code);
        var root = await tree.GetRootAsync();
        
        var classes = root.DescendantNodes()
            .OfType<ClassDeclarationSyntax>();

        var fileSummary = new FileSummary();
        
        foreach (var cls in classes)
        {   
            fileSummary.Name = cls.Identifier.Text;

            fileSummary.Methods = cls.Members
                .OfType<MethodDeclarationSyntax>()
                .Select(m => m.Identifier.Text)
                .ToList();

            var constructor = cls.Members
                .OfType<ConstructorDeclarationSyntax>()
                .FirstOrDefault();
            
            fileSummary.Deps = constructor?.ParameterList.Parameters
                .Select(p => p.Type.ToString())
                .ToList();
        }

        return fileSummary.ToString();
    }

}