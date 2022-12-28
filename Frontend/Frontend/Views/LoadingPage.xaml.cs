using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            loading_progress.Progress = 0;
            
            await loading_progress.ProgressTo(1, 5000, Easing.SpringIn);
            await Shell.Current.GoToAsync("//Main");
            
        }

    }
}