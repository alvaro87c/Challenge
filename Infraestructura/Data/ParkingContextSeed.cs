using CORE.Entidades;
using CsvHelper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data
{
    public class ParkingContextSeed
    {
        public static async Task SeedAsync(ParkingContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (!context.Clientes.Any())
                {
                    using (var readerClientes = new StreamReader(ruta + @"/Data/CSV/Clientes.csv"))
                    {
                        using (var csvClientes = new CsvReader(readerClientes, CultureInfo.InvariantCulture))
                        {
                            var clientes = csvClientes.GetRecords<Cliente>();
                            context.Clientes.AddRange(clientes);
                            await context.SaveChangesAsync();
                        }

                    }
                }

                if (!context.Autos.Any())
                {
                    using (var readerAutos= new StreamReader(ruta + @"/Data/CSV/Autos.csv"))
                    {
                        using (var csvAutos = new CsvReader(readerAutos, CultureInfo.InvariantCulture))
                        {
                            var autos = csvAutos.GetRecords<Auto>();
                            context.Autos.AddRange(autos);
                            await context.SaveChangesAsync();
                        }

                    }
                }

                if (!context.Parqueo.Any())
                {
                    using (var readerParqueo = new StreamReader(ruta + @"/Data/CSV/Parqueo.csv"))
                    {
                        using (var csvParqueo = new CsvReader(readerParqueo, CultureInfo.InvariantCulture))
                        {
                            var parqueo = csvParqueo.GetRecords<Parking>();
                            context.Parqueo.AddRange(parqueo);
                            await context.SaveChangesAsync();
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<ParkingContextSeed>();
                logger.LogError(ex.Message);
            }

        }

        public static async Task SeedRolesAsync(ParkingContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Roles.Any())
                {
                    var roles = new List<Rol>()
                        {
                            new Rol{Id=1, Nombre="Administrador"},
                            new Rol{Id=2, Nombre="Gerente"},
                            new Rol{Id=3, Nombre="Empleado"},
                        };
                    context.Roles.AddRange(roles);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ParkingContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
