using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;

namespace ArcNet.Infrastructure.Providers;

public class PromptProvider : IPromptProvider
{
    public string GetAnalyzerPrompt()
    {
        throw new NotImplementedException();
    }

    public string GetPlannerPrompt(string input)
    {
        throw new NotImplementedException();
    }
}