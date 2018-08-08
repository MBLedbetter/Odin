using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Mvvm
{

	/// <summary>
	///		This is a base class for view models..
	/// </summary>
	public class ViewModelBase : INotifyPropertyChanged, IDisposable
	{

		#region Public Properties

		/// <summary>
		///		Gets a flag that indicates whether this contract is valid to be saved to the
		///		database.
		/// </summary>
		public bool CanSave { get; protected set; }

		/// <summary>
		///		Gets or sets this object's display name.
		/// </summary>
		public virtual string DisplayName
		{
			get
			{
				if (_displayName == null)
				{
					_displayName = string.Empty;
				}
				return _displayName;
			}
			protected set
			{
				_displayName = value;
			}
		}
		private string _displayName;

		#endregion	// Public Properties

		#region Constructor

		/// <summary>
		///		ViewModelBase constructor.
		/// </summary>
		protected ViewModelBase()
		{
		}

		#endregion	// Constructor

		#region Debugging Aides

		/// <summary>
		///		If this flag is true, an exception will be thrown if an invalid property name is
		///		passed to the 'VerifyPropertyName' method.  If this flag is false, a Debug.Fail()
		///		will be used if an invalid property name is passwed to the 'VerifyPropertyName'
		///		method.
		/// </summary>
		protected virtual bool ThrowOnInvalidPropertyName
		{
			get
			{
				return _throwOnInvalidPropertyName;
			}
		}
		private bool _throwOnInvalidPropertyName = false;

		/// <summary>
		///		This method warns the developer if this object does not have a public property with
		///		the specified name.
		/// </summary>
		/// 
		/// <param name="propertyName">
		///		The property name to check.
		/// </param>
		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public void VerifyPropertyName(string propertyName)
		{
			if (TypeDescriptor.GetProperties(this)[propertyName] == null)
			{
				string msg = "Invalid property name: " + propertyName;
				if (this.ThrowOnInvalidPropertyName)
				{
					throw new Exception(msg);
				}
				else
				{
					Debug.Fail(msg);
				}
			}
		}

		#endregion	// Debugging Aides

		#region IDisposable

		/// <summary>
		///		This method will be invoked when this object is disposed of.
		/// </summary>
		public void Dispose()
		{
			this.OnDispose();
		}

		/// <summary>
		///		This method is called when this object is disposed of.
		/// </summary>
		protected virtual void OnDispose()
		{
		}

		#endregion	// IDisposable

		#region INotifyPropertyChanged

		/// <summary>
		///		This event is raised when a property of this object is changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		///		This method raises this object's 'PropertyChanged' event and sets this object's 
		///		CanSave flag.
		/// </summary>
		/// 
		/// <param name="propertyName">
		///		The property that has the new value.
		///	</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			// Set this object's "is dirty" flag
			this.CanSave = true;

			if (this.PropertyChanged != null)
			{
				PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(propertyName);
				this.PropertyChanged(this, eventArgs);
			}
		}

		/// <summary>
		///		This method raises this object's PropertyChanged event without setting this 
		///		object's CanSave.  This method should be called when the value changes of a
		///		notify property that is not a property of the model.
		/// </summary>
		/// 
		/// <param name="propertyName">
		///		The property name.
		/// </param>
		protected virtual void OnRelatedPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(propertyName);
				this.PropertyChanged(this, eventArgs);
			}
		}

		#endregion	// INotifyPropertyChanged

	}

}
