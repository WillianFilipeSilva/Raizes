using Microsoft.AspNetCore.Mvc;
using Raizes.Contracts.DTO;
using Raizes.Contracts.Services;
using Raizes.Entity;
using Raizes.Response;
using Raizes.Services;

namespace Raizes.Controllers
{
    [ApiController]
    [Route("api/[usuario]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController()
        {
            _usuarioService = new UsuarioService();
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioGetAllResponse>> GetUsuarios()
        {
            return await _usuarioService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioEntity?>> GetById(int id)
        {
            return await _usuarioService.GetById(id);
        }

        [HttpPost]
        public async Task Insert(UsuarioEntity usuario)
        {
            await _usuarioService.Insert(usuario);
        }

        [HttpPost]
        public async Task Update(UsuarioEntity usuario)
        {
            await _usuarioService.Insert(usuario);
        }

        [HttpPost]
        public async Task Delete(UsuarioEntity usuario)
        {
            await _usuarioService.Insert(usuario);
        }
    }
}
