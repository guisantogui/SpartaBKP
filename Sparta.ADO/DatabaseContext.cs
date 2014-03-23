using Sparta.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.ADO
{
    public class DatabaseContextADO : IDisposable
    {

        private readonly SqlConnection connection;

        public DatabaseContextADO()
        {
            connection = ConnectionFactory.Instance.GetConnection();
            connection.Open();
        }

        public DatabaseContextADO(string connectionString)
        {
            connection = ConnectionFactory.Instance.GetConnection(connectionString);
            connection.Open();
        }

        public void ExecuteSqlWrite(string sql)
        {
            var cmdCommando = new SqlCommand
            {
                CommandText = sql,
                CommandType = CommandType.Text,
                Connection = connection
            };

            cmdCommando.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteSqlRead(string sql)
        {
            var command = new SqlCommand(sql, connection);
            return command.ExecuteReader();
        }

        public void Dispose()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
