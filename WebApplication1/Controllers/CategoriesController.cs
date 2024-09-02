using Application.Features.Categories.Command.CreateCategory;
using Application.Features.Categories.Command.DeleteCategory;
using Application.Features.Categories.Command.UpdateCategory;
using Application.Features.Categories.Queries.GetAllCategories;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize(Roles = "Admin")]

    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCategorys([FromQuery] GetAllCategoriesQueryRequest req)
        {
            var response = await mediator.Send(req.ToQuery());
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategorys(CreateCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategorys(UpdateCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCategorys(DeleteCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
