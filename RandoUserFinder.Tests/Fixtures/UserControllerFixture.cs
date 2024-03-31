using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using RandomUserFinder.Controllers;
using RandomUserFinder.Services;

namespace RandomUserFinder.Tests.Fixtures;

public class UserControllerFixture : IDisposable
{
    private bool disposedValue;

    public UserController Controller { get; private set; }
    public Mock<IRandomUserService> RandomUserServiceMock { get; private set; }
    public Mock<ILogger<UserController>> LoggerMock { get; private set; }
    public Mock<IMapper> MapperMock { get; private set; }

    public UserControllerFixture()
    {
        RandomUserServiceMock = new Mock<IRandomUserService>();
        LoggerMock = new Mock<ILogger<UserController>>();
        MapperMock = new Mock<IMapper>();

        Controller = new UserController(RandomUserServiceMock.Object, LoggerMock.Object, MapperMock.Object);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                //TODO
            }

            disposedValue = true;
        }
    }
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
