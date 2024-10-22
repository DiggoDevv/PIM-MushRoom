using PIM.DBContext;
using PIM.Models;
using PIM.Repositorio.impl;

namespace PIM.Repositorio
{
    public class LoginRepositorio : IloginRepositorio
    {
        //context vai gravar no banco de dados
        private readonly BancoDBContext _bancoDBContext;
        public LoginRepositorio(BancoDBContext bancoDBContext) 
        {
            _bancoDBContext = bancoDBContext;            
        }
        public LoginModel ListarPorId(int id)
        {
            return _bancoDBContext.Login.FirstOrDefault(x => x.Id == id);
        }
        public LoginModel BuscarPorLogin(string login)
        {
            return _bancoDBContext.Login.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
        public List<LoginModel> BuscarTodos()
        {
            //to list carrega tudo que está no banco de dados(consulta)
            return _bancoDBContext.Login.ToList();
        }

        public LoginModel Alterar(LoginModel login)
        {
            LoginModel loginDB = ListarPorId(login.Id);

            if (loginDB == null) throw new System.Exception("Houve um erro na atualização do login");

            loginDB.Login = login.Login;
            loginDB.Senha = login.Senha;

            _bancoDBContext.Login.Update(loginDB);
            _bancoDBContext.SaveChanges();
            return loginDB;
        }

        // gravar no banco de dados
        public LoginModel Adicionar(LoginModel login)
        {
            _bancoDBContext.Login.Add(login);
            _bancoDBContext.SaveChanges();
            return login;
        }
        public bool Apagar(int id)
        {
            LoginModel loginDB = ListarPorId(id);

            if (loginDB == null) throw new System.Exception("Houve um erro na deleção do fornecedor");

            _bancoDBContext.Login.Remove(loginDB);
            _bancoDBContext.SaveChanges();
            return true;
        }
    }
}
