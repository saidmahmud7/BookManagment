using Domain.DTO_s.PublisherDto;
using Domain.Entities;
using Infrastructure.Response;
using Infrastructure.Service.PublisherService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;



[ApiController]
[Route("api/[controller]")]
public class PublisherController(IPublisherService service)
{
    [HttpGet]
    public async Task<ApiResponse<List<GetPublisherDto>>> GetAll() => await service.GetAll();

    [HttpGet("{id}")]
    public async Task<ApiResponse<Publisher>> GetById(int id) => await service.GetById(id);

    [HttpPost]
    public async Task<ApiResponse<string>> Create(CreatePublisherDto publisher) => await service.Create(publisher);

    [HttpPut]
    public async Task<ApiResponse<string>> Update(UpdatePublisherDto publisher) => await service.Update(publisher);

    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await service.Delete(id);
}