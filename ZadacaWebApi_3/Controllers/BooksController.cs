using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using ZadacaWebApi_3.Data;
using ZadacaWebApi_3.Models;


namespace ZadacaWebApi_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("allBooks")]
        public ActionResult GetAllBooks()
        {
            return Ok(StaticDb.books);
        }

        [HttpGet("{index}")]

        public ActionResult<Book> GetBook(int index) 
        {
            if (index >= 0 && index < StaticDb.books.Count)
            {
                return StaticDb.books[index];
            }
            else
            {
                return NotFound("The book not found.");
            }
        }

        [HttpGet("searchBook")]
        public ActionResult<Book> SearchBook([FromQuery] string author,[FromQuery] string title) 
        {
            var book = StaticDb.books.FirstOrDefault(b => b.Author == author && b.Title == title);

            if(book == null)
            {
                return NotFound("The book not found.");
            }
            return Ok(book);
        }

        [HttpPost("addBook")]

        public ActionResult<Book> AddBook([FromBody] Book book) 
        {
            StaticDb.books.Add(book);
            return Ok(book);
        }

        [HttpPost("titles")]
        public ActionResult<IEnumerable<string>> GetBookTitles([FromBody] List<Book> newBooks) 
        {

            StaticDb.books.AddRange(newBooks);
            var addedTitles = newBooks.Select(b => b.Title).ToList();
            return Ok(addedTitles);
        }
    }
}
