using MediatR;

namespace Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Stock { get; set; }
    }
}
