using ArcNet.Core.Entities;

namespace ArcNet.Application.Interfaces;

public interface IDirectoryAnalyzer
{
    FileNode GetFileNode(string fileName);
    DirectoryNode GetDirectoryNode();
    Task<string> Analyze();
}