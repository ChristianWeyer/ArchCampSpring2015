using System;
using System.Windows.Input;

namespace ConfDude.Infrastructure
{
    public class DelegateCommand : ICommand
    {
        private Predicate<object> _canExecuteHandler;
        private Action<object> _executeHandler;
        private bool _canExecuteCache;

        public DelegateCommand(Predicate<object> canExecuteHandler, Action<object> executeHandler)
        {
            _executeHandler = executeHandler;
            _canExecuteHandler = canExecuteHandler;
        }

        public DelegateCommand(Action<object> executeHandler)
        {
            _executeHandler = executeHandler;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteHandler == null)
            {
                return true;
            }
            var canExecute = _canExecuteHandler(parameter);
            if (canExecute != _canExecuteCache)
            {
                _canExecuteCache = canExecute;
                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, EventArgs.Empty);
                }
            }
            return canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeHandler(parameter);
        }
    }
}
