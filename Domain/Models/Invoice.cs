using System;

namespace Domain.Models
{
    public class Invoice : BaseModel
    {
        public DateTime Fecha { get; set; }
        public string Rnc { get; set; }
        public string Ncf { get; set; }
    }
}
