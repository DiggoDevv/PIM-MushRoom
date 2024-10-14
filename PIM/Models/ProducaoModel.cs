using System.ComponentModel.DataAnnotations;

namespace PIM.Models
{
    public class ProducaoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome da produção")]
        public string Nome_producao { get; set; }
        [Required(ErrorMessage = "Digite a informação da produção")]
        public string Info_producao { get; set; }

        [DataType(DataType.Date)]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "O formato da data deve ser yyyy-MM-dd.")]
        public string Ini_producao { get; set; }
        [Required(ErrorMessage = "Digite a troca de substrato")]

        public string Troca_substrato { get; set; }
    }
}
