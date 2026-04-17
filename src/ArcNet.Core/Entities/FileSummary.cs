using System.Text;

namespace ArcNet.Core.Entities;

public class FileSummary
{
    public string Name { get; set; }
    public List<string> Methods { get; set; } = new();
    public List<string> Deps { get; set; } = new();

    public string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Class: {Name}");
        if(Methods.Count > 0)
        {
            sb.AppendLine("Methods:");
            foreach(var method in Methods)
                sb.AppendLine($"-{method}");
        }
        if(Deps.Count > 0)
        {
            sb.AppendLine("Deps:");
            foreach(var dep in Deps)
                sb.AppendLine($"-{dep}");
        }

        return sb.ToString();
    }
}

public class MethodSummary
{
    public string Name { get; set; }
    public List<string> Calls { get; set; }
    public List<string> Dependencies { get; set; }
}