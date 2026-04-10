using Microsoft.EntityFrameworkCore;

namespace APICursantes.Models
{
    
        public class PacienteContext : DbContext
        {
            public PacienteContext(DbContextOptions<PacienteContext> options) : base(options) { }
            public DbSet<Paciente> Pacientes { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                modelBuilder.Entity<Paciente>()
                    .Property(p => p.NroPaciente)
                    .ValueGeneratedOnAdd();


            }
        }
    }

