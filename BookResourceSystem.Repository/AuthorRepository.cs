using BookResourceSystem.Contracts.Repository;
using BookResourceSystem.Entities.Models;

namespace BookResourceSystem.Repository;

public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
