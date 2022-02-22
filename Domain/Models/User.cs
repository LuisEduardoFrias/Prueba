namespace Domain.Models
{
    public class User : ErrorBase
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}
