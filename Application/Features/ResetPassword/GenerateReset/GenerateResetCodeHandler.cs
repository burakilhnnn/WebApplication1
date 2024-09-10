using Application.Common.Interfaces.Repository;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.NewPassword.GenerateReset.GenerateResetCodeHandler;

namespace Application.Features.NewPassword.GenerateReset
{
    public class GenerateResetCodeHandler : IRequestHandler<GenerateResetCode, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IResetCodeRepository _resetCodeRepository;

        public GenerateResetCodeHandler(IUserRepository userRepository, IResetCodeRepository resetCodeRepository)
        {
            _userRepository = userRepository;
            _resetCodeRepository = resetCodeRepository;
        }

        public async Task<bool> Handle(GenerateResetCode request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            PasswordResetService service = new PasswordResetService(_userRepository, _resetCodeRepository);


            if (user == null)
                return false;

            await service.RequestPasswordResetAsync(user.Email);

            return true;
        }

        public class PasswordResetRequest
        {
            public string Email { get; set; }
        }

        public class GenerateResetCode : IRequest<bool>
        {
            public GenerateResetCode(string email)
            {
                Email = email;
            }
            public string? ResetCode { get; set; }
            public string? NewPassword { get; set; }
            public string Email { get; set; }
        }

    }
}

