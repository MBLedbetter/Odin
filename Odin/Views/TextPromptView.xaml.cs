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
    /// Interaction logic for TextPromptView.xaml
    /// </summary>
    public partial class TextPromptView : Window
    {
        public TextPromptView()
        {
            InitializeComponent();
            TextBox1.Focus();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(this.DataContext as TextPromptViewModel).HasErrors())
            {
                if ((this.DataContext as TextPromptViewModel).Submit())
                {
                    this.DialogResult = true;
                }
                else
                {
                    this.DialogResult = false;
                }
            }
            else
            {
                MessageBox.Show((this.DataContext as TextPromptViewModel).ReturnErrors());
            }
        }
    }
}
