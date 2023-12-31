﻿using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// endpoint que aciona o método listarTodos do repositório e retorna a resposta para o usuário(front-end)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize (Roles = "Administrador, Comum")]
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

        /// <summary>
        /// endpoint que aciona o metodo de cadastro do genero 
        /// </summary>
        /// <param name="novoGenero">objeto recebido na requisicao</param>
        /// <returns>status code 201(created)</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(GeneroDomain novoGenero)
        {

            try
            {
                //fazendo a chamada para o metodo cadastrar passando o objeto como parametro 
                _generoRepository.Cadastrar(novoGenero);

                //retorna um status code 201(created)
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                //retorna status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// endpoint que aciona o método de deletar 
        /// </summary>
        /// <param name="id"> parâmetro passado para encontrar o que deseja deletar </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// endpoint que aciona o metodo de buscar por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult SearchById(int id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado != null)
                {
                    return Ok(generoBuscado);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// endpoint que aciona o metodo de atualizar dados por id no corpo
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdCorpo(genero);

                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// endpoint que aciona metodo de atualizar dados por id passando pela url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public IActionResult PutByUrl(int id, GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdUrl(id, genero);

                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    }
}
