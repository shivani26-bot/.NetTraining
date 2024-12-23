using SagaOrchestratorAPI.Models;

namespace SagaOrchestratorAPI.Interfaces
{
    public interface ISagaOrchestrator
    {
        public Task<bool> ProcessOrderSagaAsync(OrderDetailsDTO orderRequest);
    }
}
