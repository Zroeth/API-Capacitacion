using Microsoft.EntityFrameworkCore;

namespace API_Capacitacion
{
    public class MiContexto : DbContext
    {
        public MiContexto(DbContextOptions<MiContexto> options) : base(options) { }

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
