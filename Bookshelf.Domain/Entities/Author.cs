using Bookshelf.Domain.Entities.Common;

namespace Bookshelf.Domain.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Family { get; set; } = string.Empty;
    public ICollection<Book>? Books { get; set; }

}
