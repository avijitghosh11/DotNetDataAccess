using DotNetCore.OracleEntityFrameWork.API.Models;
using Microsoft.EntityFrameworkCore;


namespace DotNetCore.OracleEntityFrameWork.API.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Name = "Avijit Ghosh",
                    Gender = "Male",
                    IsGraduated = true,
                    Age = 34
                });
        }

        public DbSet<Student> Students { get; set; }
    }
}
