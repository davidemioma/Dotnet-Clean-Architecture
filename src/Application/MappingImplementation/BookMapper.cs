using Application.Dtos;
using Application.MappingInterface;
using Domain.Entities;

namespace Application.MappingImplementation
{
    public class BookMapper : IBookMapper
    {
        public BookDto MapToDto(Book book)
        {
            return new BookDto {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                YearPublished = book.YearPublished
            };
        }

        public Book MapToEntity(CreateBookDto createBookDto)
        {
            return new Book {
                Id = createBookDto.Id,
                Title = createBookDto.Title,
                Author = createBookDto.Author,
                YearPublished = createBookDto.YearPublished
            };
        }

        public Book MapToEntity(UpdateBookDto updateBookDto)
        {
            return new Book {
                Id = updateBookDto.Id,
                Title = updateBookDto.Title,
                Author = updateBookDto.Author,
                YearPublished = updateBookDto.YearPublished
            };
        }
    }
}