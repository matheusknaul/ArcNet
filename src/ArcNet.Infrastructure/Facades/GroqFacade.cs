using ArcNet.Application.Interfaces;
using ArcNet.Infrastructure.Integration.Providers;

namespace ArcNet.Infrastructure.Facades;

public class GroqFacade : IGroqFacade
{
    private readonly IGroqApi _api;

    public GroqFacade(IGroqApi api)
    {
        _api = api;
    }


}