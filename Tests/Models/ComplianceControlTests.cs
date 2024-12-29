using Models;
using Services;
using Xunit;
using Moq;

namespace Tests;

public class ComplianceControlTests
{
    private class TestCommand : ComplianceControl
    {
        public new void AddChild(ICommand child)
        {
            base.AddChild(child);
        }
    }

    private class TestComplianceCheck : ComplianceCheck
    {
        private readonly bool _shouldSucceed;
        private readonly string _message;

        public TestComplianceCheck(bool shouldSucceed = true, string message = "")
        {
            _shouldSucceed = shouldSucceed;
            _message = message;
        }

        public override CommandResult Execute()
        {
            return new CommandResult
            {
                Success = _shouldSucceed,
                Message = _message
            };
        }
    }

    [Fact]
    public void Execute_AllChildCommandsSuccessful_ReturnsSuccessMessage()
    {
        // Arrange
        var parentCommand = new TestCommand();
        parentCommand.AddChild(new TestComplianceCheck(true));
        parentCommand.AddChild(new TestComplianceCheck(true));

        // Act
        var result = parentCommand.Execute();

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Success", result.Message);
    }

    [Fact]
    public void Execute_OneChildCommandFails_ReturnsConcatenatedFailureMessages()
    {
        // Arrange
        var parentCommand = new TestCommand();
        parentCommand.AddChild(new TestComplianceCheck(true));
        parentCommand.AddChild(new TestComplianceCheck(false, "Child command failed"));

        // Act
        var result = parentCommand.Execute();

        // Assert
        Assert.False(result.Success);
        Assert.Equal("Child command failed", result.Message);
    }

    [Fact]
    public void Execute_MultipleChildCommandsFail_ReturnsConcatenatedFailureMessages()
    {
        // Arrange
        var parentCommand = new TestCommand();
        parentCommand.AddChild(new TestComplianceCheck(false, "First failure"));
        parentCommand.AddChild(new TestComplianceCheck(false, "Second failure"));

        // Act
        var result = parentCommand.Execute();

        // Assert
        Assert.False(result.Success);
        Assert.Equal("First failure. Second failure", result.Message);
    }
}
