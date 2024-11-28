using Messages;

namespace EntregadorService
{
    public class PedidoPagoHandler : IHandleMessages<PedidoPago>
    {
        public Task Handle(PedidoPago message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Pedido {message.PedidoId} já foi pago, Entregando pedido...");
            return context.Publish(new PedidoEntregue
            {
                PedidoId = message.PedidoId,
                Produto = message.Produto
            });
        }
    }
}
