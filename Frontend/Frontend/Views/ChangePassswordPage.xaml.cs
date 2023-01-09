using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Frontend.ViewModels;
using System.Text.RegularExpressions;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePassswordPage : ContentPage
    {
        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[_\W]).{8,15}$";
        public ChangePassswordPage()
        {
            InitializeComponent();


            MessagingCenter.Subscribe<PasswordViewModel, Dictionary<string, string>>(this, "PasswordEvent", async (sender, arg) =>
              {
                  Dictionary<string, string> value = (Dictionary<string, string>)arg;
                  if (value.ContainsKey(Constant.MessagingCenter_Title) && value.ContainsKey(Constant.MessagingCenter_Message))
                  {
                      await DisplayAlert(value[Constant.MessagingCenter_Title], value[Constant.MessagingCenter_Message], "Ok");
                  }
              });
        }

        private void EntryOldPassword_Completed(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (Regex.IsMatch(text, pattern))
                oldPasswordNotification.IsVisible = false;
            else
                oldPasswordNotification.IsVisible = true;
        }

        private void EntryNewPassword_Completed(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (Regex.IsMatch(text, pattern))
                newPasswordNotification.IsVisible = false;
            else
                newPasswordNotification.IsVisible = true;
        }

        private void EntryConfirmNewPassword_Completed(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (Regex.IsMatch(text, pattern))
                confirmationPasswordNotification.IsVisible = false;
            else
                confirmationPasswordNotification.IsVisible = true;
        }

        private void EntryOldPassword_Unfocused(object sender, FocusEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text != null && text != "")
            {
                if (Regex.IsMatch(text, pattern))
                    oldPasswordNotification.IsVisible = false;
                else
                    oldPasswordNotification.IsVisible = true;
            }
            else oldPasswordNotification.IsVisible = false;
        }

        private void EntryNewPassword_Unfocused(object sender, FocusEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text != null && text != "")
            {
                if (Regex.IsMatch(text, pattern))
                    newPasswordNotification.IsVisible = false;
                else
                    newPasswordNotification.IsVisible = true;
            }
            else
                newPasswordNotification.IsVisible = false;
        }

        private void EntryConfirmNewPassword_Unfocused(object sender, FocusEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text != null && text != "")
            {
                if (Regex.IsMatch(text, pattern))
                    confirmationPasswordNotification.IsVisible = false;
                else
                    confirmationPasswordNotification.IsVisible = true;
            }
            else
                confirmationPasswordNotification.IsVisible = false;
        }
    }
}