using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Mvvm
{

	/// <summary>
	///		This class provides a mechanism for classes to invoke delegates of other classes.
	/// </summary>
	public class RelayCommand : ICommand
	{

		#region Private Properties

		/// <summary>
		///		This action will be performed when this object's 'Execute' method is called.
		/// </summary>
		private readonly Action<object> _execute;

		/// <summary>
		///		This predicate determines whether this object can execute.
		/// </summary>
		private readonly Predicate<object> _canExecute;

		#endregion	// Private Properties

		#region Constructors

		/// <summary>
		///		RelayCommand constructor.
		/// </summary>
		/// 
		/// <param name="execute">
		///		This action that will be performed when this command is executed.
		/// </param>
		/// 
		/// <param name="canExecute">
		///		A predicate that specifies whether this command may be executed.
		/// </param>
		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}

			_canExecute = canExecute;
			_execute = execute;
		}

		/// <summary>
		///		RelayCommand constructor.
		/// </summary>
		/// 
		/// <param name="execute">
		///		This action that will be performed when this command is executed.
		/// </param>
		public RelayCommand(Action<object> execute)
			: this(execute, null)
		{
		}

		#endregion	// Constructors

		#region ICommand Members

		/// <summary>
		///		This method returns a flag that indicates whether this command can be executed.
		/// </summary>
		/// 
		/// <param name="parameter">
		///		The parameter that will be passed to this object's _canExecute property.
		///	</param>
		/// 
		/// <returns>
		///		Returns a flag that indicates whther this command can be executed.
		/// </returns>
		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}

		/// <summary>
		///		This event hander is called when a condition occurs that might change this object's
		///		'CanExecute' value.
		/// </summary>
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

		/// <summary>
		///		Executes this command.
		/// </summary>
		/// 
		/// <param name="parameter">
		///		The parameter that will be passed to this object's execution method.
		/// </param>
		public void Execute(object parameter)
		{
			_execute(parameter);
		}

		#endregion	// ICommand Members

	}

}

