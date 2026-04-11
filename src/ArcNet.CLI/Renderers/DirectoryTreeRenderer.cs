using ArcNet.CLI.Renderers.Abstractions;
using ArcNet.Core.Entities;
using Spectre.Console;

namespace ArcNet.CLI.Renderers;

public class DirectoryTreeRenderer : IRenderer<DirectoryNode>
{
    public void Render(DirectoryNode node)
    {
        var tree = new Tree(node.Name);

        var root = tree.AddNode(node.Name);

        RenderNode(root, node);

        AnsiConsole.Write(tree);
    }

    private void RenderNode(TreeNode parent, DirectoryNode node)
    {
        foreach (var file in node.Files)
        {
            parent.AddNode($"📄 {file.Name}{file.Extension}");
        }

        foreach (var dir in node.Directories)
        {
            var child = parent.AddNode($"📁 {dir.Name}");
            RenderNode(child, dir);
        }
    }
}