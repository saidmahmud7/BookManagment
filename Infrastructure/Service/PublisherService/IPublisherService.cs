using Domain.DTO_s.PublisherDto;
using Domain.Entities;
using Infrastructure.Response;

namespace Infrastructure.Service.PublisherService;

public interface IPublisherService
{
    Task<ApiResponse<List<GetPublisherDto>>> GetAll();
    Task<ApiResponse<Publisher>> GetById(int id);
    Task<ApiResponse<string>> Create(CreatePublisherDto publisher);
    Task<ApiResponse<string>> Update(UpdatePublisherDto publisher);
    Task<ApiResponse<string>> Delete(int id);
}