using HandlerApi.Response;
using MediatR;

namespace HandlerApi.Requests;

public class ReverseWordsRequest : IRequest<ReverseWordsResponse>
{
    public string ValueToReverse { get; set; }
}