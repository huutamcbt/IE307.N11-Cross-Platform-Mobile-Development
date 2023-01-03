using Frontend.Models;
using Frontend.Services;
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
    public partial class AddressPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        int addressID;
        int userID = UserService.GetUserID();
        public AddressPopupPage()
        {

            InitializeComponent();
            popupTitle.Text = "Thêm địa chỉ";
            addressID = 0;

        }
        public AddressPopupPage(UserAddress address)
        {
            InitializeComponent();
            mobileEntry.Text = address.Mobile;
            addressEntry.Text = address.Address;
            provinceEntry.Text = address.Province;
            cityEntry.Text = address.City;
            countryEntry.Text = address.Country;
            districtEntry.Text = address.District;
            popupTitle.Text = "Sửa địa chỉ";
            addressID = address.AddressId;




        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
            if (addressID == 0)
                await AddressService.AddAddress(new UserAddress { UserId = userID, Mobile = mobileEntry.Text, Address = addressEntry.Text, Province = provinceEntry.Text, City = cityEntry.Text, Country = countryEntry.Text, District = districtEntry.Text });
            else
                await AddressService.UpdateAddress(new UserAddress { AddressId = addressID, UserId = userID, Mobile = mobileEntry.Text, Address = addressEntry.Text, Province = provinceEntry.Text, City = cityEntry.Text, Country = countryEntry.Text, District = districtEntry.Text });
            MessagingCenter.Send<AddressPopupPage>(this, "refresh");
            await PopupNavigation.Instance.PopAsync(true);
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}