using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class TextPromptViewModel : ViewModelBase
    {
        #region Commands
        
        public ICommand SubmitCommand
        {
            get
            {
                if (_addVariantGroupIdExclusion == null)
                {
                    _addVariantGroupIdExclusion = new RelayCommand(param => Submit());
                }
                return _addVariantGroupIdExclusion;
            }
        }
        private RelayCommand _addVariantGroupIdExclusion;

        #endregion // Commands

        #region Properties


        /// <summary>
        ///     Gets or sets the Field1Title
        /// </summary>
        public string Field1Title
        {
            get
            {
                return _field1Title;
            }
            set
            {
                _field1Title = value;
                OnPropertyChanged("Field1Title");
            }
        }
        private string _field1Title = string.Empty;

        /// <summary>
        ///     Gets or sets the Field1Value
        /// </summary>
        public string Field1Value
        {
            get
            {
                return _field1Value;
            }
            set
            {
                _field1Value = value;
                OnPropertyChanged("Field1Value");
            }
        }
        private string _field1Value = string.Empty;

        /// <summary>
        ///     Gets or sets the Field2Title
        /// </summary>
        public string Field2Title
        {
            get
            {
                return _field2Title;
            }
            set
            {
                _field2Title = value;
                OnPropertyChanged("Field2Title");
            }
        }
        private string _field2Title = string.Empty;

        /// <summary>
        ///     Gets or sets the Field1Value
        /// </summary>
        public string Field2Value
        {
            get
            {
                return _field2Value;
            }
            set
            {
                _field2Value = value;
                OnPropertyChanged("Field1Value");
            }
        }
        private string _field2Value = string.Empty;

        /// <summary>
        ///     Gets or sets the Field1Visibility
        /// </summary>
        public string Field2Visibility
        {
            get
            {
                return _field2Visibility;
            }
            set
            {
                _field2Visibility = value;
                OnPropertyChanged("Field2Visibility");
            }
        }
        private string _field2Visibility = "Hidden";

        /// <summary>
        ///     Gets or sets the Title
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        private string _title = string.Empty;

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Submit true if value exists
        /// </summary>
        /// <returns></returns>
        public bool Submit()
        {
            if(string.IsNullOrEmpty(this.Field1Value))
            {
                return false;
            }
            return true;
        }

        #endregion // Methods

        #region Constructor

        public TextPromptViewModel(string title, string field1Title)
        {
            this.Field1Title = field1Title;
        }

        public TextPromptViewModel(string title, string field1Title, string field2Title)
        {
            this.Title = title;
            this.Field1Title = field1Title;
            this.Field2Title = field2Title;
            Field2Visibility = "Visible";
        }

            #endregion // Constructor

        }
}
