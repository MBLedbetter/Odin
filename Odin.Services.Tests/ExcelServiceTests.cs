using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdinServices;
using System.Collections.ObjectModel;
using OdinModels;
using System.Collections.Generic;
using Odin.Data;
using Odin.Services.Tests.Helpers;
using System;

namespace OdinTests.Services
{
    [TestClass]
    public class ExcelServiceTests
    {

        /// <summary>
        ///     Checks that the Modify Keywords function appends item id to the end of keyword search and removes the letters.
        ///     (Implemented so posters could be searched on B2B by number)
        /// </summary>
        [TestMethod]
        public void GenerateSortNumber_ReturnsCorrectNumber_ShouldSucceed()
        {
            #region Assemble
            GlobalData.ClearValues();
            OptionService optionService = new OptionService(new TestOptionRepository(), new TestRequestRepository());
            ExcelService excelService = new ExcelService(true, new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository()), optionService, new TestTemplateRepository(), new TestRequestRepository());
            DateTime dateTime = new DateTime(2019, 6, 27);
            #endregion // Assemble

            #region Act

            string result = excelService.GenerateSortNumber(dateTime);

            #endregion // Act

            #region Assert

            Assert.AreEqual("79809373", result);

            #endregion // Assert
        }

        [TestMethod]
        public void SortAmazonItemVariations_HasValues_ShouldMatch()
        {
            #region Assemble

            GlobalData.ClearValues();
            OptionService optionService = new OptionService(new TestOptionRepository(), new TestRequestRepository());
            ExcelService excelService = new ExcelService(true, new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository()), optionService, new TestTemplateRepository(), new TestRequestRepository());
            ObservableCollection<ItemObject> items = new ObservableCollection<ItemObject>();
            ItemObject item1 = new ItemObject(1)
            {
                ItemId = "RP1234"
            };
            items.Add(item1);
            ItemObject item2 = new ItemObject(1)
            {
                ItemId = "RP4321"
            };
            items.Add(item2);
            ItemObject item3 = new ItemObject(1)
            {
                ItemId = "POD1234"
            };
            items.Add(item3);
            ItemObject item4 = new ItemObject(1)
            {
                ItemId = "FR4321"
            };
            items.Add(item4);
            ItemObject item5 = new ItemObject(1)
            {
                ItemId = "FR1234"
            };
            items.Add(item5);

            #endregion // Assemble

            #region Act

            List<KeyValuePair<string, List<ItemObject>>> SortedItems = excelService.SortAmazonItemVariations(items);

            #endregion // Act

            #region Assert

            Assert.AreEqual(SortedItems[0].Value[0].ItemId, "RP1234");
            Assert.AreEqual(SortedItems[1].Value[0].ItemId, "RP4321");

