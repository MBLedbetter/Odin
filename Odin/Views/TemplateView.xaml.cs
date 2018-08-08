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
    /// Interaction logic for TemplateView.xaml
    /// </summary>
    public partial class TemplateView : Window
    {
        public TemplateView()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as TemplateViewModel).RemoveTemplate())
            {
                this.DialogResult = true;
            }
        }
    }
}
