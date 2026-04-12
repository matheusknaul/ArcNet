using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;

namespace ArcNet.Infrastructure.Providers;

public class PromptProvider : IPromptProvider
{
    public Prompt GetAnalyzerPrompt()
    {
        throw new NotImplementedException();
    }

    public Prompt GetPlannerPrompt()
    {
        throw new NotImplementedException();
    }
}