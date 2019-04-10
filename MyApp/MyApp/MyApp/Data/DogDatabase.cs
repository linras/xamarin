using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MyApp.Models;
using System.Threading.Tasks;

namespace MyApp.Data
{
    public class DogDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public DogDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Dog>().Wait();
        }

        public Task<List<Dog>> GetDogsAsync()
        {
            return _database.Table<Dog>().ToListAsync();
        }

        public Task<Dog> GetDogAsync(int id)
        {
            return _database.Table<Dog>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveDogAsync(Dog dog)
        {
            if (dog.ID != 0)
            {
                return _database.UpdateAsync(dog);
            }
            else
            {
                return _database.InsertAsync(dog);
            }
        }

        public Task<int> DeleteDogAsync(Dog dog)
        {
            return _database.DeleteAsync(dog);
        }
    }
}
