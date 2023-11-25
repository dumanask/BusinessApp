using Microsoft.AspNetCore.Mvc;
using Products.Application.Features.Products.Commands.Create;
using Products.Application.Features.Products.Commands.CreateList;
using Products.Application.Features.Products.Commands.Delete;
using Products.Application.Features.Products.Commands.DeleteList;
using Products.Application.Features.Products.Commands.Update;
using Products.Application.Features.Products.Commands.UpdateList;
using Products.Application.Features.Products.Queries.GetAllProducts;
using Products.Application.Features.Products.Queries.GetProductById;

namespace Products.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : BaseController
{
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProduct([FromHeader] GetAllProductsQuery getAllProductQuery)
        {
            var result = await Mediator.Send(getAllProductQuery);
            return Ok(result);
        }
        
        [HttpGet("GetById")]
        public async Task<IActionResult> GetProductByProductId([FromQuery] GetProductByProductIdQuery getProductByProductIdQuery)
        {
            var result = await Mediator.Send(getProductByProductIdQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductCommand command)
        {
            CreateProductResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("AddList")]
        public async Task<IActionResult> AddProductsList([FromBody] CreateProductsInListCommand command)
        {
            List<CreateProductsInListResponse> response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            UpdateProductResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("UpdateList")]
        public async Task<IActionResult> UpdateProductsList([FromBody] UpdateProductsInListCommand command)
        {
            List<UpdateProductsInListResponse> response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
        {
            DeleteProductResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("DeleteList")]
        public async Task<IActionResult> DeleteListOfProducts([FromBody] DeleteProductsInListCommand command)
        {
            List<DeleteProductsInListResponse> response = await Mediator.Send(command);
            return Ok(response);
        }
}