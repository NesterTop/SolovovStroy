using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SolovovStroy
{
    public class DataBase : IDisposable
    {
        //Data Source=DESKTOP-AVGELME\STP;Initial Catalog=DataBase;Integrated Security=True
        string _connectionString = "Server=db.edu.cchgeu.ru;DataBase=193_Solovov;User=193_Solovov;Password=Qq123123";
        SqlConnection _connection;

        public DataBase()
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
        }

        public void OpenConnection()
        {
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public DataTable ExecuteSql(string sql)
        {
            DataTable dt = new DataTable();
            var reader = new SqlCommand(sql, _connection).ExecuteReader();
            dt.Load(reader);
            return dt;
        }

        public void ExecuteSqlNonQuery(string sql)
        {
            new SqlCommand(sql, _connection).ExecuteNonQuery();
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
