using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Riva.Application.DTOs.Orders;
using Riva.Application.Features.Orders.Commands;
using Riva.Application.Features.Orders.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riva.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders")]
    public class OrdersController : BaseApiController
    {
        [HttpGet] // To Do: implement paging
        public async Task<IActionResult> GetOrdersAsync()
        {
            var result = await Mediator.Send(new GetOrdersQuery());

            return Ok(result);
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetOrdersReportAsync()
        {
            var result = await Mediator.Send(new GetOrdersReportQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDto model)
        {
            var result = await Mediator.Send(new CreateOrderCommand(model));

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderAsync([FromBody] UpdateOrderDto model)
        {
            var result = await Mediator.Send(new UpdateOrderCommand(model));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync([FromRoute] int id)
        {
            var result = await Mediator.Send(new DeleteOrderCommand(id));

            return Ok(result);
        }
    }
}
