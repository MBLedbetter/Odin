using Mvvm;
using System;
using System.Collections.Generic;
using Odin.Views;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace Odin.ViewModels
{
    class CommentBoxViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler CommentPropertyChanged;
        
        #region Properties

        /// <summary>
        ///     Gets or sets the Comment
        /// </summary>
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                if (this.CommentPropertyChanged != null)
                {
                    CommentPropertyChanged(this, new PropertyChangedEventArgs("Comment"));
                }
            }
        }
        private string _comment = string.Empty;

        /// <summary>
        ///     Gets or sets the ShopTrendsCheckBox
        /// </summary>
        public bool ShopTrendsCheckBox
        {
            get
            {
                return _shopTrendsCheckBox;
            }
            set
            {
                _shopTrendsCheckBox = value;
                if (this.CommentPropertyChanged != null)
                {
                    CommentPropertyChanged(this, new PropertyChangedEventArgs("ShopTrendsCheckBox"));
                }
            }
        }
        private bool _shopTrendsCheckBox = false;

        /// <summary>
        ///     Gets or sets the TrendsInternationalCheckBox
        /// </summary>
        public bool TrendsInternationalCheckBox
        {
            get
            {
                return _trendsInternationalCheckBox;
            }
            set
            {
                _trendsInternationalCheckBox = value;
                if (this.CommentPropertyChanged != null)
                {
                    CommentPropertyChanged(this, new PropertyChangedEventArgs("TrendsInternationalCheckBox"));
                }
            }
        }
        private bool _trendsInternationalCheckBox = true;

        /// <summary>
        ///     Gets or sets the Website
        /// </summary>
        public string Website
        {
            get
            {
                if (ShopTrendsCheckBox == true)
                {
                    if (TrendsInternationalCheckBox == true)
                    {
                        return "TrendsInternational.com, ShopTrends.com";
                    }
                    else
                    {
                        return "ShopTrends.com";
                    }
                }
                else
                {
                    return "TrendsInternational.com";
                }

            }
        }

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Returns true if a website box has been checked. Otherwise it displays a message
        ///     and returns false
        /// </summary>
        /// <returns></returns>
        public bool BoxChecked()
        {
            if(this.ShopTrendsCheckBox || this.TrendsInternationalCheckBox)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please check a website to submit to.");
                return false;
            }
        }

        #endregion // Methods
    }
}
