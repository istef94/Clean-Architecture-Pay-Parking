using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Utils;
using Domain.Interfaces;
using Domain.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        // For web api we can use this dependency injection configuration but for console application can't in this moment
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeCalculation, DateTimeCalculation>();
            services.AddTransient<IPriceCalculation, PriceCalculation>();

            return services;
        }
    }
}
