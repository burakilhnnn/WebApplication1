using Application.Features.Orders.Queries.GetAllOrder;
using Application.Features.Categories.Queries.GetAllCategories;
using MediatR;

namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest
    {
        public int? Id { get; set; }

        public GetAllCategoryQueryHandler ToQuery()
        {
            return new GetAllCategoryQueryHandler(this);
        }
    }
}
