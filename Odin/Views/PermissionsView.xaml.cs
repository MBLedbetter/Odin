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
    /// Interaction logic for PermissionsView.xaml
    /// </summary>
    public partial class PermissionsView : Window
    {
        public PermissionsView()
        {
            InitializeComponent();
        }

        private void Permission_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as PermissionsViewModel).SortPermissionColumnCommand.Execute(null);
        }

        private void Role_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as PermissionsViewModel).SortRoleColumnCommand.Execute(null);
        }

        private void UserName_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as PermissionsViewModel).SortUserNameColumnCommand.Execute(null);
        }

        private void UserRole_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as PermissionsViewModel).SortUserRoleColumnCommand.Execute(null);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
