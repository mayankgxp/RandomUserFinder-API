using System.Net;

namespace RandomUserFinder.Tests.Handlers;

public class MockHttpMessageHandler: HttpMessageHandler
{
    private readonly string _responseJson;

    public MockHttpMessageHandler(string responseJson)
    {
        _responseJson = responseJson;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(_responseJson))
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
            };
        }

        return new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(_responseJson),
        };
    }
}
