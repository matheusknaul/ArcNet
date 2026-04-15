using System.Text.Json.Serialization;

namespace ArcNet.Application.Dtos;

public class OllamaResponseDto
{
    public string Model { get; set; }
    public string Response { get; set; }
    public bool Done { get; set; }
    [JsonPropertyName("done_reason")]
    public string DoneReason { get; set; }
    [JsonPropertyName("total_duration")]
    public long TotalDuration { get; set; }
    [JsonPropertyName("load_duration")]
    public long LoadDuration { get; set; }
    [JsonPropertyName("prompt_eval_duration")]
    public long PromptEvalDuration { get; set; }
    [JsonPropertyName("eval_duration")]
    public long EvalDuration { get; set; }
    [JsonPropertyName("prompt_eval_count")]
    public int PromptEvalCount { get; set; }
    [JsonPropertyName("eval_count")]
    public int EvalCount { get; set; }
    public bool HasError { get; set; } = false;
    public string? MessageError { get; set; }
}