using MongoDB.Driver;
using MrMoney.Util.Global;

namespace MrMoney.Infrastructure.Data
{
    public class MongoDbContext<T> where T: class
    {
        private IMongoDatabase _database { get; }

        public MongoDbContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(DbConnectionConfiguration.ConnectionString));
                if (DbConnectionConfiguration.IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DbConnectionConfiguration.DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<T> Collection { get { return _database.GetCollection<T>(typeof(T).Name); } }
    }
}
