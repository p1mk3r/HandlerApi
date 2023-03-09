using HandlerApi.Options;
using HandlerApi.Requests;
using HandlerApi.Response;
using MediatR;
using Microsoft.Extensions.Options;

namespace HandlerApi.Handlers;

public class TwoDigitsSumHandler : IRequestHandler<TwoDigitsSumRequest, TwoDigitsSumResponse>
{
    private IOptions<TwoDigitsSumOptions> _options;

    public TwoDigitsSumHandler(IOptions<TwoDigitsSumOptions> options)
    {
        _options = options;
    }


    public async Task<TwoDigitsSumResponse> Handle(TwoDigitsSumRequest request, CancellationToken cancellationToken)
    {
        var splitted = request.Value.Split(' ');

        if (splitted.Length != 2)
            throw new ArgumentException("После разделения строки количество чисел не равно двум.");

        var sum = splitted.Select(x =>
        {
            if (!int.TryParse(x, out var y))
                throw new InvalidCastException($"Невозможно привести значение '{x}' к типу int.");

            return y;
        }).Sum();
        
        
        var result = new TwoDigitsSumResponse
        {
            Sum = sum,
            Created = DateTime.Now
        };
        
        return await Task.FromResult(result);
    }
}