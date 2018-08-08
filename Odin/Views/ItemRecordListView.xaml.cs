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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Odin.Views
{
    /// <summary>
    /// Interaction logic for ItemRecordListView.xaml
    /// </summary>
    public partial class ItemRecordListView : Window
    {
        public ItemRecordListView()
        {
            InitializeComponent();
        }
        private void itemRecordListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (this.DataContext as ItemRecordListViewModel).OpenSelectedItemRecordCommand.Execute(null);
        }
        private void ItemId_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ItemRecordListViewModel).SortItemIdCommand.Execute(null);
        }
        private void RecordStatus_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ItemRecordListViewModel).SortRecordStatusCommand.Execute(null);
        }
        private void UserName_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ItemRecordListViewModel).SortUserNameCommand.Execute(null);
        }
        private void InputDate_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ItemRecordListViewModel).SortInputDateCommand.Execute(null);
        }

        private void GenerateList_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ItemRecordListViewModel).GenerateListCommand.Execute(null);
        }
    }
}
