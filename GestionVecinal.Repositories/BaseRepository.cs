using GestionVecinal.Repositories.Entities;
using GestionVecinal.Repositories;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;

namespace GestionVecinal.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        public readonly SQLiteAsyncConnection _database;

        public BaseRepository()
        {
            var databasePath = Path.Combine(AppContext.BaseDirectory, Constants.DatabasePath);
            if (!File.Exists(databasePath))
            {
                File.Create(databasePath).Dispose();
            }
            _database = new SQLiteAsyncConnection(databasePath);
        }

        //public Task<List<TodoItem>> GetItemsAsync()
        //{
        //    return _database.Table<TodoItem>().ToListAsync();
        //}

        //public Task<TodoItem> GetItemAsync(int id)
        //{
        //    return _database.Table<TodoItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        //}

        //public Task<int> SaveItemAsync(TodoItem item)
        //{
        //    if (item.Id != 0)
        //    {
        //        return _database.UpdateAsync(item);
        //    }
        //    else
        //    {
        //        return _database.InsertAsync(item);
        //    }
        //}

        //public Task<int> DeleteItemAsync(TodoItem item)
        //{
        //    return _database.DeleteAsync(item);
        //}
    }
}
