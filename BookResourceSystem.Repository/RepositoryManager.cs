using BookResourceSystem.Contracts.Repository;
using System.Runtime.Intrinsics.X86;

namespace BookResourceSystem.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IAuthorRepository> _authorRepository;
    private readonly Lazy<IPublishingHouseRepository> _publishingHouseRepository;
    private readonly Lazy<IBookLanguageRepository> _bookLanguageRepository;
    private readonly Lazy<IBookRepository> _bookRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_repositoryContext));
        _publishingHouseRepository = new Lazy<IPublishingHouseRepository>(() => new PublishingHouseRepository(_repositoryContext));
        _bookLanguageRepository = new Lazy<IBookLanguageRepository>(() => new BookLanguageRepository(_repositoryContext));
        _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_repositoryContext));

    }
    public IAuthorRepository Author => _authorRepository.Value;

    public IPublishingHouseRepository PublishingHouse => _publishingHouseRepository.Value;

    public IBookLanguageRepository BookLanguage => _bookLanguageRepository.Value;

    public IBookRepository Book => _bookRepository.Value;

    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }
}
