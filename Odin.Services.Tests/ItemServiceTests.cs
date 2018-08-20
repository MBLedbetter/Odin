using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Odin.Data;
using OdinServices;
using Odin.Services.Tests.Helpers;
using System.Collections.Generic;
using OdinModels;
using System.Collections.ObjectModel;

namespace Odin.Services.Tests
{
    [TestClass]
    public class ItemServiceTests
    {
        /// <summary>
        ///     Checks that AssignDirectImport returns valid values when proper values are assigned.
        /// </summary>
        [TestMethod]
        public void ItemServiceTests_CreateEcommerce_ImageUrl_ShouldCreateNewFilePath()
        {
            #region Assemble

            ItemObject item = new ItemObject();
            string x = @"\\isiloncifs\Store 2\•CAPTURES\Poster Captures\1000\1300 - POTC 4.4 - 3.4 Black Beard_4x6.TIFF";
            
            #endregion // Assemble

            #region Act

            string result1 = item.CreateEcommerce_ImageUrl(x);

            #endregion // Act

            #region Assert

            Assert.AreEqual("http://trendsinternational.com/media/catalog/product/1/3/1300 - POTC 4.4 - 3.4 Black Beard_4x6.jpg", result1);

            #endregion // Assert
        }
        
        /// <summary>
        ///     Checks that AssignDirectImport returns valid values when proper values are assigned.
        /// </summary>
        [TestMethod]
        public void AssignDirectImport_HasValidValue_ShouldReturnValidValue()
        {
            #region Assemble

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion // Assemble

            #region Act

            string result1 = itemService.AssignDirectImport("");
            string result2 = itemService.AssignDirectImport("Y");
            string result3 = itemService.AssignDirectImport("N");

            #endregion // Act

            #region Assert

            Assert.AreEqual(result1, "N");
            Assert.AreEqual(result2, "Y");
            Assert.AreEqual(result3, "N");

            #endregion // Assert
        }

        /// <summary>
        ///     Checks that AssignDirectImport returns valid values when proper values are assigned.
        /// </summary>
        [TestMethod]
        public void AssignDirectImport_HasInvalidValue_ShouldReturnInvalidValue()
        {
            #region Assemble
            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion // Assemble

            #region Act

            string result1 = itemService.AssignDirectImport("X");
            string result2 = itemService.AssignDirectImport("Pizza");
            string result3 = itemService.AssignDirectImport("true");

            #endregion // Act

            #region Assert

            Assert.AreEqual(result1, "X");
            Assert.AreEqual(result2, "Pizza");
            Assert.AreEqual(result3, "true");

            #endregion // Assert
        }

        [TestMethod]
        public void CategoryInsert_GivenProperCategoryValues_ShouldReturnValidWebCategoryIdString()
        {
            #region Assemble
            GlobalData.ClearValues();
            TestItemRepository testItemRepository = new TestItemRepository();
            GlobalData.ClearValues();
            testItemRepository.RetrieveGlobalData();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), testItemRepository, new TestTemplateRepository());
            
            string value1 = "Category1";
            string value2 = "Category2";
            string value3 = "Category3";

            #endregion // Assemble

            #region Act

            string returnValue = testItemRepository.CombineCategories(value1, value2, value3);
            #endregion // Act

            #region Assert
            Assert.AreEqual("1,2,3", returnValue);

