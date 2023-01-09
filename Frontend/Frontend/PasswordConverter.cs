using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Frontend
{
    class PasswordConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[0] != null && values[1] != null && values[2] != null  && values.Length == 6)
            {
                string oldPassword = values[0].ToString();
                string newPassword = values[1].ToString();
                string confirmationPassword = values[2].ToString();
                bool oldPasswordCheck = (bool)values[3];
                bool newPasswordCheck = (bool)values[4];
                bool confirmationPasswordCheck = (bool)values[5];

                return new
                {
                    oldPassword,
                    newPassword,
                    confirmationPassword,
                    oldPasswordCheck,
                    newPasswordCheck,
                    confirmationPasswordCheck
                };
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
