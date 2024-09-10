using Application.Common.Interfaces.UnitOfWorks;
using MediatR;
using static Application.Features.Categories.Queries.GetCategoryByIdHandler;

namespace Application.Features.Categories.Queries
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdRequest, List<GetCategoryByIdResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCategoryByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetCategoryByIdResponse>> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
            {
                // Belirtilen ID'ye sahip kategorileri al
                var categories = await _unitOfWork.Categories.GetAllCategoriesAsync(request.Id);

                return categories.Select(x => new GetCategoryByIdResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = x.ParentId
                }).ToList();
            }

        public class GetCategoryByIdRequest : IRequest<List<GetCategoryByIdResponse>>
        {
            public int Id { get; set; }
        }

        public class GetCategoryByIdResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ParentId { get; set; }
        }

    }
    }