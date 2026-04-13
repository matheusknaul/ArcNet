using ArcNet.Core.Entities;

namespace ArcNet.Application.Interfaces;

public interface IPromptProvider
{
    string GetPlannerPrompt();
    string GetAnalyzerPrompt();
}