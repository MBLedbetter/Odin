using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdinModels;
using OdinServices;
using OdinTests.Helpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Odin.Data;

namespace OdinTests.BusinessLogicLayer.Models
{
    [TestClass]
    public class ItemsTests
    {

        [TestMethod]
        public void EcommerceValuesUpdateTest_HasUpdates_ShouldReturnTrue()
        {
            #region Assemble
            ItemObject item = new ItemObject();
            ItemObject item2 = new ItemObject();
            ItemObject item3 = new ItemObject();
            ItemObject item4 = new ItemObject();
            // item5 has no updates, should return false
            ItemObject item5 = new ItemObject();
            ItemObject item6 = new ItemObject();
            ItemObject item7 = new ItemObject();
            ItemObject item8 = new ItemObject();

            #endregion // Assemble

            #region Act


            item.Ecommerce_Bullet1 = "New Value";
            item2.Ecommerce_ItemWidth = "11";
            item3.Ecommerce_Msrp = "0.99";
            item4.Ecommerce_ImagePath2 = "img links";
            item6.Ecommerce_Size = "Boardom";
            item7.PricingGroup = "Elephant";
            item8.Ecommerce_Asin = "0009876";

            #endregion // Act

            #region Assert

            Assert.IsTrue(item.EcommerceValuesUpdate());
            Assert.IsTrue(item2.EcommerceValuesUpdate());
            Assert.IsTrue(item3.EcommerceValuesUpdate());
            Assert.IsTrue(item4.EcommerceValuesUpdate());
            Assert.IsFalse(item5.EcommerceValuesUpdate());
            Assert.IsTrue(item6.EcommerceValuesUpdate());
            Assert.IsFalse(item7.EcommerceValuesUpdate());
            Assert.IsTrue(item8.EcommerceValuesUpdate());

            #endregion // Assert
        }
        
        [TestMethod]
        public void ItemUpdateTest_HasUpdates_ShouldReturnTrue()
        {
            #region Assemble

            ItemObject Item = new ItemObject();
            ItemObject sellOnAllPostersItem = new ItemObject();
            ItemObject sellOnAmazonItem = new ItemObject();
            ItemObject sellOnFanaticsItem = new ItemObject();
            ItemObject sellOnGuitarCenterItem = new ItemObject();
            ItemObject sellOnHayneedleItem = new ItemObject();
            ItemObject sellOnTargetItem = new ItemObject();
            ItemObject sellOnTrendsItem = new ItemObject();
            ItemObject sellOnWalmartItem = new ItemObject();
            ItemObject sellOnWayfairItem = new ItemObject();
            ItemObject ecommerce_AsinItem = new ItemObject();
            ItemObject ecommerce_Bullet1Item = new ItemObject();
            ItemObject ecommerce_Bullet2Item = new ItemObject();
            ItemObject ecommerce_Bullet3Item = new ItemObject();
            ItemObject ecommerce_Bullet4Item = new ItemObject();
            ItemObject ecommerce_Bullet5Item = new ItemObject();
            ItemObject ecommerce_ComponentsItem = new ItemObject();
            ItemObject ecommerce_CostItem = new ItemObject();
            ItemObject ecommerce_ExternalIDItem = new ItemObject();
            ItemObject ecommerce_ExternalIdTypeItem = new ItemObject();
            ItemObject ecommerce_ImagePath1Item = new ItemObject();
            ItemObject ecommerce_ImagePath2Item = new ItemObject();
            ItemObject ecommerce_ImagePath3Item = new ItemObject();
            ItemObject ecommerce_ImagePath4Item = new ItemObject();
            ItemObject ecommerce_ImagePath5Item = new ItemObject();
            ItemObject ecommerce_ItemHeightItem = new ItemObject();
            ItemObject ecommerce_ItemLengthItem = new ItemObject();
            ItemObject ecommerce_ItemNameItem = new ItemObject();
            ItemObject ecommerce_ItemWeightItem = new ItemObject();
            ItemObject ecommerce_ItemWidthItem = new ItemObject();
            ItemObject ecommerce_ModelNameItem = new ItemObject();
            ItemObject ecommerce_PackageHeightItem = new ItemObject();
            ItemObject ecommerce_PackageLengthItem = new ItemObject();
            ItemObject ecommerce_PackageWeightItem = new ItemObject();
            ItemObject ecommerce_PackageWidthItem = new ItemObject();
            ItemObject ecommerce_PageQtyItem = new ItemObject();
            ItemObject ecommerce_ProductCategoryItem = new ItemObject();
            ItemObject ecommerce_ProductDescriptionItem = new ItemObject();
            ItemObject ecommerce_ProductSubcategoryItem = new ItemObject();
            ItemObject ecommerce_ManufacturerNameItem = new ItemObject();
            ItemObject ecommerce_MsrpItem = new ItemObject();
            ItemObject ecommerce_SearchTermsItem = new ItemObject();
            ItemObject ecommerce_SizeItem = new ItemObject();
            ItemObject accountingGroupItem = new ItemObject();
            ItemObject casepackHeightItem = new ItemObject();
            ItemObject casepackLengthItem = new ItemObject();
            ItemObject casepackQtyItem = new ItemObject();
            ItemObject casepackUpcItem = new ItemObject();
            ItemObject casepackWidthItem = new ItemObject();
            ItemObject casepackWeightItem = new ItemObject();
            ItemObject categoryItem = new ItemObject();
            ItemObject category2Item = new ItemObject();
            ItemObject category3Item = new ItemObject();
            ItemObject colorItem = new ItemObject();
            ItemObject copyrightItem = new ItemObject();
            ItemObject countryOfOriginItem = new ItemObject();
            ItemObject costProfileGroupItem = new ItemObject();
            ItemObject costProfileGroupItem2 = new ItemObject();
            ItemObject defaultActualCostUsdItem = new ItemObject();
            ItemObject defaultActualCostCadItem = new ItemObject();
            ItemObject descriptionItem = new ItemObject();
            ItemObject descriptionItem2 = new ItemObject();
            ItemObject descriptionItem3 = new ItemObject();
            ItemObject descriptionItem4 = new ItemObject();
            ItemObject directImportItem = new ItemObject();
            ItemObject dutyItem = new ItemObject();
            ItemObject eanItem = new ItemObject();
            ItemObject gpcItem = new ItemObject();
            ItemObject heightItem = new ItemObject();
            ItemObject innerpackHeightItem = new ItemObject();
            ItemObject innerpackLengthItem = new ItemObject();
            ItemObject innerpackQuantityItem = new ItemObject();
            ItemObject innerpackUpcItem = new ItemObject();
            ItemObject innerpackWidthItem = new ItemObject();
            ItemObject innerpackWeightItem = new ItemObject();
            ItemObject inStockDateItem = new ItemObject();
            ItemObject isbnItem = new ItemObject();
            ItemObject itemCategoryItem = new ItemObject();
            ItemObject itemCategoryItem2 = new ItemObject();
            ItemObject itemCategoryItem3 = new ItemObject();
            ItemObject itemFamilyItem = new ItemObject();
            ItemObject itemGroupItem = new ItemObject();
            ItemObject itemIdItem = new ItemObject();
            ItemObject itemKeywordsItem = new ItemObject();
            ItemObject languageItem = new ItemObject();
            ItemObject lengthItem = new ItemObject();
            ItemObject licenseItem = new ItemObject();
            ItemObject licenseBeginDateItem = new ItemObject();
            ItemObject listPriceCadItem = new ItemObject();
            ItemObject listPriceUsdItem = new ItemObject();
            ItemObject listPriceMxnItem = new ItemObject();
            ItemObject metaDescriptionItem = new ItemObject();
            ItemObject mfgSourceItem = new ItemObject();
            ItemObject msrpItem = new ItemObject();
            ItemObject msrpCadItem = new ItemObject();
            ItemObject msrpMxnItem = new ItemObject();
            ItemObject productFormatItem = new ItemObject();
            ItemObject productGroupItem = new ItemObject();
            ItemObject productGroupItem2 = new ItemObject();
            ItemObject productIdTranslationItem = new ItemObject();
            ItemObject productLineItem = new ItemObject();
            ItemObject productQtyItem = new ItemObject();
            ItemObject propertyItem = new ItemObject();
            ItemObject pricingGroupItem = new ItemObject();
            ItemObject printOnDemandItem = new ItemObject();
            ItemObject psStatusItem = new ItemObject();
            ItemObject satCodeItem = new ItemObject();
            ItemObject shortDescriptionItem = new ItemObject();
            ItemObject sizeItem = new ItemObject();
            ItemObject standardCostItem = new ItemObject();
            ItemObject statsCodeItem = new ItemObject();
            ItemObject tariffCodeItem = new ItemObject();
            ItemObject territoryItem = new ItemObject();
            ItemObject titleItem = new ItemObject();
            ItemObject udexItem = new ItemObject();
            ItemObject upcItem = new ItemObject();
            ItemObject websitePriceItem = new ItemObject();
            ItemObject weightItem = new ItemObject();
            ItemObject widthItem = new ItemObject();

            #endregion // Assemble

            #region Act

            sellOnAmazonItem.SellOnAmazon = "1";
            sellOnAllPostersItem.SellOnAmazon = "1";
            sellOnFanaticsItem.SellOnFanatics = "1";
            sellOnGuitarCenterItem.SellOnGuitarCenter = "1";
            sellOnHayneedleItem.SellOnHayneedle = "1";
            sellOnTargetItem.SellOnAmazon = "1";
            sellOnTrendsItem.SellOnTrends = "1";
            sellOnWalmartItem.SellOnWalmart = "1";
            sellOnWayfairItem.SellOnWayfair = "1";
            ecommerce_AsinItem.Ecommerce_Asin = "1";
            ecommerce_Bullet1Item.Ecommerce_Bullet1 = "1";
            ecommerce_Bullet2Item.Ecommerce_Bullet2 = "1";
            ecommerce_Bullet3Item.Ecommerce_Bullet3 = "1";
            ecommerce_Bullet4Item.Ecommerce_Bullet4 = "1";
            ecommerce_Bullet5Item.Ecommerce_Bullet5 = "1";
            ecommerce_ComponentsItem.Ecommerce_Components = "1";
            ecommerce_CostItem.Ecommerce_Cost = "1";
            ecommerce_ExternalIDItem.Ecommerce_ExternalId = "1";
            ecommerce_ExternalIdTypeItem.Ecommerce_ExternalIdType = "1";
            ecommerce_ImagePath1Item.Ecommerce_ImagePath1 = "1";
            ecommerce_ImagePath2Item.Ecommerce_ImagePath2 = "1";
            ecommerce_ImagePath3Item.Ecommerce_ImagePath3 = "1";
            ecommerce_ImagePath4Item.Ecommerce_ImagePath4 = "1";
            ecommerce_ImagePath5Item.Ecommerce_ImagePath5 = "1";
            ecommerce_ItemHeightItem.Ecommerce_ItemHeight = "1";
            ecommerce_ItemLengthItem.Ecommerce_ItemLength = "1";
            ecommerce_ItemNameItem.Ecommerce_ItemName = "1";
            ecommerce_ItemWeightItem.Ecommerce_ItemWeight = "1";
            ecommerce_ItemWidthItem.Ecommerce_ItemWidth = "1";
            ecommerce_ModelNameItem.Ecommerce_ModelName = "1";
            ecommerce_PackageHeightItem.Ecommerce_PackageHeight = "1";
            ecommerce_PackageLengthItem.Ecommerce_PackageLength = "1";
            ecommerce_PackageWeightItem.Ecommerce_PackageWeight = "1";
            ecommerce_PackageWidthItem.Ecommerce_PackageWidth = "1";
            ecommerce_PageQtyItem.Ecommerce_PageQty = "1";
            ecommerce_ProductCategoryItem.Ecommerce_ProductCategory = "1";
            ecommerce_ProductDescriptionItem.Ecommerce_ProductDescription = "1";
            ecommerce_ProductSubcategoryItem.Ecommerce_ProductSubcategory = "1";
            ecommerce_ManufacturerNameItem.Ecommerce_ManufacturerName = "1";
            ecommerce_MsrpItem.Ecommerce_Msrp = "1";
            ecommerce_SearchTermsItem.Ecommerce_SearchTerms = "1";
            ecommerce_SizeItem.Ecommerce_Size = "1";
            accountingGroupItem.AccountingGroup = "1";
            casepackHeightItem.CasepackHeight = "1";
            casepackLengthItem.CasepackLength = "1";
            casepackQtyItem.CasepackQty = "1";
            casepackUpcItem.CasepackUpc = "1";
            casepackWidthItem.CasepackWidth = "1";
            casepackWeightItem.CasepackWeight = "1";
            categoryItem.Category = "1";
            category2Item.Category2 = "1";
            category3Item.Category3 = "1";
            colorItem.Color = "1";
            copyrightItem.Copyright = "1";
            countryOfOriginItem.CountryOfOrigin = "1";
            costProfileGroupItem.CostProfileGroup = "1";
            costProfileGroupItem2.CostProfileGroup = "1";
            defaultActualCostUsdItem.DefaultActualCostUsd = "1";
            defaultActualCostCadItem.DefaultActualCostCad = "1";
            descriptionItem.Description = "1";
            descriptionItem2.Description = "1";
            descriptionItem3.Description = "1";
            descriptionItem4.Description = "1";
            directImportItem.DirectImport = "1";
            dutyItem.Duty = "1";
            eanItem.Ean = "1";
            gpcItem.Gpc = "1";
            heightItem.Height = "1";
            innerpackHeightItem.InnerpackHeight = "1";
            innerpackLengthItem.InnerpackLength = "1";
            innerpackQuantityItem.InnerpackQuantity = "1";
            innerpackUpcItem.InnerpackUpc = "1";
            innerpackWidthItem.InnerpackWidth = "1";
            innerpackWeightItem.InnerpackWeight = "1";
            inStockDateItem.InStockDate = "1";
            isbnItem.Isbn = "1";
            itemCategoryItem.ItemCategory = "1";
            itemCategoryItem2.ItemCategory = "1";
            itemCategoryItem3.ItemCategory = "1";
            itemFamilyItem.ItemFamily = "1";
            itemGroupItem.ItemGroup = "1";
            itemKeywordsItem.ItemKeywords = "1";
            languageItem.Language = "1";
            lengthItem.Length = "1";
            licenseItem.License = "1";
            licenseBeginDateItem.LicenseBeginDate = "1";
            listPriceCadItem.ListPriceCad = "1";
            listPriceUsdItem.ListPriceUsd = "1";
            listPriceMxnItem.ListPriceMxn = "1";
            metaDescriptionItem.MetaDescription = "1";
            mfgSourceItem.MfgSource = "1";
            msrpItem.Msrp = "1";
            msrpCadItem.MsrpCad = "1";
            msrpMxnItem.MsrpMxn = "1";
            productFormatItem.ProductFormat = "1";
            productGroupItem.ProductGroup = "1";
            productGroupItem2.ProductGroup = "1";
            productIdTranslationItem.ProductIdTranslation = new List<ChildElement>();
            productLineItem.ProductLine = "1";
            productQtyItem.ProductQty = "1";
            propertyItem.Property = "1";
            pricingGroupItem.PricingGroup = "1";
            printOnDemandItem.PrintOnDemand = "1";
            psStatusItem.PsStatus = "1";
            shortDescriptionItem.ShortDescription = "1";
            sizeItem.Size = "1";
            standardCostItem.StandardCost = "1";
            satCodeItem.SatCode = "1";
            statsCodeItem.StatsCode = "1";
            tariffCodeItem.TariffCode = "1";
            territoryItem.Territory = "1";
            titleItem.Title = "1";
            udexItem.Udex = "1";
            upcItem.Upc = "1";
            websitePriceItem.WebsitePrice = "1";
            weightItem.Weight = "1";
            widthItem.Width = "1";

            #endregion // Act

            #region Assert
            
            Assert.IsFalse(Item.CheckUpdates());
            Assert.IsFalse(Item.EcommerceValuesUpdate());
            Assert.IsFalse(Item.BuItemsInvUpdate());
            Assert.IsFalse(Item.CmItemMethodUpdate());
            Assert.IsFalse(Item.FxdBinLocInvUpdate());
            Assert.IsFalse(Item.InvItemsUpdate());
            Assert.IsFalse(Item.ItemAttribExUpdate());
            Assert.IsFalse(Item.ItemTerritoryUpdate());
            Assert.IsFalse(Item.ItemLanguageUpdate());
            Assert.IsFalse(Item.ItemWebInfoUpdate());
            Assert.IsFalse(Item.MasterItemUpdate());
            Assert.IsFalse(Item.ProdItemUpdate());
            Assert.IsFalse(Item.ProdPgrpLnkUpdate());
            Assert.IsFalse(Item.ProdPriceUpdate());
            Assert.IsFalse(Item.PurchItemAttrUpdate());
            Assert.IsFalse(Item.PvItmCategoryUpdate());

            Assert.IsTrue(sellOnAllPostersItem.SellOnFlagUpdate());
            Assert.IsTrue(sellOnAmazonItem.SellOnFlagUpdate());
            Assert.IsTrue(sellOnFanaticsItem.SellOnFlagUpdate());
            Assert.IsTrue(sellOnGuitarCenterItem.SellOnFlagUpdate());
            Assert.IsTrue(sellOnHayneedleItem.SellOnFlagUpdate());
            Assert.IsTrue(sellOnTargetItem.SellOnFlagUpdate());
            Assert.IsTrue(sellOnWalmartItem.SellOnFlagUpdate());
            Assert.IsTrue(sellOnWayfairItem.SellOnFlagUpdate());



            Assert.IsTrue(ecommerce_AsinItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_Bullet1Item.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_Bullet2Item.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_Bullet3Item.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_Bullet4Item.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_Bullet5Item.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ComponentsItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_CostItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ExternalIDItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ExternalIdTypeItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ImagePath1Item.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ImagePath2Item.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ImagePath3Item.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ImagePath4Item.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ImagePath5Item.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ItemHeightItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ItemLengthItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ItemNameItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ItemWeightItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ItemWidthItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ModelNameItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_PackageHeightItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_PackageLengthItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_PackageWeightItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_PackageWidthItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_PageQtyItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ProductCategoryItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ProductDescriptionItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ProductSubcategoryItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_ManufacturerNameItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_MsrpItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_SearchTermsItem.EcommerceValuesUpdate());
            Assert.IsTrue(ecommerce_SizeItem.EcommerceValuesUpdate());
            Assert.IsTrue(accountingGroupItem.ProdPgrpLnkUpdate());
            Assert.IsTrue(casepackHeightItem.ItemAttribExUpdate());
            Assert.IsTrue(casepackLengthItem.ItemAttribExUpdate());
            Assert.IsTrue(casepackQtyItem.ItemAttribExUpdate());
            Assert.IsTrue(casepackUpcItem.ItemAttribExUpdate());
            Assert.IsTrue(casepackWidthItem.ItemAttribExUpdate());
            Assert.IsTrue(casepackWeightItem.ItemAttribExUpdate());
            Assert.IsTrue(categoryItem.ItemWebInfoUpdate());
            Assert.IsTrue(category2Item.ItemWebInfoUpdate());
            Assert.IsTrue(category3Item.ItemWebInfoUpdate());
            Assert.IsTrue(colorItem.InvItemsUpdate());
            Assert.IsTrue(copyrightItem.ItemWebInfoUpdate());
            Assert.IsTrue(countryOfOriginItem.BuItemsInvUpdate());
            Assert.IsTrue(costProfileGroupItem.CmItemMethodUpdate());
            Assert.IsTrue(costProfileGroupItem2.MasterItemUpdate());
            Assert.IsTrue(defaultActualCostUsdItem.BuItemsInvUpdate());
            Assert.IsTrue(defaultActualCostCadItem.BuItemsInvUpdate());
            Assert.IsTrue(descriptionItem.InvItemsUpdate());
            Assert.IsTrue(descriptionItem2.MasterItemUpdate());
            Assert.IsTrue(descriptionItem3.ProdItemUpdate());
            Assert.IsTrue(descriptionItem4.PurchItemAttrUpdate());
            Assert.IsTrue(directImportItem.ItemAttribExUpdate());
            // Assert.IsTrue(dutyItem.Update());
            Assert.IsTrue(eanItem.ProdItemUpdate());
            Assert.IsTrue(gpcItem.ProdItemUpdate());
            Assert.IsTrue(heightItem.InvItemsUpdate());
            Assert.IsTrue(innerpackHeightItem.ItemAttribExUpdate());
            Assert.IsTrue(innerpackLengthItem.ItemAttribExUpdate());
            Assert.IsTrue(innerpackQuantityItem.ItemAttribExUpdate());
            Assert.IsTrue(innerpackUpcItem.ItemAttribExUpdate());
            Assert.IsTrue(innerpackWidthItem.ItemAttribExUpdate());
            Assert.IsTrue(innerpackWeightItem.ItemAttribExUpdate());
            Assert.IsTrue(inStockDateItem.ItemWebInfoUpdate());
            Assert.IsTrue(isbnItem.ProdItemUpdate());
            Assert.IsTrue(itemCategoryItem.PvItmCategoryUpdate());
            Assert.IsTrue(itemCategoryItem2.MasterItemUpdate());
            Assert.IsTrue(itemCategoryItem3.ProdItemUpdate());
            Assert.IsTrue(itemFamilyItem.MasterItemUpdate());
            Assert.IsTrue(itemGroupItem.MasterItemUpdate());
            Assert.IsTrue(itemKeywordsItem.ItemWebInfoUpdate());
            Assert.IsTrue(languageItem.ItemLanguageUpdate());
            Assert.IsTrue(lengthItem.InvItemsUpdate());
            Assert.IsTrue(licenseItem.ItemWebInfoUpdate());
            Assert.IsTrue(licenseBeginDateItem.ItemAttribExUpdate());
            Assert.IsTrue(listPriceCadItem.ProdPriceUpdate());
            Assert.IsTrue(listPriceUsdItem.ProdPriceUpdate());
            Assert.IsTrue(listPriceMxnItem.ProdPriceUpdate());
            Assert.IsTrue(metaDescriptionItem.ItemWebInfoUpdate());
            Assert.IsTrue(mfgSourceItem.BuItemsInvUpdate());
            Assert.IsTrue(msrpItem.ProdPriceUpdate());
            Assert.IsTrue(msrpCadItem.ProdPriceUpdate());
            Assert.IsTrue(msrpMxnItem.ProdPriceUpdate());
            Assert.IsTrue(productFormatItem.ItemAttribExUpdate());
            Assert.IsTrue(productGroupItem.ItemAttribExUpdate());
            Assert.IsTrue(productGroupItem2.ProdPriceUpdate());
            Assert.IsTrue(productLineItem.ItemAttribExUpdate());
            Assert.IsTrue(productQtyItem.ItemWebInfoUpdate());
            Assert.IsTrue(propertyItem.ItemWebInfoUpdate());
            Assert.IsTrue(pricingGroupItem.ProdPgrpLnkUpdate());
            Assert.IsTrue(printOnDemandItem.ItemAttribExUpdate());
            Assert.IsTrue(psStatusItem.MasterItemUpdate());
            Assert.IsTrue(shortDescriptionItem.ItemWebInfoUpdate());
            Assert.IsTrue(sizeItem.ItemWebInfoUpdate());
            Assert.IsTrue(standardCostItem.PurchItemAttrUpdate());
            Assert.IsTrue(satCodeItem.ItemAttribExUpdate());
            Assert.IsTrue(statsCodeItem.ProdItemUpdate());
            Assert.IsTrue(tariffCodeItem.InvItemsUpdate());
            Assert.IsTrue(territoryItem.ItemTerritoryUpdate());
            Assert.IsTrue(titleItem.ItemWebInfoUpdate());
            Assert.IsTrue(udexItem.ProdItemUpdate());
            Assert.IsTrue(upcItem.InvItemsUpdate());
            Assert.IsTrue(websitePriceItem.ItemAttribExUpdate());
            Assert.IsTrue(weightItem.InvItemsUpdate());
            Assert.IsTrue(widthItem.InvItemsUpdate());
            #endregion // Assert
        }
  
