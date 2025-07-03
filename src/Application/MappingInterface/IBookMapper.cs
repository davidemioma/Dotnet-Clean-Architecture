using Application.Dtos;
using Domain.Entities;

namespace Application.MappingInterface
{
    public interface IBookMapper
    {
        BookDto MapToDto(Book book);
        Book MapToEntity(CreateBookDto createBookDto);
        Book MapToEntity(UpdateBookDto updateBookDto);
    }
}