using Application.Common.Interface;
using Application.Common.ServiceInterface;
using Infrastructure.DbServices.EventServices;
using Infrastructure.DbServices.ParticipantServices;
using Infrastructure.DbServices.UserServices;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ConfigurationSetting
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
           IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<InnoloftContext>(option =>
            option.UseNpgsql(configuration.GetConnectionString("dbContext")));

            services.AddScoped<IUserInterface, UserServices>();
            services.AddScoped<IEventService, EventServices>();
            services.AddScoped<IEventParticipant, EventParticipantService>();
            return services;
        }
    }
}
