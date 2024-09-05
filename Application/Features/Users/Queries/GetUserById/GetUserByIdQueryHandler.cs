using Application.Interfaces.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQueryRequest,List<GetUserByIdQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetUserByIdQueryResponse>>Handle(GetUserByIdQueryRequest request,CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Users.GetAllUsersAsync(request.Id);

            return users.Select(x => new GetUserByIdQueryResponse
            {
                Id = x.Id,
                Email = x.Email,
                FullName = x.FullName,
                Password = x.Password,
                RefreshToken = x.RefreshToken,
                RefreshTokenExpiryTime = x.RefreshTokenExpiryTime,
                Roles=x.Roles,
            }).ToList();
        }
    }
}
