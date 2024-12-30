namespace Domain.DTO_s.AuthorDto;

public class UpdateAuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Nationality { get; set; }
}