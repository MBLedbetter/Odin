using Mvvm;
using OdinModels;
using OdinServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class ItemUpdateReportViewModel : ViewModelBase
    {
        #region Commands

        public ICommand PullReportCommand
        {
            get
            {
                if (_pullReportCommand == null)
                {
                    _pullReportCommand = new RelayCommand(param => PullReport());
                }
                return _pullReportCommand;
            }
        }
        private RelayCommand _pullReportCommand;

        #endregion // Commands

        #region Properties

        /// <summary>
        ///     Gets or sets the Background Worder
        /// </summary>
        private BackgroundWorker BackgroundWorker { get; set; }

        private string BackgroundWorkerState = string.Empty;

        /// <summary>
        ///     Gets or sets the models ExcelService
        /// </summary>
        ExcelService ExcelService { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        ///     Gets or sets Items
        /// </summary>
        private ObservableCollection<ItemObject> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }
        private ObservableCollection<ItemObject> _items = new ObservableCollection<ItemObject>();

        /// <summary>
        ///     Gets or sets the models ItemService
        /// </summary>
        ItemService ItemService { get; set; }
        
        /// <summary>
        ///     Gets or sets ProgressText
        /// </summary>
        public string ProgressText
        {
            get
            {
                return _progressText;
            }
            set
            {
                _progressText = value;
                OnPropertyChanged("ProgressText");
            }
        }
        private string _progressText = string.Empty;

        /// <summary>
        ///     Gets or sets the model's Report End Date
        /// </summary>
        public DateTime ReportEndDate
        {
            get
            {
                return _reportEndDate;
            }
            set
            {
                _reportEndDate = value;
                OnPropertyChanged("ReportEndDate");
            }
        }
        private DateTime _reportEndDate = DateTime.Today;

        /// <summary>
        ///     Gets or sets the model's Report Start Date
        /// </summary>
        public DateTime ReportStartDate
        {
            get
            {
                return _reportStartDate;
            }
            set
            {
                _reportStartDate = value;
                OnPropertyChanged("ReportStartDate");
            }
        }
        private DateTime _reportStartDate = DateTime.Today;

        #endregion // Properties

        #region Methods


        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.ProgressText = "Searching for Item Updates...";
            List<string> itemIds = ItemService.RetrieveUpdateItemReportItemIds(ReportEndDate, ReportStartDate);

            int count = 1;
            foreach (string itemId in itemIds)
            {
                int num = count - 1;
                try
                {
                    this.Items.Add(ItemService.RetrieveItem(itemId, count));
                    this.ProgressText = "Retrieving item data for " + count + " of " + itemIds.Count.ToString();
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError("Failed to Retrieve data for Item " + this.Items[num].ItemId + ".", ex.ToString());
                    break;
                }
                count++;
            }
            this.ProgressText = "Writing to excel sheet...";
            ExcelService.CreateItemWorkbook("**Item", this.Items, this.FilePath);
            this.ProgressText = "Report Complete";

            this.BackgroundWorkerState = "";
            this.BackgroundWorker = new BackgroundWorker();
        }

        /// <summary>
        ///     Pulls item update record report
        /// </summary>
        public void PullReport()
        {
            SaveFileDialog dlg = new SaveFileDialog()
            {
                Filter = "Excel Workbooks (*.xlsx)|*.xlsx"
            };
            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            this.FilePath = dlg.FileName;

            BackgroundWorker.DoWork += BackgroundWorker_DoWork;
            BackgroundWorker.WorkerReportsProgress = true;
            BackgroundWorker.RunWorkerAsync();
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the ItemUpdateReport View Model
        /// </summary>
        /// <param name="itemService"></param>
        /// <param name="excelService"></param>
        public ItemUpdateReportViewModel(ItemService itemService, ExcelService excelService)
        {
            this.BackgroundWorker = new BackgroundWorker();
            this.ExcelService = excelService ?? throw new ArgumentNullException("excelService");
            this.ItemService = itemService ?? throw new ArgumentNullException("itemService");
        }

        #endregion // Constructor
    }
}
