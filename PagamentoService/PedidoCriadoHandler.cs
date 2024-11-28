using Messages;

namespace PagamentoService
{
    public class PedidoCriadoHandler : IHandleMessages<PedidoCriado>
    {
        public Task Handle(PedidoCriado message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Processando pagamento para o pedido {message.PedidoId}...");
            return context.Publish(new PedidoPago
            {
                PedidoId = message.PedidoId,
                Produto = message.Produto
            });
        }
    }
}
