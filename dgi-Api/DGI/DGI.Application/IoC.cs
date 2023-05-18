using DGI.Application.Features.Taxpayers.Services;
using DGI.Application.Features.TaxReceipt.Services;
using DGI.Application.Interfaces.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DGI.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            services.AddTransient<ITaxpayerService, TaxpayerService>();
            services.AddTransient<ITaxReceiptService, TaxReceiptService>();
            return services;
        }
    }
}
