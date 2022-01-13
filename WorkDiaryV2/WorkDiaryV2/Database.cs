using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WorkDiaryV2
{
   public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DiaryEntry>().Wait();
            _database.CreateTableAsync<DiaryTaskList>().Wait();


        }

        public Task<List<DiaryEntry>> GetEntryAsync()
        {
            return _database.Table<DiaryEntry>().ToListAsync();
        }


        public Task<int> SaveEntryAsync(DiaryEntry entry)
        {
            return _database.InsertAsync(entry);    
        }

        public Task<int> SaveEntryAsync(DiaryTaskList entry)
        {
            return _database.InsertAsync(entry);
        }


        public async Task DeleteEntryAsync()
        {
            await _database.DeleteAllAsync<DiaryEntry>();
        }

        public Task<DiaryEntry> GetEntryRow(int id)
        {
            return _database.GetAsync<DiaryEntry>(id);
        }

        public Task<int> SaveDiaryTaskEntry(DiaryTaskList entry)
        {
            return _database.InsertAsync(entry);
        }

    }
}