using BookResourceSystem.Contracts.Repository;
using BookResourceSystem.Entities.Models;

namespace BookResourceSystem.Repository;

public class PublishingHouseRepository : RepositoryBase<PublishingHouse>, IPublishingHouseRepository
{
    public PublishingHouseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
