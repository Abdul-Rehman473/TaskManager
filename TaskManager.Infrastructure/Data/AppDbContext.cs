//using Microsoft.EntityFrameworkCore;
//using TaskManager.Core.Entities;
//using Microsoft.EntityFrameworkCore.SqlServer;

//namespace TaskManager.Infrastructure.Data
//{
//    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
//    {
//        public DbSet<ToDoTask> NewTasks { get; set; }   
//    }
//}



using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;


namespace TaskManager.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ToDoTask> NewTasks { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoTask>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Description)
                    .HasMaxLength(500); 
            });
        }
    }
}