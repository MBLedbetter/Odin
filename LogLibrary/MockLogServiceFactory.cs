using System;
using Moq;

namespace LogLibrary
{

    /// <summary>
    ///		This class defines a mock log service that can be used for tests.  When this class
    ///		creates a new LogService object, the returned object with be a Moq.Mock object.
    /// </summary>
    public class MockLogServiceFactory : ILogServiceFactory
    {

        #region Pubilc Methods

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
            return new Mock<ILogService>().Object;
        }

        #endregion // Public Methods

    }

}
