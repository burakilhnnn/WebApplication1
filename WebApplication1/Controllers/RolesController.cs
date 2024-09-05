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

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
 //   [Authorize(Roles = "Admin")]

    public class RolesController : ControllerBase
    {
        private readonly IMediator mediator;

        public RolesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolesById([FromRoute] Guid id)
        {
            var query = new GetRoleByIdQueryRequest { Id = id };
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles([FromQuery] GetAllRolesQueryRequest req)
        {
            var response = await mediator.Send(req.ToQuery());
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRoles(CreateRoleCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateRoles(UpdateRoleCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteRoles(DeleteRoleCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
