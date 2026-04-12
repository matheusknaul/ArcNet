using Refit;

namespace ArcNet.Infrastructure.Integration.Providers;

public interface IGroqApi
{
    [Post("")]
    Task ChatAsync();

    [Post("")]
    Task GetModels();
}