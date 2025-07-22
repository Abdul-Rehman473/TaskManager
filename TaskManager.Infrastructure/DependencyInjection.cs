using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Core.Interfaces;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Repositories;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=.\\SQLEXPRESS;Database=NewTaskManagerDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
            });

            services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();

            return services;
        }
    }
}