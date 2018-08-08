
namespace Odin.Data
{

    public interface IConnectionManager
    {

        /// <summary>
        ///     Gets a connection string to the database.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns a connection string.
        /// </returns>
        string GetConnectionString();

        /// <summary>
        ///     Gets the name of the database that this connection manager is configured to connect
        ///     to.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns a database name.
        /// </returns>
        string GetDatabaseName();

        /// <summary>
        ///     Gets the database server that this connection manager is configured to connect to.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns a server name.
        /// </returns>
        string GetDatabaseServer();

        /// <summary>
        ///     Sets the name of the database that this connection manager is configured to connect
        ///     to.
        /// </summary>
        /// 
        /// <param name="databaseName">
        ///     The database name.
        /// </param>
        void SetDatabaseName(string databaseName);

        /// <summary>
        ///     Sets the name of the database server this connection manager is configured to 
        ///     connect to.
        /// </summary>
        /// 
        /// <param name="server">
        ///     The server name.
        /// </param>
        void SetDatabaseServer(string server);

        /// <summary>
        ///     Sets a flag that determines whether connection manager will use a trusted 
        ///     connection when creating a connection string.
        /// </summary>
        /// 
        /// <param name="useTrustedConnection">
        ///     A flag that indicates whether to use trusted connections.
        /// </param>
        void SetUseTrustedConnection(bool useTrustedConnection);

    }

}
