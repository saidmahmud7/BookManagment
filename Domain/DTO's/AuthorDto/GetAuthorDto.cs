using Domain.DTO_s.BookDto;
using Domain.Entities;

namespace Domain.DTO_s.AuthorDto;

public class GetAuthorDto
{
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Nationality { get; set; }
    public List<GetBookDto> Books { get; set; }
}