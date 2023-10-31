using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Datos.Config
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Nombre).HasMaxLength(60);
            builder.Property(p => p.Apellidos).HasMaxLength(60);
            builder.Property(p => p.UsuarioRed).HasMaxLength(15);
            builder.Property(p => p.NInternoResp);
            builder.Property(p => p.IsAdmin).HasDefaultValue(true);
        }
    }
}