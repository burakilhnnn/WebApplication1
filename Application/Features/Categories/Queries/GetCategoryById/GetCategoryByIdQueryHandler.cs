using Application.Features.Categories.Queries.GetAllCategories;
using Application.Interfaces.UnitOfWorks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries
{
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, List<GetCategoryByIdQueryResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetCategoryByIdQueryResponse>> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
            {
                // Belirtilen ID'ye sahip kategorileri al
                var categories = await _unitOfWork.Categories.GetAllCategoriesAsync(request.Id);

                return categories.Select(x => new GetCategoryByIdQueryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = x.ParentId
                }).ToList();
            }
        }
    }