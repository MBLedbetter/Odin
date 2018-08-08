using Mvvm;
using Odin.Views;
using OdinModels;
using OdinServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class ExcelGeneratorViewModel : ViewModelBase
    {
        #region Commands

        public ICommand SaveExcelLayoutCommand
        {
            get
            {
                if (_saveExcelLayoutCommand == null)
                {
                    _saveExcelLayoutCommand = new RelayCommand(param => SaveExcelLayout());
                }
                return _saveExcelLayoutCommand;
            }
        }
        private RelayCommand _saveExcelLayoutCommand;

        /*
        public ICommand SetOptionCommand
        {
            get
            {
                if (_setOptionCommand == null)
                {
                    _setOptionCommand = new RelayCommand(param => SetCellOption());
                }
                return _setOptionCommand;
            }
        }
        private RelayCommand _setOptionCommand;
        */

        public ICommand ShiftDownCommand
        {
            get
            {
                if (_shiftDownCommand == null)
                {
                    _shiftDownCommand = new RelayCommand(param => MoveExcelCell("DOWN"));
                }
                return _shiftDownCommand;
            }
        }
        private RelayCommand _shiftDownCommand;

        public ICommand ShiftLeftCommand
        {
            get
            {
                if (_shiftLeftCommand == null)
                {
                    _shiftLeftCommand = new RelayCommand(param => RemoveFieldFromExcelColumns());
                }
                return _shiftLeftCommand;
            }
        }
        private RelayCommand _shiftLeftCommand;

        public ICommand ShiftRightCommand
        {
            get
            {
                if (_shiftRightCommand == null)
                {
                    _shiftRightCommand = new RelayCommand(param => AddFieldToExcelColumns());
                }
                return _shiftRightCommand;
            }
        }
        private RelayCommand _shiftRightCommand;

        public ICommand ShiftUpCommand
        {
            get
            {
                if (_shiftUpCommand == null)
                {
                    _shiftUpCommand = new RelayCommand(param => MoveExcelCell("UP"));
                }
                return _shiftUpCommand;
            }
        }
        private RelayCommand _shiftUpCommand;

        public ICommand SwapCommand
        {
            get
            {
                if (_swapCommand == null)
                {
                    _swapCommand = new RelayCommand(param => SwapCell());
                }
                return _swapCommand;
            }
        }
        private RelayCommand _swapCommand;

        #endregion // Commands

        #region Properties

        /// <summary>
        ///     List of customers
        /// </summary>
        public List<string> CustomerList
        {
            get { return _customerList; }
            set { _customerList = value; OnPropertyChanged("CustomerList"); }
        }
        private List<string> _customerList = new List<string>();

        /// <summary>
        ///     List of existing excel column cells
        /// </summary>
        public ObservableCollection<ExcelCell> ExcelColumns
        {
            get { return _excelColumns; }
            set { _excelColumns = value; OnPropertyChanged("ExcelColumns"); }
        }
        private ObservableCollection<ExcelCell> _excelColumns = new ObservableCollection<ExcelCell>();
        
        /// <summary>
        ///     Gets or sets the ExcelService
        /// </summary>
        public ExcelService ExcelService { get; set; }

        /// <summary>
        ///     Gets or sets the ExcelCustomer of the given template
        /// </summary>
        public string ExcelCustomer
        {
            get
            {
                return _excelCustomer;
            }
            set
            {
                if (_excelCustomer != value)
                {
                    _excelCustomer = value;
                    OnPropertyChanged("ExcelCustomer");
                }
            }
        }
        private string _excelCustomer = string.Empty;

        /// <summary>
        ///     Gets or sets the excelId coresponding with the current Excel template
        /// </summary>
        public int ExcelId
        {
            get
            {
                return _excelId;
            }
            set
            {
                _excelId = value;
                OnPropertyChanged("ExcelId");
            }
        }
        private int _excelId = 0;

        /// <summary>
        ///     List of existing excel templates
        /// </summary>
        public List<string> ExcelLists
        {
            get { return _excelLists; }
            set { _excelLists = value; OnPropertyChanged("ExcelLists"); }
        }
        private List<string> _excelLists = new List<string>();

        /// <summary>
        ///     Gets or sets the selected excel layout
        /// </summary>
        public string ExcelLayout
        {
            get { return _excelLayout; }
            set
            {
                if (this.ExcelLayout != value)
                {
                    _excelLayout = value;
                    LoadExcelLayout(value);
                    OnPropertyChanged("ExcelLayout");
                }
            }
        }
        private string _excelLayout = string.Empty;

        /// <summary>
        ///     List of field options for field list
        /// </summary>
        public List<string> Fields
        {
            get { return _fields; }
            set { _fields = value; OnPropertyChanged("Fields"); }
        }
        private List<string> _fields = new List<string>();

        /// <summary>
        ///     Gets or sets the isnew flag
        /// </summary>
        public string IsNew
        {
            get { return _isNew; }
            set { _isNew = value; OnPropertyChanged("IsNew"); }
        }
        private string _isNew = "False";

        /// <summary>
        ///     Gets or sets the ItemService
        /// </summary>
        public ItemService ItemService { get; set; }

        /// <summary>
        ///     List of options for option list
        /// </summary>
        public List<string> Options
        {
            get { return _options; }
            set { _options = value; OnPropertyChanged("Options"); }
        }
        private List<string> _options = new List<string>();
        
        /// <summary>
        ///     List of field options for product type
        /// </summary>
        public string ProductType
        {
            get { return _productType; }
            set { _productType = value; OnPropertyChanged("ProductType"); }
        }
        private string _productType = string.Empty;

        /// <summary>
        ///     List of options for the product type
        /// </summary>
        public List<string> ProductTypeList
        {
            get { return _productTypeList; }
            set { _productTypeList = value; OnPropertyChanged("ProductTypeList"); }
        }
        private List<string> _productTypeList = new List<string>();

        /// <summary>
        ///     Gets or sets the selected excel column
        /// </summary>
        public ExcelCell SelectedExcelColumn
        {
            get { return _selectedExcelColumn; }
            set { _selectedExcelColumn = value; OnPropertyChanged("SelectedExcelColumn"); }
        }
        private ExcelCell _selectedExcelColumn = new ExcelCell();

        /// <summary>
        ///     Gets or sets the selected excel template
        /// </summary>
        public string SelectedField
        {
            get { return _selectedField; }
            set { _selectedField = value; OnPropertyChanged("SelectedField"); }
        }
        private string _selectedField = string.Empty;

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Adds the selected field to the bottom of the excel columns
        /// </summary>
        public void AddFieldToExcelColumns()
        {
            string field = this.SelectedField;
            if (this.SelectedField == "-TEXT-")
            {
                TextPromptView textWindow = new TextPromptView();
                textWindow.DataContext = new TextPromptViewModel();
                textWindow.ShowDialog();
                if (textWindow.DialogResult == true)
                {
                    field = '"' + (textWindow.DataContext as TextPromptViewModel).TextValue + '"';
                }
                else return;
            }
            ExcelCell newCell = new ExcelCell(this.ExcelId, this.ExcelColumns.Count + 1, field, "", this.ExcelCustomer, ExcelService.ReturnColumLetter(this.ExcelColumns.Count + 1));
            this.ExcelColumns.Add(newCell);
        }

        /// <summary>
        ///     Run metods on viewmodel startup
        /// </summary>
        public void ExcelGeneratorStartUp()
        {
            this.ExcelLists = RetrieveExcelLayoutNames();
            this.ExcelLayout = "-NEW-";
            this.IsNew = "True";
            this.Fields = RetrieveFieldValues();
            this.CustomerList = RetrieveExcelCustomers();
            this.ProductTypeList = GlobalData.ProductGoups;
        }

        /// <summary>
        ///     Loads in the excel layout data for the selected excel layout
        /// </summary>
        public void LoadExcelLayout(string layoutName)
        {
            if (layoutName != "-NEW-")
            {
                this.ExcelColumns = ExcelService.RetrieveExcelLayoutData(layoutName);
                this.ExcelId = ExcelService.RetrieveExcelLayoutId(layoutName);
                this.ExcelCustomer = ExcelService.RetrieveExcelLayoutCustomer(layoutName);
                this.ProductType = ExcelService.RetrieveExcelLayoutProductType(layoutName);
                this.IsNew = "False";
                if (this.ExcelId==0)
                {
                    this.ExcelId = ExcelLists.Count + 1;
                }
                RenumberExcelColumns();
            }
            if(layoutName == "-NEW-")
            {
                this.ExcelColumns = new ObservableCollection<ExcelCell>();
                this.ExcelId = ExcelLists.Count + 1;
                this.ExcelCustomer = "";
                this.ProductType = "";
                this.IsNew = "True";
            }
        }

        /// <summary>
        ///     Shifts the selected excel column up or down 1
        /// </summary>
        public void MoveExcelCell(string direction)
        {
            ExcelCell newCell = new ExcelCell();
            if (this.SelectedExcelColumn != null)
            {
                int cellLocation = this.SelectedExcelColumn.ColumnNumber - 1;
                // Shift cell up 1 space
                if (direction == "UP")
                {
                    if (cellLocation == 0) { return; }
                    ExcelCell selectedCell = this.ExcelColumns[cellLocation];
                    ExcelCell replacedCell = this.ExcelColumns[cellLocation - 1];
                    if (selectedCell != null)
                    {
                        selectedCell.ColumnNumber++;
                        replacedCell.ColumnNumber--;
                        this.ExcelColumns[cellLocation - 1] = selectedCell;
                        this.ExcelColumns[cellLocation] = replacedCell;
                        newCell = selectedCell;
                    }
                }
                // Shift cell down 1 space
                else
                {
                    if (cellLocation == ExcelColumns.Count - 1) { return; }
                    ExcelCell selectedCell = this.ExcelColumns[cellLocation];
                    ExcelCell replacedCell = this.ExcelColumns[cellLocation + 1];
                    if (selectedCell != null)
                    {
                        selectedCell.ColumnNumber--;
                        replacedCell.ColumnNumber++;
                        this.ExcelColumns[cellLocation + 1] = selectedCell;
                        this.ExcelColumns[cellLocation] = replacedCell;
                        newCell = selectedCell;
                    }
                }
                RenumberExcelColumns();
                this.SelectedExcelColumn = newCell;
            }
        }

        /// <summary>
        ///     Removes the selected excel column from the excel column list
        /// </summary>
        public void RemoveFieldFromExcelColumns()
        {
            if (SelectedExcelColumn != null)
            {
                int columnNum = this.SelectedExcelColumn.ColumnNumber;
                ExcelColumns.Remove(ExcelColumns.Where(i => i.ColumnNumber == columnNum).Single());
                RenumberExcelColumns();
            }
        }

        /// <summary>
        ///     Adjusts the numbers of the excelcolumns
        /// </summary>
        public void RenumberExcelColumns()
        {
            int count = 1;
            foreach (ExcelCell x in this.ExcelColumns)
            {
                x.ColumnNumber = count;
                x.ColumnLetter = ExcelService.ReturnColumLetter(count);
                count++;
            }
            ObservableCollection<ExcelCell>  newExcelColumns = new ObservableCollection<ExcelCell>(ExcelColumns.OrderBy(i => i.ColumnNumber));

            this.ExcelColumns = newExcelColumns;
        }
        
        /// <summary>
        ///     Retrieve a list of customers
        /// </summary>
        public List<string> RetrieveExcelCustomers()
        {
            List<string> customers = new List<string>();
            foreach(KeyValuePair<string,string>cust in GlobalData.Customers)
            {
                customers.Add(cust.Key);
            }
            customers.Sort();
            return customers;
        }

        /// <summary>
        ///     Retrieves a list of all existing layout names. Includes New
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveExcelLayoutNames()
        {
            List<string> excelNames = new List<string>();
            try
            {
                foreach (Layout layout in ExcelService.RetrieveExcelLayouts())
                {
                    excelNames.Add(layout.Name);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to retrieve the excel layout name from the database.", ex.ToString());
            }
            excelNames.Sort();
            excelNames.Insert(0, "-NEW-");
            return excelNames;
        }

        /// <summary>
        ///     Retrieves a list of all available field values. Includes empty
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveFieldValues()
        {
            List<string> fields = new List<string>();
            try
            {
                fields = ExcelService.RetrieveFieldValues();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to retrieve the field data.", ex.ToString());
            }
            fields.Insert(0, "-TEXT-");
            fields.Insert(0, "- EMPTY -");
            return fields;
        }
        
        /// <summary>
        ///     Saves the current excel layout
        /// </summary>
        public void SaveExcelLayout()
        {
            if (ExcelColumns != new ObservableCollection<ExcelCell>())
            {
                bool result = true;
                try
                { 
                    if (this.ExcelLayout == "-NEW-")
                    {
                        // int newId = RetrieveExcelLayoutNames().Count + 1;
                        TextPromptView textWindow = new TextPromptView();
                        textWindow.DataContext = new TextPromptViewModel();
                        textWindow.ShowDialog();
                        if (textWindow.DialogResult == true)
                        {
                            string name = (textWindow.DataContext as TextPromptViewModel).TextValue;
                            if (this.ExcelLists.Contains(name))
                            {
                                MessageBox.Show(name + " is already being used by another layout. Please select another name.");
                                result = false;
                            }
                            if (result)
                            {
                                ExcelService.InsertExcelLayout(name, this.ExcelCustomer, this.ProductType);
                                int newId = ExcelService.RetrieveExcelLayoutId(name);
                                foreach (ExcelCell cell in this.ExcelColumns)
                                {
                                    cell.ExcelId = newId;
                                }
                                ExcelService.InsertExcelLayoutColumns(this.ExcelColumns);
                            }
                        }
                    }
                    else
                    {
                        int layoutId = Convert.ToInt32(ExcelColumns[0].ExcelId);
                        ExcelService.RemoveExcelLayoutColumns(layoutId);
                        ExcelService.InsertExcelLayoutColumns(this.ExcelColumns);
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError("Odin could not insert the excel layout information.", ex.ToString());
                }
                if (result)
                {
                    MessageBox.Show("Excel Layout Saved.");
                }
                RetrieveExcelLayoutNames();
            }
        }

        /// <summary>
        ///     Swaps the field value of the selected excel column with the selected field 
        /// </summary>
        public void SwapCell()
        {
            string field = this.SelectedField;
            if (this.SelectedField == "-TEXT-")
            {
                TextPromptView textWindow = new TextPromptView();
                textWindow.DataContext = new TextPromptViewModel();
                textWindow.ShowDialog();
                if (textWindow.DialogResult == true)
                {
                    field = '"' + (textWindow.DataContext as TextPromptViewModel).TextValue + '"';
                }
                else return;
            }
            this.SelectedExcelColumn.Field = field;
            RenumberExcelColumns();

        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the ExcelGeneratorViewModel
        /// </summary>
        public ExcelGeneratorViewModel(ExcelService excelService, ItemService itemService)
        {
            if (excelService == null) { throw new ArgumentNullException("excelService"); }
            if (itemService == null) { throw new ArgumentNullException("itemService"); }
            this.ExcelService = excelService;
            this.ItemService = itemService;
            ExcelGeneratorStartUp();
        }

        #endregion // Constructor

    }
}
