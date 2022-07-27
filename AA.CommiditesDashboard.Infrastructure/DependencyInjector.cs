using AA.CommiditesDashboard.Infrastructure.ReadRepositories;
using AA.CommiditesDashboard.Infrastructure.ReadRepositories.Dashboard;
using AA.CommiditesDashboard.Infrastructure.Repositories;
using AA.CommiditesDashboard.Infrastructure.Shared.Helpers;
using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces;
using AA.CommoditiesDashboard.Application.Shared.Interfaces;
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
            services.AddScoped<IGetCommodityWithModelRepository, GetCommodityWithModelRepository> ();
            services.AddScoped<IGetPriceTrendDataRepository, GetPriceTrendDataRepository>();
            services.AddScoped<IGetCumulativePnlDataRepository, GetCumulativePnlDataRepository>();
            services.AddScoped<IGetKeyactionsDataRepository, GetKeyactionsDataRepository>();
            services.AddScoped<IGetYearlyPnlDataRepository, GetYearlyPnlDataRepository>();
            return services;
        }
    }
}
