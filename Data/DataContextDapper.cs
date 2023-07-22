using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DotnetAPI
{
    class DataContextDapper
    {
        private readonly IConfiguration _config;

        //constructor
        public DataContextDapper(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefalultConnection"));

            return dbConnection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefalultConnection"));

            return dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefalultConnection"));

            return dbConnection.Execute(sql) > 0;
        }

        public int ExecuteSqlWithRowCount(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefalultConnection"));

            return dbConnection.Execute(sql);
        }
    }
}