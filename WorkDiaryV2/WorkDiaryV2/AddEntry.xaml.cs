using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkDiaryV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEntry : ContentPage
    {
        
        public AddEntry()
        {
            InitializeComponent();
            sliderHours.Value = 4;
        }
        
        //List of diary tasks
        public List<string> taskList = new List<string>();

        //Add diary task to ui & taskList
        private void AddTask_Completed(object sender, EventArgs e)
        {

            Label label = new Label
            {
                Text = entryCellAdd.Text
            };

            tasksCompleted.Children.Add(label);
            taskList.Add(entryCellAdd.Text);
            entryCellAdd.Text = "";
        }

        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            //Create DiaryEntry Object
            DiaryEntry entry = new DiaryEntry()
            {
                Place = placeOfWork.Text,
                Date = dateWorked.Date,
                Overtime = switchOvertime.IsToggled,
                Hours = sliderHours.Value,
            };

            //Save object to database
            _ = await App.Database.SaveEntryAsync(entry);
            System.Diagnostics.Debug.WriteLine($"Entry Id: {entry.Id}");
            int taskId = entry.Id;



            foreach(var task in taskList)
            {
                DiaryTaskList diaryTaskList = new DiaryTaskList()
                {
                    TaskId = taskId,
                    TaskDetail = task

                };
                _ = await App.Database.SaveEntryAsync(diaryTaskList);
                System.Diagnostics.Debug.WriteLine($"diaryTaskList Id: {diaryTaskList.Id}");
            }

            ResetPage();

            
        }

        private void ResetPage()
        {
            taskList.Clear();
            tasksCompleted.Children.Clear();
            System.Diagnostics.Debug.WriteLine("UI Cleared");
        }

    }
}