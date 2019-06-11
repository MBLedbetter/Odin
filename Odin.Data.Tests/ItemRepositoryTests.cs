using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using LogLibrary;
using OdinModels;
using Odin.DbTableModels;

namespace Odin.Data.Tests
{
    [TestClass]
    public class ItemRepositoryTests
    {
        #region Insert Tests

        /// <summary>
        ///     Tests InsertAssetItemAttr is properly inserting info into PS_ASSET_ITEM_ATTR
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertAssetItemAttr_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1){
            ItemId = "TEST1"};

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertAssetItemAttr(item, context);
                context.SaveChanges();
            }

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                AssetItemAttr result = (from o in context.AssetItemAttr select o).FirstOrDefault();

                Assert.AreEqual("SHARE",result.Setid);
                Assert.AreEqual("TEST1", result.InvItemId);
                Assert.AreEqual("", result.ProfileId);
            }            

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertBuItemsConfigAll is properly inserting info into PS_BU_ITEMS_CONFIG
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertBuItemsConfigAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1"
            };
            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertBuItemsConfigAll(item, context);
                context.SaveChanges();
            }

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<BuItemsConfig> result = (from o in context.BuItemsConfig select o).ToList();

                Assert.AreEqual("TRCN1", result[0].BusinessUnit);
                Assert.AreEqual("TEST1", result[0].InvItemId);
                Assert.AreEqual("Y", result[0].RuleBasedComp);
                Assert.AreEqual("Y", result[0].RuleBasedOper);
                Assert.AreEqual("", result[0].RefBomItem);
                Assert.AreEqual(0, result[0].CfgLeadTime);
                Assert.AreEqual("", result[0].ShipTypeId);
                Assert.AreEqual("", result[0].BusinessUnitCp);
                Assert.AreEqual("TRUS1", result[1].BusinessUnit);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertBuItemsInvAll is properly inserting info into PS_BU_ITEMS_INV
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertBuItemsInvAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1",
                MfgSource = "MG",
                CountryOfOrigin = "COO",
                DefaultActualCostUsd = "9.99",
                DefaultActualCostCad = "8.99"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertBuItemsInvAll(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<BuItemsInv> result = (from o in context.BuItemsInv select o).ToList();
                
                Assert.AreEqual("N", result[0].AddHandling); //  "N"
                Assert.AreEqual(0, result[0].AnndmInstance); //  0
                Assert.AreEqual("1", result[0].AnndmStatus); //  "1"
                Assert.AreEqual(1, result[0].Aoq); //  1
                Assert.AreEqual(0, result[0].AvailLeadTime); //  0
                Assert.AreEqual(0, result[0].AverageCost); //  0
                Assert.AreEqual(0, result[0].AverageCostMat); //  0
                Assert.AreEqual(1, result[0].BomCode); //  1
                Assert.AreEqual("1", result[0].BomUsage); //  "1"
                Assert.AreEqual("TRCN1", result[0].BusinessUnit); //  businessUnit
                Assert.AreEqual("", result[0].ChargeCode); //  ""
                Assert.AreEqual(0, result[0].ChargeMarkupAmt); //  0
                Assert.AreEqual(0, result[0].ChargeMarkupPcnt); //  0
                Assert.AreEqual("N", result[0].ConsignedFlag); //  "N"
                Assert.AreEqual("100", result[0].CostElement); //  "100"
                Assert.AreEqual("", result[0].CostGroupCd); //  ""
                Assert.AreEqual("COO", result[0].CountryIstOrigin); //  item.CountryOfOrigin
                Assert.AreEqual(8.99m, result[0].CurrentCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual(0, result[0].CycleInstance); //  0
                Assert.AreEqual(0, result[0].DaysSupply); //  0
                Assert.AreEqual(0, result[0].DeclaredValue); //  0
                Assert.AreEqual(8.99m, result[0].DfltActualCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual(0, result[0].DockToStock); //  0
                Assert.AreEqual("", result[0].DpPolicycontrol); //  ""
                Assert.AreEqual("", result[0].DpPolicyset); //  ""
                Assert.AreEqual(null, result[0].DpPublishDate); //  null
                Assert.AreEqual("", result[0].DpPublishname); //  ""
                Assert.AreEqual("N", result[0].EnAutoRev); //  "N"
                Assert.AreEqual(0, result[0].Eoq); //  0
                Assert.AreEqual(0, result[0].EoqcInstance); //  0
                Assert.AreEqual("1", result[0].EoqcStatus); //  "1"
                Assert.AreEqual("", result[0].ExcessBu); //  ""
                Assert.AreEqual("N", result[0].ExcessInventory); //  "N"
                Assert.AreEqual("", result[0].ExportLicNbr); //  ""
                Assert.AreEqual("", result[0].ExporterEccn); //  ""
                Assert.AreEqual(0, result[0].Foq); //  0
                Assert.AreEqual("N", result[0].ForecastItemFlag); //  "N"
                Assert.AreEqual("", result[0].Forecaster); //  ""
                Assert.AreEqual(0, result[0].HistoricalLead); //  0
                Assert.AreEqual(0, result[0].HldcInstance); //  0
                Assert.AreEqual("1", result[0].HldcStatus); //  "1"
                Assert.AreEqual("N", result[0].InclWipQtyFlg); //  "N"
                Assert.AreEqual(0, result[0].InspectTime); //  0
                Assert.AreEqual("TEST1", result[0].InvItemId); //  item.ItemId
                Assert.AreEqual("", result[0].InvStockType); //  ""
                Assert.AreEqual("Y", result[0].InventoryItem); //  "Y"
                Assert.AreEqual("N", result[0].IpPlanningFlg); //  "N"
                Assert.AreEqual("N", result[0].IsolateItemFlg); //  "N"
                Assert.AreEqual("ISS", result[0].IssueMethod); //  "ISS"
                Assert.AreEqual(1, result[0].IssueMultiple); //  1
                Assert.AreEqual("", result[0].IstRegionOrigin); //  ""
                Assert.AreEqual("", result[0].ItemFieldC1A); //  ""
                Assert.AreEqual("", result[0].ItemFieldC1B); //  ""
                Assert.AreEqual("", result[0].ItemFieldC1C); //  ""
                Assert.AreEqual("", result[0].ItemFieldC1D); //  ""
                Assert.AreEqual("", result[0].ItemFieldC10A); //  ""
                Assert.AreEqual("", result[0].ItemFieldC10B); //  ""
                Assert.AreEqual("", result[0].ItemFieldC10C); //  ""
                Assert.AreEqual("", result[0].ItemFieldC10D); //  ""
                Assert.AreEqual("A", result[0].ItemFieldC2); //  "A"
                Assert.AreEqual("", result[0].ItemFieldC30A); //  ""
                Assert.AreEqual("", result[0].ItemFieldC30B); //  ""
                Assert.AreEqual("", result[0].ItemFieldC30C); //  ""
                Assert.AreEqual("", result[0].ItemFieldC30D); //  ""
                Assert.AreEqual("", result[0].ItemFieldC4); //  ""
                Assert.AreEqual("", result[0].ItemFieldC6); //  ""
                Assert.AreEqual("", result[0].ItemFieldC8); //  ""
                Assert.AreEqual(0, result[0].ItemFieldN12A); //  0
                Assert.AreEqual(0, result[0].ItemFieldN12B); //  0
                Assert.AreEqual(0, result[0].ItemFieldN12C); //  0
                Assert.AreEqual(0, result[0].ItemFieldN12D); //  0
                Assert.AreEqual(0, result[0].ItemFieldN15A); //  0
                Assert.AreEqual(0, result[0].ItemFieldN15B); //  0
                Assert.AreEqual(0, result[0].ItemFieldN15C); //  0
                Assert.AreEqual(0, result[0].ItemFieldN15D); //  0
                Assert.AreEqual(null, result[0].ItmStatDtFuture); //  null
                Assert.AreEqual("1", result[0].ItmStatusCurrent); //  "1"
                Assert.AreEqual("", result[0].ItmStatusFuture); //  ""
                Assert.AreEqual(0, result[0].Last2QtrDemand); //  0
                Assert.AreEqual(null, result[0].LastAdjustment); //  null
                Assert.AreEqual(0, result[0].LastAnnualDemand); //  0
                Assert.AreEqual(DbUtil.StripTime(DateTime.Now), result[0].LastCycleCount); //  DbUtil.StripTime(DateTime.Now)
                Assert.AreEqual("", result[0].LastDemandCalc); //  ""
                Assert.AreEqual(null, result[0].LastDemandDate); //  null
                Assert.AreEqual(0, result[0].LastIssExcess); //  0
                Assert.AreEqual(0, result[0].LastMoDemand); //  0
                Assert.AreEqual("", result[0].LastOrder); //  ""
                Assert.AreEqual(null, result[0].LastOrderDate); //  null
                Assert.AreEqual(null, result[0].LastPitCount); //  null
                Assert.AreEqual(0, result[0].LastPricePaid); //  0
                Assert.AreEqual(null, result[0].LastPutawayDate); //  null
                Assert.AreEqual(0, result[0].LastQtrDemand); //  0
                Assert.AreEqual(0, result[0].LastUdDemand); //  0
                Assert.AreEqual(null, result[0].LastUtilReview); //  null
                Assert.AreEqual("ITM", result[0].MasterRtgOpt); //  "ITM"
                Assert.AreEqual("N", result[0].MaterialReconFlg); //  "N"
                Assert.AreEqual("Y", result[0].MfgCostedFlag); //  "Y"
                Assert.AreEqual(0, result[0].MfgLeadtimeF); //  0
                Assert.AreEqual(0, result[0].MfgLeadtimeV); //  0
                Assert.AreEqual("HR", result[0].MfgLtratef); //  "HR"
                Assert.AreEqual("HR", result[0].MfgLtratev); //  "HR"
                Assert.AreEqual("TEST1", result[0].MgAssociatedBom); //  item.ItemId
                Assert.AreEqual("01", result[0].MgPrdnOption); //  "01"
                Assert.AreEqual("N", result[0].MgValidPrdnOpt); //  "N"
                Assert.AreEqual(null, result[0].NextUtilReview); //  null
                Assert.AreEqual("Y", result[0].NoReplenishFlg); //  "Y"
                Assert.AreEqual("N", result[0].NonOwnFlag); //  "N"
                Assert.AreEqual(0, result[0].OrderMultiple); //  0
                Assert.AreEqual("N", result[0].Oversized); //  "N"
                Assert.AreEqual("N", result[0].PhantomItemFlag); //  "N"
                Assert.AreEqual("", result[0].PlannerCd); //  ""
                Assert.AreEqual("", result[0].PrdnAreaCode); //  ""
                Assert.AreEqual(0, result[0].ProjectedLead); //  0
                Assert.AreEqual(0, result[0].QtyAvailable); //  0
                Assert.AreEqual(0, result[0].QtyIutPar); //  0
                Assert.AreEqual(0, result[0].QtyMaximum); //  0
                Assert.AreEqual(0, result[0].QtyOnhand); //  0
                Assert.AreEqual(0, result[0].QtyOwned); //  0
                Assert.AreEqual(0, result[0].QtyReserved); //  0
                Assert.AreEqual("TEST1", result[0].RefRoutingItem); //  item.ItemId
                Assert.AreEqual("", result[0].RelatedItemId); //  ""
                Assert.AreEqual(0, result[0].ReorderPoint); //  0
                Assert.AreEqual(0, result[0].ReorderQty); //  0
                Assert.AreEqual(365, result[0].ReplCalcPeriod); //  365
                Assert.AreEqual("", result[0].ReplenishClass); //  ""
                Assert.AreEqual(0, result[0].ReplenishLead); //  0
                Assert.AreEqual(0, result[0].ReplenishPoint); //  0
                Assert.AreEqual(0, result[0].RetestLeadTime); //  0
                Assert.AreEqual("N", result[0].RevisionControl); //  "N"
                Assert.AreEqual(0, result[0].RopcInstance); //  0
                Assert.AreEqual("1", result[0].RopcStatus); //  "1"
                Assert.AreEqual(0, result[0].RtgCode); //  0
                Assert.AreEqual(0, result[0].SafetyLeadTime); //  0
                Assert.AreEqual(0, result[0].SafetyStock); //  0
                Assert.AreEqual("", result[0].SfDispatchMode); //  ""
                Assert.AreEqual("3", result[0].SfRplMethod); //  "3"
                Assert.AreEqual("1", result[0].SfRplMode); //  "1"
                Assert.AreEqual("", result[0].SfRplPrdnArea); //  ""
                Assert.AreEqual("1", result[0].SfRplSource); //  "1"
                Assert.AreEqual("", result[0].SfRplStorArea); //  ""
                Assert.AreEqual("", result[0].SfRplStorLev1); //  ""
                Assert.AreEqual("", result[0].SfRplStorLev2); //  ""
                Assert.AreEqual("", result[0].SfRplStorLev3); //  ""
                Assert.AreEqual("", result[0].SfRplStorLev4); //  ""
                Assert.AreEqual("1", result[0].SfRplType); //  "1"
                Assert.AreEqual("", result[0].SfRplVendorId); //  ""
                Assert.AreEqual("", result[0].SfRplVndrLoc); //  ""
                Assert.AreEqual(0, result[0].SfWipMaxQty); //  0
                Assert.AreEqual(0, result[0].ShelfLife); //  0
                Assert.AreEqual("", result[0].ShipTypeId); //  ""
                Assert.AreEqual("MG", result[0].SourceCode); //  item.MfgSource
                Assert.AreEqual(0, result[0].SstcInstance); //  0
                Assert.AreEqual("1", result[0].SstcStatus); //  "1"
                Assert.AreEqual("N", result[0].StagedDateFlag); //  "N"
                Assert.AreEqual("EA", result[0].StdPackUom); //  "EA"
                Assert.AreEqual(95, result[0].StockoutRate); //  95
                Assert.AreEqual(0, result[0].TargetLevel); //  0
                Assert.AreEqual(0, result[0].TransferMinOrder); //  0
                Assert.AreEqual(0, result[0].TransferYield); //  0
                Assert.AreEqual("F", result[0].TransitCostTyp); //  "F"
                Assert.AreEqual("0", result[0].UomConvFlag); //  "0"
                Assert.AreEqual("N", result[0].UseUpQoh); //  "N"
                Assert.AreEqual("01", result[0].UsgTrckngMethod); //  "01"
                Assert.AreEqual("", result[0].VendorId); //  ""
                Assert.AreEqual("", result[0].VndrLoc); //  ""
                Assert.AreEqual(0, result[0].WipMinQty); //  0
                Assert.AreEqual("N", result[0].YieldCalcFlg); //  "N"
                
                Assert.AreEqual("TRMX1", result[1].BusinessUnit); //  businessUnit
                Assert.AreEqual(9.99m, result[1].CurrentCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual(9.99m, result[1].DfltActualCost); //  Convert.ToDecimal(defaultActualCost)

                Assert.AreEqual("TRUS1", result[2].BusinessUnit); //  businessUnit
                Assert.AreEqual(9.99m, result[2].CurrentCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual(9.99m, result[2].DfltActualCost); //  Convert.ToDecimal(defaultActualCost)
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertBuItemUtilCdAll is properly inserting info into PS_BU_ITEM_UTIL_CD
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertBuItemUtilCdAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertBuItemUtilCdAll(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<BuItemUtilCd> result = (from o in context.BuItemUtilCd select o).ToList();

                Assert.AreEqual("TRCN1", result[0].BusinessUnit);
                Assert.AreEqual("TEST1", result[0].InvItemId);
                Assert.AreEqual("N", result[0].PlanningFlg);
                Assert.AreEqual("", result[0].UtilizCd);
                Assert.AreEqual("MC", result[0].UtilizGroup);
                Assert.AreEqual("TRUS1", result[1].BusinessUnit);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertCmItemMethodAll is properly inserting info into PS_CM_ITEM_METHOD_ALL
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertCmItemMethodAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1"
            };
            item.CostProfileGroup = "ACTUAL_FIFO";
            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertCmItemMethodAll(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<CmItemMethod> result = (from o in context.CmItemMethod select o).ToList();

                Assert.AreEqual("TRCN1", result[0].BusinessUnit);
                Assert.AreEqual("TEST1", result[0].InvItemId);
                Assert.AreEqual("FIN", result[0].CmBook);
                Assert.AreEqual("ACTFIFO", result[0].CmProfileId);
                Assert.AreEqual("TRUS1", result[1].BusinessUnit);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertCustomerProductAttributes is properly excluding new "N" values from PS_CUSTOMER_PRODUCT_ATTRIBUTES
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertCustomerProductAttributes_ItemInfoShouldNotSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            GlobalData.CustomerIdConversions.Add("AMAZON SELLER CENTRAL", "9");

            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1",
                SellOnAmazonSellerCentral = "N"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertCustomerProductAttributes("TEST1", "9", "N", context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            bool exists = false;
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                if (context.CustomerProductAttributes.Any(o => o.ProductId == "TEST1" && o.CustId == "9" && o.Setid == "SHARE"))
                {
                    exists = true;
                }
                Assert.IsFalse(exists);
            }

            #endregion // Assert
        }


        /// <summary>
        ///     Tests InsertCustomerProductAttributes is properly inserting info into PS_CUSTOMER_PRODUCT_ATTRIBUTES
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertCustomerProductAttributes_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            GlobalData.ClearValues();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            GlobalData.CustomerIdConversions.Add("AMAZON SELLER CENTRAL", "9");

            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1",
                SellOnAmazonSellerCentral = "Y"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertCustomerProductAttributes("TEST1", "9" ,"Y", context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<CustomerProductAttributes> result = (from o in context.CustomerProductAttributes select o).ToList();
                
                Assert.AreEqual("SHARE", result[0].Setid);
                Assert.AreEqual("TEST1", result[0].ProductId);
                Assert.AreEqual(0, result[0].InnerpackQty);
                Assert.AreEqual(0, result[0].CasepackQty);
                Assert.AreEqual("Y", result[0].SendInventory);
                Assert.AreEqual("9", result[0].CustId);
                Assert.AreEqual("Y", result[0].SendInventory);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertDefaultLocInvAll is properly inserting info into PS_DEFAULT_LOC_INV
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertDefaultLocInvAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1"
            };
            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertDefaultLocInvAll(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<DefaultLocInv> result = (from o in context.DefaultLocInv select o).ToList();
                
                Assert.AreEqual("TRCN1", result[0].BusinessUnit);
                Assert.AreEqual("TEST1", result[0].InvItemId);
                Assert.AreEqual("O",result[0].DefLocType);
                Assert.AreEqual("RECV",result[0].StorageArea);
                Assert.AreEqual("0",result[0].StorLevel1);
                Assert.AreEqual("0",result[0].StorLevel2);
                Assert.AreEqual("",result[0].StorLevel3);
                Assert.AreEqual("",result[0].StorLevel4);
                Assert.AreEqual("TRUS1", result[1].BusinessUnit);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertEcommerceValues is properly inserting info into PS_AMAZON_ITEM_ATTRIBUTES
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertEcommerceValues_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1",
                EcommerceAsin = "Asin",
                EcommerceBullet1 = "Bullet1",
                EcommerceBullet2 = "Bullet2",
                EcommerceBullet3 = "Bullet3",
                EcommerceBullet4 = "Bullet4",
                EcommerceBullet5 = "Bullet5",
                EcommerceComponents = "Components",
                EcommerceCost = "5",
                EcommerceCountryofOrigin = "Coo",
                EcommerceExternalId = "ExId",
                EcommerceExternalIdType = "ExIdT",
                EcommerceImagePath1 = "ImageUrl1",
                EcommerceImagePath2 = "ImageUrl2",
                EcommerceImagePath3 = "ImageUrl3",
                EcommerceImagePath4 = "ImageUrl4",
                EcommerceImagePath5 = "ImageUrl5",
                EcommerceItemHeight = "6",
                EcommerceItemLength = "1",
                EcommerceItemName = "ItemName",
                EcommerceItemTypeKeywords = "EcommerceItemTypeKeywords",
                EcommerceItemWeight = "2",
                EcommerceItemWidth = "3",
                EcommerceModelName = "ModelName",
                EcommercePackageHeight = "1.1",
                EcommercePackageLength = "1.2",
                EcommercePackageWeight = "1.3",
                EcommercePackageWidth = "1.4",
                EcommercePageQty = "3",
                EcommerceProductCategory = "ProductCategory",
                EcommerceProductDescription = "FullDescription",
                EcommerceProductSubcategory = "ProductSubcategory",
                EcommerceManufacturerName = "ManufacturerName",
                EcommerceMsrp = "9.99",
                EcommerceGenericKeywords = "EcommerceGenericKeywords",
                EcommerceSize = "Size",
                EcommerceUpc = "UpcOverride",
            };
            item.ResetUpdate();
            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertEcommerceValues(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                AmazonItemAttributes amazonItemAttributes = (from o in context.AmazonItemAttributes select o).FirstOrDefault();

                Assert.AreEqual("Asin", amazonItemAttributes.Asin);
                Assert.AreEqual("Bullet1", amazonItemAttributes.Bullet1);
                Assert.AreEqual("Bullet2", amazonItemAttributes.Bullet2);
                Assert.AreEqual("Bullet3", amazonItemAttributes.Bullet3);
                Assert.AreEqual("Bullet4", amazonItemAttributes.Bullet4);
                Assert.AreEqual("Bullet5", amazonItemAttributes.Bullet5);
                Assert.AreEqual("Components", amazonItemAttributes.Components);
                Assert.AreEqual(5, amazonItemAttributes.Cost);
                Assert.AreEqual("Coo", amazonItemAttributes.CountryOfOrigin);
                Assert.AreEqual("ExId", amazonItemAttributes.ExternalId);
                Assert.AreEqual("ExIdT", amazonItemAttributes.ExternalIdType);
                Assert.AreEqual("ImageUrl1", amazonItemAttributes.ImageUrl1);
                Assert.AreEqual("ImageUrl2", amazonItemAttributes.ImageUrl2);
                Assert.AreEqual("ImageUrl3", amazonItemAttributes.ImageUrl3);
                Assert.AreEqual("ImageUrl4", amazonItemAttributes.ImageUrl4);
                Assert.AreEqual("ImageUrl5", amazonItemAttributes.ImageUrl5);
                Assert.AreEqual(6, amazonItemAttributes.Height);
                Assert.AreEqual("TEST1", amazonItemAttributes.InvItemId);
                Assert.AreEqual("ItemName", amazonItemAttributes.ItemName);
                Assert.AreEqual(1, amazonItemAttributes.Length);
                Assert.AreEqual(2, amazonItemAttributes.Weight);
                Assert.AreEqual(3, amazonItemAttributes.Width);
                Assert.AreEqual("ModelName", amazonItemAttributes.ModelName);
                Assert.AreEqual(1.1000m, amazonItemAttributes.PackageHeight);
                Assert.AreEqual(1.2000m, amazonItemAttributes.PackageLength);
                Assert.AreEqual(1.3000m, amazonItemAttributes.PackageWeight);
                Assert.AreEqual(1.4000m, amazonItemAttributes.PackageWidth);
                Assert.AreEqual(3, amazonItemAttributes.PageCount);
                Assert.AreEqual("ProductCategory", amazonItemAttributes.ProductCategory);
                Assert.AreEqual("FullDescription", amazonItemAttributes.FullDescription);
                Assert.AreEqual("ProductSubcategory", amazonItemAttributes.ProductSubcategory);
                Assert.AreEqual("ManufacturerName", amazonItemAttributes.ManufacturerName);
                Assert.AreEqual(9.99m, amazonItemAttributes.Msrp);
                Assert.AreEqual("ecommercegenerickeywords", amazonItemAttributes.GenericKeywords);
                Assert.AreEqual("Size", amazonItemAttributes.Size);
                Assert.AreEqual("UpcOverride", amazonItemAttributes.UpcOverride);
            }
            #endregion // Assert

        }


        /// <summary>
        ///     Tests InsertEcommerceValues is properly inserting info into PS_AMAZON_ITEM_ATTRIBUTES
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertEnBomHeader_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1"
            };
            item.Description = "The Items Description for this test";

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertEnBomHeader(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                EnBomHeader enBomHeader = (from o in context.EnBomHeader select o).FirstOrDefault();

                Assert.AreEqual("TRUS1", enBomHeader.BusinessUnit);
                Assert.AreEqual("TEST1", enBomHeader.InvItemId);
                Assert.AreEqual("PR", enBomHeader.BomState);
                Assert.AreEqual("PR", enBomHeader.BomType);
                Assert.AreEqual(1, enBomHeader.BomCode);
                Assert.AreEqual(1, enBomHeader.BomQty);
                Assert.AreEqual("THE ITEMS DESCRIPTION FOR THI", enBomHeader.Descr);
                Assert.AreEqual("THE ITEMS", enBomHeader.Descrshort);
                Assert.AreEqual("", enBomHeader.Text254);
            }

            #endregion // Assert

        }

        /// <summary>
        ///     Tests InsertFxdBinLocInvAll is properly inserting info into PS_FXD_BIN_LOC_INV
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertFxdBinLocInvAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1",
                ItemGroup = "POSTER",
                ItemFamily = "FLAT"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertFxdBinLocInvAll(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<FxdBinLocInv> fxdBinLocInv = (from o in context.FxdBinLocInv select o).ToList();

                Assert.AreEqual("TRCN1", fxdBinLocInv[0].BusinessUnit);
                Assert.AreEqual("TEST1", fxdBinLocInv[0].InvItemId = item.ItemId);
                Assert.AreEqual(1, fxdBinLocInv[0].PickingOrder);
                Assert.AreEqual(0, fxdBinLocInv[0].QtyOptimal);
                Assert.AreEqual("PICK", fxdBinLocInv[0].StorageArea);
                Assert.AreEqual("10", fxdBinLocInv[0].StorLevel1);
                Assert.AreEqual("0", fxdBinLocInv[0].StorLevel2);
                Assert.AreEqual("", fxdBinLocInv[0].StorLevel3);
                Assert.AreEqual("", fxdBinLocInv[0].StorLevel4);
                Assert.AreEqual("EA", fxdBinLocInv[0].UnitOfMeasure);
                Assert.AreEqual("TRUS1", fxdBinLocInv[1].BusinessUnit);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertInvItems is properly inserting info into PS_INV_ITEMS
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertInvItems_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1",
                TariffCode = "TariffCode",
                Description = "Description",
                Height = "11.1",
                Length = "12.1",
                Weight = "13.1",
                Width = "14.1",
                Upc = "UPC",
                Color = "RED"
            };
            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertInvItems(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                InvItems invItems = (from o in context.InvItems select o).FirstOrDefault();

                Assert.AreEqual(0, invItems.AvailLeadTime); // 0
                Assert.AreEqual("", invItems.AvailStatus); // ""
                Assert.AreEqual("", invItems.ChargeCode); // ""
                Assert.AreEqual(0, invItems.ChargeMarkupAmt); // 0
                Assert.AreEqual(0, invItems.ChargeMarkupPcnt); // 0
                Assert.AreEqual("", invItems.CommodityCd); // ""
                Assert.AreEqual("", invItems.CommodityCdEu); // ""
                Assert.AreEqual("N", invItems.ConsumableFlg); // "N"
                Assert.AreEqual("", invItems.CurrencyCd); // ""
                Assert.AreEqual("DESCRIPTION", invItems.Descr254); // item.Description.ToUpper()
                Assert.AreEqual("N", invItems.DisposableFlag); // "N"
                Assert.AreEqual("TariffCode", invItems.HarmonizedCd); // item.TariffCode
                Assert.AreEqual("", invItems.HazClassCd); // ""
                Assert.AreEqual("", invItems.IntlHazardId); // ""
                Assert.AreEqual("RED", invItems.InvItemColor); // item.Color
                Assert.AreEqual(11.1m, invItems.InvItemHeight); // Convert.ToDecimal(item.Height)
                Assert.AreEqual("TEST1", invItems.InvItemId); // item.ItemId
                Assert.AreEqual(12.1m, invItems.InvItemLength); // Convert.ToDecimal(item.Length)
                Assert.AreEqual("", invItems.InvItemSize); // ""
                Assert.AreEqual("", invItems.InvItemTemplate); // ""
                Assert.AreEqual("", invItems.InvItemType); // ""
                Assert.AreEqual(0, invItems.InvItemVolume); // 0
                Assert.AreEqual(13.1m, invItems.InvItemWeight); // Convert.ToDecimal(item.Weight)
                Assert.AreEqual(14.1m, invItems.InvItemWidth); // Convert.ToDecimal(item.Width)
                Assert.AreEqual("", invItems.InvProdGrade); // ""
                Assert.AreEqual("", invItems.InvStockType); // ""
                Assert.AreEqual("BLEDBETTER", invItems.LastMaintOprid); // GlobalData.UserName
                Assert.AreEqual(0, invItems.MaxCapacity); // 0
                Assert.AreEqual("", invItems.MsdsId); // ""
                Assert.AreEqual("", invItems.PackingCd); // ""
                Assert.AreEqual("", invItems.PotencyRating); // ""
                Assert.AreEqual(0, invItems.RecomHumidityPct); // 0
                Assert.AreEqual(0, invItems.RecomStorTemp); // 0
                Assert.AreEqual("N", invItems.RecycleFlag); // "N"
                Assert.AreEqual(0, invItems.RetestLeadTime); // 0
                Assert.AreEqual("N", invItems.ReturnableFlg); // "N"
                Assert.AreEqual("N", invItems.ReusableFlag); // "N"
                Assert.AreEqual(0, invItems.ServiceExchAmt); // 0
                Assert.AreEqual(0, invItems.ServicePrice); // 0
                Assert.AreEqual("N", invItems.ServiceableFlg); // "N"
                Assert.AreEqual("SHARE", invItems.Setid); // "SHARE"
                Assert.AreEqual(0, invItems.ShelfLife); // 0
                Assert.AreEqual("", invItems.ShipTypeId); // ""
                Assert.AreEqual("", invItems.StorRulesId); // ""
                Assert.AreEqual("IN", invItems.UnitMeasureDim); // "IN"
                Assert.AreEqual("", invItems.UnitMeasureTemp); // ""
                Assert.AreEqual("", invItems.UnitMeasureVol); // ""
                Assert.AreEqual("LB", invItems.UnitMeasureWt); // "LB"
                Assert.AreEqual("UPC", invItems.UpcId);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertInvItemUom is properly inserting info into PS_INV_ITEM_UOM
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertInvItemUom_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1"
            };
            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertInvItemUom(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                InvItemUom invItemUom = (from o in context.InvItemUom select o).FirstOrDefault();
                
                Assert.AreEqual("SHARE", invItemUom.Setid);
                Assert.AreEqual("TEST1", invItemUom.InvItemId);
                Assert.AreEqual("EA", invItemUom.UnitOfMeasure);
                Assert.AreEqual(1, invItemUom.ConversionRate);
                Assert.AreEqual("W", invItemUom.QtyPrecision);
                Assert.AreEqual("N",invItemUom.RoundRule);
                Assert.AreEqual("Y", invItemUom.DfltUomStock);
                Assert.AreEqual("BLEDBETTER",invItemUom.LastMaintOprid);
                Assert.AreEqual(0,invItemUom.PackingWeight);
                Assert.AreEqual(0, invItemUom.PackingVolume);
                Assert.AreEqual(0, invItemUom.ShippingWeight);
                Assert.AreEqual(0, invItemUom.ShippingVolume);
                Assert.AreEqual("", invItemUom.UnitMeasureWt);
                Assert.AreEqual("", invItemUom.UnitMeasureVol);
                Assert.AreEqual("", invItemUom.PackingCd);
                Assert.AreEqual("", invItemUom.PackagingCd);
                Assert.AreEqual("", invItemUom.ContainerType);
            }
            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertItemAttribEx is properly inserting info into PS_ITEM_ATTRIB_EX
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertItemAttribEx_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1",
                CasepackHeight = "1.1",
                CasepackLength = "1.2",
                CasepackQty = "4",
                CasepackUpc = "UPC",
                CasepackWidth = "1.3",
                CasepackWeight = "1.4",
                DirectImport = "Y",
                // Duty = Duty,
                InnerpackHeight = "2.1",
                InnerpackLength = "2.2",
                InnerpackQuantity = "2",
                InnerpackUpc = "UPC2",
                InnerpackWeight = "2.3",
                InnerpackWidth = "2.4",
                LicenseBeginDate = "4/17/2014",
                ProductFormat = "ProductFormat",
                ProductGroup = "ProductGroup",
                ProductLine = "ProductLine",
                SatCode = "SatCode",
                SellOnTrends = "Y",
                PrintOnDemand = "N",
                // TranslateEdiProd = ReturnTranslateEdiProd(),
                ImagePath = "ImagePath",
                AltImageFile1 = "AltImageFile1",
                AltImageFile2 = "AltImageFile2",
                AltImageFile3 = "AltImageFile3",
                AltImageFile4 = "AltImageFile4"
                };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertItemAttribEx(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                ItemAttribEx itemAttribEx = (from o in context.ItemAttribEx select o).FirstOrDefault();
                
                Assert.AreEqual(1.1m, itemAttribEx.CasepackHeight);
                Assert.AreEqual(1.2m, itemAttribEx.CasepackLength);
                Assert.AreEqual(4, itemAttribEx.CasepackQty);
                Assert.AreEqual("UPC", itemAttribEx.CasepackUpc);
                Assert.AreEqual(1.3m, itemAttribEx.CasepackWidth);
                Assert.AreEqual(1.4m, itemAttribEx.CasepackWeight);
                Assert.AreEqual("Y", itemAttribEx.DirectImport);
                Assert.AreEqual("", itemAttribEx.Gtin);
                Assert.AreEqual(2.1m, itemAttribEx.InnerpackHeight);
                Assert.AreEqual(2.2m, itemAttribEx.InnerpackLength);
                Assert.AreEqual(2, itemAttribEx.InnerpackQty);
                Assert.AreEqual("UPC2", itemAttribEx.InnerpackUpc);
                Assert.AreEqual(2.3m, itemAttribEx.InnerpackWeight);
                Assert.AreEqual(2.4m, itemAttribEx.InnerpackWidth);
                Assert.AreEqual("TEST1", itemAttribEx.InvItemId);
                Assert.AreEqual("", itemAttribEx.BoxItemGroup);
                Assert.AreEqual("4/17/2014 12:00:00 AM", Convert.ToString(itemAttribEx.LicenseBeginDate));
                Assert.AreEqual("ProductFormat",itemAttribEx.ProdFormat);
                Assert.AreEqual("ProductGroup", itemAttribEx.ProdGroup);
                Assert.AreEqual("ProductLine", itemAttribEx.ProdLine);
                Assert.AreEqual("SatCode", itemAttribEx.SatCode);
                Assert.AreEqual("SHARE",itemAttribEx.Setid);
                Assert.AreEqual("Y", itemAttribEx.SellOnWeb);
                Assert.AreEqual("N", itemAttribEx.PrintOnDemand);
                // Assert.AreEqual(itemAttribEx.TranslateEdiProd = itemAttribEx.ReturnTranslateEdiProd());
                Assert.AreEqual("ImagePath", itemAttribEx.ImageFileName);
                Assert.AreEqual("AltImageFile1", itemAttribEx.AltImageFile1);
                Assert.AreEqual("AltImageFile2", itemAttribEx.AltImageFile2);
                Assert.AreEqual("AltImageFile3", itemAttribEx.AltImageFile3);
                Assert.AreEqual("AltImageFile4", itemAttribEx.AltImageFile4);
            }
            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertItemCompliance is properly inserting info into PS_ITEM_COMPLIANCE
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertItemCompliance_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1"
            };
            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertItemCompliance(item, context);
                context.SaveChanges();
            }

            #endregion // Act

            #region Assert
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                ItemCompliance itemCompliance = (from o in context.ItemCompliance select o).FirstOrDefault();
                
                Assert.AreEqual("TEST1", itemCompliance.InvItemId);
                Assert.AreEqual("N", itemCompliance.Prop65Compliant);
                Assert.AreEqual("SHARE", itemCompliance.Setid);
            }
            #endregion // Assert
        }

        /// <summary>
        ///     Tests that proper values are being inserted into the database and being returned properly
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertItemInfo_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());

            GlobalData.ClearValues();
            GlobalData.ItemCategories.Add("1", "ItemCategory1");

            GlobalData.WebCategoryList.Add("1", "Category1");
            GlobalData.WebCategoryList.Add("2", "Category2");
            GlobalData.WebCategoryList.Add("3", "Category3");

            GlobalData.CustomerIdConversions.Add("ALL POSTERS", "000000000020536");
            GlobalData.CustomerIdConversions.Add("AMAZON", "000000000125480");
            GlobalData.CustomerIdConversions.Add("AMAZON SELLER CENTRAL", "000000000145518");
            GlobalData.CustomerIdConversions.Add("FANATICS", "000000000125904");
            GlobalData.CustomerIdConversions.Add("HAYNEEDLE", "000000000126605");
            GlobalData.CustomerIdConversions.Add("HOUZZ", "000000000146472");
            GlobalData.CustomerIdConversions.Add("TARGET", "000000000064965");
            GlobalData.CustomerIdConversions.Add("WALMART", "000000000125921");
            GlobalData.CustomerIdConversions.Add("WAYFAIR", "000000000130446");
            GlobalData.CustomerIdConversions.Add("GUITAR CENTER", "000000000145389");
            GlobalData.CustomerIdConversions.Add("SHOP TRENDS", "000000000146515");
            GlobalData.CustomerIdConversions.Add("TRS", "000000000146515");
            GlobalData.ItemIdSuffixes.Add("DI");

            List<ChildElement> billOfMaterials = new List<ChildElement>() {
                new ChildElement("ST1111", "TestItem2", 1),
                new ChildElement("ST2222", "TestItem2", 2)
            };

            List<ChildElement> PID = new List<ChildElement>() {
                new ChildElement("ST1111", "TestItem2", 5),
                new ChildElement("ST2222", "TestItem2", 1)
            };

            ItemObject item = new ItemObject(1) {
                AltImageFile1 = "\\\\isiloncifs\\Store 2\\•CAPTURES\\Poster Captures\\3000\\3400\\3403_BRETT FAVRE.TIFF",
                AltImageFile2 = "\\\\isiloncifs\\Store 2\\•CAPTURES\\Poster Captures\\3000\\3400\\3403_BRETT FAVRE.TIFF",
                AltImageFile3 = "\\\\isiloncifs\\Store 2\\•CAPTURES\\Poster Captures\\3000\\3400\\3403_BRETT FAVRE.TIFF",
                AltImageFile4 = "\\\\isiloncifs\\Store 2\\•CAPTURES\\Poster Captures\\3000\\3400\\3403_BRETT FAVRE.TIFF",
                SellOnAllPosters = "Y",
                SellOnAmazon = "Y",
                SellOnAmazonSellerCentral = "Y",
                SellOnFanatics = "N",
                SellOnGuitarCenter = "N",
                SellOnHayneedle = "Y",
                SellOnHouzz = "N",
                SellOnTarget = "N",
                SellOnTrends = "N",
                SellOnTrs = "N",
                SellOnWalmart = "N",
                SellOnWayfair = "N",
                EcommerceAsin = "ASIN",
                EcommerceBullet1 = "Bullet1",
                EcommerceBullet2 = "Bullet2",
                EcommerceBullet3 = "Bullet3",
                EcommerceBullet4 = "Bullet4",
                EcommerceBullet5 = "Bullet5",
                EcommerceComponents = "Components",
                EcommerceCost = "5.99",
                EcommerceExternalId = "000000000000",
                EcommerceExternalIdType = "UPC",
                EcommerceImagePath1 = "http://trendsinternational.com/media/catalog/product/I/m/ImagePath1.jpg",
                EcommerceImagePath2 = "http://trendsinternational.com/media/catalog/product/I/m/ImagePath2.jpg",
                EcommerceImagePath3 = "http://trendsinternational.com/media/catalog/product/I/m/ImagePath3.jpg",
                EcommerceImagePath4 = "http://trendsinternational.com/media/catalog/product/I/m/ImagePath4.jpg",
                EcommerceImagePath5 = "http://trendsinternational.com/media/catalog/product/I/m/ImagePath5.jpg",
                EcommerceItemHeight = "6",
                EcommerceItemLength = "7",
                EcommerceItemName = "ItemName",
                EcommerceItemTypeKeywords = "EcommerceItemTypeKeywords",
                EcommerceItemWeight = "8",
                EcommerceItemWidth = "9",
                EcommerceModelName = "Model Name",
                EcommercePackageHeight = "5",
                EcommercePackageLength = "4",
                EcommercePackageWeight = "3",
                EcommercePackageWidth = "2",
                EcommercePageQty = "5",
                EcommerceParentAsin = "5qwercven",
                EcommerceProductCategory = "ProductCategory",
                EcommerceProductDescription = "ProductDescription",
                EcommerceProductSubcategory = "ProductSubcategory",
                EcommerceManufacturerName = "ManufacturerName",
                EcommerceMsrp = "1.99",
                EcommerceGenericKeywords = "EcommerceGenericKeywords",
                EcommerceSubjectKeywords = "EcommerceSubjectKeywords",
                EcommerceSize = "Size",
                EcommerceUpc = "UPC",
                AccountingGroup = "ACCOUNTING",
                BillOfMaterials = billOfMaterials,
                CasepackHeight = "1.",
                CasepackLength = "2.0",
                CasepackQty = "5",
                CasepackUpc = "999999999999",
                CasepackWidth = "77.0",
                CasepackWeight = "34.0",
                Category = "Category1",
                Category2 = "Category2",
                Category3 = "Category3",
                Color = "Color",
                Copyright = "Copyright",
                CountryOfOrigin = "COO",
                CostProfileGroup = "CPG",
                DefaultActualCostUsd = "4.99",
                DefaultActualCostCad = "8",
                Description = "Description",
                DirectImport = "N",
                Duty = "Duty",
                Ean = "EAN",
                Gpc = "GPC",
                Height = "2",
                ImagePath = "ImagePath",
                InnerpackHeight = "8.7",
                InnerpackLength = "9.7",
                InnerpackQuantity = "90",
                InnerpackUpc = "77777777",
                InnerpackWidth = "14",
                InnerpackWeight = "52",
                InStockDate = "",
                Isbn = "I",
                ItemCategory = "ItemCategory1",
                ItemFamily = "F",
                ItemGroup = "G",
                ItemId = "TestItem2",
                ItemKeywords = "Item Keywords",
                Language = "ENG",
                Length = "91",
                License = "License",
                LicenseBeginDate = "",
                ListPriceCad = "7.77",
                ListPriceMxn = "7.88",
                ListPriceUsd = "7.99",
                MetaDescription = "MetaDescription",
                MfgSource = "MF",
                Msrp = "7.77",
                MsrpCad = "19.99",
                MsrpMxn = "9.99",
                ProductFormat = "ProdF",
                ProductGroup = "ProdG",
                ProductIdTranslation = PID,
                ProductLine = "ProdL",
                ProductQty = "9",
                Property = "Property",
                PricingGroup = "PRICING GR",
                PrintOnDemand = "Y",
                PsStatus = "A",
                SatCode = "SatCode",
                ShortDescription = "Short Description",
                Size = "Size",
                StandardCost = "5",
                StatsCode = "statsCode",
                Status = "Add",
                TariffCode = "TC",
                Territory = "USA",
                Title = "Title",
                Udex = "UD",
                Upc = "000000000000",
                Weight = "2",
                Width = "1"
            };
            item.ResetUpdate();

            #endregion // Assemble

            #region Act

            itemRepository.InsertAll(item,1);
            ItemObject newItem = itemRepository.RetrieveItem("TestItem2", 1);

            #endregion // Act

            #region Assert
            
            Assert.AreEqual("Y", newItem.SellOnAllPosters);
            Assert.AreEqual("Y", newItem.SellOnAmazon);
            Assert.AreEqual("Y", newItem.SellOnAmazonSellerCentral);
            Assert.AreEqual("N", newItem.SellOnFanatics);
            Assert.AreEqual("N", newItem.SellOnGuitarCenter);
            Assert.AreEqual("Y", newItem.SellOnHayneedle);
            Assert.AreEqual("N", newItem.SellOnHouzz);
            Assert.AreEqual("N", newItem.SellOnTarget);
            Assert.AreEqual("N", newItem.SellOnTrs);
            Assert.AreEqual("N", newItem.SellOnWalmart);
            Assert.AreEqual("N", newItem.SellOnWayfair);
            Assert.AreEqual("N", newItem.SellOnTrends);
            Assert.AreEqual("ASIN", newItem.EcommerceAsin);
            Assert.AreEqual("Bullet1", newItem.EcommerceBullet1);
            Assert.AreEqual("Bullet2", newItem.EcommerceBullet2);
            Assert.AreEqual("Bullet3", newItem.EcommerceBullet3);
            Assert.AreEqual("Bullet4", newItem.EcommerceBullet4);
            Assert.AreEqual("Bullet5", newItem.EcommerceBullet5);
            Assert.AreEqual("Components", newItem.EcommerceComponents);
            Assert.AreEqual("5.99", newItem.EcommerceCost);
            Assert.AreEqual("000000000000", newItem.EcommerceExternalId);
            Assert.AreEqual("UPC", newItem.EcommerceExternalIdType);
            Assert.AreEqual("ImagePath", newItem.EcommerceImagePath1);
            Assert.AreEqual("http://trendsinternational.com/media/catalog/product/I/m/ImagePath2.jpg", newItem.EcommerceImagePath2);
            Assert.AreEqual("http://trendsinternational.com/media/catalog/product/I/m/ImagePath3.jpg", newItem.EcommerceImagePath3);
            Assert.AreEqual("http://trendsinternational.com/media/catalog/product/I/m/ImagePath4.jpg", newItem.EcommerceImagePath4);
            Assert.AreEqual("http://trendsinternational.com/media/catalog/product/I/m/ImagePath5.jpg", newItem.EcommerceImagePath5);
            Assert.AreEqual("6.0", newItem.EcommerceItemHeight);
            Assert.AreEqual("7.0", newItem.EcommerceItemLength);
            Assert.AreEqual("ItemName", newItem.EcommerceItemName);
            Assert.AreEqual("EcommerceItemTypeKeywords", newItem.EcommerceItemTypeKeywords);
            Assert.AreEqual("8.0", newItem.EcommerceItemWeight);
            Assert.AreEqual("9.0", newItem.EcommerceItemWidth);
            Assert.AreEqual("Model Name", newItem.EcommerceModelName);
            Assert.AreEqual("5.0", newItem.EcommercePackageHeight);
            Assert.AreEqual("4.0", newItem.EcommercePackageLength);
            Assert.AreEqual("3.0", newItem.EcommercePackageWeight);
            Assert.AreEqual("2.0", newItem.EcommercePackageWidth);
            Assert.AreEqual("5", newItem.EcommercePageQty);
            Assert.AreEqual("ProductCategory", newItem.EcommerceProductCategory);
            Assert.AreEqual("ProductDescription", newItem.EcommerceProductDescription);
            Assert.AreEqual("ProductSubcategory", newItem.EcommerceProductSubcategory);
            Assert.AreEqual("ManufacturerName", newItem.EcommerceManufacturerName);
            Assert.AreEqual("1.99", newItem.EcommerceMsrp);
            Assert.AreEqual("ecommercegenerickeywords", newItem.EcommerceGenericKeywords);
            Assert.AreEqual("ecommercesubjectkeywords", newItem.EcommerceSubjectKeywords);
            Assert.AreEqual("Size", newItem.EcommerceSize);
            Assert.AreEqual("UPC", newItem.EcommerceUpc);
            Assert.AreEqual("ACCOUNTING", newItem.AccountingGroup);
            Assert.AreEqual("ST1111, ST2222 (2)", newItem.ReturnBillOfMaterials());
            Assert.AreEqual("1.0", newItem.CasepackHeight);
            Assert.AreEqual("2.0", newItem.CasepackLength);
            Assert.AreEqual("5", newItem.CasepackQty);
            Assert.AreEqual("999999999999", newItem.CasepackUpc);
            Assert.AreEqual("77.0", newItem.CasepackWidth);
            Assert.AreEqual("34.0", newItem.CasepackWeight);
            Assert.AreEqual("Category1", newItem.Category);
            Assert.AreEqual("Category2", newItem.Category2);
            Assert.AreEqual("Category3", newItem.Category3);
            Assert.AreEqual("Color", newItem.Color);
            Assert.AreEqual("Copyright", newItem.Copyright);
            Assert.AreEqual("COO", newItem.CountryOfOrigin);
            Assert.AreEqual("CPG", newItem.CostProfileGroup);
            Assert.AreEqual("4.99", newItem.DefaultActualCostUsd);
            Assert.AreEqual("8.00", newItem.DefaultActualCostCad);
            Assert.AreEqual("DESCRIPTION", newItem.Description);
            Assert.AreEqual("N", newItem.DirectImport);
            Assert.AreEqual("EAN", newItem.Ean);
            Assert.AreEqual("GPC", newItem.Gpc);
            Assert.AreEqual("2.0", newItem.Height);
            Assert.AreEqual("8.7", newItem.InnerpackHeight);
            Assert.AreEqual("9.7", newItem.InnerpackLength);
            Assert.AreEqual("90", newItem.InnerpackQuantity);
            Assert.AreEqual("77777777", newItem.InnerpackUpc);
            Assert.AreEqual("14.0", newItem.InnerpackWidth);
            Assert.AreEqual("52.0", newItem.InnerpackWeight);
            // Assert.AreEqual("", newItem.InStockDate);
            Assert.AreEqual("I", newItem.Isbn);
            Assert.AreEqual("ItemCategory1", newItem.ItemCategory);
            Assert.AreEqual("F", newItem.ItemFamily);
            Assert.AreEqual("G", newItem.ItemGroup);
            Assert.AreEqual("TestItem2", newItem.ItemId);
            Assert.AreEqual("Item Keywords", newItem.ItemKeywords);
            Assert.AreEqual("ENG", newItem.Language);
            Assert.AreEqual("91.0", newItem.Length);
            Assert.AreEqual("License", newItem.License);
            // Assert.AreEqual("", newItem.LicenseBeginDate);
            Assert.AreEqual("7.77", newItem.ListPriceCad);
            Assert.AreEqual("7.88", newItem.ListPriceMxn);
            Assert.AreEqual("7.99", newItem.ListPriceUsd);
            Assert.AreEqual("MetaDescription", newItem.MetaDescription);
            Assert.AreEqual("MF", newItem.MfgSource);
            Assert.AreEqual("7.77", newItem.Msrp);
            Assert.AreEqual("19.99", newItem.MsrpCad);
            Assert.AreEqual("9.99", newItem.MsrpMxn);
            Assert.AreEqual("ProdF", newItem.ProductFormat);
            Assert.AreEqual("ProdG", newItem.ProductGroup);
            Assert.AreEqual("ST1111 (5), ST2222", newItem.ReturnProductIdTranslations());
            Assert.AreEqual("ProdL", newItem.ProductLine);
            Assert.AreEqual("9", newItem.ProductQty);
            Assert.AreEqual("Property", newItem.Property);
            Assert.AreEqual("PRICING GR", newItem.PricingGroup);
            Assert.AreEqual("Y", newItem.PrintOnDemand);
            Assert.AreEqual("A", newItem.PsStatus);
            Assert.AreEqual("SatCode", newItem.SatCode);
            Assert.AreEqual("Short Description", newItem.ShortDescription);
            Assert.AreEqual("Size", newItem.Size);
            Assert.AreEqual("5.00000", newItem.StandardCost);
            Assert.AreEqual("statsCode", newItem.StatsCode);
            Assert.AreEqual("TC", newItem.TariffCode);
            Assert.AreEqual("USA", newItem.Territory);
            Assert.AreEqual("Title", newItem.Title);
            Assert.AreEqual("UD", newItem.Udex);
            Assert.AreEqual("000000000000", newItem.Upc);
            Assert.AreEqual("2.0", newItem.Weight);
            Assert.AreEqual("1.0", newItem.Width);
            Assert.AreEqual("\\\\isiloncifs\\Store 2\\•CAPTURES\\Poster Captures\\3000\\3400\\3403_BRETT FAVRE.TIFF", newItem.AltImageFile1);
            Assert.AreEqual("\\\\isiloncifs\\Store 2\\•CAPTURES\\Poster Captures\\3000\\3400\\3403_BRETT FAVRE.TIFF", newItem.AltImageFile2);
            Assert.AreEqual("\\\\isiloncifs\\Store 2\\•CAPTURES\\Poster Captures\\3000\\3400\\3403_BRETT FAVRE.TIFF", newItem.AltImageFile3);
            Assert.AreEqual("\\\\isiloncifs\\Store 2\\•CAPTURES\\Poster Captures\\3000\\3400\\3403_BRETT FAVRE.TIFF", newItem.AltImageFile4);

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertItemLanguageAll is properly inserting info into PS_ITEM_LANGUAGE
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertItemLanguageAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                Language = "ENG/FRA/SPA"
            };
            #endregion // Assemble

            #region Act

            itemRepository.InsertItemLanguageAll(item);

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<ItemLanguage> itemLanguage = (from o in context.ItemLanguage select o).ToList();

                Assert.AreEqual("TEST1", itemLanguage[0].InvItemId);
                Assert.AreEqual("SHARE", itemLanguage[0].Setid);
                Assert.AreEqual("ENG", itemLanguage[0].LanguageCd);
                Assert.AreEqual("FRA", itemLanguage[1].LanguageCd);
                Assert.AreEqual("SPA", itemLanguage[2].LanguageCd);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertItemTerritoryAll is properly inserting info into PS_ITEM_TERRITORY
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertItemTerritoryAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1",
                Territory = "USA/CAN/MEX"
            };
            #endregion // Assemble

            #region Act

            itemRepository.InsertItemTerritoryAll(item);

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<ItemTerritory> itemTerritory = (from o in context.ItemTerritory select o).ToList();

                Assert.AreEqual("TEST1", itemTerritory[0].InvItemId);
                Assert.AreEqual("SHARE", itemTerritory[0].Setid);
                Assert.AreEqual("CAN", itemTerritory[0].Territory);
                Assert.AreEqual("MEX", itemTerritory[1].Territory);
                Assert.AreEqual("USA", itemTerritory[2].Territory);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertItemWebInfo is properly inserting info into PS_ITEM_WEB_INFO
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertItemWebInfo_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            GlobalData.ClearValues();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            GlobalData.WebCategoryList.Add("1", "Category1");
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                Active = 1,
                Category = "Category1",
                Copyright = "Copyright",
                ImagePath = "ImagePath",
                InStockDate = "1900-01-01",
                ItemKeywords = "ItemKeywords",
                License = "License",
                MetaDescription = "MetaDescription",
                ProductQty = "4",
                Property = "Property",
                ShortDescription = "ShortDesc",
                Size = "Size",
                Title = "Title"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertItemWebInfo(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                ItemWebInfo itemWebInfo = (from o in context.ItemWebInfo select o).FirstOrDefault();

                Assert.AreEqual(1m, itemWebInfo.Active);  //item.Active,
                Assert.AreEqual("", itemWebInfo.AttributeSet);  //"",
                Assert.AreEqual("1", itemWebInfo.Category);  //item.CombinedCategories,
                Assert.AreEqual("Copyright", itemWebInfo.Copyright);  //item.Copyright,
                Assert.AreEqual("ImagePath", itemWebInfo.ImagePath);  //item.ImagePath,
                // Assert.AreEqual("1900-01-01", itemWebInfo.InStockDate);  //Convert.ToDateTime(inStockDate),
                Assert.AreEqual("TEST1", itemWebInfo.InvItemId);  //item.ItemId,
                Assert.AreEqual("ItemKeywords", itemWebInfo.ItemKeywords);  //item.ItemKeywords,
                Assert.AreEqual("License", itemWebInfo.License);  //item.License,
                Assert.AreEqual("MetaDescription", itemWebInfo.MetaDescription);  //item.MetaDescription,
                Assert.AreEqual("0", itemWebInfo.Msrp);  //"0",
                Assert.AreEqual("", itemWebInfo.Newcategory);  //"",
                Assert.AreEqual("", itemWebInfo.NewDate);  //"",
                Assert.AreEqual("N", itemWebInfo.OnSite);  //"N",
                Assert.AreEqual("4", itemWebInfo.ProdQty);  //item.ProductQty,
                Assert.AreEqual("Property", itemWebInfo.Property);  //item.Property,
                Assert.AreEqual("ShortDesc", itemWebInfo.ShortDesc);  //item.ShortDescription,
                Assert.AreEqual("Size", itemWebInfo.Size);  //item.Size,
                Assert.AreEqual("Title", itemWebInfo.Title);  //item.Title
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertItemUpdateRecord is properly inserting info into ODIN_ITEM_UPDATE_RECORD
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertItemUpdateRecord_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            GlobalData.ClearValues();
            GlobalData.WebCategoryList.Add("1", "Category1");
            GlobalData.WebCategoryList.Add("2", "Category2");
            GlobalData.WebCategoryList.Add("3", "Category3");
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1) { 
                ItemId = "TEST1",
                Status = "Add",
                EcommerceAsin = "Asin",
                EcommerceBullet1 = "EcommerceBullet1",
                EcommerceBullet2 = "EcommerceBullet2",
                EcommerceBullet3 = "EcommerceBullet3",
                EcommerceBullet4 = "EcommerceBullet4",
                EcommerceBullet5 = "EcommerceBullet5",
                EcommerceComponents = "EcommerceComponents",
                EcommerceCost = "E-Cost",
                EcommerceExternalIdType = "ExIdType",
                EcommerceExternalId = "ExternalId",
                EcommerceItemHeight = "ItemHeight",
                EcommerceItemLength = "ItemLength",
                EcommerceItemName = "EcommerceItemName",
                EcommerceItemTypeKeywords = "EcommerceItemTypeKeywords",
                EcommerceItemWeight = "ItemWeight",
                EcommerceItemWidth = "ItemWidth",
                EcommerceManufacturerName = "EcommerceManufacturerName",
                EcommerceModelName = "EcommerceModelName",
                EcommerceMsrp = "msrp",
                EcommercePackageLength = "3.1",
                EcommercePackageHeight = "3.2",
                EcommercePackageWeight = "3.3",
                EcommercePackageWidth = "3.4",
                EcommercePageQty = "PQty",
                EcommerceProductCategory = "EcommerceProductCategory",
                EcommerceProductDescription = "EcommerceProductDescription",
                EcommerceProductSubcategory = "EcommerceProductSubcategory",
                EcommerceGenericKeywords = "EcommerceGenericKeywords",
                EcommerceSize = "EcommerceSize",
                EcommerceUpc = "EUpc",
                AccountingGroup = "AGroup",
                AltImageFile1 = "ImagePath2",
                AltImageFile2 = "ImagePath3",
                AltImageFile3 = "ImagePath4",
                AltImageFile4 = "ImagePath5",
                BillOfMaterials = new List<ChildElement>(),
                CasepackHeight = "2.1",
                CasepackLength = "2.2",
                CasepackQty = "2",
                CasepackUpc = "2222",
                CasepackWidth = "2.3",
                CasepackWeight = "2.4",
                Category = "Category",
                Category2 = "Category2",
                Category3 = "Category3",
                Color = "Color",
                Copyright = "Copyright",
                CountryOfOrigin = "COO",
                CostProfileGroup = "CPG",
                DefaultActualCostUsd = "dacusd",
                DefaultActualCostCad = "daccad",
                Description = "Description",
                DirectImport = "N",
                Duty = "Duty",
                Ean = "Ean",
                Gpc = "Gpc",
                Height = "Height",
                ImagePath = "ImagePath",
                InnerpackHeight = "1.1",
                InnerpackLength = "1.2",
                InnerpackQuantity = "1",
                InnerpackUpc = "1111",
                InnerpackWidth = "1.3",
                InnerpackWeight = "1.4",
                InStockDate = "InStockDate",
                Isbn = "Isbn",
                ItemCategory = "ItemCategory",
                ItemFamily = "ItemF",
                ItemGroup = "ItemGroup",
                ItemKeywords = "ItemKeywords",
                Language = "Language",
                Length = "Length",
                License = "License",
                LicenseBeginDate = "LicenseBeginDate",
                ListPriceCad = "1.99",
                ListPriceUsd = "2.99",
                ListPriceMxn = "3.99",
                MetaDescription = "MetaDescription",
                MfgSource = "MS",
                Msrp = "11.99",
                MsrpCad = "12.99",
                MsrpMxn = "13.99",
                ProductFormat = "ProductFormat",
                ProductGroup = "ProductGroup",
                ProductIdTranslation = new List<ChildElement>(),
                ProductLine = "ProductLine",
                ProductQty = "ProductQty",
                PricingGroup = "PGroup",
                PrintOnDemand = "Y",
                PsStatus = "O",
                Property = "Property",
                SatCode = "SatCode",
                ShortDescription = "ShortDescription",
                SellOnAllPosters = "Y",
                SellOnAmazon = "Y",
                SellOnFanatics = "N",
                SellOnGuitarCenter = "N",
                SellOnHayneedle = "N",
                SellOnHouzz = "N",
                SellOnTarget = "N",
                SellOnTrends = "N",
                SellOnWalmart = "N",
                SellOnWayfair = "N",
                Size = "Size",
                StandardCost = "StandardCost",
                StatsCode = "StatsCode",
                TariffCode = "TariffCode",
                Territory = "Territory",
                Title = "Title",
                Udex = "Udex",
                Upc = "Upc",
                Weight = "Weight",
                Width = "Width"
            };
            item.ResetUpdate();

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {                
                itemRepository.InsertItemUpdateRecord(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {

                OdinItemUpdateRecords itemUpdateRecord = (from o in context.OdinItemUpdateRecords select o).FirstOrDefault();
                
                Assert.AreEqual("TEST1", itemUpdateRecord.InvItemId);  //item.ItemId
                Assert.AreEqual("Add", itemUpdateRecord.ItemInputStatus);  //item.Status
                Assert.AreEqual(GlobalData.UserName, itemUpdateRecord.Username);  // GlobalData.UserName
                Assert.AreEqual("AGroup", itemUpdateRecord.AccountingGroup);  //item.AccountingGroup
                Assert.AreEqual("2.1", itemUpdateRecord.CasepackHeight);  //item.CasepackHeight
                Assert.AreEqual("2.2", itemUpdateRecord.CasepackLength);  //item.CasepackLength
                Assert.AreEqual("2", itemUpdateRecord.CasepackQty);  //item.CasepackQty
                Assert.AreEqual("2222", itemUpdateRecord.CasepackUpc);  //item.CasepackUpc
                Assert.AreEqual("2.3", itemUpdateRecord.CasepackWidth);  //item.CasepackWidth
                Assert.AreEqual("2.4", itemUpdateRecord.CasepackWeight);  //item.CasepackWeight
                Assert.AreEqual("Category", itemUpdateRecord.Category);  //item.Category
                Assert.AreEqual("Category2", itemUpdateRecord.Category2);  //item.Category2
                Assert.AreEqual("Category3", itemUpdateRecord.Category3);  //item.Category3
                Assert.AreEqual("Color", itemUpdateRecord.Color);  //item.Color
                Assert.AreEqual("Copyright", itemUpdateRecord.Copyright);  //item.Copyright
                Assert.AreEqual("COO", itemUpdateRecord.CountryOfOrigin);  //item.CountryOfOrigin
                Assert.AreEqual("CPG", itemUpdateRecord.CostProfileGroup);  //item.CostProfileGroup
                Assert.AreEqual("dacusd", itemUpdateRecord.DefaultActualCostUsd);  //item.DefaultActualCostUsd
                Assert.AreEqual("daccad", itemUpdateRecord.DefaultActualCostCad);  //item.DefaultActualCostCad
                Assert.AreEqual("Description", itemUpdateRecord.Description);  //item.Description
                Assert.AreEqual("N", itemUpdateRecord.DirectImport);  //item.DirectImport
                Assert.AreEqual("Duty", itemUpdateRecord.Duty);  //item.Duty
                Assert.AreEqual("Ean", itemUpdateRecord.Ean);  //item.Ean
                Assert.AreEqual("Gpc", itemUpdateRecord.Gpc);  //item.Gpc
                Assert.AreEqual("Height", itemUpdateRecord.Height);  //item.Height
                Assert.AreEqual("ImagePath", itemUpdateRecord.ImagePath);  //item.ImagePath
                Assert.AreEqual("1.1", itemUpdateRecord.InnerpackHeight);  //item.InnerpackHeight
                Assert.AreEqual("1.2", itemUpdateRecord.InnerpackLength);  //item.InnerpackLength
                Assert.AreEqual("1", itemUpdateRecord.InnerpackQty);  //item.InnerpackQuantity
                Assert.AreEqual("1111", itemUpdateRecord.InnerpackUpc);  //item.InnerpackUpc
                Assert.AreEqual("1.3", itemUpdateRecord.InnerpackWidth);  //item.InnerpackWidth
                Assert.AreEqual("1.4", itemUpdateRecord.InnerpackWeight);  //item.InnerpackWeight
                // Assert.AreEqual("", itemUpdateRecord.InStockDate);  //item.InStockDate
                Assert.AreEqual("Isbn", itemUpdateRecord.Isbn);  //item.Isbn
                Assert.AreEqual("ItemCategory", itemUpdateRecord.ItemCategory);  //item.ItemCategory
                Assert.AreEqual("ItemF", itemUpdateRecord.ItemFamily);  //item.ItemFamily
                Assert.AreEqual("ItemGroup", itemUpdateRecord.ItemGroup);  //item.ItemGroup
                Assert.AreEqual("ItemKeywords", itemUpdateRecord.ItemKeywords);  //item.ItemKeywords
                Assert.AreEqual("Language", itemUpdateRecord.Language);  //item.Language
                Assert.AreEqual("Length", itemUpdateRecord.Length);  //item.Length
                Assert.AreEqual("License", itemUpdateRecord.License);  //item.License
                // Assert.AreEqual("LicenseBeginDate", itemUpdateRecord.LicenseBeginDate);  //item.LicenseBeginDate
                Assert.AreEqual("1.99", itemUpdateRecord.ListPriceCad);  //item.ListPriceCad
                Assert.AreEqual("2.99", itemUpdateRecord.ListPriceUsd);  //item.ListPriceUsd
                Assert.AreEqual("3.99", itemUpdateRecord.ListPriceMxn);  //item.ListPriceMxn
                Assert.AreEqual("MetaDescription", itemUpdateRecord.MetaDescription);  //item.MetaDescription
                Assert.AreEqual("MS", itemUpdateRecord.MfgSource);  //item.MfgSource
                Assert.AreEqual("11.99", itemUpdateRecord.Msrp);  //item.Msrp
                Assert.AreEqual("12.99", itemUpdateRecord.MsrpCad);  //item.MsrpCad
                Assert.AreEqual("13.99", itemUpdateRecord.MsrpMxn);  //item.MsrpMxn
                Assert.AreEqual("ProductFormat", itemUpdateRecord.ProductFormat);  //item.ProductFormat
                Assert.AreEqual("ProductGroup", itemUpdateRecord.ProductGroup);  //item.ProductGroup
                // Assert.AreEqual("", itemUpdateRecord.ProductIdTranslation);  //item.ReturnProductIdTranslations()
                Assert.AreEqual("ProductLine", itemUpdateRecord.ProductLine);  //item.ProductLine
                Assert.AreEqual("ProductQty", itemUpdateRecord.ProdQty);  //item.ProductQty
                Assert.AreEqual("PGroup", itemUpdateRecord.PricingGroup);  //item.PricingGroup
                Assert.AreEqual("Y", itemUpdateRecord.PrintOnDemand);  //item.PrintOnDemand
                Assert.AreEqual("O", itemUpdateRecord.PsStatus);  //item.PsStatus
                Assert.AreEqual("Property", itemUpdateRecord.Property);  //item.Property
                Assert.AreEqual("SatCode", itemUpdateRecord.SatCode);  //item.SatCode
                Assert.AreEqual("ShortDescription", itemUpdateRecord.ShortDesc);  //item.ShortDescription
                Assert.AreEqual("N", itemUpdateRecord.SellOnFanatics);  //item.SellOnFanatics
                Assert.AreEqual("N", itemUpdateRecord.SellOnGuitarCenter);  //item.SellOnGuitarCenter
                Assert.AreEqual("N", itemUpdateRecord.SellOnHayneedle);  //item.SellOnHayneedle
                Assert.AreEqual("N", itemUpdateRecord.SellOnHouzz);  //item.SellOnHouzz
                Assert.AreEqual("N", itemUpdateRecord.SellOnTarget);  //item.SellOnTarget
                Assert.AreEqual("N", itemUpdateRecord.SellOnWeb);  //item.SellOnTrends
                Assert.AreEqual("N", itemUpdateRecord.SellOnWalmart);  //item.SellOnWalmart
                Assert.AreEqual("N", itemUpdateRecord.SellOnWayfair);  //item.SellOnWayfair
                Assert.AreEqual("", itemUpdateRecord.SellOnJet);  //""
                Assert.AreEqual("Size", itemUpdateRecord.Size);  //item.Size
                Assert.AreEqual("StandardCost", itemUpdateRecord.StandardCost);  //item.StandardCost
                Assert.AreEqual("StatsCode", itemUpdateRecord.StatsCode);  //item.StatsCode
                Assert.AreEqual("TariffCode", itemUpdateRecord.TariffCode);  //item.TariffCode
                Assert.AreEqual("Territory", itemUpdateRecord.Territory);  //item.Territory
                Assert.AreEqual("Title", itemUpdateRecord.Title);  //item.Title
                Assert.AreEqual("Udex", itemUpdateRecord.Udex);  //item.Udex
                Assert.AreEqual("Upc", itemUpdateRecord.Upc);  //item.Upc
                Assert.AreEqual("Weight", itemUpdateRecord.Weight);  //item.Weight
                Assert.AreEqual("Width", itemUpdateRecord.Width);  //item.Width
                Assert.AreEqual("Y", itemUpdateRecord.AAmazonActive);  //item.SellOnAmazon
                Assert.AreEqual("Asin", itemUpdateRecord.AAsin);  //item.EcommerceAsin
                Assert.AreEqual("EcommerceBullet1", itemUpdateRecord.ABullet1);  //item.EcommerceBullet1
                Assert.AreEqual("EcommerceBullet2", itemUpdateRecord.ABullet2);  //item.EcommerceBullet2
                Assert.AreEqual("EcommerceBullet3", itemUpdateRecord.ABullet3);  //item.EcommerceBullet3
                Assert.AreEqual("EcommerceBullet4", itemUpdateRecord.ABullet4);  //item.EcommerceBullet4
                Assert.AreEqual("EcommerceBullet5", itemUpdateRecord.ABullet5);  //item.EcommerceBullet5
                Assert.AreEqual("EcommerceComponents", itemUpdateRecord.AComponents);  //item.EcommerceComponents
                Assert.AreEqual("E-Cost", itemUpdateRecord.ACost);  //item.EcommerceCost
                Assert.AreEqual("ExIdType", itemUpdateRecord.AExternalIdType);  //item.EcommerceExternalIdType
                Assert.AreEqual("ExternalId", itemUpdateRecord.AExternalId);  //item.EcommerceExternalId
                Assert.AreEqual("ImagePath", itemUpdateRecord.ImagePath);  //item.EcommerceImagePath1
                Assert.AreEqual("ImagePath2", itemUpdateRecord.AltImageFile1);  //item.EcommerceImagePath2
                Assert.AreEqual("ImagePath3", itemUpdateRecord.AltImageFile2);  //item.EcommerceImagePath3
                Assert.AreEqual("ImagePath4", itemUpdateRecord.AltImageFile3);  //item.EcommerceImagePath4
                Assert.AreEqual("ImagePath5", itemUpdateRecord.AltImageFile4);  //item.EcommerceImagePath5
                Assert.AreEqual("ItemHeight", itemUpdateRecord.AItemHeight);  //item.EcommerceItemHeight
                Assert.AreEqual("ItemLength", itemUpdateRecord.AItemLength);  //item.EcommerceItemLength
                Assert.AreEqual("EcommerceItemName", itemUpdateRecord.AItemName);  //item.EcommerceItemName
                Assert.AreEqual("EcommerceItemTypeKeywords", itemUpdateRecord.AItemTypeKeywords);  //item.EcommerceTypeKeywords
                Assert.AreEqual("ItemWeight", itemUpdateRecord.AItemWeight);  //item.EcommerceItemWeight
                Assert.AreEqual("ItemWidth", itemUpdateRecord.AItemWidth);  //item.EcommerceItemWidth
                Assert.AreEqual("EcommerceModelName", itemUpdateRecord.AModelName);  //item.EcommerceModelName
                Assert.AreEqual("3.1", itemUpdateRecord.APackageLength);  //item.EcommercePackageLength
                Assert.AreEqual("3.2", itemUpdateRecord.APackageHeight);  //item.EcommercePackageHeight
                Assert.AreEqual("3.3", itemUpdateRecord.APackageWeight);  //item.EcommercePackageWeight
                Assert.AreEqual("3.4", itemUpdateRecord.APackageWidth);  //item.EcommercePackageWidth
                Assert.AreEqual("PQty", itemUpdateRecord.APageQty);  //item.EcommercePageQty
                Assert.AreEqual("EcommerceProductCategory", itemUpdateRecord.AProductCategory);  //item.EcommerceProductCategory
                Assert.AreEqual("EcommerceProductDescription", itemUpdateRecord.AProductDescription);  //item.EcommerceProductDescription
                Assert.AreEqual("EcommerceProductSubcategory", itemUpdateRecord.AProductSubcategory);  //item.EcommerceProductSubcategory
                Assert.AreEqual("EcommerceManufacturerName", itemUpdateRecord.AManufacturerName);  //item.EcommerceManufacturerName
                Assert.AreEqual("msrp", itemUpdateRecord.AMsrp);  //item.EcommerceMsrp
                Assert.AreEqual("EcommerceGenericKeywords", itemUpdateRecord.AGenericKeywords);  //item.EcommerceGenericKeywords
                Assert.AreEqual("EcommerceSize", itemUpdateRecord.ASize);  //item.EcommerceSize
                Assert.AreEqual("EUpc", itemUpdateRecord.AUpc);  //item.EcommerceUpc
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertMasterItem is properly inserting info into PS_MASTER_ITEM
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertMasterItemTbl_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            GlobalData.ClearValues();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                Description = "This is a description of more than 30 characters I hope.",
                CostProfileGroup = "CPG",
                ItemGroup = "ItemGroup",
                ItemFamily = "ItemFamily",
                ItemCategory = "ItemCategory1",
                PsStatus = "S"
            };
            GlobalData.ItemCategories.Add("1", "ItemCategory1");

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertMasterItemTbl(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                MasterItemTbl masterItemTbl = (from o in context.MasterItemTbl select o).FirstOrDefault();
                
                Assert.AreEqual("N", masterItemTbl.ApprovRequired);
                Assert.AreEqual("N", masterItemTbl.ApprovSubmitted);
                // Assert.AreEqual("xxx", masterItemTbl.ApprovalDate = Convert.ToDateTime(DbUtil.StripTime(DateTime.Now)));
                Assert.AreEqual("BLEDBETTER", masterItemTbl.ApprovalOprid);
                Assert.AreEqual("1", masterItemTbl.CategoryId);
                Assert.AreEqual("N", masterItemTbl.CfgCodeOpt);
                Assert.AreEqual("N", masterItemTbl.CfgCostOpt);
                Assert.AreEqual("N", masterItemTbl.CfgLotOpt);
                Assert.AreEqual("", masterItemTbl.ChangeField);
                Assert.AreEqual("CPG", masterItemTbl.CmGroup);
                Assert.AreEqual("N", masterItemTbl.ConsignedFlag);
                Assert.AreEqual("", masterItemTbl.CpTemplateId );
                Assert.AreEqual("", masterItemTbl.CpTreeDist);
                Assert.AreEqual("", masterItemTbl.CpTreePrdn);
                // Assert.AreEqual("xxx", masterItemTbl.DateAdded = Convert.ToDateTime(DbUtil.StripTime(DateTime.Now)));
                Assert.AreEqual("", masterItemTbl.DenialReason);
                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE", masterItemTbl.Descr);
                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE THAN 30 CHARACTERS I HOPE.", masterItemTbl.Descr60);
                Assert.AreEqual("THIS IS A", masterItemTbl.Descrshort);
                Assert.AreEqual("N", masterItemTbl.DeviceTracking);
                Assert.AreEqual("N", masterItemTbl.DistCfgFlag);
                Assert.AreEqual("ItemGroup", masterItemTbl.InvItemGroup);
                Assert.AreEqual("TEST1", masterItemTbl.InvItemId);
                Assert.AreEqual("ItemFamily", masterItemTbl.InvProdFamCd);
                Assert.AreEqual("Y", masterItemTbl.InventoryItem);
                Assert.AreEqual("", masterItemTbl.ItemFieldC1A);
                Assert.AreEqual("", masterItemTbl.ItemFieldC1B);
                Assert.AreEqual("", masterItemTbl.ItemFieldC1C);
                Assert.AreEqual("", masterItemTbl.ItemFieldC1D);
                Assert.AreEqual("", masterItemTbl.ItemFieldC10A);
                Assert.AreEqual("", masterItemTbl.ItemFieldC10B);
                Assert.AreEqual("", masterItemTbl.ItemFieldC10C);
                Assert.AreEqual("", masterItemTbl.ItemFieldC10D);
                Assert.AreEqual("S", masterItemTbl.ItemFieldC2);
                Assert.AreEqual("", masterItemTbl.ItemFieldC30A);
                Assert.AreEqual("", masterItemTbl.ItemFieldC30B);
                Assert.AreEqual("", masterItemTbl.ItemFieldC30C);
                Assert.AreEqual("", masterItemTbl.ItemFieldC30D);
                Assert.AreEqual("", masterItemTbl.ItemFieldC4);
                Assert.AreEqual("", masterItemTbl.ItemFieldC6);
                Assert.AreEqual("", masterItemTbl.ItemFieldC8);
                Assert.AreEqual(0, masterItemTbl.ItemFieldN12A);
                Assert.AreEqual(0, masterItemTbl.ItemFieldN12B);
                Assert.AreEqual(0, masterItemTbl.ItemFieldN12C);
                Assert.AreEqual(0, masterItemTbl.ItemFieldN12D);
                Assert.AreEqual(0, masterItemTbl.ItemFieldN15A);
                Assert.AreEqual(0, masterItemTbl.ItemFieldN15B);
                Assert.AreEqual(0, masterItemTbl.ItemFieldN15C);
                Assert.AreEqual(0, masterItemTbl.ItemFieldN15D);
                Assert.AreEqual(null, masterItemTbl.ItmStatDtFuture);
                Assert.AreEqual("1", masterItemTbl.ItmStatusCurrent);
                //Assert.AreEqual("xxx", masterItemTbl.ItmStatusEffdt);
                Assert.AreEqual("", masterItemTbl.ItmStatusFuture);
                // Assert.AreEqual("xxx", masterItemTbl.LastDttmUpdate = DateTime.Now);
                Assert.AreEqual("BLEDBETTER", masterItemTbl.LastMaintOprid = GlobalData.UserName);
                Assert.AreEqual("N", masterItemTbl.LotControl);
                Assert.AreEqual("N", masterItemTbl.MaterialReconFlg);
                Assert.AreEqual("N", masterItemTbl.NonOwnFlag);
                Assert.AreEqual("BLEDBETTER", masterItemTbl.OrigOprid);
                Assert.AreEqual("G", masterItemTbl.PhysicalNature);
                Assert.AreEqual("", masterItemTbl.PlPrioFamily);
                Assert.AreEqual("N", masterItemTbl.PrdnCfgFlag);
                Assert.AreEqual("", masterItemTbl.PromiseOption);
                Assert.AreEqual("N", masterItemTbl.SerialControl);
                Assert.AreEqual("N", masterItemTbl.SerialInPrdn);
                Assert.AreEqual("SHARE", masterItemTbl.Setid);
                Assert.AreEqual("N", masterItemTbl.ShipSerialCntrl);
                Assert.AreEqual("N", masterItemTbl.StagedDateFlag);
                Assert.AreEqual("0", masterItemTbl.TraceChange);
                Assert.AreEqual("0", masterItemTbl.TraceUsage);
                Assert.AreEqual("EA", masterItemTbl.UnitMeasureStd);
                Assert.AreEqual("01", masterItemTbl.UsgTrckngMethod);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertPlItemAttribAll is properly inserting info into PS_PL_ITEM_ATTRIB
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertPlItemAttribAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1"
            };
            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertPlItemAttribAll(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<PlItemAttrib> plItemAttrib = (from o in context.PlItemAttrib select o).ToList();
                
                Assert.AreEqual( "TRCN1", plItemAttrib[0].BusinessUnit);
                Assert.AreEqual("TEST1", plItemAttrib[0].InvItemId);
                Assert.AreEqual( 0, plItemAttrib[0].ReschOutFactor);
                Assert.AreEqual( 0, plItemAttrib[0].ReschInFactor);
                Assert.AreEqual( 0, plItemAttrib[0].DemandFenceOf);
                Assert.AreEqual( 0, plItemAttrib[0].PlanFenceOff);
                Assert.AreEqual( 999, plItemAttrib[0].PlanHorizon);
                Assert.AreEqual( 0, plItemAttrib[0].TransferMinOrder);
                Assert.AreEqual( 0, plItemAttrib[0].TransferMaxOrder);
                Assert.AreEqual( 1, plItemAttrib[0].TransOrdMultiple);
                Assert.AreEqual( "N", plItemAttrib[0].TransferOrdMod);
                Assert.AreEqual( 0, plItemAttrib[0].PurMinOrder);
                Assert.AreEqual( 0, plItemAttrib[0].PurMaxOrder);
                Assert.AreEqual( 1, plItemAttrib[0].PurOrderMultiple);
                Assert.AreEqual( "N", plItemAttrib[0].PurOrderMod);
                Assert.AreEqual( "", plItemAttrib[0].MfgModUnit);
                Assert.AreEqual( 0, plItemAttrib[0].MfgMinOrder);
                Assert.AreEqual( 0, plItemAttrib[0].MfgMaxOrder);
                Assert.AreEqual( 1, plItemAttrib[0].MfgOrderMultiple);
                Assert.AreEqual( "N", plItemAttrib[0].MfgOrderMod);
                Assert.AreEqual( "N", plItemAttrib[0].MfgLeadTimeFlag);
                Assert.AreEqual( 0, plItemAttrib[0].SafetyLevel);
                Assert.AreEqual( 0, plItemAttrib[0].ExcessLevel);
                Assert.AreEqual( "", plItemAttrib[0].AutoApproveMsg);
                Assert.AreEqual( "", plItemAttrib[0].PlannerCd);
                Assert.AreEqual( 100, plItemAttrib[0].PurchaseYield);
                Assert.AreEqual( 100, plItemAttrib[0].TransferYield);
                Assert.AreEqual( "N", plItemAttrib[0].SalesConsump);
                Assert.AreEqual( "N", plItemAttrib[0].ProdConsump);
                Assert.AreEqual( "N", plItemAttrib[0].TransConsump);
                Assert.AreEqual("N" , plItemAttrib[0].MsrConsump);
                Assert.AreEqual( "N", plItemAttrib[0].ExtraConsump);
                Assert.AreEqual( "N", plItemAttrib[0].PlAggDmdFlag);
                Assert.AreEqual( 999, plItemAttrib[0].ReleasedOrder);
                Assert.AreEqual( 0, plItemAttrib[0].FirmedOrder);
                Assert.AreEqual( "", plItemAttrib[0].PlPrioFamily);
                Assert.AreEqual( "N", plItemAttrib[0].UseShiptoLoc);
                Assert.AreEqual( 0, plItemAttrib[0].PlFixedPeriod);
                Assert.AreEqual( "N", plItemAttrib[0].PlItemExpl);
                Assert.AreEqual( null, plItemAttrib[0].PlProjUseDt);
                Assert.AreEqual( "4", plItemAttrib[0].PlannedBy);
                Assert.AreEqual(0 , plItemAttrib[0].CapFenceOff);
                Assert.AreEqual(0 , plItemAttrib[0].FcstFulfillSize);
                Assert.AreEqual("1" , plItemAttrib[0].FcstAdjAction);
                Assert.AreEqual( 0, plItemAttrib[0].EarlyFence);
                Assert.AreEqual("Y" , plItemAttrib[0].GblEarlyFence);
                Assert.AreEqual( 1, plItemAttrib[0].PlSearchDepth);
                Assert.AreEqual( "N", plItemAttrib[0].SpotBuyFlg);

                Assert.AreEqual("TRUS1", plItemAttrib[1].BusinessUnit);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertProdItem is properly inserting info into PS_PROD_ITEM
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertProdItem_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            GlobalData.ClearValues();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1",
                Description = "This is a description of more than 30 characters I hope.",
                Gpc = "Gpc",
                Ean = "Ean",
                ItemCategory = "ItemCategory",
                Isbn = "Isbn",
                StatsCode = "StatsCode",
                Udex = "Udex"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertProdItem(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                ProdItem prodItem = (from o in context.ProdItem select o).FirstOrDefault();

                Assert.AreEqual("", prodItem.ActivityId); //  ""
                Assert.AreEqual("", prodItem.AppliesTo); //  ""
                Assert.AreEqual("", prodItem.BpDtlTmplId); //  ""
                Assert.AreEqual("", prodItem.BusinessUnitPc); //  ""
                Assert.AreEqual("", prodItem.CaApTmplId); //  ""
                Assert.AreEqual("", prodItem.CaBpTmplId); //  ""
                Assert.AreEqual("", prodItem.CatalogNbr); //  ""
                Assert.AreEqual("N", prodItem.CfgCodeOpt); //  "N"
                Assert.AreEqual("N", prodItem.CfgKitFlag); //  "N"
                Assert.AreEqual("N", prodItem.CommFlag); //  "N"
                Assert.AreEqual(0, prodItem.CommPct); //  0
                Assert.AreEqual("", prodItem.CostElement); //  ""
                Assert.AreEqual("", prodItem.CpTemplateId); //  ""
                Assert.AreEqual("", prodItem.CpTreeDist); //  ""
                // Assert.AreEqual(DateTime.Now, prodItem.DatetimeAdded); //  DateTime.Now
                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE", prodItem.Descr); //  DbUtil.Char30(item.Description).ToUpper()
                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE THAN 30 CHARACTERS I HOPE.", prodItem.Descr254); //  item.Description.ToUpper()
                Assert.AreEqual("N", prodItem.DropShipFlag); //  "N"
                Assert.AreEqual("A", prodItem.EffStatus); //  "A"
                Assert.AreEqual("N", prodItem.ExportLicReq); //  "N"
                Assert.AreEqual("N", prodItem.ForecastItemFlag); //  "N"
                Assert.AreEqual("N", prodItem.HoldUpdateSw); //  "N"
                Assert.AreEqual("TEST1", prodItem.InvItemId); //  item.ItemId
                Assert.AreEqual(GlobalData.UserName, prodItem.LastMaintOprid); //  GlobalData.UserName
                // Assert.AreEqual(DateTime.Now, prodItem.Lastupddttm); //  DateTime.Now
                Assert.AreEqual(0, prodItem.LowerMarginPct); //  0
                Assert.AreEqual("", prodItem.ModelNbr); //  ""
                Assert.AreEqual(0, prodItem.Percentage); //  0
                Assert.AreEqual("G", prodItem.PhysicalNature); //  "G"
                Assert.AreEqual("", prodItem.PriceKitFlag); //  ""
                Assert.AreEqual("AMT", prodItem.PricingStructure); //  "AMT"
                Assert.AreEqual("", prodItem.ProdBrand); //  ""
                Assert.AreEqual("ItemCategory", prodItem.ProdCategory); //  item.ItemCategory
                Assert.AreEqual("Isbn", prodItem.ProdFieldC10A); //  item.Isbn
                Assert.AreEqual("", prodItem.ProdFieldC10B); //  ""
                Assert.AreEqual("Gpc", prodItem.ProdFieldC10C); //  item.Gpc
                Assert.AreEqual("", prodItem.ProdFieldC10D); //  ""
                Assert.AreEqual("", prodItem.ProdFieldC1A); //  ""
                Assert.AreEqual("", prodItem.ProdFieldC1B); //  ""
                Assert.AreEqual("", prodItem.ProdFieldC1C); //  ""
                Assert.AreEqual("", prodItem.ProdFieldC1D); //  ""
                Assert.AreEqual("", prodItem.ProdFieldC2); //  ""
                Assert.AreEqual("Ean", prodItem.ProdFieldC30A); //  item.Ean
                Assert.AreEqual("StatsCode", prodItem.ProdFieldC30B); //  item.StatsCode
                Assert.AreEqual("Udex", prodItem.ProdFieldC30C); //  item.Udex
                Assert.AreEqual("", prodItem.ProdFieldC30D); //  ""
                Assert.AreEqual("", prodItem.ProdFieldC4); //  ""
                Assert.AreEqual("", prodItem.ProdFieldC6); //  ""
                Assert.AreEqual("", prodItem.ProdFieldC8); //  ""
                Assert.AreEqual(0, prodItem.ProdFieldN12A); //  0
                Assert.AreEqual(0, prodItem.ProdFieldN12B); //  0
                Assert.AreEqual(0, prodItem.ProdFieldN12C); //  0
                Assert.AreEqual(0, prodItem.ProdFieldN12D); //  0
                Assert.AreEqual(0, prodItem.ProdFieldN15A); //  0
                Assert.AreEqual(0, prodItem.ProdFieldN15B); //  0
                Assert.AreEqual(0, prodItem.ProdFieldN15C); //  0
                Assert.AreEqual(0, prodItem.ProdFieldN15D); //  0
                Assert.AreEqual("TEST1", prodItem.ProductId); //  item.ItemId
                Assert.AreEqual("N", prodItem.ProductKitFlag); //  "N"
                Assert.AreEqual("1", prodItem.ProductUse); //  "1"
                Assert.AreEqual("", prodItem.ProjectId); //  ""
                Assert.AreEqual("N", prodItem.Renewable); //  "N"
                Assert.AreEqual("Y", prodItem.ReturnFlag); //  "Y"
                Assert.AreEqual("4", prodItem.RevRecogMethod); //  "4"
                Assert.AreEqual("", prodItem.RnwTemplateId); //  ""
                Assert.AreEqual("SHARE", prodItem.Setid); //  "SHARE"
                Assert.AreEqual("TEST1", prodItem.TaxProductNbr); //  item.ItemId
                Assert.AreEqual("", prodItem.TaxTransSubType); //  ""
                Assert.AreEqual("", prodItem.TaxTransType); //  ""
                Assert.AreEqual("N", prodItem.ThirdPartyFlg); //  "N"
                Assert.AreEqual(0, prodItem.UpperMarginPct); //  0
                Assert.AreEqual("", prodItem.VatSvcPerfrmFlg); //  ""
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertProdPgrpLnkAll is properly inserting info into PS_PROD_PGRP_LNK
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertProdPgrpLnkAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            GlobalData.ClearValues();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            string username = GlobalData.UserName;
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                PricingGroup = "PG"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertProdPgrpLnkAll(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List< ProdPgrpLnk> prodPgrpLnk = (from o in context.ProdPgrpLnk select o).ToList();

                // Assert.AreEqual(DateTime.Now, prodPgrpLnk[0].DatetimeAdded);
                Assert.AreEqual(username, prodPgrpLnk[0].LastMaintOprid);
                // Assert.AreEqual(DateTime.Now, prodPgrpLnk[0].Lastupddttm);
                Assert.AreEqual("N", prodPgrpLnk[0].PrimaryFlag);
                Assert.AreEqual("N", prodPgrpLnk[0].PrimPrcFlag );
                Assert.AreEqual("ACCT", prodPgrpLnk[0].ProdGrpType);
                Assert.AreEqual("", prodPgrpLnk[0].ProductGroup = item.AccountingGroup.ToUpper());
                Assert.AreEqual("TEST1", prodPgrpLnk[0].ProductId);
                Assert.AreEqual("SHARE", prodPgrpLnk[0].Setid);

                Assert.AreEqual("Y", prodPgrpLnk[1].PrimPrcFlag);
                Assert.AreEqual("PRC", prodPgrpLnk[1].ProdGrpType);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertProdPriceAll is properly inserting info into PS_PROD_PRICE
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertProdPriceAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            string userName = GlobalData.UserName;
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                ListPriceCad = "5.99",
                MsrpCad = "10.99",
                ListPriceMxn = "6.99",
                MsrpMxn = "12.99",
                ListPriceUsd = "7.99",
                Msrp = "14.99"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertProdPriceAll(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<ProdPrice> prodPrice = (from o in context.ProdPrice select o).ToList();
                
                Assert.AreEqual("TRCN1", prodPrice[0].BusinessUnitIn);
                Assert.AreEqual("CAD", prodPrice[0].CurrencyCd);
                // Assert.AreEqual(DateTime.Now, prodPrice[0].DatetimeAdded);
                Assert.AreEqual(Convert.ToDateTime("1901-01-01"), prodPrice[0].Effdt);
                Assert.AreEqual("A",prodPrice[0].EffStatus);
                Assert.AreEqual(userName, prodPrice[0].LastMaintOprid);
                // Assert.AreEqual(DateTime.Now, prodPrice[0].Lastupddttm);
                Assert.AreEqual(5.99m, prodPrice[0].ListPrice);
                Assert.AreEqual(10.99m, prodPrice[0].MfgSugRtlPrc);
                Assert.AreEqual("", prodPrice[0].PricingFlag);
                Assert.AreEqual("TEST1",prodPrice[0].ProductId);
                Assert.AreEqual(0,prodPrice[0].RepairCost);
                Assert.AreEqual(0,prodPrice[0].ServiceCost);
                Assert.AreEqual("SHARE",prodPrice[0].Setid);
                Assert.AreEqual(0,prodPrice[0].UnitCost);
                Assert.AreEqual("EA",prodPrice[0].UnitOfMeasure);


                Assert.AreEqual("TRMX1", prodPrice[1].BusinessUnitIn);
                Assert.AreEqual("MXN", prodPrice[1].CurrencyCd);
                Assert.AreEqual(6.99m, prodPrice[1].ListPrice);
                Assert.AreEqual(12.99m, prodPrice[1].MfgSugRtlPrc);

                Assert.AreEqual("TRUS1", prodPrice[2].BusinessUnitIn);
                Assert.AreEqual("CAD", prodPrice[2].CurrencyCd);
                Assert.AreEqual(5.99m, prodPrice[2].ListPrice);
                Assert.AreEqual(10.99m, prodPrice[2].MfgSugRtlPrc);

                Assert.AreEqual("TRUS1", prodPrice[3].BusinessUnitIn);
                Assert.AreEqual("MXN", prodPrice[3].CurrencyCd);
                Assert.AreEqual(6.99m, prodPrice[3].ListPrice);
                Assert.AreEqual(12.99m, prodPrice[3].MfgSugRtlPrc);
                

                Assert.AreEqual("TRUS1", prodPrice[4].BusinessUnitIn);
                Assert.AreEqual("USD", prodPrice[4].CurrencyCd);
                Assert.AreEqual(7.99m, prodPrice[4].ListPrice);
                Assert.AreEqual(14.99m, prodPrice[4].MfgSugRtlPrc);
                

            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertProdPriceBuAll is properly inserting info into PS_PROD_PRICE_BU
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertProdPriceBuAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                ListPriceMxn = "6"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertProdPriceBuAll(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<ProdPriceBu> prodPriceBu = (from o in context.ProdPriceBu select o).ToList();

                Assert.AreEqual("TRCN1", prodPriceBu[0].BusinessUnitIn);
                Assert.AreEqual("CAD", prodPriceBu[0].CurrencyCd);
                // Assert.AreEqual("TRCN1", prodPriceBu[0].DatetimeAdded);
                Assert.AreEqual("BLEDBETTER", prodPriceBu[0].LastMaintOprid);
                // Assert.AreEqual("TRCN1", prodPriceBu[0].Lastupddttm);
                Assert.AreEqual("TEST1", prodPriceBu[0].ProductId);
                Assert.AreEqual("SHARE", prodPriceBu[0].Setid);
                Assert.AreEqual("EA", prodPriceBu[0].UnitOfMeasure);

                Assert.AreEqual("TRMX1", prodPriceBu[1].BusinessUnitIn);
                Assert.AreEqual("MXN", prodPriceBu[1].CurrencyCd);

                Assert.AreEqual("TRUS1", prodPriceBu[2].BusinessUnitIn);
                Assert.AreEqual("CAD", prodPriceBu[2].CurrencyCd);

                Assert.AreEqual("TRUS1", prodPriceBu[3].BusinessUnitIn);
                Assert.AreEqual("MXN", prodPriceBu[3].CurrencyCd);
                

                Assert.AreEqual("TRUS1", prodPriceBu[4].BusinessUnitIn);
                Assert.AreEqual("USD", prodPriceBu[4].CurrencyCd);
                
                
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertProdUom is properly inserting info into PS_PROD_UOM
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertProdUom_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertProdUom(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                ProdUom prodUom = (from o in context.ProdUom select o).FirstOrDefault();

                // Assert.AreEqual(DateTime.Now, prodUom.DatetimeAdded);
                Assert.AreEqual("Y", prodUom.DfltUom);
                Assert.AreEqual("BLEDBETTER", prodUom.LastMaintOprid);
                // Assert.AreEqual(DateTime.Now, prodUom.Lastupddttm);
                Assert.AreEqual(0, prodUom.MaxOrderQty);
                Assert.AreEqual(0, prodUom.MinOrderQty);
                Assert.AreEqual(0, prodUom.OrderIncrement);
                Assert.AreEqual("TEST1", prodUom.ProductId);
                Assert.AreEqual("SHARE", prodUom.Setid);
                Assert.AreEqual("EA", prodUom.UnitOfMeasure);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertPurchItemAttr is properly inserting info into PS_PURCH_ITEM_ATTR
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertPurchItemAttr_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            GlobalData.ClearValues();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                Description = "This is a description of more than 30 characters I hope.",
                StandardCost = "9.99"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertPurchItemAttr(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                PurchItemAttr purchItemAttr = (from o in context.PurchItemAttr select o).FirstOrDefault();

                Assert.AreEqual("Y", purchItemAttr.AcceptAllShipto);
                Assert.AreEqual("Y", purchItemAttr.AcceptAllVendor);
                Assert.AreEqual("23000", purchItemAttr.Account);
                Assert.AreEqual("", purchItemAttr.Affiliate);
                Assert.AreEqual("", purchItemAttr.AffiliateIntra1);
                Assert.AreEqual("", purchItemAttr.AffiliateIntra2);
                Assert.AreEqual("", purchItemAttr.Altacct);
                Assert.AreEqual("Y", purchItemAttr.AutoSource );
                Assert.AreEqual("Y", purchItemAttr.AvailAllRgns );
                Assert.AreEqual("", purchItemAttr.BudgetRef );
                Assert.AreEqual("", purchItemAttr.Chartfield1);
                Assert.AreEqual("", purchItemAttr.Chartfield2 );
                Assert.AreEqual("", purchItemAttr.Chartfield3 );
                Assert.AreEqual("", purchItemAttr.ClassFld );
                Assert.AreEqual("N", purchItemAttr.ContractReq );
                Assert.AreEqual("USD", purchItemAttr.CurrencyCd );
                Assert.AreEqual("", purchItemAttr.Deptid );
                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE", purchItemAttr.Descr);
                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE THAN 30 CHARACTERS I HOPE.", purchItemAttr.Descr254Mixed);
                Assert.AreEqual("THIS IS A", purchItemAttr.Descrshort);
                Assert.AreEqual(50, purchItemAttr.ExtPrcTol );
                Assert.AreEqual(999999, purchItemAttr.ExtPrcTolL);
                Assert.AreEqual("", purchItemAttr.FileExtension );
                Assert.AreEqual("", purchItemAttr.Filename);
                Assert.AreEqual("", purchItemAttr.FundCode );
                Assert.AreEqual("N", purchItemAttr.InspectCd );
                Assert.AreEqual(0, purchItemAttr.InspectSamplePer );
                Assert.AreEqual("S", purchItemAttr.InspectUomType );
                Assert.AreEqual("TEST1", purchItemAttr.InvItemId);
                Assert.AreEqual(0, purchItemAttr.KbOvrRecvTol );
                Assert.AreEqual("N", purchItemAttr.KbPastDuePo );
                Assert.AreEqual(null, purchItemAttr.LastDttmUpdate );
                Assert.AreEqual(0, purchItemAttr.LastPoPricePaid );
                Assert.AreEqual(0, purchItemAttr.LeadTimeImp );
                Assert.AreEqual("", purchItemAttr.Model );
                Assert.AreEqual("", purchItemAttr.OperatingUnit );
                Assert.AreEqual("", purchItemAttr.OpridModifiedBy );
                Assert.AreEqual(0, purchItemAttr.PackingVolume );
                Assert.AreEqual(0, purchItemAttr.PackingWeight );
                Assert.AreEqual(100, purchItemAttr.PctExtPrcTol );
                Assert.AreEqual(100, purchItemAttr.PctExtPrcTolL );
                Assert.AreEqual(0, purchItemAttr.PctUnderQty );
                Assert.AreEqual(5, purchItemAttr.PctUnitPrcTol );
                Assert.AreEqual(100, purchItemAttr.PctUnitPrcTolL );
               //  Assert.AreEqual("", purchItemAttr.PoAvailDt = Convert.ToDateTime(DbUtil.StripTime(DateTime.Now)));
                // Assert.AreEqual("", purchItemAttr.PoUnavailDt = Convert.ToDateTime("2999-12-31"));
                Assert.AreEqual(0, purchItemAttr.PriceImp = 0);
                Assert.AreEqual(9.99M, purchItemAttr.PriceList );
                Assert.AreEqual("", purchItemAttr.PrimaryBuyer);
                Assert.AreEqual("", purchItemAttr.Product );
                Assert.AreEqual("", purchItemAttr.ProgramCode );
                Assert.AreEqual("", purchItemAttr.ProjectId);
                Assert.AreEqual(0, purchItemAttr.QtyRecvTolPct);
                Assert.AreEqual("1", purchItemAttr.RecvPartialFlg );
                Assert.AreEqual("Y", purchItemAttr.RecvReq );
                Assert.AreEqual(0, purchItemAttr.RejectDays);
                Assert.AreEqual("N", purchItemAttr.RfqReqFlag );
                Assert.AreEqual("N", purchItemAttr.RjctOverTolFlag );
                Assert.AreEqual("", purchItemAttr.RoutingId);
                Assert.AreEqual("SHARE", purchItemAttr.Setid);
                Assert.AreEqual(0, purchItemAttr.ShipLateDays);
                Assert.AreEqual(0, purchItemAttr.ShiptoPrImp);
                Assert.AreEqual("", purchItemAttr.ShipTypeId );
                Assert.AreEqual("B", purchItemAttr.SrcMethod );
                Assert.AreEqual(0, purchItemAttr.StdLead );
                Assert.AreEqual("N", purchItemAttr.StocklessFlg );
                Assert.AreEqual("Y", purchItemAttr.TaxableCd );
                Assert.AreEqual("", purchItemAttr.UltimateUseCd );
                Assert.AreEqual("", purchItemAttr.UnitMeasureVol );
                Assert.AreEqual("", purchItemAttr.UnitMeasureWt );
                Assert.AreEqual(999999, purchItemAttr.UnitPrcTol );
                Assert.AreEqual(999999, purchItemAttr.UnitPrcTolL  );
                Assert.AreEqual("N", purchItemAttr.UseCatSrcCntl );
                Assert.AreEqual("", purchItemAttr.VatSvcPerfrmFlg);
                Assert.AreEqual(0, purchItemAttr.VndrPrImp);
                Assert.AreEqual(999, purchItemAttr.WfPctPrcTolOvr);
                Assert.AreEqual(999, purchItemAttr.WfPctPrcTolUnd);
                Assert.AreEqual(99999999, purchItemAttr.WfPrcTolOvr);
                Assert.AreEqual(99999999, purchItemAttr.WfPrcTolUnd);
                
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertPvItmCategory is properly inserting info into PS_PV_ITM_CATEGORY
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertPvItmCategory_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1){
                ItemId = "TEST1",
                ItemCategory = "Category1"
            };
            GlobalData.ItemCategories.Add("1","Category1");

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertPvItmCategory(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                PvItmCategory pvItmCategory = (from o in context.PvItmCategory select o).FirstOrDefault();

                Assert.AreEqual("SHARE", pvItmCategory.Setid);
                Assert.AreEqual("TEST1", pvItmCategory.InvItemId);
                Assert.AreEqual("1", pvItmCategory.CategoryId);
                Assert.AreEqual("Y", pvItmCategory.PvPreferredCat);                        
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests InsertUomTypeInvAll is properly inserting info into PS_UOM_TYPE_INV_ALL
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertUomTypeInvAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1){
                ItemId = "TEST1"
            };
            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertUomTypeInvAll(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<UomTypeInv> uomTypeInv = (from o in context.UomTypeInv select o).ToList();
                
                Assert.AreEqual("TEST1", uomTypeInv[0].InvItemId);
                Assert.AreEqual("SHARE", uomTypeInv[0].Setid);
                Assert.AreEqual("EA", uomTypeInv[0].UnitOfMeasure);
                Assert.AreEqual("ORDR", uomTypeInv[0].InvUomType);
                Assert.AreEqual("SHIP", uomTypeInv[1].InvUomType);
                Assert.AreEqual("STCK", uomTypeInv[2].InvUomType);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests that Web Categories are being inserted and read back correctly
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_InsertWebCategory_ShouldSucceed()
        {
            #region Assemble 

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());

            #endregion  // Assemble

            #region Act
            itemRepository.InsertWebCategory("TestCategory");
            itemRepository.InsertWebCategory("TestCategory2");
            OdinContext context = new OdinContext(DbHelpers.GetConnectionString(), new MockLogServiceFactory());
            List<OdinNewWebCategories> odinNewWebCategories = (from l in context.OdinNewWebCategories select l).ToList();

            #endregion  // Act

            #region Assert

            Assert.AreEqual("TestCategory", odinNewWebCategories[0].Category);
            Assert.AreEqual(2, odinNewWebCategories[1].Id);

            #endregion  // Assert

        }

        #endregion // Insert Tests

        #region Retrieval Tests

        /// <summary>
        ///     Tests that proper values are being inserted into the database and being returned properly
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_RetrieveCategoryCodeByName_ShouldReturnValues()
        {
            #region Assemble
            
            TestItemRepository testItemRepository = new TestItemRepository();
            GlobalData.WebCategoryList.Add("26", "DC9category");
            string categoryValue = "DC9category";

            #endregion // Assemble

            #region Act

            string result = testItemRepository.RetrieveWebCategoryCodeByName(categoryValue);

            #endregion // Act

            #region Assert

            Assert.AreEqual("26", result);

            #endregion // Assert
        }

        /// <summary>
        ///     Tests that incorrect values return an empty string
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_RetrieveCategoryCodeByName_ShouldReturnEmptyString()
        {
            #region Assemble

            GlobalData.ClearValues();

            TestItemRepository testItemRepository = new TestItemRepository();
            #endregion // Assemble

            #region Act

            string result = testItemRepository.RetrieveWebCategoryCodeByName("Category7");

            #endregion // Act

            #region Assert

            Assert.AreEqual("", result);

            #endregion // Assert
        }
        
        /// <summary>
        ///     Tests RetrieveOpenOrderLine returns true when there is an open order
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_RetrieveOpenOrderLine_ResultsVary()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            DbHelpers.InsertOrderLine("itemId1", "O");
            DbHelpers.InsertOrderLine("itemId2", "C");
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());

            #endregion // Assemble

            #region Act

            bool result1 = itemRepository.RetrieveOpenOrderLine("itemId1");
            bool result2 = itemRepository.RetrieveOpenOrderLine("itemId2");

            #endregion // Act

            #region Assert

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);

            #endregion // Assert

        }

        /// <summary>
        ///     Checks existing product id transalations. Item id ST4444 does not exist in the product id
        ///     translation table with the correct parent id.
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_RetrieveProductIdTranslationMatch_ShouldFail()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1)
            {
                ItemId = "FROMITEM1"
            };

            // List with matching item ids
            List<ChildElement> productIdTranslationList1 = new List<ChildElement>(new ChildElement[] {
                new ChildElement("ST1111", item.ItemId, 2),
                new ChildElement("ST2222", item.ItemId, 2),
                new ChildElement("ST3333", item.ItemId, 2)
            });
            
            item.ProductIdTranslation = productIdTranslationList1;
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertProductIdTranslationAll(item, context);
                context.SaveChanges();
            }           

            #endregion // Assemble

            #region Act

            bool result1 = itemRepository.RetrieveProductIdTranslationMatch("ST1111", "FROMITEM1");
            bool result2 = itemRepository.RetrieveProductIdTranslationMatch("ST4444", "FROMITEM1");

            #endregion // Act

            #region Assert

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);

            #endregion // Assert
        }

        #endregion // Retrieval Tests

        #region Update Tests

        /// <summary>
        ///     Tests UpdateBuItemsInvAll is properly updating info in PS_BU_ITEMS_INV
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateBuItemsInvAll_ItemInfoShouldUpdate()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                MfgSource = "MG",
                CountryOfOrigin = "COO",
                DefaultActualCostUsd = "9.99",
                DefaultActualCostCad = "8.99"
            };
                        
            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertBuItemsInvAll(item, context);
                context.SaveChanges();
            }

            item.DefaultActualCostUsd = "4.99";
            item.DefaultActualCostCad = "3.99";
            
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateBuItemsInvAll(item, context);
                context.SaveChanges();
            }
            

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<BuItemsInv> result = (from o in context.BuItemsInv select o).ToList();
                
                Assert.AreEqual("TRCN1", result[0].BusinessUnit); //  businessUnit
                Assert.AreEqual(3.99m, result[0].CurrentCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual(3.99m, result[0].DfltActualCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual("TEST1", result[0].InvItemId); //  item.ItemId

                Assert.AreEqual("TRMX1", result[1].BusinessUnit); //  businessUnit
                Assert.AreEqual(4.99m, result[1].CurrentCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual(4.99m, result[1].DfltActualCost); //  Convert.ToDecimal(defaultActualCost)

                Assert.AreEqual("TRUS1", result[2].BusinessUnit); //  businessUnit
                Assert.AreEqual(4.99m, result[2].CurrentCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual(4.99m, result[2].DfltActualCost); //  Convert.ToDecimal(defaultActualCost)
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests UpdateCategory is properly updating info in Odin_NewWebCategories
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateCategory_ItemInfoShouldUpdate()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                MfgSource = "MG",
                CountryOfOrigin = "COO",
                DefaultActualCostUsd = "9.99",
                DefaultActualCostCad = "8.99"
            };

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertBuItemsInvAll(item, context);
                context.SaveChanges();
            }
            item.MfgSource = "FM";
            item.CountryOfOrigin = "COM";
            item.DefaultActualCostUsd = "4.99";
            item.DefaultActualCostCad = "3.99";

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateBuItemsInvAll(item, context);
                context.SaveChanges();
            }


            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<BuItemsInv> result = (from o in context.BuItemsInv select o).ToList();

                Assert.AreEqual("TRCN1", result[0].BusinessUnit); //  businessUnit
                Assert.AreEqual(3.99m, result[0].CurrentCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual(3.99m, result[0].DfltActualCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual("TEST1", result[0].InvItemId); //  item.ItemId
                Assert.AreEqual("COM", result[0].CountryIstOrigin); //  item.ItemId
                Assert.AreEqual("FM", result[0].SourceCode); //  item.ItemId

                Assert.AreEqual("TRMX1", result[1].BusinessUnit); //  businessUnit
                Assert.AreEqual(4.99m, result[1].CurrentCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual(4.99m, result[1].DfltActualCost); //  Convert.ToDecimal(defaultActualCost)

                Assert.AreEqual("TRUS1", result[2].BusinessUnit); //  businessUnit
                Assert.AreEqual(4.99m, result[2].CurrentCost); //  Convert.ToDecimal(defaultActualCost)
                Assert.AreEqual(4.99m, result[2].DfltActualCost); //  Convert.ToDecimal(defaultActualCost)
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests UpdateCmItemMethodAll is properly updating info in PS_CM_ITEM_METHOD
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateCmItemMethodAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                CostProfileGroup = "ACTUAL_FIFO"
            };

            #endregion // Assemble

            #region Act
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertCmItemMethodAll(item, context);
                context.SaveChanges();
            }
            item.CostProfileGroup = "ACTUAL";
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateCmItemMethodAll(item, context);
                context.SaveChanges();
            }
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<CmItemMethod> result = (from o in context.CmItemMethod select o).ToList();

                Assert.AreEqual("TRCN1", result[0].BusinessUnit);
                Assert.AreEqual("TEST1", result[0].InvItemId);
                Assert.AreEqual("MFGACTFIFO", result[0].CmProfileId);

                Assert.AreEqual("TRUS1", result[1].BusinessUnit);
                Assert.AreEqual("MFGACTFIFO", result[1].CmProfileId);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests UpdateCustomerProductAttributesAll is properly updating info in PS_CUSTOMER_PRODUCT_ATTRIBUTES
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateCustomerProductAttributesAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            GlobalData.CustomerIdConversions.Add("ALL POSTERS", "1");
            GlobalData.CustomerIdConversions.Add("AMAZON", "2");
            GlobalData.CustomerIdConversions.Add("FANATICS", "3");
            GlobalData.CustomerIdConversions.Add("HAYNEEDLE", "4");
            GlobalData.CustomerIdConversions.Add("HOUZZ", "000000000146472");
            GlobalData.CustomerIdConversions.Add("TARGET", "5");
            GlobalData.CustomerIdConversions.Add("WALMART", "6");
            GlobalData.CustomerIdConversions.Add("WAYFAIR", "7");
            GlobalData.CustomerIdConversions.Add("GUITAR CENTER", "9");
            GlobalData.CustomerIdConversions.Add("AMAZON SELLER CENTRAL", "10");
            GlobalData.CustomerIdConversions.Add("TRS", "000000000146515");
            GlobalData.CustomerIdConversions.Add("SHOP TRENDS", "000000000146515");

            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                SellOnAllPosters = "Y",
                SellOnAmazon = "N",
                SellOnFanatics = "Y",
                SellOnGuitarCenter = "Y",
                SellOnHayneedle = "N",
                // SellOnHouzz = "N",
                SellOnTarget = "Y",
                SellOnTrs = "N",
                SellOnWalmart = "N",
                SellOnWayfair = "Y"
            };

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertCustomerProductAttributesAll(item, context);
                context.SaveChanges();
            }
            item.SellOnAllPosters = "N";
            item.SellOnAmazon = "Y";
            item.SellOnFanatics = "N";
            item.SellOnGuitarCenter = "N";
            item.SellOnHayneedle = "Y";
            // item.SellOnHouzz = "Y";
            item.SellOnTarget = "N";
            item.SellOnTrs = "N";
            item.SellOnWalmart = "Y";
            item.SellOnWayfair = "N";
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateCustomerProductAttributesAll(item, context);
                context.SaveChanges();
            }


            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<CustomerProductAttributes> result = (from o in context.CustomerProductAttributes select o).ToList();

                Assert.AreEqual("SHARE", result[0].Setid);
                Assert.AreEqual("TEST1", result[0].ProductId);
                Assert.AreEqual("1", result[0].CustId);
                Assert.AreEqual(0, result[0].InnerpackQty);
                Assert.AreEqual(0, result[0].CasepackQty);
                Assert.AreEqual("N", result[0].SendInventory);

                Assert.AreEqual("2", result[1].CustId);
                Assert.AreEqual("Y", result[1].SendInventory);

                Assert.AreEqual("3", result[2].CustId);
                Assert.AreEqual("N", result[2].SendInventory);

                Assert.AreEqual("4", result[3].CustId);
                Assert.AreEqual("Y", result[3].SendInventory);

                Assert.AreEqual("5", result[4].CustId);
                Assert.AreEqual("N", result[4].SendInventory);

                Assert.AreEqual("6", result[5].CustId);
                Assert.AreEqual("Y", result[5].SendInventory);

                Assert.AreEqual("7", result[6].CustId);
                Assert.AreEqual("N", result[6].SendInventory);

                Assert.AreEqual("9", result[7].CustId);
                Assert.AreEqual("N", result[7].SendInventory);
            }

            #endregion // Assert

        }

        /// <summary>
        ///     Tests UpdateEcommerceValues is properly updating info in PS_AMAZON_ITEM_ATTRIBUTES
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateEcommerceValues_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                EcommerceAsin = "NISA",
                EcommerceBullet1 = "B1",
                EcommerceBullet2 = "B2",
                EcommerceBullet3 = "B3",
                EcommerceBullet4 = "B4",
                EcommerceBullet5 = "B5",
                EcommerceComponents = "CMPTS",
                EcommerceCost = "7",
                EcommerceCountryofOrigin = "USA",
                EcommerceExternalId = "IDEX",
                EcommerceExternalIdType = "TDIXE",
                EcommerceImagePath1 = "1IMG",
                EcommerceImagePath2 = "2IMG",
                EcommerceImagePath3 = "3IMG",
                EcommerceImagePath4 = "4IMG",
                EcommerceImagePath5 = "5IMG",
                EcommerceItemHeight = "22",
                EcommerceItemLength = "12",
                EcommerceItemName = "ItemName",
                EcommerceItemTypeKeywords = "EcommerceItemTypeKeywords",
                EcommerceItemWeight = "2.5",
                EcommerceItemWidth = "3.2",
                EcommerceModelName = "MName",
                EcommercePackageHeight = "2.1",
                EcommercePackageLength = "7.2",
                EcommercePackageWeight = "8.3",
                EcommercePackageWidth = "5.4",
                EcommercePageQty = "34",
                EcommerceProductCategory = "PCAT",
                EcommerceProductDescription = "FDESC",
                EcommerceProductSubcategory = "PRODSUB",
                EcommerceManufacturerName = "MNAME",
                EcommerceMsrp = "19.99",
                EcommerceGenericKeywords = "STERMS",
                EcommerceSubjectKeywords = "SKEYS",
                EcommerceSize = "SLIZ",
                EcommerceUpc = "UOVER"
            };
            item.ResetUpdate();

            #endregion // Assemble

            #region Act


            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertEcommerceValues(item, context);
                context.SaveChanges();
            }
            item.EcommerceAsin = "Asin";
            item.EcommerceBullet1 = "Bullet1";
            item.EcommerceBullet2 = "Bullet2";
            item.EcommerceBullet3 = "Bullet3";
            item.EcommerceBullet4 = "Bullet4";
            item.EcommerceBullet5 = "Bullet5";
            item.EcommerceComponents = "Components";
            item.EcommerceCost = "5";
            item.EcommerceCountryofOrigin = "Coo";
            item.EcommerceExternalId = "ExId";
            item.EcommerceExternalIdType = "ExIdT";
            item.EcommerceImagePath1 = "ImageUrl1";
            item.EcommerceImagePath2 = "ImageUrl2";
            item.EcommerceImagePath3 = "ImageUrl3";
            item.EcommerceImagePath4 = "ImageUrl4";
            item.EcommerceImagePath5 = "ImageUrl5";
            item.EcommerceItemHeight = "6";
            item.EcommerceItemLength = "1";
            item.EcommerceItemName = "ItemName";
            item.EcommerceItemTypeKeywords = "EcommerceItemTypeKeywords";
            item.EcommerceItemWeight = "2";
            item.EcommerceItemWidth = "3";
            item.EcommerceModelName = "ModelName";
            item.EcommercePackageHeight = "1.1";
            item.EcommercePackageLength = "1.2";
            item.EcommercePackageWeight = "1.3";
            item.EcommercePackageWidth = "1.4";
            item.EcommercePageQty = "3";
            item.EcommerceProductCategory = "ProductCategory";
            item.EcommerceProductDescription = "FullDescription";
            item.EcommerceProductSubcategory = "ProductSubcategory";
            item.EcommerceManufacturerName = "ManufacturerName";
            item.EcommerceMsrp = "9.99";
            item.EcommerceGenericKeywords = "Ecommercegenerickeywords";
            item.EcommerceSubjectKeywords = "Ecommercesubjectkeywords";
            item.EcommerceSize = "Size";
            item.EcommerceUpc = "UpcOverride";
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateEcommerceValues(item, context);
                context.SaveChanges();
            }

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {

                AmazonItemAttributes amazonItemAttributes = (from o in context.AmazonItemAttributes select o).FirstOrDefault();

                Assert.AreEqual("Asin", amazonItemAttributes.Asin);
                Assert.AreEqual("Bullet1", amazonItemAttributes.Bullet1);
                Assert.AreEqual("Bullet2", amazonItemAttributes.Bullet2);
                Assert.AreEqual("Bullet3", amazonItemAttributes.Bullet3);
                Assert.AreEqual("Bullet4", amazonItemAttributes.Bullet4);
                Assert.AreEqual("Bullet5", amazonItemAttributes.Bullet5);
                Assert.AreEqual("Components", amazonItemAttributes.Components);
                Assert.AreEqual(5, amazonItemAttributes.Cost);
                Assert.AreEqual("Coo", amazonItemAttributes.CountryOfOrigin);
                Assert.AreEqual("ExId", amazonItemAttributes.ExternalId);
                Assert.AreEqual("ExIdT", amazonItemAttributes.ExternalIdType);
                Assert.AreEqual("ImageUrl1", amazonItemAttributes.ImageUrl1);
                Assert.AreEqual("ImageUrl2", amazonItemAttributes.ImageUrl2);
                Assert.AreEqual("ImageUrl3", amazonItemAttributes.ImageUrl3);
                Assert.AreEqual("ImageUrl4", amazonItemAttributes.ImageUrl4);
                Assert.AreEqual("ImageUrl5", amazonItemAttributes.ImageUrl5);
                Assert.AreEqual(6, amazonItemAttributes.Height);
                Assert.AreEqual("TEST1", amazonItemAttributes.InvItemId);
                Assert.AreEqual("ItemName", amazonItemAttributes.ItemName);
                Assert.AreEqual(1, amazonItemAttributes.Length);
                Assert.AreEqual(2, amazonItemAttributes.Weight);
                Assert.AreEqual(3, amazonItemAttributes.Width);
                Assert.AreEqual("ModelName", amazonItemAttributes.ModelName);
                Assert.AreEqual(1.1000m, amazonItemAttributes.PackageHeight);
                Assert.AreEqual(1.2000m, amazonItemAttributes.PackageLength);
                Assert.AreEqual(1.3000m, amazonItemAttributes.PackageWeight);
                Assert.AreEqual(1.4000m, amazonItemAttributes.PackageWidth);
                Assert.AreEqual(3, amazonItemAttributes.PageCount);
                Assert.AreEqual("ProductCategory", amazonItemAttributes.ProductCategory);
                Assert.AreEqual("FullDescription", amazonItemAttributes.FullDescription);
                Assert.AreEqual("ProductSubcategory", amazonItemAttributes.ProductSubcategory);
                Assert.AreEqual("ManufacturerName", amazonItemAttributes.ManufacturerName);
                Assert.AreEqual(9.99m, amazonItemAttributes.Msrp);
                Assert.AreEqual("ecommercegenerickeywords", amazonItemAttributes.GenericKeywords);
                Assert.AreEqual("Size", amazonItemAttributes.Size);
                Assert.AreEqual("UpcOverride", amazonItemAttributes.UpcOverride);
            }

            #endregion // Assert

        }

        /// <summary>
        ///     Tests UpdateFxdBinLocInvAll is properly updating info in PS_FXD_BIN_LOC_INV
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateFxdBinLocInvAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                ItemGroup = "STICKER",
                ItemFamily = "OUCH"
            };

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertFxdBinLocInvAll(item, context);
                context.SaveChanges();
            }

            item.ItemGroup = "POSTER";
            item.ItemFamily = "FLAT";
            itemRepository.UpdateFxdBinLocInvAll(item);


            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<FxdBinLocInv> fxdBinLocInv = (from o in context.FxdBinLocInv select o).ToList();

                Assert.AreEqual("TRCN1", fxdBinLocInv[0].BusinessUnit);
                Assert.AreEqual("TEST1", fxdBinLocInv[0].InvItemId = item.ItemId);
                Assert.AreEqual(1, fxdBinLocInv[0].PickingOrder);
                Assert.AreEqual(0, fxdBinLocInv[0].QtyOptimal);
                Assert.AreEqual("PICK", fxdBinLocInv[0].StorageArea);
                Assert.AreEqual("10", fxdBinLocInv[0].StorLevel1);
                Assert.AreEqual("0", fxdBinLocInv[0].StorLevel2);
                Assert.AreEqual("", fxdBinLocInv[0].StorLevel3);
                Assert.AreEqual("", fxdBinLocInv[0].StorLevel4);
                Assert.AreEqual("EA", fxdBinLocInv[0].UnitOfMeasure);
                Assert.AreEqual("TRUS1", fxdBinLocInv[1].BusinessUnit);
            }

            #endregion // Assert


        }

        /// <summary>
        ///     Tests UpdateInvItems is properly updating info in PS_INV_ITEMS
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateInvItems_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1",
                TariffCode = "TarC",
                Description = "OG Description",
                Height = "1.1",
                Length = "2.1",
                Weight = "3.1",
                Width = "4.1",
                Upc = "OGUPC",
                Color = "TAN"
            };

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertInvItems(item, context);
                context.SaveChanges();
            }
            item.ItemId = "TEST1";
            item.TariffCode = "TariffCode";
            item.Description = "Description";
            item.Height = "11.1";
            item.Length = "12.1";
            item.Weight = "13.1";
            item.Width = "14.1";
            item.Upc = "UPC";
            item.Color = "RED";

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateInvItems(item, context);
                context.SaveChanges();
            }


            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                InvItems invItems = (from o in context.InvItems select o).FirstOrDefault();
                
                Assert.AreEqual("DESCRIPTION", invItems.Descr254); // item.Description.ToUpper()
                Assert.AreEqual("TariffCode", invItems.HarmonizedCd); // item.TariffCode
                Assert.AreEqual("RED", invItems.InvItemColor); // item.Color
                Assert.AreEqual(11.1m, invItems.InvItemHeight); // Convert.ToDecimal(item.Height)
                Assert.AreEqual("TEST1", invItems.InvItemId); // item.ItemId
                Assert.AreEqual(12.1m, invItems.InvItemLength); // Convert.ToDecimal(item.Length)
                Assert.AreEqual(13.1m, invItems.InvItemWeight); // Convert.ToDecimal(item.Weight)
                Assert.AreEqual(14.1m, invItems.InvItemWidth); // Convert.ToDecimal(item.Width)
                Assert.AreEqual("UPC", invItems.UpcId);
            }

            #endregion // Assert

        }

        /// <summary>
        ///     Tests UpdateItemAttribEx is properly updating info in PS_ITEM_ATTRIB_Ex
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateItemAttribEx_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                CasepackHeight = "12.1",
                CasepackLength = "13.2",
                CasepackQty = "7",
                CasepackUpc = "OGUPC",
                CasepackWidth = "11.3",
                CasepackWeight = "14.4",
                DirectImport = "N",
                // Duty = Duty,
                InnerpackHeight = "21.1",
                InnerpackLength = "22.2",
                InnerpackQuantity = "23",
                InnerpackUpc = "OGUPC2",
                InnerpackWeight = "24.3",
                InnerpackWidth = "25.4",
                LicenseBeginDate = "1/27/2015",
                ProductFormat = "ProdFor",
                ProductGroup = "ProdGr",
                ProductLine = "ProdLoi",
                SatCode = "CodeSat",
                SellOnTrends = "N",
                PrintOnDemand = "Y",
                // TranslateEdiProd = ReturnTranslateEdiProd(),
                ImagePath = "OGImagePath",
                AltImageFile1 = "OGAltImageFile1",
                AltImageFile2 = "OGAltImageFile2",
                AltImageFile3 = "OGAltImageFile3",
                AltImageFile4 = "OGAltImageFile4"
            };

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertItemAttribEx(item, context);
                context.SaveChanges();
            }

            item.CasepackHeight = "1.1";
            item.CasepackLength = "1.2";
            item.CasepackQty = "4";
            item.CasepackUpc = "UPC";
            item.CasepackWidth = "1.3";
            item.CasepackWeight = "1.4";
            item.DirectImport = "Y";
            item.Duty = item.Duty;
            item.InnerpackHeight = "2.1";
            item.InnerpackLength = "2.2";
            item.InnerpackQuantity = "2";
            item.InnerpackUpc = "UPC2";
            item.InnerpackWeight = "2.3";
            item.InnerpackWidth = "2.4";
            item.LicenseBeginDate = "4/17/2014";
            item.ProductFormat = "ProductFormat";
            item.ProductGroup = "ProductGroup";
            item.ProductLine = "ProductLine";
            item.SatCode = "SatCode";
            item.SellOnTrends = "Y";
            item.PrintOnDemand = "N";
            // item.TranslateEdiProd = item.ReturnTranslateEdiProd();
            item.ImagePath = "ImagePath";
            item.AltImageFile1 = "AltImageFile1";
            item.AltImageFile2 = "AltImageFile2";
            item.AltImageFile3 = "AltImageFile3";
            item.AltImageFile4 = "AltImageFile4";

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateItemAttribEx(item, context);
                context.SaveChanges();
            }


            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                ItemAttribEx itemAttribEx = (from o in context.ItemAttribEx select o).FirstOrDefault();

                Assert.AreEqual(1.1m, itemAttribEx.CasepackHeight);
                Assert.AreEqual(1.2m, itemAttribEx.CasepackLength);
                Assert.AreEqual(4, itemAttribEx.CasepackQty);
                Assert.AreEqual("UPC", itemAttribEx.CasepackUpc);
                Assert.AreEqual(1.3m, itemAttribEx.CasepackWidth);
                Assert.AreEqual(1.4m, itemAttribEx.CasepackWeight);
                Assert.AreEqual("Y", itemAttribEx.DirectImport);
                Assert.AreEqual("", itemAttribEx.Gtin);
                Assert.AreEqual(2.1m, itemAttribEx.InnerpackHeight);
                Assert.AreEqual(2.2m, itemAttribEx.InnerpackLength);
                Assert.AreEqual(2, itemAttribEx.InnerpackQty);
                Assert.AreEqual("UPC2", itemAttribEx.InnerpackUpc);
                Assert.AreEqual(2.3m, itemAttribEx.InnerpackWeight);
                Assert.AreEqual(2.4m, itemAttribEx.InnerpackWidth);
                Assert.AreEqual("TEST1", itemAttribEx.InvItemId);
                Assert.AreEqual("", itemAttribEx.BoxItemGroup);
                Assert.AreEqual("4/17/2014 12:00:00 AM", Convert.ToString(itemAttribEx.LicenseBeginDate));
                Assert.AreEqual("ProductFormat", itemAttribEx.ProdFormat);
                Assert.AreEqual("ProductGroup", itemAttribEx.ProdGroup);
                Assert.AreEqual("ProductLine", itemAttribEx.ProdLine);
                Assert.AreEqual("SatCode", itemAttribEx.SatCode);
                Assert.AreEqual("SHARE", itemAttribEx.Setid);
                Assert.AreEqual("Y", itemAttribEx.SellOnWeb);
                Assert.AreEqual("N", itemAttribEx.PrintOnDemand);
                // Assert.AreEqual(itemAttribEx.TranslateEdiProd = itemAttribEx.ReturnTranslateEdiProd());
                Assert.AreEqual("ImagePath", itemAttribEx.ImageFileName);
                Assert.AreEqual("AltImageFile1", itemAttribEx.AltImageFile1);
                Assert.AreEqual("AltImageFile2", itemAttribEx.AltImageFile2);
                Assert.AreEqual("AltImageFile3", itemAttribEx.AltImageFile3);
                Assert.AreEqual("AltImageFile4", itemAttribEx.AltImageFile4);
            }

            #endregion // Assert

        }

        /// <summary>
        ///     Tests UpdateItemWebInfo is properly updating info in PS_ITEM_WEB_INFO
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateItemWebInfo_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            GlobalData.ClearValues();

            GlobalData.WebCategoryList.Add("1", "Category1");
            GlobalData.WebCategoryList.Add("2", "Category2");
            GlobalData.WebCategoryList.Add("3", "Category3");
            GlobalData.WebCategoryList.Add("4", "Category4");
            GlobalData.WebCategoryList.Add("5", "Category5");

            ItemObject item = new ItemObject(1) { 
                ItemId = "TEST1",
                Active = 0,
                Category = "Category1",
                Category2 = "Category2",
                Category3 = "Category3",
                Copyright = "CRight",
                ImagePath = "IPath",
                InStockDate = "1991-01-01",
                ItemKeywords = "Keywordies",
                License = "LCENSE",
                MetaDescription = "MDESC",
                ProductQty = "1",
                Property = "PDiddy",
                ShortDescription = "Shorty",
                Size = "Sizzle",
                Title = "T-Itle"
            };

            #endregion // Assemble

            #region Act


            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertItemWebInfo(item, context);
                context.SaveChanges();
            }
                item.ItemId = "TEST1";
                item.Active = 1;
                item.Category = "Category4";
                item.Category2 = "Category5";
                item.Category3 = "Category1";
                item.Copyright = "Copyright";
                item.ImagePath = "ImagePath";
                item.InStockDate = "2/14/2015";
                item.ItemKeywords = "ItemKeywords";
                item.License = "License";
                item.MetaDescription = "MetaDescription";
                item.ProductQty = "4";
                item.Property = "Property";
                item.ShortDescription = "ShortDesc";
                item.Size = "Size";
                item.Title = "Title";
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                
                itemRepository.UpdateItemWebInfo(item, context);
                context.SaveChanges();
                
            }


            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                ItemWebInfo itemWebInfo = (from o in context.ItemWebInfo select o).FirstOrDefault();
                Assert.AreEqual(1m, itemWebInfo.Active);  //item.Active,
                Assert.AreEqual("", itemWebInfo.AttributeSet);  //"",
                Assert.AreEqual("4,5,1", itemWebInfo.Category);  //item.CombinedCategories,
                Assert.AreEqual("Copyright", itemWebInfo.Copyright);  //item.Copyright,
                Assert.AreEqual("ImagePath", itemWebInfo.ImagePath);  //item.ImagePath,
                Assert.AreEqual("2/14/2015 12:00:00 AM", Convert.ToString(itemWebInfo.InStockDate));  //Convert.ToDateTime(inStockDate),
                Assert.AreEqual("TEST1", itemWebInfo.InvItemId);  //item.ItemId,
                Assert.AreEqual("ItemKeywords", itemWebInfo.ItemKeywords);  //item.ItemKeywords,
                Assert.AreEqual("License", itemWebInfo.License);  //item.License,
                Assert.AreEqual("MetaDescription", itemWebInfo.MetaDescription);  //item.MetaDescription,
                Assert.AreEqual("0", itemWebInfo.Msrp);  //"0",
                Assert.AreEqual("", itemWebInfo.Newcategory);  //"",
                Assert.AreEqual("", itemWebInfo.NewDate);  //"",
                Assert.AreEqual("N", itemWebInfo.OnSite);  //"N",
                Assert.AreEqual("4", itemWebInfo.ProdQty);  //item.ProductQty,
                Assert.AreEqual("Property", itemWebInfo.Property);  //item.Property,
                Assert.AreEqual("ShortDesc", itemWebInfo.ShortDesc);  //item.ShortDescription,
                Assert.AreEqual("Size", itemWebInfo.Size);  //item.Size,
                Assert.AreEqual("Title", itemWebInfo.Title);  //item.Title
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests UpdateMasterItemTbl is properly updating info in PS_MASTER_ITEM_TBL
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateMasterItemTbl_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            GlobalData.ClearValues();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
            connectionManager.SetUseTrustedConnection(true);
            LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
            OdinContextFactory OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                Description = "This is a new description of more than 30 characters I hope.",
                CostProfileGroup = "CPG",
                ItemGroup = "ItemGroup",
                ItemFamily = "ItemFamily",
                ItemCategory = "ItemCategory1",
                PsStatus = "H"
            };
            GlobalData.ItemCategories.Add("1", "ItemCategory1");
            GlobalData.ItemCategories.Add("2", "ItemCategory2");

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertMasterItemTbl(item, context);
                context.SaveChanges();
            }
            
            item.Description = "This is a description of more than 30 characters I hope.";
            item.CostProfileGroup = "CP";
            item.ItemGroup = "ItemG";
            item.ItemFamily = "ItemF";
            item.ItemCategory = "ItemCategory2";
            item.PsStatus = "S";

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateMasterItemTbl(item, context);
                context.SaveChanges();
            }
            
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {

                MasterItemTbl masterItemTbl = (from o in context.MasterItemTbl select o).FirstOrDefault();
                
                Assert.AreEqual("CP", masterItemTbl.CmGroup);
                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE", masterItemTbl.Descr);
                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE THAN 30 CHARACTERS I HOPE.", masterItemTbl.Descr60);
                Assert.AreEqual("THIS IS A", masterItemTbl.Descrshort);
                Assert.AreEqual("ItemG", masterItemTbl.InvItemGroup);
                Assert.AreEqual("TEST1", masterItemTbl.InvItemId);
                Assert.AreEqual("ItemF", masterItemTbl.InvProdFamCd);
                Assert.AreEqual("S", masterItemTbl.ItemFieldC2);
            }

            #endregion // Assert
        }

        /// <summary>
        ///     Tests UpdateNewDate is properly updating NEW_DATE field in PS_ITEM_WEB_INFO
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateNewDate_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1);
            string date = Convert.ToString(DateTime.Now.Date);
            item.ItemId = "TEST1";

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertItemWebInfo(item, context);
                context.SaveChanges();
            }

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateNewDate("TEST1");
                context.SaveChanges();
            }


            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                ItemWebInfo result = (from o in context.ItemWebInfo select o).FirstOrDefault();

                Assert.AreEqual(date, Convert.ToString(result.NewDate));
            }

            #endregion // Assert

        }

        /// <summary>
        ///     Tests UpdateOnSite is properly updating the ON_SITE flag in PS_ITEM_WEB_INFO
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateOnSite_ItemInfoShouldSave()
        {

            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1"
            };

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertItemWebInfo(item, context);
                context.SaveChanges();
            }

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateOnSite(item,"website");
                context.SaveChanges();
            }


            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                ItemWebInfo result = (from o in context.ItemWebInfo select o).FirstOrDefault();

                Assert.AreEqual("Y", result.OnSite);
            }

            #endregion // Assert

        }

        /// <summary>
        ///     Tests UpdateProdItem is properly updating info in PS_PROD_ITEM
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateProdItem_ItemInfoShouldSave()
        {

            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                Description = "This is an old description of more than 30 characters I hope.",
                Gpc = "CPG",
                Ean = "NAE",
                ItemCategory = "ItemCat",
                Isbn = "NBSi",
                StatsCode = "CodeStats",
                Udex = "Xedu"
            };

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertProdItem(item, context);
                context.SaveChanges();
            }
            item.Description = "This is a description of more than 30 characters I hope.";
            item.Gpc = "Gpc";
            item.Ean = "Ean";
            item.ItemCategory = "ItemCategory";
            item.Isbn = "Isbn";
            item.StatsCode = "StatsCode";
            item.Udex = "Udex";
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateProdItem(item, context);
                context.SaveChanges();
            }


            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                ProdItem prodItem = (from o in context.ProdItem select o).FirstOrDefault();

                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE", prodItem.Descr); //  DbUtil.Char30(item.Description).ToUpper()
                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE THAN 30 CHARACTERS I HOPE.", prodItem.Descr254); //  item.Description.ToUpper()
                Assert.AreEqual("TEST1", prodItem.InvItemId); //  item.ItemId
                // Assert.AreEqual(DateTime.Now, prodItem.Lastupddttm); //  DateTime.Now
                Assert.AreEqual("ItemCategory", prodItem.ProdCategory); //  item.ItemCategory
                Assert.AreEqual("Isbn", prodItem.ProdFieldC10A); //  item.Isbn
                Assert.AreEqual("Gpc", prodItem.ProdFieldC10C); //  item.Gpc
                Assert.AreEqual("Ean", prodItem.ProdFieldC30A); //  item.Ean
                Assert.AreEqual("StatsCode", prodItem.ProdFieldC30B); //  item.StatsCode
                Assert.AreEqual("Udex", prodItem.ProdFieldC30C); //  item.Udex
                Assert.AreEqual("TEST1", prodItem.ProductId); //  item.ItemId
                Assert.AreEqual("N", prodItem.ProductKitFlag); //  "N"
                Assert.AreEqual("TEST1", prodItem.TaxProductNbr); //  item.ItemId
            }

            #endregion // Assert

        }

        /// <summary>
        ///     Tests UpdateProdPgrpLnkAll is properly updating info in PS_PROD_PGRP_LNK
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateProdPgrpLnkAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                AccountingGroup = "AG",
                PricingGroup = "PG"
            };

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertProdPgrpLnkAll(item, context);
                context.SaveChanges();
            }
            item.AccountingGroup = "GA";
            item.PricingGroup = "GP";

            itemRepository.UpdateProdPgrpLnkAll(item);


            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<ProdPgrpLnk> prodPgrpLnk = (from o in context.ProdPgrpLnk select o).ToList();
                
                Assert.AreEqual("N", prodPgrpLnk[0].PrimaryFlag);
                Assert.AreEqual("N", prodPgrpLnk[0].PrimPrcFlag);
                Assert.AreEqual("ACCT", prodPgrpLnk[0].ProdGrpType);
                Assert.AreEqual("TEST1", prodPgrpLnk[0].ProductId);
                Assert.AreEqual("SHARE", prodPgrpLnk[0].Setid);

                Assert.AreEqual("Y", prodPgrpLnk[1].PrimPrcFlag);
                Assert.AreEqual("PRC", prodPgrpLnk[1].ProdGrpType);
                
            }

            #endregion // Assert


        }

        /// <summary>
        ///     Tests UpdateProdPriceAll is properly updating info in PS_PROD_PRICE
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateProdPriceAll_ItemInfoShouldSave()
        {

            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                ListPriceCad = "15.99",
                MsrpCad = "11.99",
                ListPriceMxn = "16.99",
                MsrpMxn = "11.99",
                ListPriceUsd = "17.99",
                Msrp = "11.99"
            };

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertProdPriceAll(item, context);
                context.SaveChanges();
            }
            
            item.ListPriceCad = "5.99";
            item.MsrpCad = "10.99";
            item.ListPriceMxn = "6.99";
            item.MsrpMxn = "12.99";
            item.ListPriceUsd = "7.99";
            item.Msrp = "14.99";

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateProdPriceAll(item, context);
                context.SaveChanges();
            }
            
            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<ProdPrice> prodPrice = (from o in context.ProdPrice select o).ToList();

                Assert.AreEqual("TRCN1", prodPrice[0].BusinessUnitIn);
                Assert.AreEqual("CAD", prodPrice[0].CurrencyCd);
                // Assert.AreEqual(DateTime.Now, prodPrice[0].DatetimeAdded);
                Assert.AreEqual(Convert.ToDateTime("1901-01-01"), prodPrice[0].Effdt);
                Assert.AreEqual("A", prodPrice[0].EffStatus);
                // Assert.AreEqual(DateTime.Now, prodPrice[0].Lastupddttm);
                Assert.AreEqual(5.99m, prodPrice[0].ListPrice);
                Assert.AreEqual(10.99m, prodPrice[0].MfgSugRtlPrc);
                Assert.AreEqual("", prodPrice[0].PricingFlag);
                Assert.AreEqual("TEST1", prodPrice[0].ProductId);
                Assert.AreEqual(0, prodPrice[0].RepairCost);
                Assert.AreEqual(0, prodPrice[0].ServiceCost);
                Assert.AreEqual("SHARE", prodPrice[0].Setid);
                Assert.AreEqual(0, prodPrice[0].UnitCost);
                Assert.AreEqual("EA", prodPrice[0].UnitOfMeasure);


                Assert.AreEqual("TRMX1", prodPrice[1].BusinessUnitIn);
                Assert.AreEqual("MXN", prodPrice[1].CurrencyCd);
                Assert.AreEqual(6.99m, prodPrice[1].ListPrice);
                Assert.AreEqual(12.99m, prodPrice[1].MfgSugRtlPrc);

                Assert.AreEqual("TRUS1", prodPrice[2].BusinessUnitIn);
                Assert.AreEqual("CAD", prodPrice[2].CurrencyCd);
                Assert.AreEqual(5.99m, prodPrice[2].ListPrice);
                Assert.AreEqual(10.99m, prodPrice[2].MfgSugRtlPrc);

                Assert.AreEqual("TRUS1", prodPrice[3].BusinessUnitIn);
                Assert.AreEqual("MXN", prodPrice[3].CurrencyCd);
                Assert.AreEqual(6.99m, prodPrice[3].ListPrice);
                Assert.AreEqual(12.99m, prodPrice[3].MfgSugRtlPrc);


                Assert.AreEqual("TRUS1", prodPrice[4].BusinessUnitIn);
                Assert.AreEqual("USD", prodPrice[4].CurrencyCd);
                Assert.AreEqual(7.99m, prodPrice[4].ListPrice);
                Assert.AreEqual(14.99m, prodPrice[4].MfgSugRtlPrc);
            }

            #endregion // Assert

        }

        /// <summary>
        ///     Tests UpdateProdPriceBuAll is properly inserting MXN rows when MXN list price is added to an existing item
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdateProdPriceBuAll_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1"
            };
            int OgCount;
            int newCount;

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertProdPriceBuAll(item, context);
                context.SaveChanges();
            }
            
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<ProdPriceBu> prodPriceBu = (from o in context.ProdPriceBu select o).ToList();
                OgCount = prodPriceBu.Count();
            }
            item.ListPriceMxn = "6";
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdateProdPriceBuAll(item, context);
                context.SaveChanges();
            }
            
            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                List<ProdPriceBu> prodPriceBu = (from o in context.ProdPriceBu select o).ToList();

                newCount = prodPriceBu.Count();
            }

            #endregion // Act

            #region Assert

            Assert.AreEqual(3, OgCount);
            Assert.AreEqual(5, newCount);

            #endregion // Assert
        }

        /// <summary>
        ///     Tests UpdatePurchItemAttr is properly updating info in PS_PURCH_ITEM_ATTR
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdatePurchItemAttr_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1)
            {
                ItemId = "TEST1",
                Description = "This is a new description of more than 30 characters I hope.",
                StandardCost = "19.99"
            };

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertPurchItemAttr(item, context);
                context.SaveChanges();
            }
            item.Description = "This is a description of more than 30 characters I hope.";
            item.StandardCost = "9.99";

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.UpdatePurchItemAttr(item, context);
                context.SaveChanges();
            }

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                PurchItemAttr purchItemAttr = (from o in context.PurchItemAttr select o).FirstOrDefault();
                
                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE", purchItemAttr.Descr);
                Assert.AreEqual("THIS IS A DESCRIPTION OF MORE THAN 30 CHARACTERS I HOPE.", purchItemAttr.Descr254Mixed);
                Assert.AreEqual("THIS IS A", purchItemAttr.Descrshort);
                Assert.AreEqual(9.99M, purchItemAttr.PriceList);
            }

            #endregion // Assert

        }

        /// <summary>
        ///     Tests UpdatePvItmCategory is properly updating info in PS_PVT_ITM_CATEGORY
        /// </summary>
        [TestMethod]
        public void ItemRepositoryTests_UpdatePvItmCategory_ItemInfoShouldSave()
        {
            #region Assemble

            DbHelpers.ClearDatabase();
            ItemRepository itemRepository = new ItemRepository(DbHelpers.GetContextFactory());
            GlobalData.ClearValues();
            OdinContextFactory OdinContextFactory = DbHelpers.GetContextFactory();
            ItemObject item = new ItemObject(1) {
                ItemId = "TEST1",
                ItemCategory = "Category2"
            };
            GlobalData.ItemCategories.Add("1", "Category1");
            GlobalData.ItemCategories.Add("2", "Category2");

            #endregion // Assemble

            #region Act

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                itemRepository.InsertPvItmCategory(item, context);
                context.SaveChanges();
            }

            item.ItemCategory = "Category1";

            itemRepository.UpdatePvItmCategory(item);

            #endregion // Act

            #region Assert

            using (OdinContext context = OdinContextFactory.CreateContext())
            {
                PvItmCategory pvItmCategory = (from o in context.PvItmCategory select o).FirstOrDefault();
                
                Assert.AreEqual("TEST1", pvItmCategory.InvItemId);
                Assert.AreEqual("1", pvItmCategory.CategoryId);
            }

            #endregion // Assert

        }



        #endregion // Update Tests

    }
}
