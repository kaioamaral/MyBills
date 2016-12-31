using domain.Model.Contracts.Enumerators;
using netFramework.Providers;
using System.Data;
using System.Data.SqlClient;

namespace dataAccess.Factories
{
    public static class ConnectionFactory
    {
        public static IDbConnection Create(ConnectionStrings connectionString)
        {
            var con = new SqlConnection(ConfigurationProvider
                   .GetConnectionString(connectionString));
            con.Open();
            return con;
        }
    }
}
