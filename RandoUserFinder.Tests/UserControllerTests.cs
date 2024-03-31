using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using RandomUserFinder.Models;
using RandomUserFinder.Services;
using RandomUserFinder.Tests.Fixtures;
using RandomUserFinder.Tests.Handlers;
using Xunit;

namespace RandomUserFinder.Tests;

public class UserControllerTests : IClassFixture<UserControllerFixture>
{

    private const string RandomUserAPIUrl = "RandomUserAPIUrl";
    public UserControllerTests()
    {
    }

    [Fact]
    public async Task GetRandomUser_Returns_Ok_With_Valid_RandomUser()
    {
        // Arrange
        var expectedRandomUser = new RandomUser
        {
            Results = new List<RandomeUserInfo>() { new RandomeUserInfo() { Name = new Name() { First = "Mayank", Last = "Gupta" } } }
        };
        var expectedResponseJson = JsonConvert.SerializeObject(expectedRandomUser);

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock.Setup(factory =>
            factory.CreateClient(It.IsAny<string>())).Returns(new HttpClient(new MockHttpMessageHandler(expectedResponseJson)));

        var configurationHook = new Mock<IConfiguration>();
        configurationHook.Setup(x => x[RandomUserAPIUrl]).Returns("https://randomuser.me/api/");

        var randomUserService = new RandomUserService(httpClientFactoryMock.Object, configurationHook.Object);

        // Act
        var result = await randomUserService.GetRandomUserAsync();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetRandomUser_Returns_NotFound_When_No_RandomUser()
    {
        // Arrange
        RandomUser? expectedRandomUser = null;

        var expectedResponseJson = JsonConvert.SerializeObject(expectedRandomUser);

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock.Setup(factory =>
            factory.CreateClient(It.IsAny<string>())).Returns(new HttpClient(new MockHttpMessageHandler(expectedResponseJson)));

        var configurationHook = new Mock<IConfiguration>();
        configurationHook.Setup(x => x[RandomUserAPIUrl]).Returns("https://randomuser.me/api/");


        var randomUserService = new RandomUserService(httpClientFactoryMock.Object, configurationHook.Object);

        // Act
        var result = await randomUserService.GetRandomUserAsync();

        // Assert
        Assert.Null(result);
    }
}