using Refit;

namespace ArcNet.Infrastructure.Integration.Providers;

public interface IQwenApi
{
    [Post("")]
    Task ChatAsync();

    [Post("")]
    Task GetModels();
}