using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest
    {
        public int ProductId { get; set; }

        public GetAllProductsQueryHandler ToQuery()
        {
            return new GetAllProductsQueryHandler(this);
        }
    }
}
