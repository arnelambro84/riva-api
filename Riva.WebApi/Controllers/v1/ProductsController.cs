using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Riva.Application.DTOs.Products;
using Riva.Application.Features.Products.Commands;
using Riva.Application.Features.Products.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riva.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductsController : BaseApiController
    {
        
        [HttpGet] //To Do : implement search and paging
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await Mediator.Send(new GetProductsQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDto model)
        {
            var result = await Mediator.Send(new CreateProductCommand(model));

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductDto model)
        {
            var result = await Mediator.Send(new UpdateProductCommand(model));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
        {
            var result = await Mediator.Send(new DeleteProductCommand(id));

            return Ok(result);
        }
    }
}
