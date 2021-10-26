using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    [Table("X001BOOKS")]
    class Book
    {
        [Column("X001BOOKID")]
        public int Id { get; set; }

        [Column("X001BOOKNAME", TypeName = "nvarchar(128)")]
        public string Name { get; set; } = "";

        [Column("X001RELEASEAT")]
        public DateTime? ReleasedAt { get; set; }

        // ナビゲーションプロパティ（Navigation Property）
        private ICollection<Qr>? _qrs;
        public ICollection<Qr> Qrs
        {
            set => _qrs = value;
            get => _qrs ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Qrs));
        }
    }

    [Table("X002QRS")]
    class Qr
    {
        [Key, Column("X002QRCODE")]
        public string Code { get; set; } = "";

        [Column("X002BOOKID_X001BOOKS")]
        public int BookId { get; set; }

        [Column("X002URL")]
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
