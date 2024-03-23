using financeInventoryProject.Models;

namespace financeInventoryProject.Service
{
	public interface IFinanceService
	{
		//Interface (abstract & public) 
		public Task<List<FinanceInventory>> FinanceInventoryAsync();

        //GET (Read)
        public Task<FinanceInventory> GetFinanceDetailsByIdAsync(string financeId);

		//POST (Create)
		public Task AddFinanceItemAsync(FinanceInventory financeInventory);

		//PUT (Update)
		public Task UpdateFinanceItemAsync(string financeId, FinanceInventory financeInventory);	

		//DELETE (Delete)
        public Task DeleteFinanceItemAsync(string financeId);
    }
}

 