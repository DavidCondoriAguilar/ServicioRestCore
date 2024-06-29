using Microsoft.EntityFrameworkCore;
using ServicioRestCore.Models;

namespace ServicioRestCore
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.codcat);
                entity.Property(e => e.nomcat)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.escat)
                    .IsRequired();
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.codpro);
                entity.Property(e => e.nompro)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.despro)
                    .IsRequired()
                    .HasMaxLength(500);
                entity.Property(e => e.prepro)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
                entity.Property(e => e.canpro)
                    .IsRequired();
                entity.Property(e => e.estpro)
                    .IsRequired();
                entity.HasOne(d => d.categoria)
                    .WithMany(p => p.producto)
                    .HasForeignKey(d => d.codcat);
            });
        }
    }
}
