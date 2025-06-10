using Microsoft.AspNetCore.Mvc;
using Raizes.Contracts.Services;
using Raizes.Entity;
using Raizes.Response.Usuario;
using Raizes.Services;

namespace Raizes.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController()
        {
            _usuarioService = new UsuarioService();
        }

        [HttpGet]
        public async Task<UsuarioGetAllResponse> GetUsuarios()
        {
            return await _usuarioService.GetAll();
        }

        [HttpGet("/{id}")]
        public async Task<UsuarioEntity> GetById(int id)
        {
            return await _usuarioService.GetById(id);
        }

        [HttpPost]
        public async Task Insert(UsuarioEntity usuario)
        {
            await _usuarioService.Insert(usuario);
        }

        [HttpPut]
        public async Task Update(UsuarioEntity usuario)
        {
            await _usuarioService.Update(usuario);
        }

        [HttpDelete("/{id}")]
        public async Task Delete(int id)
        {
            await _usuarioService.Delete(id);
        }
    }
}
