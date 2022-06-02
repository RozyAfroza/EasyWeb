using LearningProject.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace LearningProject
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<TestDbContext, TestDbContext>((options) =>
            {
               // var dbConnectionHandler = provider.GetService<IDbConnectionHandler>();
                options.UseSqlServer("DbConnection");
            }, ServiceLifetime.Transient);

            return services;
        }
    }
}
