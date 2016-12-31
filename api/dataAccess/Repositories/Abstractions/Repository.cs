using Dapper;
using dataAccess.Factories;
using domain.Model.Contracts.Enumerators;
using System.Collections.Generic;
using System.Data;

namespace dataAccess.Repositories.Abstractions
{
    public class Repository
    {
        private ConnectionStrings connectionString;

        public Repository(ConnectionStrings connectionString)
        {
            this.connectionString = connectionString;
        }

        private IDbConnection OpenConnection(ConnectionStrings connectionString)
        {
            return ConnectionFactory.Create(connectionString);
        }
        
        protected IEnumerable<T> Query<T>(string sql)
        {
            using (var con = OpenConnection(this.connectionString))
                return con.Query<T>(sql);
        }

        protected IEnumerable<T> Query<T>(string sql, object parameters)
        {
            using (var con = OpenConnection(this.connectionString))
                return con.Query<T>(sql, parameters);
        }

        protected T QuerySingle<T>(string sql, object parameters)
        {
            using (var con = OpenConnection(this.connectionString))
                return con.QuerySingle<T>(sql, parameters);
        }

        protected void Execute(string sql, object parameters)
        {
            using (var con = OpenConnection(this.connectionString))
                con.Execute(sql, parameters);
        }
    }
}
