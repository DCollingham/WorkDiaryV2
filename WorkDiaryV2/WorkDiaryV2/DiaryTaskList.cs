using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WorkDiaryV2
{
    public class DiaryTaskList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string TaskDetail { get; set; }
    }
}
