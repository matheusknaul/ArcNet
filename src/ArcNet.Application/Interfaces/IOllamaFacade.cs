using ArcNet.Application.Dtos;
using ArcNet.Core.Entities;

namespace ArcNet.Application.Interfaces;

public interface IOllamaFacade
{
    Task<OllamaResponseDto> ChatAsync(OllamaRequestDto dto);
    Task<Provider> GetInfoAsync();
}