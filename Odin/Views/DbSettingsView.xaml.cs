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
    /// Interaction logic for DbSettingsView.xaml
    /// </summary>
    public partial class DbSettingsView : Window
    {
        public DbSettingsView()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as DbSettingsViewModel).SaveChange())
            {
                this.DialogResult = true;
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as DbSettingsViewModel).Cancel())
            {
                this.DialogResult = true;
            }
        }
    }
}
