namespace Models;

public abstract class ICommand(string code, string description)
{
    public string Code { get; private set; } = code;
    public string Description { get; private set; } = description;
    public abstract CommandResult Execute();
}
