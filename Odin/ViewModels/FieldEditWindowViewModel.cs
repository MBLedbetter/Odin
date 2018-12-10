using OdinModels;
using OdinServices;
using System;
using System.ComponentModel;
using System.Windows;

namespace Odin.ViewModels
{
    public class FieldEditWindowViewModel
    {

        #region Properties
        
        public EmailService EmailService { get; set; }

        public ItemService ItemService { get; set; }

        public string NewFieldValue
        {
            get
            {
                return _newFieldValue;
            }
            set
            {
                if (NewFieldValue != value)
                {
                    _newFieldValue = value;
                    OnPropertyChanged("NewFieldValue");
                }
            }
        }

        private string _newFieldValue { get; set; }
                
        /// <summary>
        ///     Tracks if selected field is being updated or added
        /// </summary>
        private string FieldStatus { get; set; }

        private string FieldType { get; set; }

        public string OriginalFieldValue { get; set; }

        /// <summary>
        ///     License Associated with Property field types
        /// </summary>
        private string PropertyLicense { get; set; }

        public string TextboxLabel { get; set; }

        public string ViewTitle { get; set; }

        #endregion // Properties

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Events

        #region Methods

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        ///     Seperates the license and property into 2 strings and assigns
        /// </summary>
        /// <param name="field"></param>
        private bool SplitPropertyField(string field)
        {
            if (field.Contains(":"))
            {
                string[] i = field.Split(':');
                PropertyLicense = i[0];
                NewFieldValue = i[1];
                return true;
            }
            return false;
        }
        
        private void SetTextboxLabel(string value)
        {
            TextboxLabel = value + " value";
        }

        /// <summary>
        ///     Sets the title of the fieldEditWindowView
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        private void SetViewTitle(string value, string type)
        {
            ViewTitle = type + " " + value;
        }

        public bool Submit()
        {
            bool submitStatus = false;
            if (FieldStatus == "Add")
            {
                switch (FieldType)
                {
                    case "Category":
                        try
                        {
                            ItemService.InsertCategory(NewFieldValue);
                            MessageBox.Show("Category Added");
                            submitStatus = true;
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("Category cound not be inserted into the database.", ex.ToString());
                        }

                        break;
                    case "License":
                        try
                        {
                            string[] x = NewFieldValue.Split(':');
                            string prop = "";
                            if (x[1] != null)
                            {
                                prop = x[1].Trim();
                            }
                            ItemService.InsertLicense(x[0].Trim(), prop);
                            MessageBox.Show("License / Property Added");
                            submitStatus = true;
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("License cound not be inserted into the database.", ex.ToString());
                        }
                        break;
                    case "Meta Description":
                        try
                        {
                            ItemService.InsertMetaDescription(NewFieldValue);
                            MessageBox.Show("Meta Description Added");
                            submitStatus = true;
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("Meta Description cound not be inserted into the database.", ex.ToString());
                        }
                        break;
                    case "Property":
                        try
                        {
                            if (SplitPropertyField(NewFieldValue))
                            {
                                ItemService.InsertLicense(PropertyLicense, NewFieldValue);
                                MessageBox.Show("Property Added");
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("Property cound not be inserted into the database.", ex.ToString());
                        }
                        submitStatus = true;
                        break;
                    case "Territory":
                        try
                        {
                            ItemService.InsertTerritory(NewFieldValue);
                            MessageBox.Show("Territory Added");
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("Territory cound not be inserted into the database.", ex.ToString());
                        }
                        submitStatus = true;
                        break;
                }
            }

            else if (FieldStatus == "Update")
            {
                switch (FieldType)
                {
                    case "Category":
                        try
                        {
                            ItemService.UpdateCategory(NewFieldValue, OriginalFieldValue);
                            MessageBox.Show("Category Updated");
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("Category cound not be updated.", ex.ToString());
                        }
                        submitStatus = true;
                        break;
                }
            }
            else if (FieldStatus == "Request")
            {
                switch (FieldType)
                {
                    case "Category":
                        try
                        {
                            NewFieldValue = "#" + NewFieldValue;
                            ItemService.InsertCategory(NewFieldValue);
                            string name = Environment.UserName;
                            EmailService.sendCategoryUpdateEmail(Environment.UserName);
                            MessageBox.Show("Category Request Placed");
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.LogError("Category cound not be inserted into the database.", ex.ToString());
                        }
                        submitStatus = true;
                        break;
                }
            }
            return submitStatus;
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     FieldEditWindowViewModel constructor
        /// </summary>
        /// <param name="fieldType">Name of field</param>
        /// <param name="fieldValue">Value of field</param>
        /// <param name="fieldStatus">Flag for update or add</param>
        /// <param name="itemService"></param>
        /// <param name="emailService"></param>
        public FieldEditWindowViewModel(string fieldType, string fieldValue, string fieldStatus, ItemService itemService, EmailService emailService)
        {
            ItemService = itemService ?? throw new ArgumentNullException("itemService");
            EmailService = emailService ?? throw new ArgumentNullException("emailService");
            NewFieldValue = fieldValue;
            OriginalFieldValue = fieldValue;
            FieldStatus = fieldStatus;
            FieldType = fieldType;
            SetTextboxLabel(fieldType);
            SetViewTitle(fieldType, fieldStatus);

        }

        #endregion // Constructor
    }
}
