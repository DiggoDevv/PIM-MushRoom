using PIM.Models;

namespace PIM.Repositorio
{
    public interface IloginRepositorio
    {
        LoginModel ListarPorId(int id);

        LoginModel BuscarPorLogin(string login);
        List<LoginModel> BuscarTodos();
        LoginModel Adicionar(LoginModel login);

        LoginModel Alterar(LoginModel login);

        bool Apagar(int id);
    }
}
