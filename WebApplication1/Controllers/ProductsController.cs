using Application.Features.Categories.Queries;
using Application.Features.Products.Command.CreateProduct;
using Application.Features.Products.Command.DeleteProduct.Application.Features.Products.Command.DeleteProduct;
using Application.Features.Products.Command.UpdateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [Authorize(Roles = "Admin")]

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
            var query = new GetProductByIdQueryRequest { Id = id };
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryRequest req)
        {
            var response = await mediator.Send(req.ToQuery());
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProducts(CreateProductCommandRequest request)
        {
             await mediator.Send(request);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProducts(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProducts(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }



    }
}
