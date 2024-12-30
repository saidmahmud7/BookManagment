using Domain.DTO_s.BookDto;
using Domain.Entities;

namespace Domain.DTO_s.PublisherDto;

public class GetPublisherDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactEmail { get; set; }
    public DateTime EstablishedYear { get; set; }
    public string Website { get; set; }
    public List<GetBookDto> Books { get; set; }
}