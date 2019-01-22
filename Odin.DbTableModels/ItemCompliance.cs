using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    public class ItemCompliance
    {
        #region Public Properties
        
            /// <summary>
            ///     Gets or sets the INV_ITEM_ID field
            /// </summary>
            public string InvItemId { get; set; }
            /// <summary>
            ///     Gets or sets the SETID field
            /// </summary>
            public string Setid { get; set; }
            /// <summary>
            ///     Gets or sets the PROP_65_COMPLIANT field
            /// </summary>
            public string Prop65Compliant { get; set; }

        #endregion // Public Properties
    }
}
