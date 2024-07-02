using Microsoft.EntityFrameworkCore;
using ServicioRestCore.Models;
using System.Collections.Generic;

namespace ServicioRestCore
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }


        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Producto> producto { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    //para que no se repitan los nombre de distrito
        //    modelBuilder.Entity<Categoria>().HasIndex(c => c.nomcat).IsUnique();
        //    modelBuilder.Entity<Producto>().HasIndex(p => p.nompro).IsUnique();
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //definiendo la relacion de uno a muchos entre categori y producto
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.categoria)
                .WithMany(c => c.producto)
                .HasForeignKey(p => p.codcat);
        }
    }
}