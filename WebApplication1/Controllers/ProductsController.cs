using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Application.Features.Products.Command.CreateProduct.CreateProductHandler;
using static Application.Features.Products.Command.DeleteProduct.DeleteProductHandler;
using static Application.Features.Products.Command.UpdateProduct.UpdateProductHandler;
using static Application.Features.Products.Queries.GetAllProducts.GetAllProductHandler.Handler;
using static Application.Features.Products.Queries.GetProductById.GetProductByIdHandler;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsById([FromRoute] int id)
        {
            var query = new GetProductByIdRequest { Id = id };
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductRequest req)
        {
            var response = await mediator.Send(req.ToQuery());
            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateProducts(CreateProductRequest request)
        {
             await mediator.Send(request);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateProducts(UpdateProductRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProducts(DeleteProductRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }



    }
}
