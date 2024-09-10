using Application.Features.Categories.Command.CreateCategory;
using FluentValidation;
using static Application.Features.Categories.Command.CreateCategory.CreateCategoryHandler;

namespace Application.Features.Categories.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Kategori adı zorunludur.")
                .Length(3, 100).WithMessage("Kategori adı 3 ile 100 karakter arasında olmalıdır.");

            RuleFor(command => command.ParentId)
                .GreaterThanOrEqualTo(0).WithMessage("ParentId sıfır veya daha büyük bir tamsayı olmalıdır.");


        }
    }
}
