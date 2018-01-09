using Order.Entity;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Database
{
    public class Dat
    {
        private SQLiteAsyncConnection db;

        public Dat(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<DOS>();
        }

        public Task<int> SaveTodosAsync(DOS item)
        {

            if (item.id != 0)
            {
                return db.InsertAsync(item);
            }
            else
            {
                return db.UpdateAsync(item);
            }
        }

        public Task<List<DOS>> Filterer(int FilterId)
        {
            return db.QueryAsync<DOS>("SELECT * FROM [Todos] WHERE [albumId] = " + FilterId); // klasické SQL
        }
    }
}
