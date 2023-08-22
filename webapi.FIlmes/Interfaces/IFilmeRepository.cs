using webapi.FIlmes.Domains;
using webapi.FIlmes.Repositories;

namespace webapi.FIlmes.Interfaces
{
    public interface IFilmeRepository
    {
        /// <summary>
        /// Método para cadastrar filmes
        /// </summary>
        /// <param name="novoFilme"></param>
        void Cadastrar(FilmeDomain novoFilme);

        List<FilmeDomain> ListarTodos();

        void AtualizarIdCorpo(FilmeDomain filme);
        void AtualizarIdUrl(int id, FilmeDomain filme);
        void Deletar(int id);
        FilmeDomain BuscarPorId(int id);


    }
}
