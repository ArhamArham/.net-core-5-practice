using Dot_net_5_practice.Data.Services;
using Dot_net_5_practice.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dot_net_5_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public IActionResult Index()
        {
            var books = _bookService.Index();
            return Ok(books);
        }

        [HttpGet("get-book-by-id/{id:int}")]
        public IActionResult Show(int id)
        {
            var book = _bookService.Show(id);
            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpPost("create-book")]
        public IActionResult Create([FromBody] BookVM book)
        {
            _bookService.Create(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id:int}")]
        public IActionResult Update(int id, [FromBody] BookVM book)
        {
            var updatedBook = _bookService.Update(id, book);
            if (updatedBook != null)
            {
                return Ok(updatedBook);
            }

            return NotFound();
        }

        [HttpDelete("delete-book-by-id/{id:int}")]
        public IActionResult Delete(int id)
        {
            if (_bookService.Show(id) == null) return NotFound();
            _bookService.Delete(id);
            return Ok();
        }
    }
}