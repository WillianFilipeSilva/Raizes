using Raizes.Entity;

namespace Raizes.Response
{
    public class UsuarioGetAllResponse
    {
        public UsuarioGetAllResponse(IEnumerable<UsuarioEntity> data)
        {
            Data = data;
        }

        public IEnumerable<UsuarioEntity> Data { get; set; }
    }
}
