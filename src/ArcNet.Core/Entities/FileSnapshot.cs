using ArcNet.Core.Enums;

namespace ArcNet.Core.Entities;

public class SnapshotRoot
{
    public List<ProjectSnapshot> ProjectSnapshots { get; set; }
}

public class ProjectSnapshot
{
    public string ProjectName { get; set; }
    public int InputIndex { get; set; }
    public List<FileSnapshot> FileSnapshots { get; set; }
    public DateTime LastEditAt { get; set; }

    public ProjectSnapshot(){}

    public ProjectSnapshot(int index)
    {
        InputIndex = index;
    }
}

public class FileSnapshot
{
    public string Path { get;set; }
    public string Name { get;set; }
    public string Content { get; set; }
    public SnapshotAction Action { get; set; }
}