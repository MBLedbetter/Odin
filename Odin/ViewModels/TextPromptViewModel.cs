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
        ///     Gets or sets the textvalue
        /// </summary>
        public string TextValue
        {
            get
            {
                return _textValue;
            }
            set
            {
                _textValue = value;
                OnPropertyChanged("TextValue");
            }
        }
        private string _textValue = string.Empty;

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Submit true if value exists
        /// </summary>
        /// <returns></returns>
        public bool Submit()
        {
            if(string.IsNullOrEmpty(this.TextValue))
            {
                return false;
            }
            return true;
        }

        #endregion // Methods

        #region Constructor

        public TextPromptViewModel()
        {
        }

        #endregion // Constructor

    }
}
