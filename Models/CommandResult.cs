using System.Collections.Generic;
using System.Linq;

namespace Models;

public class CommandResult
{
    private bool _success;
    private string _message;
    private readonly ICommand command;

    public CommandResult(ICommand command)
    {
        this.command = command;
    }

    public string Name => $"{command.Code}: {command.Description}";

    public bool Success
    {
        get
        {
            return ChildResults.Count > 0
                ? !ChildResults.Any(cr => !cr.Success)
                : _success;
        }
        set
        {
            _success = value;
        }
    }

    public string Message
    {
        get
        {
            var messages = ChildResults
            .Where(cr => !cr.Success)
            .Select(cr => cr.Message)
            .ToList();
            if (messages.Count > 0)
                return string.Join(". ", messages).Trim();
            return string.IsNullOrEmpty(_message)
                ? "Success"
                : _message;
        }
        set
        {
            _message = value;
        }
    }
    public List<CommandResult> ChildResults { get; set; } = [];
}
