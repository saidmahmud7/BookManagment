using System.Net;
using Domain.DTO_s.AuthorDto;
using Domain.DTO_s.BookDto;
using Domain.Entities;
using Domain.Filtres;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.AuthorService;

public class AuthorService(DataContext context) : IAuthorService
{
    public async Task<ApiResponse<List<GetAuthorDto>>> GetAll(AuthorFilter filter)
    {
        var authors = context.Authors
            .Include(b => b.Books)
            .AsQueryable();
        if (filter.Name != null)
        {
            authors = authors.Where(a => a.Name.ToLower().Contains(filter.Name.ToLower()));
        }

        var authorDto = authors.Select(a => new GetAuthorDto()
        {
            Name = a.Name,
            Biography = a.Biography,
            DateOfBirth = a.DateOfBirth,
            Nationality = a.Nationality,
            Books = a.Books.Select(b => new GetBookDto()
            {
                Title = b.Title,
                PublicationDate = b.PublicationDate,
                Genre = b.Genre,
                Pages = b.Pages,
                Language = b.Language,
            }).ToList()
        }).ToList();

        return new ApiResponse<List<GetAuthorDto>>(authorDto);
    }

    public async Task<ApiResponse<Author>> GetById(int id)
    {
        var author = await context.Authors.FirstOrDefaultAsync(a => a.Id == id);
        return author == null
            ? new ApiResponse<Author>(HttpStatusCode.NotFound, "Author not found")
            : new ApiResponse<Author>(author);
    }

    public async Task<ApiResponse<string>> Create(CreateAuthorDto author)
    {
        var authors = new Author()
        {
            Name = author.Name,
            Biography = author.Biography,
            DateOfBirth = author.DateOfBirth,
            Nationality = author.Nationality
        };
        await context.Authors.AddAsync(authors);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Author not created")
            : new ApiResponse<string>("Author created successfully");
    }

    public async Task<ApiResponse<string>> Update(UpdateAuthorDto author)
    {
        var existingAuthor = await context.Authors.FirstOrDefaultAsync(a => a.Id == author.Id);

        if (existingAuthor == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Author not Found");
        }

        existingAuthor.Name = author.Name;
        existingAuthor.Biography = author.Biography;
        existingAuthor.DateOfBirth = author.DateOfBirth;
        existingAuthor.Nationality = author.Nationality;

        var res = await context.SaveChangesAsync();

        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Author not updated")
            : new ApiResponse<string>("Author updated successfully");
    }

    public async Task<ApiResponse<string>> Delete(int id)
    {
        var existingAuthor = await context.Authors.FirstOrDefaultAsync(a => a.Id == id);

        if (existingAuthor == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Author not Found");
        }

        context.Remove(existingAuthor);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Author not deleted")
            : new ApiResponse<string>("Author deleted successfully");
    }
}