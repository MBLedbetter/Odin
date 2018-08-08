using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OdinRepositories
{
    public interface IOptionRepository
    {
        #region Methods
        
        /// <summary>
        ///     Insert a option id / value pair into the ODIN_OPTIONS_TABLE table 
        /// </summary>
        bool InsertOption(string optionId, string value);

        /// <summary>
        ///     Insert a permission / role pair into the DB 
        /// </summary>
        bool InsertRolePermission(string permission, string role);

        /// <summary>
        ///     Add a user / role pair to the db
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">Role to be granted to user</param>
        bool InsertUserRole(string userName, string role);

        /// <summary>
        ///     Removes a row from ODIN_OPTIONS_TABLE 
        /// </summary>
        /// <param name="optionId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool RemoveOption(string optionId, string value);

        /// <summary>
        ///    Remove a permission / role pair into the DB 
        /// </summary>
        bool RemoveRolePermission(string permission, string role);

        /// <summary>
        ///    Remove a user / role pair into the DB 
        /// </summary>
        bool RemoveUserRole(string userName, string role);

        bool RepositoryAssigned();

        /// <summary>
        ///     Retrieve the names of all users with Admin Roles from Odin_UserRoles
        /// </summary>
        /// <returns>List of users with Admin permission</returns>
        List<string> RetrieveAdmins();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string RetrieveGlobalKey(string key);

        /// <summary>
        ///     Retrieve the option values for the given option id from ODIN_OPTIONS_TABLE
        /// </summary>
        /// <returns>List of option values</returns>
        ObservableCollection<string> RetrieveOptions(string optionId);

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
        ///     Retrieve a list of all the User name / role pairs
        /// </summary>
        /// <returns>List of all the user name / role pairs</returns>
        ObservableCollection<PermissionObj> RetrieveUserRoleList();
        /*
        /// <summary>
        ///     Retrieve a list of user names
        /// </summary>
        /// <returns></returns>
        List<string> RetrieveUserNames();
        
        /// <summary>
        ///     Retrieve a list of user roles
        /// </summary>
        /// <returns></returns>
        List<string> RetrieveUserRoles();
        */
        /// <summary>
        ///     Change the role of a user
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">New role</param>
        bool UpdateUserRole(string userName, string role);
        
        #endregion // Methods        
    }
}
