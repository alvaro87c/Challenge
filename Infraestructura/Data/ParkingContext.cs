using Microsoft.EntityFrameworkCore;
using CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Infraestructura.Data;

public class ParkingContext : DbContext
{
    public ParkingContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Auto> Autos { get; set; }
    public DbSet<Parking> Parqueo { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}