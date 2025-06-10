using Raizes.Entity;

namespace Raizes.Response.Usuario
{
    public class UsuarioGetAllResponse
    {
        public IEnumerable<UsuarioEntity> Data { get; set; }

        public UsuarioGetAllResponse(IEnumerable<UsuarioEntity> data)
        {
            Data = data;
        }
    }
}
