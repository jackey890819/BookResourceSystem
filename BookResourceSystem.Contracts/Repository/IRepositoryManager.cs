namespace BookResourceSystem.Contracts.Repository;

public interface IRepositoryManager
{
    Task SaveAsync();
    IAuthorRepository Author { get; }
    IPublishingHouseRepository PublishingHouse { get; }
    IBookLanguageRepository BookLanguage { get; }
    IBookRepository Book { get; }
}
