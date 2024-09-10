using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using static Application.Features.Categories.Queries.GetAllCategories.GetAllCategoryHandler;


namespace Application.Features.Categories.Queries.GetAllCategories
{

    public record GetAllCategoryHandler(GetAllCategoryRequest Request) : IRequest<List<GetAllCategoryResponse>>
    {
        public class Handler : IRequestHandler<GetAllCategoryHandler, List<GetAllCategoryResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetAllCategoryResponse>> Handle(GetAllCategoryHandler query, CancellationToken cancellationToken)
            {
                var categories = await _unitOfWork.Categories.GetAllCategoriesAsync(query.Request.Id, query.Request.Name, query.Request.ParentId);

                var response = categories.Select(x => new GetAllCategoryResponse { Id = x.Id, Name = x.Name, ParentId = x.ParentId }).ToList();

                return response;

                }
            }

        public class GetAllCategoryRequest : IRequest<List<GetAllCategoryResponse>>
        {
            public int? Id { get; set; }
            public string? Name { get; set; }
            public int? ParentId { get; set; }

            public GetAllCategoryHandler ToQuery()
            {
                return new GetAllCategoryHandler(this);
            }


        }

        public class GetAllCategoryResponse
        {
            public int Id { get; set; }
            public int ParentId { get; set; }
            public string Name { get; set; }
        }

    }

}




