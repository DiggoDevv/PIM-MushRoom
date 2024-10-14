using System.ComponentModel.DataAnnotations;

namespace PIM.Models
{
   public class FornecedorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o mome do fornecedor")]
        public string Nome_fornecedor { get; set; }
        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome_produto { get; set; }
        [Required(ErrorMessage = "Digite CNPJ")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Digite o telefone")]
        [Phone(ErrorMessage = "O numero informado não é válido")]
        public string Telefone { get; set; }

    }
}
