using ArcNet.Application.Interfaces;

namespace ArcNet.Application.UseCases;

public class AnalyzeDirectory
{
    private readonly IDirectoryAnalyzer _analyzer;

    public AnalyzeDirectory(IDirectoryAnalyzer analyzer)
    {
        _analyzer = analyzer;
    } 

}