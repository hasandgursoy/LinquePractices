using LinquePractices.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinquePractices.DbOperations
{
    public class LinqueDbContext :DbContext
    {
        public DbSet<Student> Students{get;set;}


        // BookStore da inmemory database'i programcs içerisnde yapmıştık şimdi DB'nin içinde yaptık.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseInMemoryDatabase(databaseName:"LinqDatabase");
        }
    }
}