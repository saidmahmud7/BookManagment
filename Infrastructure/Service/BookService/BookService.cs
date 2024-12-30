using System.Net;
using Domain.DTO_s.BookDto;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.BookService;

public class BookService(DataContext context) :IBookService
{
    public async Task<ApiResponse<List<GetBookDto>>> GetAll()
    {
        var books = await context.Books.ToListAsync();
        var bookDto = books.Select(b => new GetBookDto()
        {
            Title = b.Title,
            PublicationDate = b.PublicationDate,
            Genre = b.Genre,
            Pages = b.Pages,
            Language = b.Language,
            AuthorId = b.AuthorId,
            PublisherId = b.PublisherId
        }).ToList();
        return new ApiResponse<List<GetBookDto>>(bookDto);
    }

    public async Task<ApiResponse<Book>> GetById(int id)
    {
        var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
        return book == null
            ? new ApiResponse<Book>(HttpStatusCode.NotFound, "Book not found")
            : new ApiResponse<Book>(book);
    }

    public async Task<ApiResponse<string>> Create(CreateBookDto book)
    {
        var books = new Book()
        {
            Title = book.Title,
            PublicationDate = book.PublicationDate,
            Genre = book.Genre,
            Pages = book.Pages,
            Language = book.Language,
            AuthorId = book.AuthorId,
            PublisherId = book.PublisherId
        };
        await context.Books.AddAsync(books);
        var res = await context.SaveChangesAsync();
        return res  == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Book not created")
            : new ApiResponse<string>("Book created successfully");
    }

    public async Task<ApiResponse<string>> Update(UpdateBookDto book)
    {
        var exisingBook = await context.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
        if (exisingBook == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Book Not Found");
        }

        exisingBook.Title = book.Title;
        exisingBook.PublicationDate = book.PublicationDate;
        exisingBook.Genre = book.Genre;
        exisingBook.Pages = book.Pages;
        exisingBook.Language = book.Language;
        exisingBook.AuthorId = book.AuthorId;
        exisingBook.PublisherId = book.PublisherId;

        var res = await context.SaveChangesAsync();
        
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Book not updated")
            : new ApiResponse<string>("Book updated successfully");
    }

    public async Task<ApiResponse<string>> Delete(int id)
    {
        
        var exisingBook = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (exisingBook == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Book Not Found");
        }

        context.Remove(exisingBook);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Book not deleted")
            : new ApiResponse<string>("Book deleted successfully");
    }
}