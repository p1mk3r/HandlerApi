using HandlerApi.Response;
using MediatR;

namespace HandlerApi.Requests;

public class TwoDigitsSumRequest : Request, IRequest<TwoDigitsSumResponse>
{
}