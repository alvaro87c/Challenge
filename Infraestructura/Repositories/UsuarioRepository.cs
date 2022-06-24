

using CORE.Entidades;
using CORE.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ParkingContext context) : base(context)
    {
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Usuarios
                            .Include(u => u.Roles)
                            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
    }
}
