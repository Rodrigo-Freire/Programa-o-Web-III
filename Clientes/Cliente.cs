using Swashbuckle.AspNetCore.SwaggerGen;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Clientes
{
    public class Cliente
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome é obrigatório!")]
        [MaxLength(255)]
        public string nome { get; set; }
        public DateTime dataDeNascimento { get; set; }

        [Range(0, 20)]
        public int QuantidadeFilhos { get; set; }

        public int idade => DateTime.Now.AddYears(-dataDeNascimento.Year).Year;

    }
}
