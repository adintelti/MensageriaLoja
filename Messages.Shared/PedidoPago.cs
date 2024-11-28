namespace Messages
{
    public class PedidoPago : IEvent
    {
        public Guid PedidoId { get; set; } = Guid.NewGuid();
        public string Produto { get; set; }
    }

}
