using System;
using System.Data.SqlClient;
using System.Windows;

namespace Odin.Data
{

    public class ConnectionManager : IConnectionManager
    {

        #region Fields

        /// <summary>
        ///     The name of the database that this connection manager will connect to.
        /// </summary>
        private string databaseName;

        /// <summary>
        ///     The name of the database server that this connection manager will connect to.
        /// </summary>
        private string databaseServer;

        private string userId = "Odin";

        private string password;


        /// <summary>
        ///     A flag that indicates whether this connection manager will use a trusted connection
        ///     when creating a connection string.
        /// </summary>
        private bool useTrustedConnection;

        #endregion  // Fields

        #region Constructors

        /// <summary>
        ///		ConnectionManager constructor.
        /// </summary>
        /// 
        /// <param name="server">
        ///		The name of the database server that this connection manager will connect to.
        ///	</param>
        ///	
        /// <param name="databaseName">
        ///		The name of the database that this connection manager will connect to.
        /// </param>
        public ConnectionManager(string server, string databaseName)
        {
            if (string.IsNullOrEmpty(server))
            {
                throw new ArgumentNullException("server");
            }
            if (string.IsNullOrEmpty(databaseName))
            {
                throw new ArgumentNullException("databaseName");
            }

            this.databaseName = databaseName;
            this.databaseServer = server;
        }

        #endregion  // Constructors

        #region Public Methods

        /// <summary>
        ///     Gets a connection string to the database.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns a connection string.
        /// </returns>
        public string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();

            connectionBuilder.DataSource = this.databaseServer;
            connectionBuilder.InitialCatalog = this.databaseName;
            connectionBuilder.ConnectTimeout = 500;
            if (this.useTrustedConnection)
            {
                connectionBuilder.IntegratedSecurity = this.useTrustedConnection;
            }
            else
            {
                connectionBuilder.UserID = this.userId;
                connectionBuilder.Password = this.password;
            }

            return connectionBuilder.ConnectionString;
        }

        /// <summary>
        ///     Gets the name of the database that this connection manager is configured to connect
        ///     to.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns a database name.
        /// </returns>
        public string GetDatabaseName()
        {
            return this.databaseName;
        }

        /// <summary>
        ///     Gets the database server that this connection manager is configured to connect to.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns a server name.
        /// </returns>
        public string GetDatabaseServer()
        {
            return this.databaseServer;
        }

        /// <summary>
        ///     Sets the name of the database that this connection manager is configured to connect
        ///     to.
        /// </summary>
        /// 
        /// <param name="databaseName">
        ///     The database name.
        /// </param>
        public void SetDatabaseName(string databaseName)
        {
            this.databaseName = databaseName;
        }

        /// <summary>
        ///     Sets the name of the database server this connection manager is configured to 
        ///     connect to.
        /// </summary>
        /// 
        /// <param name="server">
        ///     The server name.
        /// </param>
        public void SetDatabaseServer(string server)
        {
            this.databaseServer = server;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }

        /// <summary>
        ///     Sets a flag that determines whether connection manager will use a trusted 
        ///     connection when creating a connection string.
        /// </summary>
        /// 
        /// <param name="useTrustedConnection">
        ///     A flag that indicates whether to use trusted connections.
        /// </param>
        public void SetUseTrustedConnection(bool useTrustedConnection)
        {
            this.useTrustedConnection = useTrustedConnection;
        }

        #endregion  // Public Methods

    }

}
