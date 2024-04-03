using Bookshelf.Application.Features.Book.Queries.GetAllBook;

namespace Bookshelf.Application.Features.Publisher.Queries.GetPublisherDetails;

public class PublisherDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? WebsiteUrl { get; set; }
    public ICollection<BookDto>? Books { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }
    public string? CreatedBy { get; set; }
}
