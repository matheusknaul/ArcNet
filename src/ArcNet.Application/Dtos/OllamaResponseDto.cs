using System.Text.Json.Serialization;

namespace ArcNet.Application.Dtos;

public class OllamaResponseDto
{
    public string? Model { get; set; }
    public string? Response { get; set; }
    public bool Done { get; set; }
    [JsonPropertyName("done_reason")]
    public string? DoneReason { get; set; }
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

public class OllamaGetModelsResponseDto
{
    public List<OllamaModel>? Models { get; set; }
}

public class OllamaModel
{
    public string? Name { get; set; }
    public string? Model { get; set; }
    [JsonPropertyName("modified_at")]
    public DateTime ModifiedAt { get; set; }
    public long Size { get; set; }
    public string? Digest { get; set; }
    public OllamaModelDetail? Details { get; set; }
    [JsonPropertyName("parameter_size")]
    public string? ParameterSize { get; set; }
    [JsonPropertyName("quantization_level")]
    public string? QuantizationLevel { get; set; }
}

public class OllamaModelDetail
{
    public string? Format { get; set; }
    public string? Family { get; set; }
    public List<string>? Families { get; set; }
}
