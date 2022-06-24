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
    internal class ParkingConfiguration : IEntityTypeConfiguration<Parking>
    {
        public void Configure(EntityTypeBuilder<Parking> builder)
        {
            builder.ToTable("Parking");
            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.Ingreso)
                    .IsRequired();
            builder.Property(p => p.Salida)
                    .IsRequired();
            builder.Property(p=>p.Tarifa)
                   .HasColumnType("decimal(10,8)");
            builder.HasKey(p => p.AutoId);
        }
    }
}
