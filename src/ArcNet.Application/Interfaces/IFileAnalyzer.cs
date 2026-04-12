using ArcNet.Core.Entities;

namespace ArcNet.Application.Interfaces;

public interface IFileAnalyzer
{
    Task<string> Analyze(string fullPath);
}