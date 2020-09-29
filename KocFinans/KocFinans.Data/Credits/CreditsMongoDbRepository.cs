using KocFinans.Public.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KocFinans.Data.Credits
{
    public class CreditsMongoDbRepository : ICreditsRepository
    {
        private IMongoCollection<Credit> _collection;
        public CreditsMongoDbRepository(string connectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            _collection = db.GetCollection<Credit>(collectionName);
        }
        public Task<Credit> GetCreditById(string applicationId)
        {
           var credit= _collection.Find(x => x.Id == applicationId).SingleOrDefault();
            return Task.FromResult( credit);
        }

        public Task<List<Credit>> GetCreditsByIdendityNo(int identityNo)
        {
            var credits = _collection.Find(x => x.IdentityNo == identityNo).ToListAsync();
            return credits;
        }

        public Task<Credit> InsertCreditResult(Credit credit)
        {
            credit.Id = Guid.NewGuid().ToString();
             _collection.InsertOne(credit);
            return Task.FromResult(credit);

        }
    }
}
