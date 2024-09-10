using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Products.Queries.GetProductById.GetProductByIdHandler;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdHandler:IRequestHandler<GetProductByIdRequest,List<GetProductByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetProductByIdResponse>> Handle(GetProductByIdRequest request,CancellationToken cancellationToken)
        {
            var products= await _unitOfWork.Products.GetAllProductsAsync(request.Id);

            return products.Select(x => new GetProductByIdResponse
            {
                Id= x.Id,
                Title = x.Title,
                Description =x.Description,
                Price = x.Price,
                CategoryId = x.CategoryId,
                Stock = x.Stock,
            }).ToList();
        }

        public class GetProductByIdResponse
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public string Stock { get; set; }
        }

        public class GetProductByIdRequest : IRequest<List<GetProductByIdResponse>>
        {
            public int Id { get; set; }
        }


    }
}
