using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.FIlmes.Domains;
using webapi.FIlmes.Interfaces;
using webapi.FIlmes.Repositories;

namespace webapi.FIlmes.Controllers
{
    // define que a rota de uma requisição será no seguinte formato
    //dominio/api/controller
    //ex: hhtp://localhost:5000/api/genero
    [Route("api/[controller]")]

    //define que é um controlador de api
    [ApiController]

    //define que o tipo de resposta da api será no formato json
    [Produces("application/json")]

    //método controlador que herda da controller base
    //onde será criado os endpoints (rotas)
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// objeto _generoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        //instancia o objeto _generoRepository para que haja referência aos métodos no repositorio
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        //endpoint que aciona o método listarTodos do repositório e retorna a resposta para o usuário(front-end)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //cria uma lista que recebe os dados da requisição
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //retorna a lista no formato JSON com o status code OK(200)
                return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //retorna status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);    
            }

        }
    }
}
