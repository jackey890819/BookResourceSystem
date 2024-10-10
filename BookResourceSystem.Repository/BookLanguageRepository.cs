using BookResourceSystem.Contracts.Repository;
using BookResourceSystem.Entities.Models;

namespace BookResourceSystem.Repository;

public class BookLanguageRepository : RepositoryBase<BookLanguage>, IBookLanguageRepository
{
    public BookLanguageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
