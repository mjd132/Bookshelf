namespace Bookshelf.Application.Features.Book.Queries.GetAllBook;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    //public ICollection<Author> Authors { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public float Price { get; set; }

}


