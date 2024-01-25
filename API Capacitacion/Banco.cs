using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_Capacitacion
{
    public class Banco
    {
        
        [Key]
        public string Nombre { get; set; }
        public int NumeroProveedor { get; set; }
        public int NumeroContrato { get; set; }
    
}
}