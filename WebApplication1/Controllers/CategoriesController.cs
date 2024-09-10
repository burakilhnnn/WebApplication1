using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Application.Features.Categories.Command.CreateCategory.CreateCategoryHandler;
using static Application.Features.Categories.Command.DeleteCategory.DeleteCategoryHandler;
using static Application.Features.Categories.Queries.GetAllCategories.GetAllCategoryHandler;
using static Application.Features.Categories.Queries.GetCategoryByIdHandler;
using static Application.Features.Categorys.Command.UpdateCategory.UpdateCategoryHandler;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController] 



    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriesById([FromRoute] int id)
        {
            var query = new GetCategoryByIdRequest { Id = id };
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorys([FromQuery] GetAllCategoryRequest req)
        {
            var response = await mediator.Send(req.ToQuery());
            return Ok(response);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateCategorys(CreateCategoryRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateCategorys(UpdateCategoryRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategorys(DeleteCategoryRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
