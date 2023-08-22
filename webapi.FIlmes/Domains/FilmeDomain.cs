using System.ComponentModel.DataAnnotations;

namespace webapi.FIlmes.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "O título do filme é obrigatório!")]
        public string Titulo { get; set; }

        public int IdGenero { get; set; }

        // referência para classe Genero
        public GeneroDomain? Genero { get; set; }

    }
}
