using System.Collections.Generic;

namespace Models;

public abstract class ComplianceControl : ICommand
{
    private readonly List<ICommand> _children = [];

    protected void AddChild(ICommand command)
    {
        _children.Add(command);
    }

    public CommandResult Execute()
    {
        var result = new CommandResult();
        foreach (var command in _children)
        {
            var childResult = command.Execute();
            result.ChildResults.Add(childResult);
        }
        return result;
    }
}

public abstract class ComplianceCheck : ICommand
{
    public abstract CommandResult Execute();
}
