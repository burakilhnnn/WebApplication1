using FluentValidation;
using static Application.Features.Orders.Command.CreateOrder.CreateOrderHandler;

namespace Application.Features.Orders.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(command => command.UserId)
                          .NotEmpty()
                          .WithMessage("Kullanıcı ID'si boş olamaz.");


        }

    }
}
