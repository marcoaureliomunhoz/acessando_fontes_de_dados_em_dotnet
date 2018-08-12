using System.Data.SqlClient;

namespace WebApplication1.Infra.FontesDados.Dapper
{
    public class ContextoGeralDapper
    {
        string stringConexao = "";

        public ContextoGeralDapper(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public SqlConnection getNewConnection()
        {
            return new SqlConnection(stringConexao);
        }
    }
}
