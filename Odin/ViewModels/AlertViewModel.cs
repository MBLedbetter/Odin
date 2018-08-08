using Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class AlertViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Properties

        public string AlertImage
        {
            get
            {
                return this._alertImage;
            }
            set
            {
                this._alertImage = value;
                OnPropertyChanged("AlertImage");
            }
        }
        private string _alertImage = string.Empty;

        /// <summary>
        ///     Gets or sets the Alert Title. Title area of the Alert Window
        /// </summary>
        public string AlertTitle
        {
            get
            {
                return _alertTitle;
            }
            set
            {
                _alertTitle = value;
                OnPropertyChanged("AlertTitle");
            }
        }
        private string _alertTitle = "Alert";

        /// <summary>
        ///     Gets or sets the Alert Message. Text block area of the alert view
        /// </summary>
        public string AlertMessage
        {
            get
            {
                return _alertMessage;
            }
            set
            {
                _alertMessage = value;
                OnPropertyChanged("AlertMessage");
            }
        }
        private string _alertMessage = "";

        /// <summary>
        ///     Gets or sets the Alert Message text box
        /// </summary>
        public List<string> MessageList
        {
            get
            {
                return _messageList;
            }
            set
            {
                _messageList = value;
                OnPropertyChanged("MessageList");
            }
        }
        private List<string> _messageList = new List<string>();
        

        #endregion Properties

        #region Methods

        /// <summary>
        ///     Inserts carriage returns into the message. Splitting the string into rows of desired length.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ConfigureMessage(string value, int messageLength)
        {
            string returnValue = " - ";
            int index = messageLength;
            if (value.Length > messageLength)
            {
                while (value.Length > messageLength)
                {
                    index = messageLength-1;
                    while (value[index] != ' ')
                    {
                        index--;
                    }
                    returnValue += value.Substring(0, index) + "\r\n    ";
                    value = value.Substring(index);
                }
                returnValue += value;
            }
            else
            {
                returnValue += value;
            }
            return returnValue;
        }

        /// <summary>
        ///     Runs all logic on AlertViewModel startup
        /// </summary>
        /// <param name="type"></param>
        public void Main(string type)
        {
            SetImage(type);
            List<string> newList = new List<string>();
            foreach(string message in this.MessageList)
            {
                newList.Add(ConfigureMessage(message, 60));
            }
            this.MessageList = newList;
        }

        /// <summary>
        ///     Sets the image on the alert window
        /// </summary>
        /// <param name="type"></param>
        public void SetImage(string type)
        {
            switch(type)
            {
                case "Alert":
                    this.AlertImage = "/odin;component/Resources/Images/Alert.png";
                    break;
                case "Error":
                    this.AlertImage = "/odin;component/Resources/Images/Alert.png";
                    break;
                default:
                    this.AlertImage = "/odin;component/Resources/Images/Info.png";
                    break;
            }
        }

        #endregion // Methods

        #region Constructor

        public AlertViewModel(List<string> messageList, string type, string alertText)
        {
            this.MessageList = messageList;
            this.AlertMessage = alertText;
            this.AlertTitle = type;
            Main(type);
        }

        public AlertViewModel(string message, string type, string alertText)
        {
            this.MessageList.Add(message);
            this.AlertTitle = type;
            this.AlertMessage = alertText;
            Main(type);
        }

        #endregion // Constructor
    }
}
