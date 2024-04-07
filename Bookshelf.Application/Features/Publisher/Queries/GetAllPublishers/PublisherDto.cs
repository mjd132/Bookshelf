namespace Bookshelf.Application.Features.Publisher.Queries.GetAllPublishers;

public class PublisherDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? WebsiteUrl { get; set; }
    
}
