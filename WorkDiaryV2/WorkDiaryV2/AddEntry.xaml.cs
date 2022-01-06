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
    }
}