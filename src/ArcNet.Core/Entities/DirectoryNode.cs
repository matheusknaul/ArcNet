namespace ArcNet.Core.Entities;

public class DirectoryNode
{
    public string Name { get; private set; }
    public List<FileNode> Files { get; private set; } = new();
    public List<DirectoryNode> Directories { get; private set; } = new();
    public string FullPath { get; private set; }
    private static readonly HashSet<string> IgnoredDirectories = new()
    {
        "bin",
        "obj",
        ".git",
        "node_modules"
    };

    //Implementar Lazy Load depois
    //public Directory(DirectoryInfo info, int depth = 0, int maxDepth = 10)
    public DirectoryNode(DirectoryInfo info)
    {
        Name = info.Name;
        FullPath = info.FullName;
        MapAllFiles(info);
    }

    private void MapAllFiles(DirectoryInfo info)
    {
        var files = info.GetFiles();

        foreach (var file in files)
        {
            AddFile(new FileNode(file.Name, file.Extension, file.FullName));
        }

        var directories = info.GetDirectories();

        foreach (var _directory in directories)
        {
            if (IgnoredDirectories.Contains(_directory.Name))
                continue;

            var directory = new DirectoryNode(_directory);
            AddDirectory(directory);
        }
    }

    public void AddFile(FileNode file)
    {
        Files.Add(file);
    }

    public void AddDirectory(DirectoryNode directory)
    {
        Directories.Add(directory);
    }
}

public class FileNode
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public string FullPath { get; set; }

    public FileNode(string name, string extension, string fullPath)
    {
        Name = name;
        Extension = extension;
        FullPath = fullPath;
    }
}