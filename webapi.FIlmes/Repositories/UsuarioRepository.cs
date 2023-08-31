using System.Data.SqlClient;
using webapi.FIlmes.Domains;
using webapi.FIlmes.Interfaces;

namespace webapi.FIlmes.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source = NOTE15-S14; Initial Catalog = FilmesJúlia; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection (stringConexao))
            {
                string querySearch = "SELECT IdUsuario, Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand (querySearch, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    con.Open ();

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Permissao = rdr["Permissao"].ToString()
                        };

                        return usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
