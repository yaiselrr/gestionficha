using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Datos.Config
{
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.Property(o => o.Id).IsRequired();
            builder.Property(o => o.Fecha).IsRequired();
            builder.Property(o => o.Direccion).IsRequired().HasMaxLength(500);
            builder.Property(o => o.Cantidad).IsRequired();
            builder.Property(o => o.EsGESTOR).HasDefaultValue(false);

            builder.HasOne(p => p.Producto).WithMany().HasForeignKey(o => o.ProductoId);
        }
    }
}