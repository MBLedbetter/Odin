using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odin.DbTableModels
{
    public class OdinNotifications
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets DATE
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Gets or sets NOTIFICATION
        /// </summary>
        public string Notification { get; set; }

        /// <summary>
        ///     Gets or sets NOTIFICATION_NUMBER
        /// </summary>
        public int NotificationNumber { get; set; }

        #endregion // Public Properties
    }
}
