using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class ProductLines
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets INCLUDE_IN_CATALOG
        /// </summary>
        public string IncludeInCatalog { get; set; }

        /// <summary>
        ///     Gets or sets PROD_GROUP
        /// </summary>
        public string ProdGroup { get; set; }

        /// <summary>
        ///     Gets or sets PROD_LINE
        /// </summary>
        public string ProdLine { get; set; }

        #endregion // Public Properties
    }
}
