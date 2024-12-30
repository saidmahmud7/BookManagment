using Domain.DTO_s.BookDto;
using Domain.Entities;
using Infrastructure.Response;

namespace Infrastructure.Service.BookService;

public interface IBookService
{
    Task<ApiResponse<List<GetBookDto>>> GetAll();
    Task<ApiResponse<Book>> GetById(int id);
    Task<ApiResponse<string>> Create(CreateBookDto book);
    Task<ApiResponse<string>> Update(UpdateBookDto book);
    Task<ApiResponse<string>> Delete(int id);
}