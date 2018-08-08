using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Odin.Data
{
    public class TestOptionRepository : IOptionRepository
    {

        #region Public Methods

        #region Public Insert Methods

        /// <summary>
        ///     Insert a option id / value pair into the ODIN_OPTIONS_TABLE table 
        /// </summary>
        public void InsertOption(string optionId, string value, string username)
        {
        }

        /// <summary>
        ///     Insert a permission / role pair into [Odin_RolePermissions]
        /// </summary>
        public void InsertRolePermission(string permission, string role)
        {
        }

        /// <summary>
        ///     Add a user / role pair to Odin_UserRoles
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">Role to be granted to user</param>
        public void InsertUserRole(string userName, string role)
        {
        }

        #endregion // Public Insert Methods

        #region Public Remove Methods

        /// <summary>
        ///     Removes a row from ODIN_OPTIONS_TABLE 
        /// </summary>
        /// <param name="optionId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveOption(string optionId, string value, string username)
        {
        }

        /// <summary>
        ///    Remove a permission / role pair from Odin_RolePermissions
        /// </summary>
        public void RemoveRolePermission(string permission, string role)
        {
        }

        /// <summary>
        ///    Remove a user / role pair from Odin_UserRoles
        /// </summary>
        public void RemoveUserRole(string userName, string role)
        {
        }

        #endregion // Public Remove Methods

        #region Public Retrieval Methods

        /// <summary>
        ///     Retrieve the names of all users with Admin Roles from Odin_UserRoles
        /// </summary>
        /// <returns>List of users with Admin permission</returns>
        public List<string> RetrieveAdmins()
        {
            List<string> adminList = new List<string>();
            adminList.Add("Admin1");
            adminList.Add("Admin2");
            return adminList;
        }

        /// <summary>
        ///     retrieves the coresponding value for the key in Odin_GlobalKeys
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveGlobalKey(string key)
        {
            return "GlobalKey";
        }

        /// <summary>
        ///     Retrieves the next notification number
        /// </summary>
        public int RetrieveCurrentNotificationNumber()
        {
            int result = 0;
            return result;
        }

        /// <summary>
        ///     Retrieves the GlobalOptionData
        /// </summary>
        public void RetrieveGloablOptionData()
        {

        }

        /// <summary>
        ///     Retrieve all the notifications with numbers higher than the current users notification number
        /// </summary>
        /// <returns>List of notifications</returns>
        public List<string> RetrieveNotifications(string type)
        {
            List<string> results = new List<string>();
            return results;
        }

        /// <summary>
        ///     Retrieve the option values for the given option id from ODIN_OPTIONS_TABLE
        /// </summary>
        /// <returns>List of option values</returns>
        public List<string> RetrieveOptions(string optionId, string username)
        {
            List<string> optionValues = new List<string>();
            if(optionId == "VariantGroupExclusion")
            {
                optionValues.Add("RP");
                optionValues.Add("FR");
                optionValues.Add("POD");
                optionValues.Add("BLK22X34");
            }

            return optionValues;
        }

        /// <summary>
        ///     Retrieve a list of all the role/permission combinations
        /// </summary>
        /// <returns>List of all role/permission combinations</returns>
        public ObservableCollection<PermissionObj> RetrieveRolePermissionList()
        {
            ObservableCollection<PermissionObj> rolePermissionList = new ObservableCollection<PermissionObj>();

            rolePermissionList.Add(new PermissionObj("Role1", "Permission1"));
            rolePermissionList.Add(new PermissionObj("Role2", "Permission2"));
            rolePermissionList.Add(new PermissionObj("Role3", "Permission3"));

            return rolePermissionList;
        }

        /// <summary>
        ///     Retrieve the permissions associated with the username from Odin_RolePermissions
        /// </summary>
        /// <param name="name">Name of current user</param>
        /// <returns>List of permissions</returns>
        public List<string> RetrievePermissions(string name)
        {
            List<string> permissions = new List<string>();
            permissions.Add("Permission1");
            permissions.Add("Permission2");
            permissions.Add("Permission3");
            permissions.Add("Permission4");
            permissions.Add("Permission5");
            return permissions;
        }

        /// <summary>
        ///     Retrieve a list of all the User Names for a given exception from ODIN_USER_EXCEPTIONS
        /// </summary>
        /// <returns>List of all the user name / role pairs</returns>
        public List<string> RetrieveUserExceptionList(string exception)
        {
            List<string> userExceptionList = new List<string>();

            userExceptionList.Add("TESTUSER");

            return userExceptionList;
        }

        /// <summary>
        ///     Retrieve a list of all the User name / role pairs from Odin_UserRoles
        /// </summary>
        /// <returns>List of all the user name / role pairs</returns>
        public ObservableCollection<PermissionObj> RetrieveUserRoleList()
        {
            ObservableCollection<PermissionObj> userRoleList = new ObservableCollection<PermissionObj>();

            userRoleList.Add(new PermissionObj("UserName1", "Role1"));
            userRoleList.Add(new PermissionObj("UserName2", "Role2"));
            userRoleList.Add(new PermissionObj("UserName3", "Role3"));
            userRoleList.Add(new PermissionObj("UserName4", "Role4"));
            return userRoleList;
        }

        #endregion // Public Retrieval Methods

        #region Public Update Methods

        /// <summary>
        ///     Updates the current users notification number to the current number
        /// </summary>
        public void UpdateUserNotification()
        {
        }

        /// <summary>
        ///     Change the role of a user in Odin_UserRoles
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">New role</param>
        public void UpdateUserRole(string userName, string role)
        {
        }

        #endregion // Public Update Methods

        #endregion // Public Methods

        #region Constructor

        public TestOptionRepository()
        {

        }

        #endregion // Constructor
    }
}
