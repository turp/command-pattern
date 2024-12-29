using Controls;
using Services;
using Xunit;
using Moq;
using Models;

namespace Tests;

public class C123456Tests
{
    [Fact]
    public void C123456_AllServicesReturnSuccess_ReturnsSuccessMessage()
    {
        // Arrange
        var jiraServiceMock = new Mock<IJiraServce>();
        var assetServiceMock = new Mock<IAssetService>();

        jiraServiceMock.Setup(s => s.GetTicket("123456")).Returns(new JiraTicket());
        assetServiceMock.Setup(s => s.GetTicket("123456")).Returns(new ServiceNowTicket());

        var command = new C123456(jiraServiceMock.Object, assetServiceMock.Object);

        // Act
        var result = command.Execute();

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Success", result.Message);
    }

    [Fact]
    public void C123456_JiraServiceFails_ReturnsFailureMessage()
    {
        // Arrange
        var jiraServiceMock = new Mock<IJiraServce>();
        var assetServiceMock = new Mock<IAssetService>();

        jiraServiceMock.Setup(s => s.GetTicket("123456")).Returns((JiraTicket)null);
        assetServiceMock.Setup(s => s.GetTicket("123456")).Returns(new ServiceNowTicket());

        var command = new C123456(jiraServiceMock.Object, assetServiceMock.Object);

        // Act
        var result = command.Execute();

        // Assert
        Assert.False(result.Success);
        Assert.StartsWith("C123456_02: Failed to get ticket 123456", result.Message);
    }

    [Fact]
    public void C123456_AssetServiceFails_ReturnsFailureMessage()
    {
        // Arrange
        var jiraServiceMock = new Mock<IJiraServce>();
        var assetServiceMock = new Mock<IAssetService>();

        jiraServiceMock.Setup(s => s.GetTicket("123456")).Returns(new JiraTicket());
        assetServiceMock.Setup(s => s.GetTicket("123456")).Returns((ServiceNowTicket)null);

        var command = new C123456(jiraServiceMock.Object, assetServiceMock.Object);

        // Act
        var result = command.Execute();

        // Assert
        Assert.False(result.Success);
        Assert.StartsWith("C123456_03: Failed to get ticket 123456", result.Message);
    }
}
