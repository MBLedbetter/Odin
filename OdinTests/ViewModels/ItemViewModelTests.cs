using Microsoft.VisualStudio.TestTools.UnitTesting;
using Odin.Data;
using Odin.ViewModels;
using OdinModels;
using OdinServices;
using OdinTests.Helpers;
using System.Collections.Generic;

namespace OdinTests.ViewModels
{
    [TestClass]
    public class ItemViewModelTests
    {
        /// <summary>
        ///     This method test the itemViewModels validateAll function with a complete item.
        /// </summary>
        [TestMethod]
        public void ValidateAll_ItemHasValidFields_ShouldPass()
        {
            #region Setup
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            GlobalData.ClearValues();
            GlobalData.AccountingGroups.Add("DOODLE");
            GlobalData.CostProfileGroups.Add("ACTUAL_FIFO");
            GlobalData.CountriesOfOrigin.Add("USA", "United States");
            GlobalData.ExternalIdTypes.Add("UPC");
            GlobalData.ProductCategories.Add("POSTER");
            GlobalData.ItemGroups.Add("BOX");
            GlobalData.Languages.Add("ENG");
            GlobalData.Licenses.Add("Disney");
            GlobalData.ProductGoups.Add("Posters");
            GlobalData.ProductLines.Add(new KeyValuePair<string, string>("Posters", "Posters"));
            GlobalData.ProductFormats.Add(new ProductFormat("Door", "Posters", "Posters"));
            GlobalData.PricingGroups.Add("GROUP1");
            GlobalData.TariffCodes.Add("1234");
            GlobalData.Territories.Add("USA");


            ItemObject item = new ItemObject()
            {

                Status = "Add",
                AccountingGroup = "DOODLE",
                CasepackHeight = "8",
                CasepackLength = "8",
                CasepackQty = "9",
                CasepackUpc = "12345678",
                CasepackWidth = "8",
                CasepackWeight = "8",
                Category = "CALENDAR",
                Color = "RED",
                Copyright = "Copyright Stuff",
                CostProfileGroup = "ACTUAL_FIFO",
                CountryOfOrigin = "USA",
                DefaultActualCostCad = "2.00",
                DefaultActualCostUsd = "2.99",
                Description = "description",
                DirectImport = "directImport",
                Ean = "ean",
                Duty = "duty",
                Gpc = "gpc",
                Height = "1",
                InnerpackHeight = "5",
                InnerpackLength = "5",
                InnerpackQuantity = "7",
                InnerpackUpc = "12345678",
                InnerpackWidth = "5",
                InnerpackWeight = "5",
                InStockDate = "5/17/2000",
                Isbn = "isbn",
                ItemCategory = "POSTER",
                ItemFamily = "FLAT",
                ItemGroup = "BOX",
                ItemId = "RPTEST",
                ItemKeywords = "itemKeywords",
                Language = "ENG",
                Length = "5",
                License = "Disney",
                LicenseBeginDate = "12/13/2016",
                ListPriceCad = "4.99",
                ListPriceUsd = "2.99",
                ListPriceMxn = "1.99",
                MetaDescription = "metaDescription",
                MfgSource = "2",
                Msrp = "5.99",
                MsrpCad = "6.99",
                ProductGroup = "Posters",
                ProductLine = "Posters",
                ProductFormat = "Door",
                PricingGroup = "GROUP1",
                ShortDescription = "A Short Description",
                StandardCost = "2.99",
                StatsCode = "MARCA3",
                TariffCode = "1234",
                Territory = "USA",
                Title = "title",
                Udex = "udex",
                Upc = "000999888777",
                WebsitePrice = "4.50",
                Weight = "4",
                Width = "2",

                Ecommerce_Asin = "asin",
                Ecommerce_Bullet1 = "bullet 1111",
                Ecommerce_Bullet2 = "bullet 2222",
                Ecommerce_Bullet3 = "bullet 3333",
                Ecommerce_Bullet4 = "bullet 4444",
                Ecommerce_Bullet5 = "",
                Ecommerce_Components = "components^",
                Ecommerce_Cost = "2.00",
                Ecommerce_ExternalId = "12345678",
                Ecommerce_ExternalIdType = "UPC",
                Ecommerce_ImagePath1 = "12345",
                Ecommerce_ImagePath2 = "",
                Ecommerce_ImagePath3 = "12345",
                Ecommerce_ImagePath4 = "",
                Ecommerce_ImagePath5 = "12345",
                Ecommerce_ItemHeight = "3",
                Ecommerce_ItemLength = "4",
                Ecommerce_ItemName = "Name",
                Ecommerce_ItemWeight = "4",
                Ecommerce_ItemWidth = "5",
                Ecommerce_ModelName = "Model Name",
                Ecommerce_PackageHeight = "2.12",
                Ecommerce_PackageLength = "2",
                Ecommerce_PackageWeight = "33.7",
                Ecommerce_PackageWidth = "24.4",
                Ecommerce_PageQty = "24",
                Ecommerce_ProductCategory = "pCats",
                Ecommerce_ProductDescription = "pDesc this gets a lot of extra words now that the description has to have at least 100 characters in it. Why stop at 100? Why not 1,000,000,000?",
                Ecommerce_ProductSubcategory = "subby",
                Ecommerce_ManufacturerName = "mrName",
                Ecommerce_Msrp = "12.33",
                Ecommerce_GenericKeywords = "search search searcharina",
                Ecommerce_Size = "22'' x 22''",
                Ecommerce_Upc = "123456789129"
            };

            #endregion // Setup

            #region Act

            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());

            #endregion // Act

            #region Assert
            Assert.AreEqual("", itemViewModel.AccountingGroupError);
            Assert.AreEqual("", itemViewModel.CasepackHeightError);
            Assert.AreEqual("", itemViewModel.CasepackLengthError);
            Assert.AreEqual("", itemViewModel.CasepackQtyError);
            Assert.AreEqual("", itemViewModel.CasepackQtyError);
            Assert.AreEqual("", itemViewModel.CasepackWidthError);
            Assert.AreEqual("", itemViewModel.CasepackWeightError);
            // Assert.AreEqual("", itemViewModel.CategoryError);
            Assert.AreEqual("", itemViewModel.ColorError);
            Assert.AreEqual("", itemViewModel.CopyrightError);
            Assert.AreEqual("", itemViewModel.CostProfileGroupError);
            Assert.AreEqual("", itemViewModel.CountryOfOriginError);
            Assert.AreEqual("", itemViewModel.DefaultActualCostCadError);
            Assert.AreEqual("", itemViewModel.DefaultActualCostUsdError);
            Assert.AreEqual("", itemViewModel.DescriptionError);
            Assert.AreEqual("", itemViewModel.EanError);
            Assert.AreEqual("", itemViewModel.DutyError);
            Assert.AreEqual("", itemViewModel.GpcError);
            Assert.AreEqual("", itemViewModel.HeightError);
            Assert.AreEqual("", itemViewModel.InnerpackHeightError);
            Assert.AreEqual("", itemViewModel.InnerpackLengthError);
            Assert.AreEqual("", itemViewModel.InnerpackQuantityError);
            Assert.AreEqual("", itemViewModel.InnerpackWidthError);
            Assert.AreEqual("", itemViewModel.InnerpackWeightError);
            Assert.AreEqual("", itemViewModel.InStockDateError);
            Assert.AreEqual("", itemViewModel.IsbnError);
            Assert.AreEqual("", itemViewModel.ItemCategoryError);
            Assert.AreEqual("", itemViewModel.ItemFamilyError);
            Assert.AreEqual("", itemViewModel.ItemGroupError);
            Assert.AreEqual("", itemViewModel.ItemIdError);
            Assert.AreEqual("", itemViewModel.ItemKeywordsError);
            Assert.AreEqual("", itemViewModel.LanguageError);
            Assert.AreEqual("", itemViewModel.LengthError);
            Assert.AreEqual("", itemViewModel.LicenseError);
            Assert.AreEqual("", itemViewModel.LicenseBeginDateError);
            Assert.AreEqual("", itemViewModel.ListPriceCadError);
            Assert.AreEqual("", itemViewModel.ListPriceUsdError);
            Assert.AreEqual("", itemViewModel.ListPriceMxnError);
            Assert.AreEqual("", itemViewModel.MetaDescriptionError);
            Assert.AreEqual("", itemViewModel.MfgSourceError);
            Assert.AreEqual("", itemViewModel.MsrpError);
            Assert.AreEqual("", itemViewModel.MsrpCadError);
            Assert.AreEqual("", itemViewModel.ProductGroupError);
            Assert.AreEqual("", itemViewModel.ProductLineError);
            Assert.AreEqual("", itemViewModel.ProductFormatError);
            Assert.AreEqual("", itemViewModel.PricingGroupError);
            Assert.AreEqual("", itemViewModel.ShortDescriptionError);
            Assert.AreEqual("", itemViewModel.StandardCostError);
            Assert.AreEqual("", itemViewModel.StatsCodeError);
            Assert.AreEqual("", itemViewModel.TariffCodeError);
            Assert.AreEqual("", itemViewModel.TerritoryError);
            Assert.AreEqual("", itemViewModel.TitleError);
            Assert.AreEqual("", itemViewModel.UdexError);
            Assert.AreEqual("", itemViewModel.UpcError);
            Assert.AreEqual("", itemViewModel.WebsitePriceError);
            Assert.AreEqual("", itemViewModel.WeightError);
            Assert.AreEqual("", itemViewModel.WidthError);

            Assert.AreEqual("", itemViewModel.Ecommerce_AsinError);
            Assert.AreEqual("", itemViewModel.Ecommerce_Bullet1Error);
            Assert.AreEqual("", itemViewModel.Ecommerce_Bullet2Error);
            Assert.AreEqual("", itemViewModel.Ecommerce_Bullet3Error);
            Assert.AreEqual("", itemViewModel.Ecommerce_Bullet4Error);
            Assert.AreEqual("", itemViewModel.Ecommerce_Bullet5Error);
            Assert.AreEqual("", itemViewModel.Ecommerce_ComponentsError);
            Assert.AreEqual("", itemViewModel.Ecommerce_CostError);
            Assert.AreEqual("", itemViewModel.Ecommerce_ExternalIdError);
            Assert.AreEqual("", itemViewModel.Ecommerce_ExternalIdTypeError);
            // Assert.AreEqual("", itemViewModel.Ecommerce_ImagePath1Error);
            Assert.AreEqual("", itemViewModel.AltImageFile1Error);
            // Assert.AreEqual("", itemViewModel.Ecommerce_ImagePath3Error);
            Assert.AreEqual("", itemViewModel.AltImageFile3Error);
            // Assert.AreEqual("", itemViewModel.Ecommerce_ImagePath5Error);
            Assert.AreEqual("", itemViewModel.Ecommerce_ItemHeightError);
            Assert.AreEqual("", itemViewModel.Ecommerce_ItemLengthError);
            Assert.AreEqual("", itemViewModel.Ecommerce_ItemNameError);
            Assert.AreEqual("", itemViewModel.Ecommerce_ItemWeightError);
            Assert.AreEqual("", itemViewModel.Ecommerce_ItemWidthError);
            Assert.AreEqual("", itemViewModel.Ecommerce_ModelNameError);
            Assert.AreEqual("", itemViewModel.Ecommerce_PackageHeightError);
            Assert.AreEqual("", itemViewModel.Ecommerce_PackageLengthError);
            Assert.AreEqual("", itemViewModel.Ecommerce_PackageWeightError);
            Assert.AreEqual("", itemViewModel.Ecommerce_PackageWidthError);
            Assert.AreEqual("", itemViewModel.Ecommerce_PageQtyError);
            Assert.AreEqual("", itemViewModel.Ecommerce_ProductCategoryError);
            Assert.AreEqual("", itemViewModel.Ecommerce_ProductDescriptionError);
            Assert.AreEqual("", itemViewModel.Ecommerce_ProductSubcategoryError);
            Assert.AreEqual("", itemViewModel.Ecommerce_ManufacturerNameError);
            Assert.AreEqual("", itemViewModel.Ecommerce_MsrpError);
            Assert.AreEqual("", itemViewModel.Ecommerce_GenericKeywordsError);
            Assert.AreEqual("", itemViewModel.Ecommerce_SizeError);
            Assert.AreEqual("", itemViewModel.Ecommerce_UpcError);

            #endregion // Assert
        }

        [TestMethod]
        public void ValidateAllEcommerceFields_ItemHasBlankFields_ShouldReturnErrors()
        {
            #region Setup

            GlobalData.ClearValues();

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            ItemObject item = new ItemObject()
            {
                SellOnAmazon = "Y",
                Ecommerce_Asin = "",
                Ecommerce_Bullet1 = "",
                Ecommerce_Bullet2 = "",
                Ecommerce_Bullet3 = "",
                Ecommerce_Bullet4 = "",
                Ecommerce_Bullet5 = "",
                Ecommerce_Components = "",
                Ecommerce_Cost = "",
                Ecommerce_ExternalId = "",
                Ecommerce_ExternalIdType = "",
                Ecommerce_ImagePath1 = "",
                Ecommerce_ImagePath2 = "",
                Ecommerce_ImagePath3 = "",
                Ecommerce_ImagePath4 = "",
                Ecommerce_ImagePath5 = "",
                Ecommerce_ItemHeight = "",
                Ecommerce_ItemLength = "",
                Ecommerce_ItemName = "",
                Ecommerce_ItemWeight = "",
                Ecommerce_ItemWidth = "",
                Ecommerce_ModelName = "",
                Ecommerce_PackageHeight = "",
                Ecommerce_PackageLength = "",
                Ecommerce_PackageWeight = "",
                Ecommerce_PackageWidth = "",
                Ecommerce_ProductCategory = "",
                Ecommerce_ProductDescription = "",
                Ecommerce_ProductSubcategory = "",
                Ecommerce_ManufacturerName = "",
                Ecommerce_Msrp = "",
                Ecommerce_GenericKeywords = "",
                Ecommerce_Size = ""
            };

            #endregion // Setup

            #region Act

            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());
            itemViewModel.ValidateEcommerce();

            #endregion // Act

