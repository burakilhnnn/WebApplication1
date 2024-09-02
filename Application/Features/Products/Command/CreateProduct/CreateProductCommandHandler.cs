using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            // Ürünü oluştur
            Product product = new(request.Title, request.Description, request.Price, request.CategoryId, request.Stock);

            // Ürünü veritabanına ekle
            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product, cancellationToken);

            // Değişiklikleri kaydet
            await _unitOfWork.SaveAsync();

            // MediatR için dönüş türü
            return Unit.Value;
        }
    }
}
