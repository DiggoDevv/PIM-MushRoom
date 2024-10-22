using System.ComponentModel.DataAnnotations;

namespace PIM.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome_Produto { get; set; }
        [Required(ErrorMessage = "Digite a informação do produto")]
        public string Info_Produto { get; set; }

        [Required(ErrorMessage = "Digite a quantidade minima")]
        [RegularExpression(@"^\d+$", ErrorMessage = "A quantidade mínima deve conter apenas números.")]
        public string Quant_minima { get; set; }
        [Required(ErrorMessage = "Digite a quantidade em estoque")]
        [RegularExpression(@"^\d+$", ErrorMessage = "A quantidade em estoque deve conter apenas números.")]

        public string Quant_estoque { get; set; }
    }
}
