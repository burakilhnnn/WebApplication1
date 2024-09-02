using Application.Common.Interfaces.Repository;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NewPassword.GenerateReset
{
    public class GenerateResetCodeCommandHandler : IRequestHandler<GenerateResetCodeCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IResetCodeRepository _resetCodeRepository;

        public GenerateResetCodeCommandHandler(IUserRepository userRepository, IResetCodeRepository resetCodeRepository)
        {
            _userRepository = userRepository;
            _resetCodeRepository = resetCodeRepository;
        }

        public async Task<bool> Handle(GenerateResetCodeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            PasswordResetService service = new PasswordResetService(_userRepository, _resetCodeRepository);


            if (user == null)
                return false;

            await service.RequestPasswordResetAsync(user.Email);

            return true;
        }
    }
}

