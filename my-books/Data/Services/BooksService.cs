using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;

namespace my_books.Data.Services
{
    public class BooksService
    {
        //sadece bir method kullanacağız database e books eklemek için.
        //database e books eklemek için appdbcontext e referans alman gerekiyor.ÖNEMLİ!!
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
                
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,//book zaten okunmuş mu onu kontrol ettik önce eğer okunmamışsa null olcak.
                Rate = book.IsRead ? book.Rate : null, //aynı şekilde puanlama yapabilmek için okunmuş olması gerek, eğer okunnmamışsa 0 verilcek.
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now


            };
            _context.Books.Add(_book);//oluşturulan _book instance Books içine ekle.
            _context.SaveChanges(); //değişiklikleri kaydet.
        }

        //bu servisi kullanabilmek için startup.cs dosyasında konfigüre etmemiz gerek.
    }
}
