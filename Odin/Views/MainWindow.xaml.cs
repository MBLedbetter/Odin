using System.Windows;
using Odin.ViewModels;
using System.Windows.Input;
using OdinModels;
using System.Collections.Generic;

namespace Odin.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	partial class MainWindow : Window
	{
        public MainWindow()
        {
            App.WireUp();
            App.LoadGlobalValues();
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(App.ItemService, App.OptionService, App.ExcelService, App.WorkbookReader, App.EmailService);
        }

        #region Event Handlers

        private void ItemListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (this.DataContext as MainWindowViewModel).EditSelectedItemCommand.Execute(null);
        }
        private void ErrorListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (this.DataContext as MainWindowViewModel).EditSelectedErrorCommand.Execute(null);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainWindowViewModel).SubmitItemsCommand.Execute(null);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainWindowViewModel).SaveItemsCommand.Execute(null);
        }

        private void CreateFullExcel_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainWindowViewModel).CreateFullExcelCommand.Execute(null);
        }

        #endregion // Event Handlers

        /// <summary>
        ///     On window loaded 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> notifications = App.OptionRepository.RetrieveNotifications("User");
            if (notifications.Count > 0)
            {
                AlertView window = new AlertView()
                {
                    DataContext = new AlertViewModel(notifications, "Alert", "The following adjustments have been made to Odin since last login.")
                };
                window.ShowDialog();
                App.OptionRepository.UpdateUserNotification();
            }
        }

        private void Ribbon_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
