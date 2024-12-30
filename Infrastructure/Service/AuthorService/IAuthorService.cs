using Domain.DTO_s.AuthorDto;
using Domain.Entities;
using Domain.Filtres;
using Infrastructure.Response;

namespace Infrastructure.Service.AuthorService;

public interface IAuthorService
{
    Task<ApiResponse<List<GetAuthorDto>>> GetAll(AuthorFilter filter);
    Task<ApiResponse<Author>> GetById(int id);
    Task<ApiResponse<string>> Create(CreateAuthorDto author);
    Task<ApiResponse<string>> Update(UpdateAuthorDto author);
    Task<ApiResponse<string>> Delete(int id);
}