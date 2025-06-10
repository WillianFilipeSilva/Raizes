using Raizes.Entity;
using Raizes.Response.ResponseBase;

namespace Raizes.Response.Venda
{
    public class VendaGetAllResponse : ResponseBase<VendaEntity>
    {
        public VendaGetAllResponse(IEnumerable<VendaEntity> data) : base(data) { }
    }
}
