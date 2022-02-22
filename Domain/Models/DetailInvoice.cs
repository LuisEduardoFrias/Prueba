namespace Domain.Models
{
    public class DetailInvoice : ErrorBase
    {
        public int Id { get; set; }
        public Invoice FacturaId { get; set; }
        public Product ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
