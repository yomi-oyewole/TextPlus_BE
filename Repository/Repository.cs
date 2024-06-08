using MongoDB.Driver;
using TextPlus_BE.Setting;

namespace TextPlus_BE.Repository
{
    public abstract class Repository<Collection>
    {
        protected readonly IMongoCollection<Collection> _collection;
        protected readonly IMongoDatabase _database;
        private readonly MongoClient _client;
        public Repository(IDbSettings dbSettings, string collection)
        {
            _client = new MongoClient(dbSettings.ConnectionString);
            _database = _client.GetDatabase(dbSettings.DataBaseName);
            _collection = _database.GetCollection<Collection>(collection);
        }
    }
}
