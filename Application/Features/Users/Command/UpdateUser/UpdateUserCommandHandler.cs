using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Controllers;

namespace Application.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.Users.GetByIdAsync(request.Id,request.Password, cancellationToken);

            user.Id = request.Id;
            user.FullName = request.FullName;
            user.Email = request.Email;
            user.Password = request.Password;

            await unitOfWork.CommitAsync();

            return Unit.Value; 
        }
    }
}
