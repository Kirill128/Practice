using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Lab4.ViewModel
{
    class CommandLogin : ICommand
    {
        private readonly IDataErrorInfo _dataErrorInfo;
        private readonly Action _action;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CommandLogin(IDataErrorInfo dataErrorInfo, Action action)
        {
            _dataErrorInfo = dataErrorInfo;
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            return string.IsNullOrEmpty(_dataErrorInfo.Error);
        }

        public void Execute(object parameter)
        {
            _action.Invoke();
        }
    }
}
