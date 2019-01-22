using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DbTableModels
{
    /// <summary>
    ///     This class represents the PS_AMAZON_ITEM_ATTRIBUTES table
    /// </summary>
    public class AmazonItemAttributes
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets ASIN
        /// </summary>
        public string Asin { get; set; }

        /// <summary>
        ///     Gets or sets BULLET_1
        /// </summary>
        public string Bullet1 { get; set; }

        /// <summary>
        ///     Gets or sets BULLET_2
        /// </summary>
        public string Bullet2 { get; set; }

        /// <summary>
        ///     Gets or sets BULLET_3
        /// </summary>
        public string Bullet3 { get; set; }

        /// <summary>
        ///     Gets or sets BULLET_4
        /// </summary>
        public string Bullet4 { get; set; }

        /// <summary>
        ///     Gets or sets BULLET_5
        /// </summary>
        public string Bullet5 { get; set; }

        /// <summary>
        ///     Gets or sets COMPONENTS
        /// </summary>
        public string Components { get; set; }

        /// <summary>
        ///     Gets or sets COST
        /// </summary>
        public decimal? Cost{ get; set; }

        /// <summary>
        ///     Gets or sets COUNTRY_OF_ORIGIN
        /// </summary>
        public string CountryOfOrigin { get; set; }

        /// <summary>
        ///     Gets or sets EXTERNAL_ID
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        ///     Gets or sets EXTERNAL_ID_TYPE
        /// </summary>
        public string ExternalIdType { get; set; }

        /// <summary>
        ///     Gets or sets FULL_DESCRIPTION
        /// </summary>
        public string FullDescription { get; set; }
        
        /// <summary>
        ///     Gets or sets GENERIC_KEYWORDS
        /// </summary>
        public string GenericKeywords { get; set; }

        /// <summary>
        ///     Gets or sets HEIGHT
        /// </summary>
        public decimal? Height { get; set; }

        /// <summary>
        ///     Gets or sets IMAGE_URL_1
        /// </summary>
        public string ImageUrl1 { get; set; }

        /// <summary>
        ///     Gets or sets IMAGE_URL_2
        /// </summary>
        public string ImageUrl2 { get; set; }

        /// <summary>
        ///     Gets or sets IMAGE_URL_3
        /// </summary>
        public string ImageUrl3 { get; set; }

        /// <summary>
        ///     Gets or sets IMAGE_URL_4
        /// </summary>
        public string ImageUrl4 { get; set; }

        /// <summary>
        ///     Gets or sets IMAGE_URL_5
        /// </summary>
        public string ImageUrl5 { get; set; }

        /// <summary>
        ///     Gets or sets INV_ITEM_ID
        /// </summary>
        public string InvItemId { get; set; }

        /// <summary>
        ///     Gets or sets ITEM_NAME
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        ///     Gets or sets LENGTH
        /// </summary>
        public decimal? Length { get; set; }

        /// <summary>
        ///     Gets or sets MANUFACTURER_NAME
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        ///     Gets or sets MODEL_NAME
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        ///     Gets or sets MSRP
        /// </summary>
        public decimal? Msrp { get; set; }

        /// <summary>
        ///     Gets or sets PACKAGE_HEIGHT
        /// </summary>
        public decimal? PackageHeight { get; set; }

        /// <summary>
        ///     Gets or sets PACKAGE_LENGTH
        /// </summary>
        public decimal? PackageLength { get; set; }

        /// <summary>
        ///     Gets or sets PACKAGE_WEIGHT
        /// </summary>
        public decimal? PackageWeight { get; set; }

        /// <summary>
        ///     Gets or sets PACKAGE_WIDTH
        /// </summary>
        public decimal? PackageWidth { get; set; }

        /// <summary>
        ///     Gets or sets PAGE_COUNT
        /// </summary>
        public int PageCount { get; set; }
        
        /// <summary>
        ///     Gets or sets PRODUCT_CATEGORY
        /// </summary>
        public string ProductCategory { get; set; }

        /// <summary>
        ///     Gets or sets PRODUCT_SUBCATEGORY
        /// </summary>
        public string ProductSubcategory { get; set; }

        /// <summary>
        ///     Gets or sets SIZE
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        ///     Gets or sets SEARCH_TERMS
        /// </summary>
        public string SubjectKeywords { get; set; }

        /// <summary>
        ///     Gets or sets UPC_OVERRIDE
        /// </summary>
        public string UpcOverride { get; set; }

        /// <summary>
        ///     Gets or sets WEIGHT
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        ///     Gets or sets WIDTH
        /// </summary>
        public decimal? Width { get; set; }

        #endregion // Public Properties
    }
}
