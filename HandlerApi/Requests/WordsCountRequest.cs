using HandlerApi.Response;
using MediatR;

namespace HandlerApi.Requests;

public class WordsCountRequest : Request, IRequest<WordsCountResponse>
{
}