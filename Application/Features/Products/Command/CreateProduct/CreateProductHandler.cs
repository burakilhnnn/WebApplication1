using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;

using static Application.Features.Products.Command.CreateProduct.CreateProductHandler;

namespace Application.Features.Products.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProductRequest request, CancellationToken cancellationToken)
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

        public class CreateProductRequest : IRequest<Unit>
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public string Stock { get; set; }
        }

    }
}
