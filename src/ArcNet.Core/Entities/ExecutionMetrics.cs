namespace ArcNet.Core.Entities;

public class ExecutionMetrics
{
    public List<ModelSession> Sessions { get; set; } = new();
    public decimal ElapsedTime { get; set; }
    public long MemoryUsedBytes;
}

public class ModelSession
{
    public int InputTokens { get; private set; }
    public int OutputTokens { get; private set; }
    public decimal ElapsedTime { get; private set; }
    public string Model { get; private set; }

    public ModelSession(int inpTokens, int outToken, decimal et, string model)
    {
        InputTokens = inpTokens;
        OutputTokens = outToken;
        ElapsedTime = et;
        Model = model;
    }
}