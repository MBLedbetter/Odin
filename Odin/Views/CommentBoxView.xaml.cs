﻿using Odin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Odin.Views
{
    /// <summary>
    /// Interaction logic for CommentBoxView.xaml
    /// </summary>
    public partial class CommentBoxView : Window
    {
        public CommentBoxView()
        {
            InitializeComponent();
        }
       
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as CommentBoxViewModel).BoxChecked())
            {
                this.DialogResult = true;
            }
        }

        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as CommentBoxViewModel).BoxChecked())
            {
                this.DialogResult = false;
            }
        }
    }
}
