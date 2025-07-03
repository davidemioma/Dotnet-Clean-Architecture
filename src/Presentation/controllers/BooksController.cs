using Application.Dtos;
using Application.UseCaseInterface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> GetBooks() {
            return Ok(await bookService.GetBooksAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id) {
            var book = await bookService.GetBookByIdAsync(id);

            if(book == null) {
                return NotFound(new {message = "Book not found"});
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto createBookDto) {
            var book = await bookService.CreateBookAsync(new CreateBookDto {
                Id = Guid.NewGuid(),
                Title = createBookDto.Title,
                Author = createBookDto.Author,
                YearPublished = createBookDto.YearPublished
            });

            return CreatedAtAction(nameof(GetBookById), new Book { Id = book.Id}, book);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookDto updateBookDto) {
            if (id != updateBookDto.Id)
            {
                return NotFound(new {message = "Book not found"});
            }

            var book = await bookService.UpdateBookAsync(updateBookDto);

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {

            var hasDeleted = await bookService.DeleteBookAsync(id);

            if(!hasDeleted) {
                return NotFound(new {message = "Book not found"});
            }

            return Ok(new {message = "Book was deleted"});
        }
    }
}