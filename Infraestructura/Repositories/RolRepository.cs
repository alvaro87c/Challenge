

using CORE.Entidades;
using CORE.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories;

public class RolRepository : GenericRepository<Rol>, IRolRepository
{
    public RolRepository(ParkingContext context) : base(context)
    {
    }
}
