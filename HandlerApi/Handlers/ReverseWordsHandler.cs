using HandlerApi.Options;
using HandlerApi.Requests;
using HandlerApi.Response;
using MediatR;
using Microsoft.Extensions.Options;

namespace HandlerApi.Handlers;

public class ReverseWordsHandler : IRequestHandler<ReverseWordsRequest, ReverseWordsResponse>
{
    private IOptions<ReverseWordsOptions> _options;

    public ReverseWordsHandler(IOptions<ReverseWordsOptions> options)
    {
        _options = options;
    }

    public async Task<ReverseWordsResponse> Handle(ReverseWordsRequest request, CancellationToken cancellationToken)
    {
        var reversedString = string.Join(" ", request.Value.Split(' ').Reverse());

        var result = new ReverseWordsResponse
        {
            ReversedString = reversedString,
            Created = DateTime.Now
        };
        
        return await Task.FromResult(result);
    }
}