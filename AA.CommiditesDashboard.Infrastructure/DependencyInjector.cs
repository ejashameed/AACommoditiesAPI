using AA.CommiditesDashboard.Infrastructure.ReadRepositories;
using AA.CommiditesDashboard.Infrastructure.ReadRepositories.Helpers;
using AA.CommiditesDashboard.Infrastructure.Repositories;
using AA.CommoditiesDashboard.Application.Interfaces.ReadRepositories;
using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommiditesDashboard.Infrastructure
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<DashboardDbContext>();            
            services.AddScoped<ICommodityDataRepository, CommodityDataRespository> ();
            services.AddScoped<ICommodityRepository, CommodityRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<SqlHelper>();
            services.AddScoped<IReadDataRepository, ReadDataRepository>();
            return services;
        }
    }
}
