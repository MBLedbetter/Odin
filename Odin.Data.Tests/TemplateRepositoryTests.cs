using System;
using LogLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Odin.DbTableModels;
using System.Linq;
using System.Collections.Generic;
using OdinModels;
using System.Collections.ObjectModel;

namespace Odin.Data.Tests
{
    [TestClass]
    public class TemplateRepositoryTests
    {

        #region Insert Tests

        /// <summary>
        ///     Tests that InsertExcelLayoutColumn inserts row data into EXCEL_LAYOUT_DATA
        /// </summary>
        [TestMethod]
        public void TemplateRepositoryTests_InsertExcelLayoutColumns_ShouldInsert()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            TemplateRepository templateRepository = new TemplateRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ObservableCollection<ExcelCell> cellList = new ObservableCollection<ExcelCell>();
            ExcelCell excelCell = new ExcelCell();
            excelCell.ExcelId = 4;
            excelCell.ColumnNumber = 7;
            excelCell.Field = "TestField";
            excelCell.Option = "TestOption";
            excelCell.Customer = "TestCustomer";
            cellList.Add(excelCell);
            ExcelCell excelCell2 = new ExcelCell();
            excelCell2.ExcelId = 4;
            excelCell2.ColumnNumber = 8;
            excelCell2.Field = "TestField2";
            excelCell2.Option = "TestOption2";
            excelCell2.Customer = "TestCustomer2";
            cellList.Add(excelCell2);

            #endregion // Assemble

            #region Act

            templateRepository.InsertExcelLayoutColumns(cellList);

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<OdinExcelLayoutData> odinExcelLayoutData = (from o in context.OdinExcelLayoutData select o).ToList();

                Assert.AreEqual("4", Convert.ToString(odinExcelLayoutData[0].LayoutId));
                Assert.AreEqual("7", Convert.ToString(odinExcelLayoutData[0].ColumnNumber));
                Assert.AreEqual("TestField", odinExcelLayoutData[0].Field);
                Assert.AreEqual("TestOption", odinExcelLayoutData[0].Option);
                Assert.AreEqual("TestCustomer", odinExcelLayoutData[0].Customer);

                Assert.AreEqual("4", Convert.ToString(odinExcelLayoutData[1].LayoutId));
                Assert.AreEqual("8", Convert.ToString(odinExcelLayoutData[1].ColumnNumber));
                Assert.AreEqual("TestField2", odinExcelLayoutData[1].Field);
                Assert.AreEqual("TestOption2", odinExcelLayoutData[1].Option);
                Assert.AreEqual("TestCustomer2", odinExcelLayoutData[1].Customer);
            }

            #endregion // Assert
        }
        
        /// <summary>
        ///     Tests that InsertExcelLayout inserts layout data into ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        [TestMethod]
        public void TemplateRepositoryTests_InsertExcelLayout_ShouldInsert()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            TemplateRepository templateRepository = new TemplateRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);

            #endregion // Assemble

            #region Act

            templateRepository.InsertExcelLayout("layoutName", "customer", "productType");

            #endregion // Act

            #region Assert
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                OdinExcelLayoutIds odinExcelLayoutIds = (from o in context.OdinExcelLayoutIds select o).FirstOrDefault();

                Assert.AreEqual(1, odinExcelLayoutIds.LayoutId);
                Assert.AreEqual("layoutName", odinExcelLayoutIds.LayoutName);
                Assert.AreEqual("customer", odinExcelLayoutIds.Customer);
                Assert.AreEqual("productType", odinExcelLayoutIds.ProductType);
            }
            #endregion // Assert
        }

        /// <summary>
        ///     Tests that InsertTemplate inserts template data into ODIN_ITEM_TEMPLATES
        /// </summary>
        [TestMethod]
        public void TemplateRepositoryTests_InsertTemplate_ShouldInsert()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            TemplateRepository templateRepository = new TemplateRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject template = new ItemObject(2);
            template.TemplateId = "TempalteId";
            template.AccountingGroup = "AG";
            template.CasepackHeight = "1";
            template.CasepackLength = "2";
            template.CasepackQty = "3";
            template.CasepackWidth = "4";
            template.CasepackWeight = "5";
            template.Category = "c1";
            template.Category2 = "c2";
            template.Category3 = "c3";
            template.Copyright = "copyright";
            template.CostProfileGroup = "cpg";
            template.DefaultActualCostUsd = "2";
            template.DefaultActualCostCad = "5";
            template.Duty = "4";
            template.Gpc = "GPC";
            template.Height = "99";
            template.InnerpackHeight = "12";
            template.InnerpackLength = "43";
            template.InnerpackQuantity = "36";
            template.InnerpackWidth = "12";
            template.InnerpackWeight = "90";
            template.ItemCategory = "IC";
            template.ItemFamily = "IF";
            template.ItemGroup = "IG";
            template.Length = "4";
            template.ListPriceCad = "4.22";
            template.ListPriceUsd = "5.14";
            template.ListPriceMxn = "8.45";
            template.MetaDescription = "MD";
            template.MfgSource = "MS";
            template.Msrp = "9.09";
            template.MsrpCad = "6.87";
            template.MsrpMxn = "3.96";
            template.PrintOnDemand = "P";
            template.ProductFormat = "PF";
            template.ProductGroup = "PG";
            template.ProductLine = "PL";
            template.ProductQty = "PQ";
            template.PricingGroup = "PG";
            template.PsStatus = "P";
            template.SatCode = "SC";
            template.Size = "Size";
            template.TariffCode = "TC";
            template.Udex = "Udex";
            template.Weight = "23";
            template.Width = "85";
            template.EcommerceBullet1 = "EB1";
            template.EcommerceBullet2 = "EB2";
            template.EcommerceBullet3 = "EB3";
            template.EcommerceBullet4 = "EB4";
            template.EcommerceBullet5 = "EB5";
            template.EcommerceComponents = "COM";
            template.EcommerceCost = "66";
            template.EcommerceExternalIdType = "EIT";
            template.EcommerceItemHeight = "3";
            template.EcommerceItemLength = "4";
            template.EcommerceItemWeight = "5";
            template.EcommerceItemWidth = "8";
            template.EcommerceModelName = "MNAME";
            template.EcommercePackageLength = "39";
            template.EcommercePackageHeight = "65";
            template.EcommercePackageWeight = "34";
            template.EcommercePackageWidth = "82";
            template.EcommercePageQty = "19";
            template.EcommerceProductCategory = "PC";
            template.EcommerceProductDescription = "PD";
            template.EcommerceProductSubcategory = "PS";
            template.EcommerceManufacturerName = "MANNAME";
            template.EcommerceMsrp = "4.34";
            template.EcommerceSize = "ESIZE";

            #endregion // Assemble

            #region Act

            templateRepository.InsertTemplate(template);

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                OdinItemTemplates odinItemTemplates = (from o in context.OdinItemTemplates select o).FirstOrDefault();
                Assert.AreEqual(odinItemTemplates.TemplateId, "TempalteId");
                Assert.AreEqual(odinItemTemplates.AccountingGroup, "AG");
                Assert.AreEqual(odinItemTemplates.CasepackHeight, "1");
                Assert.AreEqual(odinItemTemplates.CasepackLength, "2");
                Assert.AreEqual(odinItemTemplates.CasepackQty, "3");
                Assert.AreEqual(odinItemTemplates.CasepackWidth, "4");
                Assert.AreEqual(odinItemTemplates.CasepackWeight, "5");
                Assert.AreEqual(odinItemTemplates.Category, "c1");
                Assert.AreEqual(odinItemTemplates.Category2, "c2");
                Assert.AreEqual(odinItemTemplates.Category3, "c3");
                Assert.AreEqual(odinItemTemplates.Copyright, "copyright");
                Assert.AreEqual(odinItemTemplates.CostProfileGroup, "cpg");
                Assert.AreEqual(odinItemTemplates.DefaultActualCostUsd, "2");
                Assert.AreEqual(odinItemTemplates.DefaultActualCostCad, "5");
                Assert.AreEqual(odinItemTemplates.Duty, "4");
                Assert.AreEqual(odinItemTemplates.Gpc, "GPC");
                Assert.AreEqual(odinItemTemplates.Height, "99");
                Assert.AreEqual(odinItemTemplates.InnerpackHeight, "12");
                Assert.AreEqual(odinItemTemplates.InnerpackLength, "43");
                Assert.AreEqual(odinItemTemplates.InnerpackQty, "36");
                Assert.AreEqual(odinItemTemplates.InnerpackWidth, "12");
                Assert.AreEqual(odinItemTemplates.InnerpackWeight, "90");
                Assert.AreEqual(odinItemTemplates.ItemCategory, "IC");
                Assert.AreEqual(odinItemTemplates.ItemFamily, "IF");
                Assert.AreEqual(odinItemTemplates.ItemGroup, "IG");
                Assert.AreEqual(odinItemTemplates.Length, "4");
                Assert.AreEqual(odinItemTemplates.ListPriceCad, "4.22");
                Assert.AreEqual(odinItemTemplates.ListPriceUsd, "5.14");
                Assert.AreEqual(odinItemTemplates.ListPriceMxn, "8.45");
                Assert.AreEqual(odinItemTemplates.MetaDescription, "MD");
                Assert.AreEqual(odinItemTemplates.MfgSource, "MS");
                Assert.AreEqual(odinItemTemplates.Msrp, "9.09");
                Assert.AreEqual(odinItemTemplates.MsrpCad, "6.87");
                Assert.AreEqual(odinItemTemplates.MsrpMxn, "3.96");
                Assert.AreEqual(odinItemTemplates.PrintOnDemand, "P");
                Assert.AreEqual(odinItemTemplates.ProductFormat, "PF");
                Assert.AreEqual(odinItemTemplates.ProductGroup, "PG");
                Assert.AreEqual(odinItemTemplates.ProductLine, "PL");
                Assert.AreEqual(odinItemTemplates.ProdQty, "PQ");
                Assert.AreEqual(odinItemTemplates.PricingGroup, "PG");
                Assert.AreEqual(odinItemTemplates.PsStatus, "P");
                Assert.AreEqual(odinItemTemplates.SatCode, "SC");
                Assert.AreEqual(odinItemTemplates.Size, "Size");
                Assert.AreEqual(odinItemTemplates.TariffCode, "TC");
                Assert.AreEqual(odinItemTemplates.Udex, "Udex");
                Assert.AreEqual(odinItemTemplates.Weight, "23");
                Assert.AreEqual(odinItemTemplates.Width, "85");
                Assert.AreEqual(odinItemTemplates.EcommerceBullet1, "EB1");
                Assert.AreEqual(odinItemTemplates.EcommerceBullet2, "EB2");
                Assert.AreEqual(odinItemTemplates.EcommerceBullet3, "EB3");
                Assert.AreEqual(odinItemTemplates.EcommerceBullet4, "EB4");
                Assert.AreEqual(odinItemTemplates.EcommerceBullet5, "EB5");
                Assert.AreEqual(odinItemTemplates.EcommerceComponents, "COM");
                Assert.AreEqual(odinItemTemplates.EcommerceCost, "66");
                Assert.AreEqual(odinItemTemplates.EcommerceExternalIdType, "EIT");
                Assert.AreEqual(odinItemTemplates.EcommerceItemHeight, "3");
                Assert.AreEqual(odinItemTemplates.EcommerceItemLength, "4");
                Assert.AreEqual(odinItemTemplates.EcommerceItemWeight, "5");
                Assert.AreEqual(odinItemTemplates.EcommerceItemWidth, "8");
                Assert.AreEqual(odinItemTemplates.EcommerceModelName, "MNAME");
                Assert.AreEqual(odinItemTemplates.EcommercePackageLength, "39");
                Assert.AreEqual(odinItemTemplates.EcommercePackageHeight, "65");
                Assert.AreEqual(odinItemTemplates.EcommercePackageWeight, "34");
                Assert.AreEqual(odinItemTemplates.EcommercePackageWidth, "82");
                Assert.AreEqual(odinItemTemplates.EcommercePageCount, "19");
                Assert.AreEqual(odinItemTemplates.EcommerceProductCategory, "PC");
                Assert.AreEqual(odinItemTemplates.EcommerceProductDescription, "PD");
                Assert.AreEqual(odinItemTemplates.EcommerceProductSubcategory, "PS");
                Assert.AreEqual(odinItemTemplates.EcommerceManufacturerName, "MANNAME");
                Assert.AreEqual(odinItemTemplates.EcommerceMsrp, "4.34");
                Assert.AreEqual(odinItemTemplates.EcommerceSize, "ESIZE");
            }

            #endregion // Assert
        }

        #endregion // Insert Tests

        #region Removal Tests
        
        /// <summary>
        ///     Tests that RemoveExcelLayoutColumns removes row data from EXCEL_LAYOUT_DATA
        /// </summary>
        [TestMethod]
        public void TemplateRepositoryTests_RemoveExcelLayoutColumns_ShouldRemove()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            TemplateRepository templateRepository = new TemplateRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            int layoutId = 7;
            ObservableCollection<ExcelCell> cellList = new ObservableCollection<ExcelCell>();
            ExcelCell excelCell = new ExcelCell();
            excelCell.ExcelId = 7;
            excelCell.ColumnNumber = 7;
            excelCell.Field = "TestField";
            excelCell.Option = "TestOption";
            excelCell.Customer = "TestCustomer";
            cellList.Add(excelCell);
            ExcelCell excelCell2 = new ExcelCell();
            excelCell2.ExcelId = 7;
            excelCell2.ColumnNumber = 8;
            excelCell2.Field = "TestField2";
            excelCell2.Option = "TestOption2";
            excelCell2.Customer = "TestCustomer2";
            cellList.Add(excelCell2);
            ExcelCell excelCell3 = new ExcelCell();
            excelCell3.ExcelId = 9;
            excelCell3.ColumnNumber = 8;
            excelCell3.Field = "TestField2";
            excelCell3.Option = "TestOption2";
            excelCell3.Customer = "TestCustomer2";
            cellList.Add(excelCell3);

            #endregion // Assemble

            #region Act

            templateRepository.InsertExcelLayoutColumns(cellList);

            templateRepository.RemoveExcelLayoutColumns(layoutId);

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<OdinExcelLayoutData> odinExcelLayoutData = (from o in context.OdinExcelLayoutData select o).ToList();
                Assert.AreEqual(1, odinExcelLayoutData.Count());
            }

            #endregion // Assert
        }
        
        /// <summary>
        ///     Tests that RemoveTemplate removes template data from ODIN_ITEM_TEMPLATES
        /// </summary>
        [TestMethod]
        public void TemplateRepositoryTests_RemoveTemplate_ShouldRemove()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            TemplateRepository templateRepository = new TemplateRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject template = new ItemObject(2);
            template.TemplateId = "TempalteId";
            ItemObject template2 = new ItemObject(2);
            template2.TemplateId = "TempalteId2";

            #endregion // Assemble

            #region Act

            templateRepository.InsertTemplate(template);
            templateRepository.InsertTemplate(template2);
            templateRepository.RemoveTemplate(template.TemplateId);

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<OdinItemTemplates> odinItemTemplates = (from o in context.OdinItemTemplates select o).ToList();
                Assert.AreEqual(1, odinItemTemplates.Count);
                Assert.AreEqual("TempalteId2", odinItemTemplates[0].TemplateId);
            }

            #endregion // Assert
        }

        #endregion // Removal Tests

        #region Retrieval Tests

        /// <summary>
        ///     Tests that results RetrieveFieldValues retrieves all field names from ODIN_FIELD_VALUES
        /// </summary>
        [TestMethod]
        public void TemplateRepositoryTests_RetrieveFieldValues_ShouldRetrieve()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            TemplateRepository templateRepository = new TemplateRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject template2 = new ItemObject(2);
            template2.TemplateId = "CTempalteId";

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                context.OdinFieldValues.Add(new OdinFieldValues { FieldValue = "ATEST" });
                context.OdinFieldValues.Add(new OdinFieldValues { FieldValue = "BTEST" });
                context.OdinFieldValues.Add(new OdinFieldValues { FieldValue = "DTEST" });
                context.OdinFieldValues.Add(new OdinFieldValues { FieldValue = "CTEST" });
                context.SaveChanges();
            }

            List<string> results = templateRepository.RetrieveFieldValues();

            #endregion // Act

            #region Assert

            Assert.AreEqual(results[0], "ATEST");
            Assert.AreEqual(results[1], "BTEST");
            Assert.AreEqual(results[2], "CTEST");
            Assert.AreEqual(results[3], "DTEST");


            #endregion // Assert
        }

        /// <summary>
        ///     Tests that results RetrieveTemplateNameList retrieves all template names from ODIN_ITEM_TEMPLATES
        /// </summary>
        [TestMethod]
        public void TemplateRepositoryTests_RetrieveTemplateNameList_ShouldRetrieve()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            TemplateRepository templateRepository = new TemplateRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject template2 = new ItemObject(2);
            template2.TemplateId = "CTempalteId";
            ItemObject template = new ItemObject(2);
            template.TemplateId = "ATempalteId";
            ItemObject template3 = new ItemObject(2);
            template3.TemplateId = "BTempalteId";
            ItemObject template4 = new ItemObject(2);
            template4.TemplateId = "DTempalteId";

            #endregion // Assemble

            #region Act

            templateRepository.InsertTemplate(template2);
            templateRepository.InsertTemplate(template);
            templateRepository.InsertTemplate(template3);
            templateRepository.InsertTemplate(template4);
            List<string> results = templateRepository.RetrieveTemplateNameList();
            #endregion // Act

            #region Assert

            Assert.AreEqual(results[0], "ATempalteId");
            Assert.AreEqual(results[1], "BTempalteId");
            Assert.AreEqual(results[2], "CTempalteId");
            Assert.AreEqual(results[3], "DTempalteId");


            #endregion // Assert
        }

        /// <summary>
        ///     Tests that RetrieveTemplate retrieves proper data from ODIN_ITEM_TEMPLATES
        /// </summary>
        [TestMethod]
        public void TemplateRepositoryTests_RetrieveTemplate_ShouldRetrieve()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            TemplateRepository templateRepository = new TemplateRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject template2 = new ItemObject(2);
            template2.TemplateId = "TempalteId2";
            ItemObject template = new ItemObject(2);
            template.TemplateId = "TempalteId";
            template.AccountingGroup = "AG";
            template.CasepackHeight = "1";
            template.CasepackLength = "2";
            template.CasepackQty = "3";
            template.CasepackWidth = "4";
            template.CasepackWeight = "5";
            template.Category = "c1";
            template.Category2 = "c2";
            template.Category3 = "c3";
            template.Copyright = "copyright";
            template.CostProfileGroup = "cpg";
            template.DefaultActualCostUsd = "2";
            template.DefaultActualCostCad = "5";
            template.Duty = "4";
            template.Gpc = "GPC";
            template.Height = "99";
            template.InnerpackHeight = "12";
            template.InnerpackLength = "43";
            template.InnerpackQuantity = "36";
            template.InnerpackWidth = "12";
            template.InnerpackWeight = "90";
            template.ItemCategory = "IC";
            template.ItemFamily = "IF";
            template.ItemGroup = "IG";
            template.Length = "4";
            template.ListPriceCad = "4.22";
            template.ListPriceUsd = "5.14";
            template.ListPriceMxn = "8.45";
            template.MetaDescription = "MD";
            template.MfgSource = "MS";
            template.Msrp = "9.09";
            template.MsrpCad = "6.87";
            template.MsrpMxn = "3.96";
            template.PrintOnDemand = "P";
            template.ProductFormat = "PF";
            template.ProductGroup = "PG";
            template.ProductLine = "PL";
            template.ProductQty = "PQ";
            template.PricingGroup = "PG";
            template.PsStatus = "P";
            template.SatCode = "SC";
            template.Size = "Size";
            template.TariffCode = "TC";
            template.Udex = "Udex";
            template.Weight = "23";
            template.Width = "85";
            template.EcommerceBullet1 = "EB1";
            template.EcommerceBullet2 = "EB2";
            template.EcommerceBullet3 = "EB3";
            template.EcommerceBullet4 = "EB4";
            template.EcommerceBullet5 = "EB5";
            template.EcommerceComponents = "COM";
            template.EcommerceCost = "66";
            template.EcommerceExternalIdType = "EIT";
            template.EcommerceItemHeight = "3";
            template.EcommerceItemLength = "4";
            template.EcommerceItemWeight = "5";
            template.EcommerceItemWidth = "8";
            template.EcommerceModelName = "MNAME";
            template.EcommercePackageLength = "39";
            template.EcommercePackageHeight = "65";
            template.EcommercePackageWeight = "34";
            template.EcommercePackageWidth = "82";
            template.EcommercePageQty = "19";
            template.EcommerceProductCategory = "PC";
            template.EcommerceProductDescription = "PD";
            template.EcommerceProductSubcategory = "PS";
            template.EcommerceManufacturerName = "MANNAME";
            template.EcommerceMsrp = "4.34";
            template.EcommerceSize = "ESIZE";

            #endregion // Assemble

            #region Act

            templateRepository.InsertTemplate(template2);
            templateRepository.InsertTemplate(template);

            ItemObject odinItemTemplates = templateRepository.RetrieveTemplate("TempalteId");
            #endregion // Act

            #region Assert

            Assert.AreEqual(odinItemTemplates.TemplateId, "TempalteId");
                Assert.AreEqual(odinItemTemplates.AccountingGroup, "AG");
                Assert.AreEqual(odinItemTemplates.CasepackHeight, "1");
                Assert.AreEqual(odinItemTemplates.CasepackLength, "2");
                Assert.AreEqual(odinItemTemplates.CasepackQty, "3");
                Assert.AreEqual(odinItemTemplates.CasepackWidth, "4");
                Assert.AreEqual(odinItemTemplates.CasepackWeight, "5");
                Assert.AreEqual(odinItemTemplates.Category, "c1");
                Assert.AreEqual(odinItemTemplates.Category2, "c2");
                Assert.AreEqual(odinItemTemplates.Category3, "c3");
                Assert.AreEqual(odinItemTemplates.Copyright, "copyright");
                Assert.AreEqual(odinItemTemplates.CostProfileGroup, "cpg");
                Assert.AreEqual(odinItemTemplates.DefaultActualCostUsd, "2");
                Assert.AreEqual(odinItemTemplates.DefaultActualCostCad, "5");
                Assert.AreEqual(odinItemTemplates.Duty, "4");
                Assert.AreEqual(odinItemTemplates.Gpc, "GPC");
                Assert.AreEqual(odinItemTemplates.Height, "99");
                Assert.AreEqual(odinItemTemplates.InnerpackHeight, "12");
                Assert.AreEqual(odinItemTemplates.InnerpackLength, "43");
                Assert.AreEqual(odinItemTemplates.InnerpackQuantity, "36");
                Assert.AreEqual(odinItemTemplates.InnerpackWidth, "12");
                Assert.AreEqual(odinItemTemplates.InnerpackWeight, "90");
                Assert.AreEqual(odinItemTemplates.ItemCategory, "IC");
                Assert.AreEqual(odinItemTemplates.ItemFamily, "IF");
                Assert.AreEqual(odinItemTemplates.ItemGroup, "IG");
                Assert.AreEqual(odinItemTemplates.Length, "4");
                Assert.AreEqual(odinItemTemplates.ListPriceCad, "4.22");
                Assert.AreEqual(odinItemTemplates.ListPriceUsd, "5.14");
                Assert.AreEqual(odinItemTemplates.ListPriceMxn, "8.45");
                Assert.AreEqual(odinItemTemplates.MetaDescription, "MD");
                Assert.AreEqual(odinItemTemplates.MfgSource, "MS");
                Assert.AreEqual(odinItemTemplates.Msrp, "9.09");
                Assert.AreEqual(odinItemTemplates.MsrpCad, "6.87");
                Assert.AreEqual(odinItemTemplates.MsrpMxn, "3.96");
                Assert.AreEqual(odinItemTemplates.PrintOnDemand, "P");
                Assert.AreEqual(odinItemTemplates.ProductFormat, "PF");
                Assert.AreEqual(odinItemTemplates.ProductGroup, "PG");
                Assert.AreEqual(odinItemTemplates.ProductLine, "PL");
                Assert.AreEqual(odinItemTemplates.ProductQty, "PQ");
                Assert.AreEqual(odinItemTemplates.PricingGroup, "PG");
                Assert.AreEqual(odinItemTemplates.PsStatus, "P");
                Assert.AreEqual(odinItemTemplates.SatCode, "SC");
                Assert.AreEqual(odinItemTemplates.Size, "Size");
                Assert.AreEqual(odinItemTemplates.TariffCode, "TC");
                Assert.AreEqual(odinItemTemplates.Udex, "Udex");
                Assert.AreEqual(odinItemTemplates.Weight, "23");
                Assert.AreEqual(odinItemTemplates.Width, "85");
                Assert.AreEqual(odinItemTemplates.EcommerceBullet1, "EB1");
                Assert.AreEqual(odinItemTemplates.EcommerceBullet2, "EB2");
                Assert.AreEqual(odinItemTemplates.EcommerceBullet3, "EB3");
                Assert.AreEqual(odinItemTemplates.EcommerceBullet4, "EB4");
                Assert.AreEqual(odinItemTemplates.EcommerceBullet5, "EB5");
                Assert.AreEqual(odinItemTemplates.EcommerceComponents, "COM");
                Assert.AreEqual(odinItemTemplates.EcommerceCost, "66");
                Assert.AreEqual(odinItemTemplates.EcommerceExternalIdType, "EIT");
                Assert.AreEqual(odinItemTemplates.EcommerceItemHeight, "3");
                Assert.AreEqual(odinItemTemplates.EcommerceItemLength, "4");
                Assert.AreEqual(odinItemTemplates.EcommerceItemWeight, "5");
                Assert.AreEqual(odinItemTemplates.EcommerceItemWidth, "8");
                Assert.AreEqual(odinItemTemplates.EcommerceModelName, "MNAME");
                Assert.AreEqual(odinItemTemplates.EcommercePackageLength, "39");
                Assert.AreEqual(odinItemTemplates.EcommercePackageHeight, "65");
                Assert.AreEqual(odinItemTemplates.EcommercePackageWeight, "34");
                Assert.AreEqual(odinItemTemplates.EcommercePackageWidth, "82");
                Assert.AreEqual(odinItemTemplates.EcommercePageQty, "19");
                Assert.AreEqual(odinItemTemplates.EcommerceProductCategory, "PC");
                Assert.AreEqual(odinItemTemplates.EcommerceProductDescription, "PD");
                Assert.AreEqual(odinItemTemplates.EcommerceProductSubcategory, "PS");
                Assert.AreEqual(odinItemTemplates.EcommerceManufacturerName, "MANNAME");
                Assert.AreEqual(odinItemTemplates.EcommerceMsrp, "4.34");
                Assert.AreEqual(odinItemTemplates.EcommerceSize, "ESIZE");
            

            #endregion // Assert
        }
        
        #endregion // Retrieval Tests

    }
}
