using Application.Common.Interfaces.UnitOfWorks;
using MediatR;

using static Application.Features.Products.Command.DeleteProduct.DeleteProductHandler;

namespace Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var product = await unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);



            // Ürünü sil
            unitOfWork.Products.Delete(product);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.CommitAsync();

            return Unit.Value; // MediatR için dönüş türü
        }

        public class DeleteProductRequest : IRequest<Unit>
        {
            public int Id { get; set; }
        }

    }
}
