using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Factory
{
    public class ConnectionFactory
    {

        private static ConnectionFactory instance;

        public ConnectionFactory() { }

        public static ConnectionFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectionFactory();
                }
                return instance;
            }
        }

        public SqlConnection GetConnection()
        {
            return GetConnection(ConfigurationManager.ConnectionStrings["TCCConfig"].ConnectionString);
        }

        public SqlConnection GetConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
