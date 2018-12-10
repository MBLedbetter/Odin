using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Odin.Data
{
    public class TestTemplateRepository : ITemplateRepository
    {
        #region Private Test Properties

        /// <summary>
        ///     Gets or sets the TestTemplateCollection
        /// </summary>
        private ObservableCollection<ItemObject> TestTemplateCollection
        {
            get { return _testTemplateCollection; }
            set { _testTemplateCollection = value; }
        }
        private ObservableCollection<ItemObject> _testTemplateCollection = new ObservableCollection<ItemObject>();

        #endregion // Private Test Properties

        #region Private Test Methods

        /// <summary>
        ///     Populates the Test Template collection
        /// </summary>
        private void SetTestTemplates()
        {
            ItemObject template = new ItemObject();
            template.TemplateId = "TemplateId1";
            template.AccountingGroup = "TemplateAccountingGroup1";
            template.CasepackHeight = "TemplateCasepackHeight1";
            template.CasepackLength = "TemplateCasepackLength1";
            template.CasepackQty = "TemplateCasepackQty1";
            template.CasepackWidth = "TemplateCasepackWidth1";
            template.CasepackWeight = "TemplateCasepackWeight1";
            template.Category = "TemplateCategory1";
            template.Category2 = "TemplateCategory21";
            template.Category3 = "TemplateCategory31";
            template.Copyright = "TemplateCopyright1";
            template.CostProfileGroup = "TemplateCostProfileGroup1";
            template.DefaultActualCostCad = "TemplateDefaultActualCostCad1";
            template.DefaultActualCostUsd = "TemplateDefaultActualCostUsd1";
            template.Duty = "TemplateDuty1";
            template.Gpc = "TemplateGpc1";
            template.Height = "TemplateHeight1";
            template.InnerpackHeight = "TemplateInnerpackHeight1";
            template.InnerpackLength = "TemplateInnerpackLength1";
            template.InnerpackQuantity = "TemplateInnerpackQuantity1";
            template.InnerpackWeight = "TemplateInnerpackWeight1";
            template.InnerpackWidth = "TemplateInnerpackWidth1";
            template.ItemCategory = "TemplateItemCategory1";
            template.ItemFamily = "TemplateItemFamily1";
            template.ItemGroup = "TemplateItemGroup1";
            template.Length = "TemplateLength1";
            template.ListPriceCad = "TemplateListPriceCad1";
            template.ListPriceMxn = "TemplateListPriceMxn1";
            template.ListPriceUsd = "TemplateListPriceUsd1";
            template.MetaDescription = "TemplateMetaDescription1";
            template.MfgSource = "TemplateMfgSource1";
            template.Msrp = "TemplateMsrp1";
            template.MsrpCad = "TemplateMsrpCad1";
            template.MsrpMxn = "TemplateMsrpMxn1";
            template.PrintOnDemand = "TemplatePrintOnDemand1";
            template.ProductGroup = "TemplateProductGroup1";
            template.ProductLine = "TemplateProductLine1";
            template.ProductFormat = "TemplateProductFormat1";
            template.ProductQty = "TemplateProductQty1";
            template.PricingGroup = "TemplatePricingGroup1";
            template.PsStatus = "TemplatePsStatus1";
            template.SatCode = "TemplateSatCode1";
            template.Size = "TemplateSize1";
            template.TariffCode = "TemplateTariffCode1";
            template.Udex = "TemplateUdex1";
            template.Weight = "TemplateWeight1";
            template.Width = "TemplateWidth1";
            template.EcommerceBullet1 = "TemplateEcommerceBullet11";
            template.EcommerceBullet2 = "TemplateEcommerceBullet21";
            template.EcommerceBullet3 = "TemplateEcommerceBullet31";
            template.EcommerceBullet4 = "TemplateEcommerceBullet41";
            template.EcommerceBullet5 = "TemplateEcommerceBullet51";
            template.EcommerceComponents = "TemplateEcommerceComponents1";
            template.EcommerceCost = "TemplateEcommerceCost1";
            template.EcommerceExternalIdType = "TemplateEcommerceExternalIdType1";
            template.EcommerceItemHeight = "TemplateEcommerceItemHeight1";
            template.EcommerceItemLength = "TemplateEcommerceItemLength1";
            template.EcommerceItemWeight = "TemplateEcommerceItemWeight1";
            template.EcommerceItemWidth = "TemplateEcommerceItemWidth1";
            template.EcommerceModelName = "TemplateEcommerceModelName1";
            template.EcommercePackageLength = "TemplateEcommercePackageLength1";
            template.EcommercePackageHeight = "TemplateEcommercePackageHeight1";
            template.EcommercePackageWeight = "TemplateEcommercePackageWeight1";
            template.EcommercePackageWidth = "TemplateEcommercePackageWidth1";
            template.EcommercePageQty = "TemplateEcommercePageQty1";
            template.EcommerceProductCategory = "TemplateEcommerceProductCategory1";
            template.EcommerceProductDescription = "TemplateEcommerceProductDescription1";
            template.EcommerceProductSubcategory = "TemplateEcommerceProductSubcategory1";
            template.EcommerceManufacturerName = "TemplateEcommerceManufacturerName1";
            template.EcommerceMsrp = "TemplateEcommerceMsrp1";
            template.EcommerceSize = "TemplateEcommerceSize1";
            this.TestTemplateCollection.Add(template);
        }
        
        /// <summary>
        ///     Runs all test populating methods
        /// </summary>
        private void SetTestValues()
        {
            SetTestTemplates();
        }

        #endregion // Private Test Methods

        #region Public Methods

        #region Public Insert Methods

        /// <summary>
        ///     Inserts a column data into EXCEL_LAYOUT_DATA
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void InsertExcelLayoutColumn(ExcelCell value, OdinContext context)
        {
        }

        /// <summary>
        ///     Runs InsertExcelLayoutColumn foreach object in the cellList
        /// </summary>
        /// <param name="cellList"></param>
        /// <returns></returns>
        public void InsertExcelLayoutColumns(ObservableCollection<ExcelCell> cellList)
        {
        }

        /// <summary>
        ///     Inserts a column data into ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <param name="layoutName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public void InsertExcelLayout(string layoutName, string customer, string productType)
        {
        }

        /// <summary>
        ///     Insert a template into the db
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public void InsertTemplate(ItemObject template)
        {
        }

        #endregion // Public Insert Methods

        #region Public Removal Methods

        /// <summary>
        ///     Removes all column data for the given layout from EXCEL_LAYOUT_DATA
        /// </summary>
        /// <param name="layoutId"></param>
        /// <returns></returns>
        public void RemoveExcelLayout(int layoutId)
        {
        }

        /// <summary>
        ///     Removes all column data for the given layout from EXCEL_LAYOUT_DATA
        /// </summary>
        /// <param name="layoutId"></param>
        /// <returns></returns>
        public void RemoveExcelLayoutColumns(int layoutId)
        {
        }

        /// <summary>
        ///     Remove the given template from ODIN_ITEM_TEMPLATES
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public void RemoveTemplate(string templateId)
        {
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
            excelCells.Add(new ExcelCell(
                             7,
                             1,
                             "Field",
                             "Option",
                             "Customer"));
            return excelCells;
        }

        /// <summary>
        ///     Retrieves the coresponding layout id for the given layout name from ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <param name="layoutName"></param>
        /// <returns></returns>
        public int RetrieveExcelLayoutId(string layoutName)
        {
            return 7;
        }

        /// <summary>
        ///     Retrieves a list of existing excel layout names from ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <returns></returns>
        public List<Layout> RetrieveExcelLayouts()
        {
            List<Layout> excelLayouts = new List<Layout>();
            return excelLayouts;
        }

        /// <summary>
        ///     Retrieves a list of available field values from ODIN_FIELD_VALUES
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveFieldValues()
        {
            List<string> fieldValues = new List<string>();
            fieldValues.Add("FieldValue1");
            fieldValues.Add("FieldValue2");
            fieldValues.Add("FieldValue3");
            return fieldValues;
        }

        /// <summary>
        ///     Retrieve a List of names for all existing templates
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveTemplateNameList()
        {
            List<string> results = new List<string>();
            results.Add("TemplateName1");
            results.Add("TemplateName2");
            results.Add("TemplateName3");
            return results;
        }

        /// <summary>
        ///     Retrieves a template from the db
        /// </summary>
        /// <returns></returns>
        public ItemObject RetrieveTemplate(string templateId)
        {
            foreach(ItemObject template in this.TestTemplateCollection)
            {
                if(template.TemplateId == templateId)
                {
                    return template;
                }
            }
            return new ItemObject();
        }

        #endregion // Public Retrieval Methods

        #region Public Update Methods

        /// <summary>
        ///     Updates an existing template
        /// </summary>
        /// <returns></returns>
        public void UpdateTemplate(ItemObject template, string status)
        {
        }

        #endregion // Public Update Methods

        #endregion // Public Methods

        #region Constructor

        /// <summary>
        ///     Constructs the TestTemplateRepository
        /// </summary>
        public TestTemplateRepository()
        {
            SetTestValues();
        }

        #endregion // Constructor
    }
}
