using System;
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
                    db.Books.Add(new Book { Name = "書籍A" });
                    db.Books.Add(new Book { Name = "書籍B" });
                    db.Books.Add(new Book { Name = "書籍C" });
                    db.SaveChanges();

                    // 書籍テーブルのレコードを更新(Update)
                    // (書籍名を変更 書籍A-->書籍a)
                    {
                        if (db.Books.FirstOrDefault(b => b.Name == "書籍A") is Book book)
                        {
                            book.Name = "書籍a";
                            db.SaveChanges();
                        }
                    }

                    // 書籍テーブルのレコードを削除(Delete)
                    // (書籍Cを削除)
                    {

                        if (db.Books.FirstOrDefault(b => b.Name == "書籍C") is Book book)
                        {
                            db.Books.Remove(book);
                            db.SaveChanges();
                        }
                    }

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
