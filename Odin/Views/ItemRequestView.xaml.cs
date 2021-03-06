﻿using Odin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for ItemRequestView.xaml
    /// </summary>
    public partial class ItemRequestView : Window
    {
        public ItemRequestView()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as ItemRequestViewModel).SaveRequest())
            {
                this.DialogResult = true;
            }
        }
    }
}
