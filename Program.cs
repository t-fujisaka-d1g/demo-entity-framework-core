using System;

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
