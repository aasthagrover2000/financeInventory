using MongoDB.Driver;
using Microsoft.Extensions.Options;
using financeInventoryProject.Models;

namespace financeInventoryProject.Service
{
	public class FinanceService : IFinanceService
	{
		private readonly IMongoCollection<FinanceInventory> financeCollection;

		public FinanceService(IOptions<FinanceInventoryDatabaseSettings> financeInventorySettings)
		{
			var mongoClient = new MongoClient(financeInventorySettings.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(financeInventorySettings.Value.DatabaseName);
			financeCollection = mongoDatabase.GetCollection<FinanceInventory>(financeInventorySettings.Value.CollectionName);
		}

		public async Task<List<FinanceInventory>> FinanceInventoryAsync()
		{
			return await financeCollection.Find(_ => true).ToListAsync();
		}

        public async Task<FinanceInventory> GetFinanceDetailsByIdAsync(string financeId)
        {
            return await financeCollection.Find(x => x.Id == financeId).FirstOrDefaultAsync();
        }

        public Task AddFinanceItemAsync(FinanceInventory financeInventory)
        {

            return financeCollection.InsertOneAsync(financeInventory); 
        }

        public Task UpdateFinanceItemAsync(string financeId, FinanceInventory financeInventory)
        {
            return financeCollection.ReplaceOneAsync(x => x.Id == financeId, financeInventory);
        }

        public Task DeleteFinanceItemAsync(string financeId)
        {
            return financeCollection.DeleteOneAsync(x => x.Id == financeId);
        }
    }
}

