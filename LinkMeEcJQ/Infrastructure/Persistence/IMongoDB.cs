using LinkMeEcJQ.Domain;
using MongoDB.Driver;

namespace LinkMeEcJQ.Infrastructure.Persistence
{
    public interface IMongoDB
    {
        IMongoCollection<Product> Products { get; }
    }
}
