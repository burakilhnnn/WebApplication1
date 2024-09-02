using Application.Common.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NewPassword.ConfirmReset
{
    public class ConfirmResetCodeCommandHandler : IRequestHandler<ConfirmResetCodeCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public ConfirmResetCodeCommandHandler(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        public async Task<bool> Handle(ConfirmResetCodeCommand request, CancellationToken cancellationToken)
        {
            var isValid = await _userRepository.ValidateResetCodeAsync(request.Email, request.ResetCode);
            if (!isValid)
            {
                return false;
            }

            await _userRepository.UpdatePasswordAsync(request.Email, request.NewPassword);
            return true;
        }
    }
}
