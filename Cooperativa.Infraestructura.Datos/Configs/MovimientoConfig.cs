using System;
using System.Collections.Generic;
using System.Text;

using Cooperativa.Dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cooperativa.Infraestructura.Datos.Configs
{
    class MovimientoConfig : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {
            builder.ToTable("tblMovimientos");
            builder.HasKey(movimiento => movimiento.Id);
        }
    }
}
