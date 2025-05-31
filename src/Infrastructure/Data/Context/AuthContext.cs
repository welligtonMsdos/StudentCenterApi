using MongoDB.Driver;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Infrastructure.Data.Context;

public class AuthContext
{
    private readonly IMongoDatabase _database;

    public AuthContext(IConfiguration configuration)
    {
        var connectionString = configuration["MongoDB:ConnectionString"];
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
    }

   public IMongoCollection<Dashboard> Dashboards => _database.GetCollection<Dashboard>("Dashboard");
}
