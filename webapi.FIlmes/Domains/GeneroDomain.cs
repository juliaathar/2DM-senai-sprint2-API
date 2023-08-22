using System.ComponentModel.DataAnnotations;

namespace webapi.FIlmes.Domains
{
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O nome do gênero é obrigatório!")]
        public string Nome { get; set; }

    }
}
