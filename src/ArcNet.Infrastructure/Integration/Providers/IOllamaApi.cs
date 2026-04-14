using Refit;

namespace ArcNet.Infrastructure.Integration.Providers;

public interface IOllamaApi
{
    [Post("")]
    Task ChatAsync();

    [Post("")]
    Task GetModels();
}