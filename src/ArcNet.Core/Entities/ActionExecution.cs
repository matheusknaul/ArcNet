namespace ArcNet.Core.Entities;

public class ActionExecution
{
    public string Type { get; set; }
    public string PathToExecute { get; set;}
    public string Target { get; set; }
}

public class ActionResult
{
    public string Type { get; set; }
    public string Return { get; set; }
}