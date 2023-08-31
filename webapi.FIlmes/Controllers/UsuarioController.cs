using Microsoft.AspNetCore.Mvc;
using webapi.FIlmes.Domains;
using webapi.FIlmes.Interfaces;
using webapi.FIlmes.Repositories;

namespace webapi.FIlmes.Controllers
{
    [Route("api/[controller]")]

    //define que é um controlador de api
    [ApiController]

    //define que o tipo de resposta da api será no formato json
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Senha)
        {
            try
            {
                UsuarioDomain usuario = _usuarioRepository.Login(Email, Senha) ;

                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
