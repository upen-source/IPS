using Data;
using Logic;
using Microsoft.Extensions.DependencyInjection;
using Presentation;

namespace IPS.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFileUpdater, JsonFileUpdater>();
            services.AddScoped<IPaymentsRepository, JsonPaymentsRepository>();
        }

        public static void AddLogicDependencies(this IServiceCollection services)
        {
            services.AddScoped<ModeratorPaymentService>();
        }

        public static void AddPresentationDependencies(this IServiceCollection services)
        {
            services.AddHostedService<ConsoleApp>();
        }
    }
}
