using Odin.DbTableModels;
using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Odin.Data
{
    public class OptionRepository : IOptionRepository
    {
        #region Fields

        private readonly IOdinContextFactory contextFactory;

        #endregion // Fields

        #region Public Methods

        #region Public Insert Methods

        /// <summary>
        ///     Insert a option id / value pair into the ODIN_OPTIONS_TABLE table 
        /// </summary>
        public void InsertOption(string optionId, string value, string username)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (!context.OdinOptionsTable.Any(o => o.OptionId == optionId && o.Value == value && o.UserName == username))
                {
                    context.OdinOptionsTable.Add(new OdinOptionsTable
                    {
                        OptionId = optionId,
                        Value = value,
                        UserName = username
                    });
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        ///     Insert a permission / role pair into [Odin_RolePermissions]
        /// </summary>
        public void InsertRolePermission(string permission, string role)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (!context.OdinRolePermissions.Any(o => o.Role == role && o.Permission == permission))
                {
                    context.OdinRolePermissions.Add(new OdinRolePermissions
                    {
                        Role = role,
                        Permission = permission
                    });
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        ///     Add a user / role pair to Odin_UserRoles
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">Role to be granted to user</param>
        public void InsertUserRole(string userName, string role)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (!context.OdinUserRoles.Any(o => o.Username == userName && o.Role == role))
                {
                    context.OdinUserRoles.Add(new OdinUserRoles
                    {
                        Username = userName,
                        Role = role
                    });
                    context.SaveChanges();
                }
            }
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
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (OdinOptionsTable odinOptionsTable in (from o in context.OdinOptionsTable
                           where o.OptionId == optionId && o.Value == value && o.UserName == username
                           select o))
                {
                    context.OdinOptionsTable.Remove(odinOptionsTable);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        ///    Remove a permission / role pair from Odin_RolePermissions
        /// </summary>
        public void RemoveRolePermission(string permission, string role)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (OdinRolePermissions odinRolePermissions in (from o in context.OdinRolePermissions
                                 where o.Permission == permission && o.Role == role
                                 select o))
                {
                    context.OdinRolePermissions.Remove(odinRolePermissions);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        ///    Remove a user / role pair from Odin_UserRoles
        /// </summary>
        public void RemoveUserRole(string userName, string role)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (OdinUserRoles odinUserRoles in (from o in context.OdinUserRoles
                     where o.Username == userName && o.Role == role
                     select o))
                {
                    context.OdinUserRoles.Remove(odinUserRoles);
                }
                context.SaveChanges();
            }
        }

        #endregion // Public Remove Methods

        #region Public Retrieval Methods

        /// <summary>
        ///     Retrieves the current notification number
        /// </summary>
        public int RetrieveCurrentNotificationNumber()
        {
            int result = 0;
            
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (context.OdinNotifications.Any())
                {
                    result = context.OdinNotifications.Max(o => o.NotificationNumber);
                }
            }            
            return result;
        }

        /// <summary>
        ///     Retrieves the GlobalOptionData
        /// </summary>
        public void RetrieveGloablOptionData()
        {
            GlobalData.VariantGroupExclusionOptions = RetrieveOptions("VariantGroupExclusion","");
            GlobalData.ProductFormatExclusionOptions = RetrieveOptions("ProductFormatExclusion", GlobalData.UserName);
            GlobalData.UserPermissions = RetrievePermissions(GlobalData.UserName);
            if(GlobalData.UserPermissions.Count==0)
            {
                InsertUserRole(GlobalData.UserName, "NEW");
            }
        }

        /// <summary>
        ///     Retrieve all the notifications with numbers higher than the current users notification number
        /// </summary>
        /// <returns>List of notifications</returns>
        public List<string> RetrieveNotifications(string type)
        {
            List<string> results = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                int userInt = (from o in context.OdinUserRoles where o.Username == GlobalData.UserName select o.NotificationNumber).FirstOrDefault();
                List<OdinNotifications> odinNotifications = new List<OdinNotifications>();
                if (type == "User")
                {
                    odinNotifications = (from o in context.OdinNotifications where o.NotificationNumber > userInt orderby o.Date select o).ToList();
                }
                else if (type == "All")
                {
                    odinNotifications = (from o in context.OdinNotifications orderby o.Date select o).ToList();
                }
                foreach (OdinNotifications x in odinNotifications)
                {
                    results.Add(DbUtil.DateTrim(x.Date.ToString()) + " : " + x.Notification);
                }
            }
            return results;
        }

        /// <summary>
        ///     Retrieve the option values for the given option id from ODIN_OPTIONS_TABLE
        /// </summary>
        /// <returns>List of option values</returns>
        public List<string> RetrieveOptions(string optionId,string username)
        {
            List<string> optionValues = new List<string>();

            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<string> results = (from o in context.OdinOptionsTable
                                        where o.OptionId == optionId
                                            && o.UserName == username
                                        select o.Value).ToList();
                results.Sort();
                foreach (string x in results)
                {
                    optionValues.Add(x);
                }
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

            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<OdinRolePermissions> odinRolePermissions = (from o in context.OdinRolePermissions select o).ToList();
                foreach (OdinRolePermissions x in odinRolePermissions)
                {
                    rolePermissionList.Add(new PermissionObj(x.Role, x.Permission));
                }
            }
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

            using (OdinContext context = this.contextFactory.CreateContext())
            {
                string userRole = (from o in context.OdinUserRoles where o.Username == name select o.Role).FirstOrDefault();
                permissions = (from o in context.OdinRolePermissions where o.Role == userRole select o.Permission).ToList();
                permissions.Sort();
            }

            return permissions;
        }
        
        /// <summary>
        ///     Retrieve a list of all the User Names for a given exception from ODIN_USER_EXCEPTIONS
        /// </summary>
        /// <returns>List of all the user name / role pairs</returns>
        public List<string> RetrieveUserExceptionList(string exception)
        {
            List<string> userExceptionList = new List<string>();

            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (context.OdinUserExceptions.Any(o => o.Exception == exception))
                {
                    userExceptionList = (from o in context.OdinUserExceptions where o.Exception == exception select o.Username).ToList();
                }
            }
            return userExceptionList;
        }

        /// <summary>
        ///     Retrieve a list of all the User name / role pairs from Odin_UserRoles
        /// </summary>
        /// <returns>List of all the user name / role pairs</returns>
        public ObservableCollection<PermissionObj> RetrieveUserRoleList()
        {
            ObservableCollection<PermissionObj> userRoleList = new ObservableCollection<PermissionObj>();

            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<OdinUserRoles> odinUserRoles = (from o in context.OdinUserRoles select o).ToList();
                foreach (OdinUserRoles x in odinUserRoles)
                {
                    userRoleList.Add(new PermissionObj(x.Username, x.Role));
                }
            }
            return userRoleList;
        }

        #endregion // Public Retrieval Methods

        #region Public Update Methods

        /// <summary>
        ///     Updates the current users notification number to the current number
        /// </summary>
        public void UpdateUserNotification()
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                OdinUserRoles odinUserRoles = (from o in context.OdinUserRoles where o.Username == GlobalData.UserName select o).FirstOrDefault();
                if (odinUserRoles != null)
                {
                    odinUserRoles.NotificationNumber = GlobalData.NotificationNumber;
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        ///     Change the role of a user in Odin_UserRoles
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">New role</param>
        public void UpdateUserRole(string userName, string role)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                OdinUserRoles odinUserRoles = (from o in context.OdinUserRoles where o.Username == userName select o).FirstOrDefault();
                if (odinUserRoles != null)
                {
                    odinUserRoles.Role = role;
                    context.SaveChanges();
                }
            }
        }

        #endregion // Public Update Methods

        #endregion // Public Methods

        #region Constructor

        /// <summary>
        ///     Constructs the option repository
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbPassword"></param>
        /// <param name="dbServerName"></param>
        /// <param name="isLocalTest"></param>
        public OptionRepository(IOdinContextFactory contextFactory)
        {
            this.contextFactory = contextFactory?? throw new ArgumentNullException("contextFactory");
            GlobalData.NotificationNumber = RetrieveCurrentNotificationNumber();
        }

        #endregion // Constructor
    }
}
