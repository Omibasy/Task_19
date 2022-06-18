using System;
using System.Windows.Input;

namespace Task_20.ViewModel
{
    class Command : ICommand
    {
        Action<object> execute;

        Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged 
        {
           add
            {
                CommandManager.RequerySuggested += value;
            }
            remove 
            {
                CommandManager.RequerySuggested -= value; 
            }    
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
            {
                canExecute(parameter);
            }

            return true;
        }

        public void Execute(object parameter)
        {
            if (execute != null)
            {
                execute(parameter);
            }           
        }

        public Command(Action<object> executeAction) : this(executeAction, null) 
        {
        
        }

        public Command(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this.execute = executeAction;
            this.canExecute = canExecute;
        }
    }
}
