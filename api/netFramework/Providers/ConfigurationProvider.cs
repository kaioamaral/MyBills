using domain.Model.Contracts.Enumerators;
using System.Configuration;

namespace netFramework.Providers
{
    public static class ConfigurationProvider
    {
        public static string GetConnectionString(ConnectionStrings connectionString)
        {
            return ConfigurationManager.ConnectionStrings[connectionString.ToString()].ConnectionString;
        }
    }
}
