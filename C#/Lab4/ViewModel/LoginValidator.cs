using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab4
{
    class LoginValidator: IDataErrorInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public string Error { get; private set; }

        public string this[string columnName] {
            get {
                string error = String.Empty;
                switch (columnName) {
                    case "Login":
                        if (Login==null || !Regex.IsMatch(Login,@"\d+")) {
                            error = "Login must include only digits.";
                        }
                        break;
                    case "Password":
                        if (Password == null || !(Regex.IsMatch(Password, @"\d+")&& Password.Length==4))
                        {
                            error = "Password must include only 4 digits.";
                        }
                        break;
                }
                Error = error;
                return error;
            }
        }
    }
}
