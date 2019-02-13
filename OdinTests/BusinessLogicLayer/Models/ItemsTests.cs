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
            ItemObject item = new ItemObject(1);
            ItemObject item2 = new ItemObject(1);
            ItemObject item3 = new ItemObject(1);
            ItemObject item4 = new ItemObject(1);
            // item5 has no updates, should return false
            ItemObject item5 = new ItemObject(1);
            ItemObject item6 = new ItemObject(1);
            ItemObject item7 = new ItemObject(1);
            ItemObject item8 = new ItemObject(1);

            #endregion // Assemble

            #region Act


            item.EcommerceBullet1 = "New Value";
            item2.EcommerceItemWidth = "11";
            item3.EcommerceMsrp = "0.99";
            item4.EcommerceImagePath2 = "img links";
            item6.EcommerceSize = "Boardom";
            item7.PricingGroup = "Elephant";
            item8.EcommerceAsin = "0009876";

            #endregion // Act

            #region Assert

            Assert.IsTrue(item.EcommerceValuesUpdate);
            Assert.IsTrue(item2.EcommerceValuesUpdate);
            Assert.IsTrue(item3.EcommerceValuesUpdate);
            Assert.IsTrue(item4.EcommerceValuesUpdate);
            Assert.IsFalse(item5.EcommerceValuesUpdate);
            Assert.IsTrue(item6.EcommerceValuesUpdate);
            Assert.IsFalse(item7.EcommerceValuesUpdate);
            Assert.IsTrue(item8.EcommerceValuesUpdate);

            #endregion // Assert
        }

        [TestMethod]
        public void ItemUpdateTest_HasUpdates_ShouldReturnTrue()
        {
            #region Assemble

            ItemObject Item = new ItemObject(1);
            ItemObject sellOnAllPostersItem = new ItemObject(1);
            ItemObject sellOnAmazonItem = new ItemObject(1);
            ItemObject sellOnFanaticsItem = new ItemObject(1);
            ItemObject sellOnGuitarCenterItem = new ItemObject(1);
            ItemObject sellOnHayneedleItem = new ItemObject(1);
            ItemObject sellOnTargetItem = new ItemObject(1);
            ItemObject sellOnTrendsItem = new ItemObject(1);
            ItemObject sellOnWalmartItem = new ItemObject(1);
            ItemObject sellOnWayfairItem = new ItemObject(1);
            ItemObject EcommerceAsinItem = new ItemObject(1);
            ItemObject EcommerceBullet1Item = new ItemObject(1);
            ItemObject EcommerceBullet2Item = new ItemObject(1);
            ItemObject EcommerceBullet3Item = new ItemObject(1);
            ItemObject EcommerceBullet4Item = new ItemObject(1);
            ItemObject EcommerceBullet5Item = new ItemObject(1);
            ItemObject EcommerceComponentsItem = new ItemObject(1);
            ItemObject EcommerceCostItem = new ItemObject(1);
            ItemObject EcommerceExternalIDItem = new ItemObject(1);
            ItemObject EcommerceExternalIdTypeItem = new ItemObject(1);
            ItemObject EcommerceImagePath1Item = new ItemObject(1);
            ItemObject EcommerceImagePath2Item = new ItemObject(1);
            ItemObject EcommerceImagePath3Item = new ItemObject(1);
            ItemObject EcommerceImagePath4Item = new ItemObject(1);
            ItemObject EcommerceImagePath5Item = new ItemObject(1);
            ItemObject EcommerceItemHeightItem = new ItemObject(1);
            ItemObject EcommerceItemLengthItem = new ItemObject(1);
            ItemObject EcommerceItemNameItem = new ItemObject(1);
            ItemObject EcommerceItemWeightItem = new ItemObject(1);
            ItemObject EcommerceItemWidthItem = new ItemObject(1);
            ItemObject EcommerceModelNameItem = new ItemObject(1);
            ItemObject EcommercePackageHeightItem = new ItemObject(1);
            ItemObject EcommercePackageLengthItem = new ItemObject(1);
            ItemObject EcommercePackageWeightItem = new ItemObject(1);
            ItemObject EcommercePackageWidthItem = new ItemObject(1);
            ItemObject EcommercePageQtyItem = new ItemObject(1);
            ItemObject EcommerceProductCategoryItem = new ItemObject(1);
            ItemObject EcommerceProductDescriptionItem = new ItemObject(1);
            ItemObject EcommerceProductSubcategoryItem = new ItemObject(1);
            ItemObject EcommerceManufacturerNameItem = new ItemObject(1);
            ItemObject EcommerceMsrpItem = new ItemObject(1);
            ItemObject EcommerceSearchTermsItem = new ItemObject(1);
            ItemObject EcommerceSizeItem = new ItemObject(1);
            ItemObject accountingGroupItem = new ItemObject(1);
            ItemObject casepackHeightItem = new ItemObject(1);
            ItemObject casepackLengthItem = new ItemObject(1);
            ItemObject casepackQtyItem = new ItemObject(1);
            ItemObject casepackUpcItem = new ItemObject(1);
            ItemObject casepackWidthItem = new ItemObject(1);
            ItemObject casepackWeightItem = new ItemObject(1);
            ItemObject categoryItem = new ItemObject(1);
            ItemObject category2Item = new ItemObject(1);
            ItemObject category3Item = new ItemObject(1);
            ItemObject colorItem = new ItemObject(1);
            ItemObject copyrightItem = new ItemObject(1);
            ItemObject countryOfOriginItem = new ItemObject(1);
            ItemObject costProfileGroupItem = new ItemObject(1);
            ItemObject costProfileGroupItem2 = new ItemObject(1);
            ItemObject defaultActualCostUsdItem = new ItemObject(1);
            ItemObject defaultActualCostCadItem = new ItemObject(1);
            ItemObject descriptionItem = new ItemObject(1);
            ItemObject descriptionItem2 = new ItemObject(1);
            ItemObject descriptionItem3 = new ItemObject(1);
            ItemObject descriptionItem4 = new ItemObject(1);
            ItemObject directImportItem = new ItemObject(1);
            ItemObject dutyItem = new ItemObject(1);
            ItemObject eanItem = new ItemObject(1);
            ItemObject gpcItem = new ItemObject(1);
            ItemObject heightItem = new ItemObject(1);
            ItemObject innerpackHeightItem = new ItemObject(1);
            ItemObject innerpackLengthItem = new ItemObject(1);
            ItemObject innerpackQuantityItem = new ItemObject(1);
            ItemObject innerpackUpcItem = new ItemObject(1);
            ItemObject innerpackWidthItem = new ItemObject(1);
            ItemObject innerpackWeightItem = new ItemObject(1);
            ItemObject inStockDateItem = new ItemObject(1);
            ItemObject isbnItem = new ItemObject(1);
            ItemObject itemCategoryItem = new ItemObject(1);
            ItemObject itemCategoryItem2 = new ItemObject(1);
            ItemObject itemCategoryItem3 = new ItemObject(1);
            ItemObject itemFamilyItem = new ItemObject(1);
            ItemObject itemGroupItem = new ItemObject(1);
            ItemObject itemIdItem = new ItemObject(1);
            ItemObject itemKeywordsItem = new ItemObject(1);
            ItemObject languageItem = new ItemObject(1);
            ItemObject lengthItem = new ItemObject(1);
            ItemObject licenseItem = new ItemObject(1);
            ItemObject licenseBeginDateItem = new ItemObject(1);
            ItemObject listPriceCadItem = new ItemObject(1);
            ItemObject listPriceUsdItem = new ItemObject(1);
            ItemObject listPriceMxnItem = new ItemObject(1);
            ItemObject metaDescriptionItem = new ItemObject(1);
            ItemObject mfgSourceItem = new ItemObject(1);
            ItemObject msrpItem = new ItemObject(1);
            ItemObject msrpCadItem = new ItemObject(1);
            ItemObject msrpMxnItem = new ItemObject(1);
            ItemObject productFormatItem = new ItemObject(1);
            ItemObject productGroupItem = new ItemObject(1);
            ItemObject productGroupItem2 = new ItemObject(1);
            ItemObject productIdTranslationItem = new ItemObject(1);
            ItemObject productLineItem = new ItemObject(1);
            ItemObject productQtyItem = new ItemObject(1);
            ItemObject propertyItem = new ItemObject(1);
            ItemObject pricingGroupItem = new ItemObject(1);
            ItemObject printOnDemandItem = new ItemObject(1);
            ItemObject psStatusItem = new ItemObject(1);
            ItemObject satCodeItem = new ItemObject(1);
            ItemObject shortDescriptionItem = new ItemObject(1);
            ItemObject sizeItem = new ItemObject(1);
            ItemObject standardCostItem = new ItemObject(1);
            ItemObject statsCodeItem = new ItemObject(1);
            ItemObject tariffCodeItem = new ItemObject(1);
            ItemObject territoryItem = new ItemObject(1);
            ItemObject titleItem = new ItemObject(1);
            ItemObject udexItem = new ItemObject(1);
            ItemObject upcItem = new ItemObject(1);
            ItemObject websitePriceItem = new ItemObject(1);
            ItemObject weightItem = new ItemObject(1);
            ItemObject widthItem = new ItemObject(1);

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
            EcommerceAsinItem.EcommerceAsin = "1";
            EcommerceBullet1Item.EcommerceBullet1 = "1";
            EcommerceBullet2Item.EcommerceBullet2 = "1";
            EcommerceBullet3Item.EcommerceBullet3 = "1";
            EcommerceBullet4Item.EcommerceBullet4 = "1";
            EcommerceBullet5Item.EcommerceBullet5 = "1";
            EcommerceComponentsItem.EcommerceComponents = "1";
            EcommerceCostItem.EcommerceCost = "1";
            EcommerceExternalIDItem.EcommerceExternalId = "1";
            EcommerceExternalIdTypeItem.EcommerceExternalIdType = "1";
            EcommerceImagePath1Item.EcommerceImagePath1 = "1";
            EcommerceImagePath2Item.EcommerceImagePath2 = "1";
            EcommerceImagePath3Item.EcommerceImagePath3 = "1";
            EcommerceImagePath4Item.EcommerceImagePath4 = "1";
            EcommerceImagePath5Item.EcommerceImagePath5 = "1";
            EcommerceItemHeightItem.EcommerceItemHeight = "1";
            EcommerceItemLengthItem.EcommerceItemLength = "1";
            EcommerceItemNameItem.EcommerceItemName = "1";
            EcommerceItemWeightItem.EcommerceItemWeight = "1";
            EcommerceItemWidthItem.EcommerceItemWidth = "1";
            EcommerceModelNameItem.EcommerceModelName = "1";
            EcommercePackageHeightItem.EcommercePackageHeight = "1";
            EcommercePackageLengthItem.EcommercePackageLength = "1";
            EcommercePackageWeightItem.EcommercePackageWeight = "1";
            EcommercePackageWidthItem.EcommercePackageWidth = "1";
            EcommercePageQtyItem.EcommercePageQty = "1";
            EcommerceProductCategoryItem.EcommerceProductCategory = "1";
            EcommerceProductDescriptionItem.EcommerceProductDescription = "1";
            EcommerceProductSubcategoryItem.EcommerceProductSubcategory = "1";
            EcommerceManufacturerNameItem.EcommerceManufacturerName = "1";
            EcommerceMsrpItem.EcommerceMsrp = "1";
            EcommerceSearchTermsItem.EcommerceGenericKeywords = "1";
            EcommerceSizeItem.EcommerceSize = "1";
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

            Assert.IsFalse(Item.HasUpdate);
            Assert.IsFalse(Item.EcommerceValuesUpdate);
            Assert.IsFalse(Item.BuItemsInvUpdate);
            Assert.IsFalse(Item.CmItemMethodUpdate);
            Assert.IsFalse(Item.FxdBinLocInvUpdate);
            Assert.IsFalse(Item.InvItemsUpdate);
            Assert.IsFalse(Item.ItemAttribExUpdate);
            Assert.IsFalse(Item.ItemTerritoryUpdate);
            Assert.IsFalse(Item.ItemLanguageUpdate);
            Assert.IsFalse(Item.ItemWebInfoUpdate);
            Assert.IsFalse(Item.MasterItemUpdate);
            Assert.IsFalse(Item.ProdItemUpdate);
            Assert.IsFalse(Item.ProdPgrpLnkUpdate);
            Assert.IsFalse(Item.ProdPriceUpdate);
            Assert.IsFalse(Item.PurchItemAttrUpdate);
            Assert.IsFalse(Item.PvItmCategoryUpdate);

            Assert.IsTrue(sellOnAllPostersItem.SellOnFlagUpdate);
            Assert.IsTrue(sellOnAmazonItem.SellOnFlagUpdate);
            Assert.IsTrue(sellOnFanaticsItem.SellOnFlagUpdate);
            Assert.IsTrue(sellOnGuitarCenterItem.SellOnFlagUpdate);
            Assert.IsTrue(sellOnHayneedleItem.SellOnFlagUpdate);
            Assert.IsTrue(sellOnTargetItem.SellOnFlagUpdate);
            Assert.IsTrue(sellOnWalmartItem.SellOnFlagUpdate);
            Assert.IsTrue(sellOnWayfairItem.SellOnFlagUpdate);



            Assert.IsTrue(EcommerceAsinItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceBullet1Item.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceBullet2Item.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceBullet3Item.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceBullet4Item.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceBullet5Item.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceComponentsItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceCostItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceExternalIDItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceExternalIdTypeItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceImagePath1Item.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceImagePath2Item.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceImagePath3Item.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceImagePath4Item.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceImagePath5Item.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceItemHeightItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceItemLengthItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceItemNameItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceItemWeightItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceItemWidthItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceModelNameItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommercePackageHeightItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommercePackageLengthItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommercePackageWeightItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommercePackageWidthItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommercePageQtyItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceProductCategoryItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceProductDescriptionItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceProductSubcategoryItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceManufacturerNameItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceMsrpItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceSearchTermsItem.EcommerceValuesUpdate);
            Assert.IsTrue(EcommerceSizeItem.EcommerceValuesUpdate);
            Assert.IsTrue(accountingGroupItem.ProdPgrpLnkUpdate);
            Assert.IsTrue(casepackHeightItem.ItemAttribExUpdate);
            Assert.IsTrue(casepackLengthItem.ItemAttribExUpdate);
            Assert.IsTrue(casepackQtyItem.ItemAttribExUpdate);
            Assert.IsTrue(casepackUpcItem.ItemAttribExUpdate);
            Assert.IsTrue(casepackWidthItem.ItemAttribExUpdate);
            Assert.IsTrue(casepackWeightItem.ItemAttribExUpdate);
            Assert.IsTrue(categoryItem.ItemWebInfoUpdate);
            Assert.IsTrue(category2Item.ItemWebInfoUpdate);
            Assert.IsTrue(category3Item.ItemWebInfoUpdate);
            Assert.IsTrue(colorItem.InvItemsUpdate);
            Assert.IsTrue(copyrightItem.ItemWebInfoUpdate);
            Assert.IsTrue(countryOfOriginItem.BuItemsInvUpdate);
            Assert.IsTrue(costProfileGroupItem.CmItemMethodUpdate);
            Assert.IsTrue(costProfileGroupItem2.MasterItemUpdate);
            Assert.IsTrue(defaultActualCostUsdItem.BuItemsInvUpdate);
            Assert.IsTrue(defaultActualCostCadItem.BuItemsInvUpdate);
            Assert.IsTrue(descriptionItem.InvItemsUpdate);
            Assert.IsTrue(descriptionItem2.MasterItemUpdate);
            Assert.IsTrue(descriptionItem3.ProdItemUpdate);
            Assert.IsTrue(descriptionItem4.PurchItemAttrUpdate);
            Assert.IsTrue(directImportItem.ItemAttribExUpdate);
            // Assert.IsTrue(dutyItem.Update);
            Assert.IsTrue(eanItem.ProdItemUpdate);
            Assert.IsTrue(gpcItem.ProdItemUpdate);
            Assert.IsTrue(heightItem.InvItemsUpdate);
            Assert.IsTrue(innerpackHeightItem.ItemAttribExUpdate);
            Assert.IsTrue(innerpackLengthItem.ItemAttribExUpdate);
            Assert.IsTrue(innerpackQuantityItem.ItemAttribExUpdate);
            Assert.IsTrue(innerpackUpcItem.ItemAttribExUpdate);
            Assert.IsTrue(innerpackWidthItem.ItemAttribExUpdate);
            Assert.IsTrue(innerpackWeightItem.ItemAttribExUpdate);
            Assert.IsTrue(inStockDateItem.ItemWebInfoUpdate);
            Assert.IsTrue(isbnItem.ProdItemUpdate);
            Assert.IsTrue(itemCategoryItem.PvItmCategoryUpdate);
            Assert.IsTrue(itemCategoryItem2.MasterItemUpdate);
            Assert.IsTrue(itemCategoryItem3.ProdItemUpdate);
            Assert.IsTrue(itemFamilyItem.MasterItemUpdate);
            Assert.IsTrue(itemGroupItem.MasterItemUpdate);
            Assert.IsTrue(itemKeywordsItem.ItemWebInfoUpdate);
            Assert.IsTrue(languageItem.ItemLanguageUpdate);
            Assert.IsTrue(lengthItem.InvItemsUpdate);
            Assert.IsTrue(licenseItem.ItemWebInfoUpdate);
            Assert.IsTrue(licenseBeginDateItem.ItemAttribExUpdate);
            Assert.IsTrue(listPriceCadItem.ProdPriceUpdate);
            Assert.IsTrue(listPriceUsdItem.ProdPriceUpdate);
            Assert.IsTrue(listPriceMxnItem.ProdPriceUpdate);
            Assert.IsTrue(metaDescriptionItem.ItemWebInfoUpdate);
            Assert.IsTrue(mfgSourceItem.BuItemsInvUpdate);
            Assert.IsTrue(msrpItem.ProdPriceUpdate);
            Assert.IsTrue(msrpCadItem.ProdPriceUpdate);
            Assert.IsTrue(msrpMxnItem.ProdPriceUpdate);
            Assert.IsTrue(productFormatItem.ItemAttribExUpdate);
            Assert.IsTrue(productGroupItem.ItemAttribExUpdate);
            Assert.IsTrue(productGroupItem2.ProdPriceUpdate);
            Assert.IsTrue(productLineItem.ItemAttribExUpdate);
            Assert.IsTrue(productQtyItem.ItemWebInfoUpdate);
            Assert.IsTrue(propertyItem.ItemWebInfoUpdate);
            Assert.IsTrue(pricingGroupItem.ProdPgrpLnkUpdate);
            Assert.IsTrue(printOnDemandItem.ItemAttribExUpdate);
            Assert.IsTrue(psStatusItem.MasterItemUpdate);
            Assert.IsTrue(shortDescriptionItem.ItemWebInfoUpdate);
            Assert.IsTrue(sizeItem.ItemWebInfoUpdate);
            Assert.IsTrue(standardCostItem.PurchItemAttrUpdate);
            Assert.IsTrue(satCodeItem.ItemAttribExUpdate);
            Assert.IsTrue(statsCodeItem.ProdItemUpdate);
            Assert.IsTrue(tariffCodeItem.InvItemsUpdate);
            Assert.IsTrue(territoryItem.ItemTerritoryUpdate);
            Assert.IsTrue(titleItem.ItemWebInfoUpdate);
            Assert.IsTrue(udexItem.ProdItemUpdate);
            Assert.IsTrue(upcItem.InvItemsUpdate);
            Assert.IsTrue(websitePriceItem.ItemAttribExUpdate);
            Assert.IsTrue(weightItem.InvItemsUpdate);
            Assert.IsTrue(widthItem.InvItemsUpdate);
            #endregion // Assert
        }

        [TestMethod]
        public void ValidateActiveField_StatusOfUpdate_ShouldSucceed()
        {
            #region SetUp

            ItemObject item = new ItemObject(1)
            {
                Status = "Update"
            };
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

            ItemObject item = new ItemObject(1)
            {
                AccountingGroup = "t",
                CasepackHeight = "4",
                CasepackLength = "4",
                CasepackQty = "4",
                CasepackWidth = "4",
                CasepackWeight = "4",
                Color = "RED",
                CountryOfOrigin = "USA",
                CostProfileGroup = "T",
                DefaultActualCostCad = "3",
                DefaultActualCostUsd = "2",
                Description = "DDD",
                DirectImport = "Y",
                Ean = "Y",
                Gpc = "Y",
                Height = "3",
                InnerpackHeight = "3",
                InnerpackLength = "3",
                InnerpackQuantity = "3",
                InnerpackWidth = "3",
                InnerpackWeight = "3",
                Isbn = "YT",
                ItemCategory = "R",
                ItemFamily = "RE",
                ItemGroup = "rER",
                Language = "ENG",
                LicenseBeginDate = "",
                ListPriceUsd = "3",
                ListPriceCad = "3",
                ListPriceMxn = "3",
                Length = "3",
                MfgSource = "BB",
                Msrp = "2",
                MsrpCad = "2",
                ProductFormat = "F",
                ProductGroup = "G",
                ProductLine = "L",
                PricingGroup = "PG",
                SatCode = "SC1",
                StatsCode = "SC",
                StandardCost = "SC",
                TariffCode = "11.99",
                Territory = "USA",
                Udex = "",
                Upc = "111122223333",
                WebsitePrice = "3.33",
                Weight = "3",
                Width = "2"
            };

            #endregion // Set Up

            #region Act
            // item.CheckForWeb();
            bool result = item.HasWeb;

            #endregion // Act

            #region Assert

            Assert.IsFalse(result);

            #endregion // Assert
        }

        [TestMethod]
        public void ValidateActiveField_StatusOfRemove_ShouldFail()
        {
            #region SetUp

            ItemObject item = new ItemObject(1)
            {
                Status = "Remove"
            };
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

            ItemObject item = new ItemObject(1);
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

            List<ChildElement> billOfMaterials = new List<ChildElement>() {
                new ChildElement("RP1234", "ITEMID", 1),
                new ChildElement("RP5678", "ITEMID", 2)
            };
            List<ChildElement> sameBillOfMaterials = new List<ChildElement>() {
                new ChildElement("RP1234", "ITEMID", 1),
                new ChildElement("RP5675", "ITEMID", 2)
            };
            List<ChildElement> newBillOfMaterials = new List<ChildElement>() { 
                new ChildElement("RP5675", "ITEMID", 2),
                new ChildElement("RP1234", "ITEMID", 1)
            };

            ItemObject item = new ItemObject(1)
            {
                BillOfMaterials = billOfMaterials
            };
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

            List<ChildElement> billOfMaterials = new List<ChildElement>() { 
                new ChildElement("RP1234", "ITEMID", 1),
                new ChildElement("RP5678", "ITEMID", 2)
            };
            List<ChildElement> pOd = new List<ChildElement>() {
                new ChildElement("RP1234", "ITEMID", 1),
                new ChildElement("RP5678", "ITEMID", 2)
            };
            ItemObject item = new ItemObject(1)
            {
                Status = "Update",
                AltImageFile1 = "",
                AltImageFile2 = "",
                AltImageFile3 = "",
                AltImageFile4 = "",
                AccountingGroup = "accountingGroup",
                BillOfMaterials = billOfMaterials,
                CasepackHeight = "casepackHeight",
                CasepackLength = "casepackLength",
                CasepackQty = "casepackQty",
                CasepackUpc = "casepackUpc",
                CasepackWidth = "casepackWidth",
                CasepackWeight = "casepackWeight",
                Category = "category",
                Category2 = "category2",
                Category3 = "category3",
                Color = "color",
                Copyright = "copyright",
                CountryOfOrigin = "countryOfOrigin",
                CostProfileGroup = "costProfileGroup",
                DefaultActualCostUsd = "defaultActualCostUsd",
                DefaultActualCostCad = "defaultActualCostCad",
                Description = "description",
                DirectImport = "directImport",
                Duty = "duty",
                Ean = "ean",
                EcommerceAsin = "EcommerceAsin",
                EcommerceBullet1 = "EcommerceBullet1",
                EcommerceBullet2 = "EcommerceBullet2",
                EcommerceBullet3 = "EcommerceBullet3",
                EcommerceBullet4 = "EcommerceBullet4",
                EcommerceBullet5 = "EcommerceBullet5",
                EcommerceComponents = "EcommerceComponents",
                EcommerceCost = "EcommerceCost",
                EcommerceExternalId = "EcommerceExternalID",
                EcommerceExternalIdType = "EcommerceExternalIdType",
                EcommerceGenericKeywords = "EcommerceGenericeKeywords",
                EcommerceItemHeight = "EcommerceItemHeight",
                EcommerceItemLength = "EcommerceItemLength",
                EcommerceItemName = "EcommerceItemName",
                EcommerceItemWeight = "EcommerceItemWeight",
                EcommerceItemWidth = "EcommerceItemWidth",
                EcommerceModelName = "EcommerceModelName",
                EcommercePackageHeight = "EcommercePackageHeight",
                EcommercePackageLength = "EcommercePackageLength",
                EcommercePackageWeight = "EcommercePackageWeight",
                EcommercePackageWidth = "EcommercePackageWidth",
                EcommercePageQty = "EcommercePageQty",
                EcommerceProductCategory = "EcommerceProductCategory",
                EcommerceProductDescription = "EcommerceProductDescription",
                EcommerceProductSubcategory = "EcommerceProductSubcategory",
                EcommerceManufacturerName = "EcommerceManufacturerName",
                EcommerceMsrp = "EcommerceMsrp",
                EcommerceSize = "EcommerceSearchTerms",
                EcommerceSubjectKeywords = "EcommerceSize",
                EcommerceUpc = "ecommerceUpc",
                Gpc = "gpc",
                Height = "height",
                ImagePath = "imagePath",
                InnerpackHeight = "innerpackHeight",
                InnerpackLength = "innerpackLength",
                InnerpackQuantity = "innerpackQuantity",
                InnerpackUpc = "innerpackUpc",
                InnerpackWidth = "innerpackWidth",
                InnerpackWeight = "innerpackWeight",
                InStockDate = "inStockDate",
                Isbn = "isbn",
                ItemCategory = "itemCategory",
                ItemFamily = "itemFamily",
                ItemGroup = "itemGroup",
                ItemId = "itemId",
                ItemKeywords = "itemKeywords",
                Language = "language",
                Length = "length",
                License = "license",
                LicenseBeginDate = "licenseBeginDate",
                ListPriceCad = "listPriceCad",
                ListPriceUsd = "listPriceUsd",
                ListPriceMxn = "listPriceMxn",
                MetaDescription = "metaDescription",
                MfgSource = "mfgSource",
                Msrp = "msrp",
                MsrpCad = "msrpCad",
                MsrpMxn = "msrpMxn",
                ProductFormat = "productFormat",
                ProductGroup = "productGroup",
                ProductIdTranslation = pOd,
                ProductLine = "productLine",
                ProductQty = "productQty",
                Property = "property",
                PricingGroup = "pricingGroup",
                PrintOnDemand = "printOnDemand",
                PsStatus = "psStatus",
                SatCode = "satCode",
                SellOnAllPosters = "SellOnAllPosters",
                SellOnAmazon = "sellOnAmazon",
                SellOnFanatics = "sellOnFanatics",
                SellOnGuitarCenter = "sellOnGuitarCenter",
                SellOnHayneedle = "sellOnHayneedle",
                SellOnTarget = "SellOnTarget",
                SellOnTrends = "SellOnTrends",
                SellOnWalmart = "sellOnWalmart",
                SellOnWayfair = "sellOnWayfair",
                ShortDescription = "shortDescription",
                Size = "size",
                StandardCost = "standardCost",
                StatsCode = "statsCode",
                TariffCode = "tariffCode",
                Territory = "territory",
                Title = "title",
                Udex = "udex",
                Upc = "upc",
                WebsitePrice = "websitePrice",
                Weight = "weight",
                Width = "width"
            };
            item.ResetUpdate();
            #endregion // Assemble

            #region Act

            item.EcommerceAsin = item.EcommerceAsin;
            item.EcommerceBullet1 = item.EcommerceBullet1;
            item.EcommerceBullet2 = item.EcommerceBullet2;
            item.EcommerceBullet3 = item.EcommerceBullet3;
            item.EcommerceBullet4 = item.EcommerceBullet4;
            item.EcommerceBullet5 = item.EcommerceBullet5;
            item.EcommerceComponents = item.EcommerceComponents;
            item.EcommerceCost = item.EcommerceCost;
            item.EcommerceExternalId = item.EcommerceExternalId;
            item.EcommerceExternalIdType = item.EcommerceExternalIdType;
            item.EcommerceImagePath1 = item.EcommerceImagePath1;
            item.EcommerceImagePath2 = item.EcommerceImagePath2;
            item.EcommerceImagePath3 = item.EcommerceImagePath3;
            item.EcommerceImagePath4 = item.EcommerceImagePath4;
            item.EcommerceImagePath5 = item.EcommerceImagePath5;
            item.EcommerceItemHeight = item.EcommerceItemHeight;
            item.EcommerceItemLength = item.EcommerceItemLength;
            item.EcommerceItemName = item.EcommerceItemName;
            item.EcommerceItemWeight = item.EcommerceItemWeight;
            item.EcommerceItemWidth = item.EcommerceItemWidth;
            item.EcommerceModelName = item.EcommerceModelName;
            item.EcommercePackageHeight = item.EcommercePackageHeight;
            item.EcommercePackageLength = item.EcommercePackageLength;
            item.EcommercePackageWeight = item.EcommercePackageWeight;
            item.EcommercePackageWidth = item.EcommercePackageWidth;
            item.EcommercePageQty = item.EcommercePageQty;
            item.EcommerceProductCategory = item.EcommerceProductCategory;
            item.EcommerceProductDescription = item.EcommerceProductDescription;
            item.EcommerceProductSubcategory = item.EcommerceProductSubcategory;
            item.EcommerceManufacturerName = item.EcommerceManufacturerName;
            item.EcommerceMsrp = item.EcommerceMsrp;
            item.EcommerceGenericKeywords = item.EcommerceGenericKeywords;
            item.EcommerceSize = item.EcommerceSize;
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


            bool Acommerce_AsinUpdate2 = item.EcommerceAsinUpdate;
            bool Acommerce_Bullet1Update2 = item.EcommerceBullet1Update;
            bool Acommerce_Bullet2Update2 = item.EcommerceBullet2Update;
            bool Acommerce_Bullet3Update2 = item.EcommerceBullet3Update;
            bool Acommerce_Bullet4Update2 = item.EcommerceBullet4Update;
            bool Acommerce_Bullet5Update2 = item.EcommerceBullet5Update;
            bool Acommerce_ComponentsUpdate2 = item.EcommerceComponentsUpdate;
            bool Acommerce_CostUpdate2 = item.EcommerceCostUpdate;
            bool Acommerce_ExternalIDUpdate2 = item.EcommerceExternalIdUpdate;
            bool Acommerce_ExternalIdTypeUpdate2 = item.EcommerceExternalIdTypeUpdate;
            bool Acommerce_ImagePath1Update2 = item.EcommerceImagePath1Update;
            bool Acommerce_ImagePath2Update2 = item.EcommerceImagePath2Update;
            bool Acommerce_ImagePath3Update2 = item.EcommerceImagePath3Update;
            bool Acommerce_ImagePath4Update2 = item.EcommerceImagePath4Update;
            bool Acommerce_ImagePath5Update2 = item.EcommerceImagePath5Update;
            bool Acommerce_ItemHeightUpdate2 = item.EcommerceItemHeightUpdate;
            bool Acommerce_ItemLengthUpdate2 = item.EcommerceItemLengthUpdate;
            bool Acommerce_ItemNameUpdate2 = item.EcommerceItemNameUpdate;
            bool Acommerce_ItemWeightUpdate2 = item.EcommerceItemWeightUpdate;
            bool Acommerce_ItemWidthUpdate2 = item.EcommerceItemWidthUpdate;
            bool Acommerce_ModelNameUpdate2 = item.EcommerceModelNameUpdate;
            bool Acommerce_PackageHeightUpdate2 = item.EcommercePackageHeightUpdate;
            bool Acommerce_PackageLengthUpdate2 = item.EcommercePackageLengthUpdate;
            bool Acommerce_PackageWeightUpdate2 = item.EcommercePackageWeightUpdate;
            bool Acommerce_PackageWidthUpdate2 = item.EcommercePackageWidthUpdate;
            bool Acommerce_PageQtyUpdate2 = item.EcommercePageQtyUpdate;
            bool Acommerce_ProductCategoryUpdate2 = item.EcommerceProductCategoryUpdate;
            bool Acommerce_ProductDescriptionUpdate2 = item.EcommerceProductDescriptionUpdate;
            bool Acommerce_ProductSubcategoryUpdate2 = item.EcommerceProductSubcategoryUpdate;
            bool Acommerce_ManufacturerNameUpdate2 = item.EcommerceManufacturerNameUpdate;
            bool Acommerce_MsrpUpdate2 = item.EcommerceMsrpUpdate;
            bool Acommerce_SearchTermsUpdate2 = item.EcommerceGenericKeywordsUpdate;
            bool Acommerce_SizeUpdate2 = item.EcommerceSizeUpdate;
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

            List<ChildElement> billOfMaterials = new List<ChildElement>() { 
                new ChildElement("RP1234", "ITEMID", 1),
                new ChildElement("RP5678", "ITEMID", 2)
            };
            List<ChildElement> newBillOfMaterials = new List<ChildElement>() {
                new ChildElement("RP5675", "ITEMID", 2),
                new ChildElement("RP1234", "ITEMID", 1)
            };
            ItemObject item = new ItemObject(1) {
                Status = "Update",
                AltImageFile1 = "",
                AltImageFile2 = "",
                AltImageFile3 = "",
                AltImageFile4 = "",
                AccountingGroup = "accountingGroup",
                BillOfMaterials = billOfMaterials,
                CasepackHeight = "casepackHeight",
                CasepackLength = "casepackLength",
                CasepackQty = "casepackQty",
                CasepackUpc = "casepackUpc",
                CasepackWidth = "casepackWidth",
                CasepackWeight = "casepackWeight",
                Category = "category",
                Category2 = "category2",
                Category3 = "category3",
                Color = "color",
                Copyright = "copyright",
                CountryOfOrigin = "countryOfOrigin",
                CostProfileGroup = "costProfileGroup",
                DefaultActualCostUsd = "defaultActualCostUsd",
                DefaultActualCostCad = "defaultActualCostCad",
                Description = "description",
                DirectImport = "directImport",
                Duty = "duty",
                Ean = "ean",
                EcommerceAsin = "EcommerceAsin",
                EcommerceBullet1 = "EcommerceBullet1",
                EcommerceBullet2 = "EcommerceBullet2",
                EcommerceBullet3 = "EcommerceBullet3",
                EcommerceBullet4 = "EcommerceBullet4",
                EcommerceBullet5 = "EcommerceBullet5",
                EcommerceComponents = "EcommerceComponents",
                EcommerceCost = "EcommerceCost",
                EcommerceExternalId = "EcommerceExternalID",
                EcommerceExternalIdType = "EcommerceExternalIdType",
                EcommerceGenericKeywords = "EcommerceGenericKeywords",
                EcommerceItemHeight = "EcommerceItemHeight",
                EcommerceItemLength = "EcommerceItemLength",
                EcommerceItemName = "EcommerceItemName",
                EcommerceItemWeight = "EcommerceItemWeight",
                EcommerceItemWidth = "EcommerceItemWidth",
                EcommerceModelName = "EcommerceModelName",
                EcommercePackageHeight = "EcommercePackageHeight",
                EcommercePackageLength = "EcommercePackageLength",
                EcommercePackageWeight = "EcommercePackageWeight",
                EcommercePackageWidth = "EcommercePackageWidth",
                EcommercePageQty = "EcommercePageQty",
                EcommerceProductCategory = "EcommerceProductCategory",
                EcommerceProductDescription = "EcommerceProductDescription",
                EcommerceProductSubcategory = "EcommerceProductSubcategory",
                EcommerceManufacturerName = "EcommerceManufacturerName",
                EcommerceMsrp = "EcommerceMsrp",
                EcommerceSize = "EcommerceSearchTerms",
                EcommerceSubjectKeywords = "EcommerceSize",
                EcommerceUpc = "ecommerceUpc",
                Gpc = "gpc",
                Height = "height",
                ImagePath = "imagePath",
                InnerpackHeight = "innerpackHeight",
                InnerpackLength = "innerpackLength",
                InnerpackQuantity = "innerpackQuantity",
                InnerpackUpc = "innerpackUpc",
                InnerpackWidth = "innerpackWidth",
                InnerpackWeight = "innerpackWeight",
                InStockDate = "inStockDate",
                Isbn = "isbn",
                ItemCategory = "itemCategory",
                ItemFamily = "itemFamily",
                ItemGroup = "itemGroup",
                ItemId = "itemId",
                ItemKeywords = "itemKeywords",
                Language = "language",
                Length = "length",
                License = "license",
                LicenseBeginDate = "licenseBeginDate",
                ListPriceCad = "listPriceCad",
                ListPriceUsd = "listPriceUsd",
                ListPriceMxn = "listPriceMxn",
                MetaDescription = "metaDescription",
                MfgSource = "mfgSource",
                Msrp = "msrp",
                MsrpCad = "msrpCad",
                MsrpMxn = "msrpMxn",
                ProductFormat = "productFormat",
                ProductGroup = "productGroup",
                ProductIdTranslation = new List<ChildElement>(),
                ProductLine = "productLine",
                ProductQty = "productQty",
                Property = "property",
                PricingGroup = "pricingGroup",
                PrintOnDemand = "printOnDemand",
                PsStatus = "psStatus",
                SatCode = "satCode",
                SellOnAllPosters = "SellOnAllPosters",
                SellOnAmazon = "sellOnAmazon",
                SellOnFanatics = "sellOnFanatics",
                SellOnGuitarCenter = "sellOnGuitarCenter",
                SellOnHayneedle = "sellOnHayneedle",
                SellOnTarget = "SellOnTarget",
                SellOnTrends = "SellOnTrends",
                SellOnWalmart = "sellOnWalmart",
                SellOnWayfair = "sellOnWayfair",
                ShortDescription = "shortDescription",
                Size = "size",
                StandardCost = "standardCost",
                StatsCode = "statsCode",
                TariffCode = "tariffCode",
                Territory = "territory",
                Title = "title",
                Udex = "udex",
                Upc = "upc",
                WebsitePrice = "websitePrice",
                Weight = "weight",
                Width = "width"
            };
            item.ResetUpdate();
            #endregion // Assemble

            #region Act

            bool Acommerce_AsinUpdate1 = item.EcommerceAsinUpdate;
            bool Acommerce_Bullet1Update1 = item.EcommerceBullet1Update;
            bool Acommerce_Bullet2Update1 = item.EcommerceBullet2Update;
            bool Acommerce_Bullet3Update1 = item.EcommerceBullet3Update;
            bool Acommerce_Bullet4Update1 = item.EcommerceBullet4Update;
            bool Acommerce_Bullet5Update1 = item.EcommerceBullet5Update;
            bool Acommerce_ComponentsUpdate1 = item.EcommerceComponentsUpdate;
            bool Acommerce_CostUpdate1 = item.EcommerceCostUpdate;
            bool Acommerce_ExternalIDUpdate1 = item.EcommerceExternalIdUpdate;
            bool Acommerce_ExternalIdTypeUpdate1 = item.EcommerceExternalIdTypeUpdate;
            bool Acommerce_ImagePath1Update1 = item.EcommerceImagePath1Update;
            bool Acommerce_ImagePath2Update1 = item.EcommerceImagePath2Update;
            bool Acommerce_ImagePath3Update1 = item.EcommerceImagePath3Update;
            bool Acommerce_ImagePath4Update1 = item.EcommerceImagePath4Update;
            bool Acommerce_ImagePath5Update1 = item.EcommerceImagePath5Update;
            bool Acommerce_ItemHeightUpdate1 = item.EcommerceItemHeightUpdate;
            bool Acommerce_ItemLengthUpdate1 = item.EcommerceItemLengthUpdate;
            bool Acommerce_ItemNameUpdate1 = item.EcommerceItemNameUpdate;
            bool Acommerce_ItemWeightUpdate1 = item.EcommerceItemWeightUpdate;
            bool Acommerce_ItemWidthUpdate1 = item.EcommerceItemWidthUpdate;
            bool Acommerce_ModelNameUpdate1 = item.EcommerceModelNameUpdate;
            bool Acommerce_PackageHeightUpdate1 = item.EcommercePackageHeightUpdate;
            bool Acommerce_PackageLengthUpdate1 = item.EcommercePackageLengthUpdate;
            bool Acommerce_PackageWeightUpdate1 = item.EcommercePackageWeightUpdate;
            bool Acommerce_PackageWidthUpdate1 = item.EcommercePackageWidthUpdate;
            bool Acommerce_PageQtyUpdate1 = item.EcommercePageQtyUpdate;
            bool Acommerce_ProductCategoryUpdate1 = item.EcommerceProductCategoryUpdate;
            bool Acommerce_ProductDescriptionUpdate1 = item.EcommerceProductDescriptionUpdate;
            bool Acommerce_ProductSubcategoryUpdate1 = item.EcommerceProductSubcategoryUpdate;
            bool Acommerce_ManufacturerNameUpdate1 = item.EcommerceManufacturerNameUpdate;
            bool Acommerce_MsrpUpdate1 = item.EcommerceMsrpUpdate;
            bool Acommerce_SearchTermsUpdate1 = item.EcommerceGenericKeywordsUpdate;
            bool Acommerce_SizeUpdate1 = item.EcommerceSizeUpdate;
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

            item.EcommerceAsin = "1";
            item.EcommerceBullet1 = "1";
            item.EcommerceBullet2 = "1";
            item.EcommerceBullet3 = "1";
            item.EcommerceBullet4 = "1";
            item.EcommerceBullet5 = "1";
            item.EcommerceComponents = "1";
            item.EcommerceCost = "1";
            item.EcommerceExternalId = "1";
            item.EcommerceExternalIdType = "1";
            item.EcommerceImagePath1 = "1";
            item.EcommerceImagePath2 = "1";
            item.EcommerceImagePath3 = "1";
            item.EcommerceImagePath4 = "1";
            item.EcommerceImagePath5 = "1";
            item.EcommerceItemHeight = "1";
            item.EcommerceItemLength = "1";
            item.EcommerceItemName = "1";
            item.EcommerceItemWeight = "1";
            item.EcommerceItemWidth = "1";
            item.EcommerceModelName = "1";
            item.EcommercePackageHeight = "1";
            item.EcommercePackageLength = "1";
            item.EcommercePackageWeight = "1";
            item.EcommercePackageWidth = "1";
            item.EcommercePageQty = "1";
            item.EcommerceProductCategory = "1";
            item.EcommerceProductDescription = "1";
            item.EcommerceProductSubcategory = "1";
            item.EcommerceManufacturerName = "1";
            item.EcommerceMsrp = "1";
            item.EcommerceGenericKeywords = "1";
            item.EcommerceSize = "1";
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


            bool Acommerce_AsinUpdate2 = item.EcommerceAsinUpdate;
            bool Acommerce_Bullet1Update2 = item.EcommerceBullet1Update;
            bool Acommerce_Bullet2Update2 = item.EcommerceBullet2Update;
            bool Acommerce_Bullet3Update2 = item.EcommerceBullet3Update;
            bool Acommerce_Bullet4Update2 = item.EcommerceBullet4Update;
            bool Acommerce_Bullet5Update2 = item.EcommerceBullet5Update;
            bool Acommerce_ComponentsUpdate2 = item.EcommerceComponentsUpdate;
            bool Acommerce_CostUpdate2 = item.EcommerceCostUpdate;
            bool Acommerce_ExternalIDUpdate2 = item.EcommerceExternalIdUpdate;
            bool Acommerce_ExternalIdTypeUpdate2 = item.EcommerceExternalIdTypeUpdate;
            bool Acommerce_ImagePath1Update2 = item.EcommerceImagePath1Update;
            bool Acommerce_ImagePath2Update2 = item.EcommerceImagePath2Update;
            bool Acommerce_ImagePath3Update2 = item.EcommerceImagePath3Update;
            bool Acommerce_ImagePath4Update2 = item.EcommerceImagePath4Update;
            bool Acommerce_ImagePath5Update2 = item.EcommerceImagePath5Update;
            bool Acommerce_ItemHeightUpdate2 = item.EcommerceItemHeightUpdate;
            bool Acommerce_ItemLengthUpdate2 = item.EcommerceItemLengthUpdate;
            bool Acommerce_ItemNameUpdate2 = item.EcommerceItemNameUpdate;
            bool Acommerce_ItemWeightUpdate2 = item.EcommerceItemWeightUpdate;
            bool Acommerce_ItemWidthUpdate2 = item.EcommerceItemWidthUpdate;
            bool Acommerce_ModelNameUpdate2 = item.EcommerceModelNameUpdate;
            bool Acommerce_PackageHeightUpdate2 = item.EcommercePackageHeightUpdate;
            bool Acommerce_PackageLengthUpdate2 = item.EcommercePackageLengthUpdate;
            bool Acommerce_PackageWeightUpdate2 = item.EcommercePackageWeightUpdate;
            bool Acommerce_PackageWidthUpdate2 = item.EcommercePackageWidthUpdate;
            bool Acommerce_PageQtyUpdate2 = item.EcommercePageQtyUpdate;
            bool Acommerce_ProductCategoryUpdate2 = item.EcommerceProductCategoryUpdate;
            bool Acommerce_ProductDescriptionUpdate2 = item.EcommerceProductDescriptionUpdate;
            bool Acommerce_ProductSubcategoryUpdate2 = item.EcommerceProductSubcategoryUpdate;
            bool Acommerce_ManufacturerNameUpdate2 = item.EcommerceManufacturerNameUpdate;
            bool Acommerce_MsrpUpdate2 = item.EcommerceMsrpUpdate;
            bool Acommerce_SearchTermsUpdate2 = item.EcommerceGenericKeywordsUpdate;
            bool Acommerce_SizeUpdate2 = item.EcommerceSizeUpdate;
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
