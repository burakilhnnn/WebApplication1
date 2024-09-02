using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NewPassword.GenerateReset
{
    public class GenerateResetCodeCommand : IRequest<bool>
    {
        public GenerateResetCodeCommand(string email)
        {
            Email = email;
        }
        public string? ResetCode { get; set; }
        public string? NewPassword { get; set; }
        public string Email { get; set; }
    }
}
