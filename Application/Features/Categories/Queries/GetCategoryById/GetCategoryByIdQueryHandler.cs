using Application.Features.Categories.Queries.GetAllCategories;
using Application.Interfaces.UnitOfWorks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries
{


    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<GetAllCategoriesQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.Categories.GetAllCategoriesAsync(request.Id);

            return categories.Select(x => new GetAllCategoriesQueryResponse
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId
            }).ToList();
        }
    }
}