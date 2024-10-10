using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //Mediator
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            //AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // Adding fluent validation to IoC
        }
    }
}
