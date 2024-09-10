using Application.Features.Products.Command.CreateProduct;
using FluentValidation;
using MediatR;
using static Application.Features.Products.Command.CreateProduct.CreateProductHandler;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty().WithMessage("Ürün başlığı gereklidir.")
            .Length(3, 100).WithMessage("Ürün başlığı 3 ila 100 karakter arasında olmalıdır.");

        RuleFor(command => command.Description)
            .NotEmpty().WithMessage("Ürün açıklaması gereklidir.")
            .Length(10, 500).WithMessage("Ürün açıklaması 10 ila 500 karakter arasında olmalıdır.");

        RuleFor(command => command.Price)
            .GreaterThan(0).WithMessage("Ürün fiyatı sıfırdan büyük olmalıdır.");

        RuleFor(command => command.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId pozitif bir sayı olmalıdır.");
    }
}
