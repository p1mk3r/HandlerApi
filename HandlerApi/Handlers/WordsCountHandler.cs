using HandlerApi.Requests;
using HandlerApi.Response;
using MediatR;

namespace HandlerApi.Handlers;

public class WordsCountHandler : IRequestHandler<WordsCountRequest, WordsCountResponse>
{
    public async Task<WordsCountResponse> Handle(WordsCountRequest request, CancellationToken cancellationToken)
    {
        var wordsCount = request.Words.Split().Length;

        var result = new WordsCountResponse
        {
            Count = wordsCount,
            CreatedDateTime = DateTime.Now
        };
        
        return await Task.FromResult(result);
    }
}