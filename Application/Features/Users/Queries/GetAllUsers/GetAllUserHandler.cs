using Application.Common.Interfaces.UnitOfWorks;
using Application.Features.Orders.Queries.GetAllOrders;
using MediatR;
using static Application.Features.Users.Queries.GetAllUsers.GetAllUserHandler;


namespace Application.Features.Users.Queries.GetAllUsers
{

    public record GetAllUserHandler(GetAllUserRequest Request) : IRequest<List<GetAllUserResponse>>
    {
        public class Handler : IRequestHandler<GetAllUserHandler, List<GetAllUserResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetAllUserResponse>> Handle(GetAllUserHandler query, CancellationToken cancellationToken)
            {
                var users = await _unitOfWork.Users.GetAllUsersAsync(query.Request.Id, query.Request.FullName, query.Request.Email, query.Request.Roles);
              

                var response = users.Select(x=> new GetAllUserResponse
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Email = x.Email,
                    Password = x.Password,
                    RefreshToken= x.RefreshToken,
                    RefreshTokenExpiryTime= x.RefreshTokenExpiryTime,
                    Roles=x.Roles
                }).ToList();

                 return response;

                }
            }

        public class GetAllUserRequest
        {
            public Guid? Id { get; set; }
            public string? FullName { get; set; }
            public string? Email { get; set; }
            public List<Guid>? Roles { get; set; }

            public GetAllUserHandler ToQuery()
            {
                return new GetAllUserHandler(this);
            }
        }

        public class GetAllUserResponse
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




