using System.Text.Json;
using ArcNet.Application.Dtos;
using ArcNet.Application.Interfaces;
using ArcNet.Infrastructure.Integration.Providers;
using Refit;

namespace ArcNet.Infrastructure.Facades;

public class OllamaFacade : IOllamaFacade
{
    private readonly IOllamaApi _api;

    public OllamaFacade(IOllamaApi api)
    {
        _api = api;
    }

    public async Task<OllamaResponseDto> ChatAsync(OllamaRequestDto dto)
    {
        var response = new OllamaResponseDto();

        try
        {
            var apiResponse = await _api.ChatAsync(dto);

            if (apiResponse.IsSuccessStatusCode)
            {
                response.HasError = true;
                response.MessageError = apiResponse.Error.Content;

                return response;
            }

            response = apiResponse.Content;

            return response;
        }
        catch (Exception ex)
        {
            response.HasError = true;
            response.MessageError = ex.Message;

            return response;
        }
    }
}