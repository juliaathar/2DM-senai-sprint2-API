using System.Data.SqlClient;
using webapi.FIlmes.Domains;
using webapi.FIlmes.Interfaces;

namespace webapi.FIlmes.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        // autenticacao atraves do sqlserver:
        private string stringConexao = "Data Source = NOTE15-S14; Initial Catalog = FilmesJúlia; User Id = sa; Pwd = Senai@134";
        // autenticacao atraves do windows: Integrated Security = true
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// metodo para listar todos os objetos generos
        /// </summary>
        /// <returns></returns>
        public List<GeneroDomain> ListarTodos()
        {
            // cria uma lista de objetos do tipo genero 
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();


            // declara a sqlconnection passando a string de conexao como parametro 
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a instrucao a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //abre a conexao com o banco de dados
                con.Open();

                //declara o sqldatareader para percorrer a tabela do banco de dados 
                SqlDataReader rdr;

                //declara o sqlcommand passando a query a ser executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            //atribui a propriedade Nome o valor recebido no rdr
                            Nome = rdr["Nome"].ToString()
                        };

                        listaGeneros.Add(genero);
                    }
                }
            }
        }     
    }
}



