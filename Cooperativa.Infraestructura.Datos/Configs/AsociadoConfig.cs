using System;
using System.Collections.Generic;
using System.Text;

using Cooperativa.Dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cooperativa.Infraestructura.Datos.Configs
{
    class AsociadoConfig : IEntityTypeConfiguration<Asociado>
    {
        public void Configure(EntityTypeBuilder<Asociado> builder)
        {
            builder.ToTable("tblAsociados");
            builder.HasKey(asociado => asociado.Id);
        }
    }
}
