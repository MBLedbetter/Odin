using Mvvm;
using OdinModels;
using OdinServices;
using Odin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;
using System.Linq;

namespace Odin.ViewModels
{
    public class FieldEditViewModel : INotifyPropertyChanged
    {
        #region Commands

        public ICommand AddNewCategoryCommand
        {
            get
            {
                if (_createCategory == null)
                {
                    _createCategory = new RelayCommand(param => CreateField("Category"));
                }
                return _createCategory;
            }
        }
        private RelayCommand _createCategory;

        public ICommand AddNewLicenseCommand
        {
            get
            {
                if (_createLicense == null)
                {
                    _createLicense = new RelayCommand(param => CreateField("License"));
                }
                return _createLicense;
            }
        }
        private RelayCommand _createLicense;

        public ICommand AddNewMetaDescriptionCommand
        {
            get
            {
                if (_createMetaDescription == null)
                {
                    _createMetaDescription = new RelayCommand(param => CreateField("Meta Description"));
                }
                return _createMetaDescription;
            }
        }
        private RelayCommand _createMetaDescription;

        public ICommand AddNewPropertyCommand
        {
            get
            {
                if (_createProperty == null)
                {
                    _createProperty = new RelayCommand(param => CreateField("Property"));
                }
                return _createProperty;
            }
        }
        private RelayCommand _createProperty;

        public ICommand AddNewTerritoryCommand
        {
            get
            {
                if (_createTerritory == null)
                {
                    _createTerritory = new RelayCommand(param => CreateField("Territory"));
                }
                return _createTerritory;
            }
        }
        private RelayCommand _createTerritory;

        public ICommand EditCategoryCommand
        {
            get
            {
                if (_editCategory == null)
                {
                    _editCategory = new RelayCommand(param => EditField("Category"));
                }
                return _editCategory;
            }
        }
        private RelayCommand _editCategory;

        public ICommand EditLicenseCommand
        {
            get
            {
                if (_editLicense == null)
                {
                    _editLicense = new RelayCommand(param => EditField("License"));
                }
                return _editLicense;
            }
        }
        private RelayCommand _editLicense;

        public ICommand EditPropertyCommand
        {
            get
            {
                if (_editProperty == null)
                {
                    _editProperty = new RelayCommand(param => EditField("Property"));
                }
                return _editProperty;
            }
        }
        private RelayCommand _editProperty;

        public ICommand EditCategoryTerritory
        {
            get
            {
                if (_editTerritory == null)
                {
                    _editTerritory = new RelayCommand(param => EditField("Territory"));
                }
                return _editTerritory;
            }
        }
        private RelayCommand _editTerritory;

        public ICommand RemoveCategoryCommand
        {
            get
            {
                if (_removeCategory == null)
                {
                    _removeCategory = new RelayCommand(param => RemoveField("Category"));
                }
                return _removeCategory;
            }
        }
        private RelayCommand _removeCategory;

        public ICommand RemoveLicenseCommand
        {
            get
            {
                if (_removeLicense == null)
                {
                    _removeLicense = new RelayCommand(param => RemoveField("License"));
                }
                return _removeLicense;
            }
        }
        private RelayCommand _removeLicense;

        public ICommand RemoveMetaDescriptionCommand
        {
            get
            {
                if (_removeMetaDescription == null)
                {
                    _removeMetaDescription = new RelayCommand(param => RemoveField("Meta Description"));
                }
                return _removeMetaDescription;
            }
        }
        private RelayCommand _removeMetaDescription;

        public ICommand RemovePropertyCommand
        {
            get
            {
                if (_removeProperty == null)
                {
                    _removeProperty = new RelayCommand(param => RemoveField("Property"));
                }
                return _removeProperty;
            }
        }
        private RelayCommand _removeProperty;

        public ICommand RemoveTerritoryCommand
        {
            get
            {
                if (_removeTerritory == null)
                {
                    _removeTerritory = new RelayCommand(param => RemoveField("Territory"));
                }
                return _removeTerritory;
            }
        }
        private RelayCommand _removeTerritory;

        #endregion // Commands

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Events

        #region Public Properties

        /// <summary>
        ///     List of all available categories
        /// </summary>
        public ObservableCollection<string> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new ObservableCollection<string>();
                }
                return _categories;
            }
            private set
            {
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }
        private ObservableCollection<string> _categories;
        
        /// <summary>
        ///     Variable for textbox, used for creating new category
        /// </summary>
        public string CategoryInput
        {
            get
            {
                return _categoryInput;
            }
            set
            {
                if (CategoryInput != value)
                {
                    _categoryInput = value;
                    OnPropertyChanged("CategoryInput");
                }
            }
        }
        private string _categoryInput;

        /// <summary>
        ///     Gets or sets the EmailService
        /// </summary>
        public EmailService EmailService { get; set; }

        /// <summary>
        ///     Gets or sets the ItemService
        /// </summary>
        public ItemService ItemService { get; set; }

        /// <summary>
        ///     List of all available licenses
        /// </summary>
        public ObservableCollection<string> Licenses
        {
            get
            {
                if (_licenses == null)
                {
                    _licenses = new ObservableCollection<string>();
                }
                return _licenses;
            }
            private set
            {
                _licenses = value;
                OnPropertyChanged("Licenses");
            }
        }
        private ObservableCollection<string> _licenses;

        /// <summary>
        ///     List of all available meta descriptions
        /// </summary>
        public ObservableCollection<string> MetaDescriptions
        {
            get
            {
                if (_metaDescriptions == null)
                {
                    _metaDescriptions = new ObservableCollection<string>();
                }
                return _metaDescriptions;
            }
            private set
            {
                _metaDescriptions = value;
                OnPropertyChanged("MetaDescriptions");
            }
        }
        private ObservableCollection<string> _metaDescriptions;

        /// <summary>
        ///     List of all available properties
        /// </summary>
        public ObservableCollection<string> Properties
        {
            get
            {
                if (_properties == null)
                {
                    _properties = new ObservableCollection<string>();
                }
                return _properties;
            }
            private set
            {
                _properties = value;
                OnPropertyChanged("Properties");
            }
        }
        private ObservableCollection<string> _properties;
        
        /// <summary>
        ///     The item that is selected in the view that this view model is bound to.
        /// </summary>
        public string SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                if (SelectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged("SelectedCategory");
                }
            }
        }
        private string _selectedCategory;

        /// <summary>
        ///     Selected meta description from Meta Description List
        /// </summary>
        public string SelectedMetaDescription
        {
            get
            {
                return _selectedMetaDescription;
            }
            set
            {
                if (SelectedCategory != value)
                {
                    _selectedMetaDescription = value;
                    OnPropertyChanged("SelectedMetaDescription");
                }
            }
        }
        private string _selectedMetaDescription;

        /// <summary>
        ///     Selected license from Licenses List
        /// </summary>
        public string SelectedLicense
        {
            get
            {
                return _selectedLicense;
            }
            set
            {
                if (SelectedCategory != value)
                {
                    _selectedLicense = value;
                    OnPropertyChanged("SelectedLicense");
                }
            }
        }
        private string _selectedLicense;

        /// <summary>
        ///     Selected license from Licenses List
        /// </summary>
        public string SelectedProperty
        {
            get
            {
                return _selectedProperty;
            }
            set
            {
                if (SelectedCategory != value)
                {
                    _selectedProperty = value;
                    OnPropertyChanged("SelectedProperty");
                }
            }
        }
        private string _selectedProperty;

        /// <summary>
        ///     Selected territory from Territories List
        /// </summary>
        public string SelectedTerritory
        {
            get
            {
                return _selectedTerritory;
            }
            set
            {
                if (SelectedCategory != value)
                {
                    _selectedTerritory = value;
                    OnPropertyChanged("SelectedTerritory");
                }
            }
        }
        private string _selectedTerritory;

        /// <summary>
        ///     List of all available territories
        /// </summary>
        public ObservableCollection<string> Territories
        {
            get
            {
                if (_territories == null)
                {
                    _territories = new ObservableCollection<string>();
                }
                return _territories;
            }
            private set
            {
                _territories = value;
                OnPropertyChanged("Territories");
            }
        }
        private ObservableCollection<string> _territories;
        
        #endregion // Public Properties

        #region Methods

        /// <summary>
        ///     Adds 'categoryInput' to categories table and reloads the table
        /// </summary>
        public void CreateField(string field)
        {
            FieldEditWindowView window = new FieldEditWindowView();
            window.DataContext = new FieldEditWindowViewModel(fieldType: field, fieldValue: "", fieldStatus: "Add", itemService: ItemService, emailService: EmailService);
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                string newValue = "";
                switch (field)
                {
                    case "Category":
                        newValue = (window.DataContext as FieldEditWindowViewModel).NewFieldValue;
                        Categories.Add(newValue);
                        Categories = new ObservableCollection<string>(Categories.OrderBy(i => i));
                        break;
                    case "License":
                        newValue = (window.DataContext as FieldEditWindowViewModel).NewFieldValue;
                        Licenses.Add(newValue);
                        Licenses = new ObservableCollection<string>(Licenses.OrderBy(i => i));
                        break;
                    case "Meta Description":
                        newValue = (window.DataContext as FieldEditWindowViewModel).NewFieldValue;
                        MetaDescriptions.Add(newValue);
                        MetaDescriptions = new ObservableCollection<string>(MetaDescriptions.OrderBy(i => i));
                        break;
                    case "Territory":
                        newValue = (window.DataContext as FieldEditWindowViewModel).NewFieldValue;
                        Territories.Add(newValue);
                        Territories = new ObservableCollection<string>(Territories.OrderBy(i => i));
                        break;
                }
            }
        }

        /// <summary>
        ///     Edit the selected field of current tab
        /// </summary>
        /// <param name="field"></param>
        public void EditField(string field)
        {
            switch (field)
            {
                case "Category":
                    if (SelectedCategory!= null)
                    {
                        FieldEditWindowView window = new FieldEditWindowView();
                        window.DataContext = new FieldEditWindowViewModel("Category", SelectedCategory, "Update", ItemService, EmailService);
                        window.ShowDialog();
                        if(window.DialogResult == true)
                        {
                            string newValue = (window.DataContext as FieldEditWindowViewModel).NewFieldValue;
                            string originalValue = (window.DataContext as FieldEditWindowViewModel).OriginalFieldValue;
                            Categories.Remove(originalValue);
                            Categories.Add(newValue);
                            Categories = new ObservableCollection<string>(Categories.OrderBy(i => i));
                        }
                    }
                    else { MessageBox.Show("Please Select a category to edit"); }
                    break;
            }
        }

        /// <summary>
        ///     Loads in the lists of fields that can be edited
        /// </summary>
        public void LoadFields(bool includeRequests)
        {
            Categories = new ObservableCollection<string>();
            Licenses = new ObservableCollection<string>();
            Territories = new ObservableCollection<string>();
            try
            {
                List<string> CategoryList = GlobalData.ReturnWebCategoryListValues();
                List<string> LicenseList = ItemService.RetrieveLicensePropertyList();
                List<string> TerritoryList = GlobalData.Territories;
                List<string> MetaDescriptionList = GlobalData.MetaDescriptions;
                CategoryList.Sort();
                TerritoryList.Sort();
                foreach (string i in CategoryList)
                {
                    Categories.Add(i);
                }
                foreach (string i in MetaDescriptionList)
                {
                    MetaDescriptions.Add(i);
                }
                foreach (string i in LicenseList)
                {
                    Licenses.Add(i);
                }
                foreach (string i in TerritoryList)
                {
                    Territories.Add(i);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to retrieve editable field values.", ex.ToString());
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        ///     Removes Selected category from list and reloads the list
        /// </summary>
        public void RemoveField(string field)
        {
            bool pass = false;
            switch (field)
            {
                case "Category":
                    if (SelectedCategory != null)
                    {
                        try
                        {
                            ItemService.RemoveCategory(SelectedCategory);
                            Categories.Remove(SelectedCategory);
                            pass = true;
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("Could not remove selected Category.", ex.ToString());
                        }
                    }
                    else { MessageBox.Show("No Category selected to remove"); }
                    break;
                case "License":
                    if (SelectedLicense != null)
                    {
                        try
                        {
                            ItemService.RemoveLicense(SelectedLicense);
                            Licenses.Remove(SelectedLicense);
                            pass = true;
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("Could not remove selected License.", ex.ToString());
                        }
                    }
                    else { MessageBox.Show("No License selected to remove"); }
                    break;
                case "Meta Description":
                    if (SelectedMetaDescription != null)
                    {
                        try
                        {
                            ItemService.RemoveMetaDescription(SelectedMetaDescription);
                            MetaDescriptions.Remove(SelectedMetaDescription);
                            pass = true;
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("Could not remove selected Meta Description.", ex.ToString());
                        }
                    }
                    else { MessageBox.Show("No License selected to remove"); }
                    break;
                case "Property":
                    if (SelectedProperty != null)
                    {
                        try
                        {
                            ItemService.RemoveProperty(SelectedProperty);
                            Properties.Remove(SelectedProperty);
                            pass = true;
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("Could not remove selected Property.", ex.ToString());
                        }
                    }
                    else { MessageBox.Show("No Property selected to remove"); }
                    break;
                case "Territory":
                    if (SelectedTerritory != null)
                    {
                        try
                        {
                            ItemService.RemoveTerritory(SelectedTerritory);
                            Territories.Remove(SelectedTerritory);
                            pass = true;
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("Could not remove selected Territory.", ex.ToString());
                        }
                    }
                    else { MessageBox.Show("No Territory selected to remove"); }
                    break;
            }
            if(pass)
            {
                MessageBox.Show(field + " Removed");
            }
        }

        #endregion // Methods

        #region Constructor

        public FieldEditViewModel(ItemService itemService, EmailService emailService)
        {
            if (itemService == null) { throw new ArgumentNullException("itemService"); }
            if (emailService == null) { throw new ArgumentNullException("emailService"); }
            this.ItemService = itemService;
            this.EmailService = emailService;
            this.LoadFields(true);
        }

        #endregion // Constructor

    }
}
