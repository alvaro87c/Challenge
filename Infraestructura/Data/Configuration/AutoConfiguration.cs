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
    public class AutoConfiguration : IEntityTypeConfiguration<Auto>
    {
        public void Configure(EntityTypeBuilder<Auto> builder)
        {
            builder.ToTable("Auto");
            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.Marca)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(p => p.Modelo)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(p => p.Placa)
                    .IsRequired()
                    .HasMaxLength(10);
            builder.HasKey(p => p.ClienteId);

        }
    }
}
