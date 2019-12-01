using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TshirtApp
{
    public class TshirtDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TshirtDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Tshirt>().Wait();
        }

        public Task<List<Tshirt>> GetItemsAsync()
        {
            return database.Table<Tshirt>().ToListAsync();
        }

        public Task<List<Tshirt>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Tshirt>("SELECT * FROM [Tshirt] WHERE [Done] = 0");
        }

        public Task<Tshirt> GetItemAsync(int id)
        {
            return database.Table<Tshirt>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Tshirt item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Tshirt item)
        {
            return database.DeleteAsync(item);
        }

        public Task<List<Tshirt>> GetUnSubmittedOrders()
        {
            return database.Table<Tshirt>().Where(x => x.Posted == false).ToListAsync();
        }
    }
}
    

