using Domain.Entities;

namespace Domain.RepositoryInterface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book?> GetBookByIdAsync(Guid id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book?> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(Guid id);
    }
}