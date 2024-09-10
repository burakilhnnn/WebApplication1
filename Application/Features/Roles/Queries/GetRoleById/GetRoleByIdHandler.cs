using Application.Common.Interfaces.UnitOfWorks;
using MediatR;

using static Application.Features.Roles.Queries.GetRoleById.GetRoleByIdHandler;

namespace Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdRequest, List<GetRoleByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRoleByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetRoleByIdResponse>> Handle(GetRoleByIdRequest request, CancellationToken cancellationToken)
        {
            var roles = await _unitOfWork.Roles.GetAllRolesAsync(request.Id);

            return roles.Select(x => new GetRoleByIdResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }

        public class GetRoleByIdRequest : IRequest<List<GetRoleByIdResponse>>
        {
            public Guid Id { get; set; }
        }

        public class GetRoleByIdResponse
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

    }
}
