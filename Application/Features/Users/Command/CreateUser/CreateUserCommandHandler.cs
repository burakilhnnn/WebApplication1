using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {


            User user = new User(request.FullName, request.Email, request.Password);

            await _unitOfWork.GetWriteRepository<User>().AddAsync(user, cancellationToken);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
