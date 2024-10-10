using BookResourceSystem.Contracts.Repository;
using BookResourceSystem.Entities.Models;

namespace BookResourceSystem.Repository;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
