using ArcNet.Application.Dtos;

namespace ArcNet.Application.Interfaces;

public interface IOllamaFacade
{
    Task<OllamaResponseDto> ChatAsync(OllamaRequestDto dto);
}