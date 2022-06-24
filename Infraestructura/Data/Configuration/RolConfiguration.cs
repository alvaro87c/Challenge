using CORE.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration;

public class RolConfiguration
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Rol");
        builder.Property(p => p.Id)
                .IsRequired();
        builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(200);
    }
}
