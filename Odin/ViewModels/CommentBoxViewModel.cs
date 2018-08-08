using Mvvm;
using System;
using System.Collections.Generic;
using Odin.Views;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Odin.ViewModels
{
    class CommentBoxViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler CommentPropertyChanged;
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
        private string _comment { get; set; }
    }
}
