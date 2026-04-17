namespace ArcNet.Core.Entities;

public class HistoryConversation
{
    public List<Conversation> Conversations { get; set; } = new();
    public DateTime LastConversation { get; set; }
}

public class Conversation
{
    public string UserInput { get; set; }
    public int Index { get; set; }
    public List<Step> Steps { get; set; }
    public int TotalTokens { get; set; }
    public long TotalElapsedTime { get;set; }
}

public class Step
{
    public int StepIndex { get; set; }
    public string Model { get; set; }
    public Prompt Prompt { get; set; }
    public int InTokens { get;set; }
    public int OutTokens { get;set; }
    public long ElapsedTime { get; set; }
    public DateTime SentAt { get; set; }
}