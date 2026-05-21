using ArcNet.Application.Dtos;
using ArcNet.Core.Entities;

namespace ArcNet.Application.Interfaces;

public interface ILlmProvider
{
    Task<LlmResponseDto> ChatAsync(LlmRequestDto dto);
    Task<Provider> GetInfoAsync();
}