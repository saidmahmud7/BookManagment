using Domain.DTO_s.AuthorDto;
using Domain.DTO_s.PublisherDto;
using Domain.Entities;

namespace Domain.DTO_s.BookDto;

public class GetBookDto
{
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Genre { get; set; }
    public int Pages { get; set; }
    public string Language { get; set; }
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
    // public GetAuthorDto Author { get; set; }
    // public GetPublisherDto Publisher { get; set; }
}