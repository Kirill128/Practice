using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab4.View
{
    class LoginValidator: IDataErrorInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public string Error { get; private set; }
        public string ErrorLogin { get; private set; }
        public string ErrorPassword { get; private set; }
        public string this[string columnName] {
            get {
                ErrorLogin = String.Empty;
                ErrorPassword = String.Empty;
                string error = String.Empty;
                switch (columnName) {
                    case "Login":
                        if (!string.IsNullOrEmpty(Login) && Regex.IsMatch(Login, @"\D+")) {
                            error = "Login must include only digits.";
                            ErrorLogin = error;
                        }
                        break;
                    case "Password":
                        if (!string.IsNullOrEmpty(Login) && ( Regex.IsMatch(Password, @"\D+") || (Password.Length!=4) ))
                        {
                            error = "Password must include only 4 digits.";
                            ErrorPassword = error;
                        }
                        break;
                }
                Error = error;
                return error;
            }
        }
    }
}
