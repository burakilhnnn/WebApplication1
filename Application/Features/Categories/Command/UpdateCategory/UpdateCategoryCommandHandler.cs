using Application.Features.Categories.Command.UpdateCategory;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Controllers;

namespace Application.Features.Categorys.Command.UpdateCategory
{

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var categories = await unitOfWork.Categories.GetByIdAsync(request.Id, cancellationToken);

            // Ürünü güncelle
            categories.Name = request.Name;
            categories.ParentId = request.ParentId;

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.CommitAsync();

            return Unit.Value; // MediatR için dönüş türü
        }

    }
}




