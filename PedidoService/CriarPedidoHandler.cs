using Messages;

namespace PedidoService
{
    public class CriarPedidoHandler : IHandleMessages<CriarPedido>
    {
        public Task Handle(CriarPedido message, IMessageHandlerContext context)
        {
            Console.WriteLine($"Pedido id {message.PedidoId} recebido Produto: {message.Produto}, Valor: {message.Valor}");
            return context.Publish(new PedidoCriado
            {
                PedidoId = message.PedidoId,
                Produto = message.Produto
            });
        }
    }

}
