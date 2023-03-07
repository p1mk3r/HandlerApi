using HandlerApi.Requests;
using HandlerApi.Response;
using MediatR;

namespace HandlerApi.Handlers;

public class ReverseWordsHandler : IRequestHandler<ReverseWordsRequest, ReverseWordsResponse>
{
    public async Task<ReverseWordsResponse> Handle(ReverseWordsRequest request, CancellationToken cancellationToken)
    {
        var reversedString = string.Join(" ", request.ValueToReverse.Split(' ').Reverse());

        var result = new ReverseWordsResponse
        {
            ReversedString = reversedString,
            CreatedDateTime = DateTime.Now
        };
        
        return await Task.FromResult(result);
    }
}