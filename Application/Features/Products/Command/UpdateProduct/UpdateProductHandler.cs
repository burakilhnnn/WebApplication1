using Application.Common.Interfaces.UnitOfWorks;
using MediatR;

using static Application.Features.Products.Command.UpdateProduct.UpdateProductHandler;

namespace Application.Features.Products.Command.UpdateProduct
{

    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateProductHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
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

        public class UpdateProductRequest : IRequest<Unit>
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public string Stock { get; set; }
        }

    }

}


