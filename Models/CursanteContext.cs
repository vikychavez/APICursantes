using Microsoft.EntityFrameworkCore;

namespace APICursantes.Models
{
    public class CursanteContext:DbContext
    {
        public CursanteContext(DbContextOptions<CursanteContext> options) : base(options) { }
        public DbSet<Cursante> Cursantes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Cursante>()
                .Property(p => p.NroCursante)
                .ValueGeneratedOnAdd();
            

        }
    }
}
