﻿using System;
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

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
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

        public bool Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                }
            }
        }
        private bool _status;

        public string VarName
        {
            get
            {
                return _varName;
            }
            set
            {
                _varName = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("VarName"));
                }
            }
        }
        private string _varName;

        #endregion // Properties

        #region Constructor

        /// <summary>
        ///     Creates an Item error that keeps track of the error message
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        public ItemError(string itemId, string errorMessage)
        {
            this.ItemIdNumber = itemId;
            this.ErrorMessage = errorMessage;
        }
        /// <summary>
        ///     Creates an ItemError that keeps track of the row and error message
        /// </summary>
        /// <param name="lineNumber">row the error occurs on</param>
        /// <param name="errorMessage">error message</param>
        public ItemError(string itemId, int lineNumber, string errorMessage)
        {
            this.ItemIdNumber = itemId;
            this.LineNumber = lineNumber;
            this.ErrorMessage = errorMessage;
        }
        /// <summary>
        ///     Creates an item error that keeps track of line number, message and the variable name
        /// </summary>
        /// <param name="lineNumber">row error occurs on</param>
        /// <param name="errorMessage">error message</param>
        /// <param name="varName">name of the variable causing the error</param>
        public ItemError(string itemId, int lineNumber, string errorMessage, string varName)
        {
            this.ItemIdNumber = itemId;
            this.LineNumber = lineNumber;
            this.ErrorMessage = varName + " " + errorMessage;
            this.VarName = varName;
        }

        #endregion // Constructor
    }
}

