using Application.Interfaces.UnitOfWorks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.UpdateProduct
{

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            // Ürünü veritabanından bul
            var product = await unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);

            // Ürünü güncelle
            product.Title = request.Title;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;
            product.Stock = request.Stock;

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.CommitAsync();

            return Unit.Value; // MediatR için dönüş türü
        }
    }

}


