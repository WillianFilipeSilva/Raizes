using Raizes.Entity;
using Raizes.Response;
using Raizes.Response.Usuario;

namespace Raizes.Contracts.Services
{
    public interface IUsuarioService
    {
        //Get
        Task<UsuarioGetAllResponse> GetAll();

        Task<UsuarioEntity> GetById(int Id);

        //Post
        Task<MessageResponse> Insert(UsuarioEntity usuario);

        //Put
        Task<MessageResponse> Update(UsuarioEntity usuario);

        //Delete
        Task<MessageResponse> Delete(int Id);
    }
}
