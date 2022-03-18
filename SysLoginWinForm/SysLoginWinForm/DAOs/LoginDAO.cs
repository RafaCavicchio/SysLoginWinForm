using System.Data.SqlClient;

namespace SysLoginWinForm.DAOs
{
    public class LoginDAO
    {
        public bool tem = false;
        public string mensagem = string.Empty;
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dataReader;

        public bool verificarLogin(string login, string senha)
        {
            cmd.CommandText = @"select * from Usuarios where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = con.Conectar();
                dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                    tem = true;
                con.Desconectar();
                dataReader.Close();
            }
            catch (SqlException)
            {

                this.mensagem = "Erro ao verificar usuário no banco de dados";
            }
            return tem;
        }

        public string Cadastrar(string email, string senha, string confirmacaoSenha)
        {
            tem = false;
            if (senha.Equals(confirmacaoSenha))
            {
                cmd.CommandText = "INSERT INTO Usuarios VALUES(@email, @senha)";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);

                try
                {
                    cmd.Connection = con.Conectar();
                    cmd.ExecuteNonQuery();
                    con.Desconectar();
                    tem = true;
                    this.mensagem = "Usuário cadastrado com sucesso!";

                }
                catch (SqlException)
                {

                    this.mensagem = "Erro ao tentar criar o usuário no banco de dados, entre em contato com o responsável pelo sistema.";
                }
            }
            else
            {
                this.mensagem = "A senha e a confirmação de senha devem ser iguais, tente novamente!";
            }            
            return mensagem;
        }
    }
}
