using Raizes.Contracts.Repository;
using Raizes.Contracts.Services;
using Raizes.Entity;
using Raizes.Repository;
using Raizes.Response;
using Raizes.Response.Usuario;

namespace Raizes.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        //Get
        public async Task<UsuarioGetAllResponse> GetAll()
        {
            return new UsuarioGetAllResponse(await _usuarioRepository.GetAll());
        }

        public async Task<UsuarioEntity> GetById(int Id)
        {
            try
            {
                return await _usuarioRepository.GetById(Id);
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Nenhum Usuário foi encontrado");
            }
        }

        //Post
        public async Task<MessageResponse> Insert(UsuarioEntity usuario)
        {
            await _usuarioRepository.Insert(usuario);
            return new MessageResponse { Message = "Usuário cadastrado com sucesso" };
        }

        //Put
        public async Task<MessageResponse> Update(UsuarioEntity usuario)
        {
            await _usuarioRepository.Update(usuario);
            return new MessageResponse { Message = "Usuário atualizado com sucesso" };
        }

        //Delete
        public async Task<MessageResponse> Delete(int Id)
        {
            await _usuarioRepository.Delete(Id);
            return new MessageResponse { Message = "Usuário deletado com sucesso" };
        }
    }
}
