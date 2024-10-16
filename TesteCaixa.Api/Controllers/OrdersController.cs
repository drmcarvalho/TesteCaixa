using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TesteCaixa.Api.Auth;
using TesteCaixa.Api.Dtos.Payload;
using TesteCaixa.Api.Dtos.Response;
using TesteCaixa.Api.ServiceDomain;

namespace TesteCaixa.Api.Controllers
{
    [Route("api/v1/orders")]
    [ApiController]
    [Tags("Processamento de pedidos")]
    public class OrdersController : ControllerBase
    {        
        [HttpPost]
        [AuthApiKey]
        [SwaggerOperation(Summary = "Processa os produtos de cada pedido separando por caixa de acordo com as dimensões de cada produto")]
        [ProducesResponseType<OrdersCalculatedDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ProcessOrder([FromServices] IBoxCalculateDimensionService boxService, [FromBody] CalcDimensionForOrdersDto ordersDto)
        {
            if (ordersDto.Orders.Count == 0)
            {
                return BadRequest(new {Message = "Informe pelo menos um pedido"});
            }
            var response = boxService.FitCalc(ordersDto);
            return Ok(response);
        }
    }
}
