namespace Messages
{
    public class FinalizarPedido : ICommand
    {
        public Guid PedidoId { get; set; }
    }
}
