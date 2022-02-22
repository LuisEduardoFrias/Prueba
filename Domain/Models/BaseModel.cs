namespace Domain.Models
{
    public class BaseModel : ErrorBase
    {
        public int Id { get; set; }
        public User UsuarioId { get; set; }
        public string Ip { get; set; }
    }
}
