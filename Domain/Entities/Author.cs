using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Author
{
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Nationality { get; set; }
    
    public List<Book> Books { get; set; }
}