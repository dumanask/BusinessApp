using Microsoft.AspNetCore.Mvc;
using Products.Application.Features.ProductCardTypes.Commands.Create;

namespace Products.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCardTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddProductCardType([FromBody] CreateProductCardTypeCommand command)
    {
        CreateProductCardTypeResponse response = await Mediator.Send(command);
        return Ok(response);
    }
}