using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExample
{
    public class Database
    {
        private SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Znamka>().Wait();
        }

        public Task<List<Znamka>> GetItemsAsync()
        {
            return database.Table<Znamka>().ToListAsync();
        }

        public Task<List<Znamka>> GetItemsNotDoneAsync(string predmet)
        {
            return database.QueryAsync<Znamka>("SELECT * FROM [Znamky.db3] WHERE [Predmet] = " + predmet);
        }
        
        public Task<Znamka> GetItemAsync(int id)
        {
            return database.Table<Znamka>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Znamka item)
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

        public Task<int> DeleteItemAsync(Znamka item)
        {
            return database.DeleteAsync(item);
        }

        public Task<List<Znamka>> GetListViewAsync()
        {
            return database.Table<Znamka>().ToListAsync();
        }

    }
}
