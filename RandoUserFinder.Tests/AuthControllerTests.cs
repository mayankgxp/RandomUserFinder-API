using Microsoft.AspNetCore.Mvc;
using Moq;
using RandomUserFinder.Controllers;
using RandomUserFinder.Models;
using RandomUserFinder.Services;
using Xunit;

namespace RandomUserFinder.Tests;
public class AuthControllerTests
{
    [Fact]
    public void Post_Returns_True_With_Valid_Credentials()
    {
        // Arrange
        var authServiceMock = new Mock<IAuthService>();
        authServiceMock.Setup(service => service.ValidateCredentials("valid_username", "valid_password")).Returns(true);

        var controller = new AuthController(authServiceMock.Object);
        var credentials = new Credential { UserName = "valid_username", Password = "valid_password" };

        // Act
        var result = controller.Post(credentials);

        // Assert
        var actionResult = Assert.IsType<ActionResult<bool>>(result);
        var value = Assert.IsType<bool>(actionResult.Value);
        Assert.True(value);
    }

    [Fact]
    public void Post_Returns_False_With_Invalid_Credentials()
    {
        // Arrange
        var authServiceMock = new Mock<IAuthService>();
        authServiceMock.Setup(service => service.ValidateCredentials("invalid_username", "invalid_password")).Returns(false);

        var controller = new AuthController(authServiceMock.Object);
        var credentials = new Credential { UserName = "invalid_username", Password = "invalid_password" };

        // Act
        var result = controller.Post(credentials);

        // Assert
        var actionResult = Assert.IsType<ActionResult<bool>>(result);
        var value = Assert.IsType<bool>(actionResult.Value);
        Assert.False(value);
    }
}
