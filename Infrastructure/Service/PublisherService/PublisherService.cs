using System.Net;
using Domain.DTO_s.BookDto;
using Domain.DTO_s.PublisherDto;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.PublisherService;

public class PublisherService(DataContext context) : IPublisherService
{
    public async Task<ApiResponse<List<GetPublisherDto>>> GetAll()
    {
        var publishers = context.Publishers
            .Include(b => b.Books)
            .ToList();
        var publisherDto = publishers.Select(p => new GetPublisherDto()
        {
            Name = p.Name,
            Address = p.Address,
            ContactEmail = p.ContactEmail,
            EstablishedYear = p.EstablishedYear,
            Website = p.Website,
            Books = p.Books.Select(b => new GetBookDto()
            {
                Title = b.Title,
                PublicationDate = b.PublicationDate,
                Genre = b.Genre,
                Pages = b.Pages,
                Language = b.Language,
            }).ToList()
        }).ToList();
        return new ApiResponse<List<GetPublisherDto>>(publisherDto);
    }

    public async Task<ApiResponse<Publisher>> GetById(int id)
    {
        var publisher = await context.Publishers.FirstOrDefaultAsync(p => p.Id == id);
        return publisher == null
            ? new ApiResponse<Publisher>(HttpStatusCode.NotFound, "Publisher not found")
            : new ApiResponse<Publisher>(publisher);
    }

    public async Task<ApiResponse<string>> Create(CreatePublisherDto publisher)
    {
        var publishers = new Publisher()
        {
            Name = publisher.Name,
            Address = publisher.Address,
            ContactEmail = publisher.ContactEmail,
            EstablishedYear = publisher.EstablishedYear,
            Website = publisher.Website
        };
        await context.Publishers.AddAsync(publishers);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Publisher not created")
            : new ApiResponse<string>("Publisher created successfully");
    }

    public async Task<ApiResponse<string>> Update(UpdatePublisherDto publisher)
    {
        var existingPublisher = await context.Publishers.FirstOrDefaultAsync(p => p.Id == publisher.Id);
        if (existingPublisher == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Publisher not Found");
        }

        existingPublisher.Name = publisher.Name;
        existingPublisher.Address = publisher.Address;
        existingPublisher.ContactEmail = publisher.ContactEmail;
        existingPublisher.EstablishedYear = publisher.EstablishedYear;
        existingPublisher.Website = publisher.Website;

        var res = await context.SaveChangesAsync();

        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Publisher not updated")
            : new ApiResponse<string>("Publisher updated successfully");
    }

    public async Task<ApiResponse<string>> Delete(int id)
    {
        var existingPublisher = context.Publishers.FirstOrDefaultAsync(p => p.Id == id);
        if (existingPublisher == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Publisher not Found");
        }

        context.Remove(existingPublisher);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Publisher not deleted")
            : new ApiResponse<string>("Publisher deleted successfully");
    }
}