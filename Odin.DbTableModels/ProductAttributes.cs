using System;

namespace Odin.DbTableModels
{
    public class ProductAttributes
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets ATTRIBUTE_TYPE
        /// </summary>
        public string AttributeType { get; set; }

        /// <summary>
        ///     Gets or sets ATTRIBUTE_VALUE
        /// </summary>
        public string AttributeValue { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_ID
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        ///     Gets or sets SETID
        /// </summary>
        public string SetId { get; set; }

        /// <summary>
        ///     Gets or sets TIMESTAMP
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        ///     Gets or sets USER_ID
        /// </summary>
        public string UserId { get; set; }

        #endregion // Public Properties
    }
}
