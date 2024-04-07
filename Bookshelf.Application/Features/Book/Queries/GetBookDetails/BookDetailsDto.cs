using Bookshelf.Application.Features.Author.Queries.GetAllAuthors;
using Bookshelf.Application.Features.Publisher.Queries.GetAllPublishers;

namespace Bookshelf.Application.Features.Book.Queries.GetBookDetails;

public class BookDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public ICollection<AuthorDto>? Authors { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int PagesCount { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public PublisherDto? Publisher { get; set; } = null;
    public float Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;

}
