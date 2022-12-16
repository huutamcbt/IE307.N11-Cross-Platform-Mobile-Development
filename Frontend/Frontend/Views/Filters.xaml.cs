using Rg.Plugins.Popup.Services;
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
    public partial class Filters : Rg.Plugins.Popup.Pages.PopupPage
    {
        Command GoBackCommand;
        public Filters()
        {
            InitializeComponent();
            GoBackCommand = new Command(() =>
            {
                goBackTriggered();
            });
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        async void goBackTriggered()
        {
            //await PopupNavigation.Instance.PopAsync(true);
        }
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }
    }
}