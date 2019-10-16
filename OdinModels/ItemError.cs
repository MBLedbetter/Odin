using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdinModels
{
    public class ItemError : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Events

        #region Properties

        /// <summary>
        ///     Gets or sets the ErrorField
        /// </summary>
        public string ErrorField
        {
            get
            {
                return _errorField;
            }
            set
            {
                _errorField = value;

                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ErrorField"));
                }
            }
        }
        private string _errorField = "";

        /// <summary>
        ///     Gets or sets the ErrorMessage
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                if (_errorMessage == "")
                {
                    return "";
                }
                return this.ErrorField + " " + _errorMessage;
            }
            set
            {
                _errorMessage = value;               

                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
                }
            }
        }
        private string _errorMessage = "";

        /// <summary>
        ///     Gets or sets the ErrorType
        /// </summary>
        public string ErrorType
        {
            get
            {
                return _errorType;
            }
            set
            {
                _errorType = value;

                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ErrorType"));
                }
            }
        }
        private string _errorType = "";

        /// <summary>
        ///     Gets or sets the ItemIdNumber
        /// </summary>
        public string ItemIdNumber
        {
            get
            {
                return _itemIdNumber;
            }
            set
            {
                _itemIdNumber = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemIdNumber"));
                }
            }
        }
        private string _itemIdNumber;

        /// <summary>
        ///     Gets or sets the LineNumber
        /// </summary>
        public int LineNumber
        {
            get
            {
                return _lineNumber;
            }
            set
            {
                _lineNumber = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LineNumber"));
                }
            }
        }
        private int _lineNumber;

        #endregion // Properties
        

        #region Constructor

        /// <summary>
        ///     Creates an Item Error Object
        /// </summary>
        /// <param name="itemId">Item Id associated with errored field</param>
        /// <param name="lineNumber">Line number of errored item</param>
        /// <param name="errorMessage">Error message</param>
        /// <param name="varName">Field causing error</param>
        /// <param name="isError">Type of error</param>
        public ItemError(string itemId, int lineNumber, string errorMessage, string errorField, bool isError)
        {
            this.ItemIdNumber = itemId;
            this.LineNumber = lineNumber;
            this.ErrorMessage = errorMessage;
            this.ErrorField = errorField;
            this.ErrorType = (isError) ? "Error" : "Warning";
        }

        #endregion // Constructor
    }
}

