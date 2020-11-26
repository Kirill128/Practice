﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab4.ViewModel;

namespace Lab4.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class UserAccount : Window
    {
        public ATMViewModel ATM;
        private LoginWindow LoginWindow { get; set; }
        public UserAccount(ATMViewModel atm,LoginWindow loginWindow)
        {
            InitializeComponent();
            this.ATM = atm;
            DataContext = this.ATM;
            this.LoginWindow = loginWindow;
        }

        private void ButtonGetMoney_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.ATM.CurrentCard = null;
            this.Hide();
            this.LoginWindow.Show();
        }
    }
}
