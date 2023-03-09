using HandlerApi.Options;
using HandlerApi.Requests;
using HandlerApi.Response;
using MediatR;
using Microsoft.Extensions.Options;

namespace HandlerApi.Handlers;

public class WordsCountHandler : IRequestHandler<WordsCountRequest, WordsCountResponse>
{
    private IOptions<WordsCountOptions> _options;

    public WordsCountHandler(IOptions<WordsCountOptions> options)
    {
        _options = options;
    }

    public async Task<WordsCountResponse> Handle(WordsCountRequest request, CancellationToken cancellationToken)
    {
        var wordsCount = request.Value.Split().Length;

        var result = new WordsCountResponse
        {
            Count = wordsCount,
            Created = DateTime.Now
        };
        
        return await Task.FromResult(result);
    }
}