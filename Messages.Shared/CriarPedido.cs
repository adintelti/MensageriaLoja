namespace Messages
{
    public class CriarPedido : ICommand
    {
        public Guid PedidoId { get; set; } = Guid.NewGuid();
        public string Produto { get; set; }
        public decimal Valor { get; set; }
    }

}
