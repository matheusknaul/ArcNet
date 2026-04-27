using System.Reflection;
using ArcNet.Infrastructure.Handlers;

namespace Tests.Core;

public sealed class SnapshotHandlerTest
{
    private const string PROJECT_NAME = "Project Test";
    public SnapshotHandler Instance {get; private set;} = new SnapshotHandler(PROJECT_NAME);

    [Fact]
    public void Revert_ShouldReturnCorrectPropertiesProjetc()
    {
        Instance.Revert(1);

        Assert.NotNull(Instance.Root);

        Assert.Equal(PROJECT_NAME, Instance.Root.ProjectSnapshots.FirstOrDefault().ProjectName);

        Assert.Equal(1, Instance.Root.ProjectSnapshots.FirstOrDefault().InputIndex);

        Assert.Equal(1, Instance.Root.ProjectSnapshots.Count);
    }

    [Fact]
    public void LoadSnapshots_ShouldReturnCorrectProjectName()
    {
        Instance.LoadSnapshots();

        Assert.NotNull(Instance.Root);

        Assert.Equal(PROJECT_NAME, Instance.Root.ProjectSnapshots.FirstOrDefault().ProjectName);
    }

    [Fact]
    public void LoadSnapshots_ProjectTest_ShouldReturnCorrectSnaphotsCount()
    {
        Instance.LoadSnapshots();

        Assert.NotNull(Instance.Root);

        Assert.Equal(2, Instance.Root.ProjectSnapshots.Count);
    }
}