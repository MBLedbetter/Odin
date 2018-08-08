using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdinModels
{
    public class Field
    {
        #region Properties

        /// <summary>
        ///     Fields alert message
        /// </summary>
        private string Alert { get; set; }

        /// <summary>
        ///     Error message of given field
        /// </summary>
        private string ErrorMessage { get; set; }

        /// <summary>
        ///     Flag if field has error
        /// </summary>
        private bool HasError { get; set; }

        /// <summary>
        ///     Check for if field has been updated
        /// </summary>
        private bool IsUpdate { get; set; }

        /// <summary>
        ///     String value of the given field
        /// </summary>
        private string Value { get; set; }

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Returns the fields value
        /// </summary>
        /// <returns></returns>
        public string GetValue()
        {
            return this.Value;
        }

        /// <summary>
        ///     Returns if field has been updated or not
        /// </summary>
        /// <returns></returns>
        public bool GetStatus()
        {
            return this.IsUpdate;
        }

        /// <summary>
        ///     Sets the field's value
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(string value)
        {
            this.Value = value;
        }

        /// <summary>
        ///     Updates the fields value
        /// </summary>
        /// <param name="value"></param>
        public void UpdateValue(string value)
        {
            this.Value = value;
            this.IsUpdate = true;
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs field model
        /// </summary>
        public Field()
        {
            this.Alert = string.Empty;
            this.ErrorMessage = string.Empty;
            this.HasError = false;
            this.IsUpdate = false;
            this.Value = string.Empty;
        }

        #endregion // Constructor
    }
}
