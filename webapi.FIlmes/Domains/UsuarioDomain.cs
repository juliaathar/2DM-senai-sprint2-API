using System.ComponentModel.DataAnnotations;

namespace webapi.FIlmes.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }

        public string Permissao { get; set; }
    }
}