            #region Assert
            Assert.AreEqual("", itemViewModel.Ecommerce_AsinError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_Bullet1Error);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_Bullet2Error);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_Bullet3Error);
            Assert.AreEqual("", itemViewModel.Ecommerce_Bullet4Error);
            Assert.AreEqual("", itemViewModel.Ecommerce_Bullet5Error);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ComponentsError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_CostError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ExternalIdError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ExternalIdTypeError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ItemHeightError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ItemLengthError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ItemNameError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ItemWeightError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ItemWidthError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ModelNameError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_PackageHeightError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_PackageLengthError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_PackageWeightError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_PackageWidthError,  "");
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ProductCategoryError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ProductDescriptionError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ProductSubcategoryError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_ManufacturerNameError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_MsrpError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_GenericKeywordsError);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_SizeError);

            #endregion // Assert
        }

        /// <summary>
        ///     Check amazon fields to see if they trigger the 'HasEcommerce' field. Fields with values should set 'HasEcommerce to 'Y'
        /// </summary>
        [TestMethod]
        public void CheckHasEcommerce_ItemHasSellOnFields_ShouldReturnTrue()
        {
            #region Setup


            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            ItemObject item1 = new ItemObject();
            ItemObject item2 = new ItemObject();
            ItemObject item3 = new ItemObject();
            ItemObject item4 = new ItemObject();
            ItemObject item5 = new ItemObject();
            ItemObject item6 = new ItemObject();
            item1.SellOnAmazon = "Y";
            item2.SellOnWalmart = "Y";
            item3.SellOnFanatics = "Y";
            item3.SellOnHayneedle = "Y";
            item4.SellOnTrends = "Y";
            item6.SellOnGuitarCenter = "Y";


            #endregion // Setup

            #region Act

            ItemViewModel itemViewModel1 = new ItemViewModel(item1, itemService, new List<string>());
            ItemViewModel itemViewModel2 = new ItemViewModel(item2, itemService, new List<string>());
            ItemViewModel itemViewModel3 = new ItemViewModel(item3, itemService, new List<string>());
            ItemViewModel itemViewModel4 = new ItemViewModel(item4, itemService, new List<string>());
            ItemViewModel itemViewModel5 = new ItemViewModel(item5, itemService, new List<string>());
            ItemViewModel itemViewModel6 = new ItemViewModel(item6, itemService, new List<string>());

            #endregion // Act

            #region Assert
            Assert.AreEqual(true, itemViewModel1.ItemViewModelItem.HasEcommerce());
            Assert.AreEqual(true, itemViewModel2.ItemViewModelItem.HasEcommerce());
            Assert.AreEqual(true, itemViewModel3.ItemViewModelItem.HasEcommerce());
            Assert.AreEqual(false, itemViewModel4.ItemViewModelItem.HasEcommerce());
            Assert.AreEqual(false, itemViewModel5.ItemViewModelItem.HasEcommerce());
            Assert.AreEqual(true, itemViewModel6.ItemViewModelItem.HasEcommerce());

            #endregion // Assert
        }

        /// <summary>
        ///     Check amazon fields to see if they trigger the 'HasEcommerce' field. Fields with values should set 'HasEcommerce to 'Y'
        /// </summary>
        [TestMethod]
        public void CheckHasEcommerce_AmazonActiveIsY_ShouldReturnTrue()
        {
            #region Setup


            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            ItemObject item1 = new ItemObject()
            {
                Ecommerce_Bullet1 = "Bullet1"
            };


            #endregion // Setup

            #region Act

            ItemViewModel itemViewModel1 = new ItemViewModel(item1, itemService, new List<string>())
            {
                SellOnAmazonCheck = true
            };

            #endregion // Act

            #region Assert
            Assert.IsTrue(itemViewModel1.ItemViewModelItem.HasEcommerce());

            #endregion // Assert
        }

        [TestMethod]
        public void CheckForEcommerceItemHasValues_ShouldReturnTrue()
        {
            #region Assign

            GlobalData.ClearValues();
            ItemObject item = new ItemObject() {
                Ecommerce_Bullet1 = "Rickity Recked",
                SellOnFanatics = "Y"
            };
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());
            #endregion // Assign

            #region Act
            

            #endregion // Act

            #region Assert

            Assert.IsTrue(itemViewModel.ItemViewModelItem.HasEcommerce());
            Assert.AreEqual("", itemViewModel.Ecommerce_Bullet1Error);
            Assert.AreNotEqual("", itemViewModel.Ecommerce_Bullet2Error);

            #endregion // Assert
        }

        /// <summary>
        ///     Check Ecommerce_Required is false if no amazon fields are selected
        /// </summary>
        [TestMethod]
        public void CheckForAmazon_ItemHasNoValues_ShouldReturnFalse()
        {
            #region Assign

            GlobalData.ClearValues();
            ItemObject item = new ItemObject()
            {
                ShortDescription = "OoOoOo BoYeE"
            };
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());
            #endregion // Assign

            #region Act

            bool result = itemViewModel.ItemViewModelItem.HasEcommerce();

            #endregion // Act

            #region Assert

            Assert.IsFalse(result);

            #endregion // Assert
        }

        /// <summary>
        ///     Check Ecommerce_Required is false if no amazon fields are selected
        /// </summary>
        [TestMethod]
        public void CheckHasEcommerceUpdate_ItemHasNoAmazon_ShouldReturnFalse()
        {
            #region Assign

            ItemObject item = new ItemObject() {
                SellOnAmazon = "Y",
                Ecommerce_Bullet1 = "My Porcelin Horse!"
            };
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());
            #endregion // Assign

            #region Act

            bool result1 = itemViewModel.ItemViewModelItem.HasEcommerce();
            itemViewModel.SellOnAmazonCheck = false;
            bool result2 = itemViewModel.ItemViewModelItem.HasEcommerce();

            #endregion // Act

            #region Assert

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);

            #endregion // Assert
        }

        /// <summary>
        ///     Check Ecommerce_Required is false if no amazon fields are selected
        /// </summary>
        [TestMethod]
        public void CheckHasEcommerce_ItemHasNoAmazon_ShouldReturnFalse()
        {
            #region Assign

            GlobalData.ClearValues();
            ItemObject item = new ItemObject();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());
            #endregion // Assign

            #region Act

            bool result1 = itemViewModel.ItemViewModelItem.HasEcommerce();

            #endregion // Act

            #region Assert

            Assert.IsFalse(result1);

            #endregion // Assert
        }

        [TestMethod]
        public void CheckHasWeb_ItemRecievesNewWebValues_ShouldResolveErrors()
        {
            #region Assign

            GlobalData.ClearValues();
            ItemObject item = new ItemObject()
            {
                SellOnTrends = "Y",
                ItemKeywords = ""
            };
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());
            item = new ItemObject()
            {
                SellOnTrends = "N",
                ItemKeywords = ""
            };
            ItemService itemService2 = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemViewModel itemViewModel2 = new ItemViewModel(item, itemService, new List<string>());
            #endregion // Assign

            #region Act

            itemViewModel.ShortDescription = "";

            #endregion // Act

            #region Assert

            Assert.AreNotEqual("", itemViewModel.ItemKeywordsError);
            Assert.AreEqual("", itemViewModel2.ItemKeywordsError);

            #endregion // Assert
        }

        [TestMethod]
        public void CheckHasWeb_ItemHasWebValues_ShouldNotHaveWeb()
        {
            #region Assign

            GlobalData.ClearValues();
            ItemObject item = new ItemObject()
            {
                SellOnTrends = "Y"
            };
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());
            #endregion // Assign

            #region Act
            itemViewModel.Category = "";
            #endregion // Act

            #region Assert

            Assert.AreNotEqual("", itemViewModel.CategoryError);

            #endregion // Assert
        }

        /// <summary>
        ///     Checks that the values of the itemObj are set to the coresponding fields in the itemViewModel
        /// </summary>
        [TestMethod]
        public void CheckAllItemViewModelProperteis_ItemViewModelAssignedValues_ShouldReturnMatchingValues()
        {
            #region Assign

            GlobalData.ClearValues();
            ItemObject item = new ItemObject();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            item.AccountingGroup = "AccountingGroup";
            item.CasepackHeight = "CasepackHeight";
            item.CasepackLength = "CasepackLength";
            item.CasepackQty = "CasepackQty";
            item.CasepackWidth = "CasepackWidth";
            item.CasepackWeight = "CasepackWeight";
            item.Color = "Color";
            item.CountryOfOrigin = "CountryOfOrigin";
            item.CostProfileGroup = "CostProfileGroup";
            item.DefaultActualCostCad = "DefaultActualCostCad";
            item.DefaultActualCostUsd = "DefaultActualCostUsd";
            item.Description = "Description";
            item.DirectImport = "DirectImport";
            item.Duty = "Duty";
            item.Ean = "Ean";
            item.Gpc = "Gpc";
            item.Height = "Height";
            item.InnerpackHeight = "InnerpackHeight";
            item.InnerpackLength = "InnerpackLength";
            item.InnerpackQuantity = "InnerpackQuantity";
            item.InnerpackWidth = "InnerpackWidth";
            item.InnerpackWeight = "InnerpackWeight";
            item.Isbn = "Isbn";
            item.ItemCategory = "ItemCategory";
            item.ItemGroup = "ItemGroup";
            item.ItemFamily = "ItemFamily";
            item.ItemId = "ItemId";
            item.Language = "Language";
            item.Length = "Length";
            item.LicenseBeginDate = "03/02/1900";
            item.ListPriceUsd = "ListPriceUsd";
            item.ListPriceCad = "ListPriceCad";
            item.ListPriceMxn = "ListPriceMxn";
            item.MetaDescription = "MetaDescription";
            item.MfgSource = "MfgSource";
            item.Msrp = "Msrp";
            item.MsrpCad = "MsrpCad";
            item.MsrpMxn = "MsrpMxn";
            item.ProductFormat = "ProductFormat";
            item.ProductGroup = "ProductGroup";
            item.ProductLine = "ProductLine";
            item.ProductQty = "ProductQty";
            item.PsStatus = "PsStatus";
            item.StatsCode = "StatsCode";
            item.StandardCost = "StandardCost";
            item.TariffCode = "TariffCode";
            item.Territory = "Territory";
            item.SellOnAmazon = "Y";
            item.Status = "Status";
            item.Udex = "Udex";
            item.Upc = "Upc";
            item.WebsitePrice = "WebsitePrice";
            item.Weight = "Weight";
            item.Width = "Width";
            item.Category = "Category";
            item.Category2 = "Category2";
            item.Category3 = "Category3";
            item.Copyright = "Copyright";
            item.ItemKeywords = "ItemKeywords";
            item.Title = "Title";
            item.InStockDate = "03/02/1900";
            item.License = "License";
            item.ShortDescription = "ShortDescription";
            item.Property = "Property";
            item.NewDate = "03/02/1900";
            item.Size = "Size";
            item.Ecommerce_Asin = "Ecommerce_Asin";
            item.Ecommerce_Bullet1 = "Ecommerce_Bullet1";
            item.Ecommerce_Bullet2 = "Ecommerce_Bullet2";
            item.Ecommerce_Bullet3 = "Ecommerce_Bullet3";
            item.Ecommerce_Bullet4 = "Ecommerce_Bullet4";
            item.Ecommerce_Bullet5 = "Ecommerce_Bullet5";
            item.Ecommerce_Components = "Ecommerce_Components";
            item.Ecommerce_Cost = "Ecommerce_Cost";
            item.Ecommerce_ExternalId = "Ecommerce_ExternalId";
            item.Ecommerce_ExternalIdType = "Ecommerce_ExternalIdType";
            item.Ecommerce_ImagePath1 = "Ecommerce_ImagePath1";
            item.Ecommerce_ImagePath2 = "Ecommerce_ImagePath2";
            item.Ecommerce_ImagePath3 = "Ecommerce_ImagePath3";
            item.Ecommerce_ImagePath4 = "Ecommerce_ImagePath4";
            item.Ecommerce_ImagePath5 = "Ecommerce_ImagePath5";
            item.Ecommerce_ItemHeight = "Ecommerce_ItemHeight";
            item.Ecommerce_ItemLength = "Ecommerce_ItemLength";
            item.Ecommerce_ItemName = "Ecommerce_ItemName";
            item.Ecommerce_ItemWeight = "Ecommerce_ItemWeight";
            item.Ecommerce_ItemWidth = "Ecommerce_ItemWidth";
            item.Ecommerce_ModelName = "Ecommerce_ModelName";
            item.Ecommerce_PackageHeight = "Ecommerce_PackageHeight";
            item.Ecommerce_PackageLength = "Ecommerce_PackageLength";
            item.Ecommerce_PackageWeight = "Ecommerce_PackageWeight";
            item.Ecommerce_PackageWidth = "Ecommerce_PackageWidth";
            item.Ecommerce_PageQty = "Ecommerce_PageQty";
            item.Ecommerce_ProductCategory = "Ecommerce_ProductCategory";
            item.Ecommerce_ProductDescription = "Ecommerce_ProductDescription";
            item.Ecommerce_ProductSubcategory = "Ecommerce_ProductSubcategory";
            item.Ecommerce_ManufacturerName = "Ecommerce_ManufacturerName";
            item.Ecommerce_Msrp = "Ecommerce_Msrp";
            item.Ecommerce_GenericKeywords = "Ecommerce_GenericKeywords";
            item.Ecommerce_Size = "Ecommerce_Size";

            #endregion // Assign

            #region Act

            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());

            #endregion // Act

            #region Assert

            Assert.AreEqual(itemViewModel.AccountingGroup, "AccountingGroup");
            Assert.AreEqual(itemViewModel.CasepackHeight, "CasepackHeight");
            Assert.AreEqual(itemViewModel.CasepackLength, "CasepackLength");
            Assert.AreEqual(itemViewModel.CasepackQty, "CasepackQty");
            Assert.AreEqual(itemViewModel.CasepackWidth, "CasepackWidth");
            Assert.AreEqual(itemViewModel.CasepackWeight, "CasepackWeight");
            Assert.AreEqual(itemViewModel.Color, "Color");
            Assert.AreEqual(itemViewModel.CountryOfOrigin, "CountryOfOrigin");
            Assert.AreEqual(itemViewModel.CostProfileGroup, "CostProfileGroup");
            Assert.AreEqual(itemViewModel.DefaultActualCostCad, "DefaultActualCostCad");
            Assert.AreEqual(itemViewModel.DefaultActualCostUsd, "DefaultActualCostUsd");
            Assert.AreEqual(itemViewModel.Description, "Description");
            Assert.AreEqual(itemViewModel.DirectImport, "DirectImport");
            Assert.AreEqual(itemViewModel.Duty, "Duty");
            Assert.AreEqual(itemViewModel.Ean, "Ean");
            Assert.AreEqual(itemViewModel.Gpc, "Gpc");
            Assert.AreEqual(itemViewModel.Height, "Height");
            Assert.AreEqual(itemViewModel.InnerpackHeight, "InnerpackHeight");
            Assert.AreEqual(itemViewModel.InnerpackLength, "InnerpackLength");
            Assert.AreEqual(itemViewModel.InnerpackQuantity, "InnerpackQuantity");
            Assert.AreEqual(itemViewModel.InnerpackWidth, "InnerpackWidth");
            Assert.AreEqual(itemViewModel.InnerpackWeight, "InnerpackWeight");
            Assert.AreEqual(itemViewModel.Isbn, "Isbn");
            Assert.AreEqual(itemViewModel.ItemCategory, "ItemCategory");
            Assert.AreEqual(itemViewModel.ItemGroup, "ItemGroup");
            Assert.AreEqual(itemViewModel.ItemFamily, "ItemFamily");
            Assert.AreEqual(itemViewModel.ItemId, "ItemId");
            Assert.AreEqual(itemViewModel.Language, "Language");
            Assert.AreEqual(itemViewModel.Length, "Length");
            Assert.AreEqual(itemViewModel.LicenseBeginDate, "03/02/1900");
            Assert.AreEqual(itemViewModel.ListPriceUsd, "ListPriceUsd");
            Assert.AreEqual(itemViewModel.ListPriceCad, "ListPriceCad");
            Assert.AreEqual(itemViewModel.ListPriceMxn, "ListPriceMxn");
            Assert.AreEqual(itemViewModel.MetaDescription, "MetaDescription");
            Assert.AreEqual(itemViewModel.MfgSource, "MfgSource");
            Assert.AreEqual(itemViewModel.Msrp, "Msrp");
            Assert.AreEqual(itemViewModel.MsrpCad, "MsrpCad");
            Assert.AreEqual(itemViewModel.MsrpMxn, "MsrpMxn");
            Assert.AreEqual(itemViewModel.ProductFormat, "ProductFormat");
            Assert.AreEqual(itemViewModel.ProductGroup, "ProductGroup");
            Assert.AreEqual(itemViewModel.ProductLine, "ProductLine");
            Assert.AreEqual(itemViewModel.ProductQty, "ProductQty");
            Assert.AreEqual(itemViewModel.PsStatus, "PsStatus");
            Assert.AreEqual(itemViewModel.StatsCode, "StatsCode");
            Assert.AreEqual(itemViewModel.StandardCost, "StandardCost");
            Assert.AreEqual(itemViewModel.TariffCode, "TariffCode");
            Assert.AreEqual(itemViewModel.Territory, "Territory");
            Assert.AreEqual(itemViewModel.Status, "Status");
            Assert.AreEqual(itemViewModel.Udex, "Udex");
            Assert.AreEqual(itemViewModel.Upc, "Upc");
            Assert.AreEqual(itemViewModel.WebsitePrice, "WebsitePrice");
            Assert.AreEqual(itemViewModel.Weight, "Weight");
            Assert.AreEqual(itemViewModel.Width, "Width");
            Assert.AreEqual(itemViewModel.Category, "Category");
            Assert.AreEqual(itemViewModel.Category2, "Category2");
            Assert.AreEqual(itemViewModel.Category3, "Category3");
            Assert.AreEqual(itemViewModel.Copyright, "Copyright");
            Assert.AreEqual(itemViewModel.ItemKeywords, "ItemKeywords");
            Assert.AreEqual(itemViewModel.Title, "Title");
            Assert.AreEqual(itemViewModel.InStockDate, "03/02/1900");
            Assert.AreEqual(itemViewModel.License, "License");
            Assert.AreEqual(itemViewModel.ShortDescription, "ShortDescription");
            Assert.AreEqual(itemViewModel.Property, "Property");
            // Assert.AreEqual(itemViewModel.NewDate, "NewDate");
            Assert.AreEqual(itemViewModel.Size, "Size");
            Assert.IsTrue(itemViewModel.ItemViewModelItem.HasEcommerce());
            Assert.AreEqual(itemViewModel.Ecommerce_Asin, "Ecommerce_Asin");
            Assert.AreEqual(itemViewModel.Ecommerce_Bullet1, "Ecommerce_Bullet1");
            Assert.AreEqual(itemViewModel.Ecommerce_Bullet2, "Ecommerce_Bullet2");
            Assert.AreEqual(itemViewModel.Ecommerce_Bullet3, "Ecommerce_Bullet3");
            Assert.AreEqual(itemViewModel.Ecommerce_Bullet4, "Ecommerce_Bullet4");
            Assert.AreEqual(itemViewModel.Ecommerce_Bullet5, "Ecommerce_Bullet5");
            Assert.AreEqual(itemViewModel.Ecommerce_Components, "Ecommerce_Components");
            Assert.AreEqual(itemViewModel.Ecommerce_Cost, "Ecommerce_Cost");
            Assert.AreEqual(itemViewModel.Ecommerce_ExternalId, "Ecommerce_ExternalId");
            Assert.AreEqual(itemViewModel.Ecommerce_ExternalIdType, "Ecommerce_ExternalIdType");
            Assert.AreEqual(itemViewModel.Ecommerce_ImagePath1, "Ecommerce_ImagePath1");
            Assert.AreEqual(itemViewModel.Ecommerce_ImagePath2, "Ecommerce_ImagePath2");
            Assert.AreEqual(itemViewModel.Ecommerce_ImagePath3, "Ecommerce_ImagePath3");
            Assert.AreEqual(itemViewModel.Ecommerce_ImagePath4, "Ecommerce_ImagePath4");
            Assert.AreEqual(itemViewModel.Ecommerce_ImagePath5, "Ecommerce_ImagePath5");
            Assert.AreEqual(itemViewModel.Ecommerce_ItemHeight, "Ecommerce_ItemHeight");
            Assert.AreEqual(itemViewModel.Ecommerce_ItemLength, "Ecommerce_ItemLength");
            Assert.AreEqual(itemViewModel.Ecommerce_ItemName, "Ecommerce_ItemName");
            Assert.AreEqual(itemViewModel.Ecommerce_ItemWeight, "Ecommerce_ItemWeight");
            Assert.AreEqual(itemViewModel.Ecommerce_ItemWidth, "Ecommerce_ItemWidth");
            Assert.AreEqual(itemViewModel.Ecommerce_ModelName, "Ecommerce_ModelName");
            Assert.AreEqual(itemViewModel.Ecommerce_PackageHeight, "Ecommerce_PackageHeight");
            Assert.AreEqual(itemViewModel.Ecommerce_PackageLength, "Ecommerce_PackageLength");
            Assert.AreEqual(itemViewModel.Ecommerce_PackageWeight, "Ecommerce_PackageWeight");
            Assert.AreEqual(itemViewModel.Ecommerce_PackageWidth, "Ecommerce_PackageWidth");
            Assert.AreEqual(itemViewModel.Ecommerce_PageQty, "Ecommerce_PageQty");
            Assert.AreEqual(itemViewModel.Ecommerce_ProductCategory, "Ecommerce_ProductCategory");
            Assert.AreEqual(itemViewModel.Ecommerce_ProductDescription, "Ecommerce_ProductDescription");
            Assert.AreEqual(itemViewModel.Ecommerce_ProductSubcategory, "Ecommerce_ProductSubcategory");
            Assert.AreEqual(itemViewModel.Ecommerce_ManufacturerName, "Ecommerce_ManufacturerName");
            Assert.AreEqual(itemViewModel.Ecommerce_Msrp, "Ecommerce_Msrp");
            Assert.AreEqual(itemViewModel.Ecommerce_GenericKeywords, "Ecommerce_GenericKeywords");
            Assert.AreEqual(itemViewModel.Ecommerce_Size, "Ecommerce_Size");

            #endregion // Assert
        }

        /// <summary>
        ///     Checks that the values of the itemObj are set to the coresponding fields in the itemViewModel
        /// </summary>
        [TestMethod]
        public void CheckItemViewModelProperteisNoAmazon_ItemViewModelAssignedValues_ShouldReturnMatchingValues()
        {
            #region Assign
            
            ItemObject item = new ItemObject();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            item.AccountingGroup = "AccountingGroup";
            item.CasepackHeight = "CasepackHeight";
            item.CasepackLength = "CasepackLength";
            item.CasepackQty = "CasepackQty";
            item.CasepackWidth = "CasepackWidth";
            item.CasepackWeight = "CasepackWeight";
            item.Category = "Category";
            item.Category2 = "Category2";
            item.Category3 = "Category3";
            item.Color = "Color";
            item.Copyright = "Copyright";
            item.CostProfileGroup = "CostProfileGroup";
            item.CountryOfOrigin = "CountryOfOrigin";
            item.DefaultActualCostCad = "DefaultActualCostCad";
            item.DefaultActualCostUsd = "DefaultActualCostUsd";
            item.Description = "Description";
            item.DirectImport = "DirectImport";
            item.Duty = "Duty";
            item.Ean = "Ean";
            item.Gpc = "Gpc";
            item.Height = "Height";
            item.InnerpackHeight = "InnerpackHeight";
            item.InnerpackLength = "InnerpackLength";
            item.InnerpackQuantity = "InnerpackQuantity";
            item.InnerpackWidth = "InnerpackWidth";
            item.InnerpackWeight = "InnerpackWeight";
            item.InStockDate = "02/03/1901";
            item.Isbn = "Isbn";
            item.ItemCategory = "ItemCategory";
            item.ItemFamily = "ItemFamily";
            item.ItemGroup = "ItemGroup";
            item.ItemId = "ItemId";
            item.ItemKeywords = "ItemKeywords";
            item.Language = "Language";
            item.Length = "Length";
            item.License = "License";
            item.LicenseBeginDate = "02/03/1901";
            item.ListPriceUsd = "ListPriceUsd";
            item.ListPriceCad = "ListPriceCad";
            item.ListPriceMxn = "ListPriceMxn";
            item.MetaDescription = "MetaDescription";
            item.MfgSource = "MfgSource";
            item.Msrp = "Msrp";
            item.MsrpCad = "MsrpCad";
            item.MsrpMxn = "MsrpMxn";
            item.NewDate = "NewDate";
            item.ProductFormat = "ProductFormat";
            item.ProductGroup = "ProductGroup";
            item.ProductLine = "ProductLine";
            item.ProductQty = "ProductQty";
            item.Property = "Property";
            item.PsStatus = "PsStatus";
            item.ShortDescription = "ShortDescription";
            item.Size = "Size";
            item.StandardCost = "StandardCost";
            item.StatsCode = "StatsCode";
            item.Status = "Status";
            item.TariffCode = "TariffCode";
            item.Territory = "Territory";
            item.Title = "Title";
            item.Udex = "Udex";
            item.Upc = "Upc";
            item.WebsitePrice = "WebsitePrice";
            item.Weight = "Weight";
            item.Width = "Width";

            #endregion // Assign

            #region Act

            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());

            #endregion // Act

            #region Assert

            Assert.AreEqual(itemViewModel.AccountingGroup, "AccountingGroup");
            Assert.AreEqual(itemViewModel.CasepackHeight, "CasepackHeight");
            Assert.AreEqual(itemViewModel.CasepackLength, "CasepackLength");
            Assert.AreEqual(itemViewModel.CasepackQty, "CasepackQty");
            Assert.AreEqual(itemViewModel.CasepackWidth, "CasepackWidth");
            Assert.AreEqual(itemViewModel.CasepackWeight, "CasepackWeight");
            Assert.AreEqual(itemViewModel.Category, "Category");
            Assert.AreEqual(itemViewModel.Category2, "Category2");
            Assert.AreEqual(itemViewModel.Category3, "Category3");
            Assert.AreEqual(itemViewModel.Color, "Color");
            Assert.AreEqual(itemViewModel.Copyright, "Copyright");
            Assert.AreEqual(itemViewModel.CountryOfOrigin, "CountryOfOrigin");
            Assert.AreEqual(itemViewModel.CostProfileGroup, "CostProfileGroup");
            Assert.AreEqual(itemViewModel.DefaultActualCostCad, "DefaultActualCostCad");
            Assert.AreEqual(itemViewModel.DefaultActualCostUsd, "DefaultActualCostUsd");
            Assert.AreEqual(itemViewModel.Description, "Description");
            Assert.AreEqual(itemViewModel.DirectImport, "DirectImport");
            Assert.AreEqual(itemViewModel.Duty, "Duty");
            Assert.AreEqual(itemViewModel.Ean, "Ean");
            Assert.AreEqual(itemViewModel.Gpc, "Gpc");
            Assert.AreEqual(itemViewModel.Height, "Height");
            Assert.AreEqual(itemViewModel.InnerpackHeight, "InnerpackHeight");
            Assert.AreEqual(itemViewModel.InnerpackLength, "InnerpackLength");
            Assert.AreEqual(itemViewModel.InnerpackQuantity, "InnerpackQuantity");
            Assert.AreEqual(itemViewModel.InnerpackWidth, "InnerpackWidth");
            Assert.AreEqual(itemViewModel.InnerpackWeight, "InnerpackWeight");
            Assert.AreEqual(itemViewModel.InStockDate, "02/03/1901");
            Assert.AreEqual(itemViewModel.Isbn, "Isbn");
            Assert.AreEqual(itemViewModel.ItemCategory, "ItemCategory");
            Assert.AreEqual(itemViewModel.ItemFamily, "ItemFamily");
            Assert.AreEqual(itemViewModel.ItemGroup, "ItemGroup");
            Assert.AreEqual(itemViewModel.ItemId, "ItemId");
            Assert.AreEqual(itemViewModel.ItemKeywords, "ItemKeywords");
            Assert.AreEqual(itemViewModel.Language, "Language");
            Assert.AreEqual(itemViewModel.Length, "Length");
            Assert.AreEqual(itemViewModel.License, "License");
            Assert.AreEqual(itemViewModel.LicenseBeginDate, "02/03/1901");
            Assert.AreEqual(itemViewModel.ListPriceUsd, "ListPriceUsd");
            Assert.AreEqual(itemViewModel.ListPriceCad, "ListPriceCad");
            Assert.AreEqual(itemViewModel.ListPriceMxn, "ListPriceMxn");
            Assert.AreEqual(itemViewModel.MetaDescription, "MetaDescription");
            Assert.AreEqual(itemViewModel.MfgSource, "MfgSource");
            Assert.AreEqual(itemViewModel.Msrp, "Msrp");
            Assert.AreEqual(itemViewModel.MsrpCad, "MsrpCad");
            Assert.AreEqual(itemViewModel.MsrpMxn, "MsrpMxn");
            Assert.AreEqual(itemViewModel.ProductFormat, "ProductFormat");
            Assert.AreEqual(itemViewModel.ProductGroup, "ProductGroup");
            Assert.AreEqual(itemViewModel.ProductLine, "ProductLine");
            Assert.AreEqual(itemViewModel.ProductQty, "ProductQty");
            Assert.AreEqual(itemViewModel.Property, "Property");
            Assert.AreEqual(itemViewModel.PsStatus, "PsStatus");
            Assert.AreEqual(itemViewModel.ShortDescription, "ShortDescription");
            Assert.AreEqual(itemViewModel.Size, "Size");
            Assert.AreEqual(itemViewModel.StandardCost, "StandardCost");
            Assert.AreEqual(itemViewModel.StatsCode, "StatsCode");
            Assert.AreEqual(itemViewModel.TariffCode, "TariffCode");
            Assert.AreEqual(itemViewModel.Territory, "Territory");
            Assert.AreEqual(itemViewModel.Title, "Title");
            Assert.AreEqual(itemViewModel.Status, "Status");
            Assert.AreEqual(itemViewModel.Udex, "Udex");
            Assert.AreEqual(itemViewModel.Upc, "Upc");
            Assert.AreEqual(itemViewModel.WebsitePrice, "WebsitePrice");
            Assert.AreEqual(itemViewModel.Weight, "Weight");
            Assert.AreEqual(itemViewModel.Width, "Width");
            Assert.IsFalse(itemViewModel.ItemViewModelItem.HasEcommerce());

            #endregion // Assert
        }

        [TestMethod]
        public void ItemViewModel_PassThroughValues_ValuesShouldBeEqual()
        {
            #region Assemble

            List<ChildElement> billOfMaterials = new List<ChildElement>() {
            new ChildElement("ST1111", "ST9999", 1),
            new ChildElement("ST2222", "ST9999", 2)
                };
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            List<ChildElement> PID = new List<ChildElement>() {
            new ChildElement("ST1111", "ST9999", 5),
            new ChildElement("ST2222", "ST9999", 1)
            };
            List<string> itemIds = new List<string>() {
                "" };
            ItemObject item = new ItemObject()
            {
                Status = "Add",
                AltImageFile1 = "",
                AltImageFile2 = "",
                AltImageFile3 = "",
                AltImageFile4 = "",
                AccountingGroup = "Accounting Group",
                BillOfMaterials = billOfMaterials,
                CasepackHeight = "1",
                CasepackLength = "2",
                CasepackQty = "3",
                CasepackUpc = "999999999999",
                CasepackWidth = "77",
                CasepackWeight = "34",
                Category = "Bookmarks",
                Category2 = "Paper Craft",
                Category3 = "Paper Craft: Stickers",
                Color = "Color",
                Copyright = "Copyright",
                CountryOfOrigin = "USA",
                CostProfileGroup = "Cost Profile Group",
                DefaultActualCostUsd = "4.99",
                DefaultActualCostCad = "8.00",
                Description = "Description",
                DirectImport = "Y",
                Duty = "9",
                Ean = "EAN",
                Ecommerce_Asin = "ASIN",
                Ecommerce_Bullet1 = "Bullet 1",
                Ecommerce_Bullet2 = "Bullet 2",
                Ecommerce_Bullet3 = "Bullet 3",
                Ecommerce_Bullet4 = "Bullet 4",
                Ecommerce_Bullet5 = "Bullet 5",
                Ecommerce_Components = "Components",
                Ecommerce_Cost = "5.99",
                Ecommerce_ExternalId = "000000000000",
                Ecommerce_ExternalIdType = "UPC",
                Ecommerce_GenericKeywords = "GenericeKeywords",
                Ecommerce_ItemHeight = "5",
                Ecommerce_ItemLength = "4",
                Ecommerce_ItemName = "Item Name",
                Ecommerce_ItemWeight = "9",
                Ecommerce_ItemWidth = "5",
                Ecommerce_ModelName = "Model Name",
                Ecommerce_PackageHeight = "5",
                Ecommerce_PackageLength = "4",
                Ecommerce_PackageWeight = "1",
                Ecommerce_PackageWidth = "2",
                Ecommerce_PageQty = "3",
                Ecommerce_ProductCategory = "Product Category",
                Ecommerce_ProductDescription = "Product Description",
                Ecommerce_ProductSubcategory = "Product Subcategory",
                Ecommerce_ManufacturerName = "Manufacturer Name",
                Ecommerce_Msrp = "9.99",
                Ecommerce_Size = "8",
                Ecommerce_SubjectKeywords = "SubjectKeywords",
                Ecommerce_Upc = "ecommerceUpc",
                Gpc = "gpc",
                Height = "2",
                ImagePath = "imagePath",
                InnerpackHeight = "2",
                InnerpackLength = "34",
                InnerpackQuantity = "90",
                InnerpackUpc = "019283746547",
                InnerpackWidth = "14",
                InnerpackWeight = "52",
                InStockDate = "",
                Isbn = "ISBN",
                ItemCategory = "Item Category",
                ItemFamily = "Item Family",
                ItemGroup = "item group",
                ItemId = "TestItem2",
                ItemKeywords = "Item Keywords",
                Language = "ENG",
                Length = "91",
                License = "License",
                LicenseBeginDate = "",
                ListPriceCad = "9.99",
                ListPriceUsd = "7.99",
                ListPriceMxn = "2.22",
                MetaDescription = "Meta Description",
                MfgSource = "mfgSource",
                Msrp = "7.77",
                MsrpCad = "19.99",
                MsrpMxn = "1.99",
                ProductFormat = "Product Format",
                ProductGroup = "Product Group",
                ProductIdTranslation = PID,
                ProductLine = "Product Line",
                ProductQty = "4",
                Property = "Property",
                PricingGroup = "Pricing Group",
                PrintOnDemand = "Y",
                PsStatus = "A",
                SatCode = "111",
                SellOnAllPosters = "N",
                SellOnAmazon = "N",
                SellOnFanatics = "N",
                SellOnGuitarCenter = "N",
                SellOnHayneedle = "N",
                SellOnTarget = "N",
                SellOnTrends = "N",
                SellOnWalmart = "N",
                SellOnWayfair = "N",
                ShortDescription = "Short Description",
                Size = "size",
                StandardCost = "5.00",
                StatsCode = "statsCode",
                TariffCode = "tariffCode",
                Territory = "USA",
                Title = "title",
                Udex = "udex",
                Upc = "000000000000",
                WebsitePrice = "4.99",
                Weight = "2",
                Width = "1"
            };
            item.ResetUpdate();

            #endregion // Assemble

            #region Act

            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, itemIds);
            itemViewModel.ValidateAll(itemViewModel.ItemViewModelItem);
            ItemObject newItem = itemViewModel.ItemViewModelItem;

            #endregion // Act

            #region Assert

            Assert.AreEqual(item.SellOnAmazon, newItem.SellOnAmazon);
            Assert.AreEqual(item.SellOnFanatics, newItem.SellOnFanatics);
            Assert.AreEqual(item.SellOnGuitarCenter, newItem.SellOnGuitarCenter);
            Assert.AreEqual(item.SellOnHayneedle, newItem.SellOnHayneedle);
            Assert.AreEqual(item.SellOnWalmart, newItem.SellOnWalmart);
            Assert.AreEqual(item.SellOnTrends, newItem.SellOnTrends);
            Assert.AreEqual(item.Ecommerce_Asin, newItem.Ecommerce_Asin);
            Assert.AreEqual(item.Ecommerce_Bullet1, newItem.Ecommerce_Bullet1);
            Assert.AreEqual(item.Ecommerce_Bullet2, newItem.Ecommerce_Bullet2);
            Assert.AreEqual(item.Ecommerce_Bullet3, newItem.Ecommerce_Bullet3);
            Assert.AreEqual(item.Ecommerce_Bullet4, newItem.Ecommerce_Bullet4);
            Assert.AreEqual(item.Ecommerce_Bullet5, newItem.Ecommerce_Bullet5);
            Assert.AreEqual(item.Ecommerce_Components, newItem.Ecommerce_Components);
            Assert.AreEqual(item.Ecommerce_Cost, newItem.Ecommerce_Cost);
            Assert.AreEqual(item.Ecommerce_ExternalId, newItem.Ecommerce_ExternalId);
            Assert.AreEqual(item.Ecommerce_ExternalIdType, newItem.Ecommerce_ExternalIdType);
            Assert.AreEqual(item.Ecommerce_ImagePath1, newItem.Ecommerce_ImagePath1);
            Assert.AreEqual(item.Ecommerce_ImagePath2, newItem.Ecommerce_ImagePath2);
            Assert.AreEqual(item.Ecommerce_ImagePath3, newItem.Ecommerce_ImagePath3);
            Assert.AreEqual(item.Ecommerce_ImagePath4, newItem.Ecommerce_ImagePath4);
            Assert.AreEqual(item.Ecommerce_ImagePath5, newItem.Ecommerce_ImagePath5);            
            Assert.AreEqual(item.Ecommerce_ItemHeight, newItem.Ecommerce_ItemHeight);
            Assert.AreEqual(item.Ecommerce_ItemLength, newItem.Ecommerce_ItemLength);
            Assert.AreEqual(item.Ecommerce_ItemName, newItem.Ecommerce_ItemName);
            Assert.AreEqual(item.Ecommerce_ItemWeight, newItem.Ecommerce_ItemWeight);
            Assert.AreEqual(item.Ecommerce_ItemWidth, newItem.Ecommerce_ItemWidth);
            Assert.AreEqual(item.Ecommerce_ModelName, newItem.Ecommerce_ModelName);
            Assert.AreEqual(item.Ecommerce_PackageHeight, newItem.Ecommerce_PackageHeight);
            Assert.AreEqual(item.Ecommerce_PackageLength, newItem.Ecommerce_PackageLength);
            Assert.AreEqual(item.Ecommerce_PackageWeight, newItem.Ecommerce_PackageWeight);
            Assert.AreEqual(item.Ecommerce_PackageWidth, newItem.Ecommerce_PackageWidth);
            Assert.AreEqual(item.Ecommerce_PageQty, newItem.Ecommerce_PageQty);
            Assert.AreEqual(item.Ecommerce_ProductCategory, newItem.Ecommerce_ProductCategory);
            Assert.AreEqual(item.Ecommerce_ProductDescription, newItem.Ecommerce_ProductDescription);
            Assert.AreEqual(item.Ecommerce_ProductSubcategory, newItem.Ecommerce_ProductSubcategory);
            Assert.AreEqual(item.Ecommerce_ManufacturerName, newItem.Ecommerce_ManufacturerName);
            Assert.AreEqual(item.Ecommerce_Msrp, newItem.Ecommerce_Msrp);
            Assert.AreEqual(item.Ecommerce_GenericKeywords, newItem.Ecommerce_GenericKeywords);
            Assert.AreEqual(item.Ecommerce_Size, newItem.Ecommerce_Size);
            Assert.AreEqual(item.AccountingGroup, newItem.AccountingGroup);
            Assert.AreEqual(item.ReturnBillOfMaterials(), newItem.ReturnBillOfMaterials());
            Assert.AreEqual(item.CasepackHeight, newItem.CasepackHeight);
            Assert.AreEqual(item.CasepackLength, newItem.CasepackLength);
            Assert.AreEqual(item.CasepackQty, newItem.CasepackQty);
            Assert.AreEqual(item.CasepackUpc, newItem.CasepackUpc);
            Assert.AreEqual(item.CasepackWidth, newItem.CasepackWidth);
            Assert.AreEqual(item.CasepackWeight, newItem.CasepackWeight);
            Assert.AreEqual(item.Category, newItem.Category);
            Assert.AreEqual(item.Category2, newItem.Category2);
            Assert.AreEqual(item.Category3, newItem.Category3);
            Assert.AreEqual(item.Color, newItem.Color);
            Assert.AreEqual(item.Copyright, newItem.Copyright);
            Assert.AreEqual(item.CountryOfOrigin, newItem.CountryOfOrigin);
            Assert.AreEqual(item.CostProfileGroup, newItem.CostProfileGroup);
            Assert.AreEqual(item.DefaultActualCostUsd, newItem.DefaultActualCostUsd);
            Assert.AreEqual(item.DefaultActualCostCad, newItem.DefaultActualCostCad);
            Assert.AreEqual(item.Description, newItem.Description);
            Assert.AreEqual(item.DirectImport, newItem.DirectImport);
            Assert.AreEqual(item.Ean, newItem.Ean);
            Assert.AreEqual(item.Gpc, newItem.Gpc);
            Assert.AreEqual(item.Height, newItem.Height);
            Assert.AreEqual(item.InnerpackHeight, newItem.InnerpackHeight);
            Assert.AreEqual(item.InnerpackLength, newItem.InnerpackLength);
            Assert.AreEqual(item.InnerpackQuantity, newItem.InnerpackQuantity);
            Assert.AreEqual(item.InnerpackUpc, newItem.InnerpackUpc);
            Assert.AreEqual(item.InnerpackWidth, newItem.InnerpackWidth);
            Assert.AreEqual(item.InnerpackWeight, newItem.InnerpackWeight);
            Assert.AreEqual(item.InStockDate, newItem.InStockDate);
            Assert.AreEqual(item.Isbn, newItem.Isbn);
            Assert.AreEqual(item.ItemCategory, newItem.ItemCategory);
            Assert.AreEqual(item.ItemFamily, newItem.ItemFamily);
            Assert.AreEqual(item.ItemGroup, newItem.ItemGroup);
            Assert.AreEqual(item.ItemId, newItem.ItemId);
            Assert.AreEqual(item.ItemKeywords, newItem.ItemKeywords);
            Assert.AreEqual(item.Language, newItem.Language);
            Assert.AreEqual(item.Length, newItem.Length);
            Assert.AreEqual(item.License, newItem.License);
            Assert.AreEqual(item.LicenseBeginDate, newItem.LicenseBeginDate);
            Assert.AreEqual(item.ListPriceCad, newItem.ListPriceCad);
            Assert.AreEqual(item.ListPriceUsd, newItem.ListPriceUsd);
            Assert.AreEqual(item.ListPriceMxn, newItem.ListPriceMxn);
            Assert.AreEqual(item.MetaDescription, newItem.MetaDescription);
            Assert.AreEqual(item.MfgSource, newItem.MfgSource);
            Assert.AreEqual(item.Msrp, newItem.Msrp);
            Assert.AreEqual(item.MsrpCad, newItem.MsrpCad);
            Assert.AreEqual(item.MsrpMxn, newItem.MsrpMxn);
            Assert.AreEqual(item.ProductFormat, newItem.ProductFormat);
            Assert.AreEqual(item.ProductGroup, newItem.ProductGroup);
            Assert.AreEqual(item.ReturnProductIdTranslations(), newItem.ReturnProductIdTranslations());
            Assert.AreEqual(item.ProductLine, newItem.ProductLine);
            Assert.AreEqual(item.ProductQty, newItem.ProductQty);
            Assert.AreEqual(item.Property, newItem.Property);
            Assert.AreEqual(item.PricingGroup, newItem.PricingGroup);
            Assert.AreEqual(item.PrintOnDemand, newItem.PrintOnDemand);
            Assert.AreEqual(item.PsStatus, newItem.PsStatus);
            Assert.AreEqual(item.ShortDescription, newItem.ShortDescription);
            Assert.AreEqual(item.Size, newItem.Size);
            Assert.AreEqual(item.StandardCost, newItem.StandardCost);
            Assert.AreEqual(item.StatsCode, newItem.StatsCode);
            Assert.AreEqual(item.TariffCode, newItem.TariffCode);
            Assert.AreEqual(item.Territory, newItem.Territory);
            Assert.AreEqual(item.Title, newItem.Title);
            Assert.AreEqual(item.Udex, newItem.Udex);
            Assert.AreEqual(item.Upc, newItem.Upc);
            Assert.AreEqual(item.WebsitePrice, newItem.WebsitePrice);
            Assert.AreEqual(item.Weight, newItem.Weight);
            Assert.AreEqual(item.Width, newItem.Width);

            #endregion // Assert
        }
    }
}
