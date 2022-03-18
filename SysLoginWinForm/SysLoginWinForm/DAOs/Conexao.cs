using System.Data.SqlClient;

namespace SysLoginWinForm.DAOs
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();

        public Conexao()
        {
            con.ConnectionString = @"Data Source=SZNNB374\CAVICCHIO;Initial Catalog=SysLogin;User ID=sa;Password=@Ulfr0493R$;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
