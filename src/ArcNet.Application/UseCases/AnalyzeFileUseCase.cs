using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;

namespace ArcNet.Application.UseCases;

public class AnalyzeFileUseCase
{
    private readonly IDirectoryAnalyzer _directoryAnalyzer;
    private readonly IFileAnalyzer _fileAnalyzer;

    public AnalyzeFileUseCase(IFileAnalyzer fileAnalyzer,
        IDirectoryAnalyzer directoryAnalyzer)
    {
        _directoryAnalyzer = directoryAnalyzer;
        _fileAnalyzer = fileAnalyzer;
    } 

    public FileSummary? AnalyzeFileAsync(string fileName)
    {
        var fileInfo = _directoryAnalyzer.GetFile(fileName);

        return _fileAnalyzer.Analyze(fileInfo.FullPath); 
    }

}