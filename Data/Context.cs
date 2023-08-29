using a_tarefas_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace a_tarefas_mvc.Data
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tarefas)
                .HasForeignKey(t => t.UsuarioId);
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}