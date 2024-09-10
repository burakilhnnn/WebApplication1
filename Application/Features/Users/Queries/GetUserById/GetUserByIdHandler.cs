using Application.Common.Interfaces.UnitOfWorks;
using MediatR;
using static Application.Features.Users.Queries.GetUserById.GetUserByIdHandler;


namespace Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdHandler: IRequestHandler<GetUserByIdRequest,List<GetUserByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetUserByIdResponse>>Handle(GetUserByIdRequest request,CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Users.GetAllUsersAsync(request.Id);

            return users.Select(x => new GetUserByIdResponse
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

        public class GetUserByIdRequest : IRequest<List<GetUserByIdResponse>>
        {
            public Guid Id { get; set; }
        }

        public class GetUserByIdResponse
        {
            public Guid Id { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string RefreshToken { get; set; } = string.Empty;
            public DateTime RefreshTokenExpiryTime { get; set; }
            public string Password { get; set; }
            public List<Guid> Roles { get; set; }
        }
    }
}
