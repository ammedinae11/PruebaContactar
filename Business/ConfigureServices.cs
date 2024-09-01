using Business.BLL;
using Business.Interfaces;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEstudiante, EstudianteBLL>();
            services.AddScoped<IMateria, MateriaBLL>();
            services.AddScoped<INota, NotaBLL>();
            services.AddScoped<IReporte, ReporteBLL>();
            services.AddScoped<IToken, TokenBLL>();
            services.AddDataServices(configuration);
            return services;
        }
    }
}
