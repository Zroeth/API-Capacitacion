using System;
using System.ComponentModel.DataAnnotations;

namespace API_Capacitacion
{
    public class Log
    {
        [Key]
        public int IdLog { get; set; }
        public string Clase { get; set; }
        public string Metodo { get; set; }
        public string DescripcionError { get; set; }
        public DateTime Fecha { get; set; }
    }
}
