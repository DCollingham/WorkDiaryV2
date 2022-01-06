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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetEntryAsync();
        }
        private async void Add_Entry(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            await App.Database.SaveEntryAsync(new DiaryEntry
            {
                Place = "Webbery Estate",
                Date = date,
                Hours = 4
            }) ;
            collectionView.ItemsSource = await App.Database.GetEntryAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await App.Database.DeleteEntryAsync();
            collectionView.ItemsSource = await App.Database.GetEntryAsync();
        }
    }
}