using Raizes.Entity;
using Raizes.Response;

namespace Raizes.Contracts.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioGetAllResponse> GetAll();

        Task<UsuarioEntity?> GetById(int Id);

        //Post
        Task Insert(UsuarioEntity usuario);

        //Antigos...
        Task Create();

        Task Read();

        Task Update();

        Task Delete();
    }
}
