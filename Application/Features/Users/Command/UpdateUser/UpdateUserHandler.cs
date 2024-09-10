using Application.Common.Interfaces.UnitOfWorks;
using MediatR;

using static Application.Features.Users.Command.UpdateUser.UpdateUserHandler;

namespace Application.Features.Users.Command.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateUserHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.Users.GetByIdAsync(request.Id,request.Password, cancellationToken);

            user.Id = request.Id;
            user.FullName = request.FullName;
            user.Email = request.Email;
            user.Password = request.Password;

            await unitOfWork.CommitAsync();

            return Unit.Value; 
        }

        public class UpdateUserRequest : IRequest<Unit>
        {

            public Guid Id { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }


        }

    }
}
