using Mvvm;
using OdinModels;
using OdinServices;
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
        ///     Gets or sets the Field1Error
        /// </summary>
        public string Field1Error
        {
            get
            {
                return _field1Error;
            }
            set
            {
                _field1Error = value;
                OnPropertyChanged("Field1Error");
            }
        }
        private string _field1Error = string.Empty;

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
        ///     Gets or sets the Field1Type
        /// </summary>
        public string Field1Type
        {
            get
            {
                return _field1Type;
            }
            set
            {
                _field1Type = value;
                this.Field1Error = CheckField(value, 1);
                OnPropertyChanged("Field1Type");
            }
        }
        private string _field1Type = string.Empty;

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
        ///     Gets or sets the Field2Error
        /// </summary>
        public string Field2Error
        {
            get
            {
                return _field2Error;
            }
            set
            {
                _field2Error = value;
                OnPropertyChanged("Field2Error");
            }
        }
        private string _field2Error = string.Empty;

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
        ///     Gets or sets the Field2Type
        /// </summary>
        public string Field2Type
        {
            get
            {
                return _field2Type;
            }
            set
            {
                _field2Type = value;
                OnPropertyChanged("Field2Type");
            }
        }
        private string _field2Type = string.Empty;

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
                this.Field2Error = CheckField(value, 2);
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

        public string CheckField(string value, int field)
        {
            string result = string.Empty;
            string type = "string";
            switch (field)
            {
                case 1:
                    type = this.Field1Type;
                    break;
                case 2:
                    type = this.Field2Type;
                    break;                
            }
            switch (type)
            {
                case "int":
                    if (!DbUtil.IsNumber(value))
                    {
                        return "Field " + field.ToString() + " must be a number.";
                    }
                    break;
            }
            return result;
        }

        public bool HasErrors()
        {
            if (this.Field1Error == string.Empty
                && this.Field2Error == string.Empty)
            {
                return false;
            }
            return true;
        }

        public string ReturnErrors()
        {
            string result = "";

            if(!string.IsNullOrEmpty(this.Field1Error))
            {
                result += this.Field1Error;
            }
            if (!string.IsNullOrEmpty(this.Field2Error))
            {
                if(!string.IsNullOrEmpty(result))
                {
                    result += " ";
                }
                result += this.Field2Error;
            }
            return result;
        }

        /// <summary>
        ///     Submit true if value exists
        /// </summary>
        /// <returns></returns>
        public bool Submit()
        {
            if (string.IsNullOrEmpty(this.Field1Value))
            {
                return false;
            }
            return true;
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the TextPromptViewModel for a single field
        /// </summary>
        /// <param name="title"></param>
        /// <param name="field1Title"></param>
        /// <param name="field1Type"></param>
        public TextPromptViewModel(string title, 
            string field1Title, 
            string field1Type)
        {
            this.Field1Title = field1Title;
            this.Title = title;
            this.Field1Type = field1Type;
        }

        /// <summary>
        ///     Constructs the TextPromptViewModel with 2 fields
        /// </summary>
        /// <param name="title"></param>
        /// <param name="field1Title"></param>
        /// <param name="field1Type"></param>
        /// <param name="field2Title"></param>
        /// <param name="field2Type"></param>
        public TextPromptViewModel(string title, string field1Title, string field1Type, string field2Title, string field2Type)
        {
            this.Title = title;
            this.Field1Title = field1Title;
            this.Field1Type = field1Type;
            this.Field2Title = field2Title;
            this.Field2Type = field2Type;
            this.Field2Visibility = "Visible";
        }

        #endregion // Constructor

    }
}
