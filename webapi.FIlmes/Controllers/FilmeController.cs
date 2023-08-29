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
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// endpoint que aciona o metodo de cadastrar um filme
        /// </summary>
        /// <param name="novoFilme"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// endpoint que aciona o metodo de deletar um filme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return StatusCode (200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// endpoint que aciona um metodo de listar os filmes cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

               List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

                return Ok(listaFilmes);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
