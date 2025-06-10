using Raizes.Entity;
using Raizes.Response.ResponseBase;

namespace Raizes.Response.Usuario
{
    public class UsuarioGetAllResponse : ResponseBase<UsuarioEntity>
    {
        public UsuarioGetAllResponse(IEnumerable<UsuarioEntity> data) : base(data) { }
    }
}