        [TestMethod]
        public void ValidateActiveField_StatusOfUpdate_ShouldSucceed()
        {
            #region SetUp

            ItemObject item = new ItemObject();
            item.Status = "Update";
            Boolean isItemActive = false;

            #endregion // Set Up

            #region Act

            isItemActive = (item.Active == 1) ? true : false;

            #endregion // Act

            #region Assert

            Assert.IsTrue(isItemActive);

            #endregion // Assert
        }

        /// <summary>
        ///     This test checks that the HasWeb identifier is not marked true when no web fields are submitted.
        /// </summary>
        [TestMethod]
        public void ValidateCheckForWeb_DoesNotHaveWeb_ShouldSucceed()
        {
            #region SetUp
            
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            ItemObject item = new ItemObject();
            item.AccountingGroup = "t";
            item.CasepackHeight = "4";
            item.CasepackLength = "4";
            item.CasepackQty = "4";
            item.CasepackWidth = "4";
            item.CasepackWeight = "4";
            item.Color = "RED";
            item.CountryOfOrigin = "USA";
            item.CostProfileGroup = "T";
            item.DefaultActualCostCad = "3";
            item.DefaultActualCostUsd = "2";
            item.Description = "DDD";
            item.DirectImport = "Y";
            item.Ean = "Y";
            item.Gpc = "Y";
            item.Height = "3";
            item.InnerpackHeight = "3";
            item.InnerpackLength = "3";
            item.InnerpackQuantity = "3";
            item.InnerpackWidth = "3";
            item.InnerpackWeight = "3";
            item.Isbn = "YT";
            item.ItemCategory = "R";
            item.ItemFamily = "RE";
            item.ItemGroup = "rER";
            item.Language = "ENG";
            item.LicenseBeginDate = "";
            item.ListPriceUsd = "3";
            item.ListPriceCad = "3";
            item.ListPriceMxn = "3";
            item.Length = "3";
            item.MfgSource = "BB";
            item.Msrp = "2";
            item.MsrpCad = "2";
            item.ProductFormat = "F";
            item.ProductGroup = "G";
            item.ProductLine = "L";
            item.PricingGroup = "PG";
            item.SatCode = "SC1";
            item.StatsCode = "SC";
            item.StandardCost = "SC";
            item.TariffCode = "11.99";
            item.Territory = "USA";
            item.Udex = "";
            item.Upc = "111122223333";
            item.WebsitePrice = "3.33";
            item.Weight = "3";
            item. Width = "2";
            #endregion // Set Up

            #region Act
            // item.CheckForWeb();
            bool result = item.HasWeb();

            #endregion // Act

            #region Assert

            Assert.IsFalse(result);

            #endregion // Assert
        }

        [TestMethod]
        public void ValidateActiveField_StatusOfRemove_ShouldFail()
        {
            #region SetUp

            ItemObject item = new ItemObject();
            item.Status = "Remove";
            Boolean isItemActive = false;

            #endregion // Set Up

            #region Act

            isItemActive = (item.Active == 1) ? true : false;

            #endregion // Act

            #region Assert

            Assert.IsFalse(isItemActive);

            #endregion // Assert
        }

        [TestMethod]
        public void ParseCategories_ValidIdList_ShouldSuccessfullyParse()
        {
            #region Assemble

            GlobalData.ClearValues();
            ItemService itemService = new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository());

            ItemObject item = new ItemObject();
            string list = "1,3,5";

            #endregion // Assemble

            #region Act

             List<string> newList = DbUtil.ParseCategories(list);

            #endregion // Act

            #region Assert

             Assert.AreEqual("Category1", newList[0]);
             Assert.AreEqual("Category3", newList[1]);
             Assert.AreEqual("Category5", newList[2]);

            #endregion // Assesrt
        }

        /// <summary>
        ///     Check the update flag for the bill of materials
        /// </summary>
        [TestMethod]
        public void UpdateField_BillOfMaterials_CheckFlag()
        {
            #region Assemble

            List<ChildElement> billOfMaterials = new List<ChildElement>();
            billOfMaterials.Add(new ChildElement("RP1234", "ITEMID", 1));
            billOfMaterials.Add(new ChildElement("RP5678", "ITEMID", 2));
            List<ChildElement> sameBillOfMaterials = new List<ChildElement>();
            sameBillOfMaterials.Add(new ChildElement("RP1234", "ITEMID", 1));
            sameBillOfMaterials.Add(new ChildElement("RP5675", "ITEMID", 2));
            List<ChildElement> newBillOfMaterials = new List<ChildElement>();
            newBillOfMaterials.Add(new ChildElement("RP5675", "ITEMID", 2));
            newBillOfMaterials.Add(new ChildElement("RP1234", "ITEMID", 1));

            ItemObject item = new ItemObject();
            item.BillOfMaterials = billOfMaterials;
            item.ResetUpdate();

            #endregion

            #region Act

            // check that flag is being properly reset once initial values added
            bool UpdateReseted = item.BillOfMaterialsUpdate;

            // Add the same values in different order
            item.BillOfMaterials = billOfMaterials;
            bool SameValuesAdded = item.BillOfMaterialsUpdate;

            // add different values
            item.BillOfMaterials = newBillOfMaterials;
            bool UpdateTriggered = item.BillOfMaterialsUpdate;

            #endregion // Act

            #region Assert

            Assert.IsFalse(UpdateReseted);
            //Assert.IsFalse(SameValuesAdded);
            Assert.IsTrue(UpdateTriggered);

            #endregion // Assert

        }

