using Microsoft.AspNetCore.Mvc;
using Raizes.Contracts.Services;
using Raizes.Entity;
using Raizes.Response;
using Raizes.Response.Venda;
using Raizes.Services;

namespace Raizes.Controllers
{
    [ApiController]
    [Route("api/vendas/")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController()
        {
            _vendaService = new VendaService();
        }

        [HttpGet]
        public async Task<VendaGetAllResponse> GetVendas()
        {
            return await _vendaService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<VendaEntity> GetById(int id)
        {
            return await _vendaService.GetById(id);
        }

        [HttpPost]
        public async Task<MessageResponse> Insert(VendaEntity venda)
        {
            return await _vendaService.Insert(venda);
        }

        [HttpPut]
        public async Task<MessageResponse> Update(VendaEntity venda)
        {
            return await _vendaService.Update(venda);
        }

        [HttpDelete("{id}")]
        public async Task<MessageResponse> Delete(int id)
        {
            return await _vendaService.Delete(id);
        }
    }
}
