using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        string validationNamePattern = @"^(([a-zA-Z\sÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]*)([a-zA-Z\s\'ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]*)([a-zA-Z\sÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]))*$";
        string validationPasswordPattern =  @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[_\W]).{8,15}$";
        string validationTelephoneNumberPattern = @"^(84|0[3|5|7|8|9])+([0-9]{8})\b$";
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void FirstName_Unfocused(object sender, FocusEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text != null && text != "")
            {
                Console.WriteLine("Validate");
                if (Regex.IsMatch(text, validationNamePattern) && LastNameNotification.IsVisible == false)
                {
                    FirstNameNotification.IsVisible = false;
                    NameSection.HeightRequest = 75;
                }
                else
                {
                    FirstNameNotification.IsVisible = true;
                    NameSection.HeightRequest = 100;
                }
            }
            else
            {
                if (LastNameNotification.IsVisible == false)
                {
                    FirstNameNotification.IsVisible = false;
                    NameSection.HeightRequest = 75;
                }
                else
                {
                    FirstNameNotification.IsVisible = false;
                }
            }
        }

        private void LastName_Unfocused(object sender, FocusEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text != null && text != "")
            {
                Console.WriteLine("Validate");
                if (Regex.IsMatch(text, validationNamePattern) && FirstNameNotification.IsVisible == false)
                {
                    LastNameNotification.IsVisible = false;
                    NameSection.HeightRequest = 75;
                }
                else
                {
                    LastNameNotification.IsVisible = true;
                    NameSection.HeightRequest = 100;
                }
            }
            else
            {
                if (FirstNameNotification.IsVisible == false)
                {
                    LastNameNotification.IsVisible = false;
                    NameSection.HeightRequest = 75;
                }
                else
                {
                    LastNameNotification.IsVisible = false;
                }
            }
        }

        private void entryUsername_Unfocused(object sender, FocusEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text.Length > 0 && text.Replace(" ", "") == "")
            {
                UsernameNotification.Text = "Tên đăng nhập không hợp lệ";
                UsernameNotification.IsVisible = true;
            }
            else
                UsernameNotification.IsVisible = false;
        }

        private void entryPassword_Unfocused(object sender, FocusEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text != null && text != "")
            {
                if (Regex.IsMatch(text, validationPasswordPattern))
                    PasswordNotification.IsVisible = false;
                else
                    PasswordNotification.IsVisible = true;
            }
            else
                PasswordNotification.IsVisible = false;
        }

        private void entryConfirmPassword_Unfocused(object sender, FocusEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text != null && text != "")
            {
                if (Regex.IsMatch(text, validationPasswordPattern))
                    ConfirmationPasswordNotification.IsVisible = false;
                else
                    ConfirmationPasswordNotification.IsVisible = true;
            }
            else
                ConfirmationPasswordNotification.IsVisible = false;
        }

        private void TelephoneNumber_Unfocused(object sender, FocusEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text != null && text != "")
            {
                if (Regex.IsMatch(text, validationTelephoneNumberPattern))
                    TelephoneNumberNotification.IsVisible = false;
                else
                    TelephoneNumberNotification.IsVisible = true;
            }
            else
                TelephoneNumberNotification.IsVisible = false;
        }

        private async void SendRequestButton_Clicked(object sender, EventArgs e)
        {
            if (UsernameNotification.IsVisible == true || PasswordNotification.IsVisible == true
                || ConfirmationPasswordNotification.IsVisible == true || FirstNameNotification.IsVisible == true
                || LastNameNotification.IsVisible == true || TelephoneNumberNotification.IsVisible == true)
            {
                await DisplayAlert("Lỗi", "Các trường thông tin phải hợp lệ", "OK");
            }
            else
            {

            }
        }
    }
}