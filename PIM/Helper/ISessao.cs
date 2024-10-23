using PIM.Models;

namespace PIM.Helper
{
    public interface ISessao
    {
        void CriarSessaoLogin(LoginModel loginModel);
        void RemoverSessaoLogin();
        LoginModel BuscarSessaoLogin();
    }
}
