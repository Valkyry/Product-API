using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace SampleProject.Infrastructure
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        protected DapperContext(IConfiguration configuration)
        {
            _configuration= configuration;
            _connectionString = _configuration.GetConnectionString("DBConnection");

        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString); 
    }
}
