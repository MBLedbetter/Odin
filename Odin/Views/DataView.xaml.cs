
using Odin.ViewModels;
using System.Windows;

namespace Odin.Views
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataView : Window
    {
        public DataView()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Calls SortExistingItemIdsCommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExistingItemIds_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DataViewModel).SortExistingItemIdsCommand.Execute(null);
        }

        /// <summary>
        ///     Calls SortTab2ItemIdsCommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab2ItemIds_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DataViewModel).SortTab2ItemIdsCommand.Execute(null);
        }

        /// <summary>
        ///     Calls SortTab2ItemUpcsCommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab2Upcs_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DataViewModel).SortTab2ItemUpcsCommand.Execute(null);
        }

        /// <summary>
        ///     Calls SortTab3ParentAsinsCommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab3ParentAsins_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DataViewModel).SortTab3ParentAsinsCommand.Execute(null);
        }

        /// <summary>
        ///     Calls SortTab3VariantIdsCommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab3VariantIds_Column_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DataViewModel).SortTab3VariantIdsCommand.Execute(null);
        }
    }
}
