using Application.Features.Categories.Queries;
using Application.Features.Categories.Queries.GetAllCategories;
using Application.Features.Orders.Command.CreateOrder;
using Application.Features.Orders.Command.DeleteOrder;
using Application.Features.Orders.Command.UpdateOrder;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Orders.Queries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
 //   [Authorize(Roles = "Admin")]


    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var query = new GetOrderByIdQueryRequest { Id = id };
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersQueryRequest req)
        {
            var response = await mediator.Send(req.ToQuery());
            return Ok(response);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrders(CreateOrderCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateOrders(UpdateOrderCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteOrders(DeleteOrderCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
