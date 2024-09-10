using Application.Common.Interfaces.UnitOfWorks;
using MediatR;

using static Application.Features.Products.Queries.GetAllProducts.GetAllProductHandler.Handler;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductHandler(GetAllProductRequest Request) : IRequest<List<GetAllProductResponse>>
    {
        public class Handler : IRequestHandler<GetAllProductHandler, List<GetAllProductResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetAllProductResponse>> Handle(GetAllProductHandler query, CancellationToken cancellationToken)
            {
                var products = await _unitOfWork.Products.GetAllProductsAsync(query.Request.Id,query.Request.Title, query.Request.Description,query.Request.Price, query.Request.CategoryId,query.Request.Stock, query.Request.MinPrice,
    query.Request.MaxPrice);


                var response = products.Select(x => new GetAllProductResponse {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Price = x.Price,
                    CategoryId = x.CategoryId,
                    Stock = x.Stock,

                }).ToList();


                return response;
            }

            public class GetAllProductRequest
            {
                public int? Id { get; set; }
                public string? Title { get; set; }
                public string? Description { get; set; }
                public decimal? Price { get; set; }
                public int? CategoryId { get; set; }
                public string? Stock { get; set; }
                public decimal? MaxPrice { get; set; }
                public decimal? MinPrice { get; set; }

                public GetAllProductHandler ToQuery()
                {
                    return new GetAllProductHandler(this);
                }
            }

            public class GetAllProductResponse
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
}
