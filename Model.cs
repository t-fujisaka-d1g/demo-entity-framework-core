using System;
using Microsoft.EntityFrameworkCore;

namespace app
{
    class MyContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=DemoEntityFrameworkCore;uid=SA;pwd=Pass1234;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime? ReleasedAt { get; set; }
    }

}
