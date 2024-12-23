using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SagaOrchestratorAPI.Interfaces;
using SagaOrchestratorAPI.Models;

namespace SagaOrchestratorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISagaOrchestrator _sagaOrchestrator;

        public OrderController(ISagaOrchestrator sagaOrchestrator)
        {
            _sagaOrchestrator = sagaOrchestrator;
        }
        [HttpPost]
        public async Task<IActionResult> Post(OrderDetailsDTO orderDetails)
        {
            if (await _sagaOrchestrator.ProcessOrderSagaAsync(orderDetails))
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
