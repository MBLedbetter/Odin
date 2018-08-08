using Odin.ViewModels;
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
    /// Interaction logic for FindItemResultListView.xaml
    /// </summary>
    public partial class FindItemResultListView : Window
    {
        public FindItemResultListView()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void ItemId_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as FindItemResultListViewModel).SortItemIdCommand.Execute(null);
        }
        private void Description_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as FindItemResultListViewModel).SortDescriptionCommand.Execute(null);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
