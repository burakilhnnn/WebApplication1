﻿using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public string? Stock { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }

        public GetAllProductsQueryHandler ToQuery()
        {
            return new GetAllProductsQueryHandler(this);
        }
    }
}
