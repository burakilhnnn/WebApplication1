using MediatR;

namespace Application.Features.Categories.Queries
{
    public class GetCategoryByIdQueryRequest : IRequest<GetCategoryByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
