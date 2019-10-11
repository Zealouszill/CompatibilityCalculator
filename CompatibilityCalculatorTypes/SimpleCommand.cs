/* Author: Spencer Stewart
 * Last Updated: 10/11/2019
 * Project: CompatibilityCalculator
 *
 * Description:
 * 
 * This class implements command functionality
 * 
 * It will take an event and handle it appropriately.
 * 
 */

using System;
using System.Windows.Input;

namespace CompatibilityCalculatorTypes
{
    public class SimpleCommand : ICommand
    {
        private readonly Func<bool> canExecute;
        private readonly Action execute;

        public SimpleCommand(Action execute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public SimpleCommand(Func<bool> canExecute, Action execute)
        {
            this.canExecute = canExecute;
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute();
            return true;
        }

        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}