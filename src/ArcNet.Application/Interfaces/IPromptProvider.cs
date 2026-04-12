using ArcNet.Core.Entities;

namespace ArcNet.Application.Interfaces;

public interface IPromptProvider
{
    Prompt GetPlannerPrompt();
    Prompt GetAnalyzerPrompt();
}