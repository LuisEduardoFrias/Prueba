namespace Domain.Models
{
    public class Product : BaseModel
    {
        public long CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Existencias { get; set; }
    }
}
