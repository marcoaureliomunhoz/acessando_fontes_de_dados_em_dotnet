using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Biblio.DataApp.Dapper
{
    public class ContextoGeralDapper
    {
        string stringConexao = "";

        public ContextoGeralDapper()
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            this.stringConexao = config.GetConnectionString("ContextoGeral");
        }

        public SqlConnection getNewConnection()
        {
            return new SqlConnection(stringConexao);
        }
    }
}
