using Project.Domain.Models.Books;

namespace Project.Infrastructure.Data.Repositories;

public sealed class BooksRepository : Repository<Book>, IBooksRepository 
{
    public BooksRepository(ApplicationDbContext context) 
        : base(context)
    {
    }
}