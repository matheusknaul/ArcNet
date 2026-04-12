using ArcNet.Application.Interfaces;

namespace ArcNet.Application.Orchestrator;

public class AgentOrchestrator : IAgentOrchestrator
{
    private readonly IActionExecutor _executor;

    public AgentOrchestrator(IActionExecutor executor)
    {
        
    }

    public async Task Run(string input)
    {
        var plan = await _planner.Plan(input);

        foreach (var action in plan.Actions)
        {
            var result = await _executor.Execute(action);
        }
    }
}
