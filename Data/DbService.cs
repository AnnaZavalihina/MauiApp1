using MauiApp1.Models;
using SQLite;

namespace MauiApp1.Data
{
    public class DbService
    {
        private readonly SQLiteAsyncConnection _database;
        public DbService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "images.db");
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Photo>().Wait();
        }

        public async Task<int> AddImageAsync(Photo image)
        {
            return await _database.InsertAsync(image);
        }

        public async Task<List<Photo>> GetImagesAsync()
        {
            return await _database.Table<Photo>().ToListAsync();
        }

        public async Task<int> DeleteImageAsync(int id)
        {
            return await _database.DeleteAsync<Photo>(id);
        }
    }
}