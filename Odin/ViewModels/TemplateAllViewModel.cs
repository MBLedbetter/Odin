using Mvvm;
using Odin.Views;
using OdinModels;
using OdinServices;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class TemplateAllViewModel : ViewModelBase
    {
        #region Commands
        
        public ICommand EditSelectedTemplateCommand
        {
            get
            {
                if (_editSelectedTemplateCommand == null)
                {
                    _editSelectedTemplateCommand = new RelayCommand(param => EditSelectedTemplate());
                }
                return _editSelectedTemplateCommand;
            }
        }
        private RelayCommand _editSelectedTemplateCommand;

        public ICommand ExportCommand
        {
            get
            {
                if (_export == null)
                {
                    _export = new RelayCommand(param => ExportAll());
                }
                return _export;
            }
        }
        private RelayCommand _export;

        public ICommand ExportSelectedCommand
        {
            get
            {
                if (_exportSelected == null)
                {
                    _exportSelected = new RelayCommand(param => ExportSelectedItem());
                }
                return _exportSelected;
            }
        }
        private RelayCommand _exportSelected;

        #endregion // Commands

        #region Properties

        /// <summary>
        ///     Gets or sets the Excel Service property
        /// </summary>
        private ExcelService ExcelService { get; set; }

        /// <summary>
        ///     Gets or sets the Item Service propery
        /// </summary>
        public ItemService ItemService { get; set; }

        /// <summary>
        ///     The current selected template
        /// </summary>
        public ItemObject SelectedTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the template list property
        /// </summary>
        public List<ItemObject> TemplateList
        {
            get
            {
                return _templateList;
            }
            set
            {
                _templateList = value;
                OnPropertyChanged("TemplateList");
            }
        }
        private List<ItemObject> _templateList = new List<ItemObject>();

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     open the template view / viewmodel to edit the selected template
        /// </summary>
        private void EditSelectedTemplate()
        {
            TemplateView window = new TemplateView();
            window.DataContext = new TemplateViewModel(this.ItemService, "Update", this.SelectedTemplate);
            if (window.ShowDialog() == false)
            {
                PopulateTemplateList();
            }
        }

        /// <summary>
        ///     Exports all existing templates
        /// </summary>
        private void ExportAll()
        {
            ExcelService.CreateTemplateWorkbook(this.TemplateList);
        }

        /// <summary>
        ///     Exports only the selected item
        /// </summary>
        private void ExportSelectedItem()
        {
            List<ItemObject> templateList = new List<ItemObject>();
            templateList.Add(this.SelectedTemplate);
            ExcelService.CreateTemplateWorkbook(templateList);

        }

        /// <summary>
        ///     Load in all the existing templates into the viewmodel TemplateList
        /// </summary>
        private void PopulateTemplateList()
        {
            List<string> templateNames = GlobalData.TemplateNames;
            List<ItemObject> newTemplateList = new List<ItemObject>();
            templateNames.Sort();
            foreach(string name in templateNames)
            {
                newTemplateList.Add(this.ItemService.RetrieveTemplate(name));
            }
            this.TemplateList = newTemplateList;
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the template all view model
        /// </summary>
        /// <param name="itemService"></param>
        public TemplateAllViewModel(ItemService itemService, ExcelService excelService)
        {
            if (itemService == null) { throw new ArgumentNullException("itemService"); }
            if (excelService == null) { throw new ArgumentNullException("excelService"); }
            this.ItemService = itemService;
            this.ExcelService = excelService;
            PopulateTemplateList();
        }

        #endregion // Constructor
    }
}
