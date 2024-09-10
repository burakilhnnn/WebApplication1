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
using static Application.Features.Users.Queries.GetAllUsers.GetAllUserHandler;
using static Application.Features.Users.Queries.GetUserById.GetUserByIdHandler;
using static Application.Features.Users.Command.CreateUser.CreateUserHandler;
using static Application.Features.Users.Command.UpdateUser.UpdateUserHandler;
using static Application.Features.Users.Command.DeleteUser.DeleteUserHandler;


namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

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
            var query = new GetUserByIdRequest { Id = id };
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserRequest req)
        {
            var response = await mediator.Send(req.ToQuery());
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUsers(CreateUserRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUsers(UpdateUserRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUsers(DeleteUserRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


    }
}

