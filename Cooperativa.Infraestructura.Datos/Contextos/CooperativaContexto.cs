using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Cooperativa.Dominio.Modelo;
using Cooperativa.Infraestructura.Datos.Configs;

namespace Cooperativa.Infraestructura.Datos.Contextos
{
    public class CooperativaContexto: DbContext
    {
        public DbSet<Asociado> Asociados { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=tcp:serverappcooperativa.database.windows.net,1433;Initial Catalog=app-cooperativa;Persist Security Info=False;User ID=adminappcopperativa;Password=passAppCooperativa1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AsociadoConfig());
            builder.ApplyConfiguration(new MovimientoConfig());
            builder.ApplyConfiguration(new ProductoConfig());
        }
    }
}
