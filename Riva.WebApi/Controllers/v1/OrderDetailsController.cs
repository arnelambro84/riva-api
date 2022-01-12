using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Riva.Application.DTOs.OrderDetails;
using Riva.Application.Features.OrderDetails.Commands;
using Riva.Application.Features.OrderDetails.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riva.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/order-details")]
    public class OrderDetailsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetOrderDetailsAsync([FromQuery] int orderId)
        {
            var result = await Mediator.Send(new GetOrderDetailsQuery(orderId));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetailsAsync([FromBody] CreateOrderDetailsDto model)
        {
            var result = await Mediator.Send(new CreateOrderDetailsCommand(model));

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetailsAsync([FromBody] UpdateOrderDetailsDto model)
        {
            var result = await Mediator.Send(new UpdateOrderDetailsCommand(model));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetailsAsync([FromRoute] int id)
        {
            var result = await Mediator.Send(new DeleteOrderDetailsCommand(id));

            return Ok(result);
        }
    }
}
