using Domain.DTO_s.AuthorDto;
using Domain.Entities;
using Domain.Filtres;
using Infrastructure.Response;
using Infrastructure.Service.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;


[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService service)
{
   [HttpGet]
   public async Task<ApiResponse<List<GetAuthorDto>>> GetAll([FromQuery]AuthorFilter filter) => await service.GetAll(filter);

   [HttpGet("{id}")]
   public async Task<ApiResponse<Author>> GetById(int id) => await service.GetById(id);
   
   [HttpPost]
   public async Task<ApiResponse<string>> Create(CreateAuthorDto authorDto) => await service.Create(authorDto);

   [HttpPut]
   public async Task<ApiResponse<string>> Update(UpdateAuthorDto authorDto) => await service.Update(authorDto);

   [HttpDelete]
   public async Task<ApiResponse<string>> Delete(int id) => await service.Delete(id);
}