using SysLoginWinForm.DAOs;

namespace SysLoginWinForm.Controllers
{
    public class LoginController
    {
        public bool tem;
        public string mensagem = string.Empty;

        public bool Acessar(string login, string senha)
        {
            LoginDAO loginDao = new LoginDAO();
            tem = loginDao.verificarLogin(login, senha);
            if (!loginDao.mensagem.Equals(string.Empty))
            {
                this.mensagem = loginDao.mensagem;
            }
            return tem;
        }

        public string Cadastrar(string email, string senha, string confirmacaoSenha)
        {
            LoginDAO loginDao = new LoginDAO();
            this.mensagem = loginDao.Cadastrar(email, senha, confirmacaoSenha);

            if (loginDao.tem)
            {
                this.tem = true;
            }
            return mensagem;
        }
    }
}