            #endregion // Assert
        }

        [TestMethod]
        public void CategoryRemoveDuplicates_ItemHasThreeValues_ShouldReturnFilteredValue()
        {
            #region Assemble

            GlobalData.ClearValues();
            TestItemRepository itemRepository = new TestItemRepository();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), itemRepository, new TestTemplateRepository());

            string value1 = "Posters: Wall Posters: Movies";
            string value2 = "Posters: What's New";
            string value3 = "Posters: Wall Posters: Super Hero";


            #endregion // Assemble

            #region Act

            string result = itemService.RemoveDuplicateCategories(value1, value2, value3);

            #endregion // Act

            #region Assert

            Assert.AreEqual(result, "Posters|Posters=>Wall Posters|Posters=>Wall Posters=>Movies|Posters=>What's New|Posters=>Wall Posters=>Super Hero");

            #endregion // Assert
        }

        /// <summary>
        ///     Tests that the itemObj Helper organizes different territory inputs to match validation.
        /// </summary>
        [TestMethod]
        public void CheckAlphabetize_AlphabetizeValues_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            TestItemRepository itemRepository = new TestItemRepository();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), itemRepository, new TestTemplateRepository());
            List<string> StartList = new List<string>();
            List<string> AlphaList = new List<string>();
            StartList.Add("Bookmarks");
            StartList.Add("Posters");
            StartList.Add("Stationery");
            StartList.Add("Paper Craft");
            StartList.Add("Stickers");

            #endregion // Setup

            #region Act

            AlphaList = DbUtil.Alphabetize(StartList);

            #endregion // Act

            #region Assert

            Assert.AreEqual(AlphaList[0], "Bookmarks");
            Assert.AreEqual(AlphaList[1], "Paper Craft");
            Assert.AreEqual(AlphaList[2], "Posters");
            Assert.AreEqual(AlphaList[3], "Stationery");
            Assert.AreEqual(AlphaList[4], "Stickers");


            #endregion // Assert
        }

        /// <summary>
        ///     Tests that when an ecommerce image file is updated the alt image file paths are updated to reflect the change
        /// </summary>
        [TestMethod]
        public void CheckAltImageUpdate_EcommerceImageUpdated_ShouldTriggerUpdateFlag()
        {
            #region Assemble
            ItemObject item = new ItemObject();
            item.Ecommerce_ImagePath1 = "1/2/3/img1.jpg";
            item.Ecommerce_ImagePath2 = "1/2/3/img2.jpg";
            item.ResetUpdate();
            #endregion // Assemble

            #region Act

            item.Ecommerce_ImagePath1 = "1/2/3/img5.jpg";

            #endregion // Act

            #region Assert

            Assert.IsTrue(item.Ecommerce_ImagePath1Update);
            Assert.IsFalse(item.Ecommerce_ImagePath2Update);
            Assert.IsFalse(item.AltImageFile1Update);

            #endregion // Assert
        }

        [TestMethod]
        public void CheckCompleteItem_ReturnsProperValues_ShouldSucceed()
        {
            #region Setup
            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemObject item = new ItemObject();
            item.ItemId = "ItemIdA";

            #endregion // Setup

            #region Act

            ItemObject completeItem = itemService.CompleteItem(item, 1);

            #endregion // Act

            #region Assert

            Assert.AreEqual("ItemIdA", completeItem.ItemId);
            Assert.AreEqual("AccountingGroupA", completeItem.AccountingGroup);
            Assert.AreEqual("CasepackHeightA", completeItem.CasepackHeight);
            Assert.AreEqual("CasepackLengthA", completeItem.CasepackLength);
            Assert.AreEqual("CasepackQtyA", completeItem.CasepackQty);
            Assert.AreEqual("CasepackWidthA", completeItem.CasepackWidth);
            Assert.AreEqual("CasepackWeightA", completeItem.CasepackWeight);
            Assert.AreEqual("Category1", completeItem.Category);
            Assert.AreEqual("ColorA", completeItem.Color);
            Assert.AreEqual("CopyrightA", completeItem.Copyright);
            Assert.AreEqual("CostProfileGroupA", completeItem.CostProfileGroup);
            Assert.AreEqual("CountryOfOriginA", completeItem.CountryOfOrigin);
            Assert.AreEqual("DefaultActualCostCadA", completeItem.DefaultActualCostCad);
            Assert.AreEqual("DefaultActualCostUsdA", completeItem.DefaultActualCostUsd);
            Assert.AreEqual("DescriptionA", completeItem.Description);
            Assert.AreEqual("DirectImportA", completeItem.DirectImport);
            Assert.AreEqual("EanA", completeItem.Ean);
            Assert.AreEqual("DutyA", completeItem.Duty);
            Assert.AreEqual("GpcA", completeItem.Gpc);
            Assert.AreEqual("HeightA", completeItem.Height);
            Assert.AreEqual("InnerpackHeightA", completeItem.InnerpackHeight);
            Assert.AreEqual("InnerpackLengthA", completeItem.InnerpackLength);
            Assert.AreEqual("InnerpackQuantityA", completeItem.InnerpackQuantity);
            Assert.AreEqual("InnerpackWidthA", completeItem.InnerpackWidth);
            Assert.AreEqual("InnerpackWeightA", completeItem.InnerpackWeight);
            Assert.AreEqual("InStockDateA", completeItem.InStockDate);
            Assert.AreEqual("IsbnA", completeItem.Isbn);
            Assert.AreEqual("ItemCategoryA", completeItem.ItemCategory);
            Assert.AreEqual("ItemFamilyA", completeItem.ItemFamily);
            Assert.AreEqual("ItemGroupA", completeItem.ItemGroup);
            Assert.AreEqual("ItemKeywordsA", completeItem.ItemKeywords);
            Assert.AreEqual("LanguageA", completeItem.Language);
            Assert.AreEqual("LengthA", completeItem.Length);
            Assert.AreEqual("LicenseA", completeItem.License);
            Assert.AreEqual("LicenseBeginDateA", completeItem.LicenseBeginDate);
            Assert.AreEqual("ListPriceCadA", completeItem.ListPriceCad);
            Assert.AreEqual("ListPriceUsdA", completeItem.ListPriceUsd);
            Assert.AreEqual("ListPriceMxnA", completeItem.ListPriceMxn);
            Assert.AreEqual("MetaDescriptionA", completeItem.MetaDescription);
            Assert.AreEqual("MfgSourceA", completeItem.MfgSource);
            Assert.AreEqual("MsrpUsdA", completeItem.Msrp);
            Assert.AreEqual("MsrpCadA", completeItem.MsrpCad);
            Assert.AreEqual("ProductGroupA", completeItem.ProductGroup);
            Assert.AreEqual("ProductLineA", completeItem.ProductLine);
            Assert.AreEqual("ProductFormatA", completeItem.ProductFormat);
            Assert.AreEqual("PricingGroupA", completeItem.PricingGroup);
            Assert.AreEqual("ShortDescriptionA", completeItem.ShortDescription);
            Assert.AreEqual("StandardCostA", completeItem.StandardCost);
            Assert.AreEqual("StatsCodeA", completeItem.StatsCode);
            Assert.AreEqual("TariffCodeA", completeItem.TariffCode);
            Assert.AreEqual("TerritoryA", completeItem.Territory);
            Assert.AreEqual("TitleA", completeItem.Title);
            Assert.AreEqual("UdexA", completeItem.Udex);
            Assert.AreEqual("UpcA", completeItem.Upc);
            Assert.AreEqual("WeightA", completeItem.Weight);
            Assert.AreEqual("WidthA", completeItem.Width);
            Assert.AreEqual("AAsinA", completeItem.Ecommerce_Asin);
            Assert.AreEqual("ABullet1A", completeItem.Ecommerce_Bullet1);
            Assert.AreEqual("ABullet2A", completeItem.Ecommerce_Bullet2);
            Assert.AreEqual("ABullet3A", completeItem.Ecommerce_Bullet3);
            Assert.AreEqual("ABullet4A", completeItem.Ecommerce_Bullet4);
            Assert.AreEqual("ABullet5A", completeItem.Ecommerce_Bullet5);
            Assert.AreEqual("AComponentsA", completeItem.Ecommerce_Components);
            Assert.AreEqual("ACostA", completeItem.Ecommerce_Cost);
            Assert.AreEqual("AExternalIdA", completeItem.Ecommerce_ExternalId);
            Assert.AreEqual("AExternalIdTypeA", completeItem.Ecommerce_ExternalIdType);
            Assert.AreEqual("http://trendsinternational.com/media/catalog/product/I/m/ImagePathA.jpg", completeItem.Ecommerce_ImagePath1);
            Assert.AreEqual("http://trendsinternational.com/media/catalog/product/A/l/AltImageFile1A.jpg", completeItem.Ecommerce_ImagePath2);
            Assert.AreEqual("http://trendsinternational.com/media/catalog/product/A/l/AltImageFile2A.jpg", completeItem.Ecommerce_ImagePath3);
            Assert.AreEqual("http://trendsinternational.com/media/catalog/product/A/l/AltImageFile3A.jpg", completeItem.Ecommerce_ImagePath4);
            Assert.AreEqual("http://trendsinternational.com/media/catalog/product/A/l/AltImageFile4A.jpg", completeItem.Ecommerce_ImagePath5);
            Assert.AreEqual("AItemHeightA", completeItem.Ecommerce_ItemHeight);
            Assert.AreEqual("AItemLengthA", completeItem.Ecommerce_ItemLength);
            Assert.AreEqual("AItemNameA", completeItem.Ecommerce_ItemName);
            Assert.AreEqual("AItemWeightA", completeItem.Ecommerce_ItemWeight);
            Assert.AreEqual("AItemWidthA", completeItem.Ecommerce_ItemWidth);
            Assert.AreEqual("AModelNameA", completeItem.Ecommerce_ModelName);
            Assert.AreEqual("APackageHeightA", completeItem.Ecommerce_PackageHeight);
            Assert.AreEqual("APackageLengthA", completeItem.Ecommerce_PackageLength);
            Assert.AreEqual("APackageWeightA", completeItem.Ecommerce_PackageWeight);
            Assert.AreEqual("APackageWidthA", completeItem.Ecommerce_PackageWidth);
            Assert.AreEqual("APageQtyA", completeItem.Ecommerce_PageQty);
            Assert.AreEqual("AProductCategoryA", completeItem.Ecommerce_ProductCategory);
            Assert.AreEqual("AProductDescriptionA", completeItem.Ecommerce_ProductDescription);
            Assert.AreEqual("AProductSubcategoryA", completeItem.Ecommerce_ProductSubcategory);
            Assert.AreEqual("AManufacturerNameA", completeItem.Ecommerce_ManufacturerName);
            Assert.AreEqual("AMsrpA", completeItem.Ecommerce_Msrp);
            Assert.AreEqual("ASearchTermsA", completeItem.Ecommerce_SearchTerms);
            Assert.AreEqual("ASizeA", completeItem.Ecommerce_Size);
            Assert.AreEqual("SellOnAmazonA", completeItem.SellOnAmazon);
            Assert.AreEqual("SellOnFanaticsA", completeItem.SellOnFanatics);
            Assert.AreEqual("SellOnGuitarCenterA", completeItem.SellOnGuitarCenter);
            Assert.AreEqual("SellOnAllPostersA", completeItem.SellOnAllPosters);
            Assert.AreEqual("SellOnHayneedleA", completeItem.SellOnHayneedle);
            Assert.AreEqual("SellOnTargetA", completeItem.SellOnTarget);
            Assert.AreEqual("SellOnTrendsA", completeItem.SellOnTrends);
            Assert.AreEqual("SellOnWalmartA", completeItem.SellOnWalmart);
            Assert.AreEqual("SellOnWayfairA", completeItem.SellOnWayfair);


            #endregion // Assert
        }

        /// <summary>
        ///     Tests that the Order Language function properly orders the Languages into the correct uniform order
        /// </summary>
        [TestMethod]
        public void CheckOrderLanguage_ValidValuesToOrder_ShouldPass()
        {
            #region Setup


            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            string Language1 = "FRA/ENG";
            string Language2 = "ENG/FRE";
            string Language3 = "SPA/ENG";
            string Language4 = "FRE/ENG/SPA";
            string Language5 = "SPA/FRE";


            #endregion // Setup

            #region Act

            string result1 = DbUtil.OrderLanguage(Language1);
            string result2 = DbUtil.OrderLanguage(Language2);
            string result3 = DbUtil.OrderLanguage(Language3);
            string result4 = DbUtil.OrderLanguage(Language4);
            string result5 = DbUtil.OrderLanguage(Language5);

            #endregion // Act

            #region Assert

            Assert.AreEqual("ENG/FRA", result1);
            Assert.AreEqual("ENG/FRA", result2);
            Assert.AreEqual("ENG/SPA", result3);
            Assert.AreEqual("ENG/FRA/SPA", result4);
            Assert.AreEqual("FRA/SPA", result5);

            #endregion // Assert
        }

        /// <summary>
        ///     Tests that the Order Territory function properly orders the territories into the correct uniform order
        /// </summary>
        [TestMethod]
        public void CheckOrderTerritory_ValidValuesToOrder_ShouldPass()
        {
            #region Setup


            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            string Territory1 = "CAN/USA";
            string Territory2 = "USA/CAN";
            string Territory3 = "MEX/USA";
            string Territory4 = "CAN/USA/MEX";
            string Territory5 = "MEX/CAN";


            #endregion // Setup

            #region Act

            string result1 = DbUtil.OrderTerritory(Territory1);
            string result2 = DbUtil.OrderTerritory(Territory2);
            string result3 = DbUtil.OrderTerritory(Territory3);
            string result4 = DbUtil.OrderTerritory(Territory4);
            string result5 = DbUtil.OrderTerritory(Territory5);

            #endregion // Act

            #region Assert

            Assert.AreEqual(result1, "USA/CAN");
            Assert.AreEqual(result2, "USA/CAN");
            Assert.AreEqual(result3, "USA/MEX");
            Assert.AreEqual(result4, "USA/CAN/MEX");
            Assert.AreEqual(result5, "CAN/MEX");

            #endregion // Assert
        }
        
        [TestMethod]
        public void CheckDuplicateUPCs_UPCHasMatch_ShouldReturnTrue()
        {
            #region Assemble
            GlobalData.ClearValues();

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("123456789123", "RP2332"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("123456789124", "RP3322"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("123456789127", "RP3323"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("000000000000", "RP1234"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("000000000001", "RP1111WM"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("000000000002", "RP2222MI"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("000000000003", "RP3333TG"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("000000000004", "RP4444DI"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("000000000005", "RP9999"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("000000000006", "RP8888"));

            #endregion // Assemble

            #region Act

            string result1 = "1";
            string result2 = "2";
            string result3 = "3";
            string result4 = "4";
            string result5 = "5";
            string result6 = "6";
            if (itemService.CheckDuplicateUPCs("RP9980", "000000000000", "Add").Count > 0)
            {
                result1 = "error1";
            }
            if (itemService.CheckDuplicateUPCs("RP1111", "000000000001", "Add").Count > 0)
            {
                result2 = "error2";
            }
            if (itemService.CheckDuplicateUPCs("RP4325", "000000000002", "Add").Count > 0)
            {
                result3 = "error3";
            }
            if (itemService.CheckDuplicateUPCs("RP9999DI", "000000000005", "Update").Count > 0)
            {
                result4 = itemService.CheckDuplicateUPCs("RP9999DI", "000000000005", "Update")[0];
            }
            if (itemService.CheckDuplicateUPCs("RP1111TG", "000000000001", "Add").Count > 0)
            {
                result5 = "error5";
            }
            if (itemService.CheckDuplicateUPCs("RP1343", "123456789123", "Add").Count > 0)
            {
                result6 = "error6";
            }
            #endregion // Act

            #region Assert

            Assert.AreEqual("error1", result1);
            Assert.AreEqual("2", result2);
            Assert.AreEqual("error3", result3);
            Assert.AreEqual("4", result4);
            Assert.AreEqual("5", result5);
            Assert.AreEqual("error6", result6);

            #endregion // Assert
        }

        [TestMethod]
        public void CheckOrderLine_MultipleOrderStatus_ResultsVary()
        {
            #region Assemble

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            
            #endregion // Assemble

            #region Act

            bool result1 = itemService.CheckItemHasOpenOrderLine("RP1111");
            bool result3 = itemService.CheckItemHasOpenOrderLine("OpenOrder");

            #endregion // Act

            #region Assert

            Assert.IsTrue(result1);
            Assert.IsFalse(result3);

            #endregion // Assert

        }
        
        /// <summary>
        ///     Tests that the itemObj Helper organizes different territory inputs to match validation.
        /// </summary>
        [TestMethod]
        public void ChecForWeb_ItemMissingInfo_ShouldFail()
        {
            #region Setup

            ItemObject item = new ItemObject();
            ItemObject item2 = new ItemObject();
            item.ItemId = "ST5555";
            item.ItemKeywords = "Sticker, Bears";
            item.SellOnTrends = "N";
            item2.ItemId = "ST5555";
            item2.ItemKeywords = "Sticker, Bears";
            item2.SellOnTrends = "Y";


            #endregion // Setup

            #region Act


            #endregion // Act

            #region Assert

            Assert.IsFalse(item.HasWeb());
            Assert.AreEqual("N", item.SellOnTrends);
            Assert.IsTrue(item2.HasWeb());

            #endregion // Assert
        }

        [TestMethod]
        public void CheckHeaderList_ReturnsAllHeaders_ShouldPass()
        {
            #region Setup

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion // Setup

            #region Act

            List<string> headerList = itemService.ReturnHeaderValues();

            #endregion // Act

            #region Assert

            Assert.AreEqual(headerList[0], "ACCOUNTINGGROUP");
            Assert.AreEqual(headerList[19], "DACCAD");

            #endregion // Assert
        }

        /// <summary>
        ///     Tests that the IdExists function properly detects when an itemID already exists.
        /// </summary>
        [TestMethod]
        public void CheckIdDoesNotExist_ItemIdDoesNotExistInDb_ShouldFail()
        {
            #region Setup


            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            string ItemId = "ST5674";


            #endregion // Setup

            #region Act

            bool result = itemService.CheckForExistsingItemId(ItemId);

            #endregion // Act

            #region Assert

            Assert.IsFalse(result);

            #endregion // Assert
        }

        [TestMethod]
        public void CheckIdExists_ItemIdExistsInDb_ShouldPass()
        {
            #region Setup
            
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            GlobalData.ItemIds.Add("ST5678");
            string ItemId = "ST5678";


            #endregion // Setup

            #region Act

            bool result = itemService.CheckForExistsingItemId(ItemId);

            #endregion // Act

            #region Assert

            Assert.IsTrue(result);

            #endregion // Assert
        }
        
        [TestMethod]
        public void CompleteItemTest_CompleteItem_CompletedItemShouldHaveDBValues()
        {
            #region Assemble

            GlobalData.ClearValues();
            ItemService ItemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemObject newItem = new ItemObject();
            newItem.ItemId = "ItemIdB";

            #endregion // Assemble

            #region Act

            ItemObject CompleteItem = ItemService.CompleteItem(newItem, 1);

            #endregion // Act

            #region Assert

            Assert.AreEqual("ItemGroupB", CompleteItem.ItemGroup);

            #endregion // Assert
        }

        [TestMethod]
        public void CompleteItemTest_TestFieldUpdateCheck_UpdatedFieldShouldShowTrue()
        {
            #region Assemble

            ItemService ItemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            ItemObject newItem = new ItemObject();
            newItem.ItemId = "ItemIdA";
            newItem.AccountingGroup = "test";

            #endregion // Assemble

            #region Act

            ItemObject CompleteItem = ItemService.CompleteItem(newItem, 1);

            #endregion // Act

            #region Assert

            Assert.AreEqual("ItemGroupA", CompleteItem.ItemGroup);
            Assert.IsTrue(CompleteItem.AccountingGroupUpdate);

            #endregion // Assert

        }

        [TestMethod]
        public void CompleteTemplate_HasUpdatedValues_EndValuesShouldMatch()
        {
            #region Assemble
            Template template = new Template(
                "TemplateId1",
                "accountingGroup9",
                "casepackHeight9",
                "casepackLength9",
                "casepackQty9",
                "casepackWidth9",
                "casepackWeight9",
                "category9",
                "category29",
                "category39",
                "copyright9",
                "costProfileGroup9",
                "defaultActualCostCad9",
                "defaultActualCostUsd9",
                "duty9",
                "gpc9",
                "height9",
                "innerpackHeight9",
                "innerpackLength9",
                "innerpackQuantity9",
                "innerpackWeight9",
                "innerpackWidth9",
                "itemCategory9",
                "itemFamily9",
                "itemGroup9",
                "length9",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "");
            Template template2 = new Template(
                "TemplateId1",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "listPriceCad9",
                "listPriceMxn9",
                "listPriceUsd9",
                "metaDescription9",
                "mfgSource9",
                "msrp9",
                "msrpCad9",
                "msrpMxn9",
                "productFormat9",
                "productGroup9",
                "productLine9",
                "productQty9",
                "pricingGroup9",
                "psStatus9",
                "size9",
                "tariffCode9",
                "udex9",
                "weight9",
                "width9",
                "ecommerceBullet19",
                "ecommerceBullet29",
                "ecommerceBullet39",
                "ecommerceBullet49",
                "ecommerceBullet59",
                "ecommerceComponents9",
                "ecommerceCost9",
                "ecommerceExternalIdType9",
                "ecommerceItemHeight9",
                "ecommerceItemLength9",
                "ecommerceItemWeight9",
                "ecommerceItemWidth9",
                "ecommerceModelName9",
                "ecommercePackageLength9",
                "ecommercePackageHeight9",
                "ecommercePackageWeight9",
                "ecommercePackageWidth9",
                "ecommercePageQty9",
                "ecommerceProductCategory9",
                "ecommerceProductDescription9",
                "ecommerceProductSubcategory9",
                "ecommerceManufacturerName9",
                "ecommerceMsrp9",
                "ecommerceSize9");
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());


            #endregion // Assemble

            #region Act

            Template result1 = itemService.CompleteTemplate(template);
            Template result2 = itemService.CompleteTemplate(template2);

            #endregion // Act

            #region Assert
            Assert.AreEqual("accountingGroup9", result1.AccountingGroup);
            Assert.AreEqual("casepackHeight9", result1.CasepackHeight);
            Assert.AreEqual("casepackLength9", result1.CasepackLength);
            Assert.AreEqual("casepackQty9", result1.CasepackQty);
            Assert.AreEqual("casepackWidth9", result1.CasepackWidth);
            Assert.AreEqual("casepackWeight9", result1.CasepackWeight);
            Assert.AreEqual("category9", result1.Category);
            Assert.AreEqual("category29", result1.Category2);
            Assert.AreEqual("category39", result1.Category3);
            Assert.AreEqual("copyright9", result1.Copyright);
            Assert.AreEqual("costProfileGroup9", result1.CostProfileGroup);
            Assert.AreEqual("defaultActualCostCad9", result1.DefaultActualCostCad);
            Assert.AreEqual("defaultActualCostUsd9", result1.DefaultActualCostUsd);
            Assert.AreEqual("duty9", result1.Duty);
            Assert.AreEqual("gpc9", result1.Gpc);
            Assert.AreEqual("height9", result1.Height);
            Assert.AreEqual("innerpackHeight9", result1.InnerpackHeight);
            Assert.AreEqual("innerpackLength9", result1.InnerpackLength);
            Assert.AreEqual("innerpackQuantity9", result1.InnerpackQuantity);
            Assert.AreEqual("innerpackWeight9", result1.InnerpackWeight);
            Assert.AreEqual("innerpackWidth9", result1.InnerpackWidth);
            Assert.AreEqual("itemCategory9", result1.ItemCategory);
            Assert.AreEqual("itemFamily9", result1.ItemFamily);
            Assert.AreEqual("itemGroup9", result1.ItemGroup);
            Assert.AreEqual("length9", result1.Length);
            Assert.AreEqual("TemplateListPriceCad1", result1.ListPriceCad);
            Assert.AreEqual("TemplateListPriceMxn1", result1.ListPriceMxn);
            Assert.AreEqual("TemplateListPriceUsd1", result1.ListPriceUsd);
            Assert.AreEqual(result1.MetaDescription, "TemplateMetaDescription1");
            Assert.AreEqual(result1.MfgSource, "TemplateMfgSource1");
            Assert.AreEqual(result1.Msrp, "TemplateMsrp1");
            Assert.AreEqual(result1.MsrpCad, "TemplateMsrpCad1");
            Assert.AreEqual(result1.MsrpMxn, "TemplateMsrpMxn1");
            Assert.AreEqual(result1.ProductFormat, "TemplateProductFormat1");
            Assert.AreEqual(result1.ProductGroup, "TemplateProductGroup1");
            Assert.AreEqual(result1.ProductLine, "TemplateProductLine1");
            Assert.AreEqual(result1.ProductQty, "TemplateProductQty1");
            Assert.AreEqual(result1.PricingGroup, "TemplatePricingGroup1");
            Assert.AreEqual(result1.Size, "TemplateSize1");
            Assert.AreEqual(result1.TariffCode, "TemplateTariffCode1");
            Assert.AreEqual(result1.Udex, "TemplateUdex1");
            Assert.AreEqual(result1.Weight, "TemplateWeight1");
            Assert.AreEqual(result1.Width, "TemplateWidth1");
            Assert.AreEqual(result1.EcommerceBullet1, "TemplateEcommerceBullet11");
            Assert.AreEqual(result1.EcommerceBullet2, "TemplateEcommerceBullet21");
            Assert.AreEqual(result1.EcommerceBullet3, "TemplateEcommerceBullet31");
            Assert.AreEqual(result1.EcommerceBullet4, "TemplateEcommerceBullet41");
            Assert.AreEqual(result1.EcommerceBullet5, "TemplateEcommerceBullet51");
            Assert.AreEqual(result1.EcommerceComponents, "TemplateEcommerceComponents1");
            Assert.AreEqual(result1.EcommerceCost, "TemplateEcommerceCost1");
            Assert.AreEqual(result1.EcommerceExternalIdType, "TemplateEcommerceExternalIdType1");
            Assert.AreEqual(result1.EcommerceItemHeight, "TemplateEcommerceItemHeight1");
            Assert.AreEqual(result1.EcommerceItemLength, "TemplateEcommerceItemLength1");
            Assert.AreEqual(result1.EcommerceItemWeight, "TemplateEcommerceItemWeight1");
            Assert.AreEqual(result1.EcommerceItemWidth, "TemplateEcommerceItemWidth1");
            Assert.AreEqual(result1.EcommerceModelName, "TemplateEcommerceModelName1");
            Assert.AreEqual(result1.EcommercePackageLength, "TemplateEcommercePackageLength1");
            Assert.AreEqual(result1.EcommercePackageHeight, "TemplateEcommercePackageHeight1");
            Assert.AreEqual(result1.EcommercePackageWeight, "TemplateEcommercePackageWeight1");
            Assert.AreEqual(result1.EcommercePackageWidth, "TemplateEcommercePackageWidth1");
            Assert.AreEqual(result1.EcommercePageQty, "TemplateEcommercePageQty1");
            Assert.AreEqual(result1.EcommerceProductCategory, "TemplateEcommerceProductCategory1");
            Assert.AreEqual(result1.EcommerceProductDescription, "TemplateEcommerceProductDescription1");
            Assert.AreEqual(result1.EcommerceProductSubcategory, "TemplateEcommerceProductSubcategory1");
            Assert.AreEqual(result1.EcommerceManufacturerName, "TemplateEcommerceManufacturerName1");
            Assert.AreEqual(result1.EcommerceMsrp, "TemplateEcommerceMsrp1");
            Assert.AreEqual(result1.EcommerceSize, "TemplateEcommerceSize1");
            Assert.AreEqual(result2.AccountingGroup, "TemplateAccountingGroup1");
            Assert.AreEqual(result2.CasepackHeight, "TemplateCasepackHeight1");
            Assert.AreEqual(result2.CasepackLength, "TemplateCasepackLength1");
            Assert.AreEqual(result2.CasepackQty, "TemplateCasepackQty1");
            Assert.AreEqual(result2.CasepackWidth, "TemplateCasepackWidth1");
            Assert.AreEqual(result2.CasepackWeight, "TemplateCasepackWeight1");
            Assert.AreEqual(result2.Category, "TemplateCategory1");
            Assert.AreEqual(result2.Category2, "TemplateCategory21");
            Assert.AreEqual(result2.Category3, "TemplateCategory31");
            Assert.AreEqual(result2.Copyright, "TemplateCopyright1");
            Assert.AreEqual(result2.CostProfileGroup, "TemplateCostProfileGroup1");
            Assert.AreEqual(result2.DefaultActualCostCad, "TemplateDefaultActualCostCad1");
            Assert.AreEqual(result2.DefaultActualCostUsd, "TemplateDefaultActualCostUsd1");
            Assert.AreEqual(result2.Duty, "TemplateDuty1");
            Assert.AreEqual(result2.Gpc, "TemplateGpc1");
            Assert.AreEqual(result2.Height, "TemplateHeight1");
            Assert.AreEqual(result2.InnerpackHeight, "TemplateInnerpackHeight1");
            Assert.AreEqual(result2.InnerpackLength, "TemplateInnerpackLength1");
            Assert.AreEqual(result2.InnerpackQuantity, "TemplateInnerpackQuantity1");
            Assert.AreEqual(result2.InnerpackWeight, "TemplateInnerpackWeight1");
            Assert.AreEqual(result2.InnerpackWidth, "TemplateInnerpackWidth1");
            Assert.AreEqual(result2.ItemCategory, "TemplateItemCategory1");
            Assert.AreEqual(result2.ItemFamily, "TemplateItemFamily1");
            Assert.AreEqual(result2.ItemGroup, "TemplateItemGroup1");
            Assert.AreEqual(result2.Length, "TemplateLength1");
            Assert.AreEqual(result2.ListPriceCad, "listPriceCad9");
            Assert.AreEqual(result2.ListPriceMxn, "listPriceMxn9");
            Assert.AreEqual(result2.ListPriceUsd, "listPriceUsd9");
            Assert.AreEqual(result2.MetaDescription, "metaDescription9");
            Assert.AreEqual(result2.MfgSource, "mfgSource9");
            Assert.AreEqual(result2.Msrp, "msrp9");
            Assert.AreEqual(result2.MsrpCad, "msrpCad9");
            Assert.AreEqual(result2.MsrpMxn, "msrpMxn9");
            Assert.AreEqual(result2.ProductFormat, "productFormat9");
            Assert.AreEqual(result2.ProductGroup, "productGroup9");
            Assert.AreEqual(result2.ProductLine, "productLine9");
            Assert.AreEqual(result2.ProductQty, "productQty9");
            Assert.AreEqual(result2.PricingGroup, "pricingGroup9");
            Assert.AreEqual(result2.Size, "size9");
            Assert.AreEqual(result2.TariffCode, "tariffCode9");
            Assert.AreEqual(result2.Udex, "udex9");
            Assert.AreEqual(result2.Weight, "weight9");
            Assert.AreEqual(result2.Width, "width9");
            Assert.AreEqual(result2.EcommerceBullet1, "ecommerceBullet19");
            Assert.AreEqual(result2.EcommerceBullet2, "ecommerceBullet29");
            Assert.AreEqual(result2.EcommerceBullet3, "ecommerceBullet39");
            Assert.AreEqual(result2.EcommerceBullet4, "ecommerceBullet49");
            Assert.AreEqual(result2.EcommerceBullet5, "ecommerceBullet59");
            Assert.AreEqual(result2.EcommerceComponents, "ecommerceComponents9");
            Assert.AreEqual(result2.EcommerceCost, "ecommerceCost9");
            Assert.AreEqual(result2.EcommerceExternalIdType, "ecommerceExternalIdType9");
            Assert.AreEqual(result2.EcommerceItemHeight, "ecommerceItemHeight9");
            Assert.AreEqual(result2.EcommerceItemLength, "ecommerceItemLength9");
            Assert.AreEqual(result2.EcommerceItemWeight, "ecommerceItemWeight9");
            Assert.AreEqual(result2.EcommerceItemWidth, "ecommerceItemWidth9");
            Assert.AreEqual(result2.EcommerceModelName, "ecommerceModelName9");
            Assert.AreEqual(result2.EcommercePackageLength, "ecommercePackageLength9");
            Assert.AreEqual(result2.EcommercePackageHeight, "ecommercePackageHeight9");
            Assert.AreEqual(result2.EcommercePackageWeight, "ecommercePackageWeight9");
            Assert.AreEqual(result2.EcommercePackageWidth, "ecommercePackageWidth9");
            Assert.AreEqual(result2.EcommercePageQty, "ecommercePageQty9");
            Assert.AreEqual(result2.EcommerceProductCategory, "ecommerceProductCategory9");
            Assert.AreEqual(result2.EcommerceProductDescription, "ecommerceProductDescription9");
            Assert.AreEqual(result2.EcommerceProductSubcategory, "ecommerceProductSubcategory9");
            Assert.AreEqual(result2.EcommerceManufacturerName, "ecommerceManufacturerName9");
            Assert.AreEqual(result2.EcommerceMsrp, "ecommerceMsrp9");
            Assert.AreEqual(result2.EcommerceSize, "ecommerceSize9");
            #endregion // Assert
        }

        [TestMethod]
        public void ConvertQuotes_HasConvertableValue_ShouldReturnDoubleApostrophes()
        {
            #region Assemble

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion // Assemble

            #region Act

            string input1 = "18\" x 24\"";
            string result1 = DbUtil.ReplaceQuotes(input1);

            #endregion // Act

            #region Assert

            Assert.AreEqual(result1, "18'' x 24''");

            #endregion // Assert
        }
        
        /// <summary>
        ///     This method test the ReadItemIds function where invalid data exists in excel spreadsheet. Method should succeed.
        /// </summary>
        [TestMethod]
        public void CreateEcommerce_ImageUrl_ValidImageUrl_ShouldReturnProperImageUrl()
        {

            #region Setup

            ItemObject item = new ItemObject();
            string imgLocation = @"\\MACSERV\Store 2\•CAPTURES\Poster Captures\Poster Captures\10000\10000\10031 - Zelda - A Link Between Worlds.tif";

            #endregion // Setup

            #region Act

            string result = item.CreateEcommerce_ImageUrl(imgLocation);

            #endregion // Act

            #region Assert

            Assert.AreEqual("http://trendsinternational.com/media/catalog/product/1/0/10031 - Zelda - A Link Between Worlds.jpg", result);

            #endregion // Assert
        }

        [TestMethod]
        public void FormatCategory_GivenProperCategoryValue_ShouldReturnValidWebCategory()
        {
            #region Assemble

            TestItemRepository itemRepository = new TestItemRepository();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), itemRepository, new TestTemplateRepository());

            string category1 = "Poster: Wall Poster: Your Face";

            #endregion // Assemble

            #region Act

            string newCategory = itemService.FormatCategory(category1);

            #endregion // Act

            #region Assert

            Assert.AreEqual(newCategory, "Poster|Poster=>Wall Poster|Poster=>Wall Poster=>Your Face");

            #endregion // Assert
        }

        [TestMethod]
        public void FormatCategory_FormatsCategoryForSite_ShouldProperlyFormat()
        {
            #region Setup

            string category = "Posters: Posters: Wall Posters: Sports: NFL";
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            #endregion // Setup

            #region Act

            string formatedCategory = itemService.FormatCategory(category);

            #endregion // Act

            #region Assert

            Assert.AreEqual("Posters|Posters=>Posters|Posters=>Posters=>Wall Posters|Posters=>Posters=>Wall Posters=>Sports|Posters=>Posters=>Wall Posters=>Sports=>NFL", formatedCategory);

            #endregion // Assert
        }

        /// <summary>
        ///     This test creates a scenario, but not just any scenario. This scenario reads the rows of a worksheet 
        ///     with item id's and blank item id's and asserts that no items are created form rows with no item ids.
        /// </summary>
        [TestMethod]
        public void GetPrice_ReturnItemListPrice_ShouldReturnMultipliedValues()
        {
            #region SetUp

            FakeWorkbookReader fakeWorkbookReader = new FakeWorkbookReader();
            TestItemRepository testItemRepository = new TestItemRepository();
            ItemService itemService = new ItemService(fakeWorkbookReader, testItemRepository, new TestTemplateRepository());
            ItemObject item = new ItemObject();
            item.ListPriceUsd = "2.50";
            item.ListPriceCad = "3.50";
            item.ProductQty = "10";

            ItemObject item2 = new ItemObject();
            item2.ListPriceUsd = "2.50";
            item2.ListPriceCad = "3.50";


            #endregion // Set Up

            #region Act

            string itemUsdPrice = itemService.RetrieveB2bPrice(item.ListPriceUsd, item.ProductQty);
            string itemCadPrice = itemService.RetrieveB2bPrice(item.ListPriceCad, item.ProductQty);
            string item2UsdPrice = itemService.RetrieveB2bPrice(item2.ListPriceUsd, item2.ProductQty);
            string item2CadPrice = itemService.RetrieveB2bPrice(item2.ListPriceCad, item2.ProductQty);


            #endregion // Act

            #region Assert

            Assert.AreEqual(itemUsdPrice, "25.00");
            Assert.AreEqual(itemCadPrice, "35.00");
            Assert.AreEqual(item2UsdPrice, "2.50");
            Assert.AreEqual(item2CadPrice, "3.50");

            #endregion // Assert
        }
        
        /// <summary>
        ///     Retrieves template information for given template id and populates item
        /// </summary>
        [TestMethod]
        public void LoadItem_TemplateIdProvided_ShouldReturnTemplateValues()
        {
            #region Assemble

            FakeWorkbookReader fakeWorkbookReader = new FakeWorkbookReader();
            GlobalData.TemplateNames.Add("TemplateId1");
            fakeWorkbookReader.ColumnHeaders.Add("ItemID");
            fakeWorkbookReader.ColumnHeaders.Add("Template Name");
            fakeWorkbookReader.ColumnHeaders.Add("Sell On Amazon");
            fakeWorkbookReader.ColumnHeaders.Add("Sell On Fanatics");
            fakeWorkbookReader.ColumnHeaders.Add("Sell On Guitar Center");
            fakeWorkbookReader.AddWorksheetRow();
            fakeWorkbookReader.AddCellValue("ItemIdB"); // Item Id
            fakeWorkbookReader.AddCellValue("TemplateId1"); // Template Id
            fakeWorkbookReader.AddCellValue(""); // Sell On Amazon
            fakeWorkbookReader.AddCellValue(""); // Sell On Fanatics
            fakeWorkbookReader.AddCellValue(""); // Sell On Fanatics
            ItemService itemService = new ItemService(fakeWorkbookReader, new TestItemRepository(), new TestTemplateRepository());

            #endregion // Assemble

            #region Act

            ObservableCollection<ItemObject> items = itemService.LoadExcelItems("Add", string.Empty);
            ItemObject testItem = items[0];

            #endregion // Act

            #region Assert

            Assert.AreEqual("TemplateAccountingGroup1", testItem.AccountingGroup);
            Assert.AreEqual("TemplateCasepackHeight1", testItem.CasepackHeight);
            Assert.AreEqual("TemplateCasepackLength1", testItem.CasepackLength);
            Assert.AreEqual("TemplateCasepackQty1", testItem.CasepackQty);
            Assert.AreEqual("TemplateCasepackWidth1", testItem.CasepackWidth);
            Assert.AreEqual("TemplateCasepackWeight1", testItem.CasepackWeight);
            Assert.AreEqual("TemplateCategory1", testItem.Category);
            Assert.AreEqual("TemplateCategory21", testItem.Category2);
            Assert.AreEqual("TemplateCategory31", testItem.Category3);
            Assert.AreEqual("TemplateCopyright1", testItem.Copyright);
            Assert.AreEqual("TemplateCostProfileGroup1", testItem.CostProfileGroup);
            Assert.AreEqual("TemplateDefaultActualCostCad1", testItem.DefaultActualCostCad);
            Assert.AreEqual("TemplateDefaultActualCostUsd1", testItem.DefaultActualCostUsd);
            Assert.AreEqual("TemplateDuty1", testItem.Duty);
            Assert.AreEqual("TemplateGpc1", testItem.Gpc);
            Assert.AreEqual("TemplateHeight1", testItem.Height);
            Assert.AreEqual("TemplateInnerpackHeight1", testItem.InnerpackHeight);
            Assert.AreEqual("TemplateInnerpackLength1", testItem.InnerpackLength);
            Assert.AreEqual("TemplateInnerpackQuantity1", testItem.InnerpackQuantity);
            Assert.AreEqual("TemplateInnerpackWeight1", testItem.InnerpackWeight);
            Assert.AreEqual("TemplateInnerpackWidth1", testItem.InnerpackWidth);
            Assert.AreEqual("TemplateItemCategory1", testItem.ItemCategory);
            Assert.AreEqual("TemplateItemFamily1", testItem.ItemFamily);
            Assert.AreEqual("TemplateItemGroup1", testItem.ItemGroup);
            Assert.AreEqual("TemplateLength1", testItem.Length);
            Assert.AreEqual("TemplateListPriceCad1", testItem.ListPriceCad);
            Assert.AreEqual("TemplateListPriceMxn1", testItem.ListPriceMxn);
            Assert.AreEqual("TemplateListPriceUsd1", testItem.ListPriceUsd);
            Assert.AreEqual("TemplateMetaDescription1", testItem.MetaDescription);
            Assert.AreEqual("TemplateMfgSource1", testItem.MfgSource);
            Assert.AreEqual("TemplateMsrp1", testItem.Msrp);
            Assert.AreEqual("TemplateMsrpCad1", testItem.MsrpCad);
            Assert.AreEqual("TemplateMsrpMxn1", testItem.MsrpMxn);
            Assert.AreEqual("TemplateProductFormat1", testItem.ProductFormat);
            Assert.AreEqual("TemplateProductGroup1", testItem.ProductGroup);
            Assert.AreEqual("TemplateProductLine1", testItem.ProductLine);
            Assert.AreEqual("TemplateProductQty1", testItem.ProductQty);
            Assert.AreEqual("TemplatePricingGroup1", testItem.PricingGroup);
            Assert.AreEqual("TemplateSize1", testItem.Size);
            Assert.AreEqual("TemplateTariffCode1", testItem.TariffCode);
            Assert.AreEqual("TemplateUdex1", testItem.Udex);
            Assert.AreEqual("TemplateWeight1", testItem.Weight);
            Assert.AreEqual("TemplateWidth1", testItem.Width);
            Assert.AreEqual("TemplateEcommerceBullet11", testItem.Ecommerce_Bullet1);
            Assert.AreEqual("TemplateEcommerceBullet21", testItem.Ecommerce_Bullet2);
            Assert.AreEqual("TemplateEcommerceBullet31", testItem.Ecommerce_Bullet3);
            Assert.AreEqual("TemplateEcommerceBullet41", testItem.Ecommerce_Bullet4);
            Assert.AreEqual("TemplateEcommerceBullet51", testItem.Ecommerce_Bullet5);
            Assert.AreEqual("TemplateEcommerceComponents1", testItem.Ecommerce_Components);
            Assert.AreEqual("TemplateEcommerceCost1", testItem.Ecommerce_Cost);
            Assert.AreEqual("TemplateEcommerceExternalIdType1", testItem.Ecommerce_ExternalIdType);
            Assert.AreEqual("TemplateEcommerceItemHeight1", testItem.Ecommerce_ItemHeight);
            Assert.AreEqual("TemplateEcommerceItemLength1", testItem.Ecommerce_ItemLength);
            Assert.AreEqual("TemplateEcommerceItemWeight1", testItem.Ecommerce_ItemWeight);
            Assert.AreEqual("TemplateEcommerceItemWidth1", testItem.Ecommerce_ItemWidth);
            Assert.AreEqual("TemplateEcommerceModelName1", testItem.Ecommerce_ModelName);
            Assert.AreEqual("TemplateEcommercePackageLength1", testItem.Ecommerce_PackageLength);
            Assert.AreEqual("TemplateEcommercePackageHeight1", testItem.Ecommerce_PackageHeight);
            Assert.AreEqual("TemplateEcommercePackageWeight1", testItem.Ecommerce_PackageWeight);
            Assert.AreEqual("TemplateEcommercePackageWidth1", testItem.Ecommerce_PackageWidth);
            Assert.AreEqual("TemplateEcommercePageQty1", testItem.Ecommerce_PageQty);
            Assert.AreEqual("TemplateEcommerceProductCategory1", testItem.Ecommerce_ProductCategory);
            Assert.AreEqual("TemplateEcommerceProductDescription1", testItem.Ecommerce_ProductDescription);
            Assert.AreEqual("TemplateEcommerceProductSubcategory1", testItem.Ecommerce_ProductSubcategory);
            Assert.AreEqual("TemplateEcommerceManufacturerName1", testItem.Ecommerce_ManufacturerName);
            Assert.AreEqual("TemplateEcommerceMsrp1", testItem.Ecommerce_Msrp);
            Assert.AreEqual("TemplateEcommerceSize1", testItem.Ecommerce_Size);

            #endregion // Assert
        }

        /// <summary>
        ///     Retrieves template information for given template id and populates item. Provided item fields should
        ///     override tempalte values
        /// </summary>
        [TestMethod]
        public void LoadItem_TemplateIdAndPeopleSoftValuesProvided_ShouldOverideTemplateValues()
        {
            #region Assemble

            FakeWorkbookReader fakeWorkbookReader = new FakeWorkbookReader();
            GlobalData.TemplateNames.Add("TemplateId1");
            fakeWorkbookReader.ColumnHeaders.Add("ItemID");
            fakeWorkbookReader.ColumnHeaders.Add("Template Name");
            fakeWorkbookReader.ColumnHeaders.Add("Accounting Group");
            fakeWorkbookReader.ColumnHeaders.Add("Casepack Height");
            fakeWorkbookReader.ColumnHeaders.Add("Casepack Length");
            fakeWorkbookReader.ColumnHeaders.Add("Casepack Qty");
            fakeWorkbookReader.ColumnHeaders.Add("Casepack Width");
            fakeWorkbookReader.ColumnHeaders.Add("Casepack Weight");
            fakeWorkbookReader.ColumnHeaders.Add("Category");
            fakeWorkbookReader.ColumnHeaders.Add("Category 2");
            fakeWorkbookReader.ColumnHeaders.Add("Category 3");
            fakeWorkbookReader.ColumnHeaders.Add("Color");
            fakeWorkbookReader.ColumnHeaders.Add("Copyright");
            fakeWorkbookReader.ColumnHeaders.Add("Country Of Origin");
            fakeWorkbookReader.ColumnHeaders.Add("Cost Profile Group");
            fakeWorkbookReader.ColumnHeaders.Add("Default Actual Cost Cad");
            fakeWorkbookReader.ColumnHeaders.Add("Default Actual Cost Usd");
            fakeWorkbookReader.ColumnHeaders.Add("Description");
            fakeWorkbookReader.ColumnHeaders.Add("Direct Import");
            fakeWorkbookReader.ColumnHeaders.Add("Duty");
            fakeWorkbookReader.ColumnHeaders.Add("Ean");
            fakeWorkbookReader.ColumnHeaders.Add("Gpc");
            fakeWorkbookReader.ColumnHeaders.Add("Height");
            fakeWorkbookReader.ColumnHeaders.Add("Innerpack Height");
            fakeWorkbookReader.ColumnHeaders.Add("Innerpack Length");
            fakeWorkbookReader.ColumnHeaders.Add("Innerpack Quantity");
            fakeWorkbookReader.ColumnHeaders.Add("Innerpack Weight");
            fakeWorkbookReader.ColumnHeaders.Add("Innerpack Width");
            fakeWorkbookReader.ColumnHeaders.Add("In Stock Date");
            fakeWorkbookReader.ColumnHeaders.Add("Isbn");
            fakeWorkbookReader.ColumnHeaders.Add("Item Category");
            fakeWorkbookReader.ColumnHeaders.Add("Item Family");
            fakeWorkbookReader.ColumnHeaders.Add("Item Group");
            fakeWorkbookReader.ColumnHeaders.Add("Language");
            fakeWorkbookReader.ColumnHeaders.Add("Length");
            fakeWorkbookReader.ColumnHeaders.Add("License Begin Date");
            fakeWorkbookReader.ColumnHeaders.Add("List Price Cad");
            fakeWorkbookReader.ColumnHeaders.Add("List Price Mxn");
            fakeWorkbookReader.ColumnHeaders.Add("List Price Usd");
            fakeWorkbookReader.ColumnHeaders.Add("Meta Description");
            fakeWorkbookReader.ColumnHeaders.Add("Mfg Source");
            fakeWorkbookReader.ColumnHeaders.Add("MSRP");
            fakeWorkbookReader.ColumnHeaders.Add("MSRP CAD");
            fakeWorkbookReader.ColumnHeaders.Add("MSRP MXN");
            fakeWorkbookReader.ColumnHeaders.Add("Product Format");
            fakeWorkbookReader.ColumnHeaders.Add("Product Group");
            fakeWorkbookReader.ColumnHeaders.Add("Product Line");
            fakeWorkbookReader.ColumnHeaders.Add("Product Qty");
            fakeWorkbookReader.ColumnHeaders.Add("Pricing Group");
            fakeWorkbookReader.ColumnHeaders.Add("Short Description");
            fakeWorkbookReader.ColumnHeaders.Add("Size");
            fakeWorkbookReader.ColumnHeaders.Add("Standard Cost");
            fakeWorkbookReader.ColumnHeaders.Add("Stats Code");
            fakeWorkbookReader.ColumnHeaders.Add("Tariff Code");
            fakeWorkbookReader.ColumnHeaders.Add("Territory");
            fakeWorkbookReader.ColumnHeaders.Add("Udex");
            fakeWorkbookReader.ColumnHeaders.Add("Weight");
            fakeWorkbookReader.ColumnHeaders.Add("Width");
            fakeWorkbookReader.AddWorksheetRow();
            fakeWorkbookReader.AddCellValue("ItemIdA"); // Item Id
            fakeWorkbookReader.AddCellValue("TemplateId1"); // Template Id
            fakeWorkbookReader.AddCellValue("A");
            fakeWorkbookReader.AddCellValue("B");
            fakeWorkbookReader.AddCellValue("C");
            fakeWorkbookReader.AddCellValue("D");
            fakeWorkbookReader.AddCellValue("E");
            fakeWorkbookReader.AddCellValue("F");
            fakeWorkbookReader.AddCellValue("G");
            fakeWorkbookReader.AddCellValue("H");
            fakeWorkbookReader.AddCellValue("I");
            fakeWorkbookReader.AddCellValue("J");
            fakeWorkbookReader.AddCellValue("K");
            fakeWorkbookReader.AddCellValue("L");
            fakeWorkbookReader.AddCellValue("M");
            fakeWorkbookReader.AddCellValue("N");
            fakeWorkbookReader.AddCellValue("O");
            fakeWorkbookReader.AddCellValue("P");
            fakeWorkbookReader.AddCellValue("Q");
            fakeWorkbookReader.AddCellValue("R");
            fakeWorkbookReader.AddCellValue("S");
            fakeWorkbookReader.AddCellValue("T");
            fakeWorkbookReader.AddCellValue("U");
            fakeWorkbookReader.AddCellValue("V");
            fakeWorkbookReader.AddCellValue("W");
            fakeWorkbookReader.AddCellValue("X");
            fakeWorkbookReader.AddCellValue("Y");
            fakeWorkbookReader.AddCellValue("Z");
            fakeWorkbookReader.AddCellValue("AA");
            fakeWorkbookReader.AddCellValue("AB");
            fakeWorkbookReader.AddCellValue("AC");
            fakeWorkbookReader.AddCellValue("AD");
            fakeWorkbookReader.AddCellValue("AE");
            fakeWorkbookReader.AddCellValue("AF");
            fakeWorkbookReader.AddCellValue("AG");
            fakeWorkbookReader.AddCellValue("AH");
            fakeWorkbookReader.AddCellValue("AI");
            fakeWorkbookReader.AddCellValue("AJ");
            fakeWorkbookReader.AddCellValue("AK");
            fakeWorkbookReader.AddCellValue("AL");
            fakeWorkbookReader.AddCellValue("AM");
            fakeWorkbookReader.AddCellValue("AN");
            fakeWorkbookReader.AddCellValue("AO");
            fakeWorkbookReader.AddCellValue("AP");
            fakeWorkbookReader.AddCellValue("AQ");
            fakeWorkbookReader.AddCellValue("AR");
            fakeWorkbookReader.AddCellValue("AS");
            fakeWorkbookReader.AddCellValue("AT");
            fakeWorkbookReader.AddCellValue("AU");
            fakeWorkbookReader.AddCellValue("AV");
            fakeWorkbookReader.AddCellValue("AW");
            fakeWorkbookReader.AddCellValue("AX");
            fakeWorkbookReader.AddCellValue("AY");
            fakeWorkbookReader.AddCellValue("AZ");
            fakeWorkbookReader.AddCellValue("BA");
            fakeWorkbookReader.AddCellValue("BB");
            fakeWorkbookReader.AddCellValue("BC");
            fakeWorkbookReader.AddCellValue("BD");
            fakeWorkbookReader.AddCellValue("BE");
            ItemService itemService = new ItemService(fakeWorkbookReader, new TestItemRepository(), new TestTemplateRepository());

            #endregion // Assemble

            #region Act

            ObservableCollection<ItemObject> items = itemService.LoadExcelItems("Add", string.Empty);
            ItemObject testItem = items[0];

            #endregion // Act

            #region Assert

            Assert.AreEqual("A", testItem.AccountingGroup);
            Assert.AreEqual("B", testItem.CasepackHeight);
            Assert.AreEqual("C", testItem.CasepackLength);
            Assert.AreEqual("D", testItem.CasepackQty);
            Assert.AreEqual("E", testItem.CasepackWidth);
            Assert.AreEqual("F", testItem.CasepackWeight);
            Assert.AreEqual("G", testItem.Category);
            Assert.AreEqual("H", testItem.Category2);
            Assert.AreEqual("I", testItem.Category3);
            Assert.AreEqual("J", testItem.Color);
            Assert.AreEqual("K", testItem.Copyright);
            Assert.AreEqual("L", testItem.CountryOfOrigin);
            Assert.AreEqual("M", testItem.CostProfileGroup);
            Assert.AreEqual("N", testItem.DefaultActualCostCad);
            Assert.AreEqual("O", testItem.DefaultActualCostUsd);
            Assert.AreEqual("P", testItem.Description);
            Assert.AreEqual("Q", testItem.DirectImport);
            Assert.AreEqual("R", testItem.Duty);
            Assert.AreEqual("S", testItem.Ean);
            Assert.AreEqual("T", testItem.Gpc);
            Assert.AreEqual("U.0", testItem.Height);
            Assert.AreEqual("V", testItem.InnerpackHeight);
            Assert.AreEqual("W", testItem.InnerpackLength);
            Assert.AreEqual("X", testItem.InnerpackQuantity);
            Assert.AreEqual("Y", testItem.InnerpackWeight);
            Assert.AreEqual("Z", testItem.InnerpackWidth);
            Assert.AreEqual("AA", testItem.InStockDate);
            Assert.AreEqual("AB", testItem.Isbn);
            Assert.AreEqual("AC", testItem.ItemCategory);
            Assert.AreEqual("AD", testItem.ItemFamily);
            Assert.AreEqual("AE", testItem.ItemGroup);
            Assert.AreEqual("AF", testItem.Language);
            Assert.AreEqual("AG.0", testItem.Length);
            Assert.AreEqual("AH", testItem.LicenseBeginDate);
            Assert.AreEqual("AI.00", testItem.ListPriceCad);
            Assert.AreEqual("AJ.00", testItem.ListPriceMxn);
            Assert.AreEqual("AK.00", testItem.ListPriceUsd);
            Assert.AreEqual("AL", testItem.MetaDescription);
            Assert.AreEqual("AM", testItem.MfgSource);
            Assert.AreEqual("AN", testItem.Msrp);
            Assert.AreEqual("AO", testItem.MsrpCad);
            Assert.AreEqual("AP", testItem.MsrpMxn);
            Assert.AreEqual("AQ", testItem.ProductFormat);
            Assert.AreEqual("AR", testItem.ProductGroup);
            Assert.AreEqual("AS", testItem.ProductLine);
            Assert.AreEqual("AT", testItem.ProductQty);
            Assert.AreEqual("AU", testItem.PricingGroup);
            Assert.AreEqual("AV", testItem.ShortDescription);
            Assert.AreEqual("AW", testItem.Size);
            Assert.AreEqual("O", testItem.StandardCost);
            Assert.AreEqual("AY", testItem.StatsCode);
            Assert.AreEqual("AZ", testItem.TariffCode);
            Assert.AreEqual("BA", testItem.Territory);
            Assert.AreEqual("BB", testItem.Udex);
            Assert.AreEqual("BC.0", testItem.Weight);
            Assert.AreEqual("BD.0", testItem.Width);
            Assert.AreEqual("TemplateEcommerceBullet11", testItem.Ecommerce_Bullet1);
            Assert.AreEqual("TemplateEcommerceBullet21", testItem.Ecommerce_Bullet2);
            Assert.AreEqual("TemplateEcommerceBullet31", testItem.Ecommerce_Bullet3);
            Assert.AreEqual("TemplateEcommerceBullet41", testItem.Ecommerce_Bullet4);
            Assert.AreEqual("TemplateEcommerceBullet51", testItem.Ecommerce_Bullet5);
            Assert.AreEqual("TemplateEcommerceComponents1", testItem.Ecommerce_Components);
            Assert.AreEqual("TemplateEcommerceCost1", testItem.Ecommerce_Cost);
            Assert.AreEqual("TemplateEcommerceExternalIdType1", testItem.Ecommerce_ExternalIdType);
            Assert.AreEqual("TemplateEcommerceItemHeight1", testItem.Ecommerce_ItemHeight);
            Assert.AreEqual("TemplateEcommerceItemLength1", testItem.Ecommerce_ItemLength);
            Assert.AreEqual("TemplateEcommerceItemWeight1", testItem.Ecommerce_ItemWeight);
            Assert.AreEqual("TemplateEcommerceItemWidth1", testItem.Ecommerce_ItemWidth);
            Assert.AreEqual("TemplateEcommerceModelName1", testItem.Ecommerce_ModelName);
            Assert.AreEqual("TemplateEcommercePackageLength1", testItem.Ecommerce_PackageLength);
            Assert.AreEqual("TemplateEcommercePackageHeight1", testItem.Ecommerce_PackageHeight);
            Assert.AreEqual("TemplateEcommercePackageWeight1", testItem.Ecommerce_PackageWeight);
            Assert.AreEqual("TemplateEcommercePackageWidth1", testItem.Ecommerce_PackageWidth);
            Assert.AreEqual("TemplateEcommercePageQty1", testItem.Ecommerce_PageQty);
            Assert.AreEqual("TemplateEcommerceProductCategory1", testItem.Ecommerce_ProductCategory);
            Assert.AreEqual("TemplateEcommerceProductDescription1", testItem.Ecommerce_ProductDescription);
            Assert.AreEqual("TemplateEcommerceProductSubcategory1", testItem.Ecommerce_ProductSubcategory);
            Assert.AreEqual("TemplateEcommerceManufacturerName1", testItem.Ecommerce_ManufacturerName);
            Assert.AreEqual("TemplateEcommerceMsrp1", testItem.Ecommerce_Msrp);
            Assert.AreEqual("TemplateEcommerceSize1", testItem.Ecommerce_Size);

            #endregion // Assert
        }

        /// <summary>
        ///     Retrieves template information for given template id and populates item. Provided item fields should
        ///     override tempalte values
        /// </summary>
        [TestMethod]
        public void LoadItem_TemplateIdAndEcommerceWebValues_ShouldOverideTemplateValues()
        {
            #region Assemble

            FakeWorkbookReader fakeWorkbookReader = new FakeWorkbookReader();
            GlobalData.TemplateNames.Add("TemplateId1");
            fakeWorkbookReader.ColumnHeaders.Add("ItemID");
            fakeWorkbookReader.ColumnHeaders.Add("Template Name");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Bullet 1");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Bullet 2");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Bullet 3");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Bullet 4");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Bullet 5");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Components");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Cost");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce External Id Type");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Item Height");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Item Length");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Item Weight");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Item Width");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Model Name");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Package Length");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Package Height");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Package Weight");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Package Width");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Page Qty");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Product Category");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Product Description");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Product Subcategory");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Manufacturer Name");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Msrp");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Size");
            fakeWorkbookReader.AddWorksheetRow();
            fakeWorkbookReader.AddCellValue("ItemIdA"); // Item Id
            fakeWorkbookReader.AddCellValue("TemplateId1"); // Template Id
            fakeWorkbookReader.AddCellValue("b1");
            fakeWorkbookReader.AddCellValue("b2");
            fakeWorkbookReader.AddCellValue("b3");
            fakeWorkbookReader.AddCellValue("b4");
            fakeWorkbookReader.AddCellValue("b5");
            fakeWorkbookReader.AddCellValue("c1");
            fakeWorkbookReader.AddCellValue("c2");
            fakeWorkbookReader.AddCellValue("e1");
            fakeWorkbookReader.AddCellValue("i1");
            fakeWorkbookReader.AddCellValue("i2");
            fakeWorkbookReader.AddCellValue("i3");
            fakeWorkbookReader.AddCellValue("i4");
            fakeWorkbookReader.AddCellValue("m1");
            fakeWorkbookReader.AddCellValue("p1");
            fakeWorkbookReader.AddCellValue("p2");
            fakeWorkbookReader.AddCellValue("p4");
            fakeWorkbookReader.AddCellValue("p3");
            fakeWorkbookReader.AddCellValue("Ecommerce Page Qtyp4");
            fakeWorkbookReader.AddCellValue("p5");
            fakeWorkbookReader.AddCellValue("p6");
            fakeWorkbookReader.AddCellValue("p7");
            fakeWorkbookReader.AddCellValue("m2");
            fakeWorkbookReader.AddCellValue("m3");
            fakeWorkbookReader.AddCellValue("s1");
            ItemService itemService = new ItemService(fakeWorkbookReader, new TestItemRepository(), new TestTemplateRepository());

            #endregion // Assemble

            #region Act

            ObservableCollection<ItemObject> items = itemService.LoadExcelItems("Add", string.Empty);
            ItemObject testItem = items[0];

            #endregion // Act

            #region Assert

            Assert.AreEqual("TemplateAccountingGroup1", testItem.AccountingGroup);
            Assert.AreEqual("TemplateCasepackHeight1", testItem.CasepackHeight);
            Assert.AreEqual("TemplateCasepackLength1", testItem.CasepackLength);
            Assert.AreEqual("TemplateCasepackQty1", testItem.CasepackQty);
            Assert.AreEqual("TemplateCasepackWidth1", testItem.CasepackWidth);
            Assert.AreEqual("TemplateCasepackWeight1", testItem.CasepackWeight);
            Assert.AreEqual("TemplateCategory1", testItem.Category);
            Assert.AreEqual("TemplateCategory21", testItem.Category2);
            Assert.AreEqual("TemplateCategory31", testItem.Category3);
            Assert.AreEqual("TemplateCopyright1", testItem.Copyright);
            Assert.AreEqual("TemplateCostProfileGroup1", testItem.CostProfileGroup);
            Assert.AreEqual("TemplateDefaultActualCostCad1", testItem.DefaultActualCostCad);
            Assert.AreEqual("TemplateDefaultActualCostUsd1", testItem.DefaultActualCostUsd);
            Assert.AreEqual("TemplateDuty1", testItem.Duty);
            Assert.AreEqual("TemplateGpc1", testItem.Gpc);
            Assert.AreEqual("TemplateHeight1", testItem.Height);
            Assert.AreEqual("TemplateInnerpackHeight1", testItem.InnerpackHeight);
            Assert.AreEqual("TemplateInnerpackLength1", testItem.InnerpackLength);
            Assert.AreEqual("TemplateInnerpackQuantity1", testItem.InnerpackQuantity);
            Assert.AreEqual("TemplateInnerpackWeight1", testItem.InnerpackWeight);
            Assert.AreEqual("TemplateInnerpackWidth1", testItem.InnerpackWidth);
            Assert.AreEqual("TemplateItemCategory1", testItem.ItemCategory);
            Assert.AreEqual("TemplateItemFamily1", testItem.ItemFamily);
            Assert.AreEqual("TemplateItemGroup1", testItem.ItemGroup);
            Assert.AreEqual("TemplateLength1", testItem.Length);
            Assert.AreEqual("TemplateListPriceCad1", testItem.ListPriceCad);
            Assert.AreEqual("TemplateListPriceMxn1", testItem.ListPriceMxn);
            Assert.AreEqual("TemplateListPriceUsd1", testItem.ListPriceUsd);
            Assert.AreEqual("TemplateMetaDescription1", testItem.MetaDescription);
            Assert.AreEqual("TemplateMfgSource1", testItem.MfgSource);
            Assert.AreEqual("TemplateMsrp1", testItem.Msrp);
            Assert.AreEqual("TemplateMsrpCad1", testItem.MsrpCad);
            Assert.AreEqual("TemplateMsrpMxn1", testItem.MsrpMxn);
            Assert.AreEqual("TemplateProductFormat1", testItem.ProductFormat);
            Assert.AreEqual("TemplateProductGroup1", testItem.ProductGroup);
            Assert.AreEqual("TemplateProductLine1", testItem.ProductLine);
            Assert.AreEqual("TemplateProductQty1", testItem.ProductQty);
            Assert.AreEqual("TemplatePricingGroup1", testItem.PricingGroup);
            Assert.AreEqual("TemplateSize1", testItem.Size);
            Assert.AreEqual("TemplateTariffCode1", testItem.TariffCode);
            Assert.AreEqual("TemplateUdex1", testItem.Udex);
            Assert.AreEqual("TemplateWeight1", testItem.Weight);
            Assert.AreEqual("TemplateWidth1", testItem.Width);
            Assert.AreEqual("b1", testItem.Ecommerce_Bullet1);
            Assert.AreEqual("b2", testItem.Ecommerce_Bullet2);
            Assert.AreEqual("b3", testItem.Ecommerce_Bullet3);
            Assert.AreEqual("b4", testItem.Ecommerce_Bullet4);
            Assert.AreEqual("b5", testItem.Ecommerce_Bullet5);
            Assert.AreEqual("c1", testItem.Ecommerce_Components);
            Assert.AreEqual("c2.00", testItem.Ecommerce_Cost);
            Assert.AreEqual("e1", testItem.Ecommerce_ExternalIdType);
            Assert.AreEqual("i1.0", testItem.Ecommerce_ItemHeight);
            Assert.AreEqual("i2.0", testItem.Ecommerce_ItemLength);
            Assert.AreEqual("i3.0", testItem.Ecommerce_ItemWeight);
            Assert.AreEqual("i4.0", testItem.Ecommerce_ItemWidth);
            Assert.AreEqual("m1", testItem.Ecommerce_ModelName);
            Assert.AreEqual("p1.0", testItem.Ecommerce_PackageLength);
            Assert.AreEqual("p2.0", testItem.Ecommerce_PackageHeight);
            Assert.AreEqual("p4.0", testItem.Ecommerce_PackageWeight);
            Assert.AreEqual("p3.0", testItem.Ecommerce_PackageWidth);
            Assert.AreEqual("Ecommerce Page Qtyp4", testItem.Ecommerce_PageQty);
            Assert.AreEqual("p5", testItem.Ecommerce_ProductCategory);
            Assert.AreEqual("p6", testItem.Ecommerce_ProductDescription);
            Assert.AreEqual("p7", testItem.Ecommerce_ProductSubcategory);
            Assert.AreEqual("m2", testItem.Ecommerce_ManufacturerName);
            Assert.AreEqual("m3.00", testItem.Ecommerce_Msrp);
            Assert.AreEqual("s1", testItem.Ecommerce_Size);

            #endregion // Assert
        }

        /// <summary>
        ///     Tests that the default values are appropriately added when items being added have blank fields.
        /// </summary>
        [TestMethod]
        public void LoadItemsDefaultValue_AddedItemIsMissingValues_ShouldCreateDefaultValues()
        {
            #region SetUp

            FakeWorkbookReader fakeWorkbookReader = new FakeWorkbookReader();
            fakeWorkbookReader.ColumnHeaders.Add("ItemID");
            fakeWorkbookReader.ColumnHeaders.Add("PS Status");
            fakeWorkbookReader.ColumnHeaders.Add("Sell On Amazon");
            fakeWorkbookReader.ColumnHeaders.Add("Sell On Fanatics");
            fakeWorkbookReader.ColumnHeaders.Add("Sell On Walmart");
            fakeWorkbookReader.ColumnHeaders.Add("Sell On Guitar Center");
            fakeWorkbookReader.AddWorksheetRow();
            fakeWorkbookReader.AddCellValue("ST1234"); // Item Id
            fakeWorkbookReader.AddCellValue(""); // PS Status
            fakeWorkbookReader.AddCellValue(""); // Sell On Amazon
            fakeWorkbookReader.AddCellValue(""); // Sell On Fanatics
            fakeWorkbookReader.AddCellValue(""); // Sell On Walmart
            fakeWorkbookReader.AddCellValue(""); // Sell On Guitar Center
            TestItemRepository testItemRepository = new TestItemRepository();

            #endregion // Set Up

            #region Act

            ItemService itemService = new ItemService(fakeWorkbookReader, testItemRepository, new TestTemplateRepository());
            ObservableCollection<ItemObject> items = itemService.LoadExcelItems("Add", string.Empty);


            #endregion // Act

            #region Assert

            ItemObject item = new ItemObject();

            Assert.AreEqual(1, items.Count);

            // Assert that the first item's properties are correct
            item = items[0];
            item.Status = "Add";
            item.ItemRow = 1;
            Assert.AreEqual("ST1234", item.ItemId); // Item Id
            Assert.AreEqual("Add", item.Status);
            Assert.AreEqual("I", item.PsStatus); // PS Status
            Assert.AreEqual("N", item.SellOnAmazon); // Sell On Amazon
            Assert.AreEqual("N", item.SellOnFanatics); // Sell On Fanatics
            Assert.AreEqual("N", item.SellOnGuitarCenter); // Sell On Guitar Center
            Assert.AreEqual("N", item.SellOnHayneedle); // Sell On Hayneedle
            Assert.AreEqual("N", item.SellOnWalmart); // Sell On Walmart

            #endregion // Assert
        }

        /// <summary>
        ///     Tests that the default values are appropriately added when items being added have blank fields.
        /// </summary>
        [TestMethod]
        public void LoadItemsDefaultValue_UpdatedItemIsMissingValues_ShouldNotCreateDefaultValues()
        {
            #region SetUp

            FakeWorkbookReader fakeWorkbookReader = new FakeWorkbookReader();
            fakeWorkbookReader.ColumnHeaders.Add("ItemID");
            fakeWorkbookReader.ColumnHeaders.Add("PS Status");
            fakeWorkbookReader.ColumnHeaders.Add("Sell On Amazon");
            fakeWorkbookReader.ColumnHeaders.Add("Sell On Fanatics");
            fakeWorkbookReader.ColumnHeaders.Add("Sell On Walmart");
            fakeWorkbookReader.ColumnHeaders.Add("Sell On Hayneedle");
            fakeWorkbookReader.AddWorksheetRow();
            fakeWorkbookReader.AddCellValue("ST1234"); // Item Id
            fakeWorkbookReader.AddCellValue("N"); // PS Status
            fakeWorkbookReader.AddCellValue("N"); // Sell On Amazon
            fakeWorkbookReader.AddCellValue("N"); // Sell On Fanatics
            fakeWorkbookReader.AddCellValue("N"); // Sell On Walmart
            fakeWorkbookReader.AddCellValue("N"); // Sell On Hayneedle
            TestItemRepository testItemRepository = new TestItemRepository();

            #endregion // Set Up

            #region Act

            ItemService itemService = new ItemService(fakeWorkbookReader, testItemRepository, new TestTemplateRepository());
            ObservableCollection<ItemObject> items = itemService.LoadExcelItems("Update", string.Empty);


            #endregion // Act

            #region Assert

            ItemObject item = new ItemObject();

            Assert.AreEqual(1, items.Count);

            // Assert that the first item's properties are correct
            item = items[0];
            item.Status = "Update";
            item.ItemRow = 1;
            Assert.AreEqual("ST1234", item.ItemId); // Item Id
            Assert.AreEqual("Update", item.Status);
            Assert.AreEqual("N", item.PsStatus); // PS Status
            Assert.AreEqual("N", item.SellOnAmazon); // Sell On Amazon
            Assert.AreEqual("N", item.SellOnFanatics); // Sell On Fanatics
            Assert.AreEqual("N", item.SellOnHayneedle); // Sell On Hayneedle
            Assert.AreEqual("N", item.SellOnWalmart); // Sell On Walmart

            #endregion // Assert
        }

        /// <summary>
        ///     Tests that LoadItem() loads in all values properly and that all update fields are set to false on load.
        /// </summary>
        [TestMethod]
        public void LoadItemTest_CheckAllFieldsLoad_FieldsShouldLoad()
        {
            #region SetUp

            FakeWorkbookReader fakeWorkbookReader = new FakeWorkbookReader();
            fakeWorkbookReader.ColumnHeaders.Add("ItemID");
            fakeWorkbookReader.ColumnHeaders.Add("AccountingGroup");
            fakeWorkbookReader.ColumnHeaders.Add("CasepackHeight");
            fakeWorkbookReader.ColumnHeaders.Add("CasepackLength");
            fakeWorkbookReader.ColumnHeaders.Add("CasepackQty");
            fakeWorkbookReader.ColumnHeaders.Add("CasepackWidth");
            fakeWorkbookReader.ColumnHeaders.Add("CasepackWeight");
            fakeWorkbookReader.ColumnHeaders.Add("Color");
            fakeWorkbookReader.ColumnHeaders.Add("CountryOfOrigin");
            fakeWorkbookReader.ColumnHeaders.Add("CostProfileGroup");
            fakeWorkbookReader.ColumnHeaders.Add("DefaultActualCostCad");
            fakeWorkbookReader.ColumnHeaders.Add("DefaultActualCostUsd");
            fakeWorkbookReader.ColumnHeaders.Add("Description");
            fakeWorkbookReader.ColumnHeaders.Add("Duty");
            fakeWorkbookReader.ColumnHeaders.Add("Ean");
            fakeWorkbookReader.ColumnHeaders.Add("Gpc");
            fakeWorkbookReader.ColumnHeaders.Add("Height");
            fakeWorkbookReader.ColumnHeaders.Add("InnerpackHeight");
            fakeWorkbookReader.ColumnHeaders.Add("InnerpackLength");
            fakeWorkbookReader.ColumnHeaders.Add("InnerpackQuantity");
            fakeWorkbookReader.ColumnHeaders.Add("InnerpackWidth");
            fakeWorkbookReader.ColumnHeaders.Add("InnerpackWeight");
            fakeWorkbookReader.ColumnHeaders.Add("Isbn");
            fakeWorkbookReader.ColumnHeaders.Add("ItemCategory");
            fakeWorkbookReader.ColumnHeaders.Add("ItemFamily");
            fakeWorkbookReader.ColumnHeaders.Add("ItemGroup");
            fakeWorkbookReader.ColumnHeaders.Add("Language");
            fakeWorkbookReader.ColumnHeaders.Add("Length");
            fakeWorkbookReader.ColumnHeaders.Add("LicenseBeginDate");
            fakeWorkbookReader.ColumnHeaders.Add("ListPriceCad");
            fakeWorkbookReader.ColumnHeaders.Add("ListPriceMxn");
            fakeWorkbookReader.ColumnHeaders.Add("ListPriceUsd");
            fakeWorkbookReader.ColumnHeaders.Add("MetaDescription");
            fakeWorkbookReader.ColumnHeaders.Add("MfgSource");
            fakeWorkbookReader.ColumnHeaders.Add("Msrp");
            fakeWorkbookReader.ColumnHeaders.Add("MsrpCad");
            fakeWorkbookReader.ColumnHeaders.Add("MsrpMxn");
            fakeWorkbookReader.ColumnHeaders.Add("ProductFormat");
            fakeWorkbookReader.ColumnHeaders.Add("ProductGroup");
            fakeWorkbookReader.ColumnHeaders.Add("ProductLine");
            fakeWorkbookReader.ColumnHeaders.Add("PricingGroup");
            fakeWorkbookReader.ColumnHeaders.Add("StandardCost");
            fakeWorkbookReader.ColumnHeaders.Add("StatsCode");
            fakeWorkbookReader.ColumnHeaders.Add("TariffCode");
            fakeWorkbookReader.ColumnHeaders.Add("Territory");
            fakeWorkbookReader.ColumnHeaders.Add("Udex");
            fakeWorkbookReader.ColumnHeaders.Add("Upc");
            fakeWorkbookReader.ColumnHeaders.Add("Weight");
            fakeWorkbookReader.ColumnHeaders.Add("Width");
            fakeWorkbookReader.ColumnHeaders.Add("Item Keywords");
            fakeWorkbookReader.ColumnHeaders.Add("Copyright");
            fakeWorkbookReader.ColumnHeaders.Add("License");
            fakeWorkbookReader.ColumnHeaders.Add("RelatedProducts");
            fakeWorkbookReader.ColumnHeaders.Add("ProductType");
            fakeWorkbookReader.ColumnHeaders.Add("InStockDate");
            fakeWorkbookReader.ColumnHeaders.Add("Category");
            fakeWorkbookReader.ColumnHeaders.Add("NewCategory");
            fakeWorkbookReader.ColumnHeaders.Add("Title");
            fakeWorkbookReader.ColumnHeaders.Add("ShortDescription");
            fakeWorkbookReader.ColumnHeaders.Add("Size");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce ASIN");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Bullet 1");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Bullet 2");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Bullet 3");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Bullet 4");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Bullet 5");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Components");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Cost");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Country of Origin");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce External ID");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce External ID Type");
            fakeWorkbookReader.ColumnHeaders.Add("Image Path 1");
            fakeWorkbookReader.ColumnHeaders.Add("Image Path 2");
            fakeWorkbookReader.ColumnHeaders.Add("Image Path 3");
            fakeWorkbookReader.ColumnHeaders.Add("Image Path 4");
            fakeWorkbookReader.ColumnHeaders.Add("Image Path 5");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Item Height");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Item Length");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Item Name");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Item Weight");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Item Width");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Page Qty");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Model Name");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Package Height");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Package Length");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Package Weight");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Package Width");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Product Category");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Product Description");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Product Subcategory");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Manufacturer Name");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Msrp");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Search Terms");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce Size");
            fakeWorkbookReader.ColumnHeaders.Add("Ecommerce UPC");
            fakeWorkbookReader.ColumnHeaders.Add("Amazon Active");
            fakeWorkbookReader.AddWorksheetRow();
            fakeWorkbookReader.AddCellValue("ST1234"); // Item Id
            fakeWorkbookReader.AddCellValue("AccountingGroup"); // Accounting Group
            fakeWorkbookReader.AddCellValue("CasepackHeight"); // CasepackHeight
            fakeWorkbookReader.AddCellValue("CasepackLength"); // CasepackLength
            fakeWorkbookReader.AddCellValue("CasepackQty"); // CasepackQty
            fakeWorkbookReader.AddCellValue("CasepackWidth"); // CasepackWidth
            fakeWorkbookReader.AddCellValue("CasepackWeight"); // CasepackWeight
            fakeWorkbookReader.AddCellValue("COLOR"); // Color
            fakeWorkbookReader.AddCellValue("CountryOfOrigin"); // Country of Origin
            fakeWorkbookReader.AddCellValue("CostProfileGroup"); // Cost Profile Group
            fakeWorkbookReader.AddCellValue("3.30"); // Default Actual Cost CAD
            fakeWorkbookReader.AddCellValue("5.57"); // Default Actual Cost USD
            fakeWorkbookReader.AddCellValue("Description"); // Description
            fakeWorkbookReader.AddCellValue("5.90"); // Duty
            fakeWorkbookReader.AddCellValue("Ean"); // Ean
            fakeWorkbookReader.AddCellValue("Gpc"); // Gpc
            fakeWorkbookReader.AddCellValue("9"); // Height
            fakeWorkbookReader.AddCellValue("1.1"); // Innerpack Height
            fakeWorkbookReader.AddCellValue("1.2"); // Innerpack Length
            fakeWorkbookReader.AddCellValue("1.3"); // Innerpack Quantity
            fakeWorkbookReader.AddCellValue("1.4"); // Innerpack Width
            fakeWorkbookReader.AddCellValue("1.5"); // Innerpack Weight
            fakeWorkbookReader.AddCellValue("Isbn"); // Isbn
            fakeWorkbookReader.AddCellValue("ItemCategory"); // Item Category
            fakeWorkbookReader.AddCellValue("ItemFamily"); // Item Family
            fakeWorkbookReader.AddCellValue("ItemGroup"); // Item Group
            fakeWorkbookReader.AddCellValue("ENG"); // Language
            fakeWorkbookReader.AddCellValue("7.3"); // Length
            fakeWorkbookReader.AddCellValue("LicenseBeginDate"); // License Begin Date
            fakeWorkbookReader.AddCellValue("4.5"); // List Price Cad
            fakeWorkbookReader.AddCellValue("5.4"); // List Price Mxn
            fakeWorkbookReader.AddCellValue("5.6"); // List Price Usd
            fakeWorkbookReader.AddCellValue("MetaDescription"); // MetaDescription
            fakeWorkbookReader.AddCellValue("MfgSource"); // Mfg Source
            fakeWorkbookReader.AddCellValue("MSRP"); // MSRP
            fakeWorkbookReader.AddCellValue("MSRPCAD"); // MSRP CAD
            fakeWorkbookReader.AddCellValue("MSRPMXN"); // MSRP CAD
            fakeWorkbookReader.AddCellValue("ProductFormat"); // Product Format
            fakeWorkbookReader.AddCellValue("ProductGroup"); // Product Group
            fakeWorkbookReader.AddCellValue("ProductLine"); // Product Line
            fakeWorkbookReader.AddCellValue("PricingGroup"); // Pricing Group
            fakeWorkbookReader.AddCellValue("5.57"); // Standard Cost
            fakeWorkbookReader.AddCellValue("StatsCode"); // Stats Code
            fakeWorkbookReader.AddCellValue("TariffCode"); // Tariff Code
            fakeWorkbookReader.AddCellValue("USA"); // Territory
            fakeWorkbookReader.AddCellValue("Udex"); // Udex
            fakeWorkbookReader.AddCellValue("Upc"); // Upc
            fakeWorkbookReader.AddCellValue("47"); // Weight
            fakeWorkbookReader.AddCellValue("67"); // Width
            fakeWorkbookReader.AddCellValue("ItemKeywords"); // Item Keywords
            fakeWorkbookReader.AddCellValue("Copyright"); // Copyright
            fakeWorkbookReader.AddCellValue("License"); // License
            fakeWorkbookReader.AddCellValue("RelatedProducts"); // Related Products
            fakeWorkbookReader.AddCellValue("ProductType"); // Product Type
            fakeWorkbookReader.AddCellValue("InStockDate"); // In Stock Date
            fakeWorkbookReader.AddCellValue("Category"); // Category
            fakeWorkbookReader.AddCellValue("NewCategory"); // New Category
            fakeWorkbookReader.AddCellValue("Title"); // Title
            fakeWorkbookReader.AddCellValue("ShortDescription"); // Short Description
            fakeWorkbookReader.AddCellValue("Size"); // Size
            fakeWorkbookReader.AddCellValue("Ecommerce Asin");
            fakeWorkbookReader.AddCellValue("Ecommerce Bullet 1");
            fakeWorkbookReader.AddCellValue("Ecommerce Bullet 2");
            fakeWorkbookReader.AddCellValue("Ecommerce Bullet 3");
            fakeWorkbookReader.AddCellValue("Ecommerce Bullet 4");
            fakeWorkbookReader.AddCellValue("Ecommerce Bullet 5");
            fakeWorkbookReader.AddCellValue("Ecommerce Components");
            fakeWorkbookReader.AddCellValue("Ecommerce Cost");
            fakeWorkbookReader.AddCellValue("Ecommerce Country of Origin");
            fakeWorkbookReader.AddCellValue("Ecommerce External ID");
            fakeWorkbookReader.AddCellValue("Ecommerce External ID Type");
            fakeWorkbookReader.AddCellValue("Ecommerce Image Path 1");
            fakeWorkbookReader.AddCellValue("Ecommerce Image Path 2");
            fakeWorkbookReader.AddCellValue("Ecommerce Image Path 3");
            fakeWorkbookReader.AddCellValue("Ecommerce Image Path 4");
            fakeWorkbookReader.AddCellValue("Ecommerce Image Path 5");
            fakeWorkbookReader.AddCellValue("Ecommerce Item Height");
            fakeWorkbookReader.AddCellValue("Ecommerce Item Length");
            fakeWorkbookReader.AddCellValue("Ecommerce Item Name");
            fakeWorkbookReader.AddCellValue("Ecommerce Item Weight");
            fakeWorkbookReader.AddCellValue("Ecommerce Item Width");
            fakeWorkbookReader.AddCellValue("Ecommerce Page Qty");
            fakeWorkbookReader.AddCellValue("Ecommerce Model Name");
            fakeWorkbookReader.AddCellValue("Ecommerce Package Height");
            fakeWorkbookReader.AddCellValue("Ecommerce Package Length");
            fakeWorkbookReader.AddCellValue("Ecommerce Package Weight");
            fakeWorkbookReader.AddCellValue("Ecommerce Package Width");
            fakeWorkbookReader.AddCellValue("Ecommerce Product Category");
            fakeWorkbookReader.AddCellValue("Ecommerce Product Description");
            fakeWorkbookReader.AddCellValue("Ecommerce Product Subcategory");
            fakeWorkbookReader.AddCellValue("Ecommerce Manufacturer Name");
            fakeWorkbookReader.AddCellValue("Ecommerce Msrp");
            fakeWorkbookReader.AddCellValue("Ecommerce Search Terms");
            fakeWorkbookReader.AddCellValue("Ecommerce Size");
            fakeWorkbookReader.AddCellValue("Ecommerce Upc");
            fakeWorkbookReader.AddCellValue("Amazon Active");
            TestItemRepository testItemRepository = new TestItemRepository();

            #endregion // Set Up

            #region Act

            ItemService itemService = new ItemService(fakeWorkbookReader, testItemRepository, new TestTemplateRepository());
            ObservableCollection<ItemObject> items = itemService.LoadExcelItems("Add", string.Empty);

            #endregion // Act

            #region Assert

            ItemObject item = new ItemObject();

            Assert.AreEqual(1, items.Count);

            // Assert that the first item's properties are correct
            item = items[0];
            item.Status = "Update";
            item.ItemRow = 1;
            Assert.AreEqual("ST1234", item.ItemId); // Item Id
            Assert.AreEqual("AccountingGroup", item.AccountingGroup); // Accounting Group
            Assert.AreEqual("CasepackHeight", item.CasepackHeight); // CasepackHeight
            Assert.AreEqual("CasepackLength", item.CasepackLength); // CasepackLength
            Assert.AreEqual("CasepackQty", item.CasepackQty); // CasepackQty
            Assert.AreEqual("CasepackWidth", item.CasepackWidth); // CasepackWidth
            Assert.AreEqual("CasepackWeight", item.CasepackWeight); // CasepackWeight
            Assert.AreEqual("COLOR", item.Color); // Color
            Assert.AreEqual("CountryOfOrigin", item.CountryOfOrigin); // Country of Origin
            Assert.AreEqual("CostProfileGroup", item.CostProfileGroup); // Cost Profile Group
            Assert.AreEqual("3.30", item.DefaultActualCostCad); // Default Actual Cost CAD
            Assert.AreEqual("5.57", item.DefaultActualCostUsd); // Default Actual Cost USD
            Assert.AreEqual("Description", item.Description); // Description
            // Assert.AreEqual("5.90", item.Duty); // Duty
            Assert.AreEqual("Ean", item.Ean); // Ean
            Assert.AreEqual("Gpc", item.Gpc); // Gpc
            Assert.AreEqual("9.0", item.Height); // Height
            Assert.AreEqual("InStockDate", item.InStockDate); // in stock date
            Assert.AreEqual("1.1", item.InnerpackHeight); // Innerpack Height
            Assert.AreEqual("1.2", item.InnerpackLength); // Innerpack Length
            Assert.AreEqual("1.3", item.InnerpackQuantity); // Innerpack Quantity
            Assert.AreEqual("1.4", item.InnerpackWidth); // Innerpack Width
            Assert.AreEqual("1.5", item.InnerpackWeight); // Innerpack Weight
            Assert.AreEqual("Isbn", item.Isbn); // Isbn
            Assert.AreEqual("ItemCategory", item.ItemCategory); // ItemCategory
            Assert.AreEqual("ItemFamily", item.ItemFamily); // Item Family
            Assert.AreEqual("ItemGroup", item.ItemGroup); // Item Group
            Assert.AreEqual("ENG", item.Language); // Language
            Assert.AreEqual("7.3", item.Length); // Length
            Assert.AreEqual("LicenseBeginDate", item.LicenseBeginDate); // License Begin Date
            Assert.AreEqual("4.50", item.ListPriceCad); // List Price Cad
            Assert.AreEqual("5.40", item.ListPriceMxn); // List Price Mxn
            Assert.AreEqual("5.60", item.ListPriceUsd); // List Price Usd
            Assert.AreEqual("MetaDescription", item.MetaDescription); // MetaDescription
            Assert.AreEqual("MfgSource", item.MfgSource); // Mfg Source
            Assert.AreEqual("MSRP", item.Msrp); // MSRP
            Assert.AreEqual("MSRPCAD", item.MsrpCad); // MSRPCAD
            Assert.AreEqual("MSRPMXN", item.MsrpMxn); // MSRPMXN
            Assert.AreEqual("ProductFormat", item.ProductFormat); // Product Format
            Assert.AreEqual("ProductGroup", item.ProductGroup); // Product Group
            Assert.AreEqual("ProductLine", item.ProductLine); // Product Line
            Assert.AreEqual("PricingGroup", item.PricingGroup); // Pricing Group
            Assert.AreEqual("5.57", item.StandardCost); // Standard Cost
            Assert.AreEqual("StatsCode", item.StatsCode); // Stats Code
            Assert.AreEqual("TariffCode", item.TariffCode); // Tariff Code
            Assert.AreEqual("USA", item.Territory); // Territory
            Assert.AreEqual("Udex", item.Udex); // Udex
            Assert.AreEqual("Upc", item.Upc); // Upc
            Assert.AreEqual("47.0", item.Weight); // Weight
            Assert.AreEqual("67.0", item.Width); // Width
            Assert.AreEqual("ItemKeywords", item.ItemKeywords); // Item Keywords
            Assert.AreEqual("Copyright", item.Copyright); // Copyright
            Assert.AreEqual("License", item.License); // License
            Assert.AreEqual("InStockDate", item.InStockDate); // In Stock Date
            Assert.AreEqual("Category", item.Category); // Category
            Assert.AreEqual("Title", item.Title); // Title
            Assert.AreEqual("ShortDescription", item.ShortDescription); // Short Description
            Assert.AreEqual("Size", item.Size); // Size
            Assert.AreEqual("Ecommerce Asin", item.Ecommerce_Asin);
            Assert.AreEqual("Ecommerce Bullet 1", item.Ecommerce_Bullet1);
            Assert.AreEqual("Ecommerce Bullet 2", item.Ecommerce_Bullet2);
            Assert.AreEqual("Ecommerce Bullet 3", item.Ecommerce_Bullet3);
            Assert.AreEqual("Ecommerce Bullet 4", item.Ecommerce_Bullet4);
            Assert.AreEqual("Ecommerce Bullet 5", item.Ecommerce_Bullet5);
            Assert.AreEqual("Ecommerce Components", item.Ecommerce_Components);
            Assert.AreEqual("Ecommerce Cost.00", item.Ecommerce_Cost);
            Assert.AreEqual("Ecommerce External ID", item.Ecommerce_ExternalId);
            Assert.AreEqual("Ecommerce External ID Type", item.Ecommerce_ExternalIdType);
            Assert.AreEqual("Ecommerce Image Path 1", item.ImagePath);
            Assert.AreEqual("Ecommerce Image Path 2", item.AltImageFile1);
            Assert.AreEqual("Ecommerce Image Path 3", item.AltImageFile2);
            Assert.AreEqual("Ecommerce Image Path 4", item.AltImageFile3);
            Assert.AreEqual("Ecommerce Image Path 5", item.AltImageFile4);
            Assert.AreEqual("Ecommerce Item Height.0", item.Ecommerce_ItemHeight);
            Assert.AreEqual("Ecommerce Item Length.0", item.Ecommerce_ItemLength);
            Assert.AreEqual("Ecommerce Item Name", item.Ecommerce_ItemName);
            Assert.AreEqual("Ecommerce Item Weight.0", item.Ecommerce_ItemWeight);
            Assert.AreEqual("Ecommerce Item Width.0", item.Ecommerce_ItemWidth);
            Assert.AreEqual("Ecommerce Model Name", item.Ecommerce_ModelName);
            Assert.AreEqual("Ecommerce Package Height.0", item.Ecommerce_PackageHeight);
            Assert.AreEqual("Ecommerce Package Length.0", item.Ecommerce_PackageLength);
            Assert.AreEqual("Ecommerce Package Weight.0", item.Ecommerce_PackageWeight);
            Assert.AreEqual("Ecommerce Package Width.0", item.Ecommerce_PackageWidth);
            Assert.AreEqual("Ecommerce Page Qty", item.Ecommerce_PageQty);
            Assert.AreEqual("Ecommerce Product Category", item.Ecommerce_ProductCategory);
            Assert.AreEqual("Ecommerce Product Description", item.Ecommerce_ProductDescription);
            Assert.AreEqual("Ecommerce Product Subcategory", item.Ecommerce_ProductSubcategory);
            Assert.AreEqual("Ecommerce Manufacturer Name", item.Ecommerce_ManufacturerName);
            Assert.AreEqual("Ecommerce Msrp.00", item.Ecommerce_Msrp);
            Assert.AreEqual("Ecommerce Search Terms", item.Ecommerce_SearchTerms);
            Assert.AreEqual("Ecommerce Size", item.Ecommerce_Size);
            Assert.AreEqual("Ecommerce Upc", item.Ecommerce_Upc);
            Assert.AreEqual("Amazon Active", item.SellOnAmazon);

            Assert.IsFalse(item.AccountingGroupUpdate); // Accounting Group    
            Assert.IsFalse(item.CasepackHeightUpdate); // CasepackHeight
            Assert.IsFalse(item.CasepackLengthUpdate); // CasepackLength
            Assert.IsFalse(item.CasepackQtyUpdate); // CasepackQty
            Assert.IsFalse(item.CasepackWidthUpdate); // CasepackWidth
            Assert.IsFalse(item.CasepackWeightUpdate); // CasepackWeight
            Assert.IsFalse(item.ColorUpdate); // Color
            Assert.IsFalse(item.CountryOfOriginUpdate); // Country of Origin
            Assert.IsFalse(item.CostProfileGroupUpdate); // Cost Profile Group
            Assert.IsFalse(item.DefaultActualCostCadUpdate); // Default Actual Cost CAD
            Assert.IsFalse(item.DefaultActualCostUsdUpdate); // Default Actual Cost USD
            Assert.IsFalse(item.DescriptionUpdate); // Description
            Assert.IsFalse(item.EanUpdate); // Ean
            Assert.IsFalse(item.GpcUpdate); // Gpc
            Assert.IsFalse(item.HeightUpdate); // Height
            Assert.IsFalse(item.InStockDateUpdate); // In Stock DAte
            Assert.IsFalse(item.InnerpackHeightUpdate); // Innerpack Height
            Assert.IsFalse(item.InnerpackLengthUpdate); // Innerpack Length
            Assert.IsFalse(item.InnerpackQuantityUpdate); // Innerpack Quantity
            Assert.IsFalse(item.InnerpackWidthUpdate); // Innerpack Width
            Assert.IsFalse(item.InnerpackWeightUpdate); // Innerpack Weight
            Assert.IsFalse(item.IsbnUpdate); // Isbn
            Assert.IsFalse(item.ItemCategoryUpdate); // ItemCategory
            Assert.IsFalse(item.ItemFamilyUpdate); // Item Family
            Assert.IsFalse(item.ItemGroupUpdate); // Item Group
            Assert.IsFalse(item.LanguageUpdate); // Language
            Assert.IsFalse(item.LengthUpdate); // Length
            Assert.IsFalse(item.LicenseBeginDateUpdate); // License Begin Date
            Assert.IsFalse(item.ListPriceCadUpdate); // List Price Cad
            Assert.IsFalse(item.ListPriceMxnUpdate); // List Price Mxn
            Assert.IsFalse(item.ListPriceUsdUpdate); // List Price Usd
            Assert.IsFalse(item.MetaDescriptionUpdate); // MetaDescription
            Assert.IsFalse(item.MfgSourceUpdate); // Mfg Source
            Assert.IsFalse(item.MsrpUpdate); // MSRP
            Assert.IsFalse(item.MsrpCadUpdate); // MSRPCAD
            Assert.IsFalse(item.MsrpMxnUpdate); // MSRPMXN
            Assert.IsFalse(item.ProductFormatUpdate); // Product Format
            Assert.IsFalse(item.ProductGroupUpdate); // Product Group
            Assert.IsFalse(item.ProductLineUpdate); // Product Line
            Assert.IsFalse(item.PricingGroupUpdate); // Pricing Group
            Assert.IsFalse(item.StandardCostUpdate); // Standard Cost
            Assert.IsFalse(item.StatsCodeUpdate); // Stats Code
            Assert.IsFalse(item.TariffCodeUpdate); // Tariff Code
            Assert.IsFalse(item.TerritoryUpdate); // Territory
            Assert.IsFalse(item.UdexUpdate); // Udex
            Assert.IsFalse(item.UpcUpdate); // Upc
            Assert.IsFalse(item.WeightUpdate); // Weight
            Assert.IsFalse(item.WidthUpdate); // Width
            Assert.IsFalse(item.ItemKeywordsUpdate); // Item Keywords
            Assert.IsFalse(item.CopyrightUpdate); // Copyright
            Assert.IsFalse(item.LicenseUpdate); // License
            Assert.IsFalse(item.CategoryUpdate); // Category
            Assert.IsFalse(item.TitleUpdate); // Title
            Assert.IsFalse(item.ShortDescriptionUpdate); // Short Description
            Assert.IsFalse(item.SizeUpdate); // Size
            Assert.IsFalse(item.Ecommerce_AsinUpdate);
            Assert.IsFalse(item.Ecommerce_Bullet1Update);
            Assert.IsFalse(item.Ecommerce_Bullet2Update);
            Assert.IsFalse(item.Ecommerce_Bullet3Update);
            Assert.IsFalse(item.Ecommerce_Bullet4Update);
            Assert.IsFalse(item.Ecommerce_Bullet5Update);
            Assert.IsFalse(item.Ecommerce_ComponentsUpdate);
            Assert.IsFalse(item.Ecommerce_CostUpdate);
            Assert.IsFalse(item.Ecommerce_ExternalIdUpdate);
            Assert.IsFalse(item.Ecommerce_ExternalIdTypeUpdate);
            Assert.IsFalse(item.Ecommerce_ImagePath1Update);
            Assert.IsFalse(item.Ecommerce_ImagePath2Update);
            Assert.IsFalse(item.Ecommerce_ImagePath3Update);
            Assert.IsFalse(item.Ecommerce_ImagePath4Update);
            Assert.IsFalse(item.Ecommerce_ImagePath5Update);
            Assert.IsFalse(item.Ecommerce_ItemHeightUpdate);
            Assert.IsFalse(item.Ecommerce_ItemLengthUpdate);
            Assert.IsFalse(item.Ecommerce_ItemNameUpdate);
            Assert.IsFalse(item.Ecommerce_ItemWeightUpdate);
            Assert.IsFalse(item.Ecommerce_ItemWidthUpdate);
            Assert.IsFalse(item.Ecommerce_ModelNameUpdate);
            Assert.IsFalse(item.Ecommerce_PackageHeightUpdate);
            Assert.IsFalse(item.Ecommerce_PackageLengthUpdate);
            Assert.IsFalse(item.Ecommerce_PackageWeightUpdate);
            Assert.IsFalse(item.Ecommerce_PackageWidthUpdate);
            Assert.IsFalse(item.Ecommerce_PageQtyUpdate);
            Assert.IsFalse(item.Ecommerce_ProductCategoryUpdate);
            Assert.IsFalse(item.Ecommerce_ProductDescriptionUpdate);
            Assert.IsFalse(item.Ecommerce_ProductSubcategoryUpdate);
            Assert.IsFalse(item.Ecommerce_ManufacturerNameUpdate);
            Assert.IsFalse(item.Ecommerce_MsrpUpdate);
            Assert.IsFalse(item.Ecommerce_SearchTermsUpdate);
            Assert.IsFalse(item.Ecommere_SizeUpdate);
            Assert.IsFalse(item.Ecommere_UpcUpdate);

            #endregion // Assert
        }

        /// <summary>
        ///     Tests that the itemObj Helper organizes different language inputs to match validation.
        /// </summary>
        [TestMethod]
        public void OrganizeLanguage_OrganizeLanguageValue_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            TestItemRepository itemRepository = new TestItemRepository();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), itemRepository, new TestTemplateRepository());
            string value1 = "ENG/SPA/FRA";
            string value2 = "ENG/FRE/SPA";
            string value3 = "SPA/ENG";
            string value4 = "SPA/FRA";
            string value5 = "SPA/ENG/FRA";

            string newValue1 = string.Empty;
            string newValue2 = string.Empty;
            string newValue3 = string.Empty;
            string newValue4 = string.Empty;
            string newValue5 = string.Empty;

            #endregion // Setup

            #region Act

            newValue1 = DbUtil.OrderLanguage(value1);
            newValue2 = DbUtil.OrderLanguage(value2);
            newValue3 = DbUtil.OrderLanguage(value3);
            newValue4 = DbUtil.OrderLanguage(value4);
            newValue5 = DbUtil.OrderLanguage(value5);

            #endregion // Act

            #region Assert

            Assert.AreEqual(newValue1, "ENG/FRA/SPA");
            Assert.AreEqual(newValue2, "ENG/FRA/SPA");
            Assert.AreEqual(newValue3, "ENG/SPA");
            Assert.AreEqual(newValue4, "FRA/SPA");
            Assert.AreEqual(newValue5, "ENG/FRA/SPA");


            #endregion // Assert
        }

        /// <summary>
        ///     Tests that the itemObj Helper organizes different territory inputs to match validation.
        /// </summary>
        [TestMethod]
        public void OrganizeTerritory_OrganizeTerritoryValue_ShouldSucceed()
        {
            #region Setup

            TestItemRepository itemRepository = new TestItemRepository();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), itemRepository, new TestTemplateRepository());
            string value1 = "CAN/MEX/USA";
            string value2 = "USA/CAN/MEX";
            string value3 = "MEX/USA";
            string value4 = "MEX/CAN";
            string value5 = "MEX/USA/CAN";

            string newValue1 = string.Empty;
            string newValue2 = string.Empty;
            string newValue3 = string.Empty;
            string newValue4 = string.Empty;
            string newValue5 = string.Empty;

            #endregion // Setup

            #region Act

            newValue1 = DbUtil.OrderTerritory(value1);
            newValue2 = DbUtil.OrderTerritory(value2);
            newValue3 = DbUtil.OrderTerritory(value3);
            newValue4 = DbUtil.OrderTerritory(value4);
            newValue5 = DbUtil.OrderTerritory(value5);

            #endregion // Act

            #region Assert

            Assert.AreEqual(newValue1, "USA/CAN/MEX");
            Assert.AreEqual(newValue2, "USA/CAN/MEX");
            Assert.AreEqual(newValue3, "USA/MEX");
            Assert.AreEqual(newValue4, "CAN/MEX");
            Assert.AreEqual(newValue5, "USA/CAN/MEX");


            #endregion // Assert
        }

        [TestMethod]
        public void ParseProductTranslationIds_NoProductTranslationGiven_ShouldReturnEmpty()
        {
            #region Assemble

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            string productIds = "";
            string parentId = "RP1234";
            #endregion // Assemble

            #region Act

            List<ChildElement> x = itemService.ParseChildElementIds(parentId, productIds);

            #endregion // Act

            #region Assert

            Assert.AreEqual(0, x.Count);

            #endregion // Assert
        }

        

        [TestMethod]
        public void RetrieveExceptions_ValueAllowsException_ShouldReturnEmptyError()
        {
            #region Assemble

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion

            #region Act

            string errorMessage = itemService.ValidateUpc("", "", "", "1.00", "Door Sp", "Sticker", "", "1234", "", 1);

            #endregion // Act

            #region Assert

            Assert.AreEqual("", errorMessage);

            #endregion // Assert
        }

        [TestMethod]
        public void RetrieveExceptions_ValuesMatch_ShouldReturnValue()
        {
            #region Assemble
            
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            GlobalData.UpcProductFormatExceptions.Add("Door Sp");
            
            #endregion // Assemble

            #region Act

            List<string> results = GlobalData.UpcProductFormatExceptions;

            #endregion // Act

            #region Assert

            Assert.IsTrue(results.Contains("Door Sp"));

            #endregion // Assert
        }

        /// <summary>
        ///     Checks that AssignDirectImport returns valid values when proper values are assigned.
        /// </summary>
        [TestMethod]
        public void ReturnItemPrice_HasProdQty_ShouldReturnCombinedValue()
        {
            #region Assemble

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion // Assemble

            #region Act
            string price = "2.50";
            string prodQty = "4";
            string result = itemService.ReturnItemPrice(price, prodQty);

            #endregion // Act

            #region Assert

            Assert.AreEqual(result, "10.00");

            #endregion // Assert
        }
        
        /// <summary>
        ///     Tests that the round value function works
        /// </summary>
        [TestMethod]
        public void RoundValueCheck_ValueIsTooLong_ShouldRound()
        {
            #region Setup

            GlobalData.ClearValues();
            TestItemRepository itemRepository = new TestItemRepository();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), itemRepository, new TestTemplateRepository());

            string insertValue1 = "45.1236901";
            string insertValue2 = "3.3534100";
            string insertValue3 = "3.353";

            #endregion // Setup

            #region Act

            string returnValue1 = DbUtil.RoundValue4Dec(insertValue1);
            string returnValue2 = DbUtil.RoundValue4Dec(insertValue2);
            string returnValue3 = DbUtil.RoundValue4Dec(insertValue3);

            #endregion // Act

            #region Assert

            Assert.AreEqual("45.1236", returnValue1);
            Assert.AreEqual("3.3534", returnValue2);
            Assert.AreEqual("3.353", returnValue3);


            #endregion // Assert
        }

        /// <summary>
        ///     This test creates a scenario, but not just any scenario. This scenario reads the rows of a worksheet 
        ///     with item id's and blank item id's and asserts that no items are created form rows with no item ids.
        /// </summary>
        [TestMethod]
        public void ReadItems_ReadItemsWithBlankItemId_ShouldNotCreateBlankItems()
        {
            #region SetUp

            GlobalData.ClearValues();
            FakeWorkbookReader fakeWorkbookReader = new FakeWorkbookReader();
            fakeWorkbookReader.ColumnHeaders.Add("ItemID");
            fakeWorkbookReader.ColumnHeaders.Add("DacUsd");
            fakeWorkbookReader.AddWorksheetRow();
            fakeWorkbookReader.AddCellValue("RP1234");
            fakeWorkbookReader.AddCellValue("9");
            fakeWorkbookReader.AddWorksheetRow();
            fakeWorkbookReader.AddCellValue("");
            fakeWorkbookReader.AddCellValue("");
            fakeWorkbookReader.AddWorksheetRow();
            fakeWorkbookReader.AddCellValue("");
            fakeWorkbookReader.AddCellValue("");
            fakeWorkbookReader.AddWorksheetRow();
            fakeWorkbookReader.AddCellValue("ST9876");
            fakeWorkbookReader.AddCellValue("5");
            TestItemRepository testItemRepository = new TestItemRepository();

            #endregion // Set Up

            #region Act

            ItemService itemService = new ItemService(fakeWorkbookReader, testItemRepository, new TestTemplateRepository());
            ObservableCollection<ItemObject> items = itemService.LoadExcelItems("Add", string.Empty);


            #endregion // Act

            #region Assert

            ItemObject item = items[0];

            Assert.AreEqual(2, items.Count);

            // Assert that the first item's properties are correct
            Assert.AreEqual("9", item.DefaultActualCostUsd);
            Assert.AreEqual("RP1234", item.ItemId);
            Assert.IsFalse(item.DefaultActualCostUsdUpdate);

            #endregion // Assert
        }

        /// <summary>
        ///     Tests that the IdExists function properly detects when an itemID does not exist.
        /// </summary>
        /// <summary>
        ///     This test creates a scenario that reads rows from a worksheet with item ids and asserts that
        ///     items are created from the rows.
        /// </summary>
        /// 
        [TestMethod]
        public void ReadItems_ReadValidItems_ShouldCreateItems()
        {
            #region SetUp

            GlobalData.ClearValues();
            FakeWorkbookReader fakeWorkbookReader = new FakeWorkbookReader();
            fakeWorkbookReader.ColumnHeaders.Add("ItemID");
            fakeWorkbookReader.ColumnHeaders.Add("AccountingGroup");
            fakeWorkbookReader.ColumnHeaders.Add("CasepackHeight");
            fakeWorkbookReader.ColumnHeaders.Add("CasepackLength");
            fakeWorkbookReader.ColumnHeaders.Add("CasepackQty");
            fakeWorkbookReader.ColumnHeaders.Add("CasepackWidth");
            fakeWorkbookReader.ColumnHeaders.Add("CasepackWeight");
            fakeWorkbookReader.ColumnHeaders.Add("Color");
            fakeWorkbookReader.ColumnHeaders.Add("CountryOfOrigin");
            fakeWorkbookReader.ColumnHeaders.Add("CostProfileGroup");
            fakeWorkbookReader.ColumnHeaders.Add("DefaultActualCostCad");
            fakeWorkbookReader.ColumnHeaders.Add("DefaultActualCostUsd");
            fakeWorkbookReader.ColumnHeaders.Add("Description");
            fakeWorkbookReader.ColumnHeaders.Add("Duty");
            fakeWorkbookReader.ColumnHeaders.Add("Ean");
            fakeWorkbookReader.ColumnHeaders.Add("Gpc");
            fakeWorkbookReader.ColumnHeaders.Add("Height");
            fakeWorkbookReader.ColumnHeaders.Add("InnerpackHeight");
            fakeWorkbookReader.ColumnHeaders.Add("InnerpackLength");
            fakeWorkbookReader.ColumnHeaders.Add("InnerpackQuantity");
            fakeWorkbookReader.ColumnHeaders.Add("InnerpackWidth");
            fakeWorkbookReader.ColumnHeaders.Add("InnerpackWeight");
            fakeWorkbookReader.ColumnHeaders.Add("Isbn");
            fakeWorkbookReader.ColumnHeaders.Add("ItemCategory");
            fakeWorkbookReader.ColumnHeaders.Add("ItemFamily");
            fakeWorkbookReader.ColumnHeaders.Add("ItemGroup");
            fakeWorkbookReader.ColumnHeaders.Add("Language");
            fakeWorkbookReader.ColumnHeaders.Add("Length");
            fakeWorkbookReader.ColumnHeaders.Add("LicenseBeginDate");
            fakeWorkbookReader.ColumnHeaders.Add("ListPriceCad");
            fakeWorkbookReader.ColumnHeaders.Add("ListPriceMxn");
            fakeWorkbookReader.ColumnHeaders.Add("ListPriceUsd");
            fakeWorkbookReader.ColumnHeaders.Add("MetaDescription");
            fakeWorkbookReader.ColumnHeaders.Add("MfgSource");
            fakeWorkbookReader.ColumnHeaders.Add("Msrp");
            fakeWorkbookReader.ColumnHeaders.Add("MsrpCad");
            fakeWorkbookReader.ColumnHeaders.Add("MsrpMxn");
            fakeWorkbookReader.ColumnHeaders.Add("ProductFormat");
            fakeWorkbookReader.ColumnHeaders.Add("ProductGroup");
            fakeWorkbookReader.ColumnHeaders.Add("ProductLine");
            fakeWorkbookReader.ColumnHeaders.Add("PricingGroup");
            fakeWorkbookReader.ColumnHeaders.Add("StandardCost");
            fakeWorkbookReader.ColumnHeaders.Add("StatsCode");
            fakeWorkbookReader.ColumnHeaders.Add("TariffCode");
            fakeWorkbookReader.ColumnHeaders.Add("Territory");
            fakeWorkbookReader.ColumnHeaders.Add("Udex");
            fakeWorkbookReader.ColumnHeaders.Add("Upc");
            fakeWorkbookReader.ColumnHeaders.Add("Weight");
            fakeWorkbookReader.ColumnHeaders.Add("Width");
            fakeWorkbookReader.ColumnHeaders.Add("Item Keywords");
            fakeWorkbookReader.ColumnHeaders.Add("Copyright");
            fakeWorkbookReader.ColumnHeaders.Add("License");
            fakeWorkbookReader.ColumnHeaders.Add("RelatedProducts");
            fakeWorkbookReader.ColumnHeaders.Add("ProductType");
            fakeWorkbookReader.ColumnHeaders.Add("PS Status");
            fakeWorkbookReader.ColumnHeaders.Add("InStockDate");
            fakeWorkbookReader.ColumnHeaders.Add("Category");
            fakeWorkbookReader.ColumnHeaders.Add("NewCategory");
            fakeWorkbookReader.ColumnHeaders.Add("Title");
            fakeWorkbookReader.ColumnHeaders.Add("ShortDescription");
            fakeWorkbookReader.ColumnHeaders.Add("Size");
            fakeWorkbookReader.AddWorksheetRow();
            fakeWorkbookReader.AddCellValue("ST1234"); // Item Id
            fakeWorkbookReader.AddCellValue("AccountingGroup"); // Accounting Group
            fakeWorkbookReader.AddCellValue("CasepackHeight"); // CasepackHeight
            fakeWorkbookReader.AddCellValue("CasepackLength"); // CasepackLength
            fakeWorkbookReader.AddCellValue("CasepackQty"); // CasepackQty
            fakeWorkbookReader.AddCellValue("CasepackWidth"); // CasepackWidth
            fakeWorkbookReader.AddCellValue("CasepackWeight"); // CasepackWeight
            fakeWorkbookReader.AddCellValue("COLOR"); // Color
            fakeWorkbookReader.AddCellValue("CountryOfOrigin"); // Country of Origin
            fakeWorkbookReader.AddCellValue("CostProfileGroup"); // Cost Profile Group
            fakeWorkbookReader.AddCellValue("3.30"); // Default Actual Cost CAD
            fakeWorkbookReader.AddCellValue("5.57"); // Default Actual Cost USD
            fakeWorkbookReader.AddCellValue("Description"); // Description
            fakeWorkbookReader.AddCellValue("5.90"); // Duty
            fakeWorkbookReader.AddCellValue("Ean"); // Ean
            fakeWorkbookReader.AddCellValue("Gpc"); // Gpc
            fakeWorkbookReader.AddCellValue("9"); // Height
            fakeWorkbookReader.AddCellValue("1.1"); // Innerpack Height
            fakeWorkbookReader.AddCellValue("1.2"); // Innerpack Length
            fakeWorkbookReader.AddCellValue("1.3"); // Innerpack Quantity
            fakeWorkbookReader.AddCellValue("1.4"); // Innerpack Width
            fakeWorkbookReader.AddCellValue("1.5"); // Innerpack Weight
            fakeWorkbookReader.AddCellValue("Isbn"); // Isbn
            fakeWorkbookReader.AddCellValue("ItemCategory"); // Item Category
            fakeWorkbookReader.AddCellValue("ItemFamily"); // Item Family
            fakeWorkbookReader.AddCellValue("ItemGroup"); // Item Group
            fakeWorkbookReader.AddCellValue("ENG"); // Language
            fakeWorkbookReader.AddCellValue("7.3"); // Length
            fakeWorkbookReader.AddCellValue("LicenseBeginDate"); // License Begin Date
            fakeWorkbookReader.AddCellValue("4.5"); // List Price Cad
            fakeWorkbookReader.AddCellValue("5.4"); // List Price Mxn
            fakeWorkbookReader.AddCellValue("5.6"); // List Price Usd
            fakeWorkbookReader.AddCellValue("MetaDescription"); // MetaDescription
            fakeWorkbookReader.AddCellValue("MfgSource"); // Mfg Source
            fakeWorkbookReader.AddCellValue("MSRP"); // MSRP
            fakeWorkbookReader.AddCellValue("MSRPCAD"); // MSRP CAD
            fakeWorkbookReader.AddCellValue("MSRPMXN"); // MSRP CAD
            fakeWorkbookReader.AddCellValue("ProductFormat"); // Product Format
            fakeWorkbookReader.AddCellValue("ProductGroup"); // Product Group
            fakeWorkbookReader.AddCellValue("ProductLine"); // Product Line
            fakeWorkbookReader.AddCellValue("PricingGroup"); // Pricing Group
            fakeWorkbookReader.AddCellValue("5.57"); // Standard Cost
            fakeWorkbookReader.AddCellValue("StatsCode"); // Stats Code
            fakeWorkbookReader.AddCellValue("TariffCode"); // Tariff Code
            fakeWorkbookReader.AddCellValue("USA"); // Territory
            fakeWorkbookReader.AddCellValue("Udex"); // Udex
            fakeWorkbookReader.AddCellValue("Upc"); // Upc
            fakeWorkbookReader.AddCellValue("47"); // Weight
            fakeWorkbookReader.AddCellValue("67.0"); // Width
            fakeWorkbookReader.AddCellValue("ItemKeywords"); // Item Keywords
            fakeWorkbookReader.AddCellValue("Copyright"); // Copyright
            fakeWorkbookReader.AddCellValue("License"); // License
            fakeWorkbookReader.AddCellValue("RelatedProducts"); // Related Products
            fakeWorkbookReader.AddCellValue("ProductType"); // Product Type
            fakeWorkbookReader.AddCellValue("I"); // PS Status
            fakeWorkbookReader.AddCellValue("InStockDate"); // In Stock Date
            fakeWorkbookReader.AddCellValue("Category"); // Category
            fakeWorkbookReader.AddCellValue("NewCategory"); // New Category
            fakeWorkbookReader.AddCellValue("Title"); // Title
            fakeWorkbookReader.AddCellValue("ShortDescription"); // Short Description
            fakeWorkbookReader.AddCellValue("Size"); // Size
            TestItemRepository testItemRepository = new TestItemRepository();

            #endregion // Set Up

            #region Act

            ItemService itemService = new ItemService(fakeWorkbookReader, testItemRepository, new TestTemplateRepository());
            ObservableCollection<ItemObject> items = itemService.LoadExcelItems("Add", string.Empty);


            #endregion // Act

            #region Assert

            ItemObject item = new ItemObject();

            Assert.AreEqual(1, items.Count);

            // Assert that the first item's properties are correct
            item = items[0];
            item.Status = "Update";
            item.ItemRow = 1;
            Assert.AreEqual("ST1234", item.ItemId); // Item Id
            Assert.AreEqual("AccountingGroup", item.AccountingGroup); // Accounting Group
            Assert.AreEqual("CasepackHeight", item.CasepackHeight); // CasepackHeight
            Assert.AreEqual("CasepackLength", item.CasepackLength); // CasepackLength
            Assert.AreEqual("CasepackQty", item.CasepackQty); // CasepackQty
            Assert.AreEqual("CasepackWidth", item.CasepackWidth); // CasepackWidth
            Assert.AreEqual("CasepackWeight", item.CasepackWeight); // CasepackWeight
            Assert.AreEqual("COLOR", item.Color); // Color
            Assert.AreEqual("CountryOfOrigin", item.CountryOfOrigin); // Country of Origin
            Assert.AreEqual("CostProfileGroup", item.CostProfileGroup); // Cost Profile Group
            Assert.AreEqual("3.30", item.DefaultActualCostCad); // Default Actual Cost CAD
            Assert.AreEqual("5.57", item.DefaultActualCostUsd); // Default Actual Cost USD
            Assert.AreEqual("Description", item.Description); // Description
            // Assert.AreEqual("5.90", item.Duty); // Duty
            Assert.AreEqual("Ean", item.Ean); // Ean
            Assert.AreEqual("Gpc", item.Gpc); // Gpc
            Assert.AreEqual("9.0", item.Height); // Height
            Assert.AreEqual("1.1", item.InnerpackHeight); // Innerpack Height
            Assert.AreEqual("1.2", item.InnerpackLength); // Innerpack Length
            Assert.AreEqual("1.3", item.InnerpackQuantity); // Innerpack Quantity
            Assert.AreEqual("1.4", item.InnerpackWidth); // Innerpack Width
            Assert.AreEqual("1.5", item.InnerpackWeight); // Innerpack Weight
            Assert.AreEqual("Isbn", item.Isbn); // Isbn
            Assert.AreEqual("ItemCategory", item.ItemCategory); // ItemCategory
            Assert.AreEqual("ItemFamily", item.ItemFamily); // Item Family
            Assert.AreEqual("ItemGroup", item.ItemGroup); // Item Group
            Assert.AreEqual("ENG", item.Language); // Language
            Assert.AreEqual("7.3", item.Length); // Length
            Assert.AreEqual("LicenseBeginDate", item.LicenseBeginDate); // License Begin Date
            Assert.AreEqual("4.50", item.ListPriceCad); // List Price Cad
            Assert.AreEqual("5.40", item.ListPriceMxn); // List Price Mxn
            Assert.AreEqual("5.60", item.ListPriceUsd); // List Price Usd
            Assert.AreEqual("MetaDescription", item.MetaDescription); // MetaDescription
            Assert.AreEqual("MfgSource", item.MfgSource); // Mfg Source
            Assert.AreEqual("MSRP", item.Msrp); // MSRP
            Assert.AreEqual("MSRPCAD", item.MsrpCad); // MSRPCAD
            Assert.AreEqual("MSRPMXN", item.MsrpMxn); // MSRPMXN
            Assert.AreEqual("ProductFormat", item.ProductFormat); // Product Format
            Assert.AreEqual("ProductGroup", item.ProductGroup); // Product Group
            Assert.AreEqual("ProductLine", item.ProductLine); // Product Line
            Assert.AreEqual("PricingGroup", item.PricingGroup); // Pricing Group
            Assert.AreEqual("5.57", item.StandardCost); // Standard Cost
            Assert.AreEqual("StatsCode", item.StatsCode); // Stats Code
            Assert.AreEqual("TariffCode", item.TariffCode); // Tariff Code
            Assert.AreEqual("USA", item.Territory); // Territory
            Assert.AreEqual("Udex", item.Udex); // Udex
            Assert.AreEqual("Upc", item.Upc); // Upc
            Assert.AreEqual("47.0", item.Weight); // Weight
            Assert.AreEqual("67.0", item.Width); // Width
            Assert.AreEqual("ItemKeywords", item.ItemKeywords); // Item Keywords
            Assert.AreEqual("Copyright", item.Copyright); // Copyright
            Assert.AreEqual("License", item.License); // License
            Assert.AreEqual("I", item.PsStatus); // PS Status
            Assert.AreEqual("InStockDate", item.InStockDate); // In Stock Date
            Assert.AreEqual("Category", item.Category); // Category
            Assert.AreEqual("Title", item.Title); // Title
            Assert.AreEqual("ShortDescription", item.ShortDescription); // Short Description
            // Assert.AreEqual("Size", item.Size); // Size

            #endregion // Assert
        }

        [TestMethod]
        public void SetProductType_ItemHasValidValue_ShouldReturnValidType()
        {
            #region SetUp
            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            List<string> List1 = new List<string>();
            List1.Add("Stickers & Tattoos/Decals/One Color Decals");
            List1.Add("");
            List1.Add("");
            List<string> List2 = new List<string>();
            List2.Add("Stickers & Tattoos/Office & Educational/Labels");
            List2.Add("Bookmarks/Bookmarks");
            List2.Add("");
            List<string> List3 = new List<string>();
            List3.Add("Stickers & Tattoos/Stickers/Grab & Go");
            List3.Add("");
            List3.Add("");
            List<string> List4 = new List<string>();
            List4.Add("Stickers & Tattoos/Tattoos/Glow Tattoos");
            List4.Add("Stickers & Tattoos");
            List4.Add("Stickers & Tattoos/Tattoos");
            List<string> List5 = new List<string>();
            List5.Add("Bookmarks/Page Clips/Magnetic Page Clips");
            List5.Add("");
            List5.Add("");
            List<string> List6 = new List<string>();
            List6.Add("Calendars/Deluxe Wall Calendars");
            List6.Add("Art Zone/Coloring Journals");
            List6.Add("");
            List<string> List7 = new List<string>();
            List7.Add("Posters/Posters/Wall Posters");
            List7.Add("");
            List7.Add("");
            List<string> List8 = new List<string>();
            List8.Add("Art Zone/Coloring Journals");
            List8.Add("");
            List8.Add("");
            List<string> List9 = new List<string>();
            List9.Add("Writing/Ballpoint Pens/Glow Pens");
            List9.Add("");
            List9.Add("");
            #endregion // Set Up

            #region Act

            string result1 = itemService.SetProductType(List1);
            string result2 = itemService.SetProductType(List2);
            string result3 = itemService.SetProductType(List3);
            string result4 = itemService.SetProductType(List4);
            string result5 = itemService.SetProductType(List5);
            string result6 = itemService.SetProductType(List6);
            string result7 = itemService.SetProductType(List7);
            string result8 = itemService.SetProductType(List8);
            string result9 = itemService.SetProductType(List9);

            #endregion // Act

            #region Assert

            Assert.AreEqual("Sticker Product", result1);
            Assert.AreEqual("Sticker Product", result2);
            Assert.AreEqual("Sticker Product", result3);
            Assert.AreEqual("Sticker Product", result4);
            Assert.AreEqual("Bookmark Product", result5);
            Assert.AreEqual("Calendar Product", result6);
            Assert.AreEqual("Poster Product", result7);
            Assert.AreEqual("Art Zone Product", result8);
            Assert.AreEqual("Writing Product", result9);

            #endregion // Assert
        }

        #region Validation Tests

        [TestMethod]
        public void ValidateAll_IsSubmit_ShouldReturnError()
        {
            #region Assemble

            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion // Assemble

            #region Act

            //ObservableCollection<ItemError> ErrorList =  itemService.ValidateAll()

            #endregion // Act

            #region Assert

            #endregion // Assert
        }

        /// <summary>
        ///     This method test the ValidateCasepackHeight method with a numeric string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateBillOfMaterials_ValueHasDuplicates_ShouldFail()
        {
            #region Setup

            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            List<ChildElement> childList = new List<ChildElement>();
            childList.Add(new ChildElement("TEST2", "TEST1"));
            childList.Add(new ChildElement("TEST2", "TEST1"));
            List<string> currentIds = new List<string>();
            currentIds.Add("TEST2");

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateBillOfMaterials("TEST1", childList, currentIds, 1);

            #endregion //Act

            #region Assert

            Assert.AreNotEqual(result, string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateCasepackHeight method with a numeric string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateCasepack_ValueIsANumber_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateCasepack("12", "1", "1", "1", 1, "Casepack");

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateCasepackLength method with a non-numeric string. This method asserts that the validation fails.
        /// </summary>
        [TestMethod]
        public void ValidateCasepack_SingleValueIsEmpty_ShouldError()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateCasepack("", "1", "2", "1", 1, "Casepack");

            #endregion //Act

            #region Assert

            Assert.IsTrue(result != string.Empty);

            #endregion //Assert
        }
        /// <summary>
        ///     This method test the ValidateCasepackLength method with a numeric string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateCasepackWidth_ValueIsANumber_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateCasepack("12", "1", "1", "1", 1, "Casepack");

            #endregion //Act

            #region Assert

            Assert.AreEqual(result, "");

            #endregion //Assert
        }
        /// <summary>
        ///     This method test the ValidateCasepackWidth method with a non-numeric string. This method asserts that the validation fails.
        /// </summary>
        [TestMethod]
        public void ValidateCasepackWidth_ValueIsNotANumber_ShouldError()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateCasepack("abd", "1", "4", "1", 1, "Casepack Width");

            #endregion //Act

            #region Assert

            Assert.AreNotEqual(result, "");

            #endregion //Assert
        }
        /// <summary>
        ///     This method test the ValidateCategory method with a valid category string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateCategory_ValueIsValidCategory_ShouldSucceed()
        {
            #region Setup
            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            string errorMessage = "";
            #endregion //Setup

            #region Act

            errorMessage = itemValidator.ValidateCategory("Category1", true);

            #endregion //Act

            #region Assert
            Assert.AreEqual("", errorMessage);

            #endregion //Assert
        }
        /// <summary>
        ///     This method tests the ValidateCategory method with an invalid category string. This method asserts that the validation fails.
        /// </summary>
        [TestMethod]
        public void ValidateCategory_ValueIsNotValidCategory_ShouldFail()
        {
            #region Setup

            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            string errorMessage = "";
            #endregion //Setup

            #region Act

            errorMessage = itemValidator.ValidateCategory("Not Category", true);

            #endregion //Act

            #region Assert

            Assert.IsTrue(errorMessage != "");

            #endregion //Assert
        }
        /// <summary>
        ///     This method test the ValidateColor method with a valid string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateColor_ValueIsValidString_ShouldSucceed()
        {
            #region Setup
            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateColor("PURPLE", 1);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }
        /// <summary>
        ///     This method test the ValidateCopyright method with a valid string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateCopyright_ValueIsValidString_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateCopyright("Trends");

            #endregion //Act

            #region Assert

            Assert.AreEqual(result, "");

            #endregion //Assert
        }
        /// <summary>
        ///     This method test the ValidateCountryOrOrigin method with a valid string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateCountryOfOrigin_ValueIsValidString_ShouldSucceed()
        {
            #region Setup
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            GlobalData.CountriesOfOrigin.Add("USA", "United States");
            
            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateCountryOfOrigin("USA", "1", 1);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method tests the ValidateDescription method with a valid string. Checks that a sample of special characters
        ///     are picked up by the validation. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateDescription_ValueIsValidString_ShouldSucceed()
        {
            #region Setup

            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            GlobalData.ClearValues();
            GlobalData.SpecialCharacters.Add(",");
            GlobalData.SpecialCharacters.Add("™");
            GlobalData.SpecialCharacters.Add("®");
            GlobalData.SpecialCharacters.Add("ñ");
            GlobalData.SpecialCharacters.Add("Á");
            
            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateDescription("Wall Calendar", 1);
            string result2 = itemValidator.ValidateDescription("Wall Calendar, Your Mom", 1);
            string result3 = itemValidator.ValidateDescription("Wall Calendar™", 1);
            string result4 = itemValidator.ValidateDescription("Wall Calendar®", 1);
            string result5 = itemValidator.ValidateDescription("Wall Caleñdar", 1);
            string result6 = itemValidator.ValidateDescription("WÁll Calendar", 1);

            #endregion //Act

            #region Assert
            Assert.IsFalse(result2 == string.Empty);
            Assert.IsFalse(result3 == string.Empty);
            Assert.IsFalse(result4 == string.Empty);
            Assert.IsFalse(result5 == string.Empty);
            Assert.IsFalse(result6 == string.Empty);
            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method tests the upc validation against items trying to use an existing upc value.
        /// </summary>
        [TestMethod]
        public void ValidateEcommerceUpcField_ItemHasDuplicateValue_ResultsVary()
        {
            #region Setup

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            GlobalData.ClearValues();
            GlobalData.Upcs.Add(new KeyValuePair < string, string > ("000000000000", "RP1234"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("123456789123", "RP3322"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("000000000000", "RP1234"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("000000000000", "RP1234WM"));
           
            ItemObject item = new ItemObject();
            #endregion // Setup

            #region Act

            // other item has upc (RP1234)
            string value = itemService.ValidateEcommerce_Upc("000000000000", "RP1239", "000120000001", "Update", false);
            // other item has matching ecommerce upc (RP3322)
            string value2 = itemService.ValidateEcommerce_Upc("123456789123", "RP1239", "000012000001", "Update", false);
            // unique upc, should pass
            string value3 = itemService.ValidateEcommerce_Upc("123000000000", "RP1239", "000012000001", "Update", false);
            // matching upc but item suffix pass, should pass
            string value4 = itemService.ValidateEcommerce_Upc("000000000000", "RP1234DI", "000012000001", "Update", false);

            #endregion // Act

            #region Assert

            Assert.AreNotEqual("", value);
            Assert.AreNotEqual("", value2);
            Assert.AreEqual("", value3);
            Assert.AreEqual("", value4);

            #endregion // Assert
        }

        /// <summary>
        ///     This method test the ValidateHeight method with a numeric string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateHeight_ValueIsANumber_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateHeight("16", 1);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateInnerpackHeight method with a numeric string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateInnerpackHeight_AValueIsMissing_ShouldFail()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateInnerpack("16", "", "2", "1", 1, "Casepack");

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateInnerpackHeight method with a numeric string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateInnerpackLength_ValueIsANumber_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateInnerpack("16", "1", "2", "1", 1, "Casepack");

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateInnerpackQuantity method with a numeric string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateInnerpackQuantity_ValueIsANumber_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateInnerpackQuantity("16", 1);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateInnerpackWidth method with a numeric string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateInnerpackWidth_ValueIsANumber_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateInnerpack("16", "1", "2", "1", 1, "Casepack");

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateItemGroup method with a numeric string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateItemGroup_ValueIsANumber_ShouldSucceed()
        {
            #region Setup

            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            GlobalData.ClearValues();
            GlobalData.ItemGroups.Add("POSTER");
           
            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateItemGroup("POSTER", 1);

            #endregion //Act

            #region Assert

            Assert.AreEqual(result, "");

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateItemCategory method with a numeric string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateItemCategory_ValueIsANumber_ShouldSucceed()
        {
            #region Setup

            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            GlobalData.ClearValues();
            GlobalData.ProductCategories.Add("POSTER");
            
            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateItemCategory("POSTER", 1);

            #endregion //Act

            #region Assert

            Assert.AreEqual(result, "");

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateItemId method with a valid unique Id and a status of "Add". This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateItemId_ValueIsANumberStatusIsAdd_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            string status = "Add";
            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateItemId("BR0P8866", status);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateItemId method with a valid unique Id and a status of "Update". This method asserts that the validation fails.
        /// </summary>
        [TestMethod]
        public void ValidateItemId_ValueIsANumberStatusIsUpdaate_ShouldFail()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            string status = "Update";
            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateItemId("BR0P8866", status);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result != string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateLength method with a numeric string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateLength_ValueIsANumber_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateLength("12", 1);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateLength method with a non-numeric string. This method asserts that the validation fails.
        /// </summary>
        [TestMethod]
        public void ValidateLength_ValueIsNotANumber_ShouldError()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateLength("abc", 1);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result != string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidatePricingGroup method with a valid string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidatePricingGroup_ValueIsAnEmptyValidString_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidatePricingGroup("", "0", "0", 1);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidatePricingGroup method with a valid string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidatePricingGroup_ValueIsEmptyListPriceHasValue_ShouldFail()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidatePricingGroup("", "1", "0", 1);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result != string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidatePricingGroup method with a valid string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidatePsStatuses_ValueIsLegit_ShouldSucceed()
        {
            #region Setup
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            GlobalData.ClearValues();
            GlobalData.PsStatuses.Add("A");
            GlobalData.PsStatuses.Add("CO");
            GlobalData.PsStatuses.Add("D");
            GlobalData.PsStatuses.Add("I");
            GlobalData.PsStatuses.Add("S");
            
            #endregion //Setup

            #region Act

            string result1 = itemValidator.ValidatePsStatus("A", "Item");
            string result2 = itemValidator.ValidatePsStatus("CO", "Item");
            string result3 = itemValidator.ValidatePsStatus("D", "Item");
            string result4 = itemValidator.ValidatePsStatus("I", "Item");
            string result5 = itemValidator.ValidatePsStatus("S", "Item");

            #endregion //Act

            #region Assert

            Assert.AreEqual(result1, "");
            Assert.AreEqual(result2, "");
            Assert.AreEqual(result3, "");
            Assert.AreEqual(result4, "");
            Assert.AreEqual(result5, "");

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidatePricingGroup method with a valid string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidatePsStatuses_ValueIsNotLegit_ShouldFail()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result1 = itemValidator.ValidatePsStatus("Never", "Item");
            string result2 = itemValidator.ValidatePsStatus("Gonna", "Item");
            string result3 = itemValidator.ValidatePsStatus("Give", "Item");
            string result4 = itemValidator.ValidatePsStatus("You", "Item");
            string result5 = itemValidator.ValidatePsStatus("Up", "Item");

            #endregion //Act

            #region Assert

            Assert.AreNotEqual(result1, "");
            Assert.AreNotEqual(result2, "");
            Assert.AreNotEqual(result3, "");
            Assert.AreNotEqual(result4, "");
            Assert.AreNotEqual(result5, "");

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateStandardCost method with a valid string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateStandardCost_ValueIsAValidString_ShouldSucceed()
        {
            #region Setup

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemService.ValidateStandardCost("001", 1);

            #endregion //Act

            #region Assert

            Assert.AreEqual("", result);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateWidth method with a valid string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateWidth_ValueIsAValidInteger_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateWidth("12", 1);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateWidth method with a valid string. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateItemKeywords_ValueIsAValidInteger_ShouldSucceed()
        {
            #region Setup

            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateItemKeywords("Bears, Seagulls, Bazooka", true);

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the ValidateTerritory method with a valid date. This method asserts that the validation succeeds.
        /// </summary>
        [TestMethod]
        public void ValidateInStockDate_ValueIsAValidInteger_ShouldSucceed()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemValidator = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            #endregion //Setup

            #region Act

            string result = itemValidator.ValidateInStockDate("5/17/14");

            #endregion //Act

            #region Assert

            Assert.IsTrue(result == string.Empty);

            #endregion //Assert
        }

        /// <summary>
        ///     This method test the validateWebFields method with an item containing web invalid web fields. This methods asserts that the validation fails.
        /// </summary>
        [TestMethod]
        public void ValidateLanguageField_ItemHasInvalidLanguageValue_ShouldFail()
        {
            #region Setup

            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            ItemObject item = new ItemObject();
            string value = "";
            #endregion // Setup

            #region Act

            value = itemService.ValidateLanguage(item.Language, "1", '1');

            #endregion // Act

            #region Assert

            Assert.AreNotEqual(value, "");

            #endregion // Assert
        }

        /// <summary>
        ///     Tests the product format validation. Checks that validation catches proper format casing.
        /// </summary>
        [TestMethod]
        public void ValidateProductFormat_ItemHasInvaidValue_ShouldReturnError()
        {
            #region Assemble

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            GlobalData.ClearValues();
            ProductFormat prodFormat = new ProductFormat("Stickers3", "y", "x");
            GlobalData.ProductFormats.Add(prodFormat);
            
            string value1 = "STICKERS3";
            string value2 = "Stickers3";

            #endregion // Assemble

            #region Act

            string result1 = itemService.ValidateProductFormat("x", "y", value1, "", 0);
            string result2 = itemService.ValidateProductFormat("x", "y", value2, "", 0);

            #endregion // Act

            #region Assert

            Assert.AreNotEqual("", result1);
            Assert.AreEqual("", result2);

            #endregion // Assert
        }

        [TestMethod]
        public void ValidateProductIdTranslation_ItemHasNoOpenOrderLines_ShouldFail()
        {
            #region Assemble

            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            List<ChildElement> productIdTranslationList1 = new List<ChildElement>();
            List<ChildElement> productIdTranslationList2 = new List<ChildElement>();
            List<ChildElement> emptyProductIdTranslationList = new List<ChildElement>();

            List<string> CurrentIds = new List<string>();
            CurrentIds.Add("ST1111");
            CurrentIds.Add("ST2222");
            CurrentIds.Add("TEST1");
            CurrentIds.Add("TEST3");
            CurrentIds.Add("TEST4");
            productIdTranslationList2.Add(new ChildElement("ST1111", "FROMITEM1", 2));
            productIdTranslationList2.Add(new ChildElement("ST2222", "FROMITEM1", 2));
            productIdTranslationList1.Add(new ChildElement("TEST3", "ST9999", 2));
            productIdTranslationList1.Add(new ChildElement("TEST4", "ST9999", 2));
            productIdTranslationList1.Add(new ChildElement("TEST4", "ST9999", 2));

            #endregion // Assemble

            #region Act

            string result1 = itemService.ValidateProductIdTranslation("RP2222", productIdTranslationList2, CurrentIds, "POSTER", "RRR", "Update", 0);
            string result2 = itemService.ValidateProductIdTranslation("RP2222", emptyProductIdTranslationList, CurrentIds, "POSTER", "RRR", "Update", 0);

            string result3 = itemService.ValidateProductIdTranslation("RP2222", productIdTranslationList2, CurrentIds, "POSTER", "RRR", "Add", 0);
            string result4 = itemService.ValidateProductIdTranslation("RP2222", emptyProductIdTranslationList, CurrentIds, "POSTER", "RRR", "Add", 0);
            string result5 = itemService.ValidateProductIdTranslation("ST9999", productIdTranslationList1, CurrentIds, "POSTER", "RRR", "Add", 0);
            #endregion // Act

            #region Assert
            
          Assert.AreEqual("", result1);
            Assert.AreEqual("", result2);
           Assert.AreEqual("", result3);
            Assert.AreEqual("", result4);
            Assert.AreNotEqual("", result5);

            #endregion // Assert

        }
        /*
        [TestMethod]
        public void ValidateProductIdTranslation_ItemHasOpenOrderLines_ShouldFail()
        {
            #region Assemble

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            GlobalData.ClearValues();
            GlobalData.ItemIds.Add("RP2222");
            GlobalData.ItemIds.Add("TestItem2");
            GlobalData.ItemIds.Add("TEST2");
            
            List<ChildElement> productIdTranslationList1 = new List<ChildElement>();
            List<ChildElement> productIdTranslationList2 = new List<ChildElement>();

            List<string> CurrentIds = new List<string>();
            CurrentIds.Add("TEST1");
            CurrentIds.Add("TEST2");
            productIdTranslationList1.Add(new ChildElement("TestItem2", "TEST1", 2));
            productIdTranslationList1.Add(new ChildElement("TEST2", "TEST1", 2));
            productIdTranslationList2.Add(new ChildElement("TEST2", "ST9999", 2));

            #endregion // Assemble

            #region Act

            string result1 = itemService.ValidateProductIdTranslation("RP2222", productIdTranslationList1, CurrentIds, "POSTER", "RRR", "Update", 0);
            string result2 = itemService.ValidateProductIdTranslation("RP2222", productIdTranslationList2, CurrentIds, "POSTER", "RRR", "Update", 0);

            string result3 = itemService.ValidateProductIdTranslation("RP2222", productIdTranslationList1, CurrentIds, "POSTER", "RRR", "Add", 0);
            string result4 = itemService.ValidateProductIdTranslation("RP2222", productIdTranslationList2, CurrentIds, "POSTER", "RRR", "Add", 0);
            #endregion // Act

            #region Assert

            Assert.AreNotEqual("", result1);
            Assert.AreNotEqual("", result2);
            Assert.AreEqual("", result3);
            Assert.AreEqual("", result4);

            #endregion // Assert

        }
        */
        /// <summary>
        ///     This method tests the upc validation against items trying to use an existing upc value.
        /// </summary>
        [TestMethod]
        public void ValidateUpcField_ItemHasDuplicateValue_ResultsVary()
        {
            #region Setup

            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            GlobalData.ClearValues();
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("123456789123", "RP2347"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("123456789098", "RP2341"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("000000000000", "RP3323"));
            GlobalData.Upcs.Add(new KeyValuePair<string, string>("000000666666", "RP3329"));
            
            ItemObject item = new ItemObject();
            item.ItemId = "RP2341";
            item.Upc = "123456789098";
            #endregion // Setup

            #region Act

            /// Upc already assigned to another item's ecommerce Upc
            string value = itemService.ValidateUpc("123456789123", "RP2341", "Update", "4.00", "Poster", "Poster", "Poster", "1234", "000000666666", 1);

            /// Upc and ecommerce match. Should fail
            string value2 = itemService.ValidateUpc("123456789098", "RP2341", "Add", "4.00", "Poster", "Poster", "Poster", "1234", "123456789098", 1);

            string value3 = itemService.ValidateUpc("123456789127", "RP3323", "Update", "4.00", "Poster", "Poster", "Poster", "1234", "000000666666", 1);

            string value4 = itemService.ValidateUpc("000000000000", "RP3323", "Update", "4.00", "Poster", "Poster", "Poster", "1234", "000000000000", 1);

            #endregion // Act

            #region Assert

            Assert.AreNotEqual("", value);
            Assert.AreNotEqual("", value2);
            Assert.AreEqual("", value3);
            Assert.AreNotEqual("", value4);

            #endregion // Assert
        }

        #endregion // Validation Tests

        #region Ecommerce Validation Tests

        /// <summary>
        ///     Test that blank values return error messages when Ecommercee fields are required.
        /// </summary>
        [TestMethod]
        public void ValidateRequiredEcommerceFields_HaveBlankValues_ShouldReturnErrors()
        {
            #region Assemble

            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            bool Ecommerce_Required = true;

            #endregion // Assemble

            #region Act

            string Ecommerce_BulletBlank = "1" + itemService.ValidateEcommerce_Bullet("", "1", Ecommerce_Required);
            string Ecommerce_BulletBlank2 = "2" + itemService.ValidateEcommerce_Bullet("", "5", false);
            string Ecommerce_ComponentsBlank = "3" + itemService.ValidateEcommerce_Components("", Ecommerce_Required);
            string Ecommerce_CostBlank = "4" + itemService.ValidateEcommerce_Cost("", "", Ecommerce_Required);
            string Ecommerce_ExternalIdTypeBlank = "6" + itemService.ValidateEcommerce_ExternalIdType("", Ecommerce_Required);
            string Ecommerce_ExternalIdBlank = "7" + itemService.ValidateEcommerce_ExternalId("", "", Ecommerce_Required);
            string Ecommerce_ImagePath1Blank = "8" + itemService.ValidateImagePath("", "1", Ecommerce_Required);
            string Ecommerce_ImagePath5Blank = "9" + itemService.ValidateImagePath("", "5", false);
            string Ecommerce_ItemHeightBlank = "10" + itemService.ValidateEcommerce_ItemHeight("", Ecommerce_Required);
            string Ecommerce_ItemLengthBlank = "11" + itemService.ValidateEcommerce_ItemLength("", Ecommerce_Required);
            string Ecommerce_ItemNameBlank = "12" + itemService.ValidateEcommerce_ItemName("", Ecommerce_Required);
            string Ecommerce_ItemWeightBlank = "13" + itemService.ValidateEcommerce_ItemWeight("", Ecommerce_Required);
            string Ecommerce_ItemWidthBlank = "14" + itemService.ValidateEcommerce_ItemWidth("", Ecommerce_Required);
            string Ecommerce_ModelNameBlank = "15" + itemService.ValidateEcommerce_ModelName("", Ecommerce_Required);
            string Ecommerce_PackageHeightBlank = "16" + itemService.ValidateEcommerce_PackageHeight("", Ecommerce_Required);
            string Ecommerce_PackageLengthBlank = "17" + itemService.ValidateEcommerce_PackageLength("", Ecommerce_Required);
            string Ecommerce_PackageWeightBlank = "18" + itemService.ValidateEcommerce_PackageWeight("", Ecommerce_Required);
            string Ecommerce_PackageWidthBlank = "19" + itemService.ValidateEcommerce_PackageWidth("", Ecommerce_Required);
            string Ecommerce_ProductCategoryBlank = "20" + itemService.ValidateEcommerce_ProductCategory("", Ecommerce_Required);
            string Ecommerce_ProductDescriptionBlank = "21" + itemService.ValidateEcommerce_ProductDescription("", Ecommerce_Required);
            string Ecommerce_ProductSubcategoryBlank = "22" + itemService.ValidateEcommerce_ProductSubcategory("", Ecommerce_Required);
            string Ecommerce_ManufacturerNameBlank = "23" + itemService.ValidateEcommerce_ManufacturerName("", Ecommerce_Required);
            string Ecommerce_MsrpBlank = "24" + itemService.ValidateEcommerce_Msrp("", Ecommerce_Required);
            string Ecommerce_SearchTermsBlank = "25" + itemService.ValidateEcommerce_SearchTerms("", Ecommerce_Required, "Add");

            #endregion // Act

            #region Assert

            Assert.AreNotEqual(Ecommerce_BulletBlank, "1");
            Assert.AreEqual(Ecommerce_BulletBlank2, "2");
            Assert.AreNotEqual(Ecommerce_ComponentsBlank, "3");
            Assert.AreNotEqual(Ecommerce_CostBlank, "4");
            Assert.AreNotEqual(Ecommerce_ExternalIdTypeBlank, "6");
            Assert.AreNotEqual(Ecommerce_ExternalIdBlank, "7");
            Assert.AreNotEqual(Ecommerce_ImagePath1Blank, "8");
            Assert.AreEqual(Ecommerce_ImagePath5Blank, "9");
            Assert.AreNotEqual(Ecommerce_ItemHeightBlank, "10");
            Assert.AreNotEqual(Ecommerce_ItemLengthBlank, "11");
            Assert.AreNotEqual(Ecommerce_ItemNameBlank, "12");
            Assert.AreNotEqual(Ecommerce_ItemWeightBlank, "13");
            Assert.AreNotEqual(Ecommerce_ItemWidthBlank, "14");
            Assert.AreNotEqual(Ecommerce_ModelNameBlank, "15");
            Assert.AreNotEqual(Ecommerce_PackageHeightBlank, "16");
            Assert.AreNotEqual(Ecommerce_PackageLengthBlank, "17");
            Assert.AreNotEqual(Ecommerce_PackageWeightBlank, "18");
            Assert.AreNotEqual(Ecommerce_PackageWidthBlank, "19");
            Assert.AreNotEqual(Ecommerce_ProductCategoryBlank, "20");
            Assert.AreNotEqual(Ecommerce_ProductDescriptionBlank, "21");
            Assert.AreNotEqual(Ecommerce_ProductSubcategoryBlank, "22");
            Assert.AreNotEqual(Ecommerce_ManufacturerNameBlank, "23");
            Assert.AreNotEqual(Ecommerce_MsrpBlank, "24");
            Assert.AreNotEqual(Ecommerce_SearchTermsBlank, "25");

            #endregion // Assert
        }

        /// <summary>
        ///     Test that a blank value will result as an error when other Ecommerce fields are entered.
        /// </summary>
        [TestMethod]
        public void ValidateRequiredEcommerceFields_HasAMissingValue_ShouldReturnErrors()
        {
            #region Assemble

            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            bool Ecommerce_Required = true;

            #endregion // Assemble

            #region Act
            string Ecommerce_BulletBlank = "1" + itemService.ValidateEcommerce_Bullet("", "1", Ecommerce_Required);
            string Ecommerce_BulletBlank2 = "2" + itemService.ValidateEcommerce_Bullet("", "5", false);
            string Ecommerce_ComponentsBlank = "3" + itemService.ValidateEcommerce_Components("", Ecommerce_Required);
            string Ecommerce_CostBlank = "4" + itemService.ValidateEcommerce_Cost("", "", Ecommerce_Required);
            string Ecommerce_ExternalIdTypeBlank = "6" + itemService.ValidateEcommerce_ExternalIdType("", Ecommerce_Required);
            string Ecommerce_ExternalIdBlank = "7" + itemService.ValidateEcommerce_ExternalId("", "", Ecommerce_Required);
            string Ecommerce_ImagePath1Blank = "8" + itemService.ValidateImagePath("", "1",Ecommerce_Required);
            string Ecommerce_ImagePath5Blank = "9" + itemService.ValidateImagePath("", "5", false);
            string Ecommerce_ItemHeightBlank = "10" + itemService.ValidateEcommerce_ItemHeight("", Ecommerce_Required);
            string Ecommerce_ItemLengthBlank = "11" + itemService.ValidateEcommerce_ItemLength("", Ecommerce_Required);
            string Ecommerce_ItemNameBlank = "12" + itemService.ValidateEcommerce_ItemName("", Ecommerce_Required);
            string Ecommerce_ItemWeightBlank = "13" + itemService.ValidateEcommerce_ItemWeight("", Ecommerce_Required);
            string Ecommerce_ItemWidthBlank = "14" + itemService.ValidateEcommerce_ItemWidth("", Ecommerce_Required);
            string Ecommerce_ModelNameBlank = "15" + itemService.ValidateEcommerce_ModelName("", Ecommerce_Required);
            string Ecommerce_PackageHeightBlank = "16" + itemService.ValidateEcommerce_PackageHeight("", Ecommerce_Required);
            string Ecommerce_PackageLengthBlank = "17" + itemService.ValidateEcommerce_PackageLength("", Ecommerce_Required);
            string Ecommerce_PackageWeightBlank = "18" + itemService.ValidateEcommerce_PackageWeight("", Ecommerce_Required);
            string Ecommerce_PackageWidthBlank = "19" + itemService.ValidateEcommerce_PackageWidth("", Ecommerce_Required);
            string Ecommerce_ProductCategoryBlank = "20" + itemService.ValidateEcommerce_ProductCategory("", Ecommerce_Required);
            string Ecommerce_ProductDescriptionBlank = "21" + itemService.ValidateEcommerce_ProductDescription("", Ecommerce_Required);
            string Ecommerce_ProductSubcategoryBlank = "22" + itemService.ValidateEcommerce_ProductSubcategory("", Ecommerce_Required);
            string Ecommerce_ManufacturerNameBlank = "23" + itemService.ValidateEcommerce_ManufacturerName("", Ecommerce_Required);
            string Ecommerce_MsrpBlank = "24" + itemService.ValidateEcommerce_Msrp("", Ecommerce_Required);
            string Ecommerce_SearchTermsBlank = "25" + itemService.ValidateEcommerce_SearchTerms("", Ecommerce_Required, "Update");

            #endregion // Act

            #region Assert

            Assert.AreNotEqual(Ecommerce_BulletBlank, "1");
            Assert.AreEqual(Ecommerce_BulletBlank2, "2");
            Assert.AreNotEqual(Ecommerce_ComponentsBlank, "3");
            Assert.AreNotEqual(Ecommerce_CostBlank, "4");
            Assert.AreNotEqual(Ecommerce_ExternalIdTypeBlank, "6");
            Assert.AreNotEqual(Ecommerce_ExternalIdBlank, "7");
            Assert.AreNotEqual(Ecommerce_ImagePath1Blank, "8");
            Assert.AreEqual(Ecommerce_ImagePath5Blank, "9");
            Assert.AreNotEqual(Ecommerce_ItemHeightBlank, "10");
            Assert.AreNotEqual(Ecommerce_ItemLengthBlank, "11");
            Assert.AreNotEqual(Ecommerce_ItemNameBlank, "12");
            Assert.AreNotEqual(Ecommerce_ItemWeightBlank, "13");
            Assert.AreNotEqual(Ecommerce_ItemWidthBlank, "14");
            Assert.AreNotEqual(Ecommerce_ModelNameBlank, "15");
            Assert.AreNotEqual(Ecommerce_PackageHeightBlank, "16");
            Assert.AreNotEqual(Ecommerce_PackageLengthBlank, "17");
            Assert.AreNotEqual(Ecommerce_PackageWeightBlank, "18");
            Assert.AreNotEqual(Ecommerce_PackageWidthBlank, "19");
            Assert.AreNotEqual(Ecommerce_ProductCategoryBlank, "20");
            Assert.AreNotEqual(Ecommerce_ProductDescriptionBlank, "21");
            Assert.AreNotEqual(Ecommerce_ProductSubcategoryBlank, "22");
            Assert.AreNotEqual(Ecommerce_ManufacturerNameBlank, "23");
            Assert.AreNotEqual(Ecommerce_MsrpBlank, "24");
            Assert.AreNotEqual(Ecommerce_SearchTermsBlank, "25");

            #endregion // Assert
        }

        /// <summary>
        ///     Check ValidateEcommerce_Bullet with valid and invalid values. Check for expected errors.
        /// </summary>
        [TestMethod]
        public void ValidateEcommerceBullet_HasInvalidAndValidValues_ShouldReturnSomeErrors()
        {
            #region Assemble

            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            bool Ecommerce_Required = true;

            string input1 = "";
            string input2 = "Bananas Are Dope";
            #endregion // Assemble

            #region Act

            string result1 = itemService.ValidateEcommerce_Bullet(input1, "1", Ecommerce_Required);
            string result2 = itemService.ValidateEcommerce_Bullet(input2, "1", Ecommerce_Required);
            string result3 = itemService.ValidateEcommerce_Bullet(input1, "1", false);
            string result4 = itemService.ValidateEcommerce_Bullet(input2, "1", false);

            #endregion // Act

            #region Assert

            Assert.AreNotEqual(result1, "");
            Assert.AreEqual(result2, "");
            Assert.AreEqual(result3, "");
            Assert.AreEqual(result4, "");

            #endregion // Assert
        }

        [TestMethod]
        public void ValidateEcommerceMsrp_HasInvalidAndValidValues_ShouldReturnSomeErrors()
        {

            #region Assemble

            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());
            bool Ecommerce_Required = true;

            string input1 = "0";
            string input2 = "1";
            #endregion // Assemble

            #region Act

            string result1 = itemService.ValidateEcommerce_Msrp(input1, Ecommerce_Required);
            string result2 = itemService.ValidateEcommerce_Msrp(input2, Ecommerce_Required);
            string result3 = itemService.ValidateEcommerce_Msrp(input1, false);
            string result4 = itemService.ValidateEcommerce_Msrp(input2, false);

            #endregion // Act

            #region Assert

            Assert.AreNotEqual(result1, "");
            Assert.AreEqual(result2, "");
            Assert.AreNotEqual(result3, "");
            Assert.AreEqual(result4, "");

            #endregion // Assert
        }

        #endregion // Ecommerce Validation Tests
    }
}
