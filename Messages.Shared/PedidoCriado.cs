namespace Messages
{
    public class PedidoCriado : IEvent
    {
        public Guid PedidoId { get; set; } = Guid.NewGuid();
        public string Produto { get; set; }
    }

}
