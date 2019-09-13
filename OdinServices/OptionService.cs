using Odin.Data;
using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace OdinServices
{
    public class OptionService
    {
        #region Properties


        /// <summary>
        ///     Gets or sets the OptionRepository
        /// </summary>
        public IOptionRepository OptionRepository { get; set; }

        /// <summary>
        ///     Gets or sets the RequestRepository
        /// </summary>
        public IRequestRepository RequestRepository { get; set; }

        #endregion // Properties

        #region Methods

        #region Insert Methods

        /// <summary>
        ///     Insert a option id / value pair into the ODIN_OPTIONS_TABLE table 
        /// </summary>
        public void InsertOption(string optionId, string value, string username)
        {
            OptionRepository.InsertOption(optionId, value,username);
        }

        /// <summary>
        ///     Insert a permission / role pair into the DB 
        /// </summary>
        public void InsertRolePermission(string permission, string role)
        {
            OptionRepository.InsertRolePermission(permission, role);
        }

        /// <summary>
        ///     Add a user / role pair to the db
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">Role to be granted to user</param>
        public void InsertUserRole(string userName, string role)
        {
            OptionRepository.InsertUserRole(userName, role);
        }

        #endregion // Insert Methods

        #region Removal Methods

        /// <summary>
        ///    Remove a permission / role pair into the DB 
        /// </summary>
        public void RemoveRolePermission(string permission, string role)
        {
            OptionRepository.RemoveRolePermission(permission, role);
        }

        /// <summary>
        ///     Removes a row from ODIN_OPTIONS_TABLE 
        /// </summary>
        /// <param name="optionId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveOption(string optionId, string value, string username)
        {
            OptionRepository.RemoveOption(optionId, value, username);
        }

        /// <summary>
        ///     Remove a user role
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="role"></param>
        public void RemoveUserRole(string userName, string role)
        {
            OptionRepository.RemoveUserRole(userName, role);
        }

        #endregion // Removal Methods

        #region Retrieval Methods

        /// <summary>
        ///     Retrieves a list of Notifications
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string>RetrieveNotifications(string type)
        {
            return OptionRepository.RetrieveNotifications(type);
        }

        /// <summary>
        ///     Retrieve the option values that corespond to the given option id from ODIN_OPTIONS_TABLE
        /// </summary>
        /// <returns>List of option values</returns>
        public List<string> RetrieveOptions(string optionId, string username)
        {
            return OptionRepository.RetrieveOptions(optionId, username);
        }

        /// <summary>
        ///     Retrieve the permissions associated with the username
        /// </summary>
        /// <param name="name">Name of current user</param>
        /// <returns>List of permissions</returns>
        public List<string> RetrievePermissions(string name)
        {
            return OptionRepository.RetrievePermissions(name);
        }

        public List<Request> RetrieveRequestList(int requestId)
        {
            return RequestRepository.RetrieveRequestList(requestId);
        }

        public List<Request> RetrieveRequests(bool isAdmin)
        {
            return RequestRepository.RetrieveRequests(isAdmin);
        }

        /// <summary>
        ///     Retrieve a list of all the role/permission combinations
        /// </summary>
        /// <returns>List of all role/permission combinations</returns>
        public ObservableCollection<PermissionObj> RetrieveRolePermissionList()
        {
            return OptionRepository.RetrieveRolePermissionList();
        }

        /// <summary>
        ///     Retrieve a list of all the User Names for a given exception from ODIN_USER_EXCEPTIONS
        /// </summary>
        /// <returns>List of all the user name / role pairs</returns>
        public List<string> RetrieveUserExceptionList(string exception)
        {
            return OptionRepository.RetrieveUserExceptionList(exception);
        }

        /// <summary>
        ///     Retrieve a list of all the User name / role pairs
        /// </summary>
        /// <returns>List of all the user name / role pairs</returns>
        public ObservableCollection<PermissionObj> RetrieveUserRoleList()
        {
            return OptionRepository.RetrieveUserRoleList();
        }

        #endregion // Retrieval Methods

        public void SetCaches()
        {
            // GlobalData.VariantGroupExclusionOptions = RetrieveOptions("VariantGroupExclusion", "");
            GlobalData.FtpUserexceptions = RetrieveUserExceptionList("FTP");
        }

        #region Update Methods

        /// <summary>
        ///     Change the role of a user
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">New role</param>
        public void UpdateUserRole(string userName, string role)
        {
            OptionRepository.UpdateUserRole(userName, role);
        }

        /// <summary>
        ///     Update the given WebsiteRequest
        /// </summary>
        /// <param name="request"></param>
        public void UpdateWebsiteRequest(Request request)
        {
            RequestRepository.UpdateWebsiteRequest(request);
        }

        #endregion // Update Methods

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the Option Service
        /// </summary>
        /// <param name="optionRepository"></param>
        public OptionService(IOptionRepository optionRepository, IRequestRepository requestRepository)
        {
            OptionRepository = optionRepository?? throw new ArgumentNullException("optionRepository");
            RequestRepository = requestRepository?? throw new ArgumentNullException("requestRepository");
            SetCaches();
        }

        #endregion // Constructor
    }
}
