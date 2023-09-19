
using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;

namespace my_books.Data
{
    //c# sınıfları ve sql db arasındaki köprü sınıf
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        //c# modelleri için tablo isimlerini belirle.

        public DbSet<Book> Books { get; set; } // "Books" kullanarak db get set edebileceğiz. Dbset Book türünde olacağı için. tek bu kod yeterli.

    }
}
