using Application.Features.Products.Command.DeleteProduct.Application.Features.Products.Command.DeleteProduct;
using Application.Interfaces.UnitOfWorks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var product = await unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);



            // Ürünü sil
            unitOfWork.Products.Delete(product);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.CommitAsync();

            return Unit.Value; // MediatR için dönüş türü
        }
    }
}
