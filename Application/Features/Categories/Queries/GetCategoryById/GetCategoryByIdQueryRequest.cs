using MediatR;

namespace Application.Features.Categories.Queries
{
    public class GetCategoryByIdQueryRequest : IRequest<List<GetCategoryByIdQueryResponse>>
    {
        public int Id { get; set; }
    }
}
