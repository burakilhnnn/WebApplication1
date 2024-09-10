using Application.Common.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.NewPassword.ConfirmReset.ConfirmResetCodeHandler;

namespace Application.Features.NewPassword.ConfirmReset
{
    public class ConfirmResetCodeHandler : IRequestHandler<ConfirmResetCodeResponse, bool>
    {
        private readonly IUserRepository _userRepository;

        public ConfirmResetCodeHandler(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        public async Task<bool> Handle(ConfirmResetCodeResponse request, CancellationToken cancellationToken)
        {
            var isValid = await _userRepository.ValidateResetCodeAsync(request.Email, request.ResetCode);
            if (!isValid)
            {
                return false;
            }

            await _userRepository.UpdatePasswordAsync(request.Email, request.NewPassword);
            return true;
        }

        public class ConfirmResetCodeResponse : IRequest<bool>
        {
            public string Email { get; set; }
            public string ResetCode { get; set; }
            public Guid userId { get; set; }
            public string NewPassword { get; set; }
        }

        public class PasswordResetConfirmationRequest
        {
            public string Email { get; set; }
            public string ResetCode { get; set; }
            public string NewPassword { get; set; }
        }

    }
}
