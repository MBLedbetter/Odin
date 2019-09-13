using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdinModels
{
    public class ExcelCell
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the ColumnLetter
        /// </summary>
        public string ColumnLetter
        {
            get
            {
                return _columnLetter;
            }
            set
            {
                _columnLetter = value;
            }
        }
        private string _columnLetter = string.Empty;

        /// <summary>
        ///     Gets or sets the ColumnNumber
        /// </summary>
        public int ColumnNumber
        {
            get
            {
                return _columnNumber;
            }
            set
            {
                _columnNumber = value;
            }
        }
        private int _columnNumber = 0;

        /// <summary>
        ///     Gets or sets the Customer
        /// </summary>
        public string Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
            }
        }
        private string _customer = string.Empty;

        /// <summary>
        ///     Gets or sets the ExcelId
        /// </summary>
        public int ExcelId
        {
            get
            {
                return _excelId;
            }
            set
            {
                _excelId = value;
            }
        }
        private int _excelId = 0;

        /// <summary>
        ///     Gets or sets the Field
        /// </summary>
        public string Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;
            }
        }
        private string _field = string.Empty;

        /// <summary>
        ///     Gets or sets the HeaderOverride
        /// </summary>
        public string HeaderOverride
        {
            get
            {
                return _headerOverride;
            }
            set
            {
                _headerOverride = value;
            }
        }
        private string _headerOverride = string.Empty;

        /// <summary>
        ///     Gets or sets the Option
        /// </summary>
        public string Option
        {
            get
            {
                return _option;
            }
            set
            {
                _option = value;
            }
        }
        private string _option = string.Empty;

        #endregion // Properties

        #region Constructor

        /// <summary>
        ///     Constructs the ExcelCell object
        /// </summary>
        public ExcelCell()
        {

        }

        /// <summary>
        ///     Constructs the ExcelCell object
        /// </summary>
        public ExcelCell(string field, string headerOverride)
        {
            this.Field = field;
            this.HeaderOverride = headerOverride;
        }

        /// <summary>
        ///     Constructs the ExcelCell object with provided values
        /// </summary>
        public ExcelCell(int excelId, int columnNumber, string field, string option, string customer, string columnLetter = "")
        {
            this.ExcelId = excelId;
            this.ColumnLetter = columnLetter;
            this.ColumnNumber = columnNumber;
            this.Field = field;
            this.Option = option;
            this.Customer = customer;
        }

        #endregion // Constructor
    }
}
