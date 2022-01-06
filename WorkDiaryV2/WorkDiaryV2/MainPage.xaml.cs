using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkDiaryV2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private  void ViewClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new ViewMonth()));
        }

        private void AddEntryClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AddEntry()));
        }
    }
}
