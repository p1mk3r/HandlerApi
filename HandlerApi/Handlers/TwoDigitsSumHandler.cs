using HandlerApi.Requests;
using HandlerApi.Response;
using MediatR;

namespace HandlerApi.Handlers;

public class TwoDigitsSumHandler : IRequestHandler<TwoDigitsSumRequest, TwoDigitsSumResponse>
{
    public async Task<TwoDigitsSumResponse> Handle(TwoDigitsSumRequest request, CancellationToken cancellationToken)
    {
        var splitted = request.Digits.Split(' ');

        if (splitted.Length < 2)
            throw new ArgumentException("После разделения строки количество чисел < 2.");

        var sum = splitted.Select(x =>
        {
            if (!int.TryParse(x, out var y))
                throw new InvalidCastException("Невозможно привести значение {x} к типу int.");

            return y;
        }).Sum();
        
        
        var result = new TwoDigitsSumResponse
        {
            Sum = sum,
            CreatedDateTime = DateTime.Now
        };
        
        return await Task.FromResult(result);
    }
}