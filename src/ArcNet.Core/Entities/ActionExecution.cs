namespace ArcNet.Core.Entities;

public class ActionExecution
{
    public string Type { get; set; }
    public string PathToExecute { get; set;}
    public string Target { get; set; }
    public string Result { get; set; }
    public bool Done { get; set; } = false;
}

public class Planner
{
    public string UserInput { get; set; }
    public List<ActionExecution> ActionsToExecute { get; set; }
    public bool Done { get; set; } = false;
}