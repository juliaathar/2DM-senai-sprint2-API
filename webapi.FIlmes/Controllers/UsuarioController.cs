using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        public IActionResult Login(UsuarioDomain usuarioLogin)
        {
            try
            {
                UsuarioDomain usuario = _usuarioRepository.Login(usuarioLogin.Email, usuarioLogin.Senha) ;

                if (usuario == null)
                {
                    return NotFound("Email ou senha inválidos");
                }

                // caso encontre o usuario, prossegue para a criacao do token

                //1 - definir as informacoes(claims) que serao fornecidos no token (payload)

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Permissao), 

                    //existe a possibilidade de criar uma claim personalizada
                    new Claim("ClaimPersonalizada", "Valor da Claim Personalizada")
                };

                //2 - definir a chave de acesso ao token

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                // 3 - definir as credenciais do token (header)

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4 - gerar o token

                var token = new JwtSecurityToken
                    (
                       //emissor do token
                       issuer: "webapi.FIlmes",

                       //destinatario do token
                       audience: "webapi.FIlmes",

                       //dados definidos nas claims(informacoes)
                       claims: claims,

                       //tempo de expiracao do token
                       expires: DateTime.Now.AddMinutes(5),

                       //credencias do token
                       signingCredentials: creds

                    );

                //5- retornar o token criado
                return Ok(new{

                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
