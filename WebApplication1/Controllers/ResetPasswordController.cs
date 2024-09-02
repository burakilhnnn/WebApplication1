using Application.Features.NewPassword.ConfirmReset;
using Application.Features.NewPassword.GenerateReset;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResetPasswordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SendCode")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestPasswordReset([FromBody] PasswordResetRequest request)
        {
            var result = await _mediator.Send(new GenerateResetCodeCommand(request.Email));
            if (result)
            {
                return Ok("Reset code has been sent to your email address.");
            }
            return BadRequest("Email address not found.");
        }

        [HttpPost("NewPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmPasswordReset([FromBody] PasswordResetConfirmationRequest request)
        {
            var result = await _mediator.Send(new ConfirmResetCodeCommand
            {
                Email = request.Email,
                ResetCode = request.ResetCode,
                NewPassword = request.NewPassword
            });

            if (result)
            {
                return Ok("Password has been successfully updated.");
            }
            else
            {
                return BadRequest("Reset code is invalid or expired.");
            }
        }
    }
}


