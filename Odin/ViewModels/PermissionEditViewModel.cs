using OdinModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Odin.ViewModels
{
    public class PermissionEditViewModel
    {
        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Gets or sets the Field1 Value
        /// </summary>
        public string Field1
        {
            get
            {
                if (_field1 == null)
                {
                    _field1 = string.Empty;
                }
                return _field1;
            }
            set
            {
                _field1 = value;
                OnPropertyChanged("Field1");
            }
        }
        private string _field1;

        /// <summary>
        ///     Gets or sets the Field1Title
        /// </summary>
        public string Field1Title { get; set; }

        /// <summary>
        ///     Gets or sets the Field2 Value
        /// </summary>
        public string Field2
        {
            get
            {
                if (_field2 == null)
                {
                    _field2 = string.Empty;
                }
                return _field2;
            }
            set
            {
                _field2 = value;
                OnPropertyChanged("Field2");
            }
        }
        private string _field2;

        /// <summary>
        ///     Gets or sets the Field2Title
        /// </summary>
        public string Field2Title { get; set; }
        
        /// <summary>
        ///     Gets list of User Role values
        /// </summary>
        public List<string> UserRoles
        {
            get
            {
                return GlobalData.UserRoles;
            }
        }

        #endregion // Properties

        #region Methods

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the PermissionEditViewModel
        /// </summary>
        /// <param name="type"></param>
        /// <param name="permissionObj"></param>
        public PermissionEditViewModel(string type, PermissionObj permissionObj) 
        {
            switch (type) 
            { 
                case "CreateUR":
                    this.Field1Title = "User Name";
                    this.Field2Title = "Role";
                    break;

                case "EditUR":
                    this.Field1Title = "User Name";
                    this.Field2Title = "Role";
                    break;

                case "CreateRP":
                    this.Field1Title = "Role";
                    this.Field2Title = "Permission";
                    break;
            
            }
            this.Field1 = permissionObj.Field1;
            this.Field2 = permissionObj.Field2;        
        }

        #endregion // Constructor
    }
}
