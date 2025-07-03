using Application.Dtos;

namespace Application.UseCaseInterface
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto?> GetBookByIdAsync(Guid id);
        Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
        Task<BookDto?> UpdateBookAsync(UpdateBookDto updateBookDto);
        Task<bool> DeleteBookAsync(Guid id);
    }
}