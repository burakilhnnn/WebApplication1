using Application.Features.Orders.Queries.GetAllOrders;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;


namespace Application.Features.Users.Queries.GetAllUsers
{

    public record GetAllUserQueryHandler(GetAllUsersQueryRequest Request) : IRequest<List<GetAllUsersQueryResponse>>
    {
        public class Handler : IRequestHandler<GetAllUserQueryHandler, List<GetAllUsersQueryResponse>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<GetAllUsersQueryResponse>> Handle(GetAllUserQueryHandler query, CancellationToken cancellationToken)
            {
                var users = await _unitOfWork.Users.GetAllUsersAsync(query.Request.UserId);
              

                var response = users.Select(x=> new GetAllUsersQueryResponse {Id=x.Id,FullName=x.FullName,Email=x.Email,Password=x.Password}).ToList();

                 return response;

                }
            }
        }
    }




