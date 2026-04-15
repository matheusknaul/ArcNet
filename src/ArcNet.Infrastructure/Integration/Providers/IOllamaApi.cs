using ArcNet.Application.Dtos;
using Refit;

namespace ArcNet.Infrastructure.Integration.Providers;

public interface IOllamaApi
{
    [Post("/api/generate")]
    Task<ApiResponse<OllamaResponseDto>> ChatAsync(OllamaRequestDto dto);

    [Get("/api/tags")]
    Task GetModels();
}