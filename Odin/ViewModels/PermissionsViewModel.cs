using Mvvm;
using OdinModels;
using OdinServices;
using Odin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;

namespace Odin.ViewModels
{
    public class PermissionsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Commands

        public ICommand CreateRolePermissionCommand
        {
            get
            {
                if (_createRolePermission == null)
                {
                    _createRolePermission = new RelayCommand(param => CreateRolePermission());
                }
                return _createRolePermission;
            }
        }
        private RelayCommand _createRolePermission;

        public ICommand CreateUserRoleCommand
        {
            get
            {
                if (_createUserRole == null)
                {
                    _createUserRole = new RelayCommand(param => CreateUserRole());
                }
                return _createUserRole;
            }
        }
        private RelayCommand _createUserRole;

        public ICommand EditUserRoleCommand
        {
            get
            {
                if (_editUserRole == null)
                {
                    _editUserRole = new RelayCommand(param => EditUserRole());
                }
                return _editUserRole;
            }
        }
        private RelayCommand _editUserRole;

        public ICommand RemoveRolePermissionCommand
        {
            get
            {
                if (_removeRolePermission == null)
                {
                    _removeRolePermission = new RelayCommand(param => RemoveRolePermission());
                }
                return _removeRolePermission;
            }
        }
        private RelayCommand _removeRolePermission;

        public ICommand RemoveUserRoleCommand
        {
            get
            {
                if (_removeUserRole == null)
                {
                    _removeUserRole = new RelayCommand(param => RemoveUserRole());
                }
                return _removeUserRole;
            }
        }
        private RelayCommand _removeUserRole;


        public ICommand SortPermissionColumnCommand
        {
            get
            {
                if (_sortPermissionColumn == null)
                {
                    _sortPermissionColumn = new RelayCommand(param => SortPermissions());
                }
                return _sortPermissionColumn;
            }
        }
        private RelayCommand _sortPermissionColumn;

        public ICommand SortRoleColumnCommand
        {
            get
            {
                if (_sortRoleColumn == null)
                {
                    _sortRoleColumn = new RelayCommand(param => SortRoles());
                }
                return _sortRoleColumn;
            }
        }
        private RelayCommand _sortRoleColumn;

        public ICommand SortUserNameColumnCommand
        {
            get
            {
                if (_sortUserNameColumn == null)
                {
                    _sortUserNameColumn = new RelayCommand(param => SortUserNames());
                }
                return _sortUserNameColumn;
            }
        }
        private RelayCommand _sortUserNameColumn;

        public ICommand SortUserRoleColumnCommand
        {
            get
            {
                if (_sortUserRoleColumn == null)
                {
                    _sortUserRoleColumn = new RelayCommand(param => SortUserRoles());
                }
                return _sortUserRoleColumn;
            }
        }
        private RelayCommand _sortUserRoleColumn;

        #endregion // Commands

        #region Properties

        /// <summary>
        ///     Flags current Role Sort order state
        /// </summary>
        private int RoleSortOrder { get; set; }

        /// <summary>
        ///     Flags current Permission Sort order state
        /// </summary>
        private int PermissionSortOrder { get; set; }

        /// <summary>
        ///     Flags current UserName sort order state
        /// </summary>
        private int UserNameSortOrder { get; set; }
        
        /// <summary>
        ///     Flags current UserRole sort order state
        /// </summary>
        private int UserRoleSortOrder { get; set; }

        public ObservableCollection<PermissionObj> UserRoleList
        {
            get
            {
                if (_userRoleList == null)
                {
                    _userRoleList = new ObservableCollection<PermissionObj>();
                }
                return _userRoleList;
            }
            private set
            {
                _userRoleList = value;
                OnPropertyChanged("UserRoleList");
            }
        }
        private ObservableCollection<PermissionObj> _userRoleList;

        public ObservableCollection<PermissionObj> PermissionRoleList
        {
            get
            {
                if (_permissionRoleList == null)
                {
                    _permissionRoleList = new ObservableCollection<PermissionObj>();
                }
                return _permissionRoleList;
            }
            private set
            {
                _permissionRoleList = value;
                OnPropertyChanged("PermissionRoleList");
            }
        }
        private ObservableCollection<PermissionObj> _permissionRoleList;

        /// <summary>
        ///     Selected item from the UserRoleList
        /// </summary>
        public PermissionObj SelectedUserRole { get; set; }

        /// <summary>
        ///     Selected item from the PermissionRoleList.
        /// </summary>
        public PermissionObj SelectedPermissionRole { get; set; }

        public OptionService OptionService { get; set; }

        #endregion // Properties

        #region Methods


        /// <summary>
        ///     Opens a blank PermissionEditView window to create a new role permission
        /// </summary>
        public void CreateRolePermission()
        {
            PermissionEditView window = new PermissionEditView();
            window.DataContext = new PermissionEditViewModel("CreateRP", new PermissionObj());
            if (window.ShowDialog() == true)
            {
                String string1 = (window.DataContext as PermissionEditViewModel).Field1;
                String string2 = (window.DataContext as PermissionEditViewModel).Field2;
                OptionService.InsertRolePermission(string2, string1);
                PermissionRoleList = OptionService.RetrieveRolePermissionList();
            }
            
        }

        /// <summary>
        ///     Opens a blank PermissionEditView window to create a new user role
        /// </summary>
        public void CreateUserRole()
        {
            PermissionEditView window = new PermissionEditView();
            window.DataContext = new PermissionEditViewModel("CreateUR",new PermissionObj());
            if (window.ShowDialog() == true)
            {
                String string1 = (window.DataContext as PermissionEditViewModel).Field1;
                String string2 = (window.DataContext as PermissionEditViewModel).Field2;
                OptionService.InsertUserRole(string1, string2);
                MessageBox.Show("User/Role created Successfully.");
                UserRoleList = OptionService.RetrieveUserRoleList();
            }
        }

        /// <summary>
        ///     Opens a PermissionEditView window to edit the selected user role
        /// </summary>
        public void EditUserRole()
        {
            if (SelectedUserRole != null)
            {
                PermissionEditView window = new PermissionEditView();
                window.DataContext = new PermissionEditViewModel("EditUR", SelectedUserRole);
                if (window.ShowDialog() == true)
                {
                    String string1 = (window.DataContext as PermissionEditViewModel).Field1;
                    String string2 = (window.DataContext as PermissionEditViewModel).Field2;
                    OptionService.UpdateUserRole(string1, string2);
                    MessageBox.Show("User/Role updated Successfully.");
                    UserRoleList = OptionService.RetrieveUserRoleList();

                }
            }
            else
            {
                MessageBox.Show("Please select a User/Role to edit");
            }
        }
        
        /// <summary>
        ///     Removes a Role Permission from the DB
        /// </summary>
        public void RemoveRolePermission()
        {
            OptionService.RemoveRolePermission(SelectedPermissionRole.Field2, SelectedPermissionRole.Field1);
            MessageBox.Show("Role / Permission removed.");
            UserRoleList = OptionService.RetrieveUserRoleList();
            PermissionRoleList = OptionService.RetrieveRolePermissionList();

        }

        /// <summary>
        ///     Removes a User Role from the DB
        /// </summary>
        public void RemoveUserRole() 
        {
            OptionService.RemoveUserRole(SelectedUserRole.Field1, SelectedUserRole.Field2);
            MessageBox.Show("User / Role removed");
            UserRoleList = OptionService.RetrieveUserRoleList();
            PermissionRoleList = OptionService.RetrieveRolePermissionList();
        }

        public void SortPermissions()
        {
            List<PermissionObj> SortedList = new List<PermissionObj>();
            if (PermissionSortOrder == 0)
            {
                SortedList = this.PermissionRoleList.OrderByDescending(o => o.Field2).ToList();
                PermissionSortOrder = 1;
            }
            else
            {
                SortedList = this.PermissionRoleList.OrderBy(o => o.Field2).ToList();
                PermissionSortOrder = 0;
            }
            this.PermissionRoleList = new ObservableCollection<PermissionObj>();
            foreach (PermissionObj item in SortedList)
            {
                this.PermissionRoleList.Add(item);
            }
        }

        public void SortRoles()
        {
            List<PermissionObj> SortedList = new List<PermissionObj>();
            if (RoleSortOrder == 0)
            {
                SortedList = this.PermissionRoleList.OrderByDescending(o => o.Field1).ToList();
                RoleSortOrder = 1;
            }
            else
            {
                SortedList = this.PermissionRoleList.OrderBy(o => o.Field1).ToList();
                RoleSortOrder = 0;
            }
            this.PermissionRoleList = new ObservableCollection<PermissionObj>();
            foreach (PermissionObj item in SortedList)
            {
                this.PermissionRoleList.Add(item);
            }
        }

        /// <summary>
        ///     Sorts the user name / user role list be the user name
        /// </summary>
        public void SortUserNames()
        {
            List<PermissionObj> SortedList = new List<PermissionObj>();
            if (UserNameSortOrder == 0)
            {
                SortedList = this.UserRoleList.OrderByDescending(o => o.Field1).ToList();
                UserNameSortOrder = 1;
            }
            else
            {
                SortedList = this.UserRoleList.OrderBy(o => o.Field1).ToList();
                UserNameSortOrder = 0;
            }
            this.UserRoleList = new ObservableCollection<PermissionObj>();
            foreach (PermissionObj item in SortedList)
            {
                this.UserRoleList.Add(item);
            }
        }

        /// <summary>
        ///     Sorts the user name / user role list be the user role
        /// </summary>
        public void SortUserRoles()
        {
            List<PermissionObj> SortedList = new List<PermissionObj>();
            if (UserRoleSortOrder == 0)
            {
                SortedList = this.UserRoleList.OrderByDescending(o => o.Field2).ToList();
                UserRoleSortOrder = 1;
            }
            else
            {
                SortedList = this.UserRoleList.OrderBy(o => o.Field2).ToList();
                UserRoleSortOrder = 0;
            }
            this.UserRoleList = new ObservableCollection<PermissionObj>();
            foreach (PermissionObj item in SortedList)
            {
                this.UserRoleList.Add(item);
            }
        }
        
        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the permissions view model
        /// </summary>
        /// <param name="optionService"></param>
        public PermissionsViewModel(OptionService optionService)
        {
            if (optionService == null) { throw new ArgumentNullException("optionService"); }
            this.PermissionSortOrder = 0;
            this.RoleSortOrder = 0;
            this.UserNameSortOrder = 0;
            this.UserRoleSortOrder = 0;
            OptionService = optionService;
            UserRoleList = OptionService.RetrieveUserRoleList();
            PermissionRoleList = OptionService.RetrieveRolePermissionList();
        }

        #endregion // Constructor

    }
}