            #endregion // Assert
        }

        /// <summary>
        ///     Return variant group id should strip off the preceeding letters fromt he itemId
        /// </summary>
        [TestMethod]
        public void ReturnVariantGroupId_HasValues_ShouldMatch()
        {
            #region Assemble


            GlobalData.ClearValues();
            GlobalData.VariantGroupExclusionOptions.Add("RP");
            GlobalData.VariantGroupExclusionOptions.Add("FR");
            GlobalData.VariantGroupExclusionOptions.Add("POD");
            GlobalData.VariantGroupExclusionOptions.Add("BLK22X34");
            OptionService optionService = new OptionService(new TestOptionRepository(), new TestRequestRepository());
            ExcelService excelService = new ExcelService(true, new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository()), optionService, new TestTemplateRepository(), new TestRequestRepository());
            string itemId1 = "RP1234";
            string itemId2 = "FR1234";
            string itemId3 = "POD1234";
            string itemId4 = "FR1234BLK22X34";

            #endregion // Assemble

            #region Act

            string result1 = excelService.ReturnVariantGroupId(itemId1);
            string result2 = excelService.ReturnVariantGroupId(itemId2);
            string result3 = excelService.ReturnVariantGroupId(itemId3);
            string result4 = excelService.ReturnVariantGroupId(itemId4);

            #endregion // Act

            #region Assert

            Assert.AreEqual("1234",result1);
            Assert.AreEqual("1234", result2);
            Assert.AreEqual("1234", result3);
            Assert.AreEqual("1234", result4);

            #endregion // Assert
        }

        /// <summary>
        ///     ReturnVariantAttributeName should return a value that coresponds to the preceeding letters of the itemID
        /// </summary>
        [TestMethod]
        public void ReturnVariantAttributeName_HasValues_ShouldMatch()
        {
            #region Assemble

            GlobalData.ClearValues();

            OptionService optionService = new OptionService(new TestOptionRepository(), new TestRequestRepository());
            ExcelService excelService = new ExcelService(true, new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository()), optionService, new TestTemplateRepository(), new TestRequestRepository());
            ItemObject item1 = new ItemObject(1) { ItemId = "RP1234" };
            ItemObject item2 = new ItemObject(1) { ItemId = "FR1234" };
            ItemObject item3 = new ItemObject(1) { ItemId = "POD1234"};

            #endregion // Assemble

            #region Act

            string result1 = excelService.ReturnVariantAttributeName(item1, "Amazon");
            string result2 = excelService.ReturnVariantAttributeName(item2, "Amazon");
            string result3 = excelService.ReturnVariantAttributeName(item3, "Amazon");

            #endregion // Act

            #region Assert

            Assert.AreEqual("Unframed Version", result1);
            Assert.AreEqual("Framed Version", result2);
            Assert.AreEqual("Premium Unframed", result3);

            #endregion // Assert
        }

        /// <summary>
        ///     ReturnNumberOfComponents should return a string value with the number of components 
        /// </summary>
        [TestMethod]
        public void ReturnNumberOfComponents_HasValues_ShouldMatch()
        {
            #region Assemble


            GlobalData.ClearValues();
            OptionService OptionService = new OptionService(new TestOptionRepository(), new TestRequestRepository());
            ExcelService excelService = new ExcelService(true, new ItemService(new FakeWorkbookReader(), new TestItemRepository(),new TestTemplateRepository()), OptionService, new TestTemplateRepository(), new TestRequestRepository());
            string components = "RP1234^RP2345(4)";
            string components2 = "FR1234";
            string components3 = "POD1234^RP1234";
            string components4 = "POD1234^RP1234(S)";

            #endregion // Assemble

            #region Act

            string result1 = excelService.ReturnNumberOfComponents(components);
            string result2 = excelService.ReturnNumberOfComponents(components2);
            string result3 = excelService.ReturnNumberOfComponents(components3);
            string result4 = excelService.ReturnNumberOfComponents(components4);

            #endregion // Act

            #region Assert

            Assert.AreEqual("5", result1);
            Assert.AreEqual("1", result2);
            Assert.AreEqual("2", result3);
            Assert.AreEqual("2", result4);

            #endregion // Assert
        }

        /// <summary>
        ///     ReturnNumberOfComponents should return a string value with the number of components 
        /// </summary>
        [TestMethod]
        public void CreateComponents_HasValues_ShouldMatch()
        {
            #region Assemble

            
            OptionService optionService = new OptionService(new TestOptionRepository(), new TestRequestRepository());
            ExcelService excelService = new ExcelService(true, new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository()), optionService, new TestTemplateRepository(), new TestRequestRepository());
            string components = "RP1234^RP2345(4)";
            string components2 = "FR1234";
            string components3 = "POD1234^RP1234";
            string components4 = "POD1234^RP1234(S)";

            #endregion // Assemble

            #region Act

            string result1 = excelService.ModifyComponents(components);
            string result2 = excelService.ModifyComponents(components2);
            string result3 = excelService.ModifyComponents(components3);
            string result4 = excelService.ModifyComponents(components4);

            #endregion // Act

            #region Assert

            Assert.AreEqual("RP1234(1)^RP2345(4)", result1);
            Assert.AreEqual("FR1234(1)", result2);
            Assert.AreEqual("POD1234(1)^RP1234(1)", result3);
            Assert.AreEqual("POD1234(1)^RP1234(S)", result4);

            #endregion // Assert
        }

        /// <summary>
        ///     ReturnColumnLetter should pass back the appropriate column letters to go with the given number
        /// </summary>
        [TestMethod]
        public void ReturnColumnLetter_PassedValues_ShouldReturnColumnLetters()
        {
            #region Assemble


            GlobalData.ClearValues();
            OptionService optionService = new OptionService(new TestOptionRepository(), new TestRequestRepository());
            ExcelService excelService = new ExcelService(true, new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository()), optionService, new TestTemplateRepository(), new TestRequestRepository());

            int ColumnCount1 = 29;
            int ColumnCount2 = 5;
            int ColumnCount3 = 52;
            int ColumnCount4 = 26;
            int ColumnCount5 = 27;
            int ColumnCount6 = 53;
            int ColumnCount7 = 79;

            #endregion // Assemble

            #region Act

            string result1 = excelService.ReturnColumLetter(ColumnCount1);
            string result2 = excelService.ReturnColumLetter(ColumnCount2);
            string result3 = excelService.ReturnColumLetter(ColumnCount3);
            string result4 = excelService.ReturnColumLetter(ColumnCount4);
            string result5 = excelService.ReturnColumLetter(ColumnCount5);
            string result6 = excelService.ReturnColumLetter(ColumnCount6);
            string result7 = excelService.ReturnColumLetter(ColumnCount7);

            #endregion // Act

            #region Assert

            Assert.AreEqual("AC", result1);
            Assert.AreEqual("E", result2);
            Assert.AreEqual("AZ", result3);
            Assert.AreEqual("Z", result4);
            Assert.AreEqual("AA", result5);
            Assert.AreEqual("CA", result7);

            #endregion // Assert
        }
        
        /// <summary>
        ///     Checks that the Modify Keywords function appends item id to the end of keyword search and removes the letters.
        ///     (Implemented so posters could be searched on B2B by number)
        /// </summary>
        [TestMethod]
        public void ReturnModifiedKeywords_ShouldAppendIdToKeywordsAndStripLetters()
        {
            #region Assemble
            GlobalData.ClearValues();
            OptionService optionService = new OptionService(new TestOptionRepository(), new TestRequestRepository());
            ExcelService excelService = new ExcelService(true, new ItemService(new FakeWorkbookReader(), new TestItemRepository(), new TestTemplateRepository()), optionService, new TestTemplateRepository(), new TestRequestRepository());
            #endregion // Assemble

            #region Act
            string result = excelService.ModifyKeywords("800884", "bears, dogs, cats");
            string result2 = excelService.ModifyKeywords("RP1234", "bears, dogs, cats");
            #endregion // Act

            #region Assert

            Assert.AreEqual("bears, dogs, cats, 800884", result);
            Assert.AreEqual("bears, dogs, cats, 1234", result2);

            #endregion // Assert
        }

    }
}
