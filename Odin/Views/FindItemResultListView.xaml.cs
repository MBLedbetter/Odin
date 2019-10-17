using Odin.ViewModels;
using System.Windows;

namespace Odin.Views
{
    /// <summary>
    ///     Interaction logic for FindItemResultListView.xaml
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
