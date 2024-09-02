using Application.Features.Categories.Command.CreateCategory;
using FluentValidation;

namespace Application.Features.Categories.Validators
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Kategori adı zorunludur.")
                .Length(3, 100).WithMessage("Kategori adı 3 ile 100 karakter arasında olmalıdır.");

            RuleFor(command => command.ParentId)
                .GreaterThanOrEqualTo(0).WithMessage("ParentId sıfır veya daha büyük bir tamsayı olmalıdır.");


        }
    }
}
