using System;

namespace LogLibrary
{

    /// <summary>
    ///		This interface defines a service that creates named loggers.
    /// </summary>
    public interface ILogServiceFactory
    {

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
        ILogService CreateLogService(Type type);

    }

}
