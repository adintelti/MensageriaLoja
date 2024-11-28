using Messages;

namespace EntregaService
{
    public class ProcessarEntregaSaga : Saga<ProcessarEntregaData>,
        IAmStartedByMessages<PedidoPago>,
        IAmStartedByMessages<PedidoEntregue>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ProcessarEntregaData> mapper)
        {
            mapper.MapSaga(sagaData => sagaData.PedidoId)
                .ToMessage<PedidoPago>(message => message.PedidoId)
                .ToMessage<PedidoEntregue>(message => message.PedidoId);
        }

        public Task Handle(PedidoPago message, IMessageHandlerContext context)
        {
            Data.PedidoId = message.PedidoId;
            Data.Produto = message.Produto;
            Data.PedidoPago = true;
            Console.WriteLine($"Pagamento recebido {message.PedidoId} aguardando entrega do produto.");
            return FinalizarPedido(context);
        }

        public Task Handle(PedidoEntregue message, IMessageHandlerContext context)
        {
            Data.PedidoId = message.PedidoId;
            Data.Produto = message.Produto;
            Data.PedidoEntregue = true;
            Console.WriteLine($"Pedido {message.PedidoId} entregue.");
            return FinalizarPedido(context);
        }

        async Task FinalizarPedido(IMessageHandlerContext context)
        {
            if (Data.PedidoPago && Data.PedidoEntregue)
            {
                await context.SendLocal(new FinalizarPedido() { PedidoId = Data.PedidoId });
                MarkAsComplete();
            }
        }
    }

    public class ProcessarEntregaData : ContainSagaData
    {
        public Guid PedidoId { get; set; }
        public string Produto { get; set; }

        public bool PedidoPago { get; set; }
        public bool PedidoEntregue { get; set; }
    }

}
