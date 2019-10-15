using OdinModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace Odin.ViewModels
{
    public class DataViewModel
    {

        #region Properties

        /// <summary>
        ///     Gets or set a list of existing ItemIds
        /// </summary>
        public List<string> ItemIds
        {
            get
            {
                return _itemIds;
            }
            set
            {
                _itemIds = value;
                OnPropertyChanged("ItemIds");
            }
        }
        private List<string> _itemIds = new List<string>();

        /// <summary>
        ///     Gets or set a list of existing ProductVariations [variantId + ParentAsin]
        /// </summary>
        public List<KeyValuePair<string,string>> ProductVariations
        {
            get
            {
                return _productVariations;
            }
            set
            {
                _productVariations = value;
                OnPropertyChanged("ProductVariations");
            }
        }
        List<KeyValuePair<string, string>> _productVariations = new List<KeyValuePair<string, string>>();
        #endregion // Properties

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Events

        #region Methods

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     FieldEditWindowViewModel constructor
        /// </summary>
        /// <param name="fieldType">Name of field</param>
        /// <param name="fieldValue">Value of field</param>
        /// <param name="fieldStatus">Flag for update or add</param>
        /// <param name="itemService"></param>
        /// <param name="emailService"></param>
        public DataViewModel()
        {
            this.ItemIds = GlobalData.ItemIds;
            this.ItemIds.Sort();
            this.ProductVariations = GlobalData.ProductVariations;
            // this.ProductVariations.Sort();
        }

        #endregion // Constructor
    }
}
