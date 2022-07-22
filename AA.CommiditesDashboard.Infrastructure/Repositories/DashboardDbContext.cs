using AA.CommoditiesDashboard.Application.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommiditesDashboard.Infrastructure.Repositories
{
    
    public class DashboardDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DashboardDbContext(IConfiguration configuration)
        {
            _configuration = configuration;            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builderOptions)
        {
            string connectionString = _configuration.GetConnectionString("SqlServer");
            builderOptions.UseSqlServer(connectionString);
            base.OnConfiguring(builderOptions);
        }

        public DbSet<Commodity> Commodity {get; set;}
        public DbSet<Model> Model { get; set; }
        public DbSet<CommodityData> CommodityData { get; set; }

    }
}
