using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdinModels
{
    public class ProductFormat
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the format
        /// </summary>
        public string Format
        {
            get
            {
                return _format;
            }
            set
            {
                _format = value;
            }
        }
        private string _format = string.Empty;

        /// <summary>
        ///     Gets or sets the Group
        /// </summary>
        public string Group
        {
            get
            {
                return _group;
            }
            set
            {
                _group = value;
            }
        }
        private string _group = string.Empty;

        /// <summary>
        ///     Gets or sets the format
        /// </summary>
        public string Line
        {
            get
            {
                return _line;
            }
            set
            {
                _line = value;
            }
        }
        private string _line = string.Empty;

        #endregion // Properties

        #region Constructor

        /// <summary>
        ///     Constructs the Product Format model
        /// </summary>
        /// <param name="prodFormat"></param>
        /// <param name="prodLine"></param>
        /// <param name="prodGroup"></param>
        public ProductFormat(string prodFormat, string prodLine, string prodGroup)
        {
            this.Format = prodFormat;
            this.Line = prodLine;
            this.Group = prodGroup;
        }

        #endregion // Constructor
    }
}
