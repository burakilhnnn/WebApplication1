using Application.Features.Users.Command.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Users.Command.DeleteUser;
using Application.Features.Orders.Queries.GetAllOrders;
using Microsoft.AspNetCore.Authorization;
using Application.Features.NewPassword.GenerateReset;
using Application.Features.NewPassword.ConfirmReset;
using Application.Features.NewPassword.ConfirmReset;
using Application.Features.Roles.Queries.GetRoleById;
using Application.Features.Users.Queries.GetUserById;


namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
 //   [Authorize(Roles = "Admin")]

    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersById([FromRoute] Guid id)
        {
            var query = new GetUserByIdQueryRequest { Id = id };
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest req)
        {
            var response = await mediator.Send(req.ToQuery());
            return Ok(response);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUsers(CreateUserCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUsers(UpdateUserCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUsers(DeleteUserCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


    }
}

