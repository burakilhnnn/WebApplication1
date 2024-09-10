using Application.Features.Roles.Command.CreateRole;
/*using Application.Features.Roles.Command.DeleteRole;
using Application.Features.Roles.Command.UpdateRole;
using Application.Features.Roles.Queries.GetAllRoles;*/
using Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Roles.Command.DeleteRole;
using Application.Features.Orders.Queries.GetAllOrders;
using Microsoft.AspNetCore.Authorization;
using Application.Features.Categories.Queries;
using Application.Features.Roles.Queries.GetRoleById;
using static Application.Features.Roles.Queries.GetRoleById.GetRoleByIdHandler;
using static Application.Features.Roles.Queries.GetAllRoles.GetAllRoleHandler;
using static Application.Features.Roles.Command.CreateRole.CreateRoleHandler;
using static Application.Features.Roles.Command.UpdateRole.UpdateRoleHandler;
using static Application.Features.Roles.Command.DeleteRole.DeleteRoleHandler;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class RolesController : ControllerBase
    {
        private readonly IMediator mediator;

        public RolesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolesById([FromRoute] Guid id)
        {
            var query = new GetRoleByIdRequest { Id = id };
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllRoles([FromQuery] GetAllRoleRequest req)
        {
            var response = await mediator.Send(req.ToQuery());
            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRoles(CreateRoleRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateRoles(UpdateRoleRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRoles(DeleteRoleRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
