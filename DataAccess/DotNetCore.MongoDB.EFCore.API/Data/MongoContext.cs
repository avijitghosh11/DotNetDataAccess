using DotNetCore.MongoDB.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace DotNetCore.MongoDB.EFCore.API.Data
{
    public class MongoContext : DbContext
    {
        public DbSet<Student> Students { get; init; }
        public DbSet<Teacher> Teachers { get; init; }
        public MongoContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToCollection("students");
            modelBuilder.Entity<Teacher>().ToCollection("teachers");
        }
    }
}
