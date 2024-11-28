using Messages;

namespace EntregaService
{
    internal class FinalizarPedidoHandler : IHandleMessages<FinalizarPedido>
    {
        public Task Handle(FinalizarPedido message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Pedido {message.PedidoId} finalizado com sucesso.");
            return Task.CompletedTask;
        }
    }
}
