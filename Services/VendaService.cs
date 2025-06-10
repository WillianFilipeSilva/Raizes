using Raizes.Contracts.Repository;
using Raizes.Contracts.Services;
using Raizes.Entity;
using Raizes.Repository;
using Raizes.Response;
using Raizes.Response.Venda;

namespace Raizes.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService()
        {
            _vendaRepository = new VendaRepository();
        }

        //Get
        public async Task<VendaGetAllResponse> GetAll()
        {
            return new VendaGetAllResponse(await _vendaRepository.GetAll());
        }

        public async Task<VendaEntity> GetById(int id)
        {
            try
            {
                return await _vendaRepository.GetById(id);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Nenhuma venda foi encontrada");
            }
        }

        //Post
        public async Task<MessageResponse> Insert(VendaEntity venda)
        {
            await _vendaRepository.Insert(venda);
            return new MessageResponse { Message = "Venda cadastrada com sucesso" };
        }

        //Put
        public async Task<MessageResponse> Update(VendaEntity venda)
        {
            await _vendaRepository.Update(venda);
            return new MessageResponse { Message = "Venda atualizada com sucesso" };
        }

        //Delete
        public async Task<MessageResponse> Delete(int id)
        {
            await _vendaRepository.Delete(id);
            return new MessageResponse { Message = "Venda deletada com sucesso" };
        }
    }
}
