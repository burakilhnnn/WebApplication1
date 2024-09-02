using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;


namespace Application.Features.Categories.Queries.GetAllCategories
{

    public record GetAllCategoryQueryHandler(GetAllCategoriesQueryRequest Request) : IRequest<List<GetAllCategoriesQueryResponse>>
    {
        public class Handler : IRequestHandler<GetAllCategoryQueryHandler, List<GetAllCategoriesQueryResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoryQueryHandler query, CancellationToken cancellationToken)
            {
                var categories = await _unitOfWork.Categories.GetAllCategoriesAsync(query.Request.Id);


                var response = categories.Select(x => new GetAllCategoriesQueryResponse { Id = x.Id, Name = x.Name, ParentId = x.ParentId}).ToList();

                return response;

                }
            }
        }
    }