        /// <summary>
        ///     Checks all item update fields when the same value is added
        /// </summary>
        [TestMethod]
        public void UpdateFields_FieldsHaveSameValues_FlagsShouldBeFalse()
        {
            #region Assemble

            List<ChildElement> billOfMaterials = new List<ChildElement>();
            billOfMaterials.Add(new ChildElement("RP1234", "ITEMID", 1));
            billOfMaterials.Add(new ChildElement("RP5678", "ITEMID", 2));
            List<ChildElement> pOd = new List<ChildElement>();
            pOd.Add(new ChildElement("RP1234", "ITEMID", 1));
            pOd.Add(new ChildElement("RP5678", "ITEMID", 2));
            ItemObject item = new ItemObject(
                "Update",
                "", 
                "",
                "",
                "",
                "accountingGroup",
                billOfMaterials,
                "casepackHeight",
                "casepackLength",
                "casepackQty",
                "casepackUpc",
                "casepackWidth",
                "casepackWeight",
                "category",
                "category2",
                "category3",
                "color",
                "copyright",
                "countryOfOrigin",
                "costProfileGroup",
                "defaultActualCostUsd",
                "defaultActualCostCad",
                "description",
                "directImport",
                "duty",
                "ean",
                "ecommerce_Asin",
                "ecommerce_Bullet1",
                "ecommerce_Bullet2",
                "ecommerce_Bullet3",
                "ecommerce_Bullet4",
                "ecommerce_Bullet5",
                "ecommerce_Components",
                "ecommerce_Cost",
                "ecommerce_ExternalID",
                "ecommerce_ExternalIdType",
                "ecommerce_ItemHeight",
                "ecommerce_ItemLength",
                "ecommerce_ItemName",
                "ecommerce_ItemWeight",
                "ecommerce_ItemWidth",
                "ecommerce_ModelName",
                "ecommerce_PackageHeight",
                "ecommerce_PackageLength",
                "ecommerce_PackageWeight",
                "ecommerce_PackageWidth",
                "ecommerce_PageQty",
                "ecommerce_ProductCategory",
                "ecommerce_ProductDescription",
                "ecommerce_ProductSubcategory",
                "ecommerce_ManufacturerName",
                "ecommerce_Msrp",
                "ecommerce_SearchTerms",
                "ecommerce_Size",
                "ecommerceUpc",
                "gpc",
                "height",
                "imagePath",
                "innerpackHeight",
                "innerpackLength",
                "innerpackQuantity",
                "innerpackUpc",
                "innerpackWidth",
                "innerpackWeight",
                "inStockDate",
                "isbn",
                "itemCategory",
                "itemFamily",
                "itemGroup",
                "itemId",
                "itemKeywords",
                "language",
                "length",
                "license",
                "licenseBeginDate",
                "listPriceCad",
                "listPriceUsd",
                "listPriceMxn",
                "metaDescription",
                "mfgSource",
                "msrp",
                "msrpCad",
                "msrpMxn",
                "productFormat",
                "productGroup",
                pOd,
                "productLine",
                "productQty",
                "property",
                "pricingGroup",
                "printOnDemand",
                "psStatus",
                "satCode",
                "SellOnAllPosters",
                "sellOnAmazon",
                "sellOnFanatics",
                "sellOnGuitarCenter",
                "sellOnHayneedle",
                "SellOnTarget",
                "SellOnTrends",
                "sellOnWalmart",
                "sellOnWayfair",
                "shortDescription",
                "size",
                "standardCost",
                "statsCode",
                "tariffCode",
                "territory",
                "title",
                "udex",
                "upc",
                "websitePrice",
                "weight",
                "width");

            #endregion // Assemble

            #region Act

            item.Ecommerce_Asin = item.Ecommerce_Asin;
            item.Ecommerce_Bullet1 = item.Ecommerce_Bullet1;
            item.Ecommerce_Bullet2 = item.Ecommerce_Bullet2;
            item.Ecommerce_Bullet3 = item.Ecommerce_Bullet3;
            item.Ecommerce_Bullet4 = item.Ecommerce_Bullet4;
            item.Ecommerce_Bullet5 = item.Ecommerce_Bullet5;
            item.Ecommerce_Components = item.Ecommerce_Components;
            item.Ecommerce_Cost = item.Ecommerce_Cost;
            item.Ecommerce_ExternalId = item.Ecommerce_ExternalId;
            item.Ecommerce_ExternalIdType = item.Ecommerce_ExternalIdType;
            item.Ecommerce_ImagePath1 = item.Ecommerce_ImagePath1;
            item.Ecommerce_ImagePath2 = item.Ecommerce_ImagePath2;
            item.Ecommerce_ImagePath3 = item.Ecommerce_ImagePath3;
            item.Ecommerce_ImagePath4 = item.Ecommerce_ImagePath4;
            item.Ecommerce_ImagePath5 = item.Ecommerce_ImagePath5;
            item.Ecommerce_ItemHeight = item.Ecommerce_ItemHeight;
            item.Ecommerce_ItemLength = item.Ecommerce_ItemLength;
            item.Ecommerce_ItemName = item.Ecommerce_ItemName;
            item.Ecommerce_ItemWeight = item.Ecommerce_ItemWeight;
            item.Ecommerce_ItemWidth = item.Ecommerce_ItemWidth;
            item.Ecommerce_ModelName = item.Ecommerce_ModelName;
            item.Ecommerce_PackageHeight = item.Ecommerce_PackageHeight;
            item.Ecommerce_PackageLength = item.Ecommerce_PackageLength;
            item.Ecommerce_PackageWeight = item.Ecommerce_PackageWeight;
            item.Ecommerce_PackageWidth = item.Ecommerce_PackageWidth;
            item.Ecommerce_PageQty = item.Ecommerce_PageQty;
            item.Ecommerce_ProductCategory = item.Ecommerce_ProductCategory;
            item.Ecommerce_ProductDescription = item.Ecommerce_ProductDescription;
            item.Ecommerce_ProductSubcategory = item.Ecommerce_ProductSubcategory;
            item.Ecommerce_ManufacturerName = item.Ecommerce_ManufacturerName;
            item.Ecommerce_Msrp = item.Ecommerce_Msrp;
            item.Ecommerce_SearchTerms = item.Ecommerce_SearchTerms;
            item.Ecommerce_Size = item.Ecommerce_Size;
            item.AccountingGroup = item.AccountingGroup;
            item.BillOfMaterials = item.BillOfMaterials;
            item.CasepackHeight = item.CasepackHeight;
            item.CasepackLength = item.CasepackLength;
            item.CasepackQty = item.CasepackQty;
            item.CasepackUpc = item.CasepackUpc;
            item.CasepackWidth = item.CasepackWidth;
            item.CasepackWeight = item.CasepackWeight;
            item.Category = item.Category;
            item.Category2 = item.Category2;
            item.Category3 = item.Category3;
            item.Color = item.Color;
            item.Copyright = item.Copyright;
            item.CountryOfOrigin = item.CountryOfOrigin;
            item.CostProfileGroup = item.CostProfileGroup;
            item.DefaultActualCostUsd = item.DefaultActualCostUsd;
            item.DefaultActualCostCad = item.DefaultActualCostCad;
            item.Description = item.Description;
            item.DirectImport = item.DirectImport;
            item.Duty = item.Duty;
            item.Ean = item.Ean;
            item.Gpc = item.Gpc;
            item.Height = item.Height;
            item.InStockDate = item.InStockDate;
            item.InnerpackHeight = item.InnerpackHeight;
            item.InnerpackLength = item.InnerpackLength;
            item.InnerpackQuantity = item.InnerpackQuantity;
            item.InnerpackUpc = item.InnerpackUpc;
            item.InnerpackWidth = item.InnerpackWidth;
            item.InnerpackWeight = item.InnerpackWeight;
            item.InStockDate = item.InStockDate;
            item.Isbn = item.Isbn;
            item.ItemCategory = item.ItemCategory;
            item.ItemFamily = item.ItemFamily;
            item.ItemGroup = item.ItemGroup;
            item.ItemId = item.ItemId;
            item.ItemKeywords = item.ItemKeywords;
            item.Language = item.Language;
            item.Length = item.Length;
            item.License = item.License;
            item.LicenseBeginDate = item.LicenseBeginDate;
            item.ListPriceCad = item.ListPriceCad;
            item.ListPriceUsd = item.ListPriceUsd;
            item.ListPriceMxn = item.ListPriceMxn;
            item.MetaDescription = item.MetaDescription;
            item.MfgSource = item.MfgSource;
            item.Msrp = item.Msrp;
            item.MsrpCad = item.MsrpCad;
            item.MsrpMxn = item.MsrpMxn;
            item.ProductFormat = item.ProductFormat;
            item.ProductGroup = item.ProductGroup;
            item.ProductLine = item.ProductLine;
            item.ProductQty = item.ProductQty;
            item.PricingGroup = item.PricingGroup;
            item.PsStatus = item.PsStatus;
            item.SatCode = item.SatCode;
            item.ShortDescription = item.ShortDescription;
            item.Size = item.Size;
            item.StandardCost = item.StandardCost;
            item.StatsCode = item.StatsCode;
            item.TariffCode = item.TariffCode;
            item.Territory = item.Territory;
            item.Title = item.Title;
            item.Udex = item.Udex;
            item.Upc = item.Upc;
            item.WebsitePrice = item.WebsitePrice;
            item.Weight = item.Weight;
            item.Width = item.Width;


            bool Acommerce_AsinUpdate2 = item.Ecommerce_AsinUpdate;
            bool Acommerce_Bullet1Update2 = item.Ecommerce_Bullet1Update;
            bool Acommerce_Bullet2Update2 = item.Ecommerce_Bullet2Update;
            bool Acommerce_Bullet3Update2 = item.Ecommerce_Bullet3Update;
            bool Acommerce_Bullet4Update2 = item.Ecommerce_Bullet4Update;
            bool Acommerce_Bullet5Update2 = item.Ecommerce_Bullet5Update;
            bool Acommerce_ComponentsUpdate2 = item.Ecommerce_ComponentsUpdate;
            bool Acommerce_CostUpdate2 = item.Ecommerce_CostUpdate;
            bool Acommerce_ExternalIDUpdate2 = item.Ecommerce_ExternalIdUpdate;
            bool Acommerce_ExternalIdTypeUpdate2 = item.Ecommerce_ExternalIdTypeUpdate;
            bool Acommerce_ImagePath1Update2 = item.Ecommerce_ImagePath1Update;
            bool Acommerce_ImagePath2Update2 = item.Ecommerce_ImagePath2Update;
            bool Acommerce_ImagePath3Update2 = item.Ecommerce_ImagePath3Update;
            bool Acommerce_ImagePath4Update2 = item.Ecommerce_ImagePath4Update;
            bool Acommerce_ImagePath5Update2 = item.Ecommerce_ImagePath5Update;
            bool Acommerce_ItemHeightUpdate2 = item.Ecommerce_ItemHeightUpdate;
            bool Acommerce_ItemLengthUpdate2 = item.Ecommerce_ItemLengthUpdate;
            bool Acommerce_ItemNameUpdate2 = item.Ecommerce_ItemNameUpdate;
            bool Acommerce_ItemWeightUpdate2 = item.Ecommerce_ItemWeightUpdate;
            bool Acommerce_ItemWidthUpdate2 = item.Ecommerce_ItemWidthUpdate;
            bool Acommerce_ModelNameUpdate2 = item.Ecommerce_ModelNameUpdate;
            bool Acommerce_PackageHeightUpdate2 = item.Ecommerce_PackageHeightUpdate;
            bool Acommerce_PackageLengthUpdate2 = item.Ecommerce_PackageLengthUpdate;
            bool Acommerce_PackageWeightUpdate2 = item.Ecommerce_PackageWeightUpdate;
            bool Acommerce_PackageWidthUpdate2 = item.Ecommerce_PackageWidthUpdate;
            bool Acommerce_PageQtyUpdate2 = item.Ecommerce_PageQtyUpdate;
            bool Acommerce_ProductCategoryUpdate2 = item.Ecommerce_ProductCategoryUpdate;
            bool Acommerce_ProductDescriptionUpdate2 = item.Ecommerce_ProductDescriptionUpdate;
            bool Acommerce_ProductSubcategoryUpdate2 = item.Ecommerce_ProductSubcategoryUpdate;
            bool Acommerce_ManufacturerNameUpdate2 = item.Ecommerce_ManufacturerNameUpdate;
            bool Acommerce_MsrpUpdate2 = item.Ecommerce_MsrpUpdate;
            bool Acommerce_SearchTermsUpdate2 = item.Ecommerce_SearchTermsUpdate;
            bool Acommerce_SizeUpdate2 = item.Ecommere_SizeUpdate;
            bool AccountingGroupUpdate2 = item.AccountingGroupUpdate;
            bool BillOfMaterialsUpdate2 = item.BillOfMaterialsUpdate;
            bool CasepackHeightUpdate2 = item.CasepackHeightUpdate;
            bool CasepackLengthUpdate2 = item.CasepackLengthUpdate;
            bool CasepackQtyUpdate2 = item.CasepackQtyUpdate;
            bool CasepackUpcUpdate2 = item.CasepackUpcUpdate;
            bool CasepackWidthUpdate2 = item.CasepackWidthUpdate;
            bool CasepackWeightUpdate2 = item.CasepackWeightUpdate;
            bool CategoryUpdate2 = item.CategoryUpdate;
            bool Category2Update2 = item.Category2Update;
            bool Category3Update2 = item.Category3Update;
            bool ColorUpdate2 = item.ColorUpdate;
            bool CopyrightUpdate2 = item.CopyrightUpdate;
            bool CountryOfOriginUpdate2 = item.CountryOfOriginUpdate;
            bool CostProfileGroupUpdate2 = item.CostProfileGroupUpdate;
            bool DefaultActualCostUsdUpdate2 = item.DefaultActualCostUsdUpdate;
            bool DefaultActualCostCadUpdate2 = item.DefaultActualCostCadUpdate;
            bool DescriptionUpdate2 = item.DescriptionUpdate;
            bool DirectImportUpdate2 = item.DirectImportUpdate;
            bool DutyUpdate2 = item.DutyUpdate;
            bool EanUpdate2 = item.EanUpdate;
            bool GpcUpdate2 = item.GpcUpdate;
            bool HeightUpdate2 = item.HeightUpdate;
            bool InstockDateUpdate2 = item.InStockDateUpdate;
            bool InnerpackHeightUpdate2 = item.InnerpackHeightUpdate;
            bool InnerpackLengthUpdate2 = item.InnerpackLengthUpdate;
            bool InnerpackQuantityUpdate2 = item.InnerpackQuantityUpdate;
            bool InnerpackUpcUpdate2 = item.InnerpackUpcUpdate;
            bool InnerpackWidthUpdate2 = item.InnerpackWidthUpdate;
            bool InnerpackWeightUpdate2 = item.InnerpackWeightUpdate;
            bool IsbnUpdate2 = item.IsbnUpdate;
            bool ItemCategoryUpdate2 = item.ItemCategoryUpdate;
            bool ItemFamilyUpdate2 = item.ItemFamilyUpdate;
            bool ItemGroupUpdate2 = item.ItemGroupUpdate;
            bool ItemKeywordsUpdate2 = item.ItemKeywordsUpdate;
            bool LanguageUpdate2 = item.LanguageUpdate;
            bool LengthUpdate2 = item.LengthUpdate;
            bool LicenseUpdate2 = item.LicenseUpdate;
            bool LicenseBeginDateUpdate2 = item.LicenseBeginDateUpdate;
            bool ListPriceCadUpdate2 = item.ListPriceCadUpdate;
            bool ListPriceUsdUpdate2 = item.ListPriceUsdUpdate;
            bool ListPriceMxnUpdate2 = item.ListPriceMxnUpdate;
            bool MetaDescriptionUpdate2 = item.MetaDescriptionUpdate;
            bool MfgSourceUpdate2 = item.MfgSourceUpdate;
            bool MsrpUpdate2 = item.MsrpUpdate;
            bool MsrpCadUpdate2 = item.MsrpCadUpdate;
            bool MsrpMxnUpdate2 = item.MsrpMxnUpdate;
            bool ProductFormatUpdate2 = item.ProductFormatUpdate;
            bool ProductGroupUpdate2 = item.ProductGroupUpdate;
            bool ProductLineUpdate2 = item.ProductLineUpdate;
            bool ProductQtyUpdate2 = item.ProductQtyUpdate;
            bool PricingGroupUpdate2 = item.PricingGroupUpdate;
            bool PsStatusUpdate2 = item.PsStatusUpdate;
            bool SatCodeUpdate2 = item.SatCodeUpdate;
            bool ShortDescriptionUpdate2 = item.ShortDescriptionUpdate;
            bool SizeUpdate2 = item.SizeUpdate;
            bool StandardCostUpdate2 = item.StandardCostUpdate;
            bool StatsCodeUpdate2 = item.StatsCodeUpdate;
            bool TariffCodeUpdate2 = item.TariffCodeUpdate;
            bool TerritoryUpdate2 = item.TerritoryUpdate;
            bool TitleUpdate2 = item.TitleUpdate;
            bool UdexUpdate2 = item.UdexUpdate;
            bool UpcUpdate2 = item.UpcUpdate;
            bool WebsitePriceUpdate2 = item.WebsitePriceUpdate;
            bool WeightUpdate2 = item.WeightUpdate;
            bool WidthUpdate2 = item.WidthUpdate; ;

            #endregion // Act

            #region Assert
                     
            Assert.IsFalse(Acommerce_AsinUpdate2);
            Assert.IsFalse(Acommerce_Bullet1Update2);
            Assert.IsFalse(Acommerce_Bullet2Update2);
            Assert.IsFalse(Acommerce_Bullet3Update2);
            Assert.IsFalse(Acommerce_Bullet4Update2);
            Assert.IsFalse(Acommerce_Bullet5Update2);
            Assert.IsFalse(Acommerce_ComponentsUpdate2);
            Assert.IsFalse(Acommerce_CostUpdate2);
            Assert.IsFalse(Acommerce_ExternalIDUpdate2);
            Assert.IsFalse(Acommerce_ExternalIdTypeUpdate2);
            Assert.IsFalse(Acommerce_ImagePath1Update2);
            Assert.IsFalse(Acommerce_ImagePath2Update2);
            Assert.IsFalse(Acommerce_ImagePath3Update2);
            Assert.IsFalse(Acommerce_ImagePath4Update2);
            Assert.IsFalse(Acommerce_ImagePath5Update2);
            Assert.IsFalse(Acommerce_ItemHeightUpdate2);
            Assert.IsFalse(Acommerce_ItemLengthUpdate2);
            Assert.IsFalse(Acommerce_ItemNameUpdate2);
            Assert.IsFalse(Acommerce_ItemWeightUpdate2);
            Assert.IsFalse(Acommerce_ItemWidthUpdate2);
            Assert.IsFalse(Acommerce_ModelNameUpdate2);
            Assert.IsFalse(Acommerce_PackageHeightUpdate2);
            Assert.IsFalse(Acommerce_PackageLengthUpdate2);
            Assert.IsFalse(Acommerce_PackageWeightUpdate2);
            Assert.IsFalse(Acommerce_PackageWidthUpdate2);
            Assert.IsFalse(Acommerce_PageQtyUpdate2);
            Assert.IsFalse(Acommerce_ProductCategoryUpdate2);
            Assert.IsFalse(Acommerce_ProductDescriptionUpdate2);
            Assert.IsFalse(Acommerce_ProductSubcategoryUpdate2);
            Assert.IsFalse(Acommerce_ManufacturerNameUpdate2);
            Assert.IsFalse(Acommerce_MsrpUpdate2);
            Assert.IsFalse(Acommerce_SearchTermsUpdate2);
            Assert.IsFalse(Acommerce_SizeUpdate2);
            Assert.IsFalse(AccountingGroupUpdate2);
            Assert.IsFalse(BillOfMaterialsUpdate2);
            Assert.IsFalse(CasepackHeightUpdate2);
            Assert.IsFalse(CasepackLengthUpdate2);
            Assert.IsFalse(CasepackQtyUpdate2);
            Assert.IsFalse(CasepackUpcUpdate2);
            Assert.IsFalse(CasepackWidthUpdate2);
            Assert.IsFalse(CasepackWeightUpdate2);
            Assert.IsFalse(CategoryUpdate2);
            Assert.IsFalse(Category2Update2);
            Assert.IsFalse(Category3Update2);
            Assert.IsFalse(ColorUpdate2);
            Assert.IsFalse(CopyrightUpdate2);
            Assert.IsFalse(CountryOfOriginUpdate2);
            Assert.IsFalse(CostProfileGroupUpdate2);
            Assert.IsFalse(DefaultActualCostUsdUpdate2);
            Assert.IsFalse(DefaultActualCostCadUpdate2);
            Assert.IsFalse(DescriptionUpdate2);
            Assert.IsFalse(DirectImportUpdate2);
            Assert.IsFalse(DutyUpdate2);
            Assert.IsFalse(EanUpdate2);
            Assert.IsFalse(GpcUpdate2);
            Assert.IsFalse(HeightUpdate2);
            Assert.IsFalse(InstockDateUpdate2);
            Assert.IsFalse(InnerpackHeightUpdate2);
            Assert.IsFalse(InnerpackLengthUpdate2);
            Assert.IsFalse(InnerpackQuantityUpdate2);
            Assert.IsFalse(InnerpackUpcUpdate2);
            Assert.IsFalse(InnerpackWidthUpdate2);
            Assert.IsFalse(InnerpackWeightUpdate2);
            Assert.IsFalse(IsbnUpdate2);
            Assert.IsFalse(ItemCategoryUpdate2);
            Assert.IsFalse(ItemFamilyUpdate2);
            Assert.IsFalse(ItemGroupUpdate2);
            Assert.IsFalse(ItemKeywordsUpdate2);
            Assert.IsFalse(LanguageUpdate2);
            Assert.IsFalse(LengthUpdate2);
            Assert.IsFalse(LicenseUpdate2);
            Assert.IsFalse(LicenseBeginDateUpdate2);
            Assert.IsFalse(ListPriceCadUpdate2);
            Assert.IsFalse(ListPriceUsdUpdate2);
            Assert.IsFalse(ListPriceMxnUpdate2);
            Assert.IsFalse(MetaDescriptionUpdate2);
            Assert.IsFalse(MfgSourceUpdate2);
            Assert.IsFalse(MsrpUpdate2);
            Assert.IsFalse(MsrpCadUpdate2);
            Assert.IsFalse(MsrpMxnUpdate2);
            Assert.IsFalse(ProductFormatUpdate2);
            Assert.IsFalse(ProductGroupUpdate2);
            Assert.IsFalse(ProductLineUpdate2);
            Assert.IsFalse(ProductQtyUpdate2);
            Assert.IsFalse(PricingGroupUpdate2);
            Assert.IsFalse(PsStatusUpdate2);
            Assert.IsFalse(SatCodeUpdate2);
            Assert.IsFalse(ShortDescriptionUpdate2);
            Assert.IsFalse(SizeUpdate2);
            Assert.IsFalse(StandardCostUpdate2);
            Assert.IsFalse(StatsCodeUpdate2);
            Assert.IsFalse(TariffCodeUpdate2);
            Assert.IsFalse(TerritoryUpdate2);
            Assert.IsFalse(TitleUpdate2);
            Assert.IsFalse(UdexUpdate2);
            Assert.IsFalse(UpcUpdate2);
            Assert.IsFalse(WebsitePriceUpdate2);
            Assert.IsFalse(WeightUpdate2);
            Assert.IsFalse(WidthUpdate2);

            #endregion // Assert
        }

