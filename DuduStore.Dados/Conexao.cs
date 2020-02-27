using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuduStore.Dados
{
    public class Conexao
    {
        public static SqlConnection CriarConexao()
        {
            var connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=dudu_store;Integrated Security=True";
            return connection;
        }
    }
}
