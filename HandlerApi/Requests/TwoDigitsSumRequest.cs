using HandlerApi.Response;
using MediatR;

namespace HandlerApi.Requests;

public class TwoDigitsSumRequest : IRequest<TwoDigitsSumResponse>
{
    public string Digits { get; set; }
}