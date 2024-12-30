using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Book
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    [MaxLength(50)]
    public string Genre { get; set; }
    [Range(1, int.MaxValue)]
    public int Pages { get; set; }
    [MaxLength(50)]
    public string Language { get; set; }
    //foreign key
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    //foreign key
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }

}