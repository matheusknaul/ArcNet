using System.Text.Json;
using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;
using ArcNet.Core.Enums;

namespace ArcNet.Infrastructure.Providers;

public class CheckpointManager : ICheckpointManager
{
    private readonly IDirectoryAnalyzer _directoryAnalyzer;

    private const string SNAPSHOT_PATH = "../../ProjectSnaphots/snapshots.json";
    private int _index { get; set; }
    private ProjectSnapshot _projectSnapshot { get; set;}

    public CheckpointManager(IDirectoryAnalyzer directoryAnalyzer)
    {
        _directoryAnalyzer = directoryAnalyzer;
    }

    public async Task AddAsync(string fullPath, SnapshotAction action)
    {
        if(_projectSnapshot.InputIndex != _index)
            NewProject(fullPath, _index);
        
        var content = await File.ReadAllTextAsync(fullPath);

        _projectSnapshot.LastEditAt = DateTime.UtcNow;

        var fileName = _directoryAnalyzer.GetFileName(fullPath);

        _projectSnapshot.FileSnapshots.Add(new FileSnapshot{Path = fullPath,
             Action = action, Content = content, Name = fileName});
    }

    public void SetIndex()
    {
        _index++;
    }

    private async Task NewProject(string fullPath, int index)
    {
        _projectSnapshot = new ProjectSnapshot(index);
        _projectSnapshot.ProjectName = _directoryAnalyzer.GetProjectName();
        _projectSnapshot.LastEditAt = DateTime.UtcNow;
    }

    public async Task RestoreProject(int index)
    {
        if (!File.Exists(SNAPSHOT_PATH))
            return;

        var projectsJson = await File.ReadAllTextAsync(SNAPSHOT_PATH);

        var root = JsonSerializer.Deserialize<SnapshotRoot>(projectsJson)
            .ProjectSnapshots.FirstOrDefault(i => i.InputIndex == index);

        if(root == null)
            return;

        foreach(var snapshot in root.FileSnapshots)
        {
            if(snapshot.Action == SnapshotAction.Delete)
                {
                if (File.Exists(snapshot.Path))
                    File.Delete(snapshot.Path);

                continue;
            }
                 
            await File.WriteAllTextAsync(snapshot.Path, snapshot.Content);
        }
    }

}   