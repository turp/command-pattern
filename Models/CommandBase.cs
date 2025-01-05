using System.Collections.Generic;

namespace Models;

public abstract class ComplianceControl : ICommand
{
    public ComplianceControl(string code, string description) : base(code, description) {}
    private readonly List<ICommand> _children = [];

    protected void AddChild(ICommand command)
    {
        _children.Add(command);
    }

    public override CommandResult Execute()
    {
        var result = new CommandResult(this);

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
    protected ComplianceCheck(string code, string description): base(code, description)
    {
    }
}
