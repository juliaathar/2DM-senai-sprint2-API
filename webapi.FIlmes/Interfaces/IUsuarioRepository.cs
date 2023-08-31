using webapi.FIlmes.Domains;

namespace webapi.FIlmes.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login (string Email, string Senha);
    }
}
