using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace TaskManager.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ToDoTask> NewTasks { get; set; }   
    }
}
