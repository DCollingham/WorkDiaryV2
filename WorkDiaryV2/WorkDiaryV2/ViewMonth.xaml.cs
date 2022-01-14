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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //collectionView.ItemsSource = await App.Database.GetEntryAsync();
        }


        private async void Delete_All(object sender, EventArgs e)
        {
            await App.Database.DeleteAllAsync();
            //collectionView.ItemsSource = await App.Database.GetEntryAsync();

        }

        private void Entry_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("test");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var DiaryEntryTable = await App.Database.GetEntryAsync();
            BuildLabel(DiaryEntryTable);

        }

        private async void BuildLabel( List<DiaryEntry> DiaryEntryTable)
        {
            foreach(DiaryEntry entry in DiaryEntryTable)
            {
                Grid grid = new Grid();
                Label labelPlace = new Label();
                Label labelHours = new Label();
                Label LabelDate = new Label();

                grid.Style = (Style)Resources["gridStyle"];
                labelPlace.Style = (Style)Resources["lablePlace"];
                labelHours.Style = (Style)Resources["lableHours"];
                LabelDate.Style = (Style)Resources["lableDate"];
                
                labelPlace.Text = entry.Place;
                labelHours.Text = entry.Hours.ToString();
                LabelDate.Text = entry.Date.ToShortDateString();

                grid.Children.Add(labelPlace);
                grid.Children.Add(labelHours);
                grid.Children.Add(LabelDate);

                MainContent.Children.Add(grid);

                var x = await App.Database.GetMatchingTasks(entry.Id);
                //System.Diagnostics.Debug.WriteLine(x[0].TaskDetail);
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