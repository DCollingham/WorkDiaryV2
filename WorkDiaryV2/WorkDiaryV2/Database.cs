using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace WorkDiaryV2
{
   public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DiaryEntry>().Wait();
        }

        public Task<List<DiaryEntry>> GetEntryAsync()
        {
            return _database.Table<DiaryEntry>().ToListAsync();
        }

        public Task<int> SaveEntryAsync(DiaryEntry entry)
        {
            return _database.InsertAsync(entry);
            
        }

        public async Task DeleteEntryAsync()
        {
            await _database.DeleteAllAsync<DiaryEntry>();
        }

    }
}