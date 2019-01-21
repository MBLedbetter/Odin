using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdinModels;

namespace OdinTests.BusinessLogicLayer.Models
{
    [TestClass]
    public class ItemErrorTests
    {

        /// <summary>
        ///     This method test the SelectItem function with a valid row number, field name and error Message. Method should succeed.
        /// </summary>
        [TestMethod]
        public void ItemError_ValueIsAValidRowAndMessageAndField_ShouldSucceed()
        {

            #region SetUp

            string errorMessage = "Invalid input";
            string fieldName = "ItemId";
            ItemError itemError = new ItemError("RP123", 1, errorMessage, fieldName);

            #endregion // Set Up

            #region Act

            int returnedRow = itemError.LineNumber;
            string returnedMessage = itemError.ErrorMessage;

            #endregion // Act

            #region Assert

            Assert.AreEqual(returnedMessage, "ItemId Invalid input");
            Assert.AreEqual(returnedRow, 1);
            Assert.AreEqual(fieldName, "ItemId");

            #endregion // Assert

        }
    }
}
