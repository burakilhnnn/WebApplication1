using Application.Features.Orders.Command.CreateOrder;
using FluentValidation;

namespace Application.Features.Orders.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommandRequest>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(command => command.UserId)
                          .NotEmpty()
                          .WithMessage("Kullanıcı ID'si boş olamaz.");


        }

    }
}
