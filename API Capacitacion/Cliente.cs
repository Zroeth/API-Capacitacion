using System;
using System.ComponentModel.DataAnnotations;

namespace API_Capacitacion
{
    public class Cliente
    {
        [Key]
        public int CodigoCliente { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public decimal MontoDeuda { get; set; }
        public string NIT { get; set; }
        public string ? Banco { get; set; } 
        public int? Contrato { get; set; } 


    }
}
