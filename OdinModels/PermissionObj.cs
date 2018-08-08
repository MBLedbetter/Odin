using System.ComponentModel;

namespace OdinModels
{
    public class PermissionObj
    {
        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Public Events

        #region Public Properties

        /// <summary>
        ///     Gets or sets Field1
        /// </summary>
        public string Field1
        {
            get
            {
                return _field1;
            }
            set
            {
                _field1 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Field1"));
                }
            }
        }
        private string _field1 = string.Empty;

        /// <summary>
        ///     Gets or sets Field2
        /// </summary>
        public string Field2
        {
            get
            {
                return _field2;
            }
            set
            {
                _field2 = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Field2"));
                }
            }
        }
        private string _field2 = string.Empty;

        #endregion // Public Properties

        #region Constructors

        /// <summary>
        ///     Constructs the PermissionObj
        /// </summary>
        public PermissionObj()
        {
        }

        /// <summary>
        ///     Constructs the PermissionObj
        /// </summary>
        /// <param name="field1"></param>
        /// <param name="field2"></param>
        public PermissionObj(string field1, string field2)
        {
            this.Field1 = field1;
            this.Field2 = field2;
        }

        #endregion // Constructors
    }
}
