
using AA.CommiditesDashboard.Infrastructure.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommiditesDashboard.Infrastructure.Shared.Helpers
{
    public class SqlHelper
    {
        private readonly DashboardDbContext _dbContext;

        public SqlHelper(DashboardDbContext dbContext)
        {
            _dbContext = dbContext;             
        }
        public async Task<List<T>> RawSqlQuery<T>(string query)
        {
            string connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.QueryAsync<T>(query);

                return result.ToList();
            }
        }

        public async Task<List<T>> RawSqlQuery<T>(string query, DynamicParameters parameters)
        {
            string connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.QueryAsync<T>(query,  parameters);

                return result.ToList();
            }
        }

    }
}
