using Application.Features.Orders.Command.CreateOrder;
using FluentValidation;

namespace Application.Features.Orders.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommandRequest>
    {
        public CreateOrderCommandValidator()
        {
            RuleForEach(command => command.ProductId)
                .GreaterThan(0)
                .WithMessage("ProductId sıfırdan büyük olmalıdır.");


        }
    }
}
