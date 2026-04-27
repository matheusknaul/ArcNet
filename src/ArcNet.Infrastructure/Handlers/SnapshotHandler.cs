using System.Text.Json;
using ArcNet.Core.Entities;

namespace ArcNet.Infrastructure.Handlers;

public class SnapshotHandler
{
    public SnapshotRoot? Root { get; set; }
    public string ProjectName { get; set; }
    private const string SNAPSHOTS_PATH = "ProjectSnapshot.json";

    public SnapshotHandler(string projectName)
    {
        ProjectName = projectName;
    }

    private string GetPath()
    {
        var basePath = AppContext.BaseDirectory;
        var path = Path.Combine(basePath,"ProjectSnapshots",SNAPSHOTS_PATH);

        return path;
    }

    public void LoadSnapshots()
    {
        var json = File.ReadAllText(GetPath());

        Root = JsonSerializer.Deserialize<SnapshotRoot>(json);

        Root.ProjectSnapshots = Root.ProjectSnapshots
            .Where(p => p.ProjectName == ProjectName)
            .ToList();
    }

    public void Revert(int revertToIndex)
    {
        LoadSnapshots();

        Root.ProjectSnapshots = Root.ProjectSnapshots
            .Where(p => p.InputIndex <= revertToIndex)
            .ToList();
        
        var json = JsonSerializer.Serialize(Root);

        File.WriteAllText(GetPath(), json);

        LoadSnapshots();
    }
}