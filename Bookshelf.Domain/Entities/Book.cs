using Bookshelf.Domain.Entities.Common;

namespace Bookshelf.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? PublishedDate { get; set; }
    public ICollection<Author>? Authors { get; set; }
    public string? ImageUrl { get; set; }
    public int? PagesCount { get; set; }
    public string? ISBN { get; set; }
    public string? Language { get; set; }
    public int? PublisherId { get; set; }
    public Publisher? Publisher { get; set; }
    public float? Price { get; set; }


}
