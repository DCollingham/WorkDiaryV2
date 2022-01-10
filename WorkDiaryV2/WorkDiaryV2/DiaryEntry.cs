using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WorkDiaryV2
{
    public class DiaryEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public bool Overtime { get; set; }
        public double Hours { get; set; }
        public string MyTask1 { get; set; }
        public string MyTask2 { get; set; }
        public string MyTask3 { get; set; }
        public string MyTask4 { get; set; }
    }
}
