using PIM.Helper;
using System.ComponentModel.DataAnnotations;

namespace PIM.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Digite o login.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha.")]
        public string Senha { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }
    }
}
