using Odin.DbTableModels;
using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Odin.Data
{
    public class TemplateRepository : ITemplateRepository
    {
        #region Fields

        private readonly IOdinContextFactory contextFactory;

        #endregion // Fields

        #region Public Methods

        #region Public Insert Methods

        /// <summary>
        ///     Runs InsertExcelLayoutColumn foreach object in the cellList
        /// </summary>
        /// <param name="cellList"></param>
        /// <returns></returns>
        public void InsertExcelLayoutColumns(ObservableCollection<ExcelCell> cellList)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (ExcelCell cell in cellList)
                {
                    InsertExcelLayoutColumn(cell, context);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        ///     Inserts a column data into ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <param name="layoutName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public void InsertExcelLayout(string layoutName, string customer, string productType)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                context.OdinExcelLayoutIds.Add(new OdinExcelLayoutIds
                {
                    LayoutName = layoutName,
                    Customer = customer,
                    ProductType = productType
                });
                context.SaveChanges();
            }
        }

        /// <summary>
        ///     Insert a template into the db
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public void InsertTemplate(ItemObject template)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                context.OdinItemTemplates.Add(new OdinItemTemplates
                {
                    TemplateId = template.TemplateId,
                    Username = GlobalData.UserName,
                    InputDate = DateTime.Now,
                    AccountingGroup = template.AccountingGroup,
                    CasepackHeight = template.CasepackHeight,
                    CasepackLength = template.CasepackLength,
                    CasepackQty = template.CasepackQty,
                    CasepackWidth = template.CasepackWidth,
                    CasepackWeight = template.CasepackWeight,
                    Category = template.Category,
                    Category2 = template.Category2,
                    Category3 = template.Category3,
                    Copyright = template.Copyright,
                    CostProfileGroup = template.CostProfileGroup,
                    DefaultActualCostUsd = template.DefaultActualCostUsd,
                    DefaultActualCostCad = template.DefaultActualCostCad,
                    DtcPrice = template.DtcPrice,
                    Duty = template.Duty,
                    Gpc = template.Gpc,
                    Height = template.Height,
                    InnerpackHeight = template.InnerpackHeight,
                    InnerpackLength = template.InnerpackLength,
                    InnerpackQty = template.InnerpackQuantity,
                    InnerpackWidth = template.InnerpackWidth,
                    InnerpackWeight = template.InnerpackWeight,
                    ItemCategory = template.ItemCategory,
                    ItemFamily = template.ItemFamily,
                    ItemGroup = template.ItemGroup,
                    Length = template.Length,
                    ListPriceCad = template.ListPriceCad,
                    ListPriceUsd = template.ListPriceUsd,
                    ListPriceMxn = template.ListPriceMxn,
                    MetaDescription = template.MetaDescription,
                    MfgSource = template.MfgSource,
                    Msrp = template.Msrp,
                    MsrpCad = template.MsrpCad,
                    MsrpMxn = template.MsrpMxn,
                    PrintOnDemand = template.PrintOnDemand,
                    ProductFormat = template.ProductFormat,
                    ProductGroup = template.ProductGroup,
                    ProductLine = template.ProductLine,
                    ProdQty = template.ProductQty,
                    PricingGroup = template.PricingGroup,
                    PsStatus = template.PsStatus,
                    SatCode = template.SatCode,
                    Size = template.Size,
                    TariffCode = template.TariffCode,
                    Udex = template.Udex,
                    WebsitePrice = template.WebsitePrice,
                    Weight = template.Weight,
                    Width = template.Width,
                    EcommerceBullet1 = template.EcommerceBullet1,
                    EcommerceBullet2 = template.EcommerceBullet2,
                    EcommerceBullet3 = template.EcommerceBullet3,
                    EcommerceBullet4 = template.EcommerceBullet4,
                    EcommerceBullet5 = template.EcommerceBullet5,
                    EcommerceComponents = template.EcommerceComponents,
                    EcommerceCost = template.EcommerceCost,
                    EcommerceExternalIdType = template.EcommerceExternalIdType,
                    EcommerceItemHeight = template.EcommerceItemHeight,
                    EcommerceItemLength = template.EcommerceItemLength,
                    EcommerceItemTypeKeywords = template.EcommerceItemTypeKeywords,
                    EcommerceItemWeight = template.EcommerceItemWeight,
                    EcommerceItemWidth = template.EcommerceItemWidth,
                    EcommerceModelName = template.EcommerceModelName,
                    EcommercePackageLength = template.EcommercePackageLength,
                    EcommercePackageHeight = template.EcommercePackageHeight,
                    EcommercePackageWeight = template.EcommercePackageWeight,
                    EcommercePackageWidth = template.EcommercePackageWidth,
                    EcommercePageCount = template.EcommercePageQty,
                    EcommerceProductCategory = template.EcommerceProductCategory,
                    EcommerceProductDescription = template.EcommerceProductDescription,
                    EcommerceProductSubcategory = template.EcommerceProductSubcategory,
                    EcommerceManufacturerName = template.EcommerceManufacturerName,
                    EcommerceMsrp = template.EcommerceMsrp,
                    EcommerceSize = template.EcommerceSize,
                    Warranty = template.Warranty
                });
                context.SaveChanges();
            }
        }

        #endregion // Public Insert Methods

        #region Public Removal Methods

        /// <summary>
        ///     Removes data from  EXCEL_LAYOUT_IDS for given layout ID
        /// </summary>
        /// <param name="layoutId"></param>
        /// <returns></returns>
        public void RemoveExcelLayout(int layoutId)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (OdinExcelLayoutIds odinExcelLayoutids in (from o in context.OdinExcelLayoutIds where o.LayoutId == layoutId select o))
                {
                    context.OdinExcelLayoutIds.Remove(odinExcelLayoutids);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        ///     Removes all column data for the given layout from EXCEL_LAYOUT_DATA
        /// </summary>
        /// <param name="layoutId"></param>
        /// <returns></returns>
        public void RemoveExcelLayoutColumns(int layoutId)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (OdinExcelLayoutData odinExcelLayoutData in (from o in context.OdinExcelLayoutData where o.LayoutId == layoutId select o))
                {
                    context.OdinExcelLayoutData.Remove(odinExcelLayoutData);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        ///     Remove the given template from ODIN_ITEM_TEMPLATES
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public void RemoveTemplate(string templateId)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (OdinItemTemplates odinItemTemplates in (from o in context.OdinItemTemplates where o.TemplateId == templateId select o))
                {
                    context.OdinItemTemplates.Remove(odinItemTemplates);
                }
                context.SaveChanges();
            }
        }

        #endregion // Public Removal Methods

        #region Public Retrieval Methods

        /// <summary>
        ///     Retrieves a list of excel columns from ODIN_EXCEL_LAYOUT_DATA
        /// </summary>
        /// <param name="layoutName"></param>
        /// <returns></returns>
        public ObservableCollection<ExcelCell> RetrieveExcelLayoutData(string layoutName)
        {
            ObservableCollection<ExcelCell> excelCells = new ObservableCollection<ExcelCell>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                var x = (from y in context.OdinExcelLayoutIds
                         join z in context.OdinExcelLayoutData 
                            on y.LayoutId equals z.LayoutId
                         where y.LayoutName == layoutName
                         orderby z.ColumnNumber ascending
                         select new
                         {
                             y.LayoutId,
                             z.ColumnNumber,
                             z.Field,
                             z.Option,
                             z.Customer

                         }).ToList();

                foreach (var y in x)
                {
                    excelCells.Add(new ExcelCell(y.LayoutId,y.ColumnNumber,y.Field,y.Option,y.Customer));
                }
            }
            return excelCells;
        }

        /// <summary>
        ///     Retrieves the coresponding layout id for the given layout name from ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <param name="layoutName"></param>
        /// <returns></returns>
        public int RetrieveExcelLayoutId(string layoutName)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                return (from o in context.OdinExcelLayoutIds where o.LayoutName == layoutName select o.LayoutId).FirstOrDefault();
            }
        }

        /// <summary>
        ///     Retrieves a list of existing excel layout names from ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <returns></returns>
        public List<Layout> RetrieveExcelLayouts()
        {
            List<Layout> excelLayouts = new List<Layout>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<OdinExcelLayoutIds> odinExcelLayoutIds = (from o in context.OdinExcelLayoutIds select o).ToList();
                foreach (OdinExcelLayoutIds x in odinExcelLayoutIds)
                {
                    if (!string.IsNullOrEmpty(x.LayoutName))
                    {
                        excelLayouts.Add(new Layout(x.LayoutName, x.LayoutId, x.Customer, x.ProductType));
                    }
                }
            }
            return excelLayouts;
        }

        /// <summary>
        ///     Retrieves a list of available field values from ODIN_FIELD_VALUES
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveFieldValues()
        {
            List<string> results = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                results = (from o in context.OdinFieldValues select o.FieldValue).ToList();
            }
            results.Sort();
            return results;
        }

        /// <summary>
        ///     Retrieve a List of names for all existing templates
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveTemplateNameList()
        {
            List<string> results = new List<string>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                results = (from o in context.OdinItemTemplates select o.TemplateId).ToList();
            }
            results.Sort();
            return results;
        }

        /// <summary>
        ///     Retrieves a template from the db
        /// </summary>
        /// <returns></returns>
        public ItemObject RetrieveTemplate(string templateId)
        {
            ItemObject template = new ItemObject(2);

            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (context.OdinItemTemplates.Any(o => o.TemplateId == templateId))
                {
                    OdinItemTemplates x = (from o in context.OdinItemTemplates where o.TemplateId == templateId select o).FirstOrDefault();

                    template.TemplateId = x.TemplateId;
                    template.AccountingGroup = (!string.IsNullOrEmpty(x.AccountingGroup)) ? x.AccountingGroup : "";
                    template.CasepackHeight = (!string.IsNullOrEmpty(x.CasepackHeight)) ? x.CasepackHeight : "";
                    template.CasepackLength = (!string.IsNullOrEmpty(x.CasepackLength)) ? x.CasepackLength : "";
                    template.CasepackQty = (!string.IsNullOrEmpty(x.CasepackQty)) ? x.CasepackQty : "";
                    template.CasepackWidth = (!string.IsNullOrEmpty(x.CasepackWidth)) ? x.CasepackWidth : "";
                    template.CasepackWeight = (!string.IsNullOrEmpty(x.CasepackWeight)) ? x.CasepackWeight : "";
                    template.Category = (!string.IsNullOrEmpty(x.Category)) ? x.Category : "";
                    template.Category2 = (!string.IsNullOrEmpty(x.Category2)) ? x.Category2 : "";
                    template.Category3 = (!string.IsNullOrEmpty(x.Category3)) ? x.Category3 : "";
                    template.Copyright = (!string.IsNullOrEmpty(x.Copyright)) ? x.Copyright : "";
                    template.CostProfileGroup = (!string.IsNullOrEmpty(x.CostProfileGroup)) ? x.CostProfileGroup : "";
                    template.DefaultActualCostCad = (!string.IsNullOrEmpty(x.DefaultActualCostCad)) ? x.DefaultActualCostCad : "";
                    template.DefaultActualCostUsd = (!string.IsNullOrEmpty(x.DefaultActualCostUsd)) ? x.DefaultActualCostUsd : "";
                    template.DtcPrice = (!string.IsNullOrEmpty(x.DtcPrice)) ? x.DtcPrice : "";
                    template.Duty = (!string.IsNullOrEmpty(x.Duty)) ? x.Duty : "";
                    template.Gpc = (!string.IsNullOrEmpty(x.Gpc)) ? x.Gpc : "";
                    template.Height = (!string.IsNullOrEmpty(x.Height)) ? x.Height : "";
                    template.InnerpackHeight = (!string.IsNullOrEmpty(x.InnerpackHeight)) ? x.InnerpackHeight : "";
                    template.InnerpackLength = (!string.IsNullOrEmpty(x.InnerpackLength)) ? x.InnerpackLength : "";
                    template.InnerpackQuantity = (!string.IsNullOrEmpty(x.InnerpackQty)) ? x.InnerpackQty : "";
                    template.InnerpackWeight = (!string.IsNullOrEmpty(x.InnerpackWeight)) ? x.InnerpackWeight : "";
                    template.InnerpackWidth = (!string.IsNullOrEmpty(x.InnerpackWidth)) ? x.InnerpackWidth : "";
                    template.ItemCategory = (!string.IsNullOrEmpty(x.ItemCategory)) ? x.ItemCategory : "";
                    template.ItemFamily = (!string.IsNullOrEmpty(x.ItemFamily)) ? x.ItemFamily : "";
                    template.ItemGroup = (!string.IsNullOrEmpty(x.ItemGroup)) ? x.ItemGroup : "";
                    template.Length = (!string.IsNullOrEmpty(x.Length)) ? x.Length : "";
                    template.ListPriceCad = (!string.IsNullOrEmpty(x.ListPriceCad)) ? x.ListPriceCad : "";
                    template.ListPriceMxn = (!string.IsNullOrEmpty(x.ListPriceMxn)) ? x.ListPriceMxn : "";
                    template.ListPriceUsd = (!string.IsNullOrEmpty(x.ListPriceUsd)) ? x.ListPriceUsd : "";
                    template.MetaDescription = (!string.IsNullOrEmpty(x.MetaDescription)) ? x.MetaDescription : "";
                    template.MfgSource = (!string.IsNullOrEmpty(x.MfgSource)) ? x.MfgSource : "";
                    template.Msrp = (!string.IsNullOrEmpty(x.Msrp)) ? x.Msrp : "";
                    template.MsrpCad = (!string.IsNullOrEmpty(x.MsrpCad)) ? x.MsrpCad : "";
                    template.MsrpMxn = (!string.IsNullOrEmpty(x.MsrpMxn)) ? x.MsrpMxn : "";
                    template.PrintOnDemand = (!string.IsNullOrEmpty(x.PrintOnDemand)) ? x.PrintOnDemand : "";
                    template.ProductGroup = (!string.IsNullOrEmpty(x.ProductGroup)) ? x.ProductGroup : "";
                    template.ProductLine = (!string.IsNullOrEmpty(x.ProductLine)) ? x.ProductLine : "";
                    template.ProductFormat = (!string.IsNullOrEmpty(x.ProductFormat)) ? x.ProductFormat : "";
                    template.ProductQty = (!string.IsNullOrEmpty(x.ProdQty)) ? x.ProdQty : "";
                    template.PricingGroup = (!string.IsNullOrEmpty(x.PricingGroup)) ? x.PricingGroup : "";
                    template.PsStatus = (!string.IsNullOrEmpty(x.PsStatus)) ? x.PsStatus : "";
                    template.SatCode = (!string.IsNullOrEmpty(x.SatCode)) ? x.SatCode : "";
                    template.Size = (!string.IsNullOrEmpty(x.Size)) ? x.Size : "";
                    template.TariffCode = (!string.IsNullOrEmpty(x.TariffCode)) ? x.TariffCode : "";
                    template.Udex = (!string.IsNullOrEmpty(x.Udex)) ? x.Udex : "";
                    template.WebsitePrice = (!string.IsNullOrEmpty(x.WebsitePrice)) ? x.WebsitePrice : "";
                    template.Weight = (!string.IsNullOrEmpty(x.Weight)) ? x.Weight : "";
                    template.Width = (!string.IsNullOrEmpty(x.Width)) ? x.Width : "";
                    template.EcommerceBullet1 = (!string.IsNullOrEmpty(x.EcommerceBullet1)) ? x.EcommerceBullet1 : "";
                    template.EcommerceBullet2 = (!string.IsNullOrEmpty(x.EcommerceBullet2)) ? x.EcommerceBullet2 : "";
                    template.EcommerceBullet3 = (!string.IsNullOrEmpty(x.EcommerceBullet3)) ? x.EcommerceBullet3 : "";
                    template.EcommerceBullet4 = (!string.IsNullOrEmpty(x.EcommerceBullet4)) ? x.EcommerceBullet4 : "";
                    template.EcommerceBullet5 = (!string.IsNullOrEmpty(x.EcommerceBullet5)) ? x.EcommerceBullet5 : "";
                    template.EcommerceComponents = (!string.IsNullOrEmpty(x.EcommerceComponents)) ? x.EcommerceComponents : "";
                    template.EcommerceCost = (!string.IsNullOrEmpty(x.EcommerceCost)) ? x.EcommerceCost : "";
                    template.EcommerceExternalIdType = (!string.IsNullOrEmpty(x.EcommerceExternalIdType)) ? x.EcommerceExternalIdType : "";
                    template.EcommerceItemHeight = (!string.IsNullOrEmpty(x.EcommerceItemHeight)) ? x.EcommerceItemHeight : "";
                    template.EcommerceItemTypeKeywords = (!string.IsNullOrEmpty(x.EcommerceItemTypeKeywords)) ? x.EcommerceItemTypeKeywords : "";
                    template.EcommerceItemLength = (!string.IsNullOrEmpty(x.EcommerceItemLength)) ? x.EcommerceItemLength : "";
                    template.EcommerceItemWeight = (!string.IsNullOrEmpty(x.EcommerceItemWeight)) ? x.EcommerceItemWeight : "";
                    template.EcommerceItemWidth = (!string.IsNullOrEmpty(x.EcommerceItemWidth)) ? x.EcommerceItemWidth : "";
                    template.EcommerceModelName = (!string.IsNullOrEmpty(x.EcommerceModelName)) ? x.EcommerceModelName : "";
                    template.EcommercePackageLength = (!string.IsNullOrEmpty(x.EcommercePackageLength)) ? x.EcommercePackageLength : "";
                    template.EcommercePackageHeight = (!string.IsNullOrEmpty(x.EcommercePackageHeight)) ? x.EcommercePackageHeight : "";
                    template.EcommercePackageWeight = (!string.IsNullOrEmpty(x.EcommercePackageWeight)) ? x.EcommercePackageWeight : "";
                    template.EcommercePackageWidth = (!string.IsNullOrEmpty(x.EcommercePackageWidth)) ? x.EcommercePackageWidth : "";
                    template.EcommercePageQty = (!string.IsNullOrEmpty(x.EcommercePageCount)) ? x.EcommercePageCount : "";
                    template.EcommerceProductCategory = (!string.IsNullOrEmpty(x.EcommerceProductCategory)) ? x.EcommerceProductCategory : "";
                    template.EcommerceProductDescription = (!string.IsNullOrEmpty(x.EcommerceProductDescription)) ? x.EcommerceProductDescription : "";
                    template.EcommerceProductSubcategory = (!string.IsNullOrEmpty(x.EcommerceProductSubcategory)) ? x.EcommerceProductSubcategory : "";
                    template.EcommerceManufacturerName = (!string.IsNullOrEmpty(x.EcommerceManufacturerName)) ? x.EcommerceManufacturerName : "";
                    template.EcommerceMsrp = (!string.IsNullOrEmpty(x.EcommerceMsrp)) ? x.EcommerceMsrp : "";
                    template.EcommerceSize = (!string.IsNullOrEmpty(x.EcommerceSize)) ? x.EcommerceSize : "";
                    template.Warranty = (!string.IsNullOrEmpty(x.Warranty)) ? x.Warranty : "";
                }
                else
                {
                    MessageBox.Show("Odin could not retrieve the selected template.");
                }
            }
            return template;
        }

        #endregion // Public Retrieval Methods

        #region Public Update Methods

        /// <summary>
        ///     Updates an existing template
        /// </summary>
        /// <returns></returns>
        public void UpdateTemplate(ItemObject template, string status)
        {
            RemoveTemplate(template.TemplateId);
            if (status != "Remove")
            {
                InsertTemplate(template);
            }
        }

        #endregion // Public Update Methods

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        ///     Inserts a column data into EXCEL_LAYOUT_DATA
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private void InsertExcelLayoutColumn(ExcelCell value, OdinContext context)
        {
            int excelId = Convert.ToInt32(value.ExcelId);
            if (!context.OdinExcelLayoutData.Any(o => o.LayoutId == excelId && o.ColumnNumber == value.ColumnNumber))
            {
                context.OdinExcelLayoutData.Add(new OdinExcelLayoutData
                {
                    LayoutId = Convert.ToInt32(value.ExcelId),
                    ColumnNumber = value.ColumnNumber,
                    Field = value.Field,
                    Option = value.Option,
                    Customer = value.Customer
                });
            }
        }
        
        #endregion // Private Methods

        #region Constructor

        /// <summary>
        ///     Constructs a Template Repository
        /// </summary>
        public TemplateRepository(IOdinContextFactory contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new ArgumentNullException("contextFactory");
            GlobalData.TemplateNames = RetrieveTemplateNameList();
        }

        #endregion // Constructor
    }
}
