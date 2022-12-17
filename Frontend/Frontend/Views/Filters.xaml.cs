using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Frontend.Models;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Filters : Rg.Plugins.Popup.Pages.PopupPage
    {
        public Filters()
        {
            InitializeComponent();
            InitializePicker();
        }

        private async void InitializePicker()
        {
            CategoriesService service = new CategoriesService();
            List<Category> categories = await service.GetAllCategory();
            PickerCategory.ItemsSource = categories;
            
        }

        //go back trigger
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
            await PopupNavigation.Instance.PopAsync(true);
        }

        //apply filter
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }


    }
}