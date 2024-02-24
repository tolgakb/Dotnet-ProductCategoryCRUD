using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.CreateCategory;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.DeleteCategory;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.UpdateCategory;
using ProductCategoryManagement.Application.Features.CategoryManagement.Queries.GetAllCategories;
using ProductCategoryManagement.Application.Features.CategoryManagement.Queries.GetCategoryById;
using ProductCategoryManagement.Application.Features.ProductManagement.Queries.GetAllProducts;
using ProductCategoryManagement.Application.Features.ProductManagement.Queries.GetProductById;

namespace ProductCategoryManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            //var query = new GetAllCategoriesQuery();

            //return Ok(await _mediator.Send(query));

            var categories = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(categories);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneCategory(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));

            return Ok(category);

            //var query = new GetCategoryByIdQuery(id);

            //return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            var category = await _mediator.Send(command);

            return Ok(category);

            //await _mediator.Send(new CreateCategoryCommand(command.CategoryName, command.CategoryDescription));

            //return StatusCode(201);

            //return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute(Name = "id")] Guid id)
        {
            //var command = new DeleteCategoryCommand(id);

            //return Ok(await _mediator.Send(command));

            var category = await _mediator.Send(new DeleteCategoryCommand(id));

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            //var product = await _mediator.Send(updateCategoryCommand);

            //return Ok(product);
            if(updateCategoryCommand is null)
            {
                return BadRequest();
            }

            updateCategoryCommand.Id = id;

            var category = await _mediator.Send(updateCategoryCommand);

            return Ok(category);
        }
    }
}
