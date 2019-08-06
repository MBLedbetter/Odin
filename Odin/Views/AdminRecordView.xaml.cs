using Odin.ViewModels;
using System.Windows;

namespace Odin.Views
{
    /// <summary>
    /// Interaction logic for AdminRecordView.xaml
    /// </summary>
    public partial class AdminRecordView : Window
    {
        public AdminRecordView()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        private void RecordDate_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as AdminRecordViewModel).SortRecordDateCommand.Execute(null);
        }
    }
}
