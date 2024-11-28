using Messages;

namespace EntregaService
{
    public class ProcessarEntregaSaga : Saga<ProcessarEntregaData>,
        IAmStartedByMessages<PedidoPago>
    {
        public Task Handle(PedidoPago message, IMessageHandlerContext context)
        {
            Data.PedidoId = message.PedidoId;
            Data.Produto = message.Produto;
            Console.WriteLine($"Pagamento recebido {message.PedidoId} enviando produto.");
            return Task.CompletedTask;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ProcessarEntregaData> mapper)
        {
            mapper.ConfigureMapping<PedidoPago>(message => message.PedidoId)
                  .ToSaga(sagaData => sagaData.PedidoId);
        }
    }

    public class ProcessarEntregaData : ContainSagaData
    {
        public Guid PedidoId { get; set; }
        public string Produto { get; set; }
    }

}
