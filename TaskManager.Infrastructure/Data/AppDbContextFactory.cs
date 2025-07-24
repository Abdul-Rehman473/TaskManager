//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskManager.Infrastructure.Data
//{
//    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
//    {
//        public AppDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=NewTaskManagerDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

//            return new AppDbContext(optionsBuilder.Options);
//        }
//    }
//}


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace TaskManager.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        
        private const string ConnectionString = "Server=.\\SQLEXPRESS;Database=NewTaskManagerDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}