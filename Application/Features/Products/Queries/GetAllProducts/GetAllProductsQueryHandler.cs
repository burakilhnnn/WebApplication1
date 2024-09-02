using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductsQueryHandler(GetAllProductsQueryRequest Request) : IRequest<List<GetAllProductsQueryResponse>>
    {
        public class Handler : IRequestHandler<GetAllProductsQueryHandler, List<GetAllProductsQueryResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryHandler query, CancellationToken cancellationToken)
            {
                var products = await _unitOfWork.Products.GetAllProductsAsync(query.Request.ProductId);


                var response = products.Select(x => new GetAllProductsQueryResponse {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Price = x.Price,
                    CategoryId = x.CategoryId,
                    Stock = x.Stock,
                }).ToList();


                return response;
            }
        }
    }
}
