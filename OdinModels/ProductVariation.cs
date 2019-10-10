using Odin.DbTableModels;
using System;
using System.ComponentModel;

namespace OdinModels
{
    public class ProductVariation : INotifyPropertyChanged
    {

        #region Events

        /// <summary>
        ///     This event is raised when a property of this object is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Events

        #region Public Properties

        /// <summary>
        ///     Gets or sets ExternalParentId
        /// </summary>
        public string ExternalParentId
        {
            get
            {
                return this.ProductVariations.ExternalParentId;
            }
            set
            {
                this.ProductVariations.ExternalParentId = value;
                OnPropertyChanged("ExternalParentId");
            }
        }

        /// <summary>
        ///     Gets or sets ProductId
        /// </summary>
        public string ProductId
        {
            get
            {
                return this.ProductVariations.ProductId;
            }
            set
            {
                this.ProductVariations.ProductId = value;
                OnPropertyChanged("ProductId");
            }
        }

        /// <summary>
        ///     Gets or Sets the ProductVariations model
        /// </summary>
        private ProductVariations ProductVariations { get; set; }

        /// <summary>
        ///     Gets or sets VariationGroupId
        /// </summary>
        public string VariationGroupId
        {
            get
            {
                return this.ProductVariations.VariationGroupId;
            }
            set
            {
                this.ProductVariations.VariationGroupId = value;
                OnPropertyChanged("VariationGroupId");
            }
        }

        /// <summary>
        ///     Gets or sets VariationProductCategory
        /// </summary>
        public string VariationProductCategory
        {
            get
            {
                return this.ProductVariations.VariationProductCategory;
            }
            set
            {
                this.ProductVariations.VariationProductCategory = value;
                OnPropertyChanged("VariationProductCategory");
            }

        }

        #endregion // Public Properties

        #region Methods

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the ProductVariation model
        /// </summary>
        /// <param name="productVariations"></param>
        public ProductVariation(ProductVariations productVariations)
        {
            this.ProductVariations = productVariations;
        }

        #endregion // Constructor

    }
}
