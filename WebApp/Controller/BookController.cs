using Domain.DTO_s.BookDto;
using Domain.Entities;
using Infrastructure.Response;
using Infrastructure.Service.BookService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;


[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService service)
{
    [HttpGet]
    public async Task<ApiResponse<List<GetBookDto>>> GetAll() => await service.GetAll();

    [HttpGet("{id}")]
    public async Task<ApiResponse<Book>> GetById(int id) => await service.GetById(id);

    [HttpPost]
    public async Task<ApiResponse<string>> Create(CreateBookDto book) => await service.Create(book);

    [HttpPut]
    public async Task<ApiResponse<string>> Update(UpdateBookDto book) => await service.Update(book);

    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await service.Delete(id);
}