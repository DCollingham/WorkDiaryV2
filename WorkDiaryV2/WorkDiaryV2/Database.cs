using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using System.IO;

using System.Linq;

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


        public async Task DeleteAllAsync()
        {
            await _database.DeleteAllAsync<DiaryEntry>();
            await _database.DeleteAllAsync<DiaryTaskList>();
        }

        public async Task<DiaryTaskList> GetEntryRow(int id)
        {
            return await _database.GetAsync<DiaryTaskList>(id);

        }

        public Task<int> SaveDiaryTaskEntry(DiaryTaskList entry)
        {
            return _database.InsertAsync(entry);
        }

        public async Task<List<DiaryTaskList>> GetMatchingTasks(int taskId)
        {
            return await _database.QueryAsync<DiaryTaskList>("SELECT * FROM DiaryTaskList WHERE TaskId = ? ", taskId);
        }

        public async Task<IEnumerable<dynamic>> GetAllTest()
        {
            var entrys = await _database.Table<DiaryEntry>().ToListAsync();
            var taskList = await _database.Table<DiaryTaskList>().ToListAsync();

            var joined = from e in entrys
                         join t in taskList on e.Id equals t.TaskId into dayTasks
                         select new { e.Place, e.Date, e.Hours, dayTasks };

            return joined;

            // join t in taskList on e.Id equals t.TaskId into dayTasks
            // select new { Place = e.Place, dailyTasks = dayTasks }

            // join t in taskList on e.Id equals t.TaskId
            // select new { e.Place, e.Date, e.Overtime, e.Hours, t.TaskDetail, t.TaskId };
            //

        }


    };
}
