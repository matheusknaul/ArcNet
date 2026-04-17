using System.Text.Json;
using System.Text.Json.Nodes;
using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;
using ArcNet.Core.Enums;

namespace ArcNet.Infrastructure.Providers;

public class CheckpointManager : ICheckpointManager
{
    private readonly IFileAnalyzer _fileAnalyzer;

    private const string SNAPSHOT_PATH = "../../ProjectSnaphots/snapshots.json";
    private int _index { get; set; }
    private ProjectSnapshot _projectSnapshot { get; set;}

    public CheckpointManager(IFileAnalyzer fileAnalyzer)
    {
        _fileAnalyzer = fileAnalyzer;
    }

    public async Task AddAsync(string fullPath, SnapshotAction action)
    {
        if(_projectSnapshot.InputIndex != _index)
            _projectSnapshot = new ProjectSnapshot(_index);
        
        var content = await File.ReadAllTextAsync(fullPath);

        _projectSnapshot.FileSnapshots.Add(new FileSnapshot());

        // TODO
    }

    public void SetIndex()
    {
        _index++;
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