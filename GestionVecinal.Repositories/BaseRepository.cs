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
            bool newDatabase = false;
            var databasePath = Path.Combine(AppContext.BaseDirectory, Constants.DatabasePath);
            if (!File.Exists(databasePath))
            {
                File.Create(databasePath).Dispose();
                newDatabase = true;
            }
            _database = new SQLiteAsyncConnection(databasePath);
            if (newDatabase)
            {
                _database.CreateTableAsync<Comunidad>().Wait();
                _database.CreateTableAsync<Derrama>().Wait();
                _database.CreateTableAsync<Factura>().Wait();
                _database.CreateTableAsync<Incidencia>().Wait();
                _database.CreateTableAsync<Junta>().Wait();
                _database.CreateTableAsync<Miembro>().Wait();
                _database.CreateTableAsync<Pago>().Wait();
                _database.CreateTableAsync<Presidencia>().Wait();
                _database.CreateTableAsync<Proveedor>().Wait();
            }
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
