using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class OdinExcelLayoutData
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets COLUMN_NUMBER
        /// </summary>
        public int ColumnNumber { get; set; }

        /// <summary>
        ///     Gets or sets CUSTOMER
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        ///     Gets or sets FIELD
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        ///     Gets or sets LAYOUT_ID
        /// </summary>
        public int LayoutId { get; set; }

        /// <summary>
        ///     Gets or sets OPTION
        /// </summary>
        public string Option { get; set; }

        #endregion // Public Properties
    }
}
