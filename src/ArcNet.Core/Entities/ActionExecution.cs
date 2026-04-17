namespace ArcNet.Core.Entities;

public class ActionExecution
{
    public string Type { get; set; }
    public ActionInstructions Instructions { get; set; }
    public string? Result { get; set; }
    public bool Done { get; set; } = false;
}

public class ActionInstructions
{
    public string PathToExecute { get; set; }
    public string TargetName { get; set; }
    public string? ContentCreator { get; set; }
}

public class Planner
{
    public string UserInput { get; set; }
    public List<ActionExecution> ActionsToExecute { get; set; }
    public bool Done { get; set; } = false;
}