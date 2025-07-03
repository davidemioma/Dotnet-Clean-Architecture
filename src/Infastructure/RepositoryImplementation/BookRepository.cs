using data;
using Domain.Entities;
using Domain.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.RepositoryImplementation
{
    public class BookRepository(AppDbContext context) : IBookRepository
    {
        public async Task<Book> CreateBookAsync(Book book)
        {
            await context.Books.AddAsync(book);

            // Save to database
            await context.SaveChangesAsync();

            return book;
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            // Check if book exists
            var bookExists = await context.Books.FindAsync(id);

            if(bookExists == null) {
                return false;
            }

             // Delete book from database
            context.Books.Remove(bookExists);

            // Save changes to database
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            var book = await context.Books.FindAsync(id);

            if(book == null) {
                return null;
            }

            return book;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await context.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> UpdateBookAsync(Book book)
        {
            // Check if book exists
            var bookExists = await context.Books.FindAsync(book.Id);

            if(bookExists == null) {
                return null;
            }

            // Update book
            bookExists.Title = book.Title ?? bookExists.Title;
            bookExists.Author = book.Author ?? bookExists.Author;
            bookExists.YearPublished = book.YearPublished;

            // Save changes to database
            await context.SaveChangesAsync();

            return book;
        }
    }
}