using System.Data.SqlClient;
using webapi.FIlmes.Domains;
using webapi.FIlmes.Interfaces;

namespace webapi.FIlmes.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source = NOTE15-S14; Initial Catalog = FilmesJúlia; User Id = sa; Pwd = Senai@134";
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
           using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT IdFilme, IdGenero, Titulo FROM Filme WHERE IdFilme = @IdFilme";
                string queryUpdateById = "UPDATE Filme SET IdFilme = @IdFilme, Titulo = @Titulo WHERE IdGenero = @IdGenero";

                using (SqlCommand cmdSearch = new SqlCommand(querySearchById, con))
                {
                    cmdSearch.Parameters.AddWithValue("@IdFilme", filme.IdFilme);

                    con.Open();

                    using (SqlDataReader rdr = cmdSearch.ExecuteReader())
                    {
                        if (rdr.Read())
                        {

                            rdr.Close(); // fecha o rdr antes de executar a alteracao de dados

                            using (SqlCommand cmdUpdate = new SqlCommand(queryUpdateById, con))
                            {
                                cmdUpdate.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                                cmdUpdate.Parameters.AddWithValue("@Titulo", filme.Titulo);

                                cmdUpdate.ExecuteNonQuery();
                            }
                        }
                    }
                }
               
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateByUrl = "UPDATE Filme SET IdFilme = @IdFilme, Titulo = @Titulo WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryUpdateByUrl, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            FilmeDomain filmeBuscado = new FilmeDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryGetById = "SELECT IdFilme, IdGenero, Titulo FROM Filme WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryGetById, con))
                {
                    cmd.Parameters.AddWithValue("IdGenero", id);

                    con.Open();

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        filmeBuscado = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                    }
                }
            }

            return filmeBuscado;
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Filme (IdGenero, Titulo) VALUES (@IdGenero, @Titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE Filme WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFilme, IdGenero, Titulo FROM Filme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            Titulo = rdr["Titulo"].ToString()
                        };

                        listaFilmes.Add(filme);
                    }
                }

                return listaFilmes;
            }
        }
    }
}