        /// <summary>
        ///     Checks all item update fields when a new value is inserted
        /// </summary>
        [TestMethod]
        public void UpdateFields_FieldsHaveNewValues_FlagsShouldBeTrue()
        {
            #region Assemble

            List<ChildElement> billOfMaterials = new List<ChildElement>();
            billOfMaterials.Add(new ChildElement("RP1234", "ITEMID", 1));
            billOfMaterials.Add(new ChildElement("RP5678", "ITEMID", 2));
            List<ChildElement> newBillOfMaterials = new List<ChildElement>();
            newBillOfMaterials.Add(new ChildElement("RP5675", "ITEMID", 2));
            newBillOfMaterials.Add(new ChildElement("RP1234", "ITEMID", 1));
            ItemObject item = new ItemObject(
                "Update",
                "","","","",
            "accountingGroup",
            billOfMaterials,
            "casepackHeight",
            "casepackLength",
            "casepackQty",
            "casepackUpc",
            "casepackWidth",
            "casepackWeight",
            "category",
            "category2",
            "category3",
            "color",
            "copyright",
            "countryOfOrigin",
            "costProfileGroup",
            "defaultActualCostUsd",
            "defaultActualCostCad",
            "description",
            "directImport",
            "duty",
            "ean",
            "ecommerce_Asin",
            "ecommerce_Bullet1",
            "ecommerce_Bullet2",
            "ecommerce_Bullet3",
            "ecommerce_Bullet4",
            "ecommerce_Bullet5",
            "ecommerce_Components",
            "ecommerce_Cost",
            "ecommerce_ExternalID",
            "ecommerce_ExternalIdType",
            "ecommerce_ItemHeight",
            "ecommerce_ItemLength",
            "ecommerce_ItemName",
            "ecommerce_ItemWeight",
            "ecommerce_ItemWidth",
            "ecommerce_ModelName",
            "ecommerce_PackageHeight",
            "ecommerce_PackageLength",
            "ecommerce_PackageWeight",
            "ecommerce_PackageWidth",
            "ecommerce_PageQty",
            "ecommerce_ProductCategory",
            "ecommerce_ProductDescription",
            "ecommerce_ProductSubcategory",
            "ecommerce_ManufacturerName",
            "ecommerce_Msrp",
            "ecommerce_SearchTerms",
            "ecommerce_Size",
            "ecommerceUpc",
            "gpc",
            "height",
            "imagePath",
            "innerpackHeight",
            "innerpackLength",
            "innerpackQuantity",
            "innerpackUpc",
            "innerpackWidth",
            "innerpackWeight",
            "inStockDate",
            "isbn",
            "itemCategory",
            "itemFamily",
            "itemGroup",
            "itemId",
            "itemKeywords",
            "language",
            "length",
            "license",
            "licenseBeginDate",
            "listPriceCad",
            "listPriceUsd",
            "listPriceMxn",
            "metaDescription",
            "mfgSource",
            "msrp",
            "msrpCad",
            "msrpMxn",
            "productFormat",
            "productGroup",
            new List<ChildElement>(),
            "productLine",
            "productQty",
            "property",
            "pricingGroup",
            "printOnDemand",
            "psStatus",
            "satCode",
            "SellOnAllPosters",
            "sellOnAmazon",
            "sellOnFanatics",
            "sellOnGuitarCenter",
            "sellOnHayneedle",
            "SellOnTarget",
            "SellOnTrends",
            "sellOnWalmart",
            "sellOnWayfair",
            "shortDescription",
            "size",
            "standardCost",
            "statsCode",
            "tariffCode",
            "territory",
            "title",
            "udex",
            "upc",
            "websitePrice",
            "weight",
            "width");

            #endregion // Assemble

            #region Act

            bool Acommerce_AsinUpdate1 = item.Ecommerce_AsinUpdate;
            bool Acommerce_Bullet1Update1 = item.Ecommerce_Bullet1Update;
            bool Acommerce_Bullet2Update1 = item.Ecommerce_Bullet2Update;
            bool Acommerce_Bullet3Update1 = item.Ecommerce_Bullet3Update;
            bool Acommerce_Bullet4Update1 = item.Ecommerce_Bullet4Update;
            bool Acommerce_Bullet5Update1 = item.Ecommerce_Bullet5Update;
            bool Acommerce_ComponentsUpdate1 = item.Ecommerce_ComponentsUpdate;
            bool Acommerce_CostUpdate1 = item.Ecommerce_CostUpdate;
            bool Acommerce_ExternalIDUpdate1 = item.Ecommerce_ExternalIdUpdate;
            bool Acommerce_ExternalIdTypeUpdate1 = item.Ecommerce_ExternalIdTypeUpdate;
            bool Acommerce_ImagePath1Update1 = item.Ecommerce_ImagePath1Update;
            bool Acommerce_ImagePath2Update1 = item.Ecommerce_ImagePath2Update;
            bool Acommerce_ImagePath3Update1 = item.Ecommerce_ImagePath3Update;
            bool Acommerce_ImagePath4Update1 = item.Ecommerce_ImagePath4Update;
            bool Acommerce_ImagePath5Update1 = item.Ecommerce_ImagePath5Update;
            bool Acommerce_ItemHeightUpdate1 = item.Ecommerce_ItemHeightUpdate;
            bool Acommerce_ItemLengthUpdate1 = item.Ecommerce_ItemLengthUpdate;
            bool Acommerce_ItemNameUpdate1 = item.Ecommerce_ItemNameUpdate;
            bool Acommerce_ItemWeightUpdate1 = item.Ecommerce_ItemWeightUpdate;
            bool Acommerce_ItemWidthUpdate1 = item.Ecommerce_ItemWidthUpdate;
            bool Acommerce_ModelNameUpdate1 = item.Ecommerce_ModelNameUpdate;
            bool Acommerce_PackageHeightUpdate1 = item.Ecommerce_PackageHeightUpdate;
            bool Acommerce_PackageLengthUpdate1 = item.Ecommerce_PackageLengthUpdate;
            bool Acommerce_PackageWeightUpdate1 = item.Ecommerce_PackageWeightUpdate;
            bool Acommerce_PackageWidthUpdate1 = item.Ecommerce_PackageWidthUpdate;
            bool Acommerce_PageQtyUpdate1 = item.Ecommerce_PageQtyUpdate;
            bool Acommerce_ProductCategoryUpdate1 = item.Ecommerce_ProductCategoryUpdate;
            bool Acommerce_ProductDescriptionUpdate1 = item.Ecommerce_ProductDescriptionUpdate;
            bool Acommerce_ProductSubcategoryUpdate1 = item.Ecommerce_ProductSubcategoryUpdate;
            bool Acommerce_ManufacturerNameUpdate1 = item.Ecommerce_ManufacturerNameUpdate;
            bool Acommerce_MsrpUpdate1 = item.Ecommerce_MsrpUpdate;
            bool Acommerce_SearchTermsUpdate1 = item.Ecommerce_SearchTermsUpdate;
            bool Acommerce_SizeUpdate1 = item.Ecommere_SizeUpdate;
            bool AccountingGroupUpdate1 = item.AccountingGroupUpdate;
            bool BillOfMaterialsUpdate1 = item.BillOfMaterialsUpdate;
            bool CasepackHeightUpdate1 = item.CasepackHeightUpdate;
            bool CasepackLengthUpdate1 = item.CasepackLengthUpdate;
            bool CasepackQtyUpdate1 = item.CasepackQtyUpdate;
            bool CasepackUpcUpdate1 = item.CasepackUpcUpdate;
            bool CasepackWidthUpdate1 = item.CasepackWidthUpdate;
            bool CasepackWeightUpdate1 = item.CasepackWeightUpdate;
            bool CategoryUpdate1 = item.CategoryUpdate;
            bool Category2Update1 = item.Category2Update;
            bool Category3Update1 = item.Category3Update;
            bool ColorUpdate1 = item.ColorUpdate;
            bool CopyrightUpdate1 = item.CopyrightUpdate;
            bool CountryOfOriginUpdate1 = item.CountryOfOriginUpdate;
            bool CostProfileGroupUpdate1 = item.CostProfileGroupUpdate;
            bool DefaultActualCostUsdUpdate1 = item.DefaultActualCostUsdUpdate;
            bool DefaultActualCostCadUpdate1 = item.DefaultActualCostCadUpdate;
            bool DescriptionUpdate1 = item.DescriptionUpdate;
            bool DirectImportUpdate1 = item.DirectImportUpdate;
            bool DutyUpdate1 = item.DutyUpdate;
            bool EanUpdate1 = item.EanUpdate;
            bool GpcUpdate1 = item.GpcUpdate;
            bool HeightUpdate1 = item.HeightUpdate;
            bool InStockDateUpdate1 = item.InStockDateUpdate;
            bool InnerpackHeightUpdate1 = item.InnerpackHeightUpdate;
            bool InnerpackLengthUpdate1 = item.InnerpackLengthUpdate;
            bool InnerpackQuantityUpdate1 = item.InnerpackQuantityUpdate;
            bool InnerpackUpcUpdate1 = item.InnerpackUpcUpdate;
            bool InnerpackWidthUpdate1 = item.InnerpackWidthUpdate;
            bool InnerpackWeightUpdate1 = item.InnerpackWeightUpdate;
            bool IsbnUpdate1 = item.IsbnUpdate;
            bool ItemCategoryUpdate1 = item.ItemCategoryUpdate;
            bool ItemFamilyUpdate1 = item.ItemFamilyUpdate;
            bool ItemGroupUpdate1 = item.ItemGroupUpdate;
            bool ItemKeywordsUpdate1 = item.ItemKeywordsUpdate;
            bool LanguageUpdate1 = item.LanguageUpdate;
            bool LengthUpdate1 = item.LengthUpdate;
            bool LicenseUpdate1 = item.LicenseUpdate;
            bool LicenseBeginDateUpdate1 = item.LicenseBeginDateUpdate;
            bool ListPriceCadUpdate1 = item.ListPriceCadUpdate;
            bool ListPriceUsdUpdate1 = item.ListPriceUsdUpdate;
            bool ListPriceMxnUpdate1 = item.ListPriceMxnUpdate;
            bool MetaDescriptionUpdate1 = item.MetaDescriptionUpdate;
            bool MfgSourceUpdate1 = item.MfgSourceUpdate;
            bool MsrpUpdate1 = item.MsrpUpdate;
            bool MsrpCadUpdate1 = item.MsrpCadUpdate;
            bool MsrpMxnUpdate1 = item.MsrpMxnUpdate;
            bool ProductFormatUpdate1 = item.ProductFormatUpdate;
            bool ProductGroupUpdate1 = item.ProductGroupUpdate;
            bool ProductLineUpdate1 = item.ProductLineUpdate;
            bool ProductQtyUpdate1 = item.ProductQtyUpdate;
            bool PricingGroupUpdate1 = item.PricingGroupUpdate;
            bool PsStatusUpdate1 = item.PsStatusUpdate;
            bool SatCodeUpdate1 = item.SatCodeUpdate;
            bool ShortDescriptionUpdate1 = item.ShortDescriptionUpdate;
            bool SizeUpdate1 = item.SizeUpdate;
            bool StandardCostUpdate1 = item.StandardCostUpdate;
            bool StatsCodeUpdate1 = item.StatsCodeUpdate;
            bool TariffCodeUpdate1 = item.TariffCodeUpdate;
            bool TerritoryUpdate1 = item.TerritoryUpdate;
            bool TitleUpdate1 = item.TitleUpdate;
            bool UdexUpdate1 = item.UdexUpdate;
            bool UpcUpdate1 = item.UpcUpdate;
            bool WebsitePriceUpdate1 = item.WebsitePriceUpdate;
            bool WeightUpdate1 = item.WeightUpdate;
            bool WidthUpdate1 = item.WidthUpdate; ;

            item.Ecommerce_Asin = "1";
            item.Ecommerce_Bullet1 = "1";
            item.Ecommerce_Bullet2 = "1";
            item.Ecommerce_Bullet3 = "1";
            item.Ecommerce_Bullet4 = "1";
            item.Ecommerce_Bullet5 = "1";
            item.Ecommerce_Components = "1";
            item.Ecommerce_Cost = "1";
            item.Ecommerce_ExternalId = "1";
            item.Ecommerce_ExternalIdType = "1";
            item.Ecommerce_ImagePath1 = "1";
            item.Ecommerce_ImagePath2 = "1";
            item.Ecommerce_ImagePath3 = "1";
            item.Ecommerce_ImagePath4 = "1";
            item.Ecommerce_ImagePath5 = "1";
            item.Ecommerce_ItemHeight = "1";
            item.Ecommerce_ItemLength = "1";
            item.Ecommerce_ItemName = "1";
            item.Ecommerce_ItemWeight = "1";
            item.Ecommerce_ItemWidth = "1";
            item.Ecommerce_ModelName = "1";
            item.Ecommerce_PackageHeight = "1";
            item.Ecommerce_PackageLength = "1";
            item.Ecommerce_PackageWeight = "1";
            item.Ecommerce_PackageWidth = "1";
            item.Ecommerce_PageQty = "1";
            item.Ecommerce_ProductCategory = "1";
            item.Ecommerce_ProductDescription = "1";
            item.Ecommerce_ProductSubcategory = "1";
            item.Ecommerce_ManufacturerName = "1";
            item.Ecommerce_Msrp = "1";
            item.Ecommerce_SearchTerms = "1";
            item.Ecommerce_Size = "1";
            item.AccountingGroup = "1";
            item.BillOfMaterials = newBillOfMaterials;
            item.CasepackHeight = "1";
            item.CasepackLength = "1";
            item.CasepackQty = "1";
            item.CasepackUpc = "1";
            item.CasepackWidth = "1";
            item.CasepackWeight = "1";
            item.Category = "1";
            item.Category2 = "1";
            item.Category3 = "1";
            item.Color = "1";
            item.Copyright = "1";
            item.CountryOfOrigin = "1";
            item.CostProfileGroup = "1";
            item.DefaultActualCostUsd = "1";
            item.DefaultActualCostCad = "1";
            item.Description = "1";
            item.DirectImport = "1";
            item.Duty = "1";
            item.Ean = "1";
            item.Gpc = "1";
            item.Height = "1";
            item.InStockDate = "1";
            item.InnerpackHeight = "1";
            item.InnerpackLength = "1";
            item.InnerpackQuantity = "1";
            item.InnerpackUpc = "1";
            item.InnerpackWidth = "1";
            item.InnerpackWeight = "1";
            item.InStockDate = "1";
            item.Isbn = "1";
            item.ItemCategory = "1";
            item.ItemFamily = "1";
            item.ItemGroup = "1";
            item.ItemId = "1";
            item.ItemKeywords = "1";
            item.Language = "1";
            item.Length = "1";
            item.License = "1";
            item.LicenseBeginDate = "1";
            item.ListPriceCad = "1";
            item.ListPriceUsd = "1";
            item.ListPriceMxn = "1";
            item.MetaDescription = "1";
            item.MfgSource = "1";
            item.Msrp = "1";
            item.MsrpCad = "1";
            item.MsrpMxn = "1";
            item.ProductFormat = "1";
            item.ProductGroup = "1";
            item.ProductLine = "1";
            item.ProductQty = "1";
            item.PricingGroup = "1";
            item.PsStatus = "1";
            item.SatCode = "1";
            item.ShortDescription = "1";
            item.Size = "1";
            item.StandardCost = "1";
            item.StatsCode = "1";
            item.TariffCode = "1";
            item.Territory = "1";
            item.Title = "1";
            item.Udex = "1";
            item.Upc = "1";
            item.WebsitePrice = "1";
            item.Weight = "1";
            item.Width = "1"; ;


            bool Acommerce_AsinUpdate2 = item.Ecommerce_AsinUpdate;
            bool Acommerce_Bullet1Update2 = item.Ecommerce_Bullet1Update;
            bool Acommerce_Bullet2Update2 = item.Ecommerce_Bullet2Update;
            bool Acommerce_Bullet3Update2 = item.Ecommerce_Bullet3Update;
            bool Acommerce_Bullet4Update2 = item.Ecommerce_Bullet4Update;
            bool Acommerce_Bullet5Update2 = item.Ecommerce_Bullet5Update;
            bool Acommerce_ComponentsUpdate2 = item.Ecommerce_ComponentsUpdate;
            bool Acommerce_CostUpdate2 = item.Ecommerce_CostUpdate;
            bool Acommerce_ExternalIDUpdate2 = item.Ecommerce_ExternalIdUpdate;
            bool Acommerce_ExternalIdTypeUpdate2 = item.Ecommerce_ExternalIdTypeUpdate;
            bool Acommerce_ImagePath1Update2 = item.Ecommerce_ImagePath1Update;
            bool Acommerce_ImagePath2Update2 = item.Ecommerce_ImagePath2Update;
            bool Acommerce_ImagePath3Update2 = item.Ecommerce_ImagePath3Update;
            bool Acommerce_ImagePath4Update2 = item.Ecommerce_ImagePath4Update;
            bool Acommerce_ImagePath5Update2 = item.Ecommerce_ImagePath5Update;
            bool Acommerce_ItemHeightUpdate2 = item.Ecommerce_ItemHeightUpdate;
            bool Acommerce_ItemLengthUpdate2 = item.Ecommerce_ItemLengthUpdate;
            bool Acommerce_ItemNameUpdate2 = item.Ecommerce_ItemNameUpdate;
            bool Acommerce_ItemWeightUpdate2 = item.Ecommerce_ItemWeightUpdate;
            bool Acommerce_ItemWidthUpdate2 = item.Ecommerce_ItemWidthUpdate;
            bool Acommerce_ModelNameUpdate2 = item.Ecommerce_ModelNameUpdate;
            bool Acommerce_PackageHeightUpdate2 = item.Ecommerce_PackageHeightUpdate;
            bool Acommerce_PackageLengthUpdate2 = item.Ecommerce_PackageLengthUpdate;
            bool Acommerce_PackageWeightUpdate2 = item.Ecommerce_PackageWeightUpdate;
            bool Acommerce_PackageWidthUpdate2 = item.Ecommerce_PackageWidthUpdate;
            bool Acommerce_PageQtyUpdate2 = item.Ecommerce_PageQtyUpdate;
            bool Acommerce_ProductCategoryUpdate2 = item.Ecommerce_ProductCategoryUpdate;
            bool Acommerce_ProductDescriptionUpdate2 = item.Ecommerce_ProductDescriptionUpdate;
            bool Acommerce_ProductSubcategoryUpdate2 = item.Ecommerce_ProductSubcategoryUpdate;
            bool Acommerce_ManufacturerNameUpdate2 = item.Ecommerce_ManufacturerNameUpdate;
            bool Acommerce_MsrpUpdate2 = item.Ecommerce_MsrpUpdate;
            bool Acommerce_SearchTermsUpdate2 = item.Ecommerce_SearchTermsUpdate;
            bool Acommerce_SizeUpdate2 = item.Ecommere_SizeUpdate;
            bool AccountingGroupUpdate2 = item.AccountingGroupUpdate;
            bool BillOfMaterialsUpdate2 = item.BillOfMaterialsUpdate;
            bool CasepackHeightUpdate2 = item.CasepackHeightUpdate;
            bool CasepackLengthUpdate2 = item.CasepackLengthUpdate;
            bool CasepackQtyUpdate2 = item.CasepackQtyUpdate;
            bool CasepackUpcUpdate2 = item.CasepackUpcUpdate;
            bool CasepackWidthUpdate2 = item.CasepackWidthUpdate;
            bool CasepackWeightUpdate2 = item.CasepackWeightUpdate;
            bool CategoryUpdate2 = item.CategoryUpdate;
            bool Category2Update2 = item.Category2Update;
            bool Category3Update2 = item.Category3Update;
            bool ColorUpdate2 = item.ColorUpdate;
            bool CopyrightUpdate2 = item.CopyrightUpdate;
            bool CountryOfOriginUpdate2 = item.CountryOfOriginUpdate;
            bool CostProfileGroupUpdate2 = item.CostProfileGroupUpdate;
            bool DefaultActualCostUsdUpdate2 = item.DefaultActualCostUsdUpdate;
            bool DefaultActualCostCadUpdate2 = item.DefaultActualCostCadUpdate;
            bool DescriptionUpdate2 = item.DescriptionUpdate;
            bool DirectImportUpdate2 = item.DirectImportUpdate;
            bool DutyUpdate2 = item.DutyUpdate;
            bool EanUpdate2 = item.EanUpdate;
            bool GpcUpdate2 = item.GpcUpdate;
            bool HeightUpdate2 = item.HeightUpdate;
            bool InstockDateUpdate2 = item.InStockDateUpdate;
            bool InnerpackHeightUpdate2 = item.InnerpackHeightUpdate;
            bool InnerpackLengthUpdate2 = item.InnerpackLengthUpdate;
            bool InnerpackQuantityUpdate2 = item.InnerpackQuantityUpdate;
            bool InnerpackUpcUpdate2 = item.InnerpackUpcUpdate;
            bool InnerpackWidthUpdate2 = item.InnerpackWidthUpdate;
            bool InnerpackWeightUpdate2 = item.InnerpackWeightUpdate;
            bool IsbnUpdate2 = item.IsbnUpdate;
            bool ItemCategoryUpdate2 = item.ItemCategoryUpdate;
            bool ItemFamilyUpdate2 = item.ItemFamilyUpdate;
            bool ItemGroupUpdate2 = item.ItemGroupUpdate;
            bool ItemKeywordsUpdate2 = item.ItemKeywordsUpdate;
            bool LanguageUpdate2 = item.LanguageUpdate;
            bool LengthUpdate2 = item.LengthUpdate;
            bool LicenseUpdate2 = item.LicenseUpdate;
            bool LicenseBeginDateUpdate2 = item.LicenseBeginDateUpdate;
            bool ListPriceCadUpdate2 = item.ListPriceCadUpdate;
            bool ListPriceUsdUpdate2 = item.ListPriceUsdUpdate;
            bool ListPriceMxnUpdate2 = item.ListPriceMxnUpdate;
            bool MetaDescriptionUpdate2 = item.MetaDescriptionUpdate;
            bool MfgSourceUpdate2 = item.MfgSourceUpdate;
            bool MsrpUpdate2 = item.MsrpUpdate;
            bool MsrpCadUpdate2 = item.MsrpCadUpdate;
            bool MsrpMxnUpdate2 = item.MsrpMxnUpdate;
            bool ProductFormatUpdate2 = item.ProductFormatUpdate;
            bool ProductGroupUpdate2 = item.ProductGroupUpdate;
            bool ProductLineUpdate2 = item.ProductLineUpdate;
            bool ProductQtyUpdate2 = item.ProductQtyUpdate;
            bool PricingGroupUpdate2 = item.PricingGroupUpdate;
            bool PsStatusUpdate2 = item.PsStatusUpdate;
            bool SatCodeUpdate2 = item.SatCodeUpdate;
            bool ShortDescriptionUpdate2 = item.ShortDescriptionUpdate;
            bool SizeUpdate2 = item.SizeUpdate;
            bool StandardCostUpdate2 = item.StandardCostUpdate;
            bool StatsCodeUpdate2 = item.StatsCodeUpdate;
            bool TariffCodeUpdate2 = item.TariffCodeUpdate;
            bool TerritoryUpdate2 = item.TerritoryUpdate;
            bool TitleUpdate2 = item.TitleUpdate;
            bool UdexUpdate2 = item.UdexUpdate;
            bool UpcUpdate2 = item.UpcUpdate;
            bool WebsitePriceUpdate2 = item.WebsitePriceUpdate;
            bool WeightUpdate2 = item.WeightUpdate;
            bool WidthUpdate2 = item.WidthUpdate; ;

            #endregion // Act

            #region Assert

            Assert.IsFalse(Acommerce_AsinUpdate1);
            Assert.IsFalse(Acommerce_Bullet1Update1);
            Assert.IsFalse(Acommerce_Bullet2Update1);
            Assert.IsFalse(Acommerce_Bullet3Update1);
            Assert.IsFalse(Acommerce_Bullet4Update1);
            Assert.IsFalse(Acommerce_Bullet5Update1);
            Assert.IsFalse(Acommerce_ComponentsUpdate1);
            Assert.IsFalse(Acommerce_CostUpdate1);
            Assert.IsFalse(Acommerce_ExternalIDUpdate1);
            Assert.IsFalse(Acommerce_ExternalIdTypeUpdate1);
            Assert.IsFalse(Acommerce_ImagePath1Update1);
            Assert.IsFalse(Acommerce_ImagePath2Update1);
            Assert.IsFalse(Acommerce_ImagePath3Update1);
            Assert.IsFalse(Acommerce_ImagePath4Update1);
            Assert.IsFalse(Acommerce_ImagePath5Update1);
            Assert.IsFalse(Acommerce_ItemHeightUpdate1);
            Assert.IsFalse(Acommerce_ItemLengthUpdate1);
            Assert.IsFalse(Acommerce_ItemNameUpdate1);
            Assert.IsFalse(Acommerce_ItemWeightUpdate1);
            Assert.IsFalse(Acommerce_ItemWidthUpdate1);
            Assert.IsFalse(Acommerce_ModelNameUpdate1);
            Assert.IsFalse(Acommerce_PackageHeightUpdate1);
            Assert.IsFalse(Acommerce_PackageLengthUpdate1);
            Assert.IsFalse(Acommerce_PackageWeightUpdate1);
            Assert.IsFalse(Acommerce_PackageWidthUpdate1);
            Assert.IsFalse(Acommerce_PageQtyUpdate1);
            Assert.IsFalse(Acommerce_ProductCategoryUpdate1);
            Assert.IsFalse(Acommerce_ProductDescriptionUpdate1);
            Assert.IsFalse(Acommerce_ProductSubcategoryUpdate1);
            Assert.IsFalse(Acommerce_ManufacturerNameUpdate1);
            Assert.IsFalse(Acommerce_MsrpUpdate1);
            Assert.IsFalse(Acommerce_SearchTermsUpdate1);
            Assert.IsFalse(Acommerce_SizeUpdate1);
            Assert.IsFalse(AccountingGroupUpdate1);
            Assert.IsFalse(BillOfMaterialsUpdate1);
            Assert.IsFalse(CasepackHeightUpdate1);
            Assert.IsFalse(CasepackLengthUpdate1);
            Assert.IsFalse(CasepackQtyUpdate1);
            Assert.IsFalse(CasepackUpcUpdate1);
            Assert.IsFalse(CasepackWidthUpdate1);
            Assert.IsFalse(CasepackWeightUpdate1);
            Assert.IsFalse(CategoryUpdate1);
            Assert.IsFalse(Category2Update1);
            Assert.IsFalse(Category3Update1);
            Assert.IsFalse(ColorUpdate1);
            Assert.IsFalse(CopyrightUpdate1);
            Assert.IsFalse(CountryOfOriginUpdate1);
            Assert.IsFalse(CostProfileGroupUpdate1);
            Assert.IsFalse(DefaultActualCostUsdUpdate1);
            Assert.IsFalse(DefaultActualCostCadUpdate1);
            Assert.IsFalse(DescriptionUpdate1);
            Assert.IsFalse(DirectImportUpdate1);
            Assert.IsFalse(DutyUpdate1);
            Assert.IsFalse(EanUpdate1);
            Assert.IsFalse(GpcUpdate1);
            Assert.IsFalse(HeightUpdate1);
            Assert.IsFalse(InStockDateUpdate1);
            Assert.IsFalse(InnerpackHeightUpdate1);
            Assert.IsFalse(InnerpackLengthUpdate1);
            Assert.IsFalse(InnerpackQuantityUpdate1);
            Assert.IsFalse(InnerpackUpcUpdate1);
            Assert.IsFalse(InnerpackWidthUpdate1);
            Assert.IsFalse(InnerpackWeightUpdate1);
            Assert.IsFalse(IsbnUpdate1);
            Assert.IsFalse(ItemCategoryUpdate1);
            Assert.IsFalse(ItemFamilyUpdate1);
            Assert.IsFalse(ItemGroupUpdate1);
            Assert.IsFalse(ItemKeywordsUpdate1);
            Assert.IsFalse(LanguageUpdate1);
            Assert.IsFalse(LengthUpdate1);
            Assert.IsFalse(LicenseUpdate1);
            Assert.IsFalse(LicenseBeginDateUpdate1);
            Assert.IsFalse(ListPriceCadUpdate1);
            Assert.IsFalse(ListPriceUsdUpdate1);
            Assert.IsFalse(ListPriceMxnUpdate1);
            Assert.IsFalse(MetaDescriptionUpdate1);
            Assert.IsFalse(MfgSourceUpdate1);
            Assert.IsFalse(MsrpUpdate1);
            Assert.IsFalse(MsrpCadUpdate1);
            Assert.IsFalse(MsrpMxnUpdate1);
            Assert.IsFalse(ProductFormatUpdate1);
            Assert.IsFalse(ProductGroupUpdate1);
            Assert.IsFalse(ProductLineUpdate1);
            Assert.IsFalse(ProductQtyUpdate1);
            Assert.IsFalse(PricingGroupUpdate1);
            Assert.IsFalse(PsStatusUpdate1);
            Assert.IsFalse(SatCodeUpdate1);
            Assert.IsFalse(ShortDescriptionUpdate1);
            Assert.IsFalse(SizeUpdate1);
            Assert.IsFalse(StandardCostUpdate1);
            Assert.IsFalse(StatsCodeUpdate1);
            Assert.IsFalse(TariffCodeUpdate1);
            Assert.IsFalse(TerritoryUpdate1);
            Assert.IsFalse(TitleUpdate1);
            Assert.IsFalse(UdexUpdate1);
            Assert.IsFalse(UpcUpdate1);
            Assert.IsFalse(WebsitePriceUpdate1);
            Assert.IsFalse(WeightUpdate1);
            Assert.IsFalse(WidthUpdate1); ;


            Assert.IsTrue(Acommerce_AsinUpdate2);
            Assert.IsTrue(Acommerce_Bullet1Update2);
            Assert.IsTrue(Acommerce_Bullet2Update2);
            Assert.IsTrue(Acommerce_Bullet3Update2);
            Assert.IsTrue(Acommerce_Bullet4Update2);
            Assert.IsTrue(Acommerce_Bullet5Update2);
            Assert.IsTrue(Acommerce_ComponentsUpdate2);
            Assert.IsTrue(Acommerce_CostUpdate2);
            Assert.IsTrue(Acommerce_ExternalIDUpdate2);
            Assert.IsTrue(Acommerce_ExternalIdTypeUpdate2);
            Assert.IsTrue(Acommerce_ImagePath1Update2);
            Assert.IsTrue(Acommerce_ImagePath2Update2);
            Assert.IsTrue(Acommerce_ImagePath3Update2);
            Assert.IsTrue(Acommerce_ImagePath4Update2);
            Assert.IsTrue(Acommerce_ImagePath5Update2);
            Assert.IsTrue(Acommerce_ItemHeightUpdate2);
            Assert.IsTrue(Acommerce_ItemLengthUpdate2);
            Assert.IsTrue(Acommerce_ItemNameUpdate2);
            Assert.IsTrue(Acommerce_ItemWeightUpdate2);
            Assert.IsTrue(Acommerce_ItemWidthUpdate2);
            Assert.IsTrue(Acommerce_ModelNameUpdate2);
            Assert.IsTrue(Acommerce_PackageHeightUpdate2);
            Assert.IsTrue(Acommerce_PackageLengthUpdate2);
            Assert.IsTrue(Acommerce_PackageWeightUpdate2);
            Assert.IsTrue(Acommerce_PackageWidthUpdate2);
            Assert.IsTrue(Acommerce_PageQtyUpdate2);
            Assert.IsTrue(Acommerce_ProductCategoryUpdate2);
            Assert.IsTrue(Acommerce_ProductDescriptionUpdate2);
            Assert.IsTrue(Acommerce_ProductSubcategoryUpdate2);
            Assert.IsTrue(Acommerce_ManufacturerNameUpdate2);
            Assert.IsTrue(Acommerce_MsrpUpdate2);
            Assert.IsTrue(Acommerce_SearchTermsUpdate2);
            Assert.IsTrue(Acommerce_SizeUpdate2);
            Assert.IsTrue(AccountingGroupUpdate2);
            Assert.IsTrue(BillOfMaterialsUpdate2);
            Assert.IsTrue(CasepackHeightUpdate2);
            Assert.IsTrue(CasepackLengthUpdate2);
            Assert.IsTrue(CasepackQtyUpdate2);
            Assert.IsTrue(CasepackUpcUpdate2);
            Assert.IsTrue(CasepackWidthUpdate2);
            Assert.IsTrue(CasepackWeightUpdate2);
            Assert.IsTrue(CategoryUpdate2);
            Assert.IsTrue(Category2Update2);
            Assert.IsTrue(Category3Update2);
            Assert.IsTrue(ColorUpdate2);
            Assert.IsTrue(CopyrightUpdate2);
            Assert.IsTrue(CountryOfOriginUpdate2);
            Assert.IsTrue(CostProfileGroupUpdate2);
            Assert.IsTrue(DefaultActualCostUsdUpdate2);
            Assert.IsTrue(DefaultActualCostCadUpdate2);
            Assert.IsTrue(DescriptionUpdate2);
            Assert.IsTrue(DirectImportUpdate2);
            Assert.IsTrue(DutyUpdate2);
            Assert.IsTrue(EanUpdate2);
            Assert.IsTrue(GpcUpdate2);
            Assert.IsTrue(HeightUpdate2);
            Assert.IsTrue(InstockDateUpdate2);
            Assert.IsTrue(InnerpackHeightUpdate2);
            Assert.IsTrue(InnerpackLengthUpdate2);
            Assert.IsTrue(InnerpackQuantityUpdate2);
            Assert.IsTrue(InnerpackUpcUpdate2);
            Assert.IsTrue(InnerpackWidthUpdate2);
            Assert.IsTrue(InnerpackWeightUpdate2);
            Assert.IsTrue(IsbnUpdate2);
            Assert.IsTrue(ItemCategoryUpdate2);
            Assert.IsTrue(ItemFamilyUpdate2);
            Assert.IsTrue(ItemGroupUpdate2);
            Assert.IsTrue(ItemKeywordsUpdate2);
            Assert.IsTrue(LanguageUpdate2);
            Assert.IsTrue(LengthUpdate2);
            Assert.IsTrue(LicenseUpdate2);
            Assert.IsTrue(LicenseBeginDateUpdate2);
            Assert.IsTrue(ListPriceCadUpdate2);
            Assert.IsTrue(ListPriceUsdUpdate2);
            Assert.IsTrue(ListPriceMxnUpdate2);
            Assert.IsTrue(MetaDescriptionUpdate2);
            Assert.IsTrue(MfgSourceUpdate2);
            Assert.IsTrue(MsrpUpdate2);
            Assert.IsTrue(MsrpCadUpdate2);
            Assert.IsTrue(MsrpMxnUpdate2);
            Assert.IsTrue(ProductFormatUpdate2);
            Assert.IsTrue(ProductGroupUpdate2);
            Assert.IsTrue(ProductLineUpdate2);
            Assert.IsTrue(ProductQtyUpdate2);
            Assert.IsTrue(PricingGroupUpdate2);
            Assert.IsTrue(PsStatusUpdate2);
            Assert.IsTrue(SatCodeUpdate2);
            Assert.IsTrue(ShortDescriptionUpdate2);
            Assert.IsTrue(SizeUpdate2);
            Assert.IsTrue(StandardCostUpdate2);
            Assert.IsTrue(StatsCodeUpdate2);
            Assert.IsTrue(TariffCodeUpdate2);
            Assert.IsTrue(TerritoryUpdate2);
            Assert.IsTrue(TitleUpdate2);
            Assert.IsTrue(UdexUpdate2);
            Assert.IsTrue(UpcUpdate2);
            Assert.IsTrue(WebsitePriceUpdate2);
            Assert.IsTrue(WeightUpdate2);
            Assert.IsTrue(WidthUpdate2);

            #endregion // Assert
        }
        
    }
}
