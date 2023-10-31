using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Datos.Config
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Descripcion).HasMaxLength(60);
            builder.Property(p => p.Precio).IsRequired();
        }
    }
}