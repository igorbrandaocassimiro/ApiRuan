using System.ComponentModel.DataAnnotations;

namespace projetoPessoa.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

         

    }
}
