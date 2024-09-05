using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQueryRequest,List<GetProductByIdQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetProductByIdQueryResponse>> Handle(GetProductByIdQueryRequest request,CancellationToken cancellationToken)
        {
            var products= await _unitOfWork.Products.GetAllProductsAsync(request.Id);

            return products.Select(x => new GetProductByIdQueryResponse
            {
                Id= x.Id,
                Title = x.Title,
                Description =x.Description,
                Price = x.Price,
                CategoryId = x.CategoryId,
                Stock = x.Stock,
            }).ToList();
        }

    }
}
