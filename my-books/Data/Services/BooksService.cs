using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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


     // aynı işi yapıyor aşağıdaki kodla   public List<Book> GetAllBooks() => _context.Books.ToList();
        public List <Book> GetAllBooks() {
        
            return _context.Books.ToList();

        }

        public Book GetBookById(int bookId) {

            return _context.Books.FirstOrDefault(n => n.Id == bookId); //FirstOrDefault methodundaki n.id bookId parametresine eşitledik.
        }

        public Book UpdateBookById(int bookId, BookVM book) { //BookVM olmasının sebebi sadece değişebeliceğimiz özellikleri
                                                               //değiştirmek istiyoruz id değiştiremeyiz mesela.             
             var _book = _context.Books.FirstOrDefault(n => n.Id == bookId); // id ye sahip olan kitap databasede var mı onu kontrol ettik.

            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;//book zaten okunmuş mu onu kontrol ettik önce eğer okunmamışsa null olcak.
                _book.Rate = book.IsRead ? book.Rate : null; //aynı şekilde puanlama yapabilmek için okunmuş olması gerek, eğer okunnmamışsa 0 verilcek.
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId); //bu kitap db de var mı yok mu onu dönüyor true ya da false.
            if( _book != null)
            {
                _context.Books.Remove( _book );
                _context.SaveChanges();
            }
        }
    }
}
