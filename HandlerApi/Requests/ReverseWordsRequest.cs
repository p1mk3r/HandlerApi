using HandlerApi.Response;
using MediatR;

namespace HandlerApi.Requests;

public class ReverseWordsRequest : Request, IRequest<ReverseWordsResponse> 
{
}