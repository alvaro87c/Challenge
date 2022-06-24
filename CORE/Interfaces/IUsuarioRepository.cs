

using CORE.Entidades;

namespace CORE.Interfaces;



    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> GetByUsernameAsync(string username);
    }


