using Bookshelf.Domain.Entities.Common;

namespace Bookshelf.Domain.Entities
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
        public ICollection<Book> Books { get; private set; }

    }
}
