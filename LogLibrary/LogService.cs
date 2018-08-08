using System;
using System.Windows.Forms;
using NLog;
using NLog.Targets;

namespace LogLibrary
{

    /// <summary>
    ///		This class provides methods for writing log data.
    /// </summary>
    public class LogService : ILogService
    {

        #region Fields

        /// <summary>
        ///		The title of the application that this log service belongs to.
        /// </summary>
        private readonly string ApplicationTitle;

        /// <summary>
        ///		The logger that this class will use to write log messages.
        /// </summary>
        private readonly Logger Logger;

        #endregion   // Fields

        #region Constructors

        /// <summary>
        ///		LogService constructor.
        /// </summary>
        /// 
        /// <param name="name">
        ///		The name of this logger.
        ///	</param>
        ///	
        ///	<param name="applicationTitle">
        ///		The title of the application that this log service belongs to.
        ///	</param>
        public LogService(string name, string applicationTitle)
        {
            if (string.IsNullOrEmpty(applicationTitle))
            {
                throw new ArgumentNullException("applicationTitle");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            this.ApplicationTitle = applicationTitle;
            this.Logger = LogManager.GetLogger(name);
        }

        /// <summary>
        ///		LogService constructor.
        /// </summary>
        /// 
        /// <param name="type">
        ///		The class type that this logger belongs to.
        ///	</param>
        ///	
        ///	<param name="applicationTitle">
        ///		The title of the application that this log service belongs to.
        ///	</param>
        public LogService(Type type, string applicationTitle)
        {
            if (string.IsNullOrEmpty(applicationTitle))
            {
                throw new ArgumentNullException("applicationTitle");
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            this.ApplicationTitle = applicationTitle;
            this.Logger = LogManager.GetLogger(type.FullName);
        }

        #endregion // Constructors

        #region Public Methods

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
        public ILogService CreateLogService(Type type)
        {
            return new LogService(type, this.ApplicationTitle);
        }

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
        public void Error(string message, params object[] args)
        {
            this.Logger.Error(message, args);
        }

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
        public void ErrorWithMessage(string message, params object[] args)
        {
            Error(message, args);
            Message(message, args);
        }

        /// <summary>
        ///		This method writes the specified exception's message to the log at the Error level
        ///		and displays the exception message in a message box.
        /// </summary>
        /// 
        /// <param name="exception">
        ///		The exception that generated this error.
        ///	</param>
        public void Exception(Exception exception)
        {
            this.Logger.Error(exception.ToString());

            MessageBox.Show(exception.ToString(), this.ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        ///		This method gets the fully-qualified file name of the file that this log service is
        ///		writing to.
        /// </summary>
        /// 
        ///	<returns>
        ///		Returns a fully-qualified file name.
        ///	</returns>
        public string GetFileName()
        {
            var fileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
            // Need to set timestamp here if filename uses date. 
            // For example - filename="${basedir}/logs/${shortdate}/trace.log"
            var logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };
            string fileName = fileTarget.FileName.Render(logEventInfo);
            return fileName;
        }

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
        public void Info(string message, params object[] args)
        {
            this.Logger.Info(message, args);
        }

        /// <summary>
        ///		This method displays a message box.
        /// </summary>
        /// 
        /// <param name="message">
        ///		The message to display.
        /// </param>
        public void Message(string message, params object[] args)
        {
            MessageBox.Show(string.Format(message, args), this.ApplicationTitle);
        }

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
        public void Warning(string message, params object[] args)
        {
            this.Logger.Warn(message, args);
        }

        #endregion // Public Methods

    }

}
