using ArcNet.Application.Dtos;
using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;
using ArcNet.Core.Interfaces;

namespace ArcNet.Application.Orchestrator;

public class AgentOrchestrator : IAgentOrchestrator
{
    private readonly IActionExecutor _executor;
    private readonly IPromptProvider _promptProvider;
    private readonly IOllamaFacade _ollamaFacade;
    private readonly IUserPreferences _userPreferences;

    public AgentOrchestrator(IActionExecutor executor, IPromptProvider promptProvider,
        IOllamaFacade ollamaFacade, IUserPreferences userPreferences)
    {
        _executor = executor;
        _promptProvider = promptProvider;
        _ollamaFacade = ollamaFacade;
        _userPreferences = userPreferences;
    }

    public async Task Run(string input)
    {
        var plan = new Planner();
        plan.UserInput = input;

        var userPreferences = _userPreferences.GetUserPreferences();

        while (!plan.Done)
        {
            var prompt = _promptProvider.GetPlannerPrompt(input);

            var ollamaRequestDto = new OllamaRequestDto();

            ollamaRequestDto.Model = userPreferences.Model;
            ollamaRequestDto.Prompt = prompt;

            var agentResponse = await _ollamaFacade.ChatAsync(ollamaRequestDto);

            

        }
    }
}
