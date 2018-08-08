using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Odin.Data
{
    public interface IOptionRepository
    {

        #region Public Methods

        #region Public Insert Methods

        /// <summary>
        ///     Insert a option id / value pair into the ODIN_OPTIONS_TABLE table 
        /// </summary>
        void InsertOption(string optionId, string value, string username);

        /// <summary>
        ///     Insert a permission / role pair into the DB 
        /// </summary>
        void InsertRolePermission(string permission, string role);

        /// <summary>
        ///     Add a user / role pair to the db
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">Role to be granted to user</param>
        void InsertUserRole(string userName, string role);

        #endregion // Public Insert Methods

        #region Public Removal Methods

        /// <summary>
        ///     Removes a row from ODIN_OPTIONS_TABLE 
        /// </summary>
        /// <param name="optionId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        void RemoveOption(string optionId, string value, string username);

        /// <summary>
        ///    Remove a permission / role pair into the DB 
        /// </summary>
        void RemoveRolePermission(string permission, string role);

        /// <summary>
        ///    Remove a user / role pair into the DB 
        /// </summary>
        void RemoveUserRole(string userName, string role);

        #endregion // Public Removal Methods

        #region Public Retrieval Methods

        /// <summary>
        ///     Retrieves the next notification number
        /// </summary>
        int RetrieveCurrentNotificationNumber();

        /// <summary>
        ///     Retrieves the GlobalOptionData
        /// </summary>
        void RetrieveGloablOptionData();

        /// <summary>
        ///     Retrieve all the notifications with numbers higher than the current users notification number
        /// </summary>
        /// <returns>List of notifications</returns>
        List<string> RetrieveNotifications(string type);

        /// <summary>
        ///     Retrieve the option values for the given option id from ODIN_OPTIONS_TABLE
        /// </summary>
        /// <returns>List of option values</returns>
        List<string> RetrieveOptions(string optionId, string username);

        /// <summary>
        ///     Retrieve a list of all the role/permission combinations
        /// </summary>
        /// <returns>List of all role/permission combinations</returns>
        ObservableCollection<PermissionObj> RetrieveRolePermissionList();

        /// <summary>
        ///     Retrieve the permissions associated with the username from Odin_RolePermissions
        /// </summary>
        /// <param name="name">Name of current user</param>
        /// <returns>List of permissions</returns>
        List<string> RetrievePermissions(string name);

        /// <summary>
        ///     Retrieve a list of all the User Names for a given exception from ODIN_USER_EXCEPTIONS
        /// </summary>
        /// <returns>List of all the user name / role pairs</returns>
        List<string> RetrieveUserExceptionList(string exception);

        /// <summary>
        ///     Retrieve a list of all the User name / role pairs
        /// </summary>
        /// <returns>List of all the user name / role pairs</returns>
        ObservableCollection<PermissionObj> RetrieveUserRoleList();

        #endregion // Public Retrieval Methods

        #region Public Update Methods

        /// <summary>
        ///     Updates the current users notification number to the current number
        /// </summary>
        void UpdateUserNotification();

        /// <summary>
        ///     Change the role of a user
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">New role</param>
        void UpdateUserRole(string userName, string role);

        #endregion // Public Update Methods

        #endregion // Public Methods        
    }
}
