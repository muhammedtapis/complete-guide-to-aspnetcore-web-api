using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //startup.cs dosyasında service ekledikten sonra servisi buraya inject edebiliriz.
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        //ilk endpointi oluşturacağız 
        //HTTP POST API endpoint olacak çünkü database veri gönderiyoruz.
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

    }
}
