namespace ArcNet.Application.Dtos;

public class LlmRequestDto
{
    public string Model { get; set; }
    public string Prompt { get; set; }
    //public bool Stream { get; set; }
}