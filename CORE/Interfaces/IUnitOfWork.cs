

namespace CORE.Interfaces;

public interface IUnitOfWork
{   IClientesRepository Clientes { get; }
    IRolRepository Roles { get; }
    IUsuarioRepository Usuarios { get; }
    Task <int> Save();
}
