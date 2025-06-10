using Raizes.Entity;
using Raizes.Response;
using Raizes.Response.Venda;

namespace Raizes.Contracts.Services
{
    public interface IVendaService
    {
        //Get
        Task<VendaGetAllResponse> GetAll();

        Task<VendaEntity> GetById(int Id);

        //Post
        Task<MessageResponse> Insert(VendaEntity venda);

        //Put
        Task<MessageResponse> Update(VendaEntity venda);

        //Delete
        Task<MessageResponse> Delete(int Id);
    }
}
