using System.Data;
using System.Data.SqlClient;
using LogLibrary;

namespace Odin.Data.Tests
{
    static class DbHelpers
    {
        #region Public Methods

        /// <summary>
        ///     Clears the local test database.
        /// </summary>
        public static void ClearDatabase()
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("[ClearDatabase]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Gets a connection to the local test database.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns a database connection.
        /// </returns>
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            connection.Open();
            return connection;
        }

        /// <summary>
        ///     Gets a connection string to the local test database.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns a connection string.
        /// </returns>
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(local)\SQLExpress";
            builder.InitialCatalog = "Odin";
            builder.IntegratedSecurity = true;
            return builder.ConnectionString;
        }

        /// <summary>
        ///     Gets an OdinContextFactory object that is configured to connect to the local test
        ///     database.
        /// </summary>
        /// 
        /// <param name="logServiceFactory">
        ///     The log service factory that will be assigned to the new OdinContextFactory 
        ///     object.  If this parameter is null, then a mock log service factory will be used.
        /// </param>
        /// 
        /// <returns>
        ///     Returns a new context factory.
        /// </returns>
        public static OdinContextFactory GetContextFactory(ILogServiceFactory logServiceFactory = null)
        {
            if (logServiceFactory == null)
            {
                logServiceFactory = new MockLogServiceFactory();
            }
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            return new OdinContextFactory(connectionManager, logServiceFactory);
        }

        #region Public Insert Methods
        
        public static void InsertOrderLine(string itemId, string orderStatus)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("[Odin_InsertOrdLine]", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = itemId;
                sqlCommand.Parameters.Add("@orderStatus", SqlDbType.VarChar).Value = orderStatus;
                sqlCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Inserts a row into the PS_AR_IDCUST_EC table
        /// </summary>
        /// <param name="eipCtlId"></param>
        /// <param name="lbBankTransId"></param>
        /// <param name="lockboxId"></param>
        /// <param name="lockboxBatchId"></param>
        /// <param name="paymentSeqNum"></param>
        /// <param name="idSeqNum"></param>
        public static void InsertWebCategory(string category)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("[Odin_InsertCategory]", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@category", SqlDbType.VarChar).Value = category;
                sqlCommand.ExecuteNonQuery();
            }
        }

        #endregion // Public Insert Methods

        #endregion  // Public Methods

    }
}
