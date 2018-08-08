using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OdinRepositories
{
    public class OptionRepository : IOptionRepository
    {
        #region Properties

        /// <summary>
        ///     gets or sets the server name
        /// </summary>
        private string DbServerName { get; set; }

        /// <summary>
        ///     gets or sets the database name
        /// </summary>
        private string DbName { get; set; }

        /// <summary>
        ///     gets or sets the database password
        /// </summary>
        private string DbPassword { get; set; }

        /// <summary>
        ///     gets or sets the isLocalTest flag
        /// </summary>
        private bool IsLocalTest { get; set; }

        /// <summary>
        ///     gets or sets the repositoryAssigned flag
        /// </summary>
        public bool repositoryAssigned = true;

        #endregion // Properties

        #region Methods
        
        #region Insert Methods

        /// <summary>
        ///     Insert a option id / value pair into the ODIN_OPTIONS_TABLE table 
        /// </summary>
        public bool InsertOption(string optionId, string value)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_InsertOption", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@optionId", SqlDbType.VarChar).Value = optionId;
                    sqlCommand.Parameters.Add("@value", SqlDbType.VarChar).Value = value;
                    sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }
            return false;
        }

        /// <summary>
        ///     Insert a permission / role pair into the DB 
        /// </summary>
        public bool InsertRolePermission(string permission, string role)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_InsertRolePermissions", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@permission", SqlDbType.VarChar).Value = permission;
                    sqlCommand.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
                    sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }
            return false;
        }

        /// <summary>
        ///     Add a user / role pair to the db
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">Role to be granted to user</param>
        public bool InsertUserRole(string userName, string role)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_InsertUserRole", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = userName;
                    sqlCommand.Parameters.Add("@userRole", SqlDbType.VarChar).Value = role;
                    sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }
            return false;
        }

        #endregion // Insert Methods

        #region Remove Methods

        /// <summary>
        ///     Removes a row from ODIN_OPTIONS_TABLE 
        /// </summary>
        /// <param name="optionId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool RemoveOption(string optionId, string value)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_RemoveOption", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@optionId", SqlDbType.VarChar).Value = optionId;
                    sqlCommand.Parameters.Add("@value", SqlDbType.VarChar).Value = value;
                    sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }
            return false;
        }

        /// <summary>
        ///    Remove a permission / role pair into the DB 
        /// </summary>
        public bool RemoveRolePermission(string permission, string role)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_RemoveRolePermisions", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@permission", SqlDbType.VarChar).Value = permission;
                    sqlCommand.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
                    sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }
            return false;
        }

        /// <summary>
        ///    Remove a user / role pair into the DB 
        /// </summary>
        public bool RemoveUserRole(string userName, string role)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_RemoveUserRole", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = userName;
                    sqlCommand.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
                    sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }
            return false;
        }

        #endregion // Remove Methods

        public bool RepositoryAssigned()
        {
            return this.repositoryAssigned;
        }

        #region Retrieval Methods

        /// <summary>
        ///     Retrieve the names of all users with Admin Roles from Odin_UserRoles
        /// </summary>
        /// <returns>List of users with Admin permission</returns>
        public List<string> RetrieveAdmins()
        {
            List<string> AdminList = new List<string>();
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_GetAdmins", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        string request = Convert.ToString(reader["UserName"]).Trim();
                        AdminList.Add(request);
                    }
                }
            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }
            return AdminList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveGlobalKey(string key)
        {
            string value = string.Empty;
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveGlobalKeys", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@key", SqlDbType.VarChar).Value = key;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    value = Convert.ToString(reader["VALUE"]);
                }
                reader.Close();
            }
            return value;
        }

        /// <summary>
        ///     Retrieve the option values for the given option id from ODIN_OPTIONS_TABLE
        /// </summary>
        /// <returns>List of option values</returns>
        public ObservableCollection<string> RetrieveOptions(string optionId)
        {
            ObservableCollection<string> OptionValues = new ObservableCollection<string>();
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveOptions", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@optionId", SqlDbType.VarChar).Value = optionId;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        string value = Convert.ToString(reader["VALUE"]).Trim();
                        OptionValues.Add(value);
                    }
                }
            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }
            return OptionValues;
        }

        /// <summary>
        ///     Retrieve a list of all the role/permission combinations
        /// </summary>
        /// <returns>List of all role/permission combinations</returns>
        public ObservableCollection<PermissionObj> RetrieveRolePermissionList()
        {
            ObservableCollection<PermissionObj> rolePermissionList = new ObservableCollection<PermissionObj>();
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_GetRolePermissionList", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        PermissionObj permissionObj = new PermissionObj();
                        permissionObj.Field1 = Convert.ToString(reader["Role"]).Trim();
                        permissionObj.Field2 = Convert.ToString(reader["Permission"]).Trim();
                        rolePermissionList.Add(permissionObj);
                    }
                }
            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }

            return rolePermissionList;
        }

        /// <summary>
        ///     Retrieve the permissions associated with the username from Odin_RolePermissions
        /// </summary>
        /// <param name="name">Name of current user</param>
        /// <returns>List of permissions</returns>
        public List<string> RetrievePermissions(string name)
        {
            List<string> RequestList = new List<string>();
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_GetPermissions", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = name;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        string request = Convert.ToString(reader["Permission"]).Trim();
                        RequestList.Add(request);
                    }
                }
            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }
            return RequestList;
        }
        
        /// <summary>
        ///     Retrieve a list of all the User name / role pairs
        /// </summary>
        /// <returns>List of all the user name / role pairs</returns>
        public ObservableCollection<PermissionObj> RetrieveUserRoleList()
        {
            ObservableCollection<PermissionObj> userRoleList = new ObservableCollection<PermissionObj>();
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_GetUserRoleList", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        PermissionObj permissionObj = new PermissionObj();
                        permissionObj.Field1 = Convert.ToString(reader["UserName"]).Trim();
                        permissionObj.Field2 = Convert.ToString(reader["Role"]).Trim();
                        userRoleList.Add(permissionObj);
                    }
                }


            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }

            return userRoleList;

        }
        /*
        /// <summary>
        ///     Retrieve a list of user names
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveUserNames()
        {
            List<string> Values = new List<string>();
            Values.Add("");
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveUserNames", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string UserName = Convert.ToString(reader["UserName"]);
                    Values.Add(UserName);                    
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieve a list of user roles
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveUserRoles()
        {
            List<string> Values = new List<string>();
            Values.Add("");
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetRolePermissionList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string RoleName = Convert.ToString(reader["Role"]);
                    if (!Values.Contains(RoleName))
                    {
                        Values.Add(RoleName);
                    }
                }
                reader.Close();
            }
            return Values;
        }
        */
        #endregion // Retrieval Methods

        /// <summary>
        ///     Change the role of a user
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <param name="role">New role</param>
        public bool UpdateUserRole(string userName, string role)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_UpdateUserRole", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = userName;
                    sqlCommand.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
                    sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex) { ErrorLog.LogError(ex.ToString()); }
            return false;
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the option repository
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbPassword"></param>
        /// <param name="dbServerName"></param>
        /// <param name="isLocalTest"></param>
        public OptionRepository(string dbName, string dbPassword, string dbServerName, bool isLocalTest)
        {
            DbServerName = dbServerName;
            DbName = dbName;
            DbPassword = dbPassword;
            IsLocalTest = isLocalTest;
        }

        #endregion // Constructor
    }
}
