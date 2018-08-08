using Microsoft.Win32;
using Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class HelpViewModel : ViewModelBase, INotifyPropertyChanged
    {

        #region Properties

        /// <summary>
        ///  Gets or Sets the InstructionText
        /// </summary>
        public string InstructionText
        {
            get
            {
                return _instructionText;
            }
            set
            {
                _instructionText = value;
                OnPropertyChanged("InstructionText");
            }
        }
        private string _instructionText;

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Assigns the value to Instruction Text
        /// </summary>
        public void SetInstructionText()
        {
            this.InstructionText = "\r\n    [*]   Indicates a required field for item setup.";
            this.InstructionText += "\r\n    [**]  Indicates a required field for trendsinternational.com setup.";
            this.InstructionText += "\r\n    [***] Indicates a required field for ecommerce setup.";
        }
        
        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the HelpViewModel
        /// </summary>
        public HelpViewModel()
        {
            SetInstructionText();
        }

        #endregion // Constructor
    }
}
