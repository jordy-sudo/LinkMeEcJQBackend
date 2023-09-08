using LinkMeEcJQ.Domain;
using MongoDB.Driver;

namespace LinkMeEcJQ.Infrastructure.Persistence
{
    public class ApplicationDbContext : IMongoDB
    {
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
    }
}
