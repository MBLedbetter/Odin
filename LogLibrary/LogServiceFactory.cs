using System;

namespace LogLibrary
{

    /// <summary>
    ///		This class defines a factory that creates a named log service.
    /// </summary>
    public class LogServiceFactory : ILogServiceFactory
    {

        #region Fields

        /// <summary>
        ///		The title of the application that this log service factory belongs to.
        /// </summary>
        public readonly string ApplicationTitle;

        #endregion  // Fields

        #region Constructors

        /// <summary>
        ///		LogServiceFactory constructor.
        /// </summary>
        /// 
        /// <param name="applicationTitle">
        ///		The title of the application that this log service factory belongs to.
        ///	</param>
        public LogServiceFactory(string applicationTitle)
        {
            if (string.IsNullOrEmpty(applicationTitle))
            {
                throw new ArgumentNullException("applicationTitle");
            }

            this.ApplicationTitle = applicationTitle;
        }

        #endregion // Constructors

        #region Public Methods

        /// <summary>
        ///		This method creates a named log service for the specified type.
        /// </summary>
        /// 
        /// <param name="type">
        ///		The log type.
        ///	</param>
        ///	
        /// <returns>
        ///		Returns a new log service.
        ///	</returns>
        public ILogService CreateLogService(Type type)
        {
            return new LogService(type, this.ApplicationTitle);
        }

        #endregion // Public Methods

    }

}
