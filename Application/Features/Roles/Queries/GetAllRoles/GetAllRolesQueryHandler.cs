using Application.Features.Orders.Queries.GetAllOrders;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Data;


namespace Application.Features.Roles.Queries.GetAllRoles
{

    public record GetAllRoleQueryHandler(GetAllRolesQueryRequest Request) : IRequest<List<GetAllRolesQueryResponse>>
    {
        public class Handler : IRequestHandler<GetAllRoleQueryHandler, List<GetAllRolesQueryResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetAllRolesQueryResponse>> Handle(GetAllRoleQueryHandler query, CancellationToken cancellationToken)
            {
                var roles = await _unitOfWork.Roles.GetAllRolesAsync(query.Request.Id, query.Request.Name, query.Request.Description);
               

                var response = roles.Select(x => new GetAllRolesQueryResponse
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name
                }).ToList();


                return response;
            }
        }
    }


}

