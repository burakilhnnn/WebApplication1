using FluentValidation;
using static Application.Features.Roles.Command.CreateRole.CreateRoleHandler;

namespace Application.Features.Roles.Command.CreateRole
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleRequest>
    {
        public CreateRoleValidator()
        {
            // Rol adı için doğrulama kuralları
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Rol adı gereklidir.")
                .MaximumLength(256).WithMessage("Rol adı 256 karakteri geçemez.");

            // Rol açıklaması için doğrulama kuralları
            RuleFor(r => r.Description)
                .MaximumLength(500).WithMessage("Rol açıklaması 500 karakteri geçemez.");

        }
    }
}
