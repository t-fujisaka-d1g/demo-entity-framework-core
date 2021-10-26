using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace app
{
    class MyContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Qr> Qrs => Set<Qr>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=DemoEntityFrameworkCore;uid=SA;pwd=Pass1234;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Qr>()
                .HasOne(qr => qr.Book)
                .WithMany(book => book.Qrs)
                .HasForeignKey(qr => qr.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime? ReleasedAt { get; set; }

        // ナビゲーションプロパティ（Navigation Property）
        private ICollection<Qr>? _qrs;
        public ICollection<Qr> Qrs
        {
            set => _qrs = value;
            get => _qrs ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Qrs));
        }
    }

    class Qr
    {
        [Key]
        public string Code { get; set; } = "";
        public int BookId { get; set; }
        public string Url { get; set; } = "";

        // ナビゲーションプロパティ（Navigation Property）
        private Book? _book;
        public Book Book
        {
            set => _book = value;
            get => _book ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Book));
        }
    }

}
