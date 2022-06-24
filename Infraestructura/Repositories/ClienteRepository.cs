using CORE.Entidades;
using CORE.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories;

public class ClienteRepository : GenericRepository<Cliente>, IClientesRepository
{
    public ClienteRepository(ParkingContext context) : base(context)
    {
    }
}
