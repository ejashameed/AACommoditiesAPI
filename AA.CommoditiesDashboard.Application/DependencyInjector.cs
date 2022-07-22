using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard;

namespace AA.CommoditiesDashboard.Application
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<GetCumulativePnLRequestHandler>();
            services.AddScoped<GetKeyActionsRequestHandler>();
            services.AddScoped<GetYearlyPnLRequestHandler>();
            services.AddScoped<GetYtdPriceTrendsRequestHandler>();
            services.AddScoped<GetAllModelsRequestHandler>();
            services.AddScoped<GetAllCommoditesRequestHandler>();
            return services;
        }
    }
}
