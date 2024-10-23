using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM.Models
{
   public class ComprasModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o mome do fornecedor")]
        public string Nome_fornecedor { get; set; }
        
        [Required(ErrorMessage = "Digite o produto comprado")]
        public string Produto_comprado { get; set; }
        
        [Required(ErrorMessage = "Digite a quantidade comprada")]
        [RegularExpression(@"^\d+$", ErrorMessage = "A quantidade comprada deve conter apenas números")]
        public string Qtd_comprada { get; set; }

        [Required(ErrorMessage = "Digite o valor total")]
        public decimal Valor_total { get; set; }
    }
}
