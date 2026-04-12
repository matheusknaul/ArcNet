using ArcNet.Core.Entities;

namespace ArcNet.Application.Interfaces;

public interface IActionExecutor
{
    Task<string> Execute(ActionExecution action);
}