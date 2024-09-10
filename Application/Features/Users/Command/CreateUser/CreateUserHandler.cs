using Application.Common.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Application.Features.Users.Command.CreateUser.CreateUserHandler;

namespace Application.Features.Users.Command.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {


            User user = new User(request.FullName, request.Email, request.Password);

            await _unitOfWork.GetWriteRepository<User>().AddAsync(user, cancellationToken);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }

        public class CreateUserRequest : IRequest<Unit>
        {
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

    }
}
