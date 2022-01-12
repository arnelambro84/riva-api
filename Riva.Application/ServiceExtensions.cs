using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Riva.Application.Behaviours;
using Riva.Application.Helpers;
using Riva.Application.Interfaces;
using Riva.Domain.Entities;
using System.Reflection;

namespace Riva.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient<IMediator, Mediator>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IModelHelper, ModelHelper>();
        }
    }
}