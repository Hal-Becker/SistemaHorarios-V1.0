using Microsoft.EntityFrameworkCore;
using SistemaHorarios.Domain;

namespace SistemaHorarios.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Horario> Horarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Asignatura>()
                .HasIndex(a => a.Nombre)
                .IsUnique();

            modelBuilder.Entity<Docente>()
                .HasIndex(d => d.Nombre)
                .IsUnique();

            modelBuilder.Entity<Aula>()
                .HasIndex(a => a.Nombre)
                .IsUnique();

            modelBuilder.Entity<Grupo>()
                .HasIndex(g => g.Nombre)
                .IsUnique();
        }
    }
}