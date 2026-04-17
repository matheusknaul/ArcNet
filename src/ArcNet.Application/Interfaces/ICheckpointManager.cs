using ArcNet.Core.Enums;

namespace ArcNet.Application.Interfaces;

public interface ICheckpointManager
{
    void SetIndex();
    Task AddAsync(string fullPath, SnapshotAction action);
}