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
    public partial class ViewMonth : ContentPage
    {
        public ViewMonth()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var joinedResults = await App.Database.GetAllTest();
            BuildLabel(joinedResults);
        }


        private async void Delete_All(object sender, EventArgs e)
        {
            await App.Database.DeleteAllAsync();

        }

        private void BuildLabel( IEnumerable<dynamic> joinedResults)
        {
            
            foreach(var item in joinedResults)
            {
                int columnCounter = 0;
                int rowCounter = 1;

                Grid dayContainer = new Grid();
                Label labelPlace = new Label();
                Label labelHours = new Label();
                Label LabelDate = new Label();

                dayContainer.Style = (Style)Resources["gridStyle"];
                labelPlace.Style = (Style)Resources["lablePlace"];
                labelHours.Style = (Style)Resources["lableHours"];
                LabelDate.Style = (Style)Resources["lableDate"];

                labelPlace.Text = Convert.ToString(item.Place);
                labelHours.Text = Convert.ToString(item.Hours);
                LabelDate.Text = Convert.ToString(item.Date.ToShortDateString());

                dayContainer.Children.Add(labelPlace);
                dayContainer.Children.Add(labelHours);
                dayContainer.Children.Add(LabelDate);


                foreach (var task in item.dayTasks)
                {
                    Label LabelTasks = new Label();
                    LabelTasks.Style = (Style)Resources["labelTasks"];
                    string taskDetail = Convert.ToString(task.TaskDetail);
                    LabelTasks.Text = taskDetail;
                    dayContainer.Children.Add(LabelTasks, columnCounter, rowCounter);
                    columnCounter++;
                    if(columnCounter == 3)
                    {
                        columnCounter = 0;
                        rowCounter++;
                    }
                }
                MainContent.Children.Add(dayContainer);
            }

        }
        //Tester
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var joinedResults = await  App.Database.GetAllTest();

            foreach (var item in joinedResults)
            {
                string Place = Convert.ToString(item.Place);
                string Hours = Convert.ToString(item.Hours);
                //string Place = Convert.ToString(item.Place);
                string Date = Convert.ToString(item.Date.ToShortDateString());

                System.Diagnostics.Debug.WriteLine("--------------");
                System.Diagnostics.Debug.WriteLine($"Place: {Place}");
                System.Diagnostics.Debug.WriteLine(Date);
                System.Diagnostics.Debug.WriteLine(Hours);

                foreach (var task in item.dayTasks)
                {
                    string taskDetail = Convert.ToString(task.TaskDetail);
                    System.Diagnostics.Debug.WriteLine(taskDetail);
                }
            }
            
        }
    }
}