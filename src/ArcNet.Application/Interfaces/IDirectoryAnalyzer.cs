using ArcNet.Core.Entities;

namespace ArcNet.Application.Interfaces;

public interface IDirectoryAnalyzer
{
    FileNode GetFile(string fileName);
    DirectoryNode Analyze();
}