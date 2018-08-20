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

            
            ItemObject item = new ItemObject();

            item.Status = "Add";
            item.AccountingGroup = "DOODLE";
            item.CasepackHeight = "8";
            item.CasepackLength = "8";
            item.CasepackQty = "9";
            item.CasepackUpc = "12345678";
            item.CasepackWidth = "8";
            item.CasepackWeight = "8";
            item.Category = "CALENDAR";
            item.Color = "RED";
            item.Copyright = "Copyright Stuff";
            item.CostProfileGroup = "ACTUAL_FIFO";
            item.CountryOfOrigin = "USA";
            item.DefaultActualCostCad = "2.00";
            item.DefaultActualCostUsd = "2.99";
            item.Description = "description";
            item.DirectImport = "directImport";
            item.Ean = "ean";
            item.Duty = "duty";
            item.Gpc = "gpc";
            item.Height = "1";
            item.InnerpackHeight = "5";
            item.InnerpackLength = "5";
            item.InnerpackQuantity = "7";
            item.InnerpackUpc = "12345678";
            item.InnerpackWidth = "5";
            item.InnerpackWeight = "5";
            item.InStockDate = "5/17/2000";
            item.Isbn = "isbn";
            item.ItemCategory = "POSTER";
            item.ItemFamily = "FLAT";
            item.ItemGroup = "BOX";
            item.ItemId = "RPTEST";
            item.ItemKeywords = "itemKeywords";
            item.Language = "ENG";
            item.Length = "5";
            item.License = "Disney";
            item.LicenseBeginDate = "12/13/2016";
            item.ListPriceCad = "4.99";
            item.ListPriceUsd = "2.99";
            item.ListPriceMxn = "1.99";
            item.MetaDescription = "metaDescription";
            item.MfgSource = "2";
            item.Msrp = "5.99";
            item.MsrpCad = "6.99";
            item.ProductGroup = "Posters";
            item.ProductLine = "Posters";
            item.ProductFormat = "Door";
            item.PricingGroup = "GROUP1";
            item.ShortDescription = "A Short Description";
            item.StandardCost = "2.99";
            item.StatsCode = "MARCA3";
            item.TariffCode = "1234";
            item.Territory = "USA";
            item.Title = "title";
            item.Udex = "udex";
            item.Upc = "000999888777";
            item.WebsitePrice = "4.50";
            item.Weight = "4";
            item.Width = "2";

            item.Ecommerce_Asin = "asin";
            item.Ecommerce_Bullet1 = "bullet 1111";
            item.Ecommerce_Bullet2 = "bullet 2222";
            item.Ecommerce_Bullet3 = "bullet 3333";
            item.Ecommerce_Bullet4 = "bullet 4444";
            item.Ecommerce_Bullet5 = "";
            item.Ecommerce_Components = "components^";
            item.Ecommerce_Cost = "2.00";
            item.Ecommerce_ExternalId = "12345678";
            item.Ecommerce_ExternalIdType = "UPC";
            item.Ecommerce_ImagePath1 = "12345";
            item.Ecommerce_ImagePath2 = "";
            item.Ecommerce_ImagePath3 = "12345";
            item.Ecommerce_ImagePath4 = "";
            item.Ecommerce_ImagePath5 = "12345";
            item.Ecommerce_ItemHeight = "3";
            item.Ecommerce_ItemLength = "4";
            item.Ecommerce_ItemName = "Name";
            item.Ecommerce_ItemWeight = "4";
            item.Ecommerce_ItemWidth = "5";
            item.Ecommerce_ModelName = "Model Name";
            item.Ecommerce_PackageHeight = "2.12";
            item.Ecommerce_PackageLength = "2";
            item.Ecommerce_PackageWeight = "33.7";
            item.Ecommerce_PackageWidth = "24.4";
            item.Ecommerce_PageQty = "24";
            item.Ecommerce_ProductCategory = "pCats";
            item.Ecommerce_ProductDescription = "pDesc this gets a lot of extra words now that the description has to have at least 100 characters in it. Why stop at 100? Why not 1,000,000,000?";
            item.Ecommerce_ProductSubcategory = "subby";
            item.Ecommerce_ManufacturerName = "mrName";
            item.Ecommerce_Msrp = "12.33";
            item.Ecommerce_SearchTerms = "search search searcharina";
            item.Ecommerce_Size = "22'' x 22''";
            item.Ecommerce_Upc = "123456789129";

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
            Assert.AreEqual("", itemViewModel.Ecommerce_SearchTermsError);
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

            ItemObject item = new ItemObject();
            item.SellOnAmazon = "Y";
            item.Ecommerce_Asin = "";
            item.Ecommerce_Bullet1 = "";
            item.Ecommerce_Bullet2 = "";
            item.Ecommerce_Bullet3 = "";
            item.Ecommerce_Bullet4 = "";
            item.Ecommerce_Bullet5 = "";
            item.Ecommerce_Components = "";
            item.Ecommerce_Cost = "";
            item.Ecommerce_ExternalId = "";
            item.Ecommerce_ExternalIdType = "";
            item.Ecommerce_ImagePath1 = "";
            item.Ecommerce_ImagePath2 = "";
            item.Ecommerce_ImagePath3 = "";
            item.Ecommerce_ImagePath4 = "";
            item.Ecommerce_ImagePath5 = "";
            item.Ecommerce_ItemHeight = "";
            item.Ecommerce_ItemLength = "";
            item.Ecommerce_ItemName = "";
            item.Ecommerce_ItemWeight = "";
            item.Ecommerce_ItemWidth = "";
            item.Ecommerce_ModelName = "";
            item.Ecommerce_PackageHeight = "";
            item.Ecommerce_PackageLength = "";
            item.Ecommerce_PackageWeight = "";
            item.Ecommerce_PackageWidth = "";
            item.Ecommerce_ProductCategory = "";
            item.Ecommerce_ProductDescription = "";
            item.Ecommerce_ProductSubcategory = "";
            item.Ecommerce_ManufacturerName = "";
            item.Ecommerce_Msrp = "";
            item.Ecommerce_SearchTerms = "";
            item.Ecommerce_Size = "";

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
            Assert.AreNotEqual("", itemViewModel.Ecommerce_SearchTermsError);
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

            ItemObject item1 = new ItemObject();
            item1.Ecommerce_Bullet1 = "Bullet1";


            #endregion // Setup

            #region Act

            ItemViewModel itemViewModel1 = new ItemViewModel(item1, itemService, new List<string>());
            itemViewModel1.SellOnAmazon = "Y";

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
            ItemObject item = new ItemObject();
            item.Ecommerce_Bullet1 = "Rickity Recked";
            item.SellOnFanatics = "Y";
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
            ItemObject item = new ItemObject();
            item.ShortDescription = "OoOoOo BoYeE";
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
            
            ItemObject item = new ItemObject();
            item.SellOnAmazon = "Y";
            item.Ecommerce_Bullet1 = "My Porcelin Horse!";
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());
            #endregion // Assign

            #region Act

            bool result1 = itemViewModel.ItemViewModelItem.HasEcommerce();
            itemViewModel.SellOnAmazon = "N";
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
            ItemObject item = new ItemObject();
            item.SellOnTrends = "Y";
            item.ItemKeywords = "";
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemViewModel itemViewModel = new ItemViewModel(item, itemService, new List<string>());
            item.SellOnTrends = "N";
            item.ItemKeywords = "";
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
            ItemObject item = new ItemObject();
            item.SellOnTrends = "Y";
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
            item.Ecommerce_SearchTerms = "Ecommerce_SearchTerms";
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
            Assert.AreEqual(itemViewModel.Ecommerce_SearchTerms, "Ecommerce_SearchTerms");
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
            
            List<ChildElement> billOfMaterials = new List<ChildElement>();
            billOfMaterials.Add(new ChildElement("ST1111", "ST9999", 1));
            billOfMaterials.Add(new ChildElement("ST2222", "ST9999", 2));
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            List<ChildElement> PID = new List<ChildElement>();
            ChildElement PID1 = new ChildElement("ST1111", "ST9999", 5);
            ChildElement PID2 = new ChildElement("ST2222", "ST9999", 1);
            PID.Add(PID1);
            PID.Add(PID2);
            List<string> itemIds = new List<string>();
            itemIds.Add("");
            ItemObject item = new ItemObject(
                "Add",
                "", 
                "", 
                "", 
                "",
                
                "Accounting Group",
                billOfMaterials,
                "1",
                "2",
                "3",
                "999999999999",
                "77",
                "34",
                "Bookmarks",
                "Paper Craft",
                "Paper Craft: Stickers",
                "Color",
                "Copyright",
                "USA",
                "Cost Profile Group",
                "4.99",
                "8.00",
                "Description",
                "Y",
                "9",
                "EAN", "ASIN",
                "Bullet 1",
                "Bullet 2",
                "Bullet 3",
                "Bullet 4",
                "Bullet 5",
                "Components",
                "5.99",
                "000000000000",
                "UPC",
                "5",
                "4",
                "Item Name",
                "9",
                "5",
                "Model Name",
                "5",
                "4",
                "1",
                "2",
                "3",
                "Product Category",
                "Product Description",
                "Product Subcategory",
                "Manufacturer Name",
                "9.99",
                "Search Terms",
                "8",
                "ecommerceUpc",
                "gpc",
                "2",
                "imagePath",
                "2",
                "34",
                "90",
                "019283746547",
                "14",
                "52",
                "",
                "ISBN",
                "Item Category",
                "Item Family",
                "item group",
                "TestItem2",
                "Item Keywords",
                "ENG",
                "91",
                "License",
                "",
                "9.99",
                "7.99",
                "2.22",
                "Meta Description",
                "mfgSource",
                "7.77",
                "19.99",
                "1.99",
                "Product Format",
                "Product Group",
                PID,
                "Product Line",
                "4",
                "Property",
                "Pricing Group",
                "Y",
                "A",
                "111",
                "N",
                "N",
                "N",
                "N",
                "N",
                "N",
                "N",
                "N",
                "N",
                "Short Description",
                "size",
                "5.00",
                "statsCode",
                "tariffCode",
                "USA",
                "title",
                "udex",
                "000000000000",
                "4.99",
                "2",
                "1"
                );

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
            Assert.AreEqual(item.Ecommerce_SearchTerms, newItem.Ecommerce_SearchTerms);
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
