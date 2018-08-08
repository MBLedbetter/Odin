using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogLibrary;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Odin.Data.Tests
{
    [TestClass]
    public class OptionRepositoryTests
    {
        #region Insert Tests

        /// <summary>
        ///     Tests RetrieveOptions retrieves the option values for the given option id from ODIN_OPTIONS_TABLE
        /// </summary>
        [TestMethod]
        public void OptionRepositoryTests_RetrieveOptions_ShouldRetrieve()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            OptionRepository optionRepository = new OptionRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);

            #endregion // Assemble

            #region Act

            optionRepository.InsertOption("1", "Option1","");
            optionRepository.InsertOption("2", "Option2", "");
            optionRepository.InsertOption("2", "Option22", "");
            optionRepository.InsertOption("3", "Option3", "");
            List<string> options = optionRepository.RetrieveOptions("2", "");

            #endregion // Act

            #region Assert
            
            Assert.AreEqual(2, options.Count);
            Assert.AreEqual("Option2", options[0]);
            Assert.AreEqual("Option22", options[1]);

            #endregion // Assert
        }

        #endregion // Retrieval Tests
    }
}
