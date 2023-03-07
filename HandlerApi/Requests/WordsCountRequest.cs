using HandlerApi.Response;
using MediatR;

namespace HandlerApi.Requests;

public class WordsCountRequest : IRequest<WordsCountResponse>
{
    public string Words { get; set; }
}