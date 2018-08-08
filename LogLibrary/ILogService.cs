using System;

namespace LogLibrary
{

    /// <summary>
    ///		This interface defines a class that has methods for logging events.
    /// </summary>
    public interface ILogService
    {

        /// <summary>
        ///		This method creates a new log service for the specified type.
        /// </summary>
        /// 
        /// <param name="type">
        ///		The class type that the new log service will belong to.
        ///	</param>
        ///	
        /// <returns>
        ///		Returns a new LogService object.
        ///	</returns>
        ILogService CreateLogService(Type type);

        /// <summary>
        ///		This method writes the specified message to the log at the Error level.
        /// </summary>
        /// 
        /// <param name="message">
        ///		The log message.
        ///	</param>
        ///	
        /// <param name="args">
        ///		The arguments to format.
        ///	</param>
        void Error(string message, params object[] args);

        /// <summary>
        ///		This method writes the specified message to the log at the Error level and shows
        ///		the error message in a message box.
        /// </summary>
        /// 
        /// <param name="message">
        ///		The log message.
        ///	</param>
        ///	
        /// <param name="args">
        ///		The arguments to format.
        ///	</param>
        void ErrorWithMessage(string message, params object[] args);

        /// <summary>
        ///		This method writes the specified exception's message to the log at the Error level
        ///		and displays the exception message in a message box.
        /// </summary>
        /// 
        /// <param name="exception">
        ///		The exception that generated this error.
        ///	</param>
        void Exception(Exception exception);

        /// <summary>
        ///		This method gets the fully-qualified file name of the file that this log service is
        ///		writing to.
        /// </summary>
        /// 
        ///	<returns>
        ///		Returns a fully-qualified file name.
        ///	</returns>
        string GetFileName();

        /// <summary>
        ///		This method writes the specified message to the log at the Info level.
        /// </summary>
        /// 
        /// <param name="message">
        ///		The log message.
        ///	</param>
        ///	
        /// <param name="args">
        ///		The arguments to format.
        ///	</param>
        void Info(string message, params object[] args);

        /// <summary>
        ///		This method writes the specified message to the log at the Warning level.
        /// </summary>
        /// 
        /// <param name="message">
        ///		The log message.
        ///	</param>
        ///	
        /// <param name="args">
        ///		The arguments to format.
        ///	</param>
        void Warning(string message, params object[] args);

    }

}
