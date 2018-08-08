using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdinRepositories;
using OdinModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using OdinServices;

namespace OdinRepositoryTests
{
    [TestClass]
    public class OdinItemRepositoryTests
    {
        [TestMethod]
        public void InsertItemInfo_InsertValidInfo_ItemInfoShouldSave()
        {
            #region Assemble
            ItemRepository itemRepository = new ItemRepository("", "", "", true);
            List<ProductIdTranslation> PID = new List<ProductIdTranslation>();
            ProductIdTranslation PID1 = new ProductIdTranslation("ST1111", 5);
            ProductIdTranslation PID2 = new ProductIdTranslation("ST2222", 1);
            PID.Add(PID1);
            PID.Add(PID2);
            itemRepository.RemoveTestItem("TestItem2");
            ItemObject item = new ItemObject(
                "Add", 
                "N", 
                "N", 
                "N",
                "N",
                "ASIN",
                "Bullet 1",
                "Bullet 2",
                "Bullet 3",
                "Bullet 4",
                "Bullet 5",
                "Components",
                "5.99",
                "000000000000",
                "UPC",
                "ImagePath1",
                "ImagePath2",
                "ImagePath3",
                "ImagePath4",
                "ImagePath5",
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
                "Product Category",
                "Product Description",
                "Product Subcategory",
                "Manufacturer Name",
                "9.99",
                "Search Terms",
                "8",
                "Accounting Group",
                "1",
                "2",
                "3",
                "999999999999",
                "77",
                "34",
                "Category1",
                "Category2",
                "Category3",
                "Color",
                "Copyright",
                "USA",
                "Cost Profile Group",
                "4.99",
                "8.00",
                "Description",
                "Y",
                "9",
                "EAN",
                "1",
                "1",
                "gpc",
                "2",
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
                "Short Description",
                "size",
                "5.00",
                "statsCode",
                "tariffCode",
                "USA",
                "title",
                "udex",
                "000000000000",
                "2",
                "1"
                );

            ObservableCollection<ItemObject> Items = new ObservableCollection<ItemObject>();
            Items.Add(item);

            #endregion // Assemble

            #region Act

            itemRepository.InsertAll(Items);
            ItemObject newItem = itemser.RetrieveItem("TestItem2", 1);
            #endregion // Act

            #region Assert

            Assert.AreEqual("N", newItem.SellOnAmazon);
            Assert.AreEqual("N", newItem.SellOnFanatics);
            Assert.AreEqual("N", newItem.SellOnJet);
            Assert.AreEqual("N", newItem.SellOnWalmart);
            Assert.AreEqual("ASIN", newItem.Ecommerce_Asin);
            Assert.AreEqual("Bullet 1", newItem.Ecommerce_Bullet1);
            Assert.AreEqual("Bullet 2", newItem.Ecommerce_Bullet2);
            Assert.AreEqual("Bullet 3", newItem.Ecommerce_Bullet3);
            Assert.AreEqual("Bullet 4", newItem.Ecommerce_Bullet4);
            Assert.AreEqual("Bullet 5", newItem.Ecommerce_Bullet5);
            Assert.AreEqual("Components", newItem.Ecommerce_Components);
            Assert.AreEqual("5.99", newItem.Ecommerce_Cost);
            Assert.AreEqual("000000000000", newItem.Ecommerce_ExternalID);
            Assert.AreEqual("UPC", newItem.Ecommerce_ExternalIdType);
            Assert.AreEqual("ImagePath1", newItem.Ecommerce_ImagePath1);
            Assert.AreEqual("ImagePath2", newItem.Ecommerce_ImagePath2);
            Assert.AreEqual("ImagePath3", newItem.Ecommerce_ImagePath3);
            Assert.AreEqual("ImagePath4", newItem.Ecommerce_ImagePath4);
            Assert.AreEqual("ImagePath5", newItem.Ecommerce_ImagePath5);
            Assert.AreEqual("5.0000", newItem.Ecommerce_ItemHeight);
            Assert.AreEqual("4.0000", newItem.Ecommerce_ItemLength);
            Assert.AreEqual("Item Name", newItem.Ecommerce_ItemName);
            Assert.AreEqual("9.0000", newItem.Ecommerce_ItemWeight);
            Assert.AreEqual("5.0000", newItem.Ecommerce_ItemWidth);
            Assert.AreEqual("Model Name", newItem.Ecommerce_ModelName);
            Assert.AreEqual("5.0000", newItem.Ecommerce_PackageHeight);
            Assert.AreEqual("4.0000", newItem.Ecommerce_PackageLength);
            Assert.AreEqual("1.0000", newItem.Ecommerce_PackageWeight);
            Assert.AreEqual("2.0000", newItem.Ecommerce_PackageWidth);
            Assert.AreEqual("Product Category", newItem.Ecommerce_ProductCategory);
            Assert.AreEqual("Product Description", newItem.Ecommerce_ProductDescription);
            Assert.AreEqual("Product Subcategory", newItem.Ecommerce_ProductSubcategory);
            Assert.AreEqual("Manufacturer Name", newItem.Ecommerce_ManufacturerName);
            Assert.AreEqual("9.99", newItem.Ecommerce_Msrp);
            Assert.AreEqual("search terms", newItem.Ecommerce_SearchTerms);
            Assert.AreEqual("8", newItem.Ecommerce_Size);
            // Assert.AreEqual("Accounting Group", newItem.AccountingGroup);
            Assert.AreEqual("1.00", newItem.CasepackHeight);
            Assert.AreEqual("2.00", newItem.CasepackLength);
            Assert.AreEqual("3", newItem.CasepackQty);
            Assert.AreEqual("999999999999", newItem.CasepackUpc);
            Assert.AreEqual("77.00", newItem.CasepackWidth);
            Assert.AreEqual("34.00", newItem.CasepackWeight);
            // Assert.AreEqual("Category1", newItem.Category);
            // Assert.AreEqual("Category2", newItem.Category2);
            // Assert.AreEqual("Category3", newItem.Category3);
            Assert.AreEqual("Color", newItem.Color);
            Assert.AreEqual("Copyright", newItem.Copyright);
            Assert.AreEqual("USA", newItem.CountryOfOrigin);
            Assert.AreEqual("Cost Profile Gr", newItem.CostProfileGroup);
            Assert.AreEqual("4.9900", newItem.DefaultActualCostUsd);
            Assert.AreEqual("8.0000", newItem.DefaultActualCostCad);
            Assert.AreEqual("DESCRIPTION", newItem.Description);
            Assert.AreEqual("Y", newItem.DirectImport);
            Assert.AreEqual("EAN", newItem.Ean);
            Assert.AreEqual("1", newItem.FPLCANL1);
            Assert.AreEqual("1", newItem.FPLUSL1);
            Assert.AreEqual("gpc", newItem.Gpc);
            Assert.AreEqual("2.0000", newItem.Height);
            Assert.AreEqual("2.00", newItem.InnerpackHeight);
            Assert.AreEqual("34.00", newItem.InnerpackLength);
            Assert.AreEqual("90", newItem.InnerpackQuantity);
            Assert.AreEqual("019283746547", newItem.InnerpackUpc);
            Assert.AreEqual("14.00", newItem.InnerpackWidth);
            Assert.AreEqual("52.00", newItem.InnerpackWeight);
            Assert.AreEqual("", newItem.InStockDate);
            Assert.AreEqual("ISBN", newItem.Isbn);
            Assert.AreEqual("Item Category", newItem.ItemCategory);
            Assert.AreEqual("Item Famil", newItem.ItemFamily);
            Assert.AreEqual("item group", newItem.ItemGroup);
            Assert.AreEqual("TestItem2", newItem.ItemId);
            Assert.AreEqual("Item Keywords", newItem.ItemKeywords);
            Assert.AreEqual("ENG", newItem.Language);
            Assert.AreEqual("91", newItem.Length);
            Assert.AreEqual("License", newItem.License);
            Assert.AreEqual("", newItem.LicenseBeginDate);
            Assert.AreEqual("9.99", newItem.ListPriceCad);
            Assert.AreEqual("7.99", newItem.ListPriceUsd);
            Assert.AreEqual("2.22", newItem.ListPriceMxn);
            Assert.AreEqual("Meta Description", newItem.MetaDescription);
            Assert.AreEqual("mfgSource", newItem.MfgSource);
            Assert.AreEqual("7.77", newItem.Msrp);
            Assert.AreEqual("19.99", newItem.MsrpCad);
            Assert.AreEqual("1.99", newItem.MsrpMxn);
            Assert.AreEqual("Product Format", newItem.ProductFormat);
            Assert.AreEqual("Product Group", newItem.ProductGroup);
            Assert.AreEqual("ST1111 (5), ST2222", newItem.ReturnProductIdTranslations());
            Assert.AreEqual("Product Line", newItem.ProductLine);
            Assert.AreEqual("4", newItem.ProductQty);
            Assert.AreEqual("Property", newItem.Property);
            Assert.AreEqual("Pricing Group", newItem.PricingGroup);
            Assert.AreEqual("Y", newItem.PrintOnDemand);
            Assert.AreEqual("A", newItem.PsStatus);
            Assert.AreEqual("Short Description", newItem.ShortDescription);
            Assert.AreEqual("size", newItem.Size);
            Assert.AreEqual("5.00", newItem.StandardCost);
            Assert.AreEqual("statsCode", newItem.StatsCode);
            Assert.AreEqual("tariffCode", newItem.TariffCode);
            Assert.AreEqual("territory", newItem.Territory);
            Assert.AreEqual("title", newItem.Title);
            Assert.AreEqual("udex", newItem.Udex);
            Assert.AreEqual("000000000000", newItem.Upc);
            Assert.AreEqual("2", newItem.Weight);
            Assert.AreEqual("1", newItem.Width);

            #endregion // Assert
        }
    }
}
