using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product_Api.Application.Commands;
using Product_Api.Application.Dtos;
using Product_Api.Application.Queries;

namespace Product_Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var command = new CreateProductCommand()
            {
                Category = dto.Category,
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };
            var product = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
    }
}
