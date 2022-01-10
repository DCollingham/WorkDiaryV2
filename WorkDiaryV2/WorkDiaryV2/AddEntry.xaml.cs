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
            //Saves object to database
            await App.Database.SaveEntryAsync(new DiaryEntry
            {
                Place = placeOfWork.Text,
                Date = dateWorked.Date,
                Overtime = switchOvertime.IsToggled,
                Hours = sliderHours.Value,
                MyTask1 = taskList[0],
                MyTask2 = taskList[1],
                MyTask3 = taskList[2],
                MyTask4 = taskList[3]
            });
            System.Diagnostics.Debug.WriteLine(taskList[0]);
            System.Diagnostics.Debug.WriteLine(taskList[1]);

        }
        
    }
}