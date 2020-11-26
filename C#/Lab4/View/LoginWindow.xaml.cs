using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab4.Model;
using Lab4.ViewModel;
namespace Lab4.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private string cardsPath = "I:\\Practice\\C#\\Lab4\\database\\cards.txt";

        private string moneyPath = "I:\\Practice\\C#\\Lab4\\database\\atminfo.txt";

        private string blockedCardsPath = "I:\\Practice\\C#\\Lab4\\database\\blockedcards.txt";

        LoginValidator valid;
        ATMViewModel atm { get; set; }
        UserAccount account { get; set; }

        LinkedList<Card> BlockedCards { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            valid = new LoginValidator();
            DataContext = valid;
            atm = new ATMViewModel(cardsPath,moneyPath,blockedCardsPath);
            account = new UserAccount(atm,this);
        }
        private void ButtonInput_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PasswordBox.Text)) {
                AccountDataError.Text = "Login and Password must contain some digits!";
                return;
            }
            if (string.IsNullOrEmpty(valid.ErrorLogin) && string.IsNullOrEmpty(valid.ErrorPassword))
            {
                ((Button)sender).Background = new SolidColorBrush(Color.FromRgb(103,58,183));

                if (atm.singIn(LoginBox.Text, PasswordBox.Text))
                {
                    clearInput();
                    account.Show();
                    this.Hide();
                }else
                {
                    AccountDataError.Text = "Account doesn't exist!!!";  
                }
            }
            else
            {
                AccountDataError.Text = String.Empty;
                ((Button)sender).Background = new SolidColorBrush(Colors.Red);
            }
        }
        public void clearInput()
        {
            LoginBox.Text = String.Empty;
            PasswordBox.Text = String.Empty;
        }
        
    }
}
