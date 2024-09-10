using Application.Common.Interfaces.UnitOfWorks;
using MediatR;
using System.Data;
using static Application.Features.Roles.Queries.GetAllRoles.GetAllRoleHandler;


namespace Application.Features.Roles.Queries.GetAllRoles
{

    public record GetAllRoleHandler(GetAllRoleRequest Request) : IRequest<List<GetAllRoleResponse>>
    {
        public class Handler : IRequestHandler<GetAllRoleHandler, List<GetAllRoleResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetAllRoleResponse>> Handle(GetAllRoleHandler query, CancellationToken cancellationToken)
            {
                var roles = await _unitOfWork.Roles.GetAllRolesAsync(query.Request.Id, query.Request.Name, query.Request.Description);
               

                var response = roles.Select(x => new GetAllRoleResponse
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name
                }).ToList();


                return response;
            }
        }

        public class GetAllRoleRequest
        {
            public Guid? Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }

            public GetAllRoleHandler ToQuery()
            {
                return new GetAllRoleHandler(this);
            }
        }

        public class GetAllRoleResponse
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

        }

    }


}

