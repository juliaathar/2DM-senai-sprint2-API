using webapi.FIlmes.Domains;

namespace webapi.FIlmes.Interfaces
{
    public interface IGeneroRepository
    {
        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero"> objeto que será cadastrado </param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns> lista de objetos cadastrados </returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atualiza um objeto existente passando seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero"> objeto a ser atualizado (novas informações) </param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um objeto existente passando seu id pela url da requisição
        /// </summary>
        /// <param name="id"> id do objeto que será atualizado </param>
        /// <param name="genero"> objeto a ser atualizado (novas informações) </param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Método para deletar um objeto existente passando seu id 
        /// </summary>
        /// <param name="id"> id do objeto a ser deletado </param>
        void Deletar(int id);

        /// <summary>
        /// Buscar objeto existente pelo id que está cadastrado
        /// </summary>
        /// <param name="id"> id do objeto a ser buscado </param>
        /// <returns></returns>
        GeneroDomain BuscarPorId(int id);
    }
}
