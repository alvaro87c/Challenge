
using CORE.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration;

public class UserConfiguration
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");
        builder.Property(p => p.Id)
                .IsRequired();
        builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(200);
        builder.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(200);
        builder.Property(p => p.Username)
                .IsRequired()
                .HasMaxLength(200);
        builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(200);

        builder
        .HasMany(p => p.Roles)
        .WithMany(p => p.Usuarios)
        .UsingEntity<UsuarioRoles>(
            j => j
                .HasOne(pt => pt.Rol)
                .WithMany(t => t.UsuariosRoles)
                .HasForeignKey(pt => pt.RolId),
            j => j
                .HasOne(pt => pt.Usuario)
                .WithMany(p => p.UsuariosRoles)
                .HasForeignKey(pt => pt.UsuarioId),
            j =>
            {
                j.HasKey(t => new { t.UsuarioId, t.RolId });
            });

    }
}
