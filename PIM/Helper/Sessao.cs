using Newtonsoft.Json;
using PIM.Models;
using System.Reflection.Metadata;

namespace PIM.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _HttpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _HttpContext = httpContext;
        }
        public LoginModel BuscarSessaoLogin()
        {
            string sessaoUsuario = _HttpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<LoginModel>(sessaoUsuario);
        }

        public void CriarSessaoLogin(LoginModel loginModel)
        {
            string valor = JsonConvert.SerializeObject(loginModel);
            _HttpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoLogin()
        {
            _HttpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
