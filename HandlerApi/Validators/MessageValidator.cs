using FluentValidation;
using HandlerApi.DTO;

namespace HandlerApi.Validators;

public class MessageValidator : AbstractValidator<Message>
{
    public MessageValidator()
    {
        RuleFor(x => x.Name).NotEmpty();  // Можно так же добавить .WithMessage("...");
        RuleFor(x => x.Value).NotEmpty();
    }
}