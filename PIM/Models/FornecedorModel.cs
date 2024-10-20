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
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$",
        ErrorMessage = "O formato do CNPJ deve ser XX.XXX.XXX/0001-XX.")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Digite o telefone")]
        [RegularExpression(@"^\(\d{2}\)\s9\d{4}-\d{4}$", ErrorMessage = "O formato do telefone celular deve ser (XX) 9XXXX-XXXX.")]
        public string Telefone { get; set; }

    }
}
