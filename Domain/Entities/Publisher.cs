using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Publisher
{
    public int Id { get; set; }
    [Required,MaxLength(200)]
    public string Name { get; set; }
    [MaxLength(300)]
    public string Address { get; set; }
    [EmailAddress]
    public string ContactEmail { get; set; }
    public DateTime EstablishedYear { get; set; }
    public string Website { get; set; }
    public List<Book> Books { get; set; }
}