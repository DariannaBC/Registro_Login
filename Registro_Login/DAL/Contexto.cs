using Microsoft.EntityFrameworkCore;
using Registro_Login.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Login.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data/datosUsuarios.Db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Permisos>().HasData(
                new Permisos() { PermisosId = 1, Nombre = "Descuento", DescripcionPermisos = "Con este permiso es posible modificar el precio" },
                new Permisos() { PermisosId = 2, Nombre = "Vende", DescripcionPermisos = "Con este permiso es posible vender" },
                new Permisos() { PermisosId = 3, Nombre = "Compra", DescripcionPermisos = "Con este permiso es posible comprar" }
            );

            modelBuilder.Entity<Roles>().HasData(
                new Roles() { RolID = 1, DescripcionRol = "Con este permiso es posible modificar el precio" }
            );
        }
    }
}
