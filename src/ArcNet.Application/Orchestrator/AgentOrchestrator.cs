using System.Text.Json;
using System.Text.Json.Nodes;
using ArcNet.Application.Dtos;
using ArcNet.Application.Interfaces;
using ArcNet.Core.Entities;
using ArcNet.Core.Enums;
using ArcNet.Core.Interfaces;

namespace ArcNet.Application.Orchestrator;

public class AgentOrchestrator : IAgentOrchestrator
{
    #region Properties

    public OrchestratorStep Step { get; private set; }

    #endregion


    #region Dependencies

    private readonly IActionExecutor _executor;
    private readonly IPromptProvider _promptProvider;
    private readonly IOllamaFacade _ollamaFacade;
    private readonly IUserPreferences _userPreferences;
    private readonly ICheckpointManager _checkpointManager;

    #endregion

    public AgentOrchestrator(IActionExecutor executor, IPromptProvider promptProvider,
        IOllamaFacade ollamaFacade, IUserPreferences userPreferences, ICheckpointManager checkpointManager)
    {
        _executor = executor;
        _promptProvider = promptProvider;
        _ollamaFacade = ollamaFacade;
        _userPreferences = userPreferences;
        _checkpointManager = checkpointManager;
    }

    public async Task Run(string input)
    {
        var plan = new Planner();
        plan.UserInput = input;

        var userPreferences = _userPreferences.GetUserPreferences();

        Step = OrchestratorStep.ToPlanning;

        _checkpointManager.SetIndex();

        while (!plan.Done)
        {
            var prompt = GetPrompt(input);

            var ollamaRequestDto = new OllamaRequestDto();

            ollamaRequestDto.Model = userPreferences.Model;
            ollamaRequestDto.Prompt = prompt;

            var agentResponse = await _ollamaFacade.ChatAsync(ollamaRequestDto);

            if (agentResponse.HasError)
            {
                //tratar esse erro...
            }

            var planResponse = JsonSerializer.Deserialize<Planner>(agentResponse.Response);

            if (!ValidatePlan(planResponse))
            {

            }

            foreach (var action in planResponse.ActionsToExecute)
            {
                _executor.Execute(action);
            }

        }
    }

    private bool ValidatePlan(Planner plan)
    {
        return true;
    }

    private string GetPrompt(string input)
    {
        if (Step == OrchestratorStep.ToPlanning)
        {
            Step = OrchestratorStep.InProgress;
            return _promptProvider.GetPlannerPrompt(input);
        }


        return _promptProvider.GetPlannerPrompt(input);
    }
}
