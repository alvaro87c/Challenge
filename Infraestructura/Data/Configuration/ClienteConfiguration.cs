using CORE.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Cedula)
                .HasColumnType("int(10)");
        }
    }
}
