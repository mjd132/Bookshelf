using Bookshelf.Application.Features.Book.Queries.GetAllBook;

namespace Bookshelf.Application.Features.Author.Queries.GetAuthorDetail;

public class AuthorDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Family { get; set; } = string.Empty;
    public ICollection<BookDto>? Books { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;

}