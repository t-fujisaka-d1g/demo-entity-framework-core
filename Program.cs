using System;
using System.Collections.Generic;
using System.Linq;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyContext())
            {
                try
                {
                    db.Database.BeginTransaction();

                    // 書籍テーブルに追加(Insert)
                    var book = new Book { Name = "書籍A", ReleasedAt = DateTime.Today };
                    db.Books.Add(book);
                    db.SaveChanges();

                    book.Qrs = new List<Qr> {
                        new Qr { Code = "00001", Url = "https://docs.microsoft.com/ja-jp/ef/" },
                        new Qr { Code = "00002", Url = "https://docs.microsoft.com/ja-jp/ef/core/" }
                    };
                    db.SaveChanges();

                    db.Database.CommitTransaction();
                    Console.WriteLine($"DB更新成功");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DB更新失敗");
                    Console.WriteLine($"(ex: {ex.Message})");
                    db.Database.RollbackTransaction();
                }

            }
        }
    }
}
