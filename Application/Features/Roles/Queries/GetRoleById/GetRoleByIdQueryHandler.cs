using Application.Interfaces.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQueryRequest, List<GetRoleByIdQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRoleByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetRoleByIdQueryResponse>> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await _unitOfWork.Roles.GetAllRolesAsync(request.Id);

            return roles.Select(x => new GetRoleByIdQueryResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }
    }
}
