using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class OdinItemExceptions
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets EXCEPTION_RESULT
        /// </summary>
        public string ExceptionResult { get; set; }

        /// <summary>
        ///     Gets or sets EXCEPTION_TRIGGER
        /// </summary>
        public string ExceptionTrigger { get; set; }

        /// <summary>
        ///     Gets or sets EXCEPTION_VALUE
        /// </summary>
        public string ExceptionValue { get; set; }

        /// <summary>
        ///     Gets or sets FIELD
        /// </summary>
        public string Field { get; set; }

        #endregion // Public Properties
    }
}
