using System;
using System.Collections.Generic;
using System.IO;
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

namespace Odin.Views
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : Window
    {
        public HelpView()
        {
            InitializeComponent();

            string tutorialPath = @"\\abe\ClickOnce\Odin\resources\tutorial.pdf";
            string requiredFieldpath = @"\\abe\ClickOnce\Odin\resources\requiredFields.pdf";
            this.MainBrowser.Navigate(tutorialPath);
            this.RequiredFieldBrowser.Navigate(requiredFieldpath);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
