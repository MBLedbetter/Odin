using System;
using LogLibrary;

namespace Odin.Data
{
    public class OdinContextFactory : IOdinContextFactory
    {
        #region Fields

        /// <summary>
        ///		The connection manager that this object will use to get database connection 
        ///		strings.
        /// </summary>
        private readonly IConnectionManager connectionManager;

        /// <summary>
        ///		The factory that will create the log service that this object will use to write log
        ///		messages.
        /// </summary>
        private readonly ILogServiceFactory logServiceFactory;

        #endregion  // Fields

        #region Constructors

        /// <summary>
        ///     SolediContextFactory constructor.
        /// </summary>
        /// 
        /// <param name="connectionManager">
        ///		The connection manager that this object will use to get database connection 
        ///		strings.
        /// </param>
        /// 
        /// <param name="logServiceFactory">
        ///		The factory that will create the log service that this object will use to write log
        ///		messages.
        /// </param>
        public OdinContextFactory(IConnectionManager connectionManager, ILogServiceFactory logServiceFactory)
        {
            if (connectionManager == null)
            {
                throw new ArgumentNullException("connectionManager");
            }
            if (logServiceFactory == null)
            {
                throw new ArgumentNullException("logServiceFactory");
            }

            this.connectionManager = connectionManager;
            this.logServiceFactory = logServiceFactory;
        }

        #endregion  // Constructors

        #region Public Methods

        /// <summary>
        ///     Creates a new Entity Framework context.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns a new context.
        /// </returns>
        public OdinContext CreateContext()
        {
            return new OdinContext(this.connectionManager.GetConnectionString(), this.logServiceFactory);
        }

        #endregion  // Public Methods
    }
}
