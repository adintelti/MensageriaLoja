namespace Messages
{
    public class PedidoEntregue : IEvent
    {
        public Guid PedidoId { get; set; } = Guid.NewGuid();
        public string Produto { get; set; }
    }

}
