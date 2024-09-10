using Application.Common.Interfaces.UnitOfWorks;
using MediatR;
using static Application.Features.Categorys.Command.UpdateCategory.UpdateCategoryHandler;

namespace Application.Features.Categorys.Command.UpdateCategory
{

    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
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

        public class UpdateCategoryRequest : IRequest<Unit>
        {
            public int Id { get; set; }
            public int ParentId { get; set; }
            public string Name { get; set; }

        }

    }
}




