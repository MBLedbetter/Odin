using System;
using System.Data.Entity;
using LogLibrary;
using System.ComponentModel.DataAnnotations.Schema;
using Odin.DbTableModels;

namespace Odin.Data
{
    public class OdinContext : DbContext
    {

        #region Fields

        /// <summary>
        ///		The service that this object will use to write log messages.
        /// </summary>
        private readonly ILogService logService;

        /// <summary>
        ///		The factory that this object will use to create log services.
        /// </summary>
        private readonly ILogServiceFactory logServiceFactory;

        #endregion  // Fields

        #region Public Properties

        /// <summary>
        ///     Gets or sets a list of the Amazon Item Attributes lines that are in this context.
        /// </summary>
        public DbSet<AmazonItemAttributes> AmazonItemAttributes { get; set; }

        /// <summary>
        ///     Gets or sets a list of the Asset Item Attribute lines that are in this context.
        /// </summary>
        public DbSet<AssetItemAttr> AssetItemAttr { get; set; }

        /// <summary>
        ///     Gets or sets a list of the Bu Items Config lines that are in this context.
        /// </summary>
        public DbSet<BuItemsConfig> BuItemsConfig { get; set; }

        /// <summary>
        ///     Gets or sets a list of the BuItemsInv lines that are in this context.
        /// </summary>
        public DbSet<BuItemsInv> BuItemsInv { get; set; }

        /// <summary>
        ///     Gets or sets a list of the BuItemUtilCd lines that are in this context.
        /// </summary>
        public DbSet<BuItemUtilCd> BuItemUtilCd { get; set; }

        /// <summary>
        ///     Gets or sets a list of the CmGroupDefn lines that are in this context.
        /// </summary>
        public DbSet<CmGroupDefn> CmGroupDefn { get; set; }

        /// <summary>
        ///     Gets or sets a list of the CmItemMethod lines that are in this context.
        /// </summary>
        public DbSet<CmItemMethod> CmItemMethod { get; set; }

        /// <summary>
        ///     Gets or sets a list of the CountryTbl lines that are in this context.
        /// </summary>
        public DbSet<CountryTbl> CountryTbl { get; set; }

        /// <summary>
        ///     Gets or sets a list of the CustomerProductAttributes lines that are in this context.
        /// </summary>
        public DbSet<CustomerProductAttributes> CustomerProductAttributes { get; set; }

        /// <summary>
        ///     Gets or sets a list of the DefaultLocInv lines that are in this context.
        /// </summary>
        public DbSet<DefaultLocInv> DefaultLocInv { get; set; }

        /// <summary>
        ///     Gets or sets a list of the EnBomComps lines that are in this context.
        /// </summary>
        public DbSet<EnBomComps> EnBomComps { get; set; }
        
        /// <summary>
        ///     Gets or sets a list of the EnBomHeader lines that are in this context.
        /// </summary>
        public DbSet<EnBomHeader> EnBomHeader { get; set; }

        /// <summary>
        ///     Gets or sets a list of the EnBomOutputs lines that are in this context.
        /// </summary>
        public DbSet<EnBomOutputs> EnBomOutputs { get; set; }

        /// <summary>
        ///     Gets or sets a list of the FxdBinLocInv lines that are in this context.
        /// </summary>
        public DbSet<FxdBinLocInv> FxdBinLocInv { get; set; }

        /// <summary>
        ///     Gets or sets a list of the HrmnTariffCd lines that are in this context.
        /// </summary>
        public DbSet<HrmnTariffCd> HrmnTariffCd { get; set; }
                
        /// <summary>
        ///     Gets or sets a list of the InvItemFam lines that are in this context.
        /// </summary>
        public DbSet<InvItemFam> InvItemFam { get; set; }

        /// <summary>
        ///     Gets or sets a list of the InvItemGroupTable lines that are in this context.
        /// </summary>
        public DbSet<InvItemGroupTable> InvItemGroup { get; set; }

        /// <summary>
        ///     Gets or sets a list of the InvItems lines that are in this context.
        /// </summary>
        public DbSet<InvItems> InvItems { get; set; }

        /// <summary>
        ///     Gets or sets a list of the InvItemUom lines that are in this context.
        /// </summary>
        public DbSet<InvItemUom> InvItemUom { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ItemAttribEx lines that are in this context.
        /// </summary>
        public DbSet<ItemAttribEx> ItemAttribEx { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ItemCompliance lines that are in this context.
        /// </summary>
        public DbSet<ItemCompliance> ItemCompliance { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ItemStatusTbl lines that are in this context.
        /// </summary>
        public DbSet<ItemStatusTbl> ItemStatusTbl { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ItemLanguage lines that are in this context.
        /// </summary>
        public DbSet<ItemLanguage> ItemLanguage { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ItemMfg lines that are in this context.
        /// </summary>
        public DbSet<ItemMfg> ItemMfg { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ItemTerritory lines that are in this context.
        /// </summary>
        public DbSet<ItemTerritory> ItemTerritory { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ItemWebInfo lines that are in this context.
        /// </summary>
        public DbSet<ItemWebInfo> ItemWebInfo { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ItmCatTbl lines that are in this context.
        /// </summary>
        public DbSet<ItmCatTbl> ItmCatTbl { get; set; }

        /// <summary>
        ///     Gets or sets a list of the LanguageTbl lines that are in this context.
        /// </summary>
        public DbSet<LanguageTbl> LanguageTbl { get; set; }

        /// <summary>
        ///     Gets or sets a list of the MarketplaceCustomerProducts lines that are in this context.
        /// </summary>
        public DbSet<MarketplaceCustomerProducts> MarketplaceCustomerProducts { get; set; }

        /// <summary>
        ///     Gets or sets a list of the MarketplaceProductTranslations lines that are in this context.
        /// </summary>
        public DbSet<MarketplaceProductTranslations> MarketplaceProductTranslations { get; set; }

        /// <summary>
        ///     Gets or sets a list of the MasterItemTbl lines that are in this context.
        /// </summary>
        public DbSet<MasterItemTbl> MasterItemTbl { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinAutoNumberControlTable lines that are in this context.
        /// </summary>
        public DbSet<OdinAutoNumberControlTable> OdinAutoNumberControlTable { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinCustomerConversion lines that are in this context.
        /// </summary>
        public DbSet<OdinCustomerConversion> OdinCustomerConversion { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinExcelLayoutData lines that are in this context.
        /// </summary>
        public DbSet<OdinExcelLayoutData> OdinExcelLayoutData { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinExcelLayoutIds lines that are in this context.
        /// </summary>
        public DbSet<OdinExcelLayoutIds> OdinExcelLayoutIds { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinFieldValues lines that are in this context.
        /// </summary>
        public DbSet<OdinFieldValues> OdinFieldValues { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinItemidSuffixes lines that are in this context.
        /// </summary>
        public DbSet<OdinItemIdSuffixes> OdinItemIdSuffixes { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinItemOverrideInfo lines that are in this context.
        /// </summary>
        public DbSet<OdinItemOverrideInfo> OdinItemOverrideInfo { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinGenres lines that are in this context.
        /// </summary>
        public DbSet<OdinGenres> OdinGenres { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinGlobalKeys lines that are in this context.
        /// </summary>
        public DbSet<OdinGlobalKeys> OdinGlobalKeys { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinItem lines that are in this context.
        /// </summary>
        public DbSet<OdinItem> OdinItem { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinItemExceptions lines that are in this context.
        /// </summary>
        public DbSet<OdinItemExceptions> OdinItemExceptions { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinItemTemplates lines that are in this context.
        /// </summary>
        public DbSet<OdinItemTemplates> OdinItemTemplates { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinItemTypeExtensions lines that are in this context.
        /// </summary>
        public DbSet<OdinItemTypeExtensions> OdinItemTypeExtensions { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinItemUpdateRecords lines that are in this context.
        /// </summary>
        public DbSet<OdinItemUpdateRecords> OdinItemUpdateRecords { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinLanguage lines that are in this context.
        /// </summary>
        public DbSet<OdinLanguage> OdinLanguage { get; set; }
        
        /// <summary>
        ///     Gets or sets a list of the OdinMetaDescription lines that are in this context.
        /// </summary>
        public DbSet<OdinMetaDescription> OdinMetaDescription { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinNewWebCategories lines that are in this context.
        /// </summary>
        public DbSet<OdinNewWebCategories> OdinNewWebCategories { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinNotifications lines that are in this context.
        /// </summary>
        public DbSet<OdinNotifications> OdinNotifications { get; set; }

        /// <summary>
        ///     Gets or sets a list of the xxx lines that are in this context.
        /// </summary>
        public DbSet<OdinOptionsTable> OdinOptionsTable { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinRequestComments lines that are in this context.
        /// </summary>
        public DbSet<OdinRequestComments> OdinRequestComments { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinRolePermissions lines that are in this context.
        /// </summary>
        public DbSet<OdinRolePermissions> OdinRolePermissions { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinShoptrendsBrands lines that are in this context.
        /// </summary>
        public DbSet<OdinShoptrendsBrands> OdinShoptrendsBrands { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinSpecialChars lines that are in this context.
        /// </summary>
        public DbSet<OdinSpecialChars> OdinSpecialChars { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinTerritories lines that are in this context.
        /// </summary>
        public DbSet<OdinTerritories> OdinTerritories { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinToolTips lines that are in this context.
        /// </summary>
        public DbSet<OdinToolTips> OdinToolTips { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinUserExceptions lines that are in this context.
        /// </summary>
        public DbSet<OdinUserExceptions> OdinUserExceptions { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinUserRoles lines that are in this context.
        /// </summary>
        public DbSet<OdinUserRoles> OdinUserRoles { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinWebCategories lines that are in this context.
        /// </summary>
        public DbSet<OdinWebCategories> OdinWebCategories { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinWebLanguages lines that are in this context.
        /// </summary>
        public DbSet<OdinWebLanguages> OdinWebLanguages { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinWebLicense lines that are in this context.
        /// </summary>
        public DbSet<OdinWebLicense> OdinWebLicense { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinWebsiteItemRequests lines that are in this context.
        /// </summary>
        public DbSet<OdinWebsiteItemRequests> OdinWebsiteItemRequests { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OdinWebTerritories lines that are in this context.
        /// </summary>
        public DbSet<OdinWebTerritories> OdinWebTerritories { get; set; }

        /// <summary>
        ///     Gets or sets a list of the OrdLine lines that are in this context.
        /// </summary>
        public DbSet<OrdLine> OrdLine { get; set; }

        /// <summary>
        ///     Gets or sets a list of the PlItemAttrib lines that are in this context.
        /// </summary>
        public DbSet<PlItemAttrib> PlItemAttrib { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProdCatgryTbl lines that are in this context.
        /// </summary>
        public DbSet<ProdCatgryTbl> ProdCatgryTbl { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProdGroupTbl lines that are in this context.
        /// </summary>
        public DbSet<ProdGroupTbl> ProdGroupTbl { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProdItem lines that are in this context.
        /// </summary>
        public DbSet<ProdItem> ProdItem { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProdPgrpLnk lines that are in this context.
        /// </summary>
        public DbSet<ProdPgrpLnk> ProdPgrpLnk { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProdPrice lines that are in this context.
        /// </summary>
        public DbSet<ProdPrice> ProdPrice { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProdPriceBu lines that are in this context.
        /// </summary>
        public DbSet<ProdPriceBu> ProdPriceBu { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProductAttributes lines that are in this context.
        /// </summary>
        public DbSet<ProductAttributes> ProductAttributes { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProductAttributeTypes lines that are in this context.
        /// </summary>
        public DbSet<ProductAttributeTypes> ProductAttributeTypes{ get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProductFormats lines that are in this context.
        /// </summary>
        public DbSet<ProductFormats> ProductFormats { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProductGroups lines that are in this context.
        /// </summary>
        public DbSet<ProductGroups> ProductGroups { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProductLines lines that are in this context.
        /// </summary>
        public DbSet<ProductLines> ProductLines { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProductVariations lines that are in this context.
        /// </summary>
        public DbSet<ProductVariations> ProductVariations { get; set; }

        /// <summary>
        ///     Gets or sets a list of the ProdUom lines that are in this context.
        /// </summary>
        public DbSet<ProdUom> ProdUom { get; set; }

        /// <summary>
        ///     Gets or sets a list of the PurchItemAttr lines that are in this context.
        /// </summary>
        public DbSet<PurchItemAttr> PurchItemAttr { get; set; }

        /// <summary>
        ///     Gets or sets a list of the PurchItemBu lines that are in this context.
        /// </summary>
        public DbSet<PurchItemBu> PurchItemBu { get; set; }

        /// <summary>
        ///     Gets or sets a list of the PvItmCategory lines that are in this context.
        /// </summary>
        public DbSet<PvItmCategory> PvItmCategory { get; set; }

        /// <summary>
        ///     Gets or sets a list of the SfPrdnAreaIt lines that are in this context.
        /// </summary>
        public DbSet<SfPrdnAreaIt> SfPrdnAreaIt { get; set; }

        /// <summary>
        ///     Gets or sets a list of the StatsCodes lines that are in this context.
        /// </summary>
        public DbSet<StatsCodes> StatsCodes { get; set; }

        /// <summary>
        ///     Gets or sets a list of the UomTypeInv lines that are in this context.
        /// </summary>
        public DbSet<UomTypeInv> UomTypeInv { get; set; }

        #endregion  // Public Properties

        #region Constructors

        /// <summary>
        ///		SolediContext constructor.
        /// </summary>
        /// 
        ///	<param name="connectionString">
        ///     The connection string that this context will use to connect to the database.
        ///	</param>
        ///	
        ///	<param name="logServiceFactory">
        ///		The service that this object will use to write log messages.
        ///	</param>
        public OdinContext(string connectionString, ILogServiceFactory logServiceFactory) : base(connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            if (logServiceFactory == null)
            {
                throw new ArgumentNullException("logServiceFactory");
            }

            // This is needed so that Entity Framework doesn't cache the database structure
            Database.SetInitializer<OdinContext>(null);

            //this.connectionManager = connectionManager;
            this.logService = logServiceFactory.CreateLogService(GetType());
            this.logServiceFactory = logServiceFactory;

            this.Database.Log = x => this.logService.Info(x);
            //this.Database.Log = x => System.Diagnostics.Debug.WriteLine(x);
        }

        #endregion  // Constructors

        #region Protected Methods

        /// <summary>
        ///		This method is called when this context creates its database models.  This method 
        ///		defines the mapping between POCO objects and database tables and stored procedures.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///		The model builder.
        ///	</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            MapAmazonItemAttributes(modelBuilder);
            MapAssetItemAttr(modelBuilder);
            MapBuItemsConfig(modelBuilder);
            MapBuItemsInv(modelBuilder);
            MapBuItemUtilCd(modelBuilder);
            MapCmGroupDefn(modelBuilder);
            MapCmItemMethod(modelBuilder);
            MapCountryTbl(modelBuilder);
            MapCustomerProductAttributes(modelBuilder);
            MapDefaultLocInv(modelBuilder);
            MapEnBomComps(modelBuilder);
            MapEnBomHeader(modelBuilder);
            MapEnBomOutputs(modelBuilder);
            MapFxdBinLocInv(modelBuilder);
            MapHrmnTariffCd(modelBuilder);
            MapInvItemFam(modelBuilder);
            MapInvItemGroup(modelBuilder);
            MapInvItems(modelBuilder);
            MapInvItemUom(modelBuilder);
            MapItemAttribEx(modelBuilder);
            MapItemCompliance(modelBuilder);
            MapItemLanguage(modelBuilder);
            MapItemMfg(modelBuilder);
            MapItemStatusTbl(modelBuilder);
            MapItemTerritory(modelBuilder);
            MapItemWebInfo(modelBuilder);
            MapItmCatTbl(modelBuilder);
            MapLanguageTbl(modelBuilder);
            MapMarketplaceCustomerProducts(modelBuilder);
            MapMarketplaceProductTranslations(modelBuilder);
            MapMasterItemTbl(modelBuilder);
            MapOdinAutoNumberControlTable(modelBuilder);
            MapOdinCustomerConversion(modelBuilder);
            MapOdinExcelLayoutData(modelBuilder);
            MapOdinExcelLayoutIds(modelBuilder);
            MapOdinFieldValues(modelBuilder);
            MapOdinGenres(modelBuilder);
            MapOdinGlobalKeys(modelBuilder);
            MapOdinItem(modelBuilder);
            MapOdinItemExceptions(modelBuilder);
            MapOdinItemIdSuffixes(modelBuilder);
            MapOdinItemOverrideInfo(modelBuilder);
            MapOdinItemTemplates(modelBuilder);
            MapOdinItemTypeExtensions(modelBuilder);
            MapOdinItemUpdateRecords(modelBuilder);
            MapOdinLanguage(modelBuilder);
            MapOdinMetaDescription(modelBuilder);
            MapOdinNewWebCategories(modelBuilder);
            MapOdinNotifications(modelBuilder);
            MapOdinOptionsTable(modelBuilder);
            MapOdinRequestComments(modelBuilder);
            MapOdinRolePermissions(modelBuilder);
            MapOdinShoptrendsBrands(modelBuilder);
            MapOdinSpecialChars(modelBuilder);
            MapOdinTerritories(modelBuilder);
            MapOdinToolTips(modelBuilder);
            MapOdinUserExceptions(modelBuilder);
            MapOdinUserRoles(modelBuilder);
            MapOdinWebLanguages(modelBuilder);
            MapOdinWebLicense(modelBuilder);
            MapOdinWebsiteItemRequests(modelBuilder);
            MapOdinWebTerritories(modelBuilder);
            MapOrdLine(modelBuilder);
            MapPlItemAttrib(modelBuilder);
            MapProdCatgryTbl(modelBuilder);
            MapProdGroupTbl(modelBuilder);
            MapProdItem(modelBuilder);
            MapProdPgrpLnk(modelBuilder);
            MapProdPrice(modelBuilder);
            MapProdPriceBu(modelBuilder);
            MapProductAttributes(modelBuilder);
            MapProductAttributeTypes(modelBuilder);
            MapProductFormats(modelBuilder);
            MapProductGroups(modelBuilder);
            MapProductLines(modelBuilder);
            MapProductVariations(modelBuilder);
            MapProdUom(modelBuilder);
            MapPurchItemAttr(modelBuilder);
            MapPurchItemBu(modelBuilder);
            MapPvItmCategory(modelBuilder);
            MapSfPrdnAreaIt(modelBuilder);
            MapStatsCodes(modelBuilder);
            MapUomTypeInv(modelBuilder);
        }

        #endregion  // Protected Methods

        #region Private Methods

        /// <summary>
        ///             This method maps the AmazonItemAttributes class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapAmazonItemAttributes(DbModelBuilder modelBuilder)
        {
            // Map the AmazonItemAttributes class to the PS_AMAZON_ITEM_ATTRIBUTES table
            modelBuilder.Entity<AmazonItemAttributes>()
                .HasKey(p => new
                {
                    p.InvItemId
                })
                .ToTable("PS_AMAZON_ITEM_ATTRIBUTES");

            // Map each column
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Asin).HasColumnName("ASIN");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Bullet1).HasColumnName("BULLET_1");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Bullet2).HasColumnName("BULLET_2");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Bullet3).HasColumnName("BULLET_3");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Bullet4).HasColumnName("BULLET_4");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Bullet5).HasColumnName("BULLET_5");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Components).HasColumnName("COMPONENTS");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Cost).HasColumnName("COST");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.CountryOfOrigin).HasColumnName("COUNTRY_OF_ORIGIN");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ExternalId).HasColumnName("EXTERNAL_ID");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ExternalIdType).HasColumnName("EXTERNAL_ID_TYPE");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.FullDescription).HasColumnName("FULL_DESCRIPTION");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.SubjectKeywords).HasColumnName("SEARCH_TERMS");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Height).HasColumnName("HEIGHT");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ImageUrl1).HasColumnName("IMAGE_URL_1");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ImageUrl2).HasColumnName("IMAGE_URL_2");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ImageUrl3).HasColumnName("IMAGE_URL_3");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ImageUrl4).HasColumnName("IMAGE_URL_4");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ImageUrl5).HasColumnName("IMAGE_URL_5");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ItemName).HasColumnName("ITEM_NAME");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ItemTypeKeywords).HasColumnName("ITEM_TYPE_KEYWORDS");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Length).HasColumnName("LENGTH");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ManufacturerName).HasColumnName("MANUFACTURER_NAME");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ModelName).HasColumnName("MODEL_NAME");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Msrp).HasColumnName("MSRP");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.PackageHeight).HasColumnName("PACKAGE_HEIGHT");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.PackageLength).HasColumnName("PACKAGE_LENGTH");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.PackageWeight).HasColumnName("PACKAGE_WEIGHT");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.PackageWidth).HasColumnName("PACKAGE_WIDTH");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.PageCount).HasColumnName("PAGE_COUNT");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ParentAsin).HasColumnName("PARENT_ASIN");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ProductCategory).HasColumnName("PRODUCT_CATEGORY");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.ProductSubcategory).HasColumnName("PRODUCT_SUBCATEGORY");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Size).HasColumnName("SIZE");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.GenericKeywords).HasColumnName("GENERIC_KEYWORDS");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.UpcOverride).HasColumnName("UPC_OVERRIDE");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Weight).HasColumnName("WEIGHT");
            modelBuilder.Entity<AmazonItemAttributes>().Property(p => p.Width).HasColumnName("WIDTH");

        }

        /// <summary>
        ///             This method maps the AssetItemAttr class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapAssetItemAttr(DbModelBuilder modelBuilder)
        {
            // Map the AssetItemAttr class to the PS_ASSET_ITEM_ATTR table
            modelBuilder.Entity<AssetItemAttr>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId
                })
                .ToTable("PS_ASSET_ITEM_ATTR");

            // Map each column
            modelBuilder.Entity<AssetItemAttr>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<AssetItemAttr>().Property(p => p.ProfileId).HasColumnName("PROFILE_ID");
            modelBuilder.Entity<AssetItemAttr>().Property(p => p.Setid).HasColumnName("SETID");

        }

        /// <summary>
        ///             This method maps the BuItemsConfig class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapBuItemsConfig(DbModelBuilder modelBuilder)
        {
            // Map the AmazonItemAttributes class to the PS_BU_ITEMS_CONFIG table
            modelBuilder.Entity<BuItemsConfig>()
                .HasKey(p => new
                {
                    p.BusinessUnit,
                    p.InvItemId
                })
                .ToTable("PS_BU_ITEMS_CONFIG");

            // Map each column
            modelBuilder.Entity<BuItemsConfig>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<BuItemsConfig>().Property(p => p.BusinessUnitCp).HasColumnName("BUSINESS_UNIT_CP");
            modelBuilder.Entity<BuItemsConfig>().Property(p => p.CfgLeadTime).HasColumnName("CFG_LEAD_TIME");
            modelBuilder.Entity<BuItemsConfig>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<BuItemsConfig>().Property(p => p.Lastupddttm).HasColumnName("LASTUPDDTTM");
            modelBuilder.Entity<BuItemsConfig>().Property(p => p.RefBomItem).HasColumnName("REF_BOM_ITEM");
            modelBuilder.Entity<BuItemsConfig>().Property(p => p.RuleBasedComp).HasColumnName("RULE_BASED_COMP");
            modelBuilder.Entity<BuItemsConfig>().Property(p => p.RuleBasedOper).HasColumnName("RULE_BASED_OPER");
            modelBuilder.Entity<BuItemsConfig>().Property(p => p.ShipTypeId).HasColumnName("SHIP_TYPE_ID");

        }

        /// <summary>
        ///             This method maps the BuItemsInv class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapBuItemsInv(DbModelBuilder modelBuilder)
        {
            // Map the BuItemsInv class to the PS_BU_ITEMS_INV table
            modelBuilder.Entity<BuItemsInv>()
                .HasKey(p => new
                {
                    p.BusinessUnit,
                    p.InvItemId
                })
                .ToTable("PS_BU_ITEMS_INV");

            // Map each column
            modelBuilder.Entity<BuItemsInv>().Property(p => p.AddHandling).HasColumnName("ADD_HANDLING");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.AnndmInstance).HasColumnName("ANNDM_INSTANCE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.AnndmStatus).HasColumnName("ANNDM_STATUS");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.Aoq).HasColumnName("AOQ");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.AvailLeadTime).HasColumnName("AVAIL_LEAD_TIME");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.AverageCost).HasColumnName("AVERAGE_COST");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.AverageCostMat).HasColumnName("AVERAGE_COST_MAT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.BomCode).HasColumnName("BOM_CODE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.BomUsage).HasColumnName("BOM_USAGE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ChargeCode).HasColumnName("CHARGE_CODE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ChargeMarkupAmt).HasColumnName("CHARGE_MARKUP_AMT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ChargeMarkupPcnt).HasColumnName("CHARGE_MARKUP_PCNT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ConsignedFlag).HasColumnName("CONSIGNED_FLAG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.CostElement).HasColumnName("COST_ELEMENT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.CostGroupCd).HasColumnName("COST_GROUP_CD");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.CountryIstOrigin).HasColumnName("COUNTRY_IST_ORIGIN");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.CurrentCost).HasColumnName("CURRENT_COST");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.CycleInstance).HasColumnName("CYCLE_INSTANCE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.DaysSupply).HasColumnName("DAYS_SUPPLY");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.DeclaredValue).HasColumnName("DECLARED_VALUE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.DfltActualCost).HasColumnName("DFLT_ACTUAL_COST");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.DockToStock).HasColumnName("DOCK_TO_STOCK");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.DpPolicycontrol).HasColumnName("DP_POLICYCONTROL");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.DpPolicyset).HasColumnName("DP_POLICYSET");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.DpPublishDate).HasColumnName("DP_PUBLISH_DATE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.DpPublishname).HasColumnName("DP_PUBLISHNAME");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.DtTimestamp).HasColumnName("DT_TIMESTAMP");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.EnAutoRev).HasColumnName("EN_AUTO_REV");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.Eoq).HasColumnName("EOQ");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.EoqcInstance).HasColumnName("EOQC_INSTANCE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.EoqcStatus).HasColumnName("EOQC_STATUS");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ExcessBu).HasColumnName("EXCESS_BU");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ExcessInventory).HasColumnName("EXCESS_INVENTORY");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ExportLicNbr).HasColumnName("EXPORT_LIC_NBR");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ExporterEccn).HasColumnName("EXPORTER_ECCN");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.Foq).HasColumnName("FOQ");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ForecastItemFlag).HasColumnName("FORECAST_ITEM_FLAG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.Forecaster).HasColumnName("FORECASTER");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.HistoricalLead).HasColumnName("HISTORICAL_LEAD");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.HldcInstance).HasColumnName("HLDC_INSTANCE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.HldcStatus).HasColumnName("HLDC_STATUS");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.InclWipQtyFlg).HasColumnName("INCL_WIP_QTY_FLG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.InspectTime).HasColumnName("INSPECT_TIME");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.InvStockType).HasColumnName("INV_STOCK_TYPE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.InventoryItem).HasColumnName("INVENTORY_ITEM");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.IpPlanningFlg).HasColumnName("IP_PLANNING_FLG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.IsolateItemFlg).HasColumnName("ISOLATE_ITEM_FLG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.IssueMethod).HasColumnName("ISSUE_METHOD");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.IssueMultiple).HasColumnName("ISSUE_MULTIPLE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.IstRegionOrigin).HasColumnName("IST_REGION_ORIGIN");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC1A).HasColumnName("ITEM_FIELD_C1_A");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC1B).HasColumnName("ITEM_FIELD_C1_B");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC1C).HasColumnName("ITEM_FIELD_C1_C");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC1D).HasColumnName("ITEM_FIELD_C1_D");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC10A).HasColumnName("ITEM_FIELD_C10_A");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC10B).HasColumnName("ITEM_FIELD_C10_B");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC10C).HasColumnName("ITEM_FIELD_C10_C");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC10D).HasColumnName("ITEM_FIELD_C10_D");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC2).HasColumnName("ITEM_FIELD_C2");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC30A).HasColumnName("ITEM_FIELD_C30_A");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC30B).HasColumnName("ITEM_FIELD_C30_B");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC30C).HasColumnName("ITEM_FIELD_C30_C");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC30D).HasColumnName("ITEM_FIELD_C30_D");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC4).HasColumnName("ITEM_FIELD_C4");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC6).HasColumnName("ITEM_FIELD_C6");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldC8).HasColumnName("ITEM_FIELD_C8");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldN12A).HasColumnName("ITEM_FIELD_N12_A");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldN12B).HasColumnName("ITEM_FIELD_N12_B");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldN12C).HasColumnName("ITEM_FIELD_N12_C");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldN12D).HasColumnName("ITEM_FIELD_N12_D");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldN15A).HasColumnName("ITEM_FIELD_N15_A");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldN15B).HasColumnName("ITEM_FIELD_N15_B");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldN15C).HasColumnName("ITEM_FIELD_N15_C");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItemFieldN15D).HasColumnName("ITEM_FIELD_N15_D");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItmStatDtFuture).HasColumnName("ITM_STAT_DT_FUTURE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItmStatusCurrent).HasColumnName("ITM_STATUS_CURRENT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItmStatusEffdt).HasColumnName("ITM_STATUS_EFFDT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ItmStatusFuture).HasColumnName("ITM_STATUS_FUTURE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.Last2QtrDemand).HasColumnName("LAST_2QTR_DEMAND");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastAdjustment).HasColumnName("LAST_ADJUSTMENT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastAnnualDemand).HasColumnName("LAST_ANNUAL_DEMAND");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastCycleCount).HasColumnName("LAST_CYCLE_COUNT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastDemandCalc).HasColumnName("LAST_DEMAND_CALC");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastDemandDate).HasColumnName("LAST_DEMAND_DATE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastIssExcess).HasColumnName("LAST_ISS_EXCESS");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastMoDemand).HasColumnName("LAST_MO_DEMAND");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastOrder).HasColumnName("LAST_ORDER");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastOrderDate).HasColumnName("LAST_ORDER_DATE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastPitCount).HasColumnName("LAST_PIT_COUNT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastPricePaid).HasColumnName("LAST_PRICE_PAID");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastPutawayDate).HasColumnName("LAST_PUTAWAY_DATE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastQtrDemand).HasColumnName("LAST_QTR_DEMAND");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastUdDemand).HasColumnName("LAST_UD_DEMAND");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.LastUtilReview).HasColumnName("LAST_UTIL_REVIEW");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.MasterRtgOpt).HasColumnName("MASTER_RTG_OPT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.MaterialReconFlg).HasColumnName("MATERIAL_RECON_FLG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.MfgCostedFlag).HasColumnName("MFG_COSTED_FLAG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.MfgLeadtimeF).HasColumnName("MFG_LEADTIME_F");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.MfgLeadtimeV).HasColumnName("MFG_LEADTIME_V");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.MfgLtratef).HasColumnName("MFG_LTRATEF");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.MfgLtratev).HasColumnName("MFG_LTRATEV");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.MgAssociatedBom).HasColumnName("MG_ASSOCIATED_BOM");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.MgPrdnOption).HasColumnName("MG_PRDN_OPTION");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.MgValidPrdnOpt).HasColumnName("MG_VALID_PRDN_OPT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.NextUtilReview).HasColumnName("NEXT_UTIL_REVIEW");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.NoReplenishFlg).HasColumnName("NO_REPLENISH_FLG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.NonOwnFlag).HasColumnName("NON_OWN_FLAG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.OrderMultiple).HasColumnName("ORDER_MULTIPLE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.Oversized).HasColumnName("OVERSIZED");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.PhantomItemFlag).HasColumnName("PHANTOM_ITEM_FLAG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.PlannerCd).HasColumnName("PLANNER_CD");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.PrdnAreaCode).HasColumnName("PRDN_AREA_CODE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ProjectedLead).HasColumnName("PROJECTED_LEAD");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.QtyAvailable).HasColumnName("QTY_AVAILABLE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.QtyIutPar).HasColumnName("QTY_IUT_PAR");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.QtyMaximum).HasColumnName("QTY_MAXIMUM");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.QtyOnhand).HasColumnName("QTY_ONHAND");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.QtyOwned).HasColumnName("QTY_OWNED");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.QtyReserved).HasColumnName("QTY_RESERVED");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.RefRoutingItem).HasColumnName("REF_ROUTING_ITEM");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.RelatedItemId).HasColumnName("RELATED_ITEM_ID");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ReorderPoint).HasColumnName("REORDER_POINT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ReorderQty).HasColumnName("REORDER_QTY");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ReplCalcPeriod).HasColumnName("REPL_CALC_PERIOD");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ReplenishClass).HasColumnName("REPLENISH_CLASS");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ReplenishLead).HasColumnName("REPLENISH_LEAD");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ReplenishPoint).HasColumnName("REPLENISH_POINT");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.RetestLeadTime).HasColumnName("RETEST_LEAD_TIME");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.RevisionControl).HasColumnName("REVISION_CONTROL");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.RopcInstance).HasColumnName("ROPC_INSTANCE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.RopcStatus).HasColumnName("ROPC_STATUS");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.RtgCode).HasColumnName("RTG_CODE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SafetyLeadTime).HasColumnName("SAFETY_LEAD_TIME");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SafetyStock).HasColumnName("SAFETY_STOCK");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfDispatchMode).HasColumnName("SF_DISPATCH_MODE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplMethod).HasColumnName("SF_RPL_METHOD");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplMode).HasColumnName("SF_RPL_MODE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplPrdnArea).HasColumnName("SF_RPL_PRDN_AREA");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplSource).HasColumnName("SF_RPL_SOURCE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplStorArea).HasColumnName("SF_RPL_STOR_AREA");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplStorLev1).HasColumnName("SF_RPL_STOR_LEV1");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplStorLev2).HasColumnName("SF_RPL_STOR_LEV2");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplStorLev3).HasColumnName("SF_RPL_STOR_LEV3");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplStorLev4).HasColumnName("SF_RPL_STOR_LEV4");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplType).HasColumnName("SF_RPL_TYPE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplVendorId).HasColumnName("SF_RPL_VENDOR_ID");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfRplVndrLoc).HasColumnName("SF_RPL_VNDR_LOC");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SfWipMaxQty).HasColumnName("SF_WIP_MAX_QTY");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ShelfLife).HasColumnName("SHELF_LIFE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.ShipTypeId).HasColumnName("SHIP_TYPE_ID");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SourceCode).HasColumnName("SOURCE_CODE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SstcInstance).HasColumnName("SSTC_INSTANCE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.SstcStatus).HasColumnName("SSTC_STATUS");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.StagedDateFlag).HasColumnName("STAGED_DATE_FLAG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.StdPackUom).HasColumnName("STD_PACK_UOM");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.StockoutRate).HasColumnName("STOCKOUT_RATE");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.TargetLevel).HasColumnName("TARGET_LEVEL");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.TransferMinOrder).HasColumnName("TRANSFER_MIN_ORDER");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.TransferYield).HasColumnName("TRANSFER_YIELD");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.TransitCostTyp).HasColumnName("TRANSIT_COST_TYP");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.UomConvFlag).HasColumnName("UOM_CONV_FLAG");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.UseUpQoh).HasColumnName("USE_UP_QOH");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.UsgTrckngMethod).HasColumnName("USG_TRCKNG_METHOD");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.VendorId).HasColumnName("VENDOR_ID");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.VndrLoc).HasColumnName("VNDR_LOC");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.WipMinQty).HasColumnName("WIP_MIN_QTY");
            modelBuilder.Entity<BuItemsInv>().Property(p => p.YieldCalcFlg).HasColumnName("YIELD_CALC_FLG");
        }

        /// <summary>
        ///             This method maps the BuItemUtilCd class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapBuItemUtilCd(DbModelBuilder modelBuilder)
        {
            // Map the BuItemUtilCd class to the PS_BU_ITEM_UTIL_CD table
            modelBuilder.Entity<BuItemUtilCd>()
                .HasKey(p => new
                {
                    p.BusinessUnit,
                    p.InvItemId,
                    p.UtilizGroup
                })
                .ToTable("PS_BU_ITEM_UTIL_CD");

            // Map each column
            modelBuilder.Entity<BuItemUtilCd>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<BuItemUtilCd>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<BuItemUtilCd>().Property(p => p.PlanningFlg).HasColumnName("PLANNING_FLG");
            modelBuilder.Entity<BuItemUtilCd>().Property(p => p.UtilizCd).HasColumnName("UTILIZ_CD");
            modelBuilder.Entity<BuItemUtilCd>().Property(p => p.UtilizGroup).HasColumnName("UTILIZ_GROUP");

        }

        /// <summary>
        ///             This method maps the CmGroupDefn class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapCmGroupDefn(DbModelBuilder modelBuilder)
        {
            // Map the CmGroupDefn class to the PS_CM_GROUP_DEFN table
            modelBuilder.Entity<CmGroupDefn>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.CmGroup
                })
                .ToTable("PS_CM_GROUP_DEFN");

            // Map each column
            modelBuilder.Entity<CmGroupDefn>().Property(p => p.CmGroup).HasColumnName("CM_GROUP");
            modelBuilder.Entity<CmGroupDefn>().Property(p => p.Comments).HasColumnName("COMMENTS");
            modelBuilder.Entity<CmGroupDefn>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<CmGroupDefn>().Property(p => p.Setid).HasColumnName("SETID");
        }

        /// <summary>
        ///             This method maps the CmItemMethod class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapCmItemMethod(DbModelBuilder modelBuilder)
        {
            // Map the CmItemMethod class to the PS_CM_ITEM_METHOD table
            modelBuilder.Entity<CmItemMethod>()
                .HasKey(p => new
                {
                    p.BusinessUnit,
                    p.InvItemId,
                    p.CmBook
                })
                .ToTable("PS_CM_ITEM_METHOD");

            // Map each column
            modelBuilder.Entity<CmItemMethod>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<CmItemMethod>().Property(p => p.CmBook).HasColumnName("CM_BOOK");
            modelBuilder.Entity<CmItemMethod>().Property(p => p.CmProfileId).HasColumnName("CM_PROFILE_ID");
            modelBuilder.Entity<CmItemMethod>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");

        }

        /// <summary>
        ///             This method maps the CountryTbl class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapCountryTbl(DbModelBuilder modelBuilder)
        {
            // Map the CountryTbl class to the PS_COUNTRY_TBL table
            modelBuilder.Entity<CountryTbl>()
                .HasKey(p => new
                {
                    p.Country
                })
                .ToTable("PS_COUNTRY_TBL");

            // Map each column
            modelBuilder.Entity<CountryTbl>().Property(p => p.AddrField1Avail).HasColumnName("ADDR_FIELD1_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.AddrField1Lbl).HasColumnName("ADDR_FIELD1_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.AddrField2Avail).HasColumnName("ADDR_FIELD2_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.AddrField2Lbl).HasColumnName("ADDR_FIELD2_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.AddrField3Avail).HasColumnName("ADDR_FIELD3_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.AddrField3Lbl).HasColumnName("ADDR_FIELD3_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Addr1Avail).HasColumnName("ADDR1_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Addr1Lbl).HasColumnName("ADDR1_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Addr2Avail).HasColumnName("ADDR2_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Addr2Lbl).HasColumnName("ADDR2_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Addr3Avail).HasColumnName("ADDR3_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Addr3Lbl).HasColumnName("ADDR3_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Addr4Avail).HasColumnName("ADDR4_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Addr4Lbl).HasColumnName("ADDR4_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.CityAvail).HasColumnName("CITY_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.CityLbl).HasColumnName("CITY_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Country).HasColumnName("COUNTRY");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Country2Char).HasColumnName("COUNTRY_2CHAR");
            modelBuilder.Entity<CountryTbl>().Property(p => p.CountyAvail).HasColumnName("COUNTY_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.CountyLbl).HasColumnName("COUNTY_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Descrshort).HasColumnName("DESCRSHORT");
            modelBuilder.Entity<CountryTbl>().Property(p => p.EuMemberState).HasColumnName("EU_MEMBER_STATE");
            modelBuilder.Entity<CountryTbl>().Property(p => p.GbsysCfgpathUk).HasColumnName("GBSYS_CFGPATH_UK");
            modelBuilder.Entity<CountryTbl>().Property(p => p.GbsysNrpathUk).HasColumnName("GBSYS_NRPATH_UK");
            modelBuilder.Entity<CountryTbl>().Property(p => p.GeoCodeAvail).HasColumnName("GEO_CODE_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.GeoCodeLbl).HasColumnName("GEO_CODE_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.HouseTypeAvail).HasColumnName("HOUSE_TYPE_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.HouseTypeLbl).HasColumnName("HOUSE_TYPE_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.InCityLimAvail).HasColumnName("IN_CITY_LIM_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.InCityLimLbl).HasColumnName("IN_CITY_LIM_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Num1Avail).HasColumnName("NUM1_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Num1Lbl).HasColumnName("NUM1_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Num2Avail).HasColumnName("NUM2_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Num2Lbl).HasColumnName("NUM2_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.PostSrchAvail).HasColumnName("POST_SRCH_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.PostalAvail).HasColumnName("POSTAL_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.PostalLbl).HasColumnName("POSTAL_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.StateAvail).HasColumnName("STATE_AVAIL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.StateLbl).HasColumnName("STATE_LBL");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Syncdttm).HasColumnName("SYNCDTTM");
            modelBuilder.Entity<CountryTbl>().Property(p => p.Syncid).HasColumnName("SYNCID");

        }

        /// <summary>
        ///             This method maps the CustomerProductAttributes class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapCustomerProductAttributes(DbModelBuilder modelBuilder)
        {
            // Map the CustomerProductAttributes class to the PS_CUSTOMER_PRODUCT_ATTRIBUTES table
            modelBuilder.Entity<CustomerProductAttributes>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.ProductId,
                    p.CustId
                })
                .ToTable("PS_CUSTOMER_PRODUCT_ATTRIBUTES");

            // Map each column
            modelBuilder.Entity<CustomerProductAttributes>().Property(p => p.CasepackQty).HasColumnName("CASEPACK_QTY");
            modelBuilder.Entity<CustomerProductAttributes>().Property(p => p.CustId).HasColumnName("CUST_ID");
            modelBuilder.Entity<CustomerProductAttributes>().Property(p => p.InnerpackQty).HasColumnName("INNERPACK_QTY");
            modelBuilder.Entity<CustomerProductAttributes>().Property(p => p.IsExclusive).HasColumnName("IS_EXCLUSIVE");
            modelBuilder.Entity<CustomerProductAttributes>().Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            modelBuilder.Entity<CustomerProductAttributes>().Property(p => p.SendInventory).HasColumnName("SEND_INVENTORY");
            modelBuilder.Entity<CustomerProductAttributes>().Property(p => p.Setid).HasColumnName("SETID");
        }

        /// <summary>
        ///             This method maps the DefaultLocInv class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapDefaultLocInv(DbModelBuilder modelBuilder)
        {
            // Map the DefaultLocInv class to the PS_DEFAULT_LOC_INV table
            modelBuilder.Entity<DefaultLocInv>()
                .HasKey(p => new
                {
                    p.BusinessUnit,
                    p.InvItemId,
                    p.DefLocType
                })
                .ToTable("PS_DEFAULT_LOC_INV");

            // Map each column
            modelBuilder.Entity<DefaultLocInv>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<DefaultLocInv>().Property(p => p.DefLocType).HasColumnName("DEF_LOC_TYPE");
            modelBuilder.Entity<DefaultLocInv>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<DefaultLocInv>().Property(p => p.StorLevel1).HasColumnName("STOR_LEVEL_1");
            modelBuilder.Entity<DefaultLocInv>().Property(p => p.StorLevel2).HasColumnName("STOR_LEVEL_2");
            modelBuilder.Entity<DefaultLocInv>().Property(p => p.StorLevel3).HasColumnName("STOR_LEVEL_3");
            modelBuilder.Entity<DefaultLocInv>().Property(p => p.StorLevel4).HasColumnName("STOR_LEVEL_4");
            modelBuilder.Entity<DefaultLocInv>().Property(p => p.StorageArea).HasColumnName("STORAGE_AREA");

        }

        /// <summary>
        ///             This method maps the EnBomComps class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapEnBomComps(DbModelBuilder modelBuilder)
        {
            // Map the EnBomComps class to the PS_EN_BOM_COMPS table
            modelBuilder.Entity<EnBomComps>()
                .HasKey(p => new
                {
                    p.BusinessUnit,
                    p.InvItemId,
                    p.BomState,
                    p.BomType,
                    p.BomCode,
                    p.ComponentId,
                    p.OpSequence,
                    p.DateInEffect
                })
                .ToTable("PS_EN_BOM_COMPS");
            // Map each column
            modelBuilder.Entity<EnBomComps>().Property(p => p.BomCode).HasColumnName("BOM_CODE");
            modelBuilder.Entity<EnBomComps>().Property(p => p.BomState).HasColumnName("BOM_STATE");
            modelBuilder.Entity<EnBomComps>().Property(p => p.BomType).HasColumnName("BOM_TYPE");
            modelBuilder.Entity<EnBomComps>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<EnBomComps>().Property(p => p.CompRev).HasColumnName("COMP_REV");
            modelBuilder.Entity<EnBomComps>().Property(p => p.ComponentId).HasColumnName("COMPONENT_ID");
            modelBuilder.Entity<EnBomComps>().Property(p => p.DateInEffect).HasColumnName("DATE_IN_EFFECT");
            modelBuilder.Entity<EnBomComps>().Property(p => p.DateObsolete).HasColumnName("DATE_OBSOLETE");
            modelBuilder.Entity<EnBomComps>().Property(p => p.EcoId).HasColumnName("ECO_ID");
            modelBuilder.Entity<EnBomComps>().Property(p => p.EnSubsExist).HasColumnName("EN_SUBS_EXIST");
            modelBuilder.Entity<EnBomComps>().Property(p => p.IncrConsOffset).HasColumnName("INCR_CONS_OFFSET");
            modelBuilder.Entity<EnBomComps>().Property(p => p.IncrConsType).HasColumnName("INCR_CONS_TYPE");
            modelBuilder.Entity<EnBomComps>().Property(p => p.InvItemHeight).HasColumnName("INV_ITEM_HEIGHT");
            modelBuilder.Entity<EnBomComps>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<EnBomComps>().Property(p => p.InvItemLength).HasColumnName("INV_ITEM_LENGTH");
            modelBuilder.Entity<EnBomComps>().Property(p => p.InvItemSize).HasColumnName("INV_ITEM_SIZE");
            modelBuilder.Entity<EnBomComps>().Property(p => p.InvItemVolume).HasColumnName("INV_ITEM_VOLUME");
            modelBuilder.Entity<EnBomComps>().Property(p => p.InvItemWeight).HasColumnName("INV_ITEM_WEIGHT");
            modelBuilder.Entity<EnBomComps>().Property(p => p.InvItemWidth).HasColumnName("INV_ITEM_WIDTH");
            modelBuilder.Entity<EnBomComps>().Property(p => p.NonOwnFlag).HasColumnName("NON_OWN_FLAG");
            modelBuilder.Entity<EnBomComps>().Property(p => p.OpSequence).HasColumnName("OP_SEQUENCE");
            modelBuilder.Entity<EnBomComps>().Property(p => p.PendingStatus).HasColumnName("PENDING_STATUS");
            modelBuilder.Entity<EnBomComps>().Property(p => p.PosNbr).HasColumnName("POS_NBR");
            modelBuilder.Entity<EnBomComps>().Property(p => p.QtyCode).HasColumnName("QTY_CODE");
            modelBuilder.Entity<EnBomComps>().Property(p => p.QtyPer).HasColumnName("QTY_PER");
            modelBuilder.Entity<EnBomComps>().Property(p => p.RollupFlg).HasColumnName("ROLLUP_FLG");
            modelBuilder.Entity<EnBomComps>().Property(p => p.SubSupplyFlg).HasColumnName("SUB_SUPPLY_FLG");
            modelBuilder.Entity<EnBomComps>().Property(p => p.TeardownFlag).HasColumnName("TEARDOWN_FLAG");
            modelBuilder.Entity<EnBomComps>().Property(p => p.Text254).HasColumnName("TEXT254");
            modelBuilder.Entity<EnBomComps>().Property(p => p.UnitMeasureDim).HasColumnName("UNIT_MEASURE_DIM");
            modelBuilder.Entity<EnBomComps>().Property(p => p.UnitMeasureVol).HasColumnName("UNIT_MEASURE_VOL");
            modelBuilder.Entity<EnBomComps>().Property(p => p.UnitMeasureWt).HasColumnName("UNIT_MEASURE_WT");
            modelBuilder.Entity<EnBomComps>().Property(p => p.Yield).HasColumnName("YIELD");

        }

        /// <summary>
        ///             This method maps the EnBomHeader class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapEnBomHeader(DbModelBuilder modelBuilder)
        {
            // Map the EnBomHeader class to the PS_EN_BOM_HEADER table
            modelBuilder.Entity<EnBomHeader>()
                .HasKey(p => new
                {
                    p.BusinessUnit,
                    p.InvItemId,
                    p.BomState,
                    p.BomType,
                    p.BomCode
                })
                .ToTable("PS_EN_BOM_HEADER");
            // Map each column
            modelBuilder.Entity<EnBomHeader>().Property(p => p.BomCode).HasColumnName("BOM_CODE");
            modelBuilder.Entity<EnBomHeader>().Property(p => p.BomQty).HasColumnName("BOM_QTY");
            modelBuilder.Entity<EnBomHeader>().Property(p => p.BomState).HasColumnName("BOM_STATE");
            modelBuilder.Entity<EnBomHeader>().Property(p => p.BomType).HasColumnName("BOM_TYPE");
            modelBuilder.Entity<EnBomHeader>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<EnBomHeader>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<EnBomHeader>().Property(p => p.Descrshort).HasColumnName("DESCRSHORT");
            modelBuilder.Entity<EnBomHeader>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<EnBomHeader>().Property(p => p.Text254).HasColumnName("TEXT254");

        }

        /// <summary>
        ///             This method maps the EnBomOutputs class to the database.
        /// </summary>
        /// 
        /// <param name="modelBuilder">
        ///             The DbModelBuilder to update with the mapping.
        /// </param>
        private void MapEnBomOutputs(DbModelBuilder modelBuilder)
        {
            // Map the EnBomHeader class to the PS_EN_BOM_OUTPUTS table
            modelBuilder.Entity<EnBomOutputs>()
                .HasKey(p => new
                {
                    p.BusinessUnit, 
                    p.InvItemId, 
                    p.BomState, 
                    p.BomType, 
                    p.BomCode, 
                    p.MgOutputType, 
                    p.MgOutputItem, 
                    p.OpSequence, 
                    p.DateInEffect
                })
                .ToTable("PS_EN_BOM_OUTPUTS");
            // Map each column
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.BomState).HasColumnName("BOM_STATE");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.BomType).HasColumnName("BOM_TYPE");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.BomCode).HasColumnName("BOM_CODE");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.MgOutputType).HasColumnName("MG_OUTPUT_TYPE");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.MgOutputItem).HasColumnName("MG_OUTPUT_ITEM");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.OpSequence).HasColumnName("OP_SEQUENCE");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.DateInEffect).HasColumnName("DATE_IN_EFFECT");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.DateObsolete).HasColumnName("DATE_OBSOLETE");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.MgOutputQty).HasColumnName("MG_OUTPUT_QTY");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.MgOutputQtyCode).HasColumnName("MG_OUTPUT_QTY_CODE");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.MgOutputResPct).HasColumnName("MG_OUTPUT_RES_PCT");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.MgOutputCostPct).HasColumnName("MG_OUTPUT_COST_PCT");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.IncrRelType).HasColumnName("INCR_REL_TYPE");
            modelBuilder.Entity<EnBomOutputs>().Property(p => p.IncrRelOffset).HasColumnName("INCR_REL_OFFSET");
        }

        /// <summary>
        ///             This method maps the FxdBinLocInv class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapFxdBinLocInv(DbModelBuilder modelBuilder)
        {
            // Map the FxdBinLocInv class to the PS_FXD_BIN_LOC_INV table
            modelBuilder.Entity<FxdBinLocInv>()
                .HasKey(p => new
                {
                    p.BusinessUnit,
                    p.InvItemId,
                    p.StorageArea,
                    p.StorLevel1,
                    p.StorLevel2,
                    p.StorLevel3,
                    p.StorLevel4
                })
                .ToTable("PS_FXD_BIN_LOC_INV");

            // Map each column
            modelBuilder.Entity<FxdBinLocInv>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<FxdBinLocInv>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<FxdBinLocInv>().Property(p => p.PickingOrder).HasColumnName("PICKING_ORDER");
            modelBuilder.Entity<FxdBinLocInv>().Property(p => p.QtyOptimal).HasColumnName("QTY_OPTIMAL");
            modelBuilder.Entity<FxdBinLocInv>().Property(p => p.StorLevel1).HasColumnName("STOR_LEVEL_1");
            modelBuilder.Entity<FxdBinLocInv>().Property(p => p.StorLevel2).HasColumnName("STOR_LEVEL_2");
            modelBuilder.Entity<FxdBinLocInv>().Property(p => p.StorLevel3).HasColumnName("STOR_LEVEL_3");
            modelBuilder.Entity<FxdBinLocInv>().Property(p => p.StorLevel4).HasColumnName("STOR_LEVEL_4");
            modelBuilder.Entity<FxdBinLocInv>().Property(p => p.StorageArea).HasColumnName("STORAGE_AREA");
            modelBuilder.Entity<FxdBinLocInv>().Property(p => p.UnitOfMeasure).HasColumnName("UNIT_OF_MEASURE");

        }

        /// <summary>
        ///             This method maps the HrmnTariffCd class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapHrmnTariffCd(DbModelBuilder modelBuilder)
        {
            // Map the HrmnTariffCd class to the PS_HRMN_TARIFF_CD table
            modelBuilder.Entity<HrmnTariffCd>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.HarmonizedCd,
                    p.Effdt
                })
                .ToTable("PS_HRMN_TARIFF_CD");

            // Map each column
            modelBuilder.Entity<HrmnTariffCd>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<HrmnTariffCd>().Property(p => p.Descrshort).HasColumnName("DESCRSHORT");
            modelBuilder.Entity<HrmnTariffCd>().Property(p => p.EffStatus).HasColumnName("EFF_STATUS");
            modelBuilder.Entity<HrmnTariffCd>().Property(p => p.Effdt).HasColumnName("EFFDT");
            modelBuilder.Entity<HrmnTariffCd>().Property(p => p.HarmonizedCd).HasColumnName("HARMONIZED_CD");
            modelBuilder.Entity<HrmnTariffCd>().Property(p => p.Setid).HasColumnName("SETID");

        }

        /// <summary>
        ///             This method maps the InvItemFam class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapInvItemFam(DbModelBuilder modelBuilder)
        {
            // Map the InvItemFam class to the PS_INV_ITEM_FAM table
            modelBuilder.Entity<InvItemFam>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvProdFamCd,
                    p.Effdt
                })
                .ToTable("PS_INV_ITEM_FAM");

            // Map each column
            modelBuilder.Entity<InvItemFam>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<InvItemFam>().Property(p => p.Descrshort).HasColumnName("DESCRSHORT");
            modelBuilder.Entity<InvItemFam>().Property(p => p.EffStatus).HasColumnName("EFF_STATUS");
            modelBuilder.Entity<InvItemFam>().Property(p => p.Effdt).HasColumnName("EFFDT");
            modelBuilder.Entity<InvItemFam>().Property(p => p.InvProdFamCd).HasColumnName("INV_PROD_FAM_CD");
            modelBuilder.Entity<InvItemFam>().Property(p => p.Setid).HasColumnName("SETID");
        }

        /// <summary>
        ///             This method maps the InvItemGroupTable class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapInvItemGroup(DbModelBuilder modelBuilder)
        {
            // Map the InvItemGroupTable class to the PS_INV_ITEM_GROUP table
            modelBuilder.Entity<InvItemGroupTable>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemGroup,
                    p.Effdt
                })
                .ToTable("PS_INV_ITEM_GROUP");

            // Map each column
            modelBuilder.Entity<InvItemGroupTable>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<InvItemGroupTable>().Property(p => p.Descrshort).HasColumnName("DESCRSHORT");
            modelBuilder.Entity<InvItemGroupTable>().Property(p => p.EffStatus).HasColumnName("EFF_STATUS");
            modelBuilder.Entity<InvItemGroupTable>().Property(p => p.Effdt).HasColumnName("EFFDT");
            modelBuilder.Entity<InvItemGroupTable>().Property(p => p.InvItemGroup).HasColumnName("INV_ITEM_GROUP");
            modelBuilder.Entity<InvItemGroupTable>().Property(p => p.Setid).HasColumnName("SETID");
        }

        /// <summary>
        ///             This method maps the InvItems class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapInvItems(DbModelBuilder modelBuilder)
        {
            // Map the InvItems class to the PS_INV_ITEMS table
            modelBuilder.Entity<InvItems>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId,
                    p.Effdt
                })
                .ToTable("PS_INV_ITEMS");

            // Map each column
            modelBuilder.Entity<InvItems>().Property(p => p.AvailLeadTime).HasColumnName("AVAIL_LEAD_TIME");
            modelBuilder.Entity<InvItems>().Property(p => p.AvailStatus).HasColumnName("AVAIL_STATUS");
            modelBuilder.Entity<InvItems>().Property(p => p.ChargeCode).HasColumnName("CHARGE_CODE");
            modelBuilder.Entity<InvItems>().Property(p => p.ChargeMarkupAmt).HasColumnName("CHARGE_MARKUP_AMT");
            modelBuilder.Entity<InvItems>().Property(p => p.ChargeMarkupPcnt).HasColumnName("CHARGE_MARKUP_PCNT");
            modelBuilder.Entity<InvItems>().Property(p => p.CommodityCd).HasColumnName("COMMODITY_CD");
            modelBuilder.Entity<InvItems>().Property(p => p.CommodityCdEu).HasColumnName("COMMODITY_CD_EU");
            modelBuilder.Entity<InvItems>().Property(p => p.ConsumableFlg).HasColumnName("CONSUMABLE_FLG");
            modelBuilder.Entity<InvItems>().Property(p => p.CurrencyCd).HasColumnName("CURRENCY_CD");
            modelBuilder.Entity<InvItems>().Property(p => p.Descr254).HasColumnName("DESCR254");
            modelBuilder.Entity<InvItems>().Property(p => p.DisposableFlag).HasColumnName("DISPOSABLE_FLAG");
            modelBuilder.Entity<InvItems>().Property(p => p.Effdt).HasColumnName("EFFDT");
            modelBuilder.Entity<InvItems>().Property(p => p.HarmonizedCd).HasColumnName("HARMONIZED_CD");
            modelBuilder.Entity<InvItems>().Property(p => p.HazClassCd).HasColumnName("HAZ_CLASS_CD");
            modelBuilder.Entity<InvItems>().Property(p => p.IntlHazardId).HasColumnName("INTL_HAZARD_ID");
            modelBuilder.Entity<InvItems>().Property(p => p.InvItemColor).HasColumnName("INV_ITEM_COLOR");
            modelBuilder.Entity<InvItems>().Property(p => p.InvItemHeight).HasColumnName("INV_ITEM_HEIGHT");
            modelBuilder.Entity<InvItems>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<InvItems>().Property(p => p.InvItemLength).HasColumnName("INV_ITEM_LENGTH");
            modelBuilder.Entity<InvItems>().Property(p => p.InvItemSize).HasColumnName("INV_ITEM_SIZE");
            modelBuilder.Entity<InvItems>().Property(p => p.InvItemTemplate).HasColumnName("INV_ITEM_TEMPLATE");
            modelBuilder.Entity<InvItems>().Property(p => p.InvItemType).HasColumnName("INV_ITEM_TYPE");
            modelBuilder.Entity<InvItems>().Property(p => p.InvItemVolume).HasColumnName("INV_ITEM_VOLUME");
            modelBuilder.Entity<InvItems>().Property(p => p.InvItemWeight).HasColumnName("INV_ITEM_WEIGHT");
            modelBuilder.Entity<InvItems>().Property(p => p.InvItemWidth).HasColumnName("INV_ITEM_WIDTH");
            modelBuilder.Entity<InvItems>().Property(p => p.InvProdGrade).HasColumnName("INV_PROD_GRADE");
            modelBuilder.Entity<InvItems>().Property(p => p.InvStockType).HasColumnName("INV_STOCK_TYPE");
            modelBuilder.Entity<InvItems>().Property(p => p.LastDttmUpdate).HasColumnName("LAST_DTTM_UPDATE");
            modelBuilder.Entity<InvItems>().Property(p => p.LastMaintOprid).HasColumnName("LAST_MAINT_OPRID");
            modelBuilder.Entity<InvItems>().Property(p => p.MaxCapacity).HasColumnName("MAX_CAPACITY");
            modelBuilder.Entity<InvItems>().Property(p => p.MsdsId).HasColumnName("MSDS_ID");
            modelBuilder.Entity<InvItems>().Property(p => p.PackingCd).HasColumnName("PACKING_CD");
            modelBuilder.Entity<InvItems>().Property(p => p.PotencyRating).HasColumnName("POTENCY_RATING");
            modelBuilder.Entity<InvItems>().Property(p => p.RecomHumidityPct).HasColumnName("RECOM_HUMIDITY_PCT");
            modelBuilder.Entity<InvItems>().Property(p => p.RecomStorTemp).HasColumnName("RECOM_STOR_TEMP");
            modelBuilder.Entity<InvItems>().Property(p => p.RecycleFlag).HasColumnName("RECYCLE_FLAG");
            modelBuilder.Entity<InvItems>().Property(p => p.RetestLeadTime).HasColumnName("RETEST_LEAD_TIME");
            modelBuilder.Entity<InvItems>().Property(p => p.ReturnableFlg).HasColumnName("RETURNABLE_FLG");
            modelBuilder.Entity<InvItems>().Property(p => p.ReusableFlag).HasColumnName("REUSABLE_FLAG");
            modelBuilder.Entity<InvItems>().Property(p => p.ServiceExchAmt).HasColumnName("SERVICE_EXCH_AMT");
            modelBuilder.Entity<InvItems>().Property(p => p.ServicePrice).HasColumnName("SERVICE_PRICE");
            modelBuilder.Entity<InvItems>().Property(p => p.ServiceableFlg).HasColumnName("SERVICEABLE_FLG");
            modelBuilder.Entity<InvItems>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<InvItems>().Property(p => p.ShelfLife).HasColumnName("SHELF_LIFE");
            modelBuilder.Entity<InvItems>().Property(p => p.ShipTypeId).HasColumnName("SHIP_TYPE_ID");
            modelBuilder.Entity<InvItems>().Property(p => p.StorRulesId).HasColumnName("STOR_RULES_ID");
            modelBuilder.Entity<InvItems>().Property(p => p.UnitMeasureDim).HasColumnName("UNIT_MEASURE_DIM");
            modelBuilder.Entity<InvItems>().Property(p => p.UnitMeasureTemp).HasColumnName("UNIT_MEASURE_TEMP");
            modelBuilder.Entity<InvItems>().Property(p => p.UnitMeasureVol).HasColumnName("UNIT_MEASURE_VOL");
            modelBuilder.Entity<InvItems>().Property(p => p.UnitMeasureWt).HasColumnName("UNIT_MEASURE_WT");
            modelBuilder.Entity<InvItems>().Property(p => p.UpcId).HasColumnName("UPC_ID");

        }

        /// <summary>
        ///             This method maps the InvItemUom class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapInvItemUom(DbModelBuilder modelBuilder)
        {
            // Map the InvItems class to the PS_INV_ITEM_UOM table
            modelBuilder.Entity<InvItemUom>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId,
                    p.UnitOfMeasure
                })
                .ToTable("PS_INV_ITEM_UOM");

            // Map each column
            modelBuilder.Entity<InvItemUom>().Property(p => p.ContainerType).HasColumnName("CONTAINER_TYPE");
            modelBuilder.Entity<InvItemUom>().Property(p => p.ConversionRate).HasColumnName("CONVERSION_RATE");
            modelBuilder.Entity<InvItemUom>().Property(p => p.DfltUomStock).HasColumnName("DFLT_UOM_STOCK");
            modelBuilder.Entity<InvItemUom>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<InvItemUom>().Property(p => p.LastDttmUpdate).HasColumnName("LAST_DTTM_UPDATE");
            modelBuilder.Entity<InvItemUom>().Property(p => p.LastMaintOprid).HasColumnName("LAST_MAINT_OPRID");
            modelBuilder.Entity<InvItemUom>().Property(p => p.PackagingCd).HasColumnName("PACKAGING_CD");
            modelBuilder.Entity<InvItemUom>().Property(p => p.PackingCd).HasColumnName("PACKING_CD");
            modelBuilder.Entity<InvItemUom>().Property(p => p.PackingVolume).HasColumnName("PACKING_VOLUME");
            modelBuilder.Entity<InvItemUom>().Property(p => p.PackingWeight).HasColumnName("PACKING_WEIGHT");
            modelBuilder.Entity<InvItemUom>().Property(p => p.QtyPrecision).HasColumnName("QTY_PRECISION");
            modelBuilder.Entity<InvItemUom>().Property(p => p.RoundRule).HasColumnName("ROUND_RULE");
            modelBuilder.Entity<InvItemUom>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<InvItemUom>().Property(p => p.ShippingVolume).HasColumnName("SHIPPING_VOLUME");
            modelBuilder.Entity<InvItemUom>().Property(p => p.ShippingWeight).HasColumnName("SHIPPING_WEIGHT");
            modelBuilder.Entity<InvItemUom>().Property(p => p.UnitMeasureVol).HasColumnName("UNIT_MEASURE_VOL");
            modelBuilder.Entity<InvItemUom>().Property(p => p.UnitMeasureWt).HasColumnName("UNIT_MEASURE_WT");
            modelBuilder.Entity<InvItemUom>().Property(p => p.UnitOfMeasure).HasColumnName("UNIT_OF_MEASURE");
        }

        /// <summary>
        ///             This method maps the ItemAttribEx class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapItemAttribEx(DbModelBuilder modelBuilder)
        {
            // Map the ItemAttribEx class to the PS_ITEM_ATTRIB_EX table
            modelBuilder.Entity<ItemAttribEx>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId
                })
                .ToTable("PS_ITEM_ATTRIB_EX");

            // Map each column
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.AltImageFile1).HasColumnName("ALT_IMAGE_FILE_1");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.AltImageFile2).HasColumnName("ALT_IMAGE_FILE_2");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.AltImageFile3).HasColumnName("ALT_IMAGE_FILE_3");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.AltImageFile4).HasColumnName("ALT_IMAGE_FILE_4");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.BoxItemGroup).HasColumnName("BOX_ITEM_GROUP");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.CasepackHeight).HasColumnName("CASEPACK_HEIGHT");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.CasepackLength).HasColumnName("CASEPACK_LENGTH");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.CasepackQty).HasColumnName("CASEPACK_QTY");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.CasepackUpc).HasColumnName("CASEPACK_UPC");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.CasepackWeight).HasColumnName("CASEPACK_WEIGHT");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.CasepackWidth).HasColumnName("CASEPACK_WIDTH");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.DirectImport).HasColumnName("DIRECT_IMPORT");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.DtcPrice).HasColumnName("DTC_PRICE");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.Duty).HasColumnName("DUTY");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.Genre1).HasColumnName("GENRE_1");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.Genre2).HasColumnName("GENRE_2");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.Genre3).HasColumnName("GENRE_3");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.Gtin).HasColumnName("GTIN");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.ImageFileName).HasColumnName("IMAGE_FILE_NAME");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.InnerpackHeight).HasColumnName("INNERPACK_HEIGHT");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.InnerpackLength).HasColumnName("INNERPACK_LENGTH");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.InnerpackQty).HasColumnName("INNERPACK_QTY");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.InnerpackUpc).HasColumnName("INNERPACK_UPC");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.InnerpackWeight).HasColumnName("INNERPACK_WEIGHT");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.InnerpackWidth).HasColumnName("INNERPACK_WIDTH");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.LicenseBeginDate).HasColumnName("LICENSE_BEGIN_DATE");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.PrintOnDemand).HasColumnName("PRINT_ON_DEMAND");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.ProdFormat).HasColumnName("PROD_FORMAT");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.ProdGroup).HasColumnName("PROD_GROUP");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.ProdLine).HasColumnName("PROD_LINE");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.SatCode).HasColumnName("SAT_CODE");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.SellOnEcommerce).HasColumnName("SELL_ON_ECOM");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.SellOnWeb).HasColumnName("SELL_ON_WEB");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.TranslateEdiProd).HasColumnName("TRANSLATE_EDI_PROD");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.WebsitePrice).HasColumnName("WEBSITE_PRICE");
            modelBuilder.Entity<ItemAttribEx>().Property(p => p.WebsiteUrl).HasColumnName("WEBSITE_URL");

        }
        
        /// <summary>
        ///             This method maps the ItemCompliance class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapItemCompliance(DbModelBuilder modelBuilder)
        {
            // Map the ItemCompliance class to the PS_ITEM_COMPLIANCE table
            modelBuilder.Entity<ItemCompliance>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId
                })
                .ToTable("PS_ITEM_COMPLIANCE");

            // Map each column
            modelBuilder.Entity<ItemCompliance>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<ItemCompliance>().Property(p => p.Prop65Compliant).HasColumnName("PROP_65_COMPLIANT");
            modelBuilder.Entity<ItemCompliance>().Property(p => p.Setid).HasColumnName("SETID");

        }

        /// <summary>
        ///             This method maps the ItemLanguage class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapItemLanguage(DbModelBuilder modelBuilder)
        {
            // Map the ItemLanguage class to the PS_ITEM_LANGUAGE table
            modelBuilder.Entity<ItemLanguage>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId,
                    p.LanguageCd
                })
                .ToTable("PS_ITEM_LANGUAGE");

            // Map each column
            modelBuilder.Entity<ItemLanguage>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<ItemLanguage>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<ItemLanguage>().Property(p => p.LanguageCd).HasColumnName("LANGUAGE_CD");

        }

        /// <summary>
        ///             This method maps the ItemTerritory class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapItemTerritory(DbModelBuilder modelBuilder)
        {
            // Map the ItemLanguage class to the PS_ITEM_TERRITORY table
            modelBuilder.Entity<ItemTerritory>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId,
                    p.Territory
                })
                .ToTable("PS_ITEM_TERRITORY");

            // Map each column
            modelBuilder.Entity<ItemTerritory>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<ItemTerritory>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<ItemTerritory>().Property(p => p.Territory).HasColumnName("TERRITORY");
        }

        /// <summary>
        ///             This method maps the ItemMfg class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapItemMfg(DbModelBuilder modelBuilder)
        {
            // Map the ItemMfg class to the PS_ITEM_MFG table
            modelBuilder.Entity<ItemMfg>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId,
                    p.MfgId,
                    p.MfgItmId
                })
                .ToTable("PS_ITEM_MFG");

            // Map each column
            modelBuilder.Entity<ItemMfg>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<ItemMfg>().Property(p => p.MfgId).HasColumnName("MFG_ID");
            modelBuilder.Entity<ItemMfg>().Property(p => p.MfgItmId).HasColumnName("MFG_ITM_ID");
            modelBuilder.Entity<ItemMfg>().Property(p => p.PreferredMfg).HasColumnName("PREFERRED_MFG");
            modelBuilder.Entity<ItemMfg>().Property(p => p.Setid).HasColumnName("SETID");

        }

        /// <summary>
        ///             This method maps the ItemStatusTbl class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapItemStatusTbl(DbModelBuilder modelBuilder)
        {
            // Map the ItemStatusTbl class to the PS_ITEM_STATUS_TBL table
            modelBuilder.Entity<ItemStatusTbl>()
                .HasKey(p => new
                {
                    p.StatusCd
                })
                .ToTable("PS_ITEM_STATUS_TBL");

            // Map each column
            modelBuilder.Entity<ItemStatusTbl>().Property(p => p.Descr60).HasColumnName("DESCR60");
            modelBuilder.Entity<ItemStatusTbl>().Property(p => p.IsItemActive).HasColumnName("IS_ITEM_ACTIVE");
            modelBuilder.Entity<ItemStatusTbl>().Property(p => p.StatusCd).HasColumnName("STATUS_CD");
        }

        /// <summary>
        ///             This method maps the ItemWebInfo class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapItemWebInfo(DbModelBuilder modelBuilder)
        {
            // Map the ItemWebInfo class to the PS_ITEM_WEB_INFO table
            modelBuilder.Entity<ItemWebInfo>()
                .HasKey(p => new
                {
                    p.InvItemId
                })
                .ToTable("PS_ITEM_WEB_INFO");

            // Map each column
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.Active).HasColumnName("ACTIVE");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.AttributeSet).HasColumnName("ATTRIBUTE_SET");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.Category).HasColumnName("CATEGORY");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.Copyright).HasColumnName("COPYRIGHT");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.ImagePath).HasColumnName("IMAGE_PATH");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.InStockDate).HasColumnName("IN_STOCK_DATE");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.ItemKeywords).HasColumnName("ITEM_KEYWORDS");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.Language).HasColumnName("LANGUAGE");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.License).HasColumnName("LICENSE");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.MetaDescription).HasColumnName("META_DESCRIPTION");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.Msrp).HasColumnName("MSRP");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.NewDate).HasColumnName("NEW_DATE");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.Newcategory).HasColumnName("NEWCATEGORY");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.OnSite).HasColumnName("ON_SITE");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.OnShopTrends).HasColumnName("ON_SHOPTRENDS");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.ProdQty).HasColumnName("PROD_QTY");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.Property).HasColumnName("PROPERTY");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.ShortDesc).HasColumnName("SHORT_DESC");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.Size).HasColumnName("SIZE");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.Territory).HasColumnName("TERRITORY");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.Title).HasColumnName("TITLE");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.Warranty).HasColumnName("WARRANTY");
            modelBuilder.Entity<ItemWebInfo>().Property(p => p.WarrantyCheck).HasColumnName("WARRANTY_CHECK");
        }

        /// <summary>
        ///             This method maps the ItmCatTbl class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapItmCatTbl(DbModelBuilder modelBuilder)
        {
            // Map the ItemWebInfo class to the PS_ITM_CAT_TBL table
            modelBuilder.Entity<ItmCatTbl>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.CategoryType,
                    p.CategoryCd,
                    p.CategoryId,
                    p.Effdt
                })
                .ToTable("PS_ITM_CAT_TBL");

            // Map each column
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.Account).HasColumnName("ACCOUNT");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.Altacct).HasColumnName("ALTACCT");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.CategoryCd).HasColumnName("CATEGORY_CD");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.CategoryId).HasColumnName("CATEGORY_ID");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.CategoryType).HasColumnName("CATEGORY_TYPE");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.CommentsLong).HasColumnName("COMMENTS_LONG");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.CumSrcRunLevel).HasColumnName("CUM_SRC_RUN_LEVEL");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.CurrencyCd).HasColumnName("CURRENCY_CD");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.Descrshort).HasColumnName("DESCRSHORT");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.EffStatus).HasColumnName("EFF_STATUS");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.Effdt).HasColumnName("EFFDT");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.ExtPrcTol).HasColumnName("EXT_PRC_TOL");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.ExtPrcTolL).HasColumnName("EXT_PRC_TOL_L");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.HistEndDt).HasColumnName("HIST_END_DT");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.HistNbrMths).HasColumnName("HIST_NBR_MTHS");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.HistStartDt).HasColumnName("HIST_START_DT");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.HistStartMth).HasColumnName("HIST_START_MTH");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.InspectCd).HasColumnName("INSPECT_CD");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.InspectUomType).HasColumnName("INSPECT_UOM_TYPE");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.LeadTime).HasColumnName("LEAD_TIME");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.LeadTimeImp).HasColumnName("LEAD_TIME_IMP");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.Marketcode).HasColumnName("MARKETCODE");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.MerchAmtCatTot).HasColumnName("MERCH_AMT_CAT_TOT");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.NbrOfItms).HasColumnName("NBR_OF_ITMS");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.PctExtPrcTol).HasColumnName("PCT_EXT_PRC_TOL");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.PctExtPrcTolL).HasColumnName("PCT_EXT_PRC_TOL_L");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.PctUnderQty).HasColumnName("PCT_UNDER_QTY");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.PctUnitPrcTol).HasColumnName("PCT_UNIT_PRC_TOL");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.PctUnitPrcTolL).HasColumnName("PCT_UNIT_PRC_TOL_L");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.PhysicalNature).HasColumnName("PHYSICAL_NATURE");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.PriceImp).HasColumnName("PRICE_IMP");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.PrimaryBuyer).HasColumnName("PRIMARY_BUYER");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.ProfileId).HasColumnName("PROFILE_ID");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.QtyRecvTolPct).HasColumnName("QTY_RECV_TOL_PCT");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.RecvPartialFlg).HasColumnName("RECV_PARTIAL_FLG");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.RecvReq).HasColumnName("RECV_REQ");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.RejectDays).HasColumnName("REJECT_DAYS");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.RfqReqFlag).HasColumnName("RFQ_REQ_FLAG");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.RjctOverTolFlag).HasColumnName("RJCT_OVER_TOL_FLAG");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.RoutingId).HasColumnName("ROUTING_ID");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.ShipLateDays).HasColumnName("SHIP_LATE_DAYS");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.ShiptoPrImp).HasColumnName("SHIPTO_PR_IMP");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.SrcMethod).HasColumnName("SRC_METHOD");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.UltimateUseCd).HasColumnName("ULTIMATE_USE_CD");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.UnitPrcTol).HasColumnName("UNIT_PRC_TOL");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.UnitPrcTolL).HasColumnName("UNIT_PRC_TOL_L");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.VatSvcPerfrmFlg).HasColumnName("VAT_SVC_PERFRM_FLG");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.VndrPrImp).HasColumnName("VNDR_PR_IMP");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.WfPctPrcTolOvr).HasColumnName("WF_PCT_PRC_TOL_OVR");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.WfPctPrcTolUnd).HasColumnName("WF_PCT_PRC_TOL_UND");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.WfPrcTolOvr).HasColumnName("WF_PRC_TOL_OVR");
            modelBuilder.Entity<ItmCatTbl>().Property(p => p.WfPrcTolUnd).HasColumnName("WF_PRC_TOL_UND");
        }

        /// <summary>
        ///             This method maps the LanguageTbl class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapLanguageTbl(DbModelBuilder modelBuilder)
        {
            // Map the LanguageTbl class to the PS_LANGUAGE_TBL table
            modelBuilder.Entity<LanguageTbl>()
                .HasKey(p => new
                {
                    p.LanguageCd
                })
                .ToTable("PS_LANGUAGE_TBL");

            // Map each column
            modelBuilder.Entity<LanguageTbl>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<LanguageTbl>().Property(p => p.LanguageCd).HasColumnName("LANGUAGE_CD");
        }

        /// <summary>
        ///             This method maps the MarketplaceCustomerProducts class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapMarketplaceCustomerProducts(DbModelBuilder modelBuilder)
        {
            // Map the MarketplaceCustomerProducts class to the PS_MARKETPLACE_CUSTOMER_PRODUCTS table
            modelBuilder.Entity<MarketplaceCustomerProducts>()
                .HasKey(p => new
                {
                    p.CustId,
                    p.InvItemId,
                    p.Setid
                })
                .ToTable("PS_MARKETPLACE_CUSTOMER_PRODUCTS");

            // Map each column
            modelBuilder.Entity<MarketplaceCustomerProducts>().Property(p => p.CustId).HasColumnName("CUST_ID");
            modelBuilder.Entity<MarketplaceCustomerProducts>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<MarketplaceCustomerProducts>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<MarketplaceCustomerProducts>().Property(p => p.Title).HasColumnName("TITLE");
        }

        /// <summary>
        ///             This method maps the MarketplaceProductTranslations class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapMarketplaceProductTranslations(DbModelBuilder modelBuilder)
        {
            // Map the MarketplaceProductTranslations class to the PS_MARKETPLACE_PRODUCT_TRANSLATIONS table
            modelBuilder.Entity<MarketplaceProductTranslations>()
                .HasKey(p => new
                {
                    p.FromProductId,
                    p.ToProductId
                })
                .ToTable("PS_MARKETPLACE_PRODUCT_TRANSLATIONS");

            // Map each column
            modelBuilder.Entity<MarketplaceProductTranslations>().Property(p => p.DttmAdded).HasColumnName("DTTM_ADDED");
            modelBuilder.Entity<MarketplaceProductTranslations>().Property(p => p.FromProductId).HasColumnName("FROM_PRODUCT_ID");
            modelBuilder.Entity<MarketplaceProductTranslations>().Property(p => p.Oprid).HasColumnName("OPRID");
            modelBuilder.Entity<MarketplaceProductTranslations>().Property(p => p.ToProductId).HasColumnName("TO_PRODUCT_ID");
            modelBuilder.Entity<MarketplaceProductTranslations>().Property(p => p.ToQty).HasColumnName("TO_QTY");
        }

        /// <summary>
        ///             This method maps the MasterItemTbl class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapMasterItemTbl(DbModelBuilder modelBuilder)
        {
            // Map the MasterItemTbl class to the PS_MASTER_ITEM_TBL table
            modelBuilder.Entity<MasterItemTbl>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId
                })
                .ToTable("PS_MASTER_ITEM_TBL");

            // Map each column
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ApprovRequired).HasColumnName("APPROV_REQUIRED");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ApprovSubmitted).HasColumnName("APPROV_SUBMITTED");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ApprovalDate).HasColumnName("APPROVAL_DATE");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ApprovalOprid).HasColumnName("APPROVAL_OPRID");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.CategoryId).HasColumnName("CATEGORY_ID");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.CfgCodeOpt).HasColumnName("CFG_CODE_OPT");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.CfgCostOpt).HasColumnName("CFG_COST_OPT");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.CfgLotOpt).HasColumnName("CFG_LOT_OPT");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ChangeField).HasColumnName("CHANGE_FIELD");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.CmGroup).HasColumnName("CM_GROUP");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ConsignedFlag).HasColumnName("CONSIGNED_FLAG");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.CpTemplateId).HasColumnName("CP_TEMPLATE_ID");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.CpTreeDist).HasColumnName("CP_TREE_DIST");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.CpTreePrdn).HasColumnName("CP_TREE_PRDN");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.DateAdded).HasColumnName("DATE_ADDED");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.DenialReason).HasColumnName("DENIAL_REASON");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.Descr60).HasColumnName("DESCR60");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.Descrshort).HasColumnName("DESCRSHORT");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.DeviceTracking).HasColumnName("DEVICE_TRACKING");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.DistCfgFlag).HasColumnName("DIST_CFG_FLAG");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.InvItemGroup).HasColumnName("INV_ITEM_GROUP");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.InvProdFamCd).HasColumnName("INV_PROD_FAM_CD");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.InventoryItem).HasColumnName("INVENTORY_ITEM");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC1A).HasColumnName("ITEM_FIELD_C1_A");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC1B).HasColumnName("ITEM_FIELD_C1_B");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC1C).HasColumnName("ITEM_FIELD_C1_C");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC1D).HasColumnName("ITEM_FIELD_C1_D");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC10A).HasColumnName("ITEM_FIELD_C10_A");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC10B).HasColumnName("ITEM_FIELD_C10_B");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC10C).HasColumnName("ITEM_FIELD_C10_C");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC10D).HasColumnName("ITEM_FIELD_C10_D");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC2).HasColumnName("ITEM_FIELD_C2");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC30A).HasColumnName("ITEM_FIELD_C30_A");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC30B).HasColumnName("ITEM_FIELD_C30_B");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC30C).HasColumnName("ITEM_FIELD_C30_C");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC30D).HasColumnName("ITEM_FIELD_C30_D");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC4).HasColumnName("ITEM_FIELD_C4");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC6).HasColumnName("ITEM_FIELD_C6");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldC8).HasColumnName("ITEM_FIELD_C8");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldN12A).HasColumnName("ITEM_FIELD_N12_A");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldN12B).HasColumnName("ITEM_FIELD_N12_B");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldN12C).HasColumnName("ITEM_FIELD_N12_C");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldN12D).HasColumnName("ITEM_FIELD_N12_D");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldN15A).HasColumnName("ITEM_FIELD_N15_A");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldN15B).HasColumnName("ITEM_FIELD_N15_B");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldN15C).HasColumnName("ITEM_FIELD_N15_C");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItemFieldN15D).HasColumnName("ITEM_FIELD_N15_D");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItmStatDtFuture).HasColumnName("ITM_STAT_DT_FUTURE");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItmStatusCurrent).HasColumnName("ITM_STATUS_CURRENT");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItmStatusEffdt).HasColumnName("ITM_STATUS_EFFDT");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ItmStatusFuture).HasColumnName("ITM_STATUS_FUTURE");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.LastDttmUpdate).HasColumnName("LAST_DTTM_UPDATE");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.LastMaintOprid).HasColumnName("LAST_MAINT_OPRID");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.LotControl).HasColumnName("LOT_CONTROL");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.MaterialReconFlg).HasColumnName("MATERIAL_RECON_FLG");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.NonOwnFlag).HasColumnName("NON_OWN_FLAG");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.OrigOprid).HasColumnName("ORIG_OPRID");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.PhysicalNature).HasColumnName("PHYSICAL_NATURE");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.PlPrioFamily).HasColumnName("PL_PRIO_FAMILY");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.PrdnCfgFlag).HasColumnName("PRDN_CFG_FLAG");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.PromiseOption).HasColumnName("PROMISE_OPTION");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.SerialControl).HasColumnName("SERIAL_CONTROL");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.SerialInPrdn).HasColumnName("SERIAL_IN_PRDN");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.ShipSerialCntrl).HasColumnName("SHIP_SERIAL_CNTRL");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.StagedDateFlag).HasColumnName("STAGED_DATE_FLAG");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.TraceChange).HasColumnName("TRACE_CHANGE");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.TraceUsage).HasColumnName("TRACE_USAGE");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.UnitMeasureStd).HasColumnName("UNIT_MEASURE_STD");
            modelBuilder.Entity<MasterItemTbl>().Property(p => p.UsgTrckngMethod).HasColumnName("USG_TRCKNG_METHOD");

        }

        /// <summary>
        ///             This method maps the OdinAutoNumberControlTable class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinAutoNumberControlTable(DbModelBuilder modelBuilder)
        {
            // Map the OdinAutoNumberControlTable class to the Odin_AutoNumberControlTable table
            modelBuilder.Entity<OdinAutoNumberControlTable>()
                .HasKey(p => new
                {
                    p.Identifier
                })
                .ToTable("Odin_AutoNumberControlTable");

            // Map each column
            modelBuilder.Entity<OdinAutoNumberControlTable>().Property(p => p.Identifier).HasColumnName("Identifier");
            modelBuilder.Entity<OdinAutoNumberControlTable>().Property(p => p.Nextautonumber).HasColumnName("NextAutoNumber");

        }

        /// <summary>
        ///             This method maps the OdinCustomerConversion class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinCustomerConversion(DbModelBuilder modelBuilder)
        {
            // Map the OdinCustomerConversion class to the ODIN_CUSTOMER_CONVERSION table
            modelBuilder.Entity<OdinCustomerConversion>()
                .HasKey(p => new
                {
                    p.CorporateCustId
                })
                .ToTable("ODIN_CUSTOMER_CONVERSION");

            // Map each column
            modelBuilder.Entity<OdinCustomerConversion>().Property(p => p.CorporateCustId).HasColumnName("CORPORATE_CUST_ID");
            modelBuilder.Entity<OdinCustomerConversion>().Property(p => p.CustName).HasColumnName("CUST_NAME");

        }

        /// <summary>
        ///     This method maps the OdinExcelLayoutData class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        /// The DbDbModelBuilder modelBuilder to update with the mapping
        /// </param>
        private void MapOdinExcelLayoutData(DbModelBuilder modelBuilder)
        {
            // Map the OdinExcelLayoutData class to the ODIN_EXCEL_LAYOUT_DATA table
            modelBuilder.Entity<OdinExcelLayoutData>()
                .HasKey(p => new
                {
                    p.ColumnNumber,
                    p.LayoutId
                })
                .ToTable("ODIN_EXCEL_LAYOUT_DATA");

            // Map each column
            modelBuilder.Entity<OdinExcelLayoutData>().Property(p => p.ColumnNumber).HasColumnName("COLUMN_NUMBER");
            modelBuilder.Entity<OdinExcelLayoutData>().Property(p => p.Customer).HasColumnName("CUSTOMER");
            modelBuilder.Entity<OdinExcelLayoutData>().Property(p => p.Field).HasColumnName("FIELD");
            modelBuilder.Entity<OdinExcelLayoutData>().Property(p => p.LayoutId).HasColumnName("LAYOUT_ID");
            modelBuilder.Entity<OdinExcelLayoutData>().Property(p => p.Option).HasColumnName("OPTION");

        }

        /// <summary>
        ///     This method maps the OdinExcelLayoutIds class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///     The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinExcelLayoutIds(DbModelBuilder modelBuilder)
        {
            // Map the OdinExcelLayoutIds class to the ODIN_EXCEL_LAYOUT_IDS table
            modelBuilder.Entity<OdinExcelLayoutIds>()
                .HasKey(p => new
                {
                    p.LayoutId
                })
                .ToTable("ODIN_EXCEL_LAYOUT_IDS");

            // Map each column
            modelBuilder.Entity<OdinExcelLayoutIds>().Property(p => p.Customer).HasColumnName("CUSTOMER");
            modelBuilder.Entity<OdinExcelLayoutIds>().Property(p => p.LayoutId).HasColumnName("LAYOUT_ID");
            modelBuilder.Entity<OdinExcelLayoutIds>().Property(p => p.LayoutName).HasColumnName("LAYOUT_NAME");
            modelBuilder.Entity<OdinExcelLayoutIds>().Property(p => p.ProductType).HasColumnName("PRODUCT_TYPE");
        }

        /// <summary>
        ///             This method maps the OdinFieldValues class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinFieldValues(DbModelBuilder modelBuilder)
        {
            // Map the OdinFieldValues class to the ODIN_FIELD_VALUES table
            modelBuilder.Entity<OdinFieldValues>()
                .HasKey(p => new
                {
                    p.FieldValue
                })
                .ToTable("ODIN_FIELD_VALUES");

            // Map each column
            modelBuilder.Entity<OdinFieldValues>().Property(p => p.FieldValue).HasColumnName("FIELD_VALUE");
        }

        /// <summary>
        ///             This method maps the OdinGenres class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinGenres(DbModelBuilder modelBuilder)
        {
            // Map the OdinGenres class to the ODIN_GENRES table
            modelBuilder.Entity<OdinGenres>()
                .HasKey(p => new
                {
                    p.Genre
                })
                .ToTable("ODIN_GENRES");

            // Map each column
            modelBuilder.Entity<OdinGenres>().Property(p => p.Genre).HasColumnName("GENRE");

        }

        /// <summary>
        ///             This method maps the OdinGlobalKeys class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinGlobalKeys(DbModelBuilder modelBuilder)
        {
            // Map the OdinGlobalKeys class to the Odin_GlobalKeys table
            modelBuilder.Entity<OdinGlobalKeys>()
                .HasKey(p => new
                {
                    p.Key
                })
                .ToTable("Odin_GlobalKeys");

            // Map each column
            modelBuilder.Entity<OdinGlobalKeys>().Property(p => p.Key).HasColumnName("KEY");
            modelBuilder.Entity<OdinGlobalKeys>().Property(p => p.Value).HasColumnName("VALUE");

        }

        /// <summary>
        ///             This method maps the OdinItem class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinItem(DbModelBuilder modelBuilder)
        {
            // Map the OdinItem class to the ODIN_ITEM_VW table
            modelBuilder.Entity<OdinItem>()
                .HasKey(p => new
                {
                    p.InvItemId
                })
                .ToTable("ODIN_ITEM_VW");

            // Map each column
            modelBuilder.Entity<OdinItem>().Property(p => p.AccountingGroup).HasColumnName("ACCOUNTING_GROUP");
            modelBuilder.Entity<OdinItem>().Property(p => p.AltImageFile1).HasColumnName("ALT_IMAGE_FILE_1");
            modelBuilder.Entity<OdinItem>().Property(p => p.AltImageFile2).HasColumnName("ALT_IMAGE_FILE_2");
            modelBuilder.Entity<OdinItem>().Property(p => p.AltImageFile3).HasColumnName("ALT_IMAGE_FILE_3");
            modelBuilder.Entity<OdinItem>().Property(p => p.AltImageFile4).HasColumnName("ALT_IMAGE_FILE_4");
            modelBuilder.Entity<OdinItem>().Property(p => p.AttributeSet).HasColumnName("ATTRIBUTE_SET");
            modelBuilder.Entity<OdinItem>().Property(p => p.BillOfMaterials).HasColumnName("BILL_OF_MATERIALS");
            modelBuilder.Entity<OdinItem>().Property(p => p.CasepackHeight).HasColumnName("CASEPACK_HEIGHT");
            modelBuilder.Entity<OdinItem>().Property(p => p.CasepackLength).HasColumnName("CASEPACK_LENGTH");
            modelBuilder.Entity<OdinItem>().Property(p => p.CasepackQty).HasColumnName("CASEPACK_QTY");
            modelBuilder.Entity<OdinItem>().Property(p => p.CasepackUpc).HasColumnName("CASEPACK_UPC");
            modelBuilder.Entity<OdinItem>().Property(p => p.CasepackWeight).HasColumnName("CASEPACK_WEIGHT");
            modelBuilder.Entity<OdinItem>().Property(p => p.CasepackWidth).HasColumnName("CASEPACK_WIDTH");
            modelBuilder.Entity<OdinItem>().Property(p => p.Category).HasColumnName("CATEGORY");
            modelBuilder.Entity<OdinItem>().Property(p => p.CmGroup).HasColumnName("CM_GROUP");
            modelBuilder.Entity<OdinItem>().Property(p => p.Copyright).HasColumnName("COPYRIGHT");
            modelBuilder.Entity<OdinItem>().Property(p => p.CountryIstOrigin).HasColumnName("COUNTRY_IST_ORIGIN");
            modelBuilder.Entity<OdinItem>().Property(p => p.DefaultActualCostCad).HasColumnName("DACCAD");
            modelBuilder.Entity<OdinItem>().Property(p => p.DefaultActualCostUsd).HasColumnName("DACUSD");
            modelBuilder.Entity<OdinItem>().Property(p => p.DateAdded).HasColumnName("DATE_ADDED");
            modelBuilder.Entity<OdinItem>().Property(p => p.Descr60).HasColumnName("DESCR60");
            modelBuilder.Entity<OdinItem>().Property(p => p.DirectImport).HasColumnName("DIRECT_IMPORT");
            modelBuilder.Entity<OdinItem>().Property(p => p.DtcPrice).HasColumnName("DTC_PRICE");
            modelBuilder.Entity<OdinItem>().Property(p => p.Duty).HasColumnName("DUTY");
            modelBuilder.Entity<OdinItem>().Property(p => p.Ean).HasColumnName("EAN");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceAsin).HasColumnName("ECOMMERCE_ASIN");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceBullet1).HasColumnName("ECOMMERCE_BULLET_1");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceBullet2).HasColumnName("ECOMMERCE_BULLET_2");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceBullet3).HasColumnName("ECOMMERCE_BULLET_3");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceBullet4).HasColumnName("ECOMMERCE_BULLET_4");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceBullet5).HasColumnName("ECOMMERCE_BULLET_5");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceComponents).HasColumnName("ECOMMERCE_COMPONENTS");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceCost).HasColumnName("ECOMMERCE_COST");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceCountryOfOrigin).HasColumnName("ECOMMERCE_COUNTRY_OF_ORIGIN");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceExternalId).HasColumnName("ECOMMERCE_EXTERNAL_ID");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceExternalIdType).HasColumnName("ECOMMERCE_EXTERNAL_ID_TYPE");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceFullDescription).HasColumnName("ECOMMERCE_FULL_DESCRIPTION");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceGenericKeywords).HasColumnName("ECOMMERCE_GENERIC_KEYWORDS");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceHeight).HasColumnName("ECOMMERCE_HEIGHT");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceImageUrl1).HasColumnName("ECOMMERCE_IMAGE_URL_1");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceImageUrl2).HasColumnName("ECOMMERCE_IMAGE_URL_2");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceImageUrl3).HasColumnName("ECOMMERCE_IMAGE_URL_3");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceImageUrl4).HasColumnName("ECOMMERCE_IMAGE_URL_4");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceImageUrl5).HasColumnName("ECOMMERCE_IMAGE_URL_5");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceItemName).HasColumnName("ECOMMERCE_ITEM_NAME");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceItemTypeKeywords).HasColumnName("ECOMMERCE_ITEM_TYPE_KEYWORDS");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceLength).HasColumnName("ECOMMERCE_LENGTH");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceManufacturerName).HasColumnName("ECOMMERCE_MANUFACTURER_NAME");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceModelName).HasColumnName("ECOMMERCE_MODEL_NAME");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceMsrp).HasColumnName("ECOMMERCE_MSRP");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommercePackageHeight).HasColumnName("ECOMMERCE_PACKAGE_HEIGHT");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommercePackageLength).HasColumnName("ECOMMERCE_PACKAGE_LENGTH");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommercePackageWeight).HasColumnName("ECOMMERCE_PACKAGE_WEIGHT");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommercePackageWidth).HasColumnName("ECOMMERCE_PACKAGE_WIDTH");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommercePageCount).HasColumnName("ECOMMERCE_PAGE_COUNT");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceParentAsin).HasColumnName("ECOMMERCE_PARENT_ASIN");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceProductCategory).HasColumnName("ECOMMERCE_PRODUCT_CATEGORY");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceProductSubcategory).HasColumnName("ECOMMERCE_PRODUCT_SUBCATEGORY");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceSize).HasColumnName("ECOMMERCE_SIZE");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceSubjectKeywords).HasColumnName("ECOMMERCE_SEARCH_TERMS");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceUpc).HasColumnName("ECOMMERCE_UPC");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceWeight).HasColumnName("ECOMMERCE_WEIGHT");
            modelBuilder.Entity<OdinItem>().Property(p => p.EcommerceWidth).HasColumnName("ECOMMERCE_WIDTH");
            modelBuilder.Entity<OdinItem>().Property(p => p.Gpc).HasColumnName("GPC");
            modelBuilder.Entity<OdinItem>().Property(p => p.Genre1).HasColumnName("GENRE_1");
            modelBuilder.Entity<OdinItem>().Property(p => p.Genre2).HasColumnName("GENRE_2");
            modelBuilder.Entity<OdinItem>().Property(p => p.Genre3).HasColumnName("GENRE_3");
            modelBuilder.Entity<OdinItem>().Property(p => p.HarmonizedCd).HasColumnName("HARMONIZED_CD");
            modelBuilder.Entity<OdinItem>().Property(p => p.ImageFileName).HasColumnName("IMAGE_FILE_NAME");
            modelBuilder.Entity<OdinItem>().Property(p => p.InnerpackHeight).HasColumnName("INNERPACK_HEIGHT");
            modelBuilder.Entity<OdinItem>().Property(p => p.InnerpackLength).HasColumnName("INNERPACK_LENGTH");
            modelBuilder.Entity<OdinItem>().Property(p => p.InnerpackQty).HasColumnName("INNERPACK_QTY");
            modelBuilder.Entity<OdinItem>().Property(p => p.InnerpackUpc).HasColumnName("INNERPACK_UPC");
            modelBuilder.Entity<OdinItem>().Property(p => p.InnerpackWeight).HasColumnName("INNERPACK_WEIGHT");
            modelBuilder.Entity<OdinItem>().Property(p => p.InnerpackWidth).HasColumnName("INNERPACK_WIDTH");
            modelBuilder.Entity<OdinItem>().Property(p => p.InStockDate).HasColumnName("IN_STOCK_DATE").IsOptional();
            modelBuilder.Entity<OdinItem>().Property(p => p.InvItemColor).HasColumnName("INV_ITEM_COLOR");
            modelBuilder.Entity<OdinItem>().Property(p => p.InvItemGroup).HasColumnName("INV_ITEM_GROUP");
            modelBuilder.Entity<OdinItem>().Property(p => p.InvItemHeight).HasColumnName("INV_ITEM_HEIGHT");
            modelBuilder.Entity<OdinItem>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<OdinItem>().Property(p => p.InvItemLength).HasColumnName("INV_ITEM_LENGTH");
            modelBuilder.Entity<OdinItem>().Property(p => p.InvItemWeight).HasColumnName("INV_ITEM_WEIGHT");
            modelBuilder.Entity<OdinItem>().Property(p => p.InvItemWidth).HasColumnName("INV_ITEM_WIDTH");
            modelBuilder.Entity<OdinItem>().Property(p => p.InvProdFamCd).HasColumnName("INV_PROD_FAM_CD");
            modelBuilder.Entity<OdinItem>().Property(p => p.Isbn).HasColumnName("ISBN");
            modelBuilder.Entity<OdinItem>().Property(p => p.ItemKeywords).HasColumnName("ITEM_KEYWORDS");
            modelBuilder.Entity<OdinItem>().Property(p => p.ItemKeywordsOverride).HasColumnName("ITEM_KEYWORDS_OVERRIDE");
            modelBuilder.Entity<OdinItem>().Property(p => p.Language).HasColumnName("LANGUAGE").IsOptional();
            modelBuilder.Entity<OdinItem>().Property(p => p.License).HasColumnName("LICENSE");
            modelBuilder.Entity<OdinItem>().Property(p => p.LicenseBeginDate).HasColumnName("LICENSE_BEGIN_DATE");
            modelBuilder.Entity<OdinItem>().Property(p => p.ListPriceCad).HasColumnName("LIST_PRICE_CAN");
            modelBuilder.Entity<OdinItem>().Property(p => p.ListPriceMxn).HasColumnName("LIST_PRICE_MXN");
            modelBuilder.Entity<OdinItem>().Property(p => p.ListPriceUsd).HasColumnName("LIST_PRICE_USD");
            modelBuilder.Entity<OdinItem>().Property(p => p.MetaDescription).HasColumnName("META_DESCRIPTION");
            modelBuilder.Entity<OdinItem>().Property(p => p.MfgSource).HasColumnName("MFG_SOURCE");
            modelBuilder.Entity<OdinItem>().Property(p => p.MsrpCad).HasColumnName("MSRP_CAN");
            modelBuilder.Entity<OdinItem>().Property(p => p.MsrpMxn).HasColumnName("MSRP_MXN");
            modelBuilder.Entity<OdinItem>().Property(p => p.MsrpUsd).HasColumnName("MSRP_USD");
            modelBuilder.Entity<OdinItem>().Property(p => p.NewDate).HasColumnName("NEW_DATE");
            modelBuilder.Entity<OdinItem>().Property(p => p.Newcategory).HasColumnName("NEWCATEGORY");
            modelBuilder.Entity<OdinItem>().Property(p => p.OnShopTrends).HasColumnName("ON_SHOPTRENDS");
            modelBuilder.Entity<OdinItem>().Property(p => p.OnSite).HasColumnName("ON_SITE");
            modelBuilder.Entity<OdinItem>().Property(p => p.Orientation).HasColumnName("ORIENTATION");
            modelBuilder.Entity<OdinItem>().Property(p => p.PricingGroup).HasColumnName("PRICING_GROUP");
            modelBuilder.Entity<OdinItem>().Property(p => p.PrintOnDemand).HasColumnName("PRINT_ON_DEMAND");
            modelBuilder.Entity<OdinItem>().Property(p => p.ProdCategory).HasColumnName("PROD_CATEGORY");
            modelBuilder.Entity<OdinItem>().Property(p => p.ProdFormat).HasColumnName("PROD_FORMAT");
            modelBuilder.Entity<OdinItem>().Property(p => p.ProdGroup).HasColumnName("PROD_GROUP");
            modelBuilder.Entity<OdinItem>().Property(p => p.ProdLine).HasColumnName("PROD_LINE");
            modelBuilder.Entity<OdinItem>().Property(p => p.ProdQty).HasColumnName("PROD_QTY");
            modelBuilder.Entity<OdinItem>().Property(p => p.ProductExclusive).HasColumnName("PRODUCT_EXCLUSIVE");
            modelBuilder.Entity<OdinItem>().Property(p => p.ProductIdTranslation).HasColumnName("PRODUCT_ID_TRANSLATION");
            modelBuilder.Entity<OdinItem>().Property(p => p.Property).HasColumnName("PROPERTY");
            modelBuilder.Entity<OdinItem>().Property(p => p.Psstatus).HasColumnName("PSSTATUS");
            modelBuilder.Entity<OdinItem>().Property(p => p.SatCode).HasColumnName("SAT_CODE");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnAllPosters).HasColumnName("SELL_ON_ALL_POSTERS");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnAmazon).HasColumnName("SELL_ON_AMAZON");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnAmazonSellerCentral).HasColumnName("SELL_ON_AMAZON_SELLER_CENTRAL");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnEcommerce).HasColumnName("SELL_ON_ECOMMERCE");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnFanatics).HasColumnName("SELL_ON_FANATICS");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnGuitarCenter).HasColumnName("SELL_ON_GUITAR_CENTER");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnHayneedle).HasColumnName("SELL_ON_HAYNEEDLE");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnHouzz).HasColumnName("SELL_ON_HOUZZ");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnTarget).HasColumnName("SELL_ON_TARGET");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnTrs).HasColumnName("SELL_ON_TRS");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnWalmart).HasColumnName("SELL_ON_WALMART");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnWayfair).HasColumnName("SELL_ON_WAYFAIR");
            modelBuilder.Entity<OdinItem>().Property(p => p.SellOnWeb).HasColumnName("SELL_ON_WEB");
            modelBuilder.Entity<OdinItem>().Property(p => p.ShortDesc).HasColumnName("SHORT_DESC");
            modelBuilder.Entity<OdinItem>().Property(p => p.Size).HasColumnName("SIZE");
            modelBuilder.Entity<OdinItem>().Property(p => p.StandardCost).HasColumnName("STANDARD_COST");
            modelBuilder.Entity<OdinItem>().Property(p => p.StatsCode).HasColumnName("STATS_CODE");
            modelBuilder.Entity<OdinItem>().Property(p => p.Territory).HasColumnName("TERRITORY");
            modelBuilder.Entity<OdinItem>().Property(p => p.Title).HasColumnName("TITLE");
            modelBuilder.Entity<OdinItem>().Property(p => p.TitleOverride).HasColumnName("TITLE_OVERRIDE");
            modelBuilder.Entity<OdinItem>().Property(p => p.Udex).HasColumnName("UDEX");
            modelBuilder.Entity<OdinItem>().Property(p => p.UpcId).HasColumnName("UPC_ID");
            modelBuilder.Entity<OdinItem>().Property(p => p.Warranty).HasColumnName("WARRANTY");
            modelBuilder.Entity<OdinItem>().Property(p => p.WarrantyCheck).HasColumnName("WARRANTY_CHECK");
            modelBuilder.Entity<OdinItem>().Property(p => p.WebsitePriceOverride).HasColumnName("WEBSITE_PRICE_OVERRIDE");
            modelBuilder.Entity<OdinItem>().Property(p => p.WebsitePrice).HasColumnName("WEBSITE_PRICE");
            modelBuilder.Entity<OdinItem>().Property(p => p.WebsiteUrl).HasColumnName("WEBSITE_URL");
        }

        /// <summary>
        ///             This method maps the OdinItemExceptions class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinItemExceptions(DbModelBuilder modelBuilder)
        {
            // Map the OdinItemExceptions class to the Odin_Item_Exceptions table
            modelBuilder.Entity<OdinItemExceptions>()
                .HasKey(p => new
                {
                    p.Field,
                    p.ExceptionResult,
                    p.ExceptionTrigger,
                    p.ExceptionValue
                })
                .ToTable("Odin_Item_Exceptions");

            // Map each column
            modelBuilder.Entity<OdinItemExceptions>().Property(p => p.ExceptionResult).HasColumnName("EXCEPTION_RESULT");
            modelBuilder.Entity<OdinItemExceptions>().Property(p => p.ExceptionTrigger).HasColumnName("EXCEPTION_TRIGGER");
            modelBuilder.Entity<OdinItemExceptions>().Property(p => p.ExceptionValue).HasColumnName("EXCEPTION_VALUE");
            modelBuilder.Entity<OdinItemExceptions>().Property(p => p.Field).HasColumnName("FIELD");

        }


        /// <summary>
        ///             This method maps the OdinItem class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinItemIdSuffixes(DbModelBuilder modelBuilder)
        {
            // Map the OdinItem class to the ODIN_ITEM_VW table
            modelBuilder.Entity<OdinItemIdSuffixes>()
                .HasKey(p => new
                {
                    p.FieldValue
                })
                .ToTable("ODIN_ITEMID_SUFFIXES");

            // Map each column
            modelBuilder.Entity<OdinItemIdSuffixes>().Property(p => p.Desc).HasColumnName("DESC");
            modelBuilder.Entity<OdinItemIdSuffixes>().Property(p => p.FieldValue).HasColumnName("FIELD_VALUE");
        }

        /// <summary>
        ///             This method maps the OdinItemOverrideInfo class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinItemOverrideInfo(DbModelBuilder modelBuilder)
        {
            // Map the OdinItemExceptions class to the ODIN_ITEM_OVERRIDE_INFO table
            modelBuilder.Entity<OdinItemOverrideInfo>()
                .HasKey(p => new
                {
                    p.ItemId
                })
                .ToTable("ODIN_ITEM_OVERRIDE_INFO");

            // Map each column
            modelBuilder.Entity<OdinItemOverrideInfo>().Property(p => p.ItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<OdinItemOverrideInfo>().Property(p => p.ItemKeywords).HasColumnName("ITEM_KEYWORDS");
            modelBuilder.Entity<OdinItemOverrideInfo>().Property(p => p.Title).HasColumnName("TITLE");
            modelBuilder.Entity<OdinItemOverrideInfo>().Property(p => p.WebsitePrice).HasColumnName("WEBSITE_PRICE");

        }
        
        /// <summary>
        ///             This method maps the OdinItemTemplates class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinItemTemplates(DbModelBuilder modelBuilder)
        {
            // Map the OdinItemTemplates class to the ODIN_ITEM_TEMPLATES table
            modelBuilder.Entity<OdinItemTemplates>()
                .HasKey(p => new
                {
                    p.TemplateId
                })
                .ToTable("ODIN_ITEM_TEMPLATES");

            // Map each column
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.AccountingGroup).HasColumnName("ACCOUNTING_GROUP");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.CasepackHeight).HasColumnName("CASEPACK_HEIGHT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.CasepackLength).HasColumnName("CASEPACK_LENGTH");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.CasepackQty).HasColumnName("CASEPACK_QTY");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.CasepackUpc).HasColumnName("CASEPACK_UPC");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.CasepackWeight).HasColumnName("CASEPACK_WEIGHT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.CasepackWidth).HasColumnName("CASEPACK_WIDTH");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Category).HasColumnName("CATEGORY");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Category2).HasColumnName("CATEGORY2");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Category3).HasColumnName("CATEGORY3");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Copyright).HasColumnName("COPYRIGHT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.CostProfileGroup).HasColumnName("COST_PROFILE_GROUP");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.DefaultActualCostCad).HasColumnName("DEFAULT_ACTUAL_COST_CAD");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.DefaultActualCostUsd).HasColumnName("DEFAULT_ACTUAL_COST_USD");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.DtcPrice).HasColumnName("DTC_PRICE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Duty).HasColumnName("DUTY");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceBullet1).HasColumnName("ECOMMERCE_BULLET_1");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceBullet2).HasColumnName("ECOMMERCE_BULLET_2");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceBullet3).HasColumnName("ECOMMERCE_BULLET_3");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceBullet4).HasColumnName("ECOMMERCE_BULLET_4");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceBullet5).HasColumnName("ECOMMERCE_BULLET_5");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceComponents).HasColumnName("ECOMMERCE_COMPONENTS");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceCost).HasColumnName("ECOMMERCE_COST");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceExternalIdType).HasColumnName("ECOMMERCE_EXTERNAL_ID_TYPE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceItemHeight).HasColumnName("ECOMMERCE_ITEM_HEIGHT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceItemLength).HasColumnName("ECOMMERCE_ITEM_LENGTH");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceItemTypeKeywords).HasColumnName("ECOMMERCE_ITEM_TYPE_KEYWORDS");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceItemWeight).HasColumnName("ECOMMERCE_ITEM_WEIGHT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceItemWidth).HasColumnName("ECOMMERCE_ITEM_WIDTH");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceManufacturerName).HasColumnName("ECOMMERCE_MANUFACTURER_NAME");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceModelName).HasColumnName("ECOMMERCE_MODEL_NAME");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceMsrp).HasColumnName("ECOMMERCE_MSRP");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommercePackageHeight).HasColumnName("ECOMMERCE_PACKAGE_HEIGHT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommercePackageLength).HasColumnName("ECOMMERCE_PACKAGE_LENGTH");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommercePackageWeight).HasColumnName("ECOMMERCE_PACKAGE_WEIGHT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommercePackageWidth).HasColumnName("ECOMMERCE_PACKAGE_WIDTH");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommercePageCount).HasColumnName("ECOMMERCE_PAGE_COUNT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceProductCategory).HasColumnName("ECOMMERCE_PRODUCT_CATEGORY");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceProductDescription).HasColumnName("ECOMMERCE_PRODUCT_DESCRIPTION");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceProductSubcategory).HasColumnName("ECOMMERCE_PRODUCT_SUBCATEGORY");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.EcommerceSize).HasColumnName("ECOMMERCE_SIZE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Gpc).HasColumnName("GPC");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Height).HasColumnName("HEIGHT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.InStockDate).HasColumnName("IN_STOCK_DATE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.InnerpackHeight).HasColumnName("INNERPACK_HEIGHT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.InnerpackLength).HasColumnName("INNERPACK_LENGTH");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.InnerpackQty).HasColumnName("INNERPACK_QTY");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.InnerpackUpc).HasColumnName("INNERPACK_UPC");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.InnerpackWeight).HasColumnName("INNERPACK_WEIGHT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.InnerpackWidth).HasColumnName("INNERPACK_WIDTH");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.InputDate).HasColumnName("INPUT_DATE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.ItemCategory).HasColumnName("ITEM_CATEGORY");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.ItemFamily).HasColumnName("ITEM_FAMILY");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.ItemGroup).HasColumnName("ITEM_GROUP");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.ItemKeywords).HasColumnName("ITEM_KEYWORDS");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Length).HasColumnName("LENGTH");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.License).HasColumnName("LICENSE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.ListPriceCad).HasColumnName("LIST_PRICE_CAD");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.ListPriceMxn).HasColumnName("LIST_PRICE_MXN");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.ListPriceUsd).HasColumnName("LIST_PRICE_USD");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.MetaDescription).HasColumnName("META_DESCRIPTION");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.MfgSource).HasColumnName("MFG_SOURCE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Msrp).HasColumnName("MSRP");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.MsrpCad).HasColumnName("MSRP_CAD");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.MsrpMxn).HasColumnName("MSRP_MXN");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.PricingGroup).HasColumnName("PRICING_GROUP");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.PrintOnDemand).HasColumnName("PRINT_ON_DEMAND");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.ProdQty).HasColumnName("PROD_QTY");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.ProductFormat).HasColumnName("PRODUCT_FORMAT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.ProductGroup).HasColumnName("PRODUCT_GROUP");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.ProductLine).HasColumnName("PRODUCT_LINE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.PsStatus).HasColumnName("PS_STATUS");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.SatCode).HasColumnName("SAT_CODE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Size).HasColumnName("SIZE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.StandardCost).HasColumnName("STANDARD_COST");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.StatsCode).HasColumnName("STATS_CODE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.TariffCode).HasColumnName("TARIFF_CODE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.TemplateId).HasColumnName("TEMPLATE_ID");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Udex).HasColumnName("UDEX");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Username).HasColumnName("USERNAME");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Warranty).HasColumnName("WARRANTY");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.WebsitePrice).HasColumnName("WEBSITE_PRICE");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Weight).HasColumnName("WEIGHT");
            modelBuilder.Entity<OdinItemTemplates>().Property(p => p.Width).HasColumnName("WIDTH");

        }

        /// <summary>
        ///             This method maps the OdinItemTypeExtensions class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinItemTypeExtensions(DbModelBuilder modelBuilder)
        {
            // Map the OdinItemTypeExtensions class to the ODIN_ITEM_TYPE_EXTENSIONS table
            modelBuilder.Entity<OdinItemTypeExtensions>()
                .HasKey(p => new
                {
                    p.Prefix,
                    p.Suffix
                })
                .ToTable("ODIN_ITEM_TYPE_EXTENSIONS");

            // Map each column
            modelBuilder.Entity<OdinItemTypeExtensions>().Property(p => p.Prefix).HasColumnName("PREFIX");
            modelBuilder.Entity<OdinItemTypeExtensions>().Property(p => p.Suffix).HasColumnName("SUFFIX");

        }

        /// <summary>
        ///             This method maps the OdinItemUpdateRecords class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinItemUpdateRecords(DbModelBuilder modelBuilder)
        {
            // Map the OdinItemUpdateRecords class to the ODIN_ITEM_UPDATE_RECORDS table
            modelBuilder.Entity<OdinItemUpdateRecords>()
                .HasKey(p => new
                {
                    p.InputDate
                })
                .ToTable("ODIN_ITEM_UPDATE_RECORDS");

            // Map each column
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AAmazonActive).HasColumnName("A_AMAZON_ACTIVE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AAsin).HasColumnName("A_ASIN");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ABullet1).HasColumnName("A_BULLET_1");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ABullet2).HasColumnName("A_BULLET_2");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ABullet3).HasColumnName("A_BULLET_3");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ABullet4).HasColumnName("A_BULLET_4");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ABullet5).HasColumnName("A_BULLET_5");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AComponents).HasColumnName("A_COMPONENTS");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ACost).HasColumnName("A_COST");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AExternalId).HasColumnName("A_EXTERNAL_ID");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AExternalIdType).HasColumnName("A_EXTERNAL_ID_TYPE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AGenericKeywords).HasColumnName("A_GENERIC_KEYWORDS");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AImageUrl1).HasColumnName("A_IMAGE_URL_1");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AImageUrl2).HasColumnName("A_IMAGE_URL_2");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AImageUrl3).HasColumnName("A_IMAGE_URL_3");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AImageUrl4).HasColumnName("A_IMAGE_URL_4");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AImageUrl5).HasColumnName("A_IMAGE_URL_5");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AItemHeight).HasColumnName("A_ITEM_HEIGHT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AItemLength).HasColumnName("A_ITEM_LENGTH");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AItemName).HasColumnName("A_ITEM_NAME");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AItemTypeKeywords).HasColumnName("A_ITEM_TYPE_KEYWORDS");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AItemWeight).HasColumnName("A_ITEM_WEIGHT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AItemWidth).HasColumnName("A_ITEM_WIDTH");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AManufacturerName).HasColumnName("A_MANUFACTURER_NAME");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AModelName).HasColumnName("A_MODEL_NAME");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AMsrp).HasColumnName("A_MSRP");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.APackageHeight).HasColumnName("A_PACKAGE_HEIGHT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.APackageLength).HasColumnName("A_PACKAGE_LENGTH");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.APackageWeight).HasColumnName("A_PACKAGE_WEIGHT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.APackageWidth).HasColumnName("A_PACKAGE_WIDTH");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.APageQty).HasColumnName("A_PAGE_QTY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AParentAsin).HasColumnName("A_PARENT_ASIN");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AProductCategory).HasColumnName("A_PRODUCT_CATEGORY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AProductDescription).HasColumnName("A_PRODUCT_DESCRIPTION");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AProductSubcategory).HasColumnName("A_PRODUCT_SUBCATEGORY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ASubjectKeywords).HasColumnName("A_SEARCH_TERMS");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ASize).HasColumnName("A_SIZE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AUpc).HasColumnName("A_UPC");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AccountingGroup).HasColumnName("ACCOUNTING_GROUP");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AltImageFile1).HasColumnName("ALT_IMAGE_FILE_1");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AltImageFile2).HasColumnName("ALT_IMAGE_FILE_2");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AltImageFile3).HasColumnName("ALT_IMAGE_FILE_3");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.AltImageFile4).HasColumnName("ALT_IMAGE_FILE_4");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.BillOfMaterials).HasColumnName("BILL_OF_MATERIALS");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.CasepackHeight).HasColumnName("CASEPACK_HEIGHT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.CasepackLength).HasColumnName("CASEPACK_LENGTH");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.CasepackQty).HasColumnName("CASEPACK_QTY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.CasepackUpc).HasColumnName("CASEPACK_UPC");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.CasepackWeight).HasColumnName("CASEPACK_WEIGHT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.CasepackWidth).HasColumnName("CASEPACK_WIDTH");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Category).HasColumnName("CATEGORY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Category2).HasColumnName("CATEGORY2");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Category3).HasColumnName("CATEGORY3");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Color).HasColumnName("COLOR");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Copyright).HasColumnName("COPYRIGHT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.CostProfileGroup).HasColumnName("COST_PROFILE_GROUP");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.CountryOfOrigin).HasColumnName("COUNTRY_OF_ORIGIN");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.DefaultActualCostCad).HasColumnName("DEFAULT_ACTUAL_COST_CAD");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.DefaultActualCostUsd).HasColumnName("DEFAULT_ACTUAL_COST_USD");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Description).HasColumnName("DESCRIPTION");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.DirectImport).HasColumnName("DIRECT_IMPORT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.DtcPrice).HasColumnName("DTC_PRICE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Duty).HasColumnName("DUTY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Ean).HasColumnName("EAN");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Exclusive).HasColumnName("EXCLUSIVE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Fplcanl1).HasColumnName("FPLCANL1");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Fplusl1).HasColumnName("FPLUSL1");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Genre1).HasColumnName("GENRE_1");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Genre2).HasColumnName("GENRE_2");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Genre3).HasColumnName("GENRE_3");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Gpc).HasColumnName("GPC");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Height).HasColumnName("HEIGHT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ImageFileName).HasColumnName("IMAGE_FILE_NAME");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ImagePath).HasColumnName("IMAGE_PATH");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.InStockDate).HasColumnName("IN_STOCK_DATE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.InnerpackHeight).HasColumnName("INNERPACK_HEIGHT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.InnerpackLength).HasColumnName("INNERPACK_LENGTH");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.InnerpackQty).HasColumnName("INNERPACK_QTY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.InnerpackUpc).HasColumnName("INNERPACK_UPC");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.InnerpackWeight).HasColumnName("INNERPACK_WEIGHT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.InnerpackWidth).HasColumnName("INNERPACK_WIDTH");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.InputDate).HasColumnName("INPUT_DATE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Isbn).HasColumnName("ISBN");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ItemCategory).HasColumnName("ITEM_CATEGORY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ItemFamily).HasColumnName("ITEM_FAMILY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ItemGroup).HasColumnName("ITEM_GROUP");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ItemInputStatus).HasColumnName("ITEM_INPUT_STATUS");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ItemKeywords).HasColumnName("ITEM_KEYWORDS");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Language).HasColumnName("LANGUAGE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Length).HasColumnName("LENGTH");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.License).HasColumnName("LICENSE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.LicenseBeginDate).HasColumnName("LICENSE_BEGIN_DATE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ListPriceCad).HasColumnName("LIST_PRICE_CAD");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ListPriceMxn).HasColumnName("LIST_PRICE_MXN");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ListPriceUsd).HasColumnName("LIST_PRICE_USD");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.MetaDescription).HasColumnName("META_DESCRIPTION");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.MfgSource).HasColumnName("MFG_SOURCE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Msrp).HasColumnName("MSRP");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.MsrpCad).HasColumnName("MSRP_CAD");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.MsrpMxn).HasColumnName("MSRP_MXN");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Orientation).HasColumnName("ORIENTATION");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.PricingGroup).HasColumnName("PRICING_GROUP");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.PrintOnDemand).HasColumnName("PRINT_ON_DEMAND");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ProdQty).HasColumnName("PROD_QTY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ProductFormat).HasColumnName("PRODUCT_FORMAT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ProductGroup).HasColumnName("PRODUCT_GROUP");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ProductIdTranslation).HasColumnName("PRODUCT_ID_TRANSLATION");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ProductLine).HasColumnName("PRODUCT_LINE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Property).HasColumnName("PROPERTY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.PsStatus).HasColumnName("PS_STATUS");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SatCode).HasColumnName("SAT_CODE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnAllposters).HasColumnName("SELL_ON_ALLPOSTERS");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnAmazon).HasColumnName("SELL_ON_AMAZON");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnAmazonSellerCentral).HasColumnName("SELL_ON_AMAZON_SELLER_CENTRAL");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnEcommerce).HasColumnName("SELL_ON_ECOM");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnFanatics).HasColumnName("SELL_ON_FANATICS");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnGuitarCenter).HasColumnName("SELL_ON_GUITAR_CENTER");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnHayneedle).HasColumnName("SELL_ON_HAYNEEDLE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnHouzz).HasColumnName("SELL_ON_HOUZZ");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnJet).HasColumnName("SELL_ON_JET");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnTarget).HasColumnName("SELL_ON_TARGET");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnTrs).HasColumnName("SELL_ON_TRS");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnWalmart).HasColumnName("SELL_ON_WALMART");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnWayfair).HasColumnName("SELL_ON_WAYFAIR");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.SellOnWeb).HasColumnName("SELL_ON_WEB");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.ShortDesc).HasColumnName("SHORT_DESC");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Size).HasColumnName("SIZE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.StandardCost).HasColumnName("STANDARD_COST");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.StatsCode).HasColumnName("STATS_CODE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.TariffCode).HasColumnName("TARIFF_CODE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Territory).HasColumnName("TERRITORY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Title).HasColumnName("TITLE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Udex).HasColumnName("UDEX");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Upc).HasColumnName("UPC");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Username).HasColumnName("USERNAME");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Warranty).HasColumnName("WARRANTY");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.WarrantyCheck).HasColumnName("WARRANTY_CHECK");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.WebsitePrice).HasColumnName("WEBSITE_PRICE");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Weight).HasColumnName("WEIGHT");
            modelBuilder.Entity<OdinItemUpdateRecords>().Property(p => p.Width).HasColumnName("WIDTH");

        }

        /// <summary>
        ///             This method maps the OdinLanguage class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinLanguage(DbModelBuilder modelBuilder)
        {
            // Map the OdinLanguage class to the ODIN_LANGUAGES table
            modelBuilder.Entity<OdinLanguage>()
                .HasKey(p => new
                {
                    p.Language
                })
                .ToTable("ODIN_LANGUAGES");

            // Map each column
            modelBuilder.Entity<OdinLanguage>().Property(p => p.Language).HasColumnName("LANGUAGE");

        }

        /// <summary>
        ///             This method maps the OdinMetaDescription class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinMetaDescription(DbModelBuilder modelBuilder)
        {
            // Map the OdinMetaDescription class to the Odin_MetaDescription table
            modelBuilder.Entity<OdinMetaDescription>()
                .HasKey(p => new
                {
                    p.MetaDescription
                })
                .ToTable("Odin_MetaDescription");

            // Map each column
            modelBuilder.Entity<OdinMetaDescription>().Property(p => p.Id).HasColumnName("ID");
            modelBuilder.Entity<OdinMetaDescription>().Property(p => p.MetaDescription).HasColumnName("META_DESCRIPTION");

        }

        /// <summary>
        ///             This method maps the OdinNewWebCategories class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinNewWebCategories(DbModelBuilder modelBuilder)
        {
            // Map the OdinNewWebCategories class to the Odin_NewWebCategories table
            modelBuilder.Entity<OdinNewWebCategories>()
                .HasKey(p => new
                {
                    p.Id
                })
                .ToTable("Odin_NewWebCategories");

            // Map each column
            modelBuilder.Entity<OdinNewWebCategories>().Property(p => p.Category).HasColumnName("CATEGORY");
            modelBuilder.Entity<OdinNewWebCategories>().Property(p => p.Id).HasColumnName("ID");
            modelBuilder.Entity<OdinNewWebCategories>().Property(p => p.OldId).HasColumnName("OLD_ID");
        }

        /// <summary>
        ///             This method maps the OdinNotifications class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinNotifications(DbModelBuilder modelBuilder)
        {
            // Map the OdinNewWebCategories class to the ODIN_NOTIFICATIONS table
            modelBuilder.Entity<OdinNotifications>()
                .HasKey(p => new
                {
                    p.NotificationNumber
                })
                .ToTable("ODIN_NOTIFICATIONS");

            // Map each column
            modelBuilder.Entity<OdinNotifications>().Property(p => p.Date).HasColumnName("DATE");
            modelBuilder.Entity<OdinNotifications>().Property(p => p.Notification).HasColumnName("NOTIFICATION");
            modelBuilder.Entity<OdinNotifications>().Property(p => p.NotificationNumber).HasColumnName("NOTIFICATION_NUMBER");
        }

        /// <summary>
        ///             This method maps the OdinOptionsTable class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinOptionsTable(DbModelBuilder modelBuilder)
        {
            // Map the OdinOptionsTable class to the ODIN_OPTIONS_TABLE table
            modelBuilder.Entity<OdinOptionsTable>()
                .HasKey(p => new
                {
                    p.OptionId,
                    p.UserName,
                    p.Value
                })
                .ToTable("ODIN_OPTIONS_TABLE");

            // Map each column
            modelBuilder.Entity<OdinOptionsTable>().Property(p => p.OptionId).HasColumnName("OPTION_ID");
            modelBuilder.Entity<OdinOptionsTable>().Property(p => p.UserName).HasColumnName("USERNAME");
            modelBuilder.Entity<OdinOptionsTable>().Property(p => p.Value).HasColumnName("VALUE");
        }

        /// <summary>
        ///             This method maps the OdinRequestComments class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinRequestComments(DbModelBuilder modelBuilder)
        {
            // Map the OdinRequestComments class to the Odin_RequestComments table
            modelBuilder.Entity<OdinRequestComments>()
                .HasKey(p => new
                {
                    p.Rid
                })
                .ToTable("Odin_RequestComments");

            // Map each column
            modelBuilder.Entity<OdinRequestComments>().Property(p => p.Groupcomment).HasColumnName("GroupComment");
            modelBuilder.Entity<OdinRequestComments>().Property(p => p.Rid).HasColumnName("RID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }

        /// <summary>
        ///             This method maps the OdinRolePermissions class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinRolePermissions(DbModelBuilder modelBuilder)
        {
            // Map the OdinRolePermissions class to the ODIN_ROLE_PERMISSIONS table
            modelBuilder.Entity<OdinRolePermissions>()
                .HasKey(p => new
                {
                    p.Role,
                    p.Permission
                })
                .ToTable("ODIN_ROLE_PERMISSIONS");

            // Map each column
            modelBuilder.Entity<OdinRolePermissions>().Property(p => p.Permission).HasColumnName("PERMISSION");
            modelBuilder.Entity<OdinRolePermissions>().Property(p => p.Role).HasColumnName("ROLE");
        }

        /// <summary>
        ///             This method maps the OdinShoptrendsBrands class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinShoptrendsBrands(DbModelBuilder modelBuilder)
        {
            // Map the OdinShoptrendsBrands class to the ODIN_SHOPTRENDS_BRANDS table
            modelBuilder.Entity<OdinShoptrendsBrands>()
                .HasKey(p => new
                {
                    p.Brand
                })
                .ToTable("ODIN_SHOPTRENDS_BRANDS");

            // Map each column
            modelBuilder.Entity<OdinShoptrendsBrands>().Property(p => p.Brand).HasColumnName("BRAND");

        }
        /// <summary>
        ///             This method maps the OdinSpecialChars class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinSpecialChars(DbModelBuilder modelBuilder)
        {
            // Map the ODIN_SPECIAL_CHARS class to the PS_ASSET_ITEM_ATTR table
            modelBuilder.Entity<OdinSpecialChars>()
                .HasKey(p => new
                {
                    p.Character,
                    p.Id
                })
                .ToTable("ODIN_SPECIAL_CHARS");

            // Map each column
            modelBuilder.Entity<OdinSpecialChars>().Property(p => p.Character).HasColumnName("CHARACTER");
            modelBuilder.Entity<OdinSpecialChars>().Property(p => p.Id).HasColumnName("ID");

        }

        /// <summary>
        ///             This method maps the OdinTerritories class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinTerritories(DbModelBuilder modelBuilder)
        {
            // Map the OdinTerritories class to the ODIN_TERRITORIES table
            modelBuilder.Entity<OdinTerritories>()
                .HasKey(p => new
                {
                    p.Territory
                })
                .ToTable("ODIN_TERRITORIES");

            // Map each column
            modelBuilder.Entity<OdinTerritories>().Property(p => p.Territory).HasColumnName("TERRITORY");

        }

        /// <summary>
        ///             This method maps the OdinToolTips class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinToolTips(DbModelBuilder modelBuilder)
        {
            // Map the OdinToolTips class to the ODIN_TOOL_TIPS table
            modelBuilder.Entity<OdinToolTips>()
                .HasKey(p => new
                {
                    p.Name
                })
                .ToTable("ODIN_TOOL_TIPS");

            // Map each column
            modelBuilder.Entity<OdinToolTips>().Property(p => p.Name).HasColumnName("NAME");
            modelBuilder.Entity<OdinToolTips>().Property(p => p.Value).HasColumnName("VALUE");

        }

        /// <summary>
        ///             This method maps the OdinUserExceptions class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinUserExceptions(DbModelBuilder modelBuilder)
        {
            // Map the OdinUserExceptions class to the ODIN_USER_EXCEPTIONS table
            modelBuilder.Entity<OdinUserExceptions>()
                .HasKey(p => new
                {
                    p.Username,
                    p.Exception
                })
                .ToTable("ODIN_USER_EXCEPTIONS");

            // Map each column
            modelBuilder.Entity<OdinUserExceptions>().Property(p => p.Username).HasColumnName("USERNAME");
            modelBuilder.Entity<OdinUserExceptions>().Property(p => p.Exception).HasColumnName("EXCEPTION");
        }

        /// <summary>
        ///             This method maps the OdinUserRoles class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinUserRoles(DbModelBuilder modelBuilder)
        {
            // Map the OdinUserRoles class to the ODIN_USER_ROLES table
            modelBuilder.Entity<OdinUserRoles>()
                .HasKey(p => new
                {
                    p.Username
                })
                .ToTable("ODIN_USER_ROLES");

            // Map each column
            modelBuilder.Entity<OdinUserRoles>().Property(p => p.NotificationNumber).HasColumnName("NOTIFICATION_NUMBER");
            modelBuilder.Entity<OdinUserRoles>().Property(p => p.Role).HasColumnName("ROLE");
            modelBuilder.Entity<OdinUserRoles>().Property(p => p.Username).HasColumnName("USER_NAME");
        }

        /// <summary>
        ///             This method maps the OdinWebLanguages class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinWebLanguages(DbModelBuilder modelBuilder)
        {
            // Map the OdinWebLanguages class to the Odin_Web_Languages table
            modelBuilder.Entity<OdinWebLanguages>()
                .HasKey(p => new
                {
                    p.Language
                })
                .ToTable("Odin_Web_Languages");

            // Map each column
            modelBuilder.Entity<OdinWebLanguages>().Property(p => p.Language).HasColumnName("LANGUAGE");

        }

        /// <summary>
        ///             This method maps the OdinWebLicense class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinWebLicense(DbModelBuilder modelBuilder)
        {
            // Map the OdinWebLicense class to the Odin_Web_License table
            modelBuilder.Entity<OdinWebLicense>()
                .HasKey(p => new
                {
                    p.License,
                    p.Property
                })
                .ToTable("Odin_Web_License");

            // Map each column
            modelBuilder.Entity<OdinWebLicense>().Property(p => p.License).HasColumnName("LICENSE");
            modelBuilder.Entity<OdinWebLicense>().Property(p => p.Property).HasColumnName("PROPERTY");
        }

        /// <summary>
        ///             This method maps the OdinWebsiteItemRequests class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinWebsiteItemRequests(DbModelBuilder modelBuilder)
        {
            // Map the OdinWebsiteItemRequests class to the Odin_WebsiteItemRequests table
            modelBuilder.Entity<OdinWebsiteItemRequests>()
                .HasKey(p => new
                {
                    p.RequestId,
                    p.ItemId
                })
                .ToTable("Odin_WebsiteItemRequests");

            // Map each column
            modelBuilder.Entity<OdinWebsiteItemRequests>().Property(p => p.Comment).HasColumnName("Comment");
            modelBuilder.Entity<OdinWebsiteItemRequests>().Property(p => p.DttmSubmitted).HasColumnName("DttmSubmitted");
            modelBuilder.Entity<OdinWebsiteItemRequests>().Property(p => p.InStockDate).HasColumnName("InStockDate");
            modelBuilder.Entity<OdinWebsiteItemRequests>().Property(p => p.ItemCategory).HasColumnName("ItemCategory");
            modelBuilder.Entity<OdinWebsiteItemRequests>().Property(p => p.ItemId).HasColumnName("ItemId");
            modelBuilder.Entity<OdinWebsiteItemRequests>().Property(p => p.ItemStatus).HasColumnName("ItemStatus");
            modelBuilder.Entity<OdinWebsiteItemRequests>().Property(p => p.RequestId).HasColumnName("RequestId");
            modelBuilder.Entity<OdinWebsiteItemRequests>().Property(p => p.RequestStatus).HasColumnName("RequestStatus");
            modelBuilder.Entity<OdinWebsiteItemRequests>().Property(p => p.UserName).HasColumnName("UserName");
            modelBuilder.Entity<OdinWebsiteItemRequests>().Property(p => p.Website).HasColumnName("Website");
        }

        /// <summary>
        ///             This method maps the OdinWebTerritories class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOdinWebTerritories(DbModelBuilder modelBuilder)
        {
            // Map the OdinWebTerritories class to the Odin_Web_Territories table
            modelBuilder.Entity<OdinWebTerritories>()
                .HasKey(p => new
                {
                    p.Territory
                })
                .ToTable("Odin_Web_Territories");

            // Map each column
            modelBuilder.Entity<OdinWebTerritories>().Property(p => p.Territory).HasColumnName("TERRITORY");

        }

        /// <summary>
        ///             This method maps the OrdLine class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapOrdLine(DbModelBuilder modelBuilder)
        {
            // Map the OrdLine class to the PS_ORD_LINE table
            modelBuilder.Entity<OrdLine>()
                .HasKey(p => new
                {
                    p.BusinessUnit,
                    p.OrderNo,
                    p.OrderIntLineNo
                })
                .ToTable("PS_ORD_LINE");

            // Map each column
            modelBuilder.Entity<OrdLine>().Property(p => p.AddrOvrdLevel).HasColumnName("ADDR_OVRD_LEVEL");
            modelBuilder.Entity<OrdLine>().Property(p => p.AddressSeqNum).HasColumnName("ADDRESS_SEQ_NUM");
            modelBuilder.Entity<OrdLine>().Property(p => p.Aerp).HasColumnName("AERP");
            modelBuilder.Entity<OrdLine>().Property(p => p.AllowOverpickFlg).HasColumnName("ALLOW_OVERPICK_FLG");
            modelBuilder.Entity<OrdLine>().Property(p => p.BckordrCnclFlag).HasColumnName("BCKORDR_CNCL_FLAG");
            modelBuilder.Entity<OrdLine>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<OrdLine>().Property(p => p.CancelDate).HasColumnName("CANCEL_DATE");
            modelBuilder.Entity<OrdLine>().Property(p => p.CarrierId).HasColumnName("CARRIER_ID");
            modelBuilder.Entity<OrdLine>().Property(p => p.CarrierIdExp).HasColumnName("CARRIER_ID_EXP");
            modelBuilder.Entity<OrdLine>().Property(p => p.CciReqExp).HasColumnName("CCI_REQ_EXP");
            modelBuilder.Entity<OrdLine>().Property(p => p.CntrctId).HasColumnName("CNTRCT_ID");
            modelBuilder.Entity<OrdLine>().Property(p => p.CntrctLineNbr).HasColumnName("CNTRCT_LINE_NBR");
            modelBuilder.Entity<OrdLine>().Property(p => p.CntrctSchedNbr).HasColumnName("CNTRCT_SCHED_NBR");
            modelBuilder.Entity<OrdLine>().Property(p => p.ConfigCode).HasColumnName("CONFIG_CODE");
            modelBuilder.Entity<OrdLine>().Property(p => p.CooReqExp).HasColumnName("COO_REQ_EXP");
            modelBuilder.Entity<OrdLine>().Property(p => p.CountryLocBuyer).HasColumnName("COUNTRY_LOC_BUYER");
            modelBuilder.Entity<OrdLine>().Property(p => p.CountryLocSeller).HasColumnName("COUNTRY_LOC_SELLER");
            modelBuilder.Entity<OrdLine>().Property(p => p.CountryShipFrom).HasColumnName("COUNTRY_SHIP_FROM");
            modelBuilder.Entity<OrdLine>().Property(p => p.CountryShipTo).HasColumnName("COUNTRY_SHIP_TO");
            modelBuilder.Entity<OrdLine>().Property(p => p.CountryVatBillfr).HasColumnName("COUNTRY_VAT_BILLFR");
            modelBuilder.Entity<OrdLine>().Property(p => p.CountryVatBillto).HasColumnName("COUNTRY_VAT_BILLTO");
            modelBuilder.Entity<OrdLine>().Property(p => p.CountryVatPerfrm).HasColumnName("COUNTRY_VAT_PERFRM");
            modelBuilder.Entity<OrdLine>().Property(p => p.CountryVatSupply).HasColumnName("COUNTRY_VAT_SUPPLY");
            modelBuilder.Entity<OrdLine>().Property(p => p.CpTemplateId).HasColumnName("CP_TEMPLATE_ID");
            modelBuilder.Entity<OrdLine>().Property(p => p.CsdBenefitId).HasColumnName("CSD_BENEFIT_ID");
            modelBuilder.Entity<OrdLine>().Property(p => p.CurrencyCd).HasColumnName("CURRENCY_CD");
            modelBuilder.Entity<OrdLine>().Property(p => p.CurrencyCdBase).HasColumnName("CURRENCY_CD_BASE");
            modelBuilder.Entity<OrdLine>().Property(p => p.CustBbackAllBse).HasColumnName("CUST_BBACK_ALL_BSE");
            modelBuilder.Entity<OrdLine>().Property(p => p.CustBillBackAll).HasColumnName("CUST_BILL_BACK_ALL");
            modelBuilder.Entity<OrdLine>().Property(p => p.CustNetPrcBase).HasColumnName("CUST_NET_PRC_BASE");
            modelBuilder.Entity<OrdLine>().Property(p => p.CustNetPrice).HasColumnName("CUST_NET_PRICE");
            modelBuilder.Entity<OrdLine>().Property(p => p.CustOffInvBase).HasColumnName("CUST_OFF_INV_BASE");
            modelBuilder.Entity<OrdLine>().Property(p => p.CustOffInvDisc).HasColumnName("CUST_OFF_INV_DISC");
            modelBuilder.Entity<OrdLine>().Property(p => p.CustPoPrcBase).HasColumnName("CUST_PO_PRC_BASE");
            modelBuilder.Entity<OrdLine>().Property(p => p.CustPoPrice).HasColumnName("CUST_PO_PRICE");
            modelBuilder.Entity<OrdLine>().Property(p => p.CustomerItemNbr).HasColumnName("CUSTOMER_ITEM_NBR");
            modelBuilder.Entity<OrdLine>().Property(p => p.CustomerPo).HasColumnName("CUSTOMER_PO");
            modelBuilder.Entity<OrdLine>().Property(p => p.CustomerPoLine).HasColumnName("CUSTOMER_PO_LINE");
            modelBuilder.Entity<OrdLine>().Property(p => p.DatetimeAdded).HasColumnName("DATETIME_ADDED");
            modelBuilder.Entity<OrdLine>().Property(p => p.DropShipFlag).HasColumnName("DROP_SHIP_FLAG");
            modelBuilder.Entity<OrdLine>().Property(p => p.Export).HasColumnName("EXPORT");
            modelBuilder.Entity<OrdLine>().Property(p => p.ExportApplDt).HasColumnName("EXPORT_APPL_DT");
            modelBuilder.Entity<OrdLine>().Property(p => p.ExportLicAppl).HasColumnName("EXPORT_LIC_APPL");
            modelBuilder.Entity<OrdLine>().Property(p => p.ExportLicExpire).HasColumnName("EXPORT_LIC_EXPIRE");
            modelBuilder.Entity<OrdLine>().Property(p => p.ExportLicNbr).HasColumnName("EXPORT_LIC_NBR");
            modelBuilder.Entity<OrdLine>().Property(p => p.ExportLicQty).HasColumnName("EXPORT_LIC_QTY");
            modelBuilder.Entity<OrdLine>().Property(p => p.ExportLicRec).HasColumnName("EXPORT_LIC_REC");
            modelBuilder.Entity<OrdLine>().Property(p => p.ExportLicReq).HasColumnName("EXPORT_LIC_REQ");
            modelBuilder.Entity<OrdLine>().Property(p => p.ExportLicType).HasColumnName("EXPORT_LIC_TYPE");
            modelBuilder.Entity<OrdLine>().Property(p => p.ExportLicValue).HasColumnName("EXPORT_LIC_VALUE");
            modelBuilder.Entity<OrdLine>().Property(p => p.ExportRecDt).HasColumnName("EXPORT_REC_DT");
            modelBuilder.Entity<OrdLine>().Property(p => p.ExsTaxTxnType).HasColumnName("EXS_TAX_TXN_TYPE");
            modelBuilder.Entity<OrdLine>().Property(p => p.FreightTerms).HasColumnName("FREIGHT_TERMS");
            modelBuilder.Entity<OrdLine>().Property(p => p.FreightTermsExp).HasColumnName("FREIGHT_TERMS_EXP");
            modelBuilder.Entity<OrdLine>().Property(p => p.ImportApplDt).HasColumnName("IMPORT_APPL_DT");
            modelBuilder.Entity<OrdLine>().Property(p => p.ImportCertNbr).HasColumnName("IMPORT_CERT_NBR");
            modelBuilder.Entity<OrdLine>().Property(p => p.ImportLicAppl).HasColumnName("IMPORT_LIC_APPL");
            modelBuilder.Entity<OrdLine>().Property(p => p.ImportLicExp).HasColumnName("IMPORT_LIC_EXP");
            modelBuilder.Entity<OrdLine>().Property(p => p.ImportLicRec).HasColumnName("IMPORT_LIC_REC");
            modelBuilder.Entity<OrdLine>().Property(p => p.ImportLicReq).HasColumnName("IMPORT_LIC_REQ");
            modelBuilder.Entity<OrdLine>().Property(p => p.ImportRecDt).HasColumnName("IMPORT_REC_DT");
            modelBuilder.Entity<OrdLine>().Property(p => p.IstTxnFlg).HasColumnName("IST_TXN_FLG");
            modelBuilder.Entity<OrdLine>().Property(p => p.LastMaintOprid).HasColumnName("LAST_MAINT_OPRID");
            modelBuilder.Entity<OrdLine>().Property(p => p.Lastupddttm).HasColumnName("LASTUPDDTTM");
            modelBuilder.Entity<OrdLine>().Property(p => p.ListPrice).HasColumnName("LIST_PRICE");
            modelBuilder.Entity<OrdLine>().Property(p => p.ListPriceBase).HasColumnName("LIST_PRICE_BASE");
            modelBuilder.Entity<OrdLine>().Property(p => p.ListPriceOrig).HasColumnName("LIST_PRICE_ORIG");
            modelBuilder.Entity<OrdLine>().Property(p => p.ListPriceorigBse).HasColumnName("LIST_PRICEORIG_BSE");
            modelBuilder.Entity<OrdLine>().Property(p => p.LoadId).HasColumnName("LOAD_ID");
            modelBuilder.Entity<OrdLine>().Property(p => p.MaxPickTolerance).HasColumnName("MAX_PICK_TOLERANCE");
            modelBuilder.Entity<OrdLine>().Property(p => p.NaftaReqExp).HasColumnName("NAFTA_REQ_EXP");
            modelBuilder.Entity<OrdLine>().Property(p => p.OrdLineStatus).HasColumnName("ORD_LINE_STATUS");
            modelBuilder.Entity<OrdLine>().Property(p => p.OrdLineTag).HasColumnName("ORD_LINE_TAG");
            modelBuilder.Entity<OrdLine>().Property(p => p.OrderGrp).HasColumnName("ORDER_GRP");
            modelBuilder.Entity<OrdLine>().Property(p => p.OrderIntLineNo).HasColumnName("ORDER_INT_LINE_NO");
            modelBuilder.Entity<OrdLine>().Property(p => p.OrderNo).HasColumnName("ORDER_NO");
            modelBuilder.Entity<OrdLine>().Property(p => p.PaymentMethod).HasColumnName("PAYMENT_METHOD");
            modelBuilder.Entity<OrdLine>().Property(p => p.PhysicalNature).HasColumnName("PHYSICAL_NATURE");
            modelBuilder.Entity<OrdLine>().Property(p => p.Price).HasColumnName("PRICE");
            modelBuilder.Entity<OrdLine>().Property(p => p.PriceBase).HasColumnName("PRICE_BASE");
            modelBuilder.Entity<OrdLine>().Property(p => p.PriceOrig).HasColumnName("PRICE_ORIG");
            modelBuilder.Entity<OrdLine>().Property(p => p.PriceOrigBase).HasColumnName("PRICE_ORIG_BASE");
            modelBuilder.Entity<OrdLine>().Property(p => p.PriceProgram).HasColumnName("PRICE_PROGRAM");
            modelBuilder.Entity<OrdLine>().Property(p => p.PriceProtected).HasColumnName("PRICE_PROTECTED");
            modelBuilder.Entity<OrdLine>().Property(p => p.ProcessInstance).HasColumnName("PROCESS_INSTANCE");
            modelBuilder.Entity<OrdLine>().Property(p => p.ProdIdEntered).HasColumnName("PROD_ID_ENTERED");
            modelBuilder.Entity<OrdLine>().Property(p => p.ProdIdSrc).HasColumnName("PROD_ID_SRC");
            modelBuilder.Entity<OrdLine>().Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            modelBuilder.Entity<OrdLine>().Property(p => p.ProductIdOrig).HasColumnName("PRODUCT_ID_ORIG");
            modelBuilder.Entity<OrdLine>().Property(p => p.PymntTermsCd).HasColumnName("PYMNT_TERMS_CD");
            modelBuilder.Entity<OrdLine>().Property(p => p.QtyOrdered).HasColumnName("QTY_ORDERED");
            modelBuilder.Entity<OrdLine>().Property(p => p.QtyOrderedOrig).HasColumnName("QTY_ORDERED_ORIG");
            modelBuilder.Entity<OrdLine>().Property(p => p.ReasonCd).HasColumnName("REASON_CD");
            modelBuilder.Entity<OrdLine>().Property(p => p.ReplacementFlg).HasColumnName("REPLACEMENT_FLG");
            modelBuilder.Entity<OrdLine>().Property(p => p.ReqArrivalDttm).HasColumnName("REQ_ARRIVAL_DTTM");
            modelBuilder.Entity<OrdLine>().Property(p => p.ReqShipDttm).HasColumnName("REQ_SHIP_DTTM");
            modelBuilder.Entity<OrdLine>().Property(p => p.SchedArrvDttm).HasColumnName("SCHED_ARRV_DTTM");
            modelBuilder.Entity<OrdLine>().Property(p => p.SchedShipDttm).HasColumnName("SCHED_SHIP_DTTM");
            modelBuilder.Entity<OrdLine>().Property(p => p.SedReqExp).HasColumnName("SED_REQ_EXP");
            modelBuilder.Entity<OrdLine>().Property(p => p.ShipFromBu).HasColumnName("SHIP_FROM_BU");
            modelBuilder.Entity<OrdLine>().Property(p => p.ShipPartialFlag).HasColumnName("SHIP_PARTIAL_FLAG");
            modelBuilder.Entity<OrdLine>().Property(p => p.ShipPriorFlag).HasColumnName("SHIP_PRIOR_FLAG");
            modelBuilder.Entity<OrdLine>().Property(p => p.ShipPriorityExp).HasColumnName("SHIP_PRIORITY_EXP");
            modelBuilder.Entity<OrdLine>().Property(p => p.ShipPriorityId).HasColumnName("SHIP_PRIORITY_ID");
            modelBuilder.Entity<OrdLine>().Property(p => p.ShipToCustId).HasColumnName("SHIP_TO_CUST_ID");
            modelBuilder.Entity<OrdLine>().Property(p => p.ShipTypeId).HasColumnName("SHIP_TYPE_ID");
            modelBuilder.Entity<OrdLine>().Property(p => p.ShipTypeIdExp).HasColumnName("SHIP_TYPE_ID_EXP");
            modelBuilder.Entity<OrdLine>().Property(p => p.StateLocBuyer).HasColumnName("STATE_LOC_BUYER");
            modelBuilder.Entity<OrdLine>().Property(p => p.StateLocSeller).HasColumnName("STATE_LOC_SELLER");
            modelBuilder.Entity<OrdLine>().Property(p => p.StateShipFrom).HasColumnName("STATE_SHIP_FROM");
            modelBuilder.Entity<OrdLine>().Property(p => p.StateShipTo).HasColumnName("STATE_SHIP_TO");
            modelBuilder.Entity<OrdLine>().Property(p => p.StateVatDefault).HasColumnName("STATE_VAT_DEFAULT");
            modelBuilder.Entity<OrdLine>().Property(p => p.StateVatPerfrm).HasColumnName("STATE_VAT_PERFRM");
            modelBuilder.Entity<OrdLine>().Property(p => p.StdDiscount).HasColumnName("STD_DISCOUNT");
            modelBuilder.Entity<OrdLine>().Property(p => p.StoreNumber).HasColumnName("STORE_NUMBER");
            modelBuilder.Entity<OrdLine>().Property(p => p.TaxCd).HasColumnName("TAX_CD");
            modelBuilder.Entity<OrdLine>().Property(p => p.TaxCdVat).HasColumnName("TAX_CD_VAT");
            modelBuilder.Entity<OrdLine>().Property(p => p.TaxCustGroup).HasColumnName("TAX_CUST_GROUP");
            modelBuilder.Entity<OrdLine>().Property(p => p.TrnsptLeadDays).HasColumnName("TRNSPT_LEAD_DAYS");
            modelBuilder.Entity<OrdLine>().Property(p => p.TrnsptLeadHours).HasColumnName("TRNSPT_LEAD_HOURS");
            modelBuilder.Entity<OrdLine>().Property(p => p.TrnsptLeadMin).HasColumnName("TRNSPT_LEAD_MIN");
            modelBuilder.Entity<OrdLine>().Property(p => p.UnitCost).HasColumnName("UNIT_COST");
            modelBuilder.Entity<OrdLine>().Property(p => p.UnitOfMeasure).HasColumnName("UNIT_OF_MEASURE");
            modelBuilder.Entity<OrdLine>().Property(p => p.UomOrig).HasColumnName("UOM_ORIG");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatApplicability).HasColumnName("VAT_APPLICABILITY");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatCalcGrossNet).HasColumnName("VAT_CALC_GROSS_NET");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatCntrySubdFlg).HasColumnName("VAT_CNTRY_SUBD_FLG");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatDclrtnPoint).HasColumnName("VAT_DCLRTN_POINT");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatDfltDoneFlg).HasColumnName("VAT_DFLT_DONE_FLG");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatDstAcctType).HasColumnName("VAT_DST_ACCT_TYPE");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatEntity).HasColumnName("VAT_ENTITY");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatExcptnCertif).HasColumnName("VAT_EXCPTN_CERTIF");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatExcptnType).HasColumnName("VAT_EXCPTN_TYPE");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatRecalcFlg).HasColumnName("VAT_RECALC_FLG");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatRgstrnBuyer).HasColumnName("VAT_RGSTRN_BUYER");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatRoundRule).HasColumnName("VAT_ROUND_RULE");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatServiceType).HasColumnName("VAT_SERVICE_TYPE");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatSvcSupplyFlg).HasColumnName("VAT_SVC_SUPPLY_FLG");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatTreatment).HasColumnName("VAT_TREATMENT");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatTreatmentGrp).HasColumnName("VAT_TREATMENT_GRP");
            modelBuilder.Entity<OrdLine>().Property(p => p.VatTxnTypeCd).HasColumnName("VAT_TXN_TYPE_CD");


        }

        /// <summary>
        ///             This method maps the PlItemAttrib class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapPlItemAttrib(DbModelBuilder modelBuilder)
        {
            // Map the PlItemAttrib class to the PS_PL_ITEM_ATTRIB table
            modelBuilder.Entity<PlItemAttrib>()
                .HasKey(p => new
                {
                    p.BusinessUnit,
                    p.InvItemId
                })
                .ToTable("PS_PL_ITEM_ATTRIB");

            // Map each column
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.AutoApproveMsg).HasColumnName("AUTO_APPROVE_MSG");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.CapFenceOff).HasColumnName("CAP_FENCE_OFF");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.DemandFenceOf).HasColumnName("DEMAND_FENCE_OF");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.EarlyFence).HasColumnName("EARLY_FENCE");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.ExcessLevel).HasColumnName("EXCESS_LEVEL");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.ExtraConsump).HasColumnName("EXTRA_CONSUMP");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.FcstAdjAction).HasColumnName("FCST_ADJ_ACTION");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.FcstFulfillSize).HasColumnName("FCST_FULFILL_SIZE");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.FirmedOrder).HasColumnName("FIRMED_ORDER");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.GblEarlyFence).HasColumnName("GBL_EARLY_FENCE");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.MfgLeadTimeFlag).HasColumnName("MFG_LEAD_TIME_FLAG");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.MfgMaxOrder).HasColumnName("MFG_MAX_ORDER");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.MfgMinOrder).HasColumnName("MFG_MIN_ORDER");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.MfgModUnit).HasColumnName("MFG_MOD_UNIT");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.MfgOrderMod).HasColumnName("MFG_ORDER_MOD");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.MfgOrderMultiple).HasColumnName("MFG_ORDER_MULTIPLE");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.MsrConsump).HasColumnName("MSR_CONSUMP");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PlAggDmdFlag).HasColumnName("PL_AGG_DMD_FLAG");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PlFixedPeriod).HasColumnName("PL_FIXED_PERIOD");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PlItemExpl).HasColumnName("PL_ITEM_EXPL");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PlPrioFamily).HasColumnName("PL_PRIO_FAMILY");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PlProjUseDt).HasColumnName("PL_PROJ_USE_DT");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PlSearchDepth).HasColumnName("PL_SEARCH_DEPTH");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PlanFenceOff).HasColumnName("PLAN_FENCE_OFF");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PlanHorizon).HasColumnName("PLAN_HORIZON");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PlannedBy).HasColumnName("PLANNED_BY");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PlannerCd).HasColumnName("PLANNER_CD");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.ProdConsump).HasColumnName("PROD_CONSUMP");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PurMaxOrder).HasColumnName("PUR_MAX_ORDER");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PurMinOrder).HasColumnName("PUR_MIN_ORDER");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PurOrderMod).HasColumnName("PUR_ORDER_MOD");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PurOrderMultiple).HasColumnName("PUR_ORDER_MULTIPLE");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.PurchaseYield).HasColumnName("PURCHASE_YIELD");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.ReleasedOrder).HasColumnName("RELEASED_ORDER");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.ReschInFactor).HasColumnName("RESCH_IN_FACTOR");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.ReschOutFactor).HasColumnName("RESCH_OUT_FACTOR");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.SafetyLevel).HasColumnName("SAFETY_LEVEL");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.SalesConsump).HasColumnName("SALES_CONSUMP");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.SpotBuyFlg).HasColumnName("SPOT_BUY_FLG");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.TransConsump).HasColumnName("TRANS_CONSUMP");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.TransOrdMultiple).HasColumnName("TRANS_ORD_MULTIPLE");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.TransferMaxOrder).HasColumnName("TRANSFER_MAX_ORDER");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.TransferMinOrder).HasColumnName("TRANSFER_MIN_ORDER");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.TransferOrdMod).HasColumnName("TRANSFER_ORD_MOD");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.TransferYield).HasColumnName("TRANSFER_YIELD");
            modelBuilder.Entity<PlItemAttrib>().Property(p => p.UseShiptoLoc).HasColumnName("USE_SHIPTO_LOC");

        }

        /// <summary>
        ///             This method maps the ProdCatgryTbl class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProdCatgryTbl(DbModelBuilder modelBuilder)
        {
            // Map the ProdCatgryTbl class to the PS_PROD_CATGRY_TBL table
            modelBuilder.Entity<ProdCatgryTbl>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.ProdCategory,
                    p.Effdt
                })
                .ToTable("PS_PROD_CATGRY_TBL");

            // Map each column
            modelBuilder.Entity<ProdCatgryTbl>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<ProdCatgryTbl>().Property(p => p.Descrshort).HasColumnName("DESCRSHORT");
            modelBuilder.Entity<ProdCatgryTbl>().Property(p => p.EffStatus).HasColumnName("EFF_STATUS");
            modelBuilder.Entity<ProdCatgryTbl>().Property(p => p.Effdt).HasColumnName("EFFDT");
            modelBuilder.Entity<ProdCatgryTbl>().Property(p => p.ProdCategory).HasColumnName("PROD_CATEGORY");
            modelBuilder.Entity<ProdCatgryTbl>().Property(p => p.Setid).HasColumnName("SETID");

        }

        /// <summary>
        ///             This method maps the ProdGroupTbl class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProdGroupTbl(DbModelBuilder modelBuilder)
        {
            // Map the ProdGroupTbl class to the PS_PROD_GROUP_TBL table
            modelBuilder.Entity<ProdGroupTbl>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.ProdGrpType,
                    p.ProductGroup,
                    p.Effdt
                })
                .ToTable("PS_PROD_GROUP_TBL");

            // Map each column
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.DatetimeAdded).HasColumnName("DATETIME_ADDED");
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.Descrshort).HasColumnName("DESCRSHORT");
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.EffStatus).HasColumnName("EFF_STATUS");
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.Effdt).HasColumnName("EFFDT");
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.GlobalFlag).HasColumnName("GLOBAL_FLAG");
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.LastMaintOprid).HasColumnName("LAST_MAINT_OPRID");
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.Lastupddttm).HasColumnName("LASTUPDDTTM");
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.ProdGrpType).HasColumnName("PROD_GRP_TYPE");
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.ProductGroup).HasColumnName("PRODUCT_GROUP");
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<ProdGroupTbl>().Property(p => p.WebOeProdCat).HasColumnName("WEB_OE_PROD_CAT");

        }

        /// <summary>
        ///             This method maps the ProdItem class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProdItem(DbModelBuilder modelBuilder)
        {
            // Map the ProdItem class to the PS_PROD_ITEM table
            modelBuilder.Entity<ProdItem>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.ProductId
                })
                .ToTable("PS_PROD_ITEM");

            // Map each column
            modelBuilder.Entity<ProdItem>().Property(p => p.ActivityId).HasColumnName("ACTIVITY_ID");
            modelBuilder.Entity<ProdItem>().Property(p => p.AppliesTo).HasColumnName("APPLIES_TO");
            modelBuilder.Entity<ProdItem>().Property(p => p.BpDtlTmplId).HasColumnName("BP_DTL_TMPL_ID");
            modelBuilder.Entity<ProdItem>().Property(p => p.BusinessUnitPc).HasColumnName("BUSINESS_UNIT_PC");
            modelBuilder.Entity<ProdItem>().Property(p => p.CaApTmplId).HasColumnName("CA_AP_TMPL_ID");
            modelBuilder.Entity<ProdItem>().Property(p => p.CaBpTmplId).HasColumnName("CA_BP_TMPL_ID");
            modelBuilder.Entity<ProdItem>().Property(p => p.CatalogNbr).HasColumnName("CATALOG_NBR");
            modelBuilder.Entity<ProdItem>().Property(p => p.CfgCodeOpt).HasColumnName("CFG_CODE_OPT");
            modelBuilder.Entity<ProdItem>().Property(p => p.CfgKitFlag).HasColumnName("CFG_KIT_FLAG");
            modelBuilder.Entity<ProdItem>().Property(p => p.CommFlag).HasColumnName("COMM_FLAG");
            modelBuilder.Entity<ProdItem>().Property(p => p.CommPct).HasColumnName("COMM_PCT");
            modelBuilder.Entity<ProdItem>().Property(p => p.CostElement).HasColumnName("COST_ELEMENT");
            modelBuilder.Entity<ProdItem>().Property(p => p.CpTemplateId).HasColumnName("CP_TEMPLATE_ID");
            modelBuilder.Entity<ProdItem>().Property(p => p.CpTreeDist).HasColumnName("CP_TREE_DIST");
            modelBuilder.Entity<ProdItem>().Property(p => p.DatetimeAdded).HasColumnName("DATETIME_ADDED");
            modelBuilder.Entity<ProdItem>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<ProdItem>().Property(p => p.Descr254).HasColumnName("DESCR254");
            modelBuilder.Entity<ProdItem>().Property(p => p.DropShipFlag).HasColumnName("DROP_SHIP_FLAG");
            modelBuilder.Entity<ProdItem>().Property(p => p.EffStatus).HasColumnName("EFF_STATUS");
            modelBuilder.Entity<ProdItem>().Property(p => p.ExportLicReq).HasColumnName("EXPORT_LIC_REQ");
            modelBuilder.Entity<ProdItem>().Property(p => p.ForecastItemFlag).HasColumnName("FORECAST_ITEM_FLAG");
            modelBuilder.Entity<ProdItem>().Property(p => p.HoldUpdateSw).HasColumnName("HOLD_UPDATE_SW");
            modelBuilder.Entity<ProdItem>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<ProdItem>().Property(p => p.LastMaintOprid).HasColumnName("LAST_MAINT_OPRID");
            modelBuilder.Entity<ProdItem>().Property(p => p.Lastupddttm).HasColumnName("LASTUPDDTTM");
            modelBuilder.Entity<ProdItem>().Property(p => p.LowerMarginPct).HasColumnName("LOWER_MARGIN_PCT");
            modelBuilder.Entity<ProdItem>().Property(p => p.ModelNbr).HasColumnName("MODEL_NBR");
            modelBuilder.Entity<ProdItem>().Property(p => p.Percentage).HasColumnName("PERCENTAGE");
            modelBuilder.Entity<ProdItem>().Property(p => p.PhysicalNature).HasColumnName("PHYSICAL_NATURE");
            modelBuilder.Entity<ProdItem>().Property(p => p.PriceKitFlag).HasColumnName("PRICE_KIT_FLAG");
            modelBuilder.Entity<ProdItem>().Property(p => p.PricingStructure).HasColumnName("PRICING_STRUCTURE");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdBrand).HasColumnName("PROD_BRAND");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdCategory).HasColumnName("PROD_CATEGORY");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC1A).HasColumnName("PROD_FIELD_C1_A");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC1B).HasColumnName("PROD_FIELD_C1_B");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC1C).HasColumnName("PROD_FIELD_C1_C");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC1D).HasColumnName("PROD_FIELD_C1_D");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC10A).HasColumnName("PROD_FIELD_C10_A");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC10B).HasColumnName("PROD_FIELD_C10_B");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC10C).HasColumnName("PROD_FIELD_C10_C");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC10D).HasColumnName("PROD_FIELD_C10_D");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC2).HasColumnName("PROD_FIELD_C2");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC30A).HasColumnName("PROD_FIELD_C30_A");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC30B).HasColumnName("PROD_FIELD_C30_B");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC30C).HasColumnName("PROD_FIELD_C30_C");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC30D).HasColumnName("PROD_FIELD_C30_D");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC4).HasColumnName("PROD_FIELD_C4");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC6).HasColumnName("PROD_FIELD_C6");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldC8).HasColumnName("PROD_FIELD_C8");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldN12A).HasColumnName("PROD_FIELD_N12_A");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldN12B).HasColumnName("PROD_FIELD_N12_B");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldN12C).HasColumnName("PROD_FIELD_N12_C");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldN12D).HasColumnName("PROD_FIELD_N12_D");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldN15A).HasColumnName("PROD_FIELD_N15_A");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldN15B).HasColumnName("PROD_FIELD_N15_B");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldN15C).HasColumnName("PROD_FIELD_N15_C");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProdFieldN15D).HasColumnName("PROD_FIELD_N15_D");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProductKitFlag).HasColumnName("PRODUCT_KIT_FLAG");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProductUse).HasColumnName("PRODUCT_USE");
            modelBuilder.Entity<ProdItem>().Property(p => p.ProjectId).HasColumnName("PROJECT_ID");
            modelBuilder.Entity<ProdItem>().Property(p => p.Renewable).HasColumnName("RENEWABLE");
            modelBuilder.Entity<ProdItem>().Property(p => p.ReturnFlag).HasColumnName("RETURN_FLAG");
            modelBuilder.Entity<ProdItem>().Property(p => p.RevRecogMethod).HasColumnName("REV_RECOG_METHOD");
            modelBuilder.Entity<ProdItem>().Property(p => p.RnwTemplateId).HasColumnName("RNW_TEMPLATE_ID");
            modelBuilder.Entity<ProdItem>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<ProdItem>().Property(p => p.TaxProductNbr).HasColumnName("TAX_PRODUCT_NBR");
            modelBuilder.Entity<ProdItem>().Property(p => p.TaxTransSubType).HasColumnName("TAX_TRANS_SUB_TYPE");
            modelBuilder.Entity<ProdItem>().Property(p => p.TaxTransType).HasColumnName("TAX_TRANS_TYPE");
            modelBuilder.Entity<ProdItem>().Property(p => p.ThirdPartyFlg).HasColumnName("THIRD_PARTY_FLG");
            modelBuilder.Entity<ProdItem>().Property(p => p.UpperMarginPct).HasColumnName("UPPER_MARGIN_PCT");
            modelBuilder.Entity<ProdItem>().Property(p => p.VatSvcPerfrmFlg).HasColumnName("VAT_SVC_PERFRM_FLG");

        }

        /// <summary>
        ///             This method maps the ProdPgrpLnk class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProdPgrpLnk(DbModelBuilder modelBuilder)
        {
            // Map the ProdPgrpLnk class to the PS_PROD_PGRP_LNK table
            modelBuilder.Entity<ProdPgrpLnk>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.ProductId,
                    p.ProdGrpType,
                    p.ProductGroup
                })
                .ToTable("PS_PROD_PGRP_LNK");

            // Map each column
            modelBuilder.Entity<ProdPgrpLnk>().Property(p => p.DatetimeAdded).HasColumnName("DATETIME_ADDED");
            modelBuilder.Entity<ProdPgrpLnk>().Property(p => p.LastMaintOprid).HasColumnName("LAST_MAINT_OPRID");
            modelBuilder.Entity<ProdPgrpLnk>().Property(p => p.Lastupddttm).HasColumnName("LASTUPDDTTM");
            modelBuilder.Entity<ProdPgrpLnk>().Property(p => p.PrimPrcFlag).HasColumnName("PRIM_PRC_FLAG");
            modelBuilder.Entity<ProdPgrpLnk>().Property(p => p.PrimaryFlag).HasColumnName("PRIMARY_FLAG");
            modelBuilder.Entity<ProdPgrpLnk>().Property(p => p.ProdGrpType).HasColumnName("PROD_GRP_TYPE");
            modelBuilder.Entity<ProdPgrpLnk>().Property(p => p.ProductGroup).HasColumnName("PRODUCT_GROUP");
            modelBuilder.Entity<ProdPgrpLnk>().Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            modelBuilder.Entity<ProdPgrpLnk>().Property(p => p.Setid).HasColumnName("SETID");
        }

        /// <summary>
        ///             This method maps the ProdPrice class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProdPrice(DbModelBuilder modelBuilder)
        {
            // Map the ProdPrice class to the PS_PROD_PRICE table
            // SETID, PRODUCT_ID, UNIT_OF_MEASURE, BUSINESS_UNIT_IN, CURRENCY_CD, EFFDT
            modelBuilder.Entity<ProdPrice>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.ProductId,
                    p.UnitOfMeasure,
                    p.BusinessUnitIn,
                    p.CurrencyCd,
                    p.Effdt
                })
                .ToTable("PS_PROD_PRICE");

            // Map each column
            modelBuilder.Entity<ProdPrice>().Property(p => p.BusinessUnitIn).HasColumnName("BUSINESS_UNIT_IN");
            modelBuilder.Entity<ProdPrice>().Property(p => p.CurrencyCd).HasColumnName("CURRENCY_CD");
            modelBuilder.Entity<ProdPrice>().Property(p => p.DatetimeAdded).HasColumnName("DATETIME_ADDED");
            modelBuilder.Entity<ProdPrice>().Property(p => p.EffStatus).HasColumnName("EFF_STATUS");
            modelBuilder.Entity<ProdPrice>().Property(p => p.Effdt).HasColumnName("EFFDT");
            modelBuilder.Entity<ProdPrice>().Property(p => p.LastMaintOprid).HasColumnName("LAST_MAINT_OPRID");
            modelBuilder.Entity<ProdPrice>().Property(p => p.Lastupddttm).HasColumnName("LASTUPDDTTM");
            modelBuilder.Entity<ProdPrice>().Property(p => p.ListPrice).HasColumnName("LIST_PRICE");
            modelBuilder.Entity<ProdPrice>().Property(p => p.MfgSugRtlPrc).HasColumnName("MFG_SUG_RTL_PRC");
            modelBuilder.Entity<ProdPrice>().Property(p => p.PricingFlag).HasColumnName("PRICING_FLAG");
            modelBuilder.Entity<ProdPrice>().Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            modelBuilder.Entity<ProdPrice>().Property(p => p.RepairCost).HasColumnName("REPAIR_COST");
            modelBuilder.Entity<ProdPrice>().Property(p => p.ServiceCost).HasColumnName("SERVICE_COST");
            modelBuilder.Entity<ProdPrice>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<ProdPrice>().Property(p => p.UnitCost).HasColumnName("UNIT_COST");
            modelBuilder.Entity<ProdPrice>().Property(p => p.UnitOfMeasure).HasColumnName("UNIT_OF_MEASURE");

        }

        /// <summary>
        ///             This method maps the ProdPriceBu class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProdPriceBu(DbModelBuilder modelBuilder)
        {
            // Map the ProdPriceBu class to the PS_PROD_PRICE_BU table
            modelBuilder.Entity<ProdPriceBu>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.ProductId,
                    p.UnitOfMeasure,
                    p.BusinessUnitIn,
                    p.CurrencyCd
                })
                .ToTable("PS_PROD_PRICE_BU");

            // Map each column
            modelBuilder.Entity<ProdPriceBu>().Property(p => p.BusinessUnitIn).HasColumnName("BUSINESS_UNIT_IN");
            modelBuilder.Entity<ProdPriceBu>().Property(p => p.CurrencyCd).HasColumnName("CURRENCY_CD");
            modelBuilder.Entity<ProdPriceBu>().Property(p => p.DatetimeAdded).HasColumnName("DATETIME_ADDED");
            modelBuilder.Entity<ProdPriceBu>().Property(p => p.LastMaintOprid).HasColumnName("LAST_MAINT_OPRID");
            modelBuilder.Entity<ProdPriceBu>().Property(p => p.Lastupddttm).HasColumnName("LASTUPDDTTM");
            modelBuilder.Entity<ProdPriceBu>().Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            modelBuilder.Entity<ProdPriceBu>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<ProdPriceBu>().Property(p => p.UnitOfMeasure).HasColumnName("UNIT_OF_MEASURE");
        }

        /// <summary>
        ///             This method maps the ProductAttributes class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProductAttributes(DbModelBuilder modelBuilder)
        {
            // Map the ProductFormats class to the PS_PRODUCT_ATTRIBUTES table
            modelBuilder.Entity<ProductAttributes>()
                .HasKey(p => new
                {
                    p.SetId,
                    p.ProductId,
                    p.AttributeType,
                    p.AttributeValue
                })
                .ToTable("PS_PRODUCT_ATTRIBUTES");

            // Map each column
            modelBuilder.Entity<ProductAttributes>().Property(p => p.SetId).HasColumnName("SETID");
            modelBuilder.Entity<ProductAttributes>().Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            modelBuilder.Entity<ProductAttributes>().Property(p => p.AttributeType).HasColumnName("ATTRIBUTE_TYPE");
            modelBuilder.Entity<ProductAttributes>().Property(p => p.AttributeValue).HasColumnName("ATTRIBUTE_VALUE");
            modelBuilder.Entity<ProductAttributes>().Property(p => p.UserId).HasColumnName("USER_ID");
            modelBuilder.Entity<ProductAttributes>().Property(p => p.TimeStamp).HasColumnName("TIMESTAMP");
        }

        /// <summary>
        ///             This method maps the ProductAttributeTypes class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProductAttributeTypes(DbModelBuilder modelBuilder)
        {
            // Map the ProductFormats class to the PS_PRODUCT_ATTRIBUTE_TYPES table
            modelBuilder.Entity<ProductAttributeTypes>()
                .HasKey(p => new
                {
                    p.AttributeType
                })
                .ToTable("PS_PRODUCT_ATTRIBUTE_TYPES");

            // Map each column
            modelBuilder.Entity<ProductAttributeTypes>().Property(p => p.AttributeType).HasColumnName("ATTRIBUTE_TYPE");
        }

        /// <summary>
        ///             This method maps the ProductFormats class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProductFormats(DbModelBuilder modelBuilder)
        {
            // Map the ProductFormats class to the PS_PRODUCT_FORMATS table
            modelBuilder.Entity<ProductFormats>()
                .HasKey(p => new
                {
                    p.ProdFormat,
                    p.ProdGroup,
                    p.ProdLine
                })
                .ToTable("PS_PRODUCT_FORMATS");

            // Map each column
            modelBuilder.Entity<ProductFormats>().Property(p => p.IncludeInCatalog).HasColumnName("INCLUDE_IN_CATALOG");
            modelBuilder.Entity<ProductFormats>().Property(p => p.ProdFormat).HasColumnName("PROD_FORMAT");
            modelBuilder.Entity<ProductFormats>().Property(p => p.ProdGroup).HasColumnName("PROD_GROUP");
            modelBuilder.Entity<ProductFormats>().Property(p => p.ProdLine).HasColumnName("PROD_LINE");
        }

        /// <summary>
        ///             This method maps the ProductGroups class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProductGroups(DbModelBuilder modelBuilder)
        {
            // Map the ProductGroups class to the PS_ASSET_ITEM_ATTR table
            modelBuilder.Entity<ProductGroups>()
                .HasKey(p => new
                {
                    p.ProdGroup
                })
                .ToTable("PS_PRODUCT_GROUPS");

            // Map each column
            modelBuilder.Entity<ProductGroups>().Property(p => p.IncludeInCatalog).HasColumnName("INCLUDE_IN_CATALOG");
            modelBuilder.Entity<ProductGroups>().Property(p => p.ProdGroup).HasColumnName("PROD_GROUP");

        }

        /// <summary>
        ///             This method maps the ProductLines class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProductLines(DbModelBuilder modelBuilder)
        {
            // Map the ProductLines class to the PS_PRODUCT_LINES table
            modelBuilder.Entity<ProductLines>()
                .HasKey(p => new
                {
                    p.ProdGroup,
                    p.ProdLine
                })
                .ToTable("PS_PRODUCT_LINES");

            // Map each column
            modelBuilder.Entity<ProductLines>().Property(p => p.IncludeInCatalog).HasColumnName("INCLUDE_IN_CATALOG");
            modelBuilder.Entity<ProductLines>().Property(p => p.ProdGroup).HasColumnName("PROD_GROUP");
            modelBuilder.Entity<ProductLines>().Property(p => p.ProdLine).HasColumnName("PROD_LINE");

        }

        /// <summary>
        ///             This method maps the ProductVariations class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProductVariations(DbModelBuilder modelBuilder)
        {
            // Map the ProductLines class to the PS_PRODUCT_VARIATIONS table
            modelBuilder.Entity<ProductVariations>()
                .HasKey(p => new
                {
                    p.ProductId,
                    p.SetId,
                    p.CustId
                })
                .ToTable("PS_PRODUCT_VARIATIONS");

            // Map each column
            modelBuilder.Entity<ProductVariations>().Property(p => p.CustId).HasColumnName("CUST_ID");
            modelBuilder.Entity<ProductVariations>().Property(p => p.DttmCreated).HasColumnName("DTTM_CREATED");
            modelBuilder.Entity<ProductVariations>().Property(p => p.DttmUpdated).HasColumnName("DTTM_LAST_UPDATED");
            modelBuilder.Entity<ProductVariations>().Property(p => p.ExternalParentId).HasColumnName("EXTERNAL_PARENT_ID");
            modelBuilder.Entity<ProductVariations>().Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            modelBuilder.Entity<ProductVariations>().Property(p => p.SetId).HasColumnName("SETID");
            modelBuilder.Entity<ProductVariations>().Property(p => p.VariationGroupId).HasColumnName("VARIATION_GROUP_ID");
            modelBuilder.Entity<ProductVariations>().Property(p => p.VariationProductCategory).HasColumnName("VARIATION_PRODUCT_CATEGORY");

        }

        /// <summary>
        ///             This method maps the ProdUom class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapProdUom(DbModelBuilder modelBuilder)
        {
            // Map the ProdUom class to the PS_PROD_UOM table
            modelBuilder.Entity<ProdUom>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.ProductId
                })
                .ToTable("PS_PROD_UOM");

            // Map each column
            modelBuilder.Entity<ProdUom>().Property(p => p.DatetimeAdded).HasColumnName("DATETIME_ADDED");
            modelBuilder.Entity<ProdUom>().Property(p => p.DfltUom).HasColumnName("DFLT_UOM");
            modelBuilder.Entity<ProdUom>().Property(p => p.LastMaintOprid).HasColumnName("LAST_MAINT_OPRID");
            modelBuilder.Entity<ProdUom>().Property(p => p.Lastupddttm).HasColumnName("LASTUPDDTTM");
            modelBuilder.Entity<ProdUom>().Property(p => p.MaxOrderQty).HasColumnName("MAX_ORDER_QTY");
            modelBuilder.Entity<ProdUom>().Property(p => p.MinOrderQty).HasColumnName("MIN_ORDER_QTY");
            modelBuilder.Entity<ProdUom>().Property(p => p.OrderIncrement).HasColumnName("ORDER_INCREMENT");
            modelBuilder.Entity<ProdUom>().Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            modelBuilder.Entity<ProdUom>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<ProdUom>().Property(p => p.UnitOfMeasure).HasColumnName("UNIT_OF_MEASURE");

        }

        /// <summary>
        ///             This method maps the PurchItemAttr class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapPurchItemAttr(DbModelBuilder modelBuilder)
        {
            // Map the PurchItemAttr class to the PS_PURCH_ITEM_ATTR table
            modelBuilder.Entity<PurchItemAttr>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId
                })
                .ToTable("PS_PURCH_ITEM_ATTR");

            // Map each column
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.AcceptAllShipto).HasColumnName("ACCEPT_ALL_SHIPTO");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.AcceptAllVendor).HasColumnName("ACCEPT_ALL_VENDOR");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Account).HasColumnName("ACCOUNT");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Affiliate).HasColumnName("AFFILIATE");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.AffiliateIntra1).HasColumnName("AFFILIATE_INTRA1");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.AffiliateIntra2).HasColumnName("AFFILIATE_INTRA2");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Altacct).HasColumnName("ALTACCT");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.AutoSource).HasColumnName("AUTO_SOURCE");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.AvailAllRgns).HasColumnName("AVAIL_ALL_RGNS");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.BudgetRef).HasColumnName("BUDGET_REF");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Chartfield1).HasColumnName("CHARTFIELD1");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Chartfield2).HasColumnName("CHARTFIELD2");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Chartfield3).HasColumnName("CHARTFIELD3");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.ClassFld).HasColumnName("CLASS_FLD");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.ContractReq).HasColumnName("CONTRACT_REQ");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.CurrencyCd).HasColumnName("CURRENCY_CD");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Deptid).HasColumnName("DEPTID");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Descr).HasColumnName("DESCR");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Descr254Mixed).HasColumnName("DESCR254_MIXED");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Descrshort).HasColumnName("DESCRSHORT");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.ExtPrcTol).HasColumnName("EXT_PRC_TOL");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.ExtPrcTolL).HasColumnName("EXT_PRC_TOL_L");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.FileExtension).HasColumnName("FILE_EXTENSION");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Filename).HasColumnName("FILENAME");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.FundCode).HasColumnName("FUND_CODE");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.InspectCd).HasColumnName("INSPECT_CD");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.InspectSamplePer).HasColumnName("INSPECT_SAMPLE_PER");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.InspectUomType).HasColumnName("INSPECT_UOM_TYPE");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.KbOvrRecvTol).HasColumnName("KB_OVR_RECV_TOL");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.KbPastDuePo).HasColumnName("KB_PAST_DUE_PO");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.LastDttmUpdate).HasColumnName("LAST_DTTM_UPDATE");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.LastPoPricePaid).HasColumnName("LAST_PO_PRICE_PAID");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.LeadTimeImp).HasColumnName("LEAD_TIME_IMP");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Model).HasColumnName("MODEL");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.OperatingUnit).HasColumnName("OPERATING_UNIT");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.OpridModifiedBy).HasColumnName("OPRID_MODIFIED_BY");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PackingVolume).HasColumnName("PACKING_VOLUME");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PackingWeight).HasColumnName("PACKING_WEIGHT");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PctExtPrcTol).HasColumnName("PCT_EXT_PRC_TOL");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PctExtPrcTolL).HasColumnName("PCT_EXT_PRC_TOL_L");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PctUnderQty).HasColumnName("PCT_UNDER_QTY");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PctUnitPrcTol).HasColumnName("PCT_UNIT_PRC_TOL");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PctUnitPrcTolL).HasColumnName("PCT_UNIT_PRC_TOL_L");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PoAvailDt).HasColumnName("PO_AVAIL_DT");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PoUnavailDt).HasColumnName("PO_UNAVAIL_DT");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PriceImp).HasColumnName("PRICE_IMP");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PriceList).HasColumnName("PRICE_LIST");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.PrimaryBuyer).HasColumnName("PRIMARY_BUYER");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Product).HasColumnName("PRODUCT");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.ProgramCode).HasColumnName("PROGRAM_CODE");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.ProjectId).HasColumnName("PROJECT_ID");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.QtyRecvTolPct).HasColumnName("QTY_RECV_TOL_PCT");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.RecvPartialFlg).HasColumnName("RECV_PARTIAL_FLG");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.RecvReq).HasColumnName("RECV_REQ");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.RejectDays).HasColumnName("REJECT_DAYS");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.RfqReqFlag).HasColumnName("RFQ_REQ_FLAG");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.RjctOverTolFlag).HasColumnName("RJCT_OVER_TOL_FLAG");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.RoutingId).HasColumnName("ROUTING_ID");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.ShipLateDays).HasColumnName("SHIP_LATE_DAYS");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.ShipTypeId).HasColumnName("SHIP_TYPE_ID");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.ShiptoPrImp).HasColumnName("SHIPTO_PR_IMP");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.SrcMethod).HasColumnName("SRC_METHOD");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.StdLead).HasColumnName("STD_LEAD");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.StocklessFlg).HasColumnName("STOCKLESS_FLG");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.TaxableCd).HasColumnName("TAXABLE_CD");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.UltimateUseCd).HasColumnName("ULTIMATE_USE_CD");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.UnitMeasureVol).HasColumnName("UNIT_MEASURE_VOL");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.UnitMeasureWt).HasColumnName("UNIT_MEASURE_WT");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.UnitPrcTol).HasColumnName("UNIT_PRC_TOL");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.UnitPrcTolL).HasColumnName("UNIT_PRC_TOL_L");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.UseCatSrcCntl).HasColumnName("USE_CAT_SRC_CNTL");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.VatSvcPerfrmFlg).HasColumnName("VAT_SVC_PERFRM_FLG");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.VndrPrImp).HasColumnName("VNDR_PR_IMP");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.WfPctPrcTolOvr).HasColumnName("WF_PCT_PRC_TOL_OVR");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.WfPctPrcTolUnd).HasColumnName("WF_PCT_PRC_TOL_UND");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.WfPrcTolOvr).HasColumnName("WF_PRC_TOL_OVR");
            modelBuilder.Entity<PurchItemAttr>().Property(p => p.WfPrcTolUnd).HasColumnName("WF_PRC_TOL_UND");

        }

        /// <summary>
        ///             This method maps the PurchItemBu class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapPurchItemBu(DbModelBuilder modelBuilder)
        {
            // Map the PurchItemBu class to the PS_PURCH_ITEM_BU table
            modelBuilder.Entity<PurchItemBu>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId,
                    p.BusinessUnit
                })
                .ToTable("PS_PURCH_ITEM_BU");

            // Map each column
            modelBuilder.Entity<PurchItemBu>().Property(p => p.AcceptAllShipto).HasColumnName("ACCEPT_ALL_SHIPTO");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.AcceptAllVendor).HasColumnName("ACCEPT_ALL_VENDOR");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.Account).HasColumnName("ACCOUNT");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.Affiliate).HasColumnName("AFFILIATE");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.AffiliateIntra1).HasColumnName("AFFILIATE_INTRA1");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.AffiliateIntra2).HasColumnName("AFFILIATE_INTRA2");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.Altacct).HasColumnName("ALTACCT");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.AutoSource).HasColumnName("AUTO_SOURCE");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.BuUpdPrice).HasColumnName("BU_UPD_PRICE");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.BudgetRef).HasColumnName("BUDGET_REF");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.Chartfield1).HasColumnName("CHARTFIELD1");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.Chartfield2).HasColumnName("CHARTFIELD2");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.Chartfield3).HasColumnName("CHARTFIELD3");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.ClassFld).HasColumnName("CLASS_FLD");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.ContractReq).HasColumnName("CONTRACT_REQ");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.CurrencyCd).HasColumnName("CURRENCY_CD");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.Deptid).HasColumnName("DEPTID");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.ExtPrcTol).HasColumnName("EXT_PRC_TOL");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.ExtPrcTolL).HasColumnName("EXT_PRC_TOL_L");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.FundCode).HasColumnName("FUND_CODE");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.InspectCd).HasColumnName("INSPECT_CD");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.InspectSamplePer).HasColumnName("INSPECT_SAMPLE_PER");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.InspectUomType).HasColumnName("INSPECT_UOM_TYPE");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.KbOvrRecvTol).HasColumnName("KB_OVR_RECV_TOL");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.KbPastDuePo).HasColumnName("KB_PAST_DUE_PO");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.LastDttmUpdate).HasColumnName("LAST_DTTM_UPDATE");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.LastPoPricePaid).HasColumnName("LAST_PO_PRICE_PAID");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.OperatingUnit).HasColumnName("OPERATING_UNIT");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.OpridModifiedBy).HasColumnName("OPRID_MODIFIED_BY");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.PackingVolume).HasColumnName("PACKING_VOLUME");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.PackingWeight).HasColumnName("PACKING_WEIGHT");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.PctExtPrcTol).HasColumnName("PCT_EXT_PRC_TOL");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.PctExtPrcTolL).HasColumnName("PCT_EXT_PRC_TOL_L");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.PctUnderQty).HasColumnName("PCT_UNDER_QTY");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.PctUnitPrcTol).HasColumnName("PCT_UNIT_PRC_TOL");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.PctUnitPrcTolL).HasColumnName("PCT_UNIT_PRC_TOL_L");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.PriceList).HasColumnName("PRICE_LIST");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.PrimaryBuyer).HasColumnName("PRIMARY_BUYER");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.Product).HasColumnName("PRODUCT");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.ProgramCode).HasColumnName("PROGRAM_CODE");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.ProjectId).HasColumnName("PROJECT_ID");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.QtyRecvTolPct).HasColumnName("QTY_RECV_TOL_PCT");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.RecvPartialFlg).HasColumnName("RECV_PARTIAL_FLG");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.RecvReq).HasColumnName("RECV_REQ");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.RejectDays).HasColumnName("REJECT_DAYS");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.RfqReqFlag).HasColumnName("RFQ_REQ_FLAG");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.RjctOverTolFlag).HasColumnName("RJCT_OVER_TOL_FLAG");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.RoutingId).HasColumnName("ROUTING_ID");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.ShipLateDays).HasColumnName("SHIP_LATE_DAYS");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.ShipTypeId).HasColumnName("SHIP_TYPE_ID");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.StdLead).HasColumnName("STD_LEAD");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.StocklessFlg).HasColumnName("STOCKLESS_FLG");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.TaxableCd).HasColumnName("TAXABLE_CD");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.UltimateUseCd).HasColumnName("ULTIMATE_USE_CD");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.UnitMeasureVol).HasColumnName("UNIT_MEASURE_VOL");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.UnitMeasureWt).HasColumnName("UNIT_MEASURE_WT");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.UnitPrcTol).HasColumnName("UNIT_PRC_TOL");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.UnitPrcTolL).HasColumnName("UNIT_PRC_TOL_L");
            modelBuilder.Entity<PurchItemBu>().Property(p => p.VatSvcPerfrmFlg).HasColumnName("VAT_SVC_PERFRM_FLG");

        }

        /// <summary>
        ///             This method maps the PvItmCategory class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapPvItmCategory(DbModelBuilder modelBuilder)
        {
            // Map the PvItmCategory class to the PS_PV_ITM_CATEGORY table
            modelBuilder.Entity<PvItmCategory>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId,
                    p.CategoryId
                })
                .ToTable("PS_PV_ITM_CATEGORY");

            // Map each column
            modelBuilder.Entity<PvItmCategory>().Property(p => p.CategoryId).HasColumnName("CATEGORY_ID");
            modelBuilder.Entity<PvItmCategory>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<PvItmCategory>().Property(p => p.PvPreferredCat).HasColumnName("PV_PREFERRED_CAT");
            modelBuilder.Entity<PvItmCategory>().Property(p => p.Setid).HasColumnName("SETID");

        }

        /// <summary>
        ///     This method maps the StatsCodes class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///     The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapStatsCodes(DbModelBuilder modelBuilder)
        {
            // Map the StatsCodes class to the PS_T_STATS_CODES table
            modelBuilder.Entity<StatsCodes>()
                .HasKey(p => new
                {
                    p.StatsCode
                })
                .ToTable("PS_T_STATS_CODES");

            // Map each column
            modelBuilder.Entity<StatsCodes>().Property(p => p.BrandName).HasColumnName("BRAND_NAME");
            modelBuilder.Entity<StatsCodes>().Property(p => p.DttmCreated).HasColumnName("DTTM_CREATED");
            modelBuilder.Entity<StatsCodes>().Property(p => p.DttmModified).HasColumnName("DTTM_MODIFIED");
            modelBuilder.Entity<StatsCodes>().Property(p => p.Gln).HasColumnName("GLN");
            modelBuilder.Entity<StatsCodes>().Property(p => p.LastMaintOprid).HasColumnName("LAST_MAINT_OPRID");
            modelBuilder.Entity<StatsCodes>().Property(p => p.StatsCode).HasColumnName("STATS_CODE");
        }

        /// <summary>
        ///             This method maps the SfPrdnAreaIt class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapSfPrdnAreaIt(DbModelBuilder modelBuilder)
        {
            // Map the SfPrdnAreaIt class to the PS_SF_PRDN_AREA_IT table
            modelBuilder.Entity<SfPrdnAreaIt>()
                .HasKey(p => new
                {
                    p.BusinessUnit,
                    p.PrdnAreaCode,
                    p.InvItemId,
                    p.BomCode,
                    p.RtgCode,
                    p.DateInEffect
                })
                .ToTable("PS_SF_PRDN_AREA_IT");

            // Map each column
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.BegSeq).HasColumnName("BEG_SEQ");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.BomCode).HasColumnName("BOM_CODE");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.BusinessUnit).HasColumnName("BUSINESS_UNIT");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.DateInEffect).HasColumnName("DATE_IN_EFFECT");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.IssueMethod).HasColumnName("ISSUE_METHOD");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.LockBomRtgFlg).HasColumnName("LOCK_BOM_RTG_FLG");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.MaPrdnIdFlg).HasColumnName("MA_PRDN_ID_FLG");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.NetChangeEp).HasColumnName("NET_CHANGE_EP");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.NetChangeFlg).HasColumnName("NET_CHANGE_FLG");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.PaItPriority).HasColumnName("PA_IT_PRIORITY");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.PaItStatus).HasColumnName("PA_IT_STATUS");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.Percentage).HasColumnName("PERCENTAGE");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.PrdnAreaCode).HasColumnName("PRDN_AREA_CODE");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.PrdnAreaItemTxt).IsOptional().HasColumnName("PRDN_AREA_ITEM_TXT");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.PrdnRateQty).HasColumnName("PRDN_RATE_QTY");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.PrdnSchDefnFlg).HasColumnName("PRDN_SCH_DEFN_FLG");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.PrimaryFlg).HasColumnName("PRIMARY_FLG");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.Revision).HasColumnName("REVISION");
            modelBuilder.Entity<SfPrdnAreaIt>().Property(p => p.RtgCode).HasColumnName("RTG_CODE");


        }

        /// <summary>
        ///             This method maps the UomTypeInv class to the database.
        /// </summary>
        /// 
        /// <param name="DbModelBuilder modelBuilder">
        ///             The DbDbModelBuilder modelBuilder to update with the mapping.
        /// </param>
        private void MapUomTypeInv(DbModelBuilder modelBuilder)
        {
            // Map the UomTypeInv class to the PS_UOM_TYPE_INV table
            modelBuilder.Entity<UomTypeInv>()
                .HasKey(p => new
                {
                    p.Setid,
                    p.InvItemId,
                    p.UnitOfMeasure,
                    p.InvUomType
                })
                .ToTable("PS_UOM_TYPE_INV");

            // Map each column
            modelBuilder.Entity<UomTypeInv>().Property(p => p.InvItemId).HasColumnName("INV_ITEM_ID");
            modelBuilder.Entity<UomTypeInv>().Property(p => p.InvUomType).HasColumnName("INV_UOM_TYPE");
            modelBuilder.Entity<UomTypeInv>().Property(p => p.Setid).HasColumnName("SETID");
            modelBuilder.Entity<UomTypeInv>().Property(p => p.UnitOfMeasure).HasColumnName("UNIT_OF_MEASURE");
        }

        #endregion  // Private Methods
    }
    
}
