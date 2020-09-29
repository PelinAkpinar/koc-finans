using KocFinans.Public.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KocFinans.Data.CreditScore
{
    public class CreditScoreMongoDbRepository : ICreditScoreRepository
    {

        private IMongoCollection<UserCreditScore> _collection;
        public CreditScoreMongoDbRepository(string connectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            _collection = db.GetCollection<UserCreditScore>(collectionName);
        }
     

        public Task<List<UserCreditScore>> GetAllCreditScores()
        {
            var result =  _collection.Find(_ => true).ToListAsync();
            return result;
        }

        public Task<UserCreditScore> GetCreditScoreAsync(int identityNo)
        {

            var result = _collection.Find(x => x.IdentityNo == identityNo).SingleOrDefault();
            return Task.FromResult(result);
        }


    }
}
