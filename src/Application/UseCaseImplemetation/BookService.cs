using Application.Dtos;
using Application.MappingInterface;
using Application.UseCaseInterface;
using Domain.RepositoryInterface;

namespace Application.UseCaseImplemetation
{
    public class BookService(IBookRepository bookRepository, IBookMapper bookMapper) : IBookService
    {
        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            var bookValues = bookMapper.MapToEntity(createBookDto);

            var newBook = await bookRepository.CreateBookAsync(bookValues);

            return bookMapper.MapToDto(newBook);
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
           var hasDeleted = await bookRepository.DeleteBookAsync(id);

           return hasDeleted;
        }

        public async Task<BookDto?> GetBookByIdAsync(Guid id)
        {
            var book = await bookRepository.GetBookByIdAsync(id);

            return book == null ? null : bookMapper.MapToDto(book);
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await bookRepository.GetBooksAsync();

            return books.Select(book => bookMapper.MapToDto(book)).ToList();
        }

        public async Task<BookDto?> UpdateBookAsync(UpdateBookDto updateBookDto)
        {
            var bookValues = bookMapper.MapToEntity(updateBookDto);

            var updatedBook = await bookRepository.UpdateBookAsync(bookValues);

            return updatedBook == null ? null : bookMapper.MapToDto(updatedBook);
        }
    }
}