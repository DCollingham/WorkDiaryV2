using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WorkDiaryV2
{
    class DiaryTaskList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int taskId { get; set; }
        public string TaskDetail { get; set; }
    }
}
