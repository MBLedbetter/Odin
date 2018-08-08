using OdinModels;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OdinRepositories
{
    public class DatabaseConnection
    {

        #region Properties

        private string DBServerName { get; set; }
        private string DBName { get; set; }
        private string DBPassword { get; set; }
        private bool IsLocalTest { get; set; }

        #endregion // Properties

        #region Methods

        public SqlConnection GetConnection(bool isLocalTest)
        {
            SqlConnection connection = null;

            string connString;
            if (IsLocalTest)
            {
                connString = string.Format("SERVER={0};DATABASE={1};TRUSTED_CONNECTION=Yes;", @"(local)\SQLEXPRESS", "Odin");
            }
            else
            {
                connString = string.Format("SERVER={0};DATABASE={1};UID=Odin;PWD={2};", DBServerName, DBName, DBPassword);
            }
            // Open the connection
            try
            {
                connection = new SqlConnection(connString);
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex.ToString());
                return null;
            }

            return connection;
        }

        #endregion // Methods

        #region Constructor

        public DatabaseConnection(string dbServerName, string dbName, string dbPassword, bool isLocalTest)
        {
            DBServerName = dbServerName;
            DBName = dbName;
            DBPassword = dbPassword;
            IsLocalTest = isLocalTest;
    }

        #endregion // Constructor
    }
}
