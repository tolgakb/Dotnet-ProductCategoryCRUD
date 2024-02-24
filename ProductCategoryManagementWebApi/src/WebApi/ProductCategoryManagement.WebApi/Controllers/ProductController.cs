using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.CreateCategory;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.DeleteCategory;
using ProductCategoryManagement.Application.Features.CategoryManagement.Commands.UpdateCategory;
using ProductCategoryManagement.Application.Features.CategoryManagement.Queries.GetAllCategories;
using ProductCategoryManagement.Application.Features.CategoryManagement.Queries.GetCategoryById;
using ProductCategoryManagement.Application.Features.ProductManagement.Commands.CreateProduct;
using ProductCategoryManagement.Application.Features.ProductManagement.Commands.DeleteProduct;
using ProductCategoryManagement.Application.Features.ProductManagement.Commands.UpdateProduct;
using ProductCategoryManagement.Application.Features.ProductManagement.Queries.GetAllProducts;
using ProductCategoryManagement.Application.Features.ProductManagement.Queries.GetProductById;
using ProductCategoryManagement.Application.Features.ProductManagement.Queries.GetProductsByCategory;

namespace ProductCategoryManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());

            return Ok(products);

            //var query = new GetAllProductsQuery();

            //return Ok(await _mediator.Send(query));
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetOneProduct(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            return Ok(product);

            //var query = new GetProductByIdQuery(id);

            //return Ok(await _mediator.Send(query));
        }

        [HttpGet("category/{categoryName}")]

        public async Task<IActionResult> GetProductsByCategory(string categoryName)
        {
            var products = await _mediator.Send(new GetProductsByCategory(categoryName));

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            var product = await _mediator.Send(command);

            return Ok(product);

            //return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute(Name = "id")] Guid id)
        {

            var product = await _mediator.Send(new DeleteProductCommand(id));

            return Ok(product);

            //var command = new DeleteProductCommand(id);

            //return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand updateProductCommand)
        {
            if (updateProductCommand is null)
            {
                return BadRequest();
            }

            updateProductCommand.Id = id;

            var product = await _mediator.Send(updateProductCommand);

            return Ok(product);

            //return Ok(await _mediator.Send(updateProductCommand));
        }


    }
}
