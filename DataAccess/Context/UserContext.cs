using BackendStageTwo.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackendStageTwo.DataAccess.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)  : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder
            //.LogTo(Console.WriteLine, LogLevel.Information)
            //.EnableSensitiveDataLogging()
            //.EnableDetailedErrors();
        }
    }
}
