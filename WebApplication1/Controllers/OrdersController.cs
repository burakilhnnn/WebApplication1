
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Application.Features.Orders.Command.CreateOrder.CreateOrderHandler;
using static Application.Features.Orders.Command.DeleteOrder.DeleteOrderHandler;
using static Application.Features.Orders.Command.UpdateOrder.UpdateOrderHandler;
using static Application.Features.Orders.Queries.GetAllOrders.GetAllOrderHandler.Handler;
using static Application.Features.Orders.Queries.GetOrderById.GetOrderByIdHandler;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

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
            var query = new GetOrderByIdRequest { Id = id };
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrderRequest req)
        {
            var response = await mediator.Send(req.ToQuery());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrders(CreateOrderRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrders(UpdateOrderRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteOrders(DeleteOrderRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
