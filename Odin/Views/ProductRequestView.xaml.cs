using Odin.ViewModels;
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
    /// Interaction logic for ProductRequestView.xaml
    /// </summary>
    public partial class ProductRequestView : Window
    {
        public ProductRequestView()
        {
            InitializeComponent();
        }

        private void Request_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (this.DataContext as ProductRequestViewModel).ViewSelectedRequestCommand.Execute(null);
        }
        private void ItemRequest_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (this.DataContext as ProductRequestViewModel).ViewSelectedItemRequestCommand.Execute(null);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
