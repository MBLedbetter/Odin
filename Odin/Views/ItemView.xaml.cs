using OdinModels;
using Odin.ViewModels;
using System.Windows;

namespace Odin.Views
{
    /// <summary>
    /// Interaction logic for ItemView.xaml
    /// </summary>
    partial class ItemView : Window
    {
        public ItemView()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as ItemViewModel).SubmitItem())
            {
                this.DialogResult = true;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ItemViewModel).RemoveItemCommand.Execute(null);
            this.DialogResult = true;
        }
    }
}