
using CORE.Interfaces;
using Infraestructura.Data;
using Infraestructura.Repositories;

namespace Infraestructura.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ParkingContext _context;
    private IClientesRepository _clientes;
    private IRolRepository _roles;
    private IUsuarioRepository _usuarios;

    public UnitOfWork(ParkingContext context)
    {
        _context = context;
    }

    public IClientesRepository Clientes
    {
        get
        {
            if (_clientes == null)
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }

    public IRolRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }


    public IUsuarioRepository Usuarios
    {
        get
        {
            if (_usuarios == null)
            {
                _usuarios = new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    public async Task <int> Save()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
