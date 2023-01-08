using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net;

using Frontend.Services;
using System.Diagnostics;
using Newtonsoft.Json;
using Frontend.Models;
using Frontend.Views;
using System.Threading.Tasks;

namespace Frontend.ViewModels
{
    class PasswordViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string oldpass;
        private string newpass;
        private string confirmationpass;
        private bool oldPasswordCheck;
        private bool newPasswordCheck;
        private bool confirmationPasswordCheck;
        public string oldPassword
        {
            get
            {
                return oldpass;
            }
            set
            {
                SetProperty(ref oldpass, value);
            }
        }
        public string newPassword
        {
            get
            {
                return newpass;
            }
            set
            {
                SetProperty(ref newpass, value);
            }
        }
        public string confirmationPassword
        {
            get
            {
                return confirmationpass;
            }
            set
            {
                SetProperty(ref confirmationpass, value);
            }
        }
        public bool OldPasswordCheck
        {
            get
            {
                return oldPasswordCheck;
            }
            set
            {
                SetProperty(ref oldPasswordCheck, value);
            }
        }
        public bool NewPasswordCheck
        {
            get
            {
                return newPasswordCheck;
            }
            set
            {
                SetProperty(ref newPasswordCheck, value);
            }
        }
        public bool ConfirmationPasswordCheck
        {
            get
            {
                return confirmationPasswordCheck;
            }
            set
            {
                SetProperty(ref confirmationPasswordCheck, value);
            }
        }

        private Dictionary<string, string> messageParameters = new Dictionary<string, string>();


        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        public ICommand StorageCommand { get; set; }
        public PasswordViewModel()
        {
            StorageCommand = new Command<object>(storgeCommand);
            OldPasswordCheck = false;
            NewPasswordCheck = false;
            confirmationPasswordCheck = false;
        }

        private async void storgeCommand(object obj)
        {
            var passwords = new
            {
                oldPassword = "",
                newPassword = "",
                confirmationPassword = "",
                oldPasswordCheck = false,
                newPasswordCheck = false,
                confirmationPasswordCheck = false
            };


            passwords = Cast(passwords, obj);
            if (passwords.oldPasswordCheck == true || passwords.newPasswordCheck == true || passwords.confirmationPasswordCheck == true)
            {
                // Display a pop-ups to notify the result
                messageParameters = null;
                messageParameters = new Dictionary<string, string>();
                messageParameters.Add(Constant.MessagingCenter_Title, "Lỗi");
                messageParameters.Add(Constant.MessagingCenter_Message, "Giá trị mật khẩu không hợp lệ");
                MessagingCenter.Send<PasswordViewModel, Dictionary<string, string>>(this, "PasswordEvent", messageParameters);
            }
            else
            {
                // Check the equality of old password and new password
                if (Object.Equals(passwords.oldPassword, passwords.newPassword) == false)
                {
                    // Check the equality of new password and confirmation password
                    if (Object.Equals(passwords.newPassword, passwords.confirmationPassword))
                    {
                        // Create anonymous object to send to the update password api
                        var requestContent = new
                        {
                            UserId = UserService.user.UserId,
                            oldPassword = passwords.oldPassword,
                            newPassword = passwords.newPassword
                        };

                        // Send the update password request
                        HttpResponseMessage response = await UserService.UpdatePassword(requestContent);

                        HttpStatusCode statusCode = response.StatusCode;
                        Debug.WriteLine(response.StatusCode + " " + response.Content);
                        // Check the status code
                        // If  the request is successful
                        if (Object.Equals(statusCode, HttpStatusCode.OK))
                        {
                            // Display a pop-ups to notify the result
                            messageParameters = null;
                            messageParameters = new Dictionary<string, string>();
                            messageParameters.Add(Constant.MessagingCenter_Title, "Thông báo");
                            messageParameters.Add(Constant.MessagingCenter_Message, "Đổi mật khẩu thành công");
                            MessagingCenter.Send<PasswordViewModel, Dictionary<string, string>>(this, "PasswordEvent", messageParameters);

                            await Shell.Current.GoToAsync(nameof(ProfilePage));
                        }
                        // If the request if failed
                        if (Object.Equals(statusCode, HttpStatusCode.BadRequest))
                        {
                            int code = Convert.ToInt32(response.Content.ReadAsStringAsync().Result);
                            // Check the CheckedCode
                            if (code == CheckedCode.WRONG_PASSWORD)
                            {
                                // Display a pop-ups to notify the result
                                messageParameters = null;
                                messageParameters = new Dictionary<string, string>();
                                messageParameters.Add(Constant.MessagingCenter_Title, "Lỗi");
                                messageParameters.Add(Constant.MessagingCenter_Message, "Sai mật khẩu");
                                MessagingCenter.Send<PasswordViewModel, Dictionary<string, string>>(this, "PasswordEvent", messageParameters);
                            }

                            //Debug.WriteLine($"Status Code: {response.StatusCode} \n" +
                            //    $"Content: {response.Content.ReadAsStringAsync().Result}");
                        }
                    }
                    else
                    {
                        // Display a pop-ups to notify the result
                        messageParameters = null;
                        messageParameters = new Dictionary<string, string>();
                        messageParameters.Add(Constant.MessagingCenter_Title, "Lỗi");
                        messageParameters.Add(Constant.MessagingCenter_Message, "Mật khẩu mới và mật khẩu xác nhận không trùng khớp nhau");
                        MessagingCenter.Send<PasswordViewModel, Dictionary<string, string>>(this, "PasswordEvent", messageParameters);
                    }
                }
                else
                {
                    // Display a pop-ups to notify the result
                    messageParameters = null;
                    messageParameters = new Dictionary<string, string>();
                    messageParameters.Add(Constant.MessagingCenter_Title, "Lỗi");
                    messageParameters.Add(Constant.MessagingCenter_Message, "Mật khẩu mới phải khác mật khẩu ban đầu");
                    MessagingCenter.Send<PasswordViewModel, Dictionary<string, string>>(this, "PasswordEvent", messageParameters);
                }
            }

        }

        private T Cast<T>(T typeHolder, object o)
        {
            return (T)o;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
