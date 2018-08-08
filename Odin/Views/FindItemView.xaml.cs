using OdinModels;
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
using System.Windows.Forms;

namespace Odin.Views
{
    /// <summary>
    /// Interaction logic for UpdateView.xaml
    /// </summary>
    public partial class FindItemView : Window
    {
        public FindItemView()
        {
            InitializeComponent();
        }
       
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ItemId_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as FindItemViewModel).SortItemIdCommand.Execute(null);
        }

        private void Description_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as FindItemViewModel).SortDescriptionCommand.Execute(null);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}
