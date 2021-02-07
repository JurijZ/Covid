using API.Interfaces;
using API.POCOs;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class RepositoryService : IRepositoryService
    {
        private IConfiguration configuration { get; }

        public RepositoryService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<TypedCase> GetDataPartition(int id, int pageSize)
        {
            using var connection = new SqlConnection(configuration.GetSection("CovidDB").Value);
            string sql = @"
                        SELECT TOP (@PageSize) *
                        FROM dbo.Cases
                        WHERE object_id >= @Id";

            var parameters = new { Id = id, PageSize = pageSize };
            return connection.Query<TypedCase>(sql, parameters);
        }

        public int GetDataSize()
        {
            using var connection = new SqlConnection(configuration.GetSection("CovidDB").Value);
            string sql = @"
                        SELECT COUNT(*)
                        FROM dbo.Cases";

            return connection.QuerySingle<int>(sql);
        }

        public int SaveNewCase(TypedCase newCase)
        {
            using var connection = new SqlConnection(configuration.GetSection("CovidDB").Value);
            string sql = @"
                        INSERT INTO dbo.Cases (X, Y)
                        OUTPUT Inserted.object_id
                        VALUES (@X, @Y)";
            var result = connection.ExecuteScalar(sql, newCase);

            int newId = -1;
            if (result != null)
            {
                newId = Convert.ToInt32(result);
            }

            return newId;
        }
    }
}
