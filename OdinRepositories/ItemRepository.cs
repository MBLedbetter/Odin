using System;
using System.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using OdinModels;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;

namespace OdinRepositories
{
    public class ItemRepository : IItemRepository
    {

        #region Properties
               
        /// <summary>
        ///     Gets or sets the Database name
        /// </summary>
        private string DbName { get; set; }

        /// <summary>
        ///     Gets or sets the database password
        /// </summary>
        private string DbPassword { get; set; }

        /// <summary>
        ///     Gets or sets the database serverName
        /// </summary>
        private string DbServerName { get; set; }
        
        /// <summary>
        ///     Flag for if local test
        /// </summary>
        private bool IsLocalTest { get; set; }
        
        /// <summary>
        ///     Flag to check if test
        /// </summary>
        /// <returns></returns>
        public Boolean IsTest()
        {
            return false;
        }

        /// <summary>
        ///     Flag for if the repository has been assigned to the serve
        /// </summary>
        private bool repositoryAssigned = true;

        /// <summary>
        ///     Gets or sets the save progress value. Used to display progress of item saves.
        /// </summary>
        public string SaveProgress
        {
            get
            {
                return _saveProgress;
            }
            set
            {
                _saveProgress = value;
            }
        }        
        private string _saveProgress = string.Empty;
                
        #endregion // Properties

        #region Methods
                
        #region Compare Methods

        /// <summary>
        ///     Check for items with given UPC value
        /// </summary>
        /// <param name="UPC"></param>
        /// <returns>list of existing item Ids with matching UPCs</returns>
        public List<string> CheckDuplicateEcommerceUPCs(string UPC)
        {
            List<string> itemIds = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveEcommerceUPCs", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@upc", SqlDbType.VarChar).Value = UPC;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string value = Convert.ToString(reader["INV_ITEM_ID"]).Trim();
                    if (!string.IsNullOrEmpty(value))
                    {
                        itemIds.Add(value);
                    }
                }
                reader.Close();
            }
            return itemIds;
        }
        
        /// <summary>
        ///     Searches PS_ORD_LINE for any open orders (ORD_LINE_STATUS = P or O) with the given ItemId = CUSTOMER_ITEM_NBR
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>true if any open orders with Item Id exist</returns>
        public bool CheckOpenOrderLine(string itemId)
        {
            bool result = false;
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_CheckOrderLine", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = itemId;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    result = true;
                }
                reader.Close();
            }
            return result;
        }
        
        #endregion // Compare Methods

        #region Insert Methods

        /// <summary>
        ///     Inserts item information into all item tables
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool InsertAll(ObservableCollection<ItemObject> items)
        {
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName,DbName,DbPassword,IsLocalTest).GetConnection(IsLocalTest))
            {
                try
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        int count = 0;
                        foreach (ItemObject item in items)
                        {
                            count++;
                            // Table rows created on initial item Setup
                            if (item.Status == "Add")
                            {
                                InsertAssetItemAttr(item, sqlTransaction);
                                InsertBuItemsConfig(item, sqlTransaction);
                                InsertBuItemsInv(item, sqlTransaction);
                                InsertBuItemUtilCd(item, sqlTransaction);
                                InsertCmItemMethod(item, sqlTransaction);
                                InsertDefaultLocInv(item, sqlTransaction);
                                InsertFxdBinLocInv(item, sqlTransaction);
                                InsertInvItems(item, sqlTransaction);
                                InsertInvItemUom(item, sqlTransaction);
                                InsertItemAttribEx(item, sqlTransaction);
                                InsertItemCompliance(item, sqlTransaction);
                                InsertItemLanguage(item, sqlTransaction);
                                InsertItemTerritory(item, sqlTransaction);
                                InsertPlItemAttrib(item, sqlTransaction);
                                InsertProdPriceBu(item, sqlTransaction);
                                InsertProdUom(item, sqlTransaction);
                                InsertUomTypeInv(item, sqlTransaction);
                                InsertItemWebInfo(item, sqlTransaction);
                                InsertMasterItem(item, sqlTransaction);
                                InsertProdItem(item, sqlTransaction);
                                InsertProdPgrpLnk(item, sqlTransaction);
                                InsertProdPrice(item, sqlTransaction);
                                InsertPurchItemAttr(item, sqlTransaction);
                                InsertPvItmCategory(item, sqlTransaction);
                                InsertItemUpdateRecord(item, sqlTransaction);
                                InsertAllCustomerProductAttributes(item, sqlTransaction);
                                if (item.ProductIdTranslation.Count>0)
                                {
                                    InsertProductIdTranslation(item, sqlTransaction);
                                }
                                if (item.BillOfMaterials.Count > 0)
                                {
                                    InsertEnBomComps(item, sqlTransaction);
                                    InsertSfPrdnAreaIt(item.ItemId, sqlTransaction);
                                    InsertEnBomHeader(item, sqlTransaction);
                                }

                                // item.Ecommerce_CountryofOrigin = RetrieveEcommerceCountryOfOrigin(item.CountryOfOrigin, sqlTransaction);
                                InsertEcommerceValues(item, sqlTransaction);
                            }
                            else if (item.CheckUpdates())
                            {
                                if (item.BuItemsInvUpdate()) { InsertBuItemsInv(item, sqlTransaction); }
                                if (item.CmItemMethodUpdate()) { InsertCmItemMethod(item, sqlTransaction); }
                                if (item.FxdBinLocInvUpdate()) { InsertFxdBinLocInv(item, sqlTransaction); }
                                if (item.InvItemsUpdate()) { InsertInvItems(item, sqlTransaction); }
                                if (item.ItemAttribExUpdate()){ InsertItemAttribEx(item, sqlTransaction); }
                                if (item.ItemLanguageUpdate()) { InsertItemLanguage(item, sqlTransaction); }
                                if (item.ItemTerritoryUpdate()) { InsertItemTerritory(item, sqlTransaction); }
                                if (item.ItemWebInfoUpdate()) { InsertItemWebInfo(item, sqlTransaction); }
                                if (item.MasterItemUpdate()) { InsertMasterItem(item, sqlTransaction); }
                                if (item.ProdItemUpdate()) { InsertProdItem(item, sqlTransaction); }
                                if (item.ProdPgrpLnkUpdate()) { InsertProdPgrpLnk(item, sqlTransaction); }
                                if (item.ProdPriceUpdate()) { InsertProdPrice(item, sqlTransaction); }
                                if (item.ProdPriceBuUpdate()) { InsertProdPriceBu(item, sqlTransaction); }
                                if (item.PurchItemAttrUpdate()) { InsertPurchItemAttr(item, sqlTransaction); }
                                if (item.PvItmCategoryUpdate()) { InsertPvItmCategory(item, sqlTransaction); }
                                if (item.ProductIdTranslationUpdate)
                                {
                                    RemoveProductIdTranslation(item.ItemId);
                                    InsertProductIdTranslation(item, sqlTransaction);
                                }
                                if (item.SellOnFlagUpdate()) { InsertAllCustomerProductAttributes(item, sqlTransaction); }
                                if(item.EcommerceValuesUpdate())
                                {
                                    InsertEcommerceValues(item, sqlTransaction);
                                }
                                if (item.BillOfMaterialsUpdate)
                                {
                                    RemoveEnBomComps(item.ItemId, sqlTransaction);
                                    InsertEnBomComps(item, sqlTransaction);
                                    InsertSfPrdnAreaIt(item.ItemId, sqlTransaction);
                                    InsertEnBomHeader(item, sqlTransaction);
                                }
                            }
                            InsertItemUpdateRecord(item, sqlTransaction);
                            this.SaveProgress = count.ToString();
                        }
                        sqlTransaction.Commit();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    ErrorLog.LogError(ex.ToString());
                }
            }
            return false;
        }

        /// <summary>
        ///     Checks and inserts sellOn flags for each customer
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool InsertAllCustomerProductAttributes(ItemObject item, SqlTransaction transaction)
        {
            bool result = true;
            string customer = "";

            customer = RetrieveCustomerId("ALL POSTERS");
            result = InsertCustomerProductAttributes(item.ItemId, customer, item.SellOnAllPosters, transaction);
            if (!result) { return result; }

            customer = RetrieveCustomerId("AMAZON");
            result = InsertCustomerProductAttributes(item.ItemId, customer, item.SellOnAmazon, transaction);
            if (!result) { return result; }

            customer = RetrieveCustomerId("FANATICS");
            result = InsertCustomerProductAttributes(item.ItemId, customer, item.SellOnFanatics, transaction);
            if (!result) { return result; }

            customer = RetrieveCustomerId("HAYNEEDLE");
            result = InsertCustomerProductAttributes(item.ItemId, customer, item.SellOnHayneedle, transaction);
            if (!result) { return result; }
            
            customer = RetrieveCustomerId("TARGET");
            result = InsertCustomerProductAttributes(item.ItemId, customer, item.SellOnTarget, transaction);
            if (!result) { return result; }
           
            customer = RetrieveCustomerId("WALMART");
            result = InsertCustomerProductAttributes(item.ItemId, customer, item.SellOnWalmart, transaction);
            if (!result) { return result; }

            customer = RetrieveCustomerId("WAYFAIR");
            result = InsertCustomerProductAttributes(item.ItemId, customer, item.SellOnWayfair, transaction);
            return result;
        }

        /// <summary>
        ///     Inserts item info (ItemID) into PS_ASSET_ITEM_ATTR table.
        /// </summary>
        private bool InsertAssetItemAttr(ItemObject item, SqlTransaction transaction)
        {
            try
            {
            SqlCommand sqlCommand = new SqlCommand("Odin_InsertAssetItemAttr", transaction.Connection, transaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
            sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Insert Item info (ItemID) into PS_BU_ITEMS_CONFIG table x2
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        private bool InsertBuItemsConfig(ItemObject item, SqlTransaction transaction)
        {
            try
            {
            SqlCommand sqlCommand = new SqlCommand("Odin_InsertBuItemsConfig", transaction.Connection, transaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
            sqlCommand.Parameters.Add("@busUnit", SqlDbType.VarChar).Value = "TRUS1";
            sqlCommand.ExecuteNonQuery();

            SqlCommand sqlCommand2 = new SqlCommand("Odin_InsertBuItemsConfig", transaction.Connection, transaction);
            sqlCommand2.CommandType = CommandType.StoredProcedure;
            sqlCommand2.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
            sqlCommand2.Parameters.Add("@busUnit", SqlDbType.VarChar).Value = "TRCN1";
            sqlCommand2.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Insert Item info (Item ID, Country of Origin, MFG Source, DacCad, DacUsd) into PS_BU_ITEMS_INV table x2
        /// </summary>
        private bool InsertBuItemsInv(ItemObject item, SqlTransaction transaction)
        {
            try
            {
            SqlCommand sqlCommand = new SqlCommand("Odin_InsertBuItemsInv", transaction.Connection, transaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@businessUnit", SqlDbType.VarChar).Value = "TRCN1";
            sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
            sqlCommand.Parameters.Add("@COO", SqlDbType.VarChar).Value = item.CountryOfOrigin;
            sqlCommand.Parameters.Add("@mfg", SqlDbType.VarChar).Value = item.MfgSource;
            sqlCommand.Parameters.Add("@dac", SqlDbType.Decimal).Value = item.DefaultActualCostCad;
            sqlCommand.ExecuteNonQuery();

            SqlCommand sqlCommand2 = new SqlCommand("Odin_InsertBuItemsInv", transaction.Connection, transaction);
            sqlCommand2.CommandType = CommandType.StoredProcedure;
            sqlCommand2.Parameters.Add("@businessUnit", SqlDbType.VarChar).Value = "TRUS1";
            sqlCommand2.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
            sqlCommand2.Parameters.Add("@COO", SqlDbType.VarChar).Value = item.CountryOfOrigin;
            sqlCommand2.Parameters.Add("@mfg", SqlDbType.VarChar).Value = item.MfgSource;
            sqlCommand2.Parameters.Add("@dac", SqlDbType.Decimal).Value = item.DefaultActualCostUsd;
            sqlCommand2.ExecuteNonQuery();

            SqlCommand sqlCommand3 = new SqlCommand("Odin_InsertBuItemsInv", transaction.Connection, transaction);
            sqlCommand3.CommandType = CommandType.StoredProcedure;
            sqlCommand3.Parameters.Add("@businessUnit", SqlDbType.VarChar).Value = "TRMX1";
            sqlCommand3.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
            sqlCommand3.Parameters.Add("@COO", SqlDbType.VarChar).Value = item.CountryOfOrigin;
            sqlCommand3.Parameters.Add("@mfg", SqlDbType.VarChar).Value = item.MfgSource;
            sqlCommand3.Parameters.Add("@dac", SqlDbType.Decimal).Value = item.DefaultActualCostUsd;
            sqlCommand3.ExecuteNonQuery();
            return true;
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
    }
}

        /// <summary>
        /// Insert item info(itemId) into table PS_BU_ITEM_UTIL_CD x 2
        /// </summary>
        private bool InsertBuItemUtilCd(ItemObject item, SqlTransaction transaction)
        {
            try
            {
            SqlCommand sqlCommand = new SqlCommand("Odin_InsertBuItemUtilCd", transaction.Connection, transaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
            sqlCommand.Parameters.Add("@busUnit", SqlDbType.VarChar).Value = "TRCN1";
            sqlCommand.ExecuteNonQuery();

            SqlCommand sqlCommand2 = new SqlCommand("Odin_InsertBuItemUtilCd", transaction.Connection, transaction);
            sqlCommand2.CommandType = CommandType.StoredProcedure;
            sqlCommand2.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
            sqlCommand2.Parameters.Add("@busUnit", SqlDbType.VarChar).Value = "TRUS1";
            sqlCommand2.ExecuteNonQuery();
            return true;
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
    }
}

        /// <summary>
        ///     Inserts New Category into table
        /// </summary>
        /// <param name="category"></param>
        public bool InsertCategory(string category)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_InsertCategory", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@category", SqlDbType.VarChar).Value = category;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert item info(itemId, CostProfileGroup) into table PS_CM_ITEM_METHOD x2
        /// </summary>
        private bool InsertCmItemMethod(ItemObject item, SqlTransaction transaction)
        {
            string cmProfileId;
            if (item.CostProfileGroup == "ACTUAL_FIFO") { cmProfileId = "ACTFIFO"; }
            else cmProfileId = "MFGACTFIFO";
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertCmItemMethod", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@busUnit", SqlDbType.VarChar).Value = "TRCN1";
                sqlCommand.Parameters.Add("@cmProfileId", SqlDbType.VarChar).Value = cmProfileId;
                sqlCommand.ExecuteNonQuery();

                SqlCommand sqlCommand2 = new SqlCommand("Odin_InsertCmItemMethod", transaction.Connection, transaction);
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                sqlCommand2.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand2.Parameters.Add("@busUnit", SqlDbType.VarChar).Value = "TRUS1";
                sqlCommand2.Parameters.Add("@cmProfileId", SqlDbType.VarChar).Value = cmProfileId;
                sqlCommand2.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Insert rows into the PS_CUSTOMER_PRODUCT_ATTRIBUTES table. Set the flag for the given customer
        ///     to allow sales of the given item.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="customerId"></param>
        /// <param name="flag"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool InsertCustomerProductAttributes(string itemId, string customerId, string flag, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertCustomerProductAttributes", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = itemId;
                sqlCommand.Parameters.Add("@customerId", SqlDbType.VarChar).Value = customerId;
                sqlCommand.Parameters.Add("@sendInventoryFlag", SqlDbType.VarChar).Value = flag;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert item info(itemId) into table PS_DEFAULT_LOC_INV x2
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        private bool InsertDefaultLocInv(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertDefaultLocInv", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@busUnit", SqlDbType.VarChar).Value = "TRUS1";
                sqlCommand.ExecuteNonQuery();

                SqlCommand sqlCommand2 = new SqlCommand("Odin_InsertDefaultLocInv", transaction.Connection, transaction);
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                sqlCommand2.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand2.Parameters.Add("@busUnit", SqlDbType.VarChar).Value = "TRCN1";
                sqlCommand2.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Insert Ecommerce Value into Database
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        private bool InsertEcommerceValues(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertAmazon", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@asin", SqlDbType.VarChar).Value = item.Ecommerce_Asin;
                sqlCommand.Parameters.Add("@bullet1", SqlDbType.VarChar).Value = item.Ecommerce_Bullet1;
                sqlCommand.Parameters.Add("@bullet2", SqlDbType.VarChar).Value = item.Ecommerce_Bullet2;
                sqlCommand.Parameters.Add("@bullet3", SqlDbType.VarChar).Value = item.Ecommerce_Bullet3;
                sqlCommand.Parameters.Add("@bullet4", SqlDbType.VarChar).Value = item.Ecommerce_Bullet4;
                sqlCommand.Parameters.Add("@bullet5", SqlDbType.VarChar).Value = item.Ecommerce_Bullet5;
                sqlCommand.Parameters.Add("@components", SqlDbType.VarChar).Value = item.Ecommerce_Components;
                if (!string.IsNullOrEmpty(item.Ecommerce_Cost))
                {
                    sqlCommand.Parameters.Add("@cost", SqlDbType.VarChar).Value = item.Ecommerce_Cost;
                }
                sqlCommand.Parameters.Add("@countryOfOrigin", SqlDbType.VarChar).Value = item.Ecommerce_CountryofOrigin;
                sqlCommand.Parameters.Add("@externalID", SqlDbType.VarChar).Value = item.Ecommerce_ExternalId;
                sqlCommand.Parameters.Add("@externalIDType", SqlDbType.VarChar).Value = item.Ecommerce_ExternalIdType;
                sqlCommand.Parameters.Add("@imagePath1", SqlDbType.VarChar).Value = item.Ecommerce_ImagePath1;
                sqlCommand.Parameters.Add("@imagePath2", SqlDbType.VarChar).Value = item.Ecommerce_ImagePath2;
                sqlCommand.Parameters.Add("@imagePath3", SqlDbType.VarChar).Value = item.Ecommerce_ImagePath3;
                sqlCommand.Parameters.Add("@imagePath4", SqlDbType.VarChar).Value = item.Ecommerce_ImagePath4;
                sqlCommand.Parameters.Add("@imagePath5", SqlDbType.VarChar).Value = item.Ecommerce_ImagePath5;
                if (!string.IsNullOrEmpty(item.Ecommerce_ItemHeight))
                {
                    sqlCommand.Parameters.Add("@itemHeight", SqlDbType.VarChar).Value = item.Ecommerce_ItemHeight;
                }
                if (!string.IsNullOrEmpty(item.Ecommerce_ItemLength))
                {
                    sqlCommand.Parameters.Add("@itemLength", SqlDbType.VarChar).Value = item.Ecommerce_ItemLength;
                }
                sqlCommand.Parameters.Add("@itemName", SqlDbType.VarChar).Value = item.Ecommerce_ItemName;
                if (!string.IsNullOrEmpty(item.Ecommerce_ItemWeight))
                {
                    sqlCommand.Parameters.Add("@itemWeight", SqlDbType.VarChar).Value = item.Ecommerce_ItemWeight;
                }
                if (!string.IsNullOrEmpty(item.Ecommerce_ItemWidth))
                {
                    sqlCommand.Parameters.Add("@itemWidth", SqlDbType.VarChar).Value = item.Ecommerce_ItemWidth;
                }
                sqlCommand.Parameters.Add("@modelName", SqlDbType.VarChar).Value = item.Ecommerce_ModelName;
                if (!string.IsNullOrEmpty(item.Ecommerce_PackageHeight))
                {
                    sqlCommand.Parameters.Add("@packageHeight", SqlDbType.VarChar).Value = item.Ecommerce_PackageHeight;
                }
                if (!string.IsNullOrEmpty(item.Ecommerce_PackageLength))
                {
                    sqlCommand.Parameters.Add("@packageLength", SqlDbType.VarChar).Value = item.Ecommerce_PackageLength;
                }
                if (!string.IsNullOrEmpty(item.Ecommerce_PackageWeight))
                {
                    sqlCommand.Parameters.Add("@packageWeight", SqlDbType.VarChar).Value = item.Ecommerce_PackageWeight;
                }
                if (!string.IsNullOrEmpty(item.Ecommerce_PackageWidth))
                {
                    sqlCommand.Parameters.Add("@packageWidth", SqlDbType.VarChar).Value = item.Ecommerce_PackageWidth;
                }
                if (!string.IsNullOrEmpty(item.Ecommerce_PageQty))
                {
                    sqlCommand.Parameters.Add("@pageQty", SqlDbType.Int).Value = Convert.ToInt64(item.Ecommerce_PageQty);
                }
                else
                {
                    sqlCommand.Parameters.Add("@pageQty", SqlDbType.Int).Value = 0;
                }
                sqlCommand.Parameters.Add("@productCategory", SqlDbType.VarChar).Value = item.Ecommerce_ProductCategory;
                sqlCommand.Parameters.Add("@productDescription", SqlDbType.VarChar).Value = item.Ecommerce_ProductDescription;
                sqlCommand.Parameters.Add("@productSubcategory", SqlDbType.VarChar).Value = item.Ecommerce_ProductSubcategory;
                sqlCommand.Parameters.Add("@manufacturerName", SqlDbType.VarChar).Value = item.Ecommerce_ManufacturerName;

                if (!string.IsNullOrEmpty(item.Ecommerce_Msrp))
                {
                    sqlCommand.Parameters.Add("@msrp", SqlDbType.VarChar).Value = item.Ecommerce_Msrp;
                }
                sqlCommand.Parameters.Add("@searchTerms", SqlDbType.VarChar).Value = item.Ecommerce_SearchTerms.ToLower();
                sqlCommand.Parameters.Add("@size", SqlDbType.VarChar).Value = item.Ecommerce_Size;
                sqlCommand.Parameters.Add("@upc", SqlDbType.VarChar).Value = item.Ecommerce_Upc;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Inserts rows into PS_EN_BOM_COMPS for each bill of materials in item.BillOfMaterials
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        private bool InsertEnBomComps(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                foreach (ChildElement child in item.BillOfMaterials)
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_InsertEnBomComps", transaction.Connection, transaction);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                    sqlCommand.Parameters.Add("@componentId", SqlDbType.VarChar).Value = child.ItemId.Trim();
                    sqlCommand.Parameters.Add("@qty", SqlDbType.VarChar).Value = child.Qty;
                    sqlCommand.ExecuteNonQuery();
                    
                }
                return true;

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Inserts rows into PS_EN_BOM_COMPS for each bill of materials in item.BillOfMaterials
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        private bool InsertEnBomHeader(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                    SqlCommand sqlCommand = new SqlCommand("Odin_InserteEnBomHeader", transaction.Connection, transaction);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                    sqlCommand.Parameters.Add("@descr", SqlDbType.VarChar).Value = DbUtil.Char30(item.Description);
                    sqlCommand.Parameters.Add("@descShort", SqlDbType.VarChar).Value = DbUtil.Char10(item.Description);
                    sqlCommand.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert info(itemId) to table PS_FXD_BIN_LOC_INV x 2
        /// </summary>
        private bool InsertFxdBinLocInv(ItemObject item, SqlTransaction transaction)
        {
            string fpll1 = "0";
            if ((!string.IsNullOrEmpty(item.ItemGroup)) && (!string.IsNullOrEmpty(item.ItemFamily)))
            {
                if ((item.ItemGroup.ToUpper() == "POSTER") && (item.ItemFamily.ToUpper() == "FLAT"))
                {
                    fpll1 = "10";
                }
            }
            try
            { 
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertFxdBinLocInv", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@busUnit", SqlDbType.VarChar).Value = "TRCN1";
                sqlCommand.Parameters.Add("@fpll1", SqlDbType.VarChar).Value = fpll1;
                sqlCommand.ExecuteNonQuery();

                SqlCommand sqlCommand2 = new SqlCommand("Odin_InsertFxdBinLocInv", transaction.Connection, transaction);
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                sqlCommand2.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand2.Parameters.Add("@busUnit", SqlDbType.VarChar).Value = "TRUS1";
                sqlCommand2.Parameters.Add("@fpll1", SqlDbType.VarChar).Value = fpll1;
                sqlCommand2.ExecuteNonQuery();
                return true;
            }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    ErrorLog.LogError(ex.ToString());
                    return false;
            }
        }

        /// <summary>
        /// Insert item info(TariffCode, ItemColor, ItemHeight, ItemLength, ItemId, Description, ItemWeight, ItemWidth, Upc) and username to PS_INV_ITEMS
        /// </summary>
        private bool InsertInvItems(ItemObject item, SqlTransaction transaction)
        {
            try
            { 
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertInvItems", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@harmonizedCd", SqlDbType.VarChar).Value = item.TariffCode;
                sqlCommand.Parameters.Add("@itemColor", SqlDbType.VarChar).Value = item.Color;
                sqlCommand.Parameters.Add("@itemHeight", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.Height);
                sqlCommand.Parameters.Add("@itemLength", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.Length);
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@description", SqlDbType.VarChar).Value = item.Description.ToUpper();
                sqlCommand.Parameters.Add("@itemWeight", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.Weight);
                sqlCommand.Parameters.Add("@itemWidth", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.Width);
                sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand.Parameters.Add("@upc", SqlDbType.VarChar).Value = item.Upc;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert item info(item Id) and username to table PS_INV_ITEM_UOM
        /// </summary>
        private bool InsertInvItemUom(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertInvItemUom", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Insert item info(CasepackHeight, CasepackLength, CasepackWidth, CasepackQty, DirectImport, InnerpackHeight, InnterpackLength, 
        ///     InnerpackQty, InnerpackWidth, ItemId, LicenseBeginDate, ProductFormat, ProductGroup, ProductLine, SAT Code, SellOnAmazon, 
        ///     SellOnFanatics, SellOnWalmart, SellOnTarget) into table PS_ITEM_ATTRIB_EX
        /// </summary>
        private bool InsertItemAttribEx(ItemObject item, SqlTransaction transaction)
        {
            try
            { 
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertItemAttribEx", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@casepackHeight", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.CasepackHeight);
                sqlCommand.Parameters.Add("@casepackLength", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.CasepackLength);
                sqlCommand.Parameters.Add("@casepackQty", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.CasepackQty);
                sqlCommand.Parameters.Add("@casepackUpc", SqlDbType.VarChar).Value = item.CasepackUpc;
                sqlCommand.Parameters.Add("@casepackWidth", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.CasepackWidth);
                sqlCommand.Parameters.Add("@casepackWeight", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.CasepackWeight);
                sqlCommand.Parameters.Add("@directImport", SqlDbType.VarChar).Value = item.DirectImport;
                sqlCommand.Parameters.Add("@innerpackHeight", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.InnerpackHeight);
                sqlCommand.Parameters.Add("@innerpackLength", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.InnerpackLength);
                sqlCommand.Parameters.Add("@innerpackQty", SqlDbType.SmallInt).Value = DbUtil.ToDecimal(item.InnerpackQuantity);
                sqlCommand.Parameters.Add("@innerpackUpc", SqlDbType.VarChar).Value = item.InnerpackUpc;
                sqlCommand.Parameters.Add("@innerpackWidth", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.InnerpackWidth);
                sqlCommand.Parameters.Add("@innerpackWeight", SqlDbType.Decimal).Value = DbUtil.ToDecimal(item.InnerpackWeight);
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@satCode", SqlDbType.VarChar).Value = item.SatCode;
                sqlCommand.Parameters.Add("@printOnDemand", SqlDbType.VarChar).Value = item.PrintOnDemand;
                sqlCommand.Parameters.Add("@sellOnWeb", SqlDbType.VarChar).Value = item.SellOnTrends;
                sqlCommand.Parameters.Add("@translateEdiProd", SqlDbType.VarChar).Value = item.ReturnTranslateEdiProd();
                sqlCommand.Parameters.Add("@imageFileName", SqlDbType.VarChar).Value = item.ImagePath;
                sqlCommand.Parameters.Add("@altImageFileName1", SqlDbType.VarChar).Value = item.AltImageFile1;
                sqlCommand.Parameters.Add("@altImageFileName2", SqlDbType.VarChar).Value = item.AltImageFile2;
                sqlCommand.Parameters.Add("@altImageFileName3", SqlDbType.VarChar).Value = item.AltImageFile3;
                sqlCommand.Parameters.Add("@altImageFileName4", SqlDbType.VarChar).Value = item.AltImageFile4;
                if (!(string.IsNullOrEmpty(item.LicenseBeginDate)))
                {
                    sqlCommand.Parameters.Add("@licenseBeginDate", SqlDbType.VarChar).Value = Convert.ToDateTime(item.LicenseBeginDate);
                }
                sqlCommand.Parameters.Add("@prodFormat", SqlDbType.VarChar).Value = item.ProductFormat;
                sqlCommand.Parameters.Add("@prodGroup", SqlDbType.VarChar).Value = item.ProductGroup;
                sqlCommand.Parameters.Add("@prodLine", SqlDbType.VarChar).Value = item.ProductLine;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert item info(itemId) into table PS_ITEM_COMPLIANCE
        /// </summary>
        private bool InsertItemCompliance(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertItemCompliance", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Removes old values for item in PS_ITEM_LANGUAGE then inserts new language values into PS_ITEM_LANGUAGE
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        private bool InsertItemLanguage(ItemObject item, SqlTransaction transaction)
        {
            try
            { 
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertLanguage", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@language", SqlDbType.VarChar).Value = item.Language;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Removes old values for item in PS_ITEM_TERRITORY then inserts new territory values into PS_ITEM_TERRITORY
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        private bool InsertItemTerritory(ItemObject item, SqlTransaction transaction)
        {
            try
            { 
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertTerritory", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@territory", SqlDbType.VarChar).Value = item.Territory;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                return false;
            }
        }

        /// <summary>
        ///     Inserts item infor into ODIN_ITEM_UPDATE_RECORDS
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool InsertItemUpdateRecord(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertOdinUpdateRecords", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@itemInputStatus", SqlDbType.VarChar).Value = item.Status;
                sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand.Parameters.Add("@accountingGroup", SqlDbType.VarChar).Value = item.AccountingGroup;
                sqlCommand.Parameters.Add("@casepackHeight", SqlDbType.VarChar).Value = item.CasepackHeight;
                sqlCommand.Parameters.Add("@casepackLength", SqlDbType.VarChar).Value = item.CasepackLength;
                sqlCommand.Parameters.Add("@casepackQty", SqlDbType.VarChar).Value = item.CasepackQty;
                sqlCommand.Parameters.Add("@casepackUpc", SqlDbType.VarChar).Value = item.CasepackUpc;
                sqlCommand.Parameters.Add("@casepackWidth", SqlDbType.VarChar).Value = item.CasepackWidth;
                sqlCommand.Parameters.Add("@casepackWeight", SqlDbType.VarChar).Value = item.CasepackWeight;
                sqlCommand.Parameters.Add("@category", SqlDbType.VarChar).Value = item.Category;
                sqlCommand.Parameters.Add("@category2", SqlDbType.VarChar).Value = item.Category2;
                sqlCommand.Parameters.Add("@category3", SqlDbType.VarChar).Value = item.Category3;
                sqlCommand.Parameters.Add("@color", SqlDbType.VarChar).Value = item.Color;
                sqlCommand.Parameters.Add("@copyright", SqlDbType.VarChar).Value = item.Copyright;
                sqlCommand.Parameters.Add("@countryOfOrigin", SqlDbType.VarChar).Value = item.CountryOfOrigin;
                sqlCommand.Parameters.Add("@costProfileGroup", SqlDbType.VarChar).Value = item.CostProfileGroup;
                sqlCommand.Parameters.Add("@dacusd", SqlDbType.VarChar).Value = item.DefaultActualCostUsd;
                sqlCommand.Parameters.Add("@daccad", SqlDbType.VarChar).Value = item.DefaultActualCostCad;
                sqlCommand.Parameters.Add("@description", SqlDbType.VarChar).Value = item.Description;
                sqlCommand.Parameters.Add("@directImport", SqlDbType.VarChar).Value = item.DirectImport;
                sqlCommand.Parameters.Add("@duty", SqlDbType.VarChar).Value = item.Duty;
                sqlCommand.Parameters.Add("@ean", SqlDbType.VarChar).Value = item.Ean;
                sqlCommand.Parameters.Add("@gpc", SqlDbType.VarChar).Value = item.Gpc;
                sqlCommand.Parameters.Add("@height", SqlDbType.VarChar).Value = item.Height;
                sqlCommand.Parameters.Add("@imagePath", SqlDbType.VarChar).Value = item.ImagePath;
                sqlCommand.Parameters.Add("@innerpackHeight", SqlDbType.VarChar).Value = item.InnerpackHeight;
                sqlCommand.Parameters.Add("@innerpackLength", SqlDbType.VarChar).Value = item.InnerpackLength;
                sqlCommand.Parameters.Add("@innerpackQty", SqlDbType.VarChar).Value = item.InnerpackQuantity;
                sqlCommand.Parameters.Add("@innerpackUpc", SqlDbType.VarChar).Value = item.InnerpackUpc;
                sqlCommand.Parameters.Add("@innerpackWidth", SqlDbType.VarChar).Value = item.InnerpackWidth;
                sqlCommand.Parameters.Add("@innerpackWeight", SqlDbType.VarChar).Value = item.InnerpackWeight;
                sqlCommand.Parameters.Add("@inStockDate", SqlDbType.VarChar).Value = item.InStockDate;
                sqlCommand.Parameters.Add("@isbn", SqlDbType.VarChar).Value = item.Isbn;
                sqlCommand.Parameters.Add("@itemCategory", SqlDbType.VarChar).Value = item.ItemCategory;
                sqlCommand.Parameters.Add("@itemFamily", SqlDbType.VarChar).Value = item.ItemFamily;
                sqlCommand.Parameters.Add("@itemGroup", SqlDbType.VarChar).Value = item.ItemGroup;
                sqlCommand.Parameters.Add("@itemKeywords", SqlDbType.VarChar).Value = item.ItemKeywords;
                sqlCommand.Parameters.Add("@language", SqlDbType.VarChar).Value = item.Language;
                sqlCommand.Parameters.Add("@length", SqlDbType.VarChar).Value = item.Length;
                sqlCommand.Parameters.Add("@license", SqlDbType.VarChar).Value = item.License;
                sqlCommand.Parameters.Add("@licenseBeginDate", SqlDbType.VarChar).Value = item.LicenseBeginDate;
                sqlCommand.Parameters.Add("@listPriceCad", SqlDbType.VarChar).Value = item.ListPriceCad;
                sqlCommand.Parameters.Add("@listPriceUsd", SqlDbType.VarChar).Value = item.ListPriceUsd;
                sqlCommand.Parameters.Add("@listPriceMxn", SqlDbType.VarChar).Value = item.ListPriceMxn;
                sqlCommand.Parameters.Add("@metaDescription", SqlDbType.VarChar).Value = item.MetaDescription;
                sqlCommand.Parameters.Add("@mfgSource", SqlDbType.VarChar).Value = item.MfgSource;
                sqlCommand.Parameters.Add("@msrp", SqlDbType.VarChar).Value = item.Msrp;
                sqlCommand.Parameters.Add("@msrpCad", SqlDbType.VarChar).Value = item.MsrpCad;
                sqlCommand.Parameters.Add("@msrpMxn", SqlDbType.VarChar).Value = item.MsrpMxn;
                sqlCommand.Parameters.Add("@productFormat", SqlDbType.VarChar).Value = item.ProductFormat;
                sqlCommand.Parameters.Add("@productGroup", SqlDbType.VarChar).Value = item.ProductGroup;
                sqlCommand.Parameters.Add("@productIdTranslation", SqlDbType.VarChar).Value = item.ReturnProductIdTranslations();
                sqlCommand.Parameters.Add("@productLine", SqlDbType.VarChar).Value = item.ProductLine;
                sqlCommand.Parameters.Add("@productQty", SqlDbType.VarChar).Value = item.ProductQty;
                sqlCommand.Parameters.Add("@pricingGroup", SqlDbType.VarChar).Value = item.PricingGroup;
                sqlCommand.Parameters.Add("@printOnDemand", SqlDbType.VarChar).Value = item.PrintOnDemand;
                sqlCommand.Parameters.Add("@psStatus", SqlDbType.VarChar).Value = item.PsStatus;
                sqlCommand.Parameters.Add("@property", SqlDbType.VarChar).Value = item.Property;
                sqlCommand.Parameters.Add("@satCode", SqlDbType.VarChar).Value = item.SatCode;
                sqlCommand.Parameters.Add("@shortDesc", SqlDbType.VarChar).Value = item.ShortDescription;
                sqlCommand.Parameters.Add("@sellOnFanatics", SqlDbType.VarChar).Value = item.SellOnFanatics;
                sqlCommand.Parameters.Add("@sellOnHayneedle", SqlDbType.VarChar).Value = item.SellOnHayneedle;
                sqlCommand.Parameters.Add("@sellOnTarget", SqlDbType.VarChar).Value = item.SellOnTarget;
                sqlCommand.Parameters.Add("@sellOnWeb", SqlDbType.VarChar).Value = item.SellOnTrends;
                sqlCommand.Parameters.Add("@sellOnWalmart", SqlDbType.VarChar).Value = item.SellOnWalmart;
                sqlCommand.Parameters.Add("@sellOnWayfair", SqlDbType.VarChar).Value = item.SellOnWayfair;
                sqlCommand.Parameters.Add("@sellOnJet", SqlDbType.VarChar).Value ="";
                sqlCommand.Parameters.Add("@size", SqlDbType.VarChar).Value = item.Size;
                sqlCommand.Parameters.Add("@standardCost", SqlDbType.VarChar).Value = item.StandardCost;
                sqlCommand.Parameters.Add("@statsCode", SqlDbType.VarChar).Value = item.StatsCode;
                sqlCommand.Parameters.Add("@tariffCode", SqlDbType.VarChar).Value = item.TariffCode;
                sqlCommand.Parameters.Add("@territory", SqlDbType.VarChar).Value = item.Territory;
                sqlCommand.Parameters.Add("@title", SqlDbType.VarChar).Value = item.Title;
                sqlCommand.Parameters.Add("@udex", SqlDbType.VarChar).Value = item.Udex;
                sqlCommand.Parameters.Add("@upc", SqlDbType.VarChar).Value = item.Upc;
                sqlCommand.Parameters.Add("@weight", SqlDbType.VarChar).Value = item.Weight;
                sqlCommand.Parameters.Add("@width", SqlDbType.VarChar).Value = item.Width;
                sqlCommand.Parameters.Add("@a_AmazonActive", SqlDbType.VarChar).Value = item.SellOnAmazon;
                sqlCommand.Parameters.Add("@a_Asin", SqlDbType.VarChar).Value = item.Ecommerce_Asin;
                sqlCommand.Parameters.Add("@a_Bullet1", SqlDbType.VarChar).Value = item.Ecommerce_Bullet1;
                sqlCommand.Parameters.Add("@a_Bullet2", SqlDbType.VarChar).Value = item.Ecommerce_Bullet2;
                sqlCommand.Parameters.Add("@a_Bullet3", SqlDbType.VarChar).Value = item.Ecommerce_Bullet3;
                sqlCommand.Parameters.Add("@a_Bullet4", SqlDbType.VarChar).Value = item.Ecommerce_Bullet4;
                sqlCommand.Parameters.Add("@a_Bullet5", SqlDbType.VarChar).Value = item.Ecommerce_Bullet5;
                sqlCommand.Parameters.Add("@a_Components", SqlDbType.VarChar).Value = item.Ecommerce_Components;
                sqlCommand.Parameters.Add("@a_Cost", SqlDbType.VarChar).Value = item.Ecommerce_Cost;
                sqlCommand.Parameters.Add("@a_ExternalIdType", SqlDbType.VarChar).Value = item.Ecommerce_ExternalIdType;
                sqlCommand.Parameters.Add("@a_ExternalId", SqlDbType.VarChar).Value = item.Ecommerce_ExternalId;
                sqlCommand.Parameters.Add("@a_ImageUrl1", SqlDbType.VarChar).Value = item.Ecommerce_ImagePath1;
                sqlCommand.Parameters.Add("@a_ImageUrl2", SqlDbType.VarChar).Value = item.Ecommerce_ImagePath2;
                sqlCommand.Parameters.Add("@a_ImageUrl3", SqlDbType.VarChar).Value = item.Ecommerce_ImagePath3;
                sqlCommand.Parameters.Add("@a_ImageUrl4", SqlDbType.VarChar).Value = item.Ecommerce_ImagePath4;
                sqlCommand.Parameters.Add("@a_ImageUrl5", SqlDbType.VarChar).Value = item.Ecommerce_ImagePath5;
                sqlCommand.Parameters.Add("@a_ItemHeight", SqlDbType.VarChar).Value = item.Ecommerce_ItemHeight;
                sqlCommand.Parameters.Add("@a_ItemLength", SqlDbType.VarChar).Value = item.Ecommerce_ItemLength;
                sqlCommand.Parameters.Add("@a_ItemName", SqlDbType.VarChar).Value = item.Ecommerce_ItemName ;
                sqlCommand.Parameters.Add("@a_ItemWeight", SqlDbType.VarChar).Value = item.Ecommerce_ItemWeight;
                sqlCommand.Parameters.Add("@a_ItemWidth", SqlDbType.VarChar).Value = item.Ecommerce_ItemWidth;
                sqlCommand.Parameters.Add("@a_ModelName", SqlDbType.VarChar).Value = item.Ecommerce_ModelName;
                sqlCommand.Parameters.Add("@a_PackageLength", SqlDbType.VarChar).Value = item.Ecommerce_PackageLength;
                sqlCommand.Parameters.Add("@a_PackageHeight", SqlDbType.VarChar).Value = item.Ecommerce_PackageHeight;
                sqlCommand.Parameters.Add("@a_PackageWidth", SqlDbType.VarChar).Value = item.Ecommerce_PackageWidth;
                sqlCommand.Parameters.Add("@a_PageQty", SqlDbType.VarChar).Value = item.Ecommerce_PageQty;
                sqlCommand.Parameters.Add("@a_PackageWeight", SqlDbType.VarChar).Value = item.Ecommerce_PackageWeight;
                sqlCommand.Parameters.Add("@a_ProductCategory", SqlDbType.VarChar).Value = item.Ecommerce_ProductCategory;
                sqlCommand.Parameters.Add("@a_ProductDescription", SqlDbType.VarChar).Value = item.Ecommerce_ProductDescription;
                sqlCommand.Parameters.Add("@a_ProductSubcategory", SqlDbType.VarChar).Value = item.Ecommerce_ProductSubcategory;
                sqlCommand.Parameters.Add("@a_ManufacturerName", SqlDbType.VarChar).Value = item.Ecommerce_ManufacturerName;
                sqlCommand.Parameters.Add("@a_Msrp", SqlDbType.VarChar).Value = item.Ecommerce_Msrp;
                sqlCommand.Parameters.Add("@a_SearchTerms", SqlDbType.VarChar).Value = item.Ecommerce_SearchTerms;
                sqlCommand.Parameters.Add("@a_Size", SqlDbType.VarChar).Value = item.Ecommerce_Size;
                sqlCommand.Parameters.Add("@a_Upc", SqlDbType.VarChar).Value = item.Ecommerce_Upc;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                return false;
            }
        }

        /// <summary>
        /// Insert item info(language, territory, instockdate, itemKeywords, category, copyright, itemId, imagePath) into PS_ITEM_WEB_INFO
        /// </summary>
        private bool InsertItemWebInfo(ItemObject item, SqlTransaction transaction)
        {
            try
            { 
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertItemWebInfo", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@imagePath", SqlDbType.VarChar).Value = item.ImagePath;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@itemKeywords", SqlDbType.VarChar).Value = item.ItemKeywords;
                sqlCommand.Parameters.Add("@category", SqlDbType.VarChar).Value = item.CombinedCategories;
                sqlCommand.Parameters.Add("@property", SqlDbType.VarChar).Value = item.Property;
                sqlCommand.Parameters.Add("@copyright", SqlDbType.VarChar).Value = item.Copyright;
                sqlCommand.Parameters.Add("@title", SqlDbType.VarChar).Value = item.Title;
                sqlCommand.Parameters.Add("@active", SqlDbType.VarChar).Value = item.Active;
                sqlCommand.Parameters.Add("@license", SqlDbType.VarChar).Value = item.License;
                // sqlCommand.Parameters.Add("@attributeSet", SqlDbType.VarChar).Value = item.ProductType;
                sqlCommand.Parameters.Add("@shortDescription", SqlDbType.VarChar).Value = item.ShortDescription;
                sqlCommand.Parameters.Add("@metaDescription", SqlDbType.VarChar).Value = item.MetaDescription;
                sqlCommand.Parameters.Add("@prodQty", SqlDbType.VarChar).Value = item.ProductQty;
                sqlCommand.Parameters.Add("@size", SqlDbType.VarChar).Value = item.Size;
                if (!(string.IsNullOrEmpty(item.InStockDate)))
                {
                    sqlCommand.Parameters.Add("@inStockDate", SqlDbType.VarChar).Value = Convert.ToDateTime(item.InStockDate);
                }
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                return false;
            }
        }

        /// <summary>
        ///     Inserts License and property into Odin_Web_License
        /// </summary>
        /// <param name="category"></param>
        public bool InsertLicense(string license, string property)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_InsertLicense", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@license", SqlDbType.VarChar).Value = license;
                        sqlCommand.Parameters.Add("@property", SqlDbType.VarChar).Value = property;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert item info(ItemCategory, CostProfileGroup, Description, ItemGroup, ItemId, ItemFamily) and user name to PS_MASTER_ITEM_TBL
        /// </summary>
        private bool InsertMasterItem(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertMasterItemTbl", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemCategory", SqlDbType.VarChar).Value = item.ItemCategory;
                sqlCommand.Parameters.Add("@cmGroup", SqlDbType.VarChar).Value = item.CostProfileGroup;
                sqlCommand.Parameters.Add("@description", SqlDbType.VarChar).Value = item.Description.ToUpper();
                sqlCommand.Parameters.Add("@desc30", SqlDbType.VarChar).Value = DbUtil.Char30(item.Description).ToUpper();
                sqlCommand.Parameters.Add("@itemGroup", SqlDbType.VarChar).Value = item.ItemGroup;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@psStatus", SqlDbType.VarChar).Value = item.PsStatus;
                sqlCommand.Parameters.Add("@itemFamily", SqlDbType.VarChar).Value = item.ItemFamily;
                sqlCommand.Parameters.Add("@desc10", SqlDbType.VarChar).Value = DbUtil.Char10(item.Description).ToUpper();
                sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Inserts Meta Description into Odin_MetaDescription
        /// </summary>
        /// <param name="metaDescription"></param>
        /// <returns></returns>
        public bool InsertMetaDescription(string metaDescription)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_InsertMetaDescription", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@metaDescription", SqlDbType.VarChar).Value = metaDescription;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Inserts the new to date marking when the item was submitted to the website.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="transaction"></param>
        public bool InsertNewDate(string itemId)
        {
            DateTime thisDay = DateTime.Today;
            string newDate = thisDay.ToString("d");
            try
            { 
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName,DbName,DbPassword,IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                            SqlCommand sqlCommand = new SqlCommand("Odin_InsertNewDate", sqlTransaction.Connection, sqlTransaction);
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = itemId;
                            sqlCommand.Parameters.Add("@newDate", SqlDbType.VarChar).Value = newDate;
                            sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert item info(itemId) into table PS_PL_ITEM_ATTRIB x 2
        /// </summary>
        private bool InsertPlItemAttrib(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertPlItemAttrib", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@businessUnit", SqlDbType.VarChar).Value = "TRCN1";
                sqlCommand.ExecuteNonQuery();

                SqlCommand sqlCommand2 = new SqlCommand("Odin_InsertPlItemAttrib", transaction.Connection, transaction);
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                sqlCommand2.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand2.Parameters.Add("@businessUnit", SqlDbType.VarChar).Value = "TRUS1";
                sqlCommand2.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert item info(itemId, ProductCategory, StatsCode, Description, Isbn, Ean, Udex, Gpc) and user name to PS_PROD_Item
        /// </summary>
        private bool InsertProdItem(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertProdItem", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@prodCat", SqlDbType.VarChar).Value = item.ItemCategory;
                sqlCommand.Parameters.Add("@statsCode", SqlDbType.VarChar).Value = item.StatsCode;
                sqlCommand.Parameters.Add("@desc30", SqlDbType.VarChar).Value = DbUtil.Char30(item.Description).ToUpper();
                sqlCommand.Parameters.Add("@description", SqlDbType.VarChar).Value = item.Description.ToUpper();
                sqlCommand.Parameters.Add("@isbn", SqlDbType.VarChar).Value = item.Isbn;
                sqlCommand.Parameters.Add("@ean", SqlDbType.VarChar).Value = item.Ean;
                sqlCommand.Parameters.Add("@udex", SqlDbType.VarChar).Value = item.Udex;
                sqlCommand.Parameters.Add("@gpc", SqlDbType.VarChar).Value = item.Gpc;
                sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert item info(item id, accountingGroup) and userName into PS_PROD_PGRP_LNK
        /// </summary>
        private bool InsertProdPgrpLnk(ItemObject item, SqlTransaction transaction)
        {
            try
                {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertProdPgrpLnk", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@productGroup", SqlDbType.VarChar).Value = item.AccountingGroup.ToUpper();
                sqlCommand.Parameters.Add("@prodGroupType", SqlDbType.VarChar).Value = "ACCT";
                sqlCommand.Parameters.Add("@primPrcFlag", SqlDbType.VarChar).Value = "N";
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand.ExecuteNonQuery();

                if (!(string.IsNullOrEmpty(item.PricingGroup)))
                {
                    SqlCommand sqlCommand2 = new SqlCommand("Odin_InsertProdPgrpLnk", transaction.Connection, transaction);
                    sqlCommand2.CommandType = CommandType.StoredProcedure;
                    sqlCommand2.Parameters.Add("@productGroup", SqlDbType.VarChar).Value = item.PricingGroup.ToUpper();
                    sqlCommand2.Parameters.Add("@prodGroupType", SqlDbType.VarChar).Value = "PRC";
                    sqlCommand2.Parameters.Add("@primPrcFlag", SqlDbType.VarChar).Value = "Y";
                    sqlCommand2.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                    sqlCommand2.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                    sqlCommand2.ExecuteNonQuery();
                }
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert item info(product group, listPriceCad, listPriceUsd, item id) and username into PS_PROD_PRICE x 3
        /// </summary>
        private bool InsertProdPrice(ItemObject item, SqlTransaction transaction)
        {
            try
            { 
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertProdPrice", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@productGroup", SqlDbType.VarChar).Value = item.ProductGroup;
                sqlCommand.Parameters.Add("@listPrice", SqlDbType.VarChar).Value = item.ListPriceCad;
                sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@msrp", SqlDbType.VarChar).Value = DbUtil.AssignMsrp(item.MsrpCad, item.Msrp);
                sqlCommand.Parameters.Add("@ccd", SqlDbType.VarChar).Value = "CAD";
                sqlCommand.Parameters.Add("@bui", SqlDbType.VarChar).Value = "TRCN1";
                sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand.ExecuteNonQuery();

                SqlCommand sqlCommand4 = new SqlCommand("Odin_InsertProdPrice", transaction.Connection, transaction);
                sqlCommand4.CommandType = CommandType.StoredProcedure;
                sqlCommand4.Parameters.Add("@productGroup", SqlDbType.VarChar).Value = item.ProductGroup;
                sqlCommand4.Parameters.Add("@listPrice", SqlDbType.VarChar).Value = item.ListPriceCad;
                sqlCommand4.Parameters.Add("@productId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand4.Parameters.Add("@msrp", SqlDbType.VarChar).Value = DbUtil.AssignMsrp(item.MsrpCad, item.Msrp);
                sqlCommand4.Parameters.Add("@ccd", SqlDbType.VarChar).Value = "CAD";
                sqlCommand4.Parameters.Add("@bui", SqlDbType.VarChar).Value = "TRUS1";
                sqlCommand4.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand4.ExecuteNonQuery();

                SqlCommand sqlCommand2 = new SqlCommand("Odin_InsertProdPrice", transaction.Connection, transaction);
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                sqlCommand2.Parameters.Add("@productGroup", SqlDbType.VarChar).Value = item.ProductGroup;
                sqlCommand2.Parameters.Add("@listPrice", SqlDbType.VarChar).Value = item.ListPriceUsd;
                sqlCommand2.Parameters.Add("@productId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand2.Parameters.Add("@msrp", SqlDbType.VarChar).Value = Convert.ToDecimal(item.Msrp);
                sqlCommand2.Parameters.Add("@ccd", SqlDbType.VarChar).Value = "USD";
                sqlCommand2.Parameters.Add("@bui", SqlDbType.VarChar).Value = "TRUS1";
                sqlCommand2.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand2.ExecuteNonQuery();
                if (!(string.IsNullOrEmpty(item.ListPriceMxn)))
                {
                    SqlCommand sqlCommand3 = new SqlCommand("Odin_InsertProdPrice", transaction.Connection, transaction);
                    sqlCommand3.CommandType = CommandType.StoredProcedure;
                    sqlCommand3.Parameters.Add("@productGroup", SqlDbType.VarChar).Value = item.ProductGroup;
                    sqlCommand3.Parameters.Add("@listPrice", SqlDbType.VarChar).Value = item.ListPriceMxn;
                    sqlCommand3.Parameters.Add("@productId", SqlDbType.VarChar).Value = item.ItemId;
                    sqlCommand3.Parameters.Add("@msrp", SqlDbType.VarChar).Value = DbUtil.AssignMsrp(item.MsrpMxn, item.Msrp);
                    sqlCommand3.Parameters.Add("@ccd", SqlDbType.VarChar).Value = "MXN";
                    sqlCommand3.Parameters.Add("@bui", SqlDbType.VarChar).Value = "TRUS1";
                    sqlCommand3.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                    sqlCommand3.ExecuteNonQuery();

                    SqlCommand sqlCommand5 = new SqlCommand("Odin_InsertProdPrice", transaction.Connection, transaction);
                    sqlCommand5.CommandType = CommandType.StoredProcedure;
                    sqlCommand5.Parameters.Add("@productGroup", SqlDbType.VarChar).Value = item.ProductGroup;
                    sqlCommand5.Parameters.Add("@listPrice", SqlDbType.VarChar).Value = item.ListPriceMxn;
                    sqlCommand5.Parameters.Add("@productId", SqlDbType.VarChar).Value = item.ItemId;
                    sqlCommand5.Parameters.Add("@msrp", SqlDbType.VarChar).Value = DbUtil.AssignMsrp(item.MsrpMxn, item.Msrp);
                    sqlCommand5.Parameters.Add("@ccd", SqlDbType.VarChar).Value = "MXN";
                    sqlCommand5.Parameters.Add("@bui", SqlDbType.VarChar).Value = "TRMX1";
                    sqlCommand5.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                    sqlCommand5.ExecuteNonQuery();
                }
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert item info(item id) and user name into PS_PROD_PRICE_BU x 2
        /// </summary>
        private bool InsertProdPriceBu(ItemObject item, SqlTransaction transaction)
        {
            try
            {  
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertProdPriceBu", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@ccd", SqlDbType.VarChar).Value = "CAD";
                sqlCommand.Parameters.Add("@bui", SqlDbType.VarChar).Value = "TRCN1";
                sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand.ExecuteNonQuery();

                SqlCommand sqlCommand4 = new SqlCommand("Odin_InsertProdPriceBu", transaction.Connection, transaction);
                sqlCommand4.CommandType = CommandType.StoredProcedure;
                sqlCommand4.Parameters.Add("@productId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand4.Parameters.Add("@ccd", SqlDbType.VarChar).Value = "CAD";
                sqlCommand4.Parameters.Add("@bui", SqlDbType.VarChar).Value = "TRUS1";
                sqlCommand4.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand4.ExecuteNonQuery();

                SqlCommand sqlCommand2 = new SqlCommand("Odin_InsertProdPriceBu", transaction.Connection, transaction);
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                sqlCommand2.Parameters.Add("@productId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand2.Parameters.Add("@ccd", SqlDbType.VarChar).Value = "USD";
                sqlCommand2.Parameters.Add("@bui", SqlDbType.VarChar).Value = "TRUS1";
                sqlCommand2.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand2.ExecuteNonQuery();

                if (!(string.IsNullOrEmpty(item.ListPriceMxn)))
                {
                    SqlCommand sqlCommand3 = new SqlCommand("Odin_InsertProdPriceBu", transaction.Connection, transaction);
                    sqlCommand3.CommandType = CommandType.StoredProcedure;
                    sqlCommand3.Parameters.Add("@productId", SqlDbType.VarChar).Value = item.ItemId;
                    sqlCommand3.Parameters.Add("@ccd", SqlDbType.VarChar).Value = "MXN";
                    sqlCommand3.Parameters.Add("@bui", SqlDbType.VarChar).Value = "TRUS1";
                    sqlCommand3.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                    sqlCommand3.ExecuteNonQuery();

                    SqlCommand sqlCommand5 = new SqlCommand("Odin_InsertProdPriceBu", transaction.Connection, transaction);
                    sqlCommand5.CommandType = CommandType.StoredProcedure;
                    sqlCommand5.Parameters.Add("@productId", SqlDbType.VarChar).Value = item.ItemId;
                    sqlCommand5.Parameters.Add("@ccd", SqlDbType.VarChar).Value = "MXN";
                    sqlCommand5.Parameters.Add("@bui", SqlDbType.VarChar).Value = "TRMX1";
                    sqlCommand5.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                    sqlCommand5.ExecuteNonQuery();
                }
                
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

        }

        /// <summary>
        ///     Insert a product id translation line into PS_MARKETPLACE_PRODUCT_TRANSLATIONS
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool InsertProductIdTranslation(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                foreach (ChildElement productIdTranslation in item.ProductIdTranslation)
                {
                    if (!string.IsNullOrEmpty(productIdTranslation.ItemId) && !string.IsNullOrEmpty(item.ItemId))
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_InsertProductIdTranslation", transaction.Connection, transaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@fromProductId", SqlDbType.VarChar).Value = item.ItemId;
                        sqlCommand.Parameters.Add("@toProductId", SqlDbType.VarChar).Value = productIdTranslation.ItemId.Trim();
                        sqlCommand.Parameters.Add("@qty", SqlDbType.Int).Value = productIdTranslation.Qty;
                        sqlCommand.Parameters.Add("@oprid", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Inserts item info(item id) and username into table PS_PROD_UOM
        /// </summary>
        private bool InsertProdUom(ItemObject item, SqlTransaction transaction)
        {
            try
            { 
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertProdUom", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@productId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Insert item info(Description, item id and standard cost) into PS_PURCH_ITEM_ATTR
        /// </summary>
        private bool InsertPurchItemAttr(ItemObject item, SqlTransaction transaction)
        {
            try
            { 
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertPurchItemAttr", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@desc30", SqlDbType.VarChar).Value = DbUtil.Char30(item.Description).ToUpper();
                sqlCommand.Parameters.Add("@desc10", SqlDbType.VarChar).Value = DbUtil.Char10(item.Description).ToUpper();
                sqlCommand.Parameters.Add("@description", SqlDbType.VarChar).Value = item.Description.ToUpper();
                sqlCommand.Parameters.Add("@stndrdCost", SqlDbType.Decimal).Value = Convert.ToDecimal(item.StandardCost);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Insert item info (itemId and item category) into PS_PV_ITM_Category table
        /// </summary>
        private bool InsertPvItmCategory(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertPvItmCategory", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@itemCategory", SqlDbType.VarChar).Value = item.ItemCategory;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                ErrorLog.LogError(e.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Inserts BOM header Value into PS_SF_PRDN_AREA_IT
        /// </summary>
        /// <param name="category"></param>
        public bool InsertSfPrdnAreaIt(string itemId, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertSfPrdnAreaIt", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = itemId;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Inserts Territory Value into Odin_Web_Territories
        /// </summary>
        /// <param name="category"></param>
        public bool InsertTerritory(string territory)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_InsertTerritory", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@territory", SqlDbType.VarChar).Value = territory;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Insert Item info (itemID) x 3 into PS_UOM_TYPE_INV
        /// </summary>
        private bool InsertUomTypeInv(ItemObject item, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertUomTypeInv", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand.Parameters.Add("@invUomType", SqlDbType.VarChar).Value = "ORDR";
                sqlCommand.ExecuteNonQuery();

                SqlCommand sqlCommand1 = new SqlCommand("Odin_InsertUomTypeInv", transaction.Connection, transaction);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                sqlCommand1.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand1.Parameters.Add("@invUomType", SqlDbType.VarChar).Value = "SHIP";
                sqlCommand1.ExecuteNonQuery();

                SqlCommand sqlCommand2 = new SqlCommand("Odin_InsertUomTypeInv", transaction.Connection, transaction);
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                sqlCommand2.Parameters.Add("@itemId", SqlDbType.VarChar).Value = item.ItemId;
                sqlCommand2.Parameters.Add("@invUomType", SqlDbType.VarChar).Value = "STCK";
                sqlCommand2.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        #endregion // Insert Methods

        #region Removal Methods

        /// <summary>
        ///     Removes category from Odin_NewWebCategories
        /// </summary>
        /// <param name="category">Category to be removed</param>
        public bool RemoveCategory(string category)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_RemoveCategory", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@category", SqlDbType.VarChar).Value = category.Trim();
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                ErrorLog.LogError(e.ToString());
                return false;
            }

        }

        /// <summary>
        ///     Removes category from Odin_RemoveEnBomComps
        /// </summary>
        /// <param name="category">item id of bom components to remove</param>
        public bool RemoveEnBomComps(string itemId, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RemoveEnBomComps", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = itemId.Trim();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("RemoveEnBomComps Failed: " + Convert.ToString(e));
                ErrorLog.LogError(e.ToString());
                return false;
            }

        }

        /// <summary>
        ///     Removes a License and all associted propertiesfrom Odin_Web_License
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool RemoveLicense(string value)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_RemoveLicense", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@license", SqlDbType.VarChar).Value = value;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                return false;
            }

        }

        /// <summary>
        ///     Removes a Meta Description from Odin_MetaDescription
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool RemoveMetaDescription(string value)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_RemoveMetaDescription", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@metaDescription", SqlDbType.VarChar).Value = value;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                return false;
            }
        }

        /// <summary>
        ///     Removes a property from Odin_Web_License
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool RemoveProperty(string value)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_RemoveProperty", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@property", SqlDbType.VarChar).Value = value;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                return false;
            }

        }

        /// <summary>
        ///     Removes the product id translations from PS_MARKETPLACE_PRODUCT_TRANSLATIONS for a given itemId
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool RemoveProductIdTranslation(string itemId)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_RemoveProductIdTranslation", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = itemId;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                return false;
            }

        }

        /// <summary>
        ///     Removes a territory from Odin_Web_Territories
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool RemoveTerritory(string value)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_RemoveTerritory", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@territory", SqlDbType.VarChar).Value = value;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                return false;
            }

        }
        
        /// <summary>
        ///     Removes an item from the test database
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool RemoveTestItem(string value)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, true).GetConnection(true))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_RemoveTestItem", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = value;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                return false;
            }

        }

        #endregion // Removal Methods
        
        /// <summary>
        ///     Returns the value of the save progress value
        /// </summary>
        /// <returns></returns>
        public string ReturnSaveProgress()
        {
            return this.SaveProgress;
        }

        /// <summary>
        ///     Check to determine if repository has been created for testing
        /// </summary>
        /// <returns></returns>
        public bool RepositoryAssigned()
        {
            return repositoryAssigned;
        }

        #region Retrieval Methods
        
        /// <summary>
        ///     Returns all items that fall within the given date range for the given customer
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<string> RetrieveActiveEcommerceItemIds(string startDate, string endDate, string productGroup, string customerName)
        {
            List<string> Values = new List<string>();
            string customerId = RetrieveCustomerId(customerName);
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveActiveEcommerceItemIds", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@startDate", SqlDbType.VarChar).Value = startDate;
                sqlCommand.Parameters.Add("@endDate", SqlDbType.VarChar).Value = endDate;
                sqlCommand.Parameters.Add("@productGroup", SqlDbType.VarChar).Value = productGroup;
                sqlCommand.Parameters.Add("@customerId", SqlDbType.VarChar).Value = customerId;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string itemId = Convert.ToString(reader["PRODUCT_ID"]).Trim();
                    Values.Add(itemId);
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Returns all items that fall within the given date range for the given customer
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public ObservableCollection<ItemObject> RetrieveActiveEcommerceItems(string startDate, string endDate, string productGroup, string customerName)
        {
            ObservableCollection<ItemObject> Values = new ObservableCollection<ItemObject>();
            string customerId = RetrieveCustomerId(customerName);
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveActiveEcommerceItems", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@startDate", SqlDbType.VarChar).Value = startDate;
                sqlCommand.Parameters.Add("@endDate", SqlDbType.VarChar).Value = endDate;
                sqlCommand.Parameters.Add("@productGroup", SqlDbType.VarChar).Value = productGroup;
                sqlCommand.Parameters.Add("@customerId", SqlDbType.VarChar).Value = customerId;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ItemObject item = new ItemObject();
                    item.ItemId = Convert.ToString(reader["INV_ITEM_ID"]).Trim();
                    item.CountryOfOrigin = Convert.ToString(reader["COUNTRY_OF_ORIGIN"]).Trim();
                    item.Ecommerce_ItemName = Convert.ToString(reader["ITEM_NAME"]).Trim();
                    item.Ecommerce_ModelName = Convert.ToString(reader["MODEL_NAME"]).Trim();
                    item.Ecommerce_ProductCategory = Convert.ToString(reader["PRODUCT_CATEGORY"]).Trim();
                    item.Ecommerce_ProductSubcategory = Convert.ToString(reader["PRODUCT_SUBCATEGORY"]).Trim();
                    item.Ecommerce_Asin = Convert.ToString(reader["ASIN"]).Trim();
                    item.Ecommerce_Bullet1 = Convert.ToString(reader["BULLET_1"]).Trim();
                    item.Ecommerce_Bullet2 = Convert.ToString(reader["BULLET_2"]).Trim();
                    item.Ecommerce_Bullet3 = Convert.ToString(reader["BULLET_3"]).Trim();
                    item.Ecommerce_Bullet4 = Convert.ToString(reader["BULLET_4"]).Trim();
                    item.Ecommerce_Bullet5 = Convert.ToString(reader["BULLET_5"]).Trim();
                    item.Ecommerce_ProductDescription = Convert.ToString(reader["FULL_DESCRIPTION"]).Trim();
                    item.Ecommerce_ExternalIdType = Convert.ToString(reader["EXTERNAL_ID_TYPE"]).Trim();
                    item.Ecommerce_ExternalId = Convert.ToString(reader["EXTERNAL_ID"]).Trim();
                    item.Ecommerce_SearchTerms = Convert.ToString(reader["SEARCH_TERMS"]).Trim();
                    item.Ecommerce_ImagePath1 = Convert.ToString(reader["IMAGE_URL_1"]).Trim();
                    item.Ecommerce_ImagePath2 = Convert.ToString(reader["IMAGE_URL_2"]).Trim();
                    item.Ecommerce_ImagePath3 = Convert.ToString(reader["IMAGE_URL_3"]).Trim();
                    item.Ecommerce_ImagePath4 = Convert.ToString(reader["IMAGE_URL_4"]).Trim();
                    item.Ecommerce_ImagePath5 = Convert.ToString(reader["IMAGE_URL_5"]).Trim();
                    item.Ecommerce_Size = Convert.ToString(reader["SIZE"]).Trim();
                    item.Ecommerce_Upc = Convert.ToString(reader["UPC_OVERRIDE"]).Trim();
                    item.Ecommerce_Cost = Convert.ToString(reader["COST"]).Trim();
                    item.Ecommerce_Msrp = Convert.ToString(reader["MSRP"]).Trim();
                    item.Ecommerce_ManufacturerName = Convert.ToString(reader["MANUFACTURER_NAME"]).Trim();
                    item.Ecommerce_CountryofOrigin = Convert.ToString(reader["COUNTRY_OF_ORIGIN"]).Trim();
                    item.Ecommerce_ItemLength = Convert.ToString(reader["LENGTH"]).Trim();
                    item.Ecommerce_ItemHeight = Convert.ToString(reader["HEIGHT"]).Trim();
                    item.Ecommerce_ItemWidth = Convert.ToString(reader["WIDTH"]).Trim();
                    item.Ecommerce_ItemWeight = Convert.ToString(reader["WEIGHT"]).Trim();
                    item.Ecommerce_PackageLength = Convert.ToString(reader["PACKAGE_LENGTH"]).Trim();
                    item.Ecommerce_PackageHeight = Convert.ToString(reader["PACKAGE_HEIGHT"]).Trim();
                    item.Ecommerce_PackageWidth = Convert.ToString(reader["PACKAGE_WIDTH"]).Trim();
                    item.Ecommerce_PackageWeight = Convert.ToString(reader["PACKAGE_WEIGHT"]).Trim();
                    item.Ecommerce_Components = Convert.ToString(reader["COMPONENTS"]).Trim();
                    item.License = Convert.ToString(reader["LICENSE"]).Trim();
                    item.Property = Convert.ToString(reader["PROPERTY"]).Trim();
                    Values.Add(item);
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Returns the coresponding value for the given key from the customerIdConversion list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string RetrieveCustomerId(string value)
        {
            foreach (KeyValuePair<string, string> x in GlobalData.CustomerIdConversions)
            {
                if (x.Key == value)
                {
                    return x.Value;
                }
            }
            return "";
        }

        /// <summary>
        ///     Selects all of the info for a given item from the db. If assigned type 2 only retrieves information from db not included in spreadsheet
        /// </summary>
        /// <param name="item"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public ItemObject RetrieveItem(string idInput, int row)
        {
            ItemObject item = new ItemObject();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_SelectItem", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = idInput;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    //remove the time from date values
                    string[] isdate = Convert.ToString(reader["IN_STOCK_DATE"]).Split(' ');
                    string[] lbDate = Convert.ToString(reader["LICENSE_BEGIN_DATE"]).Split(' ');
                    string accountingGroup = Convert.ToString(reader["ACCT_GRP"]);
                    string billOfMaterials = Convert.ToString(reader["BILL_OF_MATERIALS"]);
                    string altImageFile1 = Convert.ToString(reader["ALT_IMAGE_FILE_1"]);
                    string altImageFile2 = Convert.ToString(reader["ALT_IMAGE_FILE_2"]);
                    string altImageFile3 = Convert.ToString(reader["ALT_IMAGE_FILE_3"]);
                    string altImageFile4 = Convert.ToString(reader["ALT_IMAGE_FILE_4"]);
                    string casepackHeight = Convert.ToString(reader["CASEPACK_HEIGHT"]);
                    string casepackLength = Convert.ToString(reader["CASEPACK_LENGTH"]);
                    string casepackQty = Convert.ToString(reader["CASEPACK_QTY"]);
                    string casepackUpc = Convert.ToString(reader["CASEPACK_UPC"]);
                    string casepackWidth = Convert.ToString(reader["CASEPACK_WIDTH"]);
                    string casepackWeight = Convert.ToString(reader["CASEPACK_WEIGHT"]);
                    string category = Convert.ToString(reader["CATEGORY"]);
                    string color = Convert.ToString(reader["INV_ITEM_COLOR"]);
                    string copyright = Convert.ToString(reader["COPYRIGHT"]);
                    string countryOfOrigin = Convert.ToString(reader["COUNTRY_IST_ORIGIN"]);
                    string costProfileGroup = Convert.ToString(reader["CM_GROUP"]);
                    string description = DbUtil.FieldToString(reader["DESCR60"]);
                    string directImport = Convert.ToString(reader["DIRECT_IMPORT"]);
                    string defaultActualCostCad = DbUtil.FieldToString(reader["DACCAD"]);
                    string defaultActualCostUsd = DbUtil.FieldToString(reader["DACUSD"]);
                    string duty = Convert.ToString(reader["DUTY"]);
                    string ean = Convert.ToString(reader["PROD_FIELD_C30_A"]);
                    string gpc = Convert.ToString(reader["PROD_FIELD_C10_C"]);
                    string height = Convert.ToString(reader["INV_ITEM_HEIGHT"]);
                    string imagePath = Convert.ToString(reader["IMAGE_FILE_NAME"]);
                    string innerpackHeight = Convert.ToString(reader["INNERPACK_HEIGHT"]);
                    string innerpackLength = Convert.ToString(reader["INNERPACK_LENGTH"]);
                    string innerpackQuantity = Convert.ToString(reader["INNERPACK_QTY"]);
                    string innerpackUpc = Convert.ToString(reader["INNERPACK_UPC"]);
                    string innerpackWidth = Convert.ToString(reader["INNERPACK_WIDTH"]);
                    string innerpackWeight = Convert.ToString(reader["INNERPACK_WEIGHT"]);
                    string isbn = Convert.ToString(reader["PROD_FIELD_C10_A"]);
                    string itemFamily = Convert.ToString(reader["INV_PROD_FAM_CD"]);
                    string itemGroup = Convert.ToString(reader["INV_ITEM_GROUP"]);
                    string itemKeywords = Convert.ToString(reader["ITEM_KEYWORDS"]);
                    string language = Convert.ToString(reader["LANGUAGE"]);
                    string license = Convert.ToString(reader["LICENSE"]);
                    string licenseBeginDate = lbDate[0];
                    string listPriceUS = Convert.ToString(reader["LISTUS"]);
                    string listPriceCN = Convert.ToString(reader["LISTCN"]);
                    string listPriceMX = Convert.ToString(reader["LISTMX"]);
                    string length = Convert.ToString(reader["INV_ITEM_LENGTH"]);
                    string metaDescription = Convert.ToString(reader["META_DESCRIPTION"]);
                    string mfgSource = Convert.ToString(reader["MFG_SOURCE"]);
                    string msrp = Convert.ToString(reader["MSRP1"]);
                    string msrpCad = Convert.ToString(reader["MSRP2"]);
                    string msrpMxn = Convert.ToString(reader["MSRP3"]);
                    string newDate = Convert.ToString(reader["NEW_DATE"]);
                    string onSite = Convert.ToString(reader["ON_SITE"]);
                    string itemCategory = Convert.ToString(reader["PROD_CATEGORY"]);
                    string printOnDemand = Convert.ToString(reader["PRINT_ON_DEMAND"]);
                    string productFormat = Convert.ToString(reader["PROD_FORMAT"]);
                    string productGroup = Convert.ToString(reader["PROD_GROUP"]);
                    string productIdTranslation = Convert.ToString(reader["PRODUCT_ID_TRANSLATION"]);
                    string productType = Convert.ToString(reader["ATTRIBUTE_SET"]);
                    string productLine = Convert.ToString(reader["PROD_LINE"]);
                    string productQty = Convert.ToString(reader["PROD_QTY"]);
                    string property = Convert.ToString(reader["PROPERTY"]);
                    string pricingGroup = Convert.ToString(reader["PRC_GRP"]);
                    string psStatus = Convert.ToString(reader["PSSTATUS"]);
                    string satCode = Convert.ToString(reader["SAT_CODE"]);
                    string sellOnAllPosters = Convert.ToString(reader["SELL_ON_ALLPOSTERS"]);
                    string sellOnAmazon = Convert.ToString(reader["SELL_ON_AMAZON"]);
                    string sellOnFanatics = Convert.ToString(reader["SELL_ON_FANATICS"]);
                    string sellOnHayneedle = Convert.ToString(reader["SELL_ON_HAYNEEDLE"]);
                    string sellOnTarget = Convert.ToString(reader["SELL_ON_TARGET"]);
                    string sellOnWalmart = Convert.ToString(reader["SELL_ON_WALMART"]);
                    string sellOnWayfair = Convert.ToString(reader["SELL_ON_WAYFAIR"]);
                    string sellOnTrends = Convert.ToString(reader["SELL_ON_WEB"]);
                    string shortDescription = Convert.ToString(reader["SHORT_DESC"]);
                    string size = Convert.ToString(reader["SIZE"]);
                    string standardCost = Convert.ToString(reader["PRICE_LIST"]);
                    string statsCode = Convert.ToString(reader["PROD_FIELD_C30_B"]);
                    string status = "Update";
                    string tariffCode = Convert.ToString(reader["HARMONIZED_CD"]);
                    string territory = Convert.ToString(reader["TERRITORY"]);
                    string title = Convert.ToString(reader["TITLE"]);
                    string udex = Convert.ToString(reader["PROD_FIELD_C30_C"]);
                    string upc = Convert.ToString(reader["UPC_ID"]);
                    string weight = Convert.ToString(reader["INV_ITEM_WEIGHT"]);
                    string width = Convert.ToString(reader["INV_ITEM_WIDTH"]);
                    string inStockDate = isdate[0];
                    int active = Convert.ToInt32(reader["ACTIVE"]);
                    /* Ecommerce Fields */
                    string ecommerce_itemName = Convert.ToString(reader["A_ITEM_NAME"]);
                    string ecommerce_modelName = Convert.ToString(reader["A_MODEL_NAME"]);
                    string ecommerce_productCategory = Convert.ToString(reader["A_PRODUCT_CATEGORY"]);
                    string ecommerce_productSubcategory = Convert.ToString(reader["A_PRODUCT_SUBCATEGORY"]);
                    string ecommerce_asin = Convert.ToString(reader["A_ASIN"]);
                    string ecommerce_bullet1 = Convert.ToString(reader["A_BULLET_1"]);
                    string ecommerce_bullet2 = Convert.ToString(reader["A_BULLET_2"]);
                    string ecommerce_bullet3 = Convert.ToString(reader["A_BULLET_3"]);
                    string ecommerce_bullet4 = Convert.ToString(reader["A_BULLET_4"]);
                    string ecommerce_bullet5 = Convert.ToString(reader["A_BULLET_5"]);
                    string ecommerce_description = Convert.ToString(reader["A_FULL_DESCRIPTION"]);
                    string ecommerce_externalIdType = Convert.ToString(reader["A_EXTERNAL_ID_TYPE"]);
                    string ecommerce_externalId = Convert.ToString(reader["A_EXTERNAL_ID"]);
                    string ecommerce_searchTerms = Convert.ToString(reader["A_SEARCH_TERMS"]);
                    string ecommerce_imageUrl1 = Convert.ToString(reader["A_IMAGE_URL_1"]);
                    string ecommerce_imageUrl2 = Convert.ToString(reader["A_IMAGE_URL_2"]);
                    string ecommerce_imageUrl3 = Convert.ToString(reader["A_IMAGE_URL_3"]);
                    string ecommerce_imageUrl4 = Convert.ToString(reader["A_IMAGE_URL_4"]);
                    string ecommerce_imageUrl5 = Convert.ToString(reader["A_IMAGE_URL_5"]);
                    string ecommerce_size = Convert.ToString(reader["A_SIZE"]);
                    string ecommerce_upc = Convert.ToString(reader["A_UPC"]);
                    string ecommerce_cost = Convert.ToString(reader["A_COST"]);
                    string ecommerce_msrp = Convert.ToString(reader["A_MSRP"]);
                    string ecommerce_manufacturerName = Convert.ToString(reader["A_MANUFACTURER_NAME"]);
                    string ecommerce_countryOfOrigin = Convert.ToString(reader["A_COUNTRY_OF_ORIGIN"]);
                    string ecommerce_length = Convert.ToString(reader["A_LENGTH"]);
                    string ecommerce_height = Convert.ToString(reader["A_HEIGHT"]);
                    string ecommerce_width = Convert.ToString(reader["A_WIDTH"]);
                    string ecommerce_weight = Convert.ToString(reader["A_WEIGHT"]);
                    string ecommerce_packageLength = Convert.ToString(reader["A_PACKAGE_LENGTH"]);
                    string ecommerce_packageHeight = Convert.ToString(reader["A_PACKAGE_HEIGHT"]);
                    string ecommerce_packageWidth = Convert.ToString(reader["A_PACKAGE_WIDTH"]);
                    string ecommerce_pageQty = Convert.ToString(reader["A_PAGE_COUNT"]);
                    string ecommerce_packageWeight = Convert.ToString(reader["A_PACKAGE_WEIGHT"]);
                    string ecommerce_components = Convert.ToString(reader["A_COMPONENTS"]);

                    List<ChildElement> idTranslations = new List<ChildElement>();
                    if (!string.IsNullOrEmpty(productIdTranslation))
                    {
                        foreach (string x in productIdTranslation.Split(','))
                        {
                            string[] y = x.Split('&');
                            ChildElement idTranslation = new ChildElement(y[0], idInput, Convert.ToInt32(y[1]));
                            idTranslations.Add(idTranslation);
                        }
                    }
                    List<ChildElement> billOfMaterialsList = new List<ChildElement>();
                    if (!string.IsNullOrEmpty(billOfMaterials))
                    {
                        foreach (string x in billOfMaterials.Split(','))
                        {
                            string[] y = x.Split('&');
                            string num = y[1].Replace(".0000", "");

                            ChildElement billOfMaterial = new ChildElement(y[0].Trim(), idInput, Convert.ToInt32(num));
                            billOfMaterialsList.Add(billOfMaterial);
                        }
                    }
                    item = new ItemObject(
                                "Update",
                                altImageFile1,
                                altImageFile2,
                                altImageFile3,
                                altImageFile4,
                                sellOnAllPosters.Trim(),
                                sellOnAmazon.Trim(),
                                sellOnFanatics.Trim(),
                                sellOnHayneedle.Trim(),
                                sellOnTarget.Trim(),
                                sellOnTrends.Trim(),
                                sellOnWalmart.Trim(),
                                sellOnWayfair.Trim(),
                                ecommerce_asin.Trim(),
                                ecommerce_bullet1.Trim(),
                                ecommerce_bullet2.Trim(),
                                ecommerce_bullet3.Trim(),
                                ecommerce_bullet4.Trim(),
                                ecommerce_bullet5.Trim(),
                                ecommerce_components.Trim(),
                                DbUtil.ZeroTrim(ecommerce_cost.Trim(), 2),
                                ecommerce_externalId.Trim(),
                                ecommerce_externalIdType.Trim(),
                                ecommerce_imageUrl1.Trim(),
                                ecommerce_imageUrl2.Trim(),
                                ecommerce_imageUrl3.Trim(),
                                ecommerce_imageUrl4.Trim(),
                                ecommerce_imageUrl5.Trim(),
                                DbUtil.ZeroTrim(ecommerce_height.Trim(), 1),
                                DbUtil.ZeroTrim(ecommerce_length.Trim(), 1),
                                ecommerce_itemName.Trim(),
                                DbUtil.ZeroTrim(ecommerce_weight.Trim(), 1),
                                DbUtil.ZeroTrim(ecommerce_width.Trim(), 1),
                                ecommerce_modelName.Trim(),
                                DbUtil.ZeroTrim(ecommerce_packageHeight.Trim(), 1),
                                DbUtil.ZeroTrim(ecommerce_packageLength.Trim(), 1),
                                DbUtil.ZeroTrim(ecommerce_packageWeight.Trim(), 1),
                                DbUtil.ZeroTrim(ecommerce_packageWidth.Trim(), 1),
                                ecommerce_pageQty.Trim(),
                                ecommerce_productCategory.Trim(),
                                ecommerce_description.Trim(),
                                ecommerce_productSubcategory.Trim(),
                                ecommerce_manufacturerName.Trim(),
                                DbUtil.ZeroTrim(ecommerce_msrp.Trim(), 2),
                                ecommerce_searchTerms.Trim(),
                                ecommerce_size.Trim(),
                                ecommerce_upc.Trim(),
                                accountingGroup.Trim(),
                                billOfMaterialsList,
                                DbUtil.ZeroTrim(casepackHeight, 1),
                                DbUtil.ZeroTrim(casepackLength, 1),
                                casepackQty.Trim(),
                                casepackUpc.Trim(),
                                DbUtil.ZeroTrim(casepackWidth, 1),
                                DbUtil.ZeroTrim(casepackWeight, 1),
                                category,
                                "",
                                "",
                                color.Trim(),
                                copyright.Trim(),
                                countryOfOrigin.Trim(),
                                costProfileGroup.Trim(),
                                DbUtil.ZeroTrim(defaultActualCostUsd, 2),
                                DbUtil.ZeroTrim(defaultActualCostCad, 2),
                                description.Trim(),
                                directImport.Trim(),
                                duty.Trim(),
                                ean.Trim(),
                                gpc.Trim(),
                                DbUtil.ZeroTrim(height, 1),
                                imagePath.Trim(),
                                DbUtil.ZeroTrim(innerpackHeight, 1),
                                DbUtil.ZeroTrim(innerpackLength, 1),
                                innerpackQuantity.Trim(),
                                innerpackUpc.Trim(),
                                DbUtil.ZeroTrim(innerpackWidth, 1),
                                DbUtil.ZeroTrim(innerpackWeight, 1),
                                DbUtil.TrimDate(inStockDate),
                                isbn.Trim(),
                                itemCategory.Trim(),
                                itemFamily.Trim(),
                                itemGroup.Trim(),
                                idInput,
                                itemKeywords.Trim(),
                                language.Trim(),
                                DbUtil.ZeroTrim(length, 1),
                                license.Trim(),
                                DbUtil.TrimDate(licenseBeginDate),
                                DbUtil.ZeroTrim(listPriceCN.Trim(), 2),
                                DbUtil.ZeroTrim(listPriceUS.Trim(), 2),
                                DbUtil.ZeroTrim(listPriceMX.Trim(), 2),
                                metaDescription.Trim(),
                                mfgSource.Trim(),
                                DbUtil.ZeroTrim(msrp.Trim(), 2),
                                DbUtil.ZeroTrim(msrpCad.Trim(), 2),
                                DbUtil.ZeroTrim(msrpMxn.Trim(), 2),
                                productFormat.Trim(),
                                productGroup.Trim(),
                                idTranslations,
                                productLine.Trim(),
                                productQty.Trim(),
                                property.Trim(),
                                pricingGroup.Trim(),
                                printOnDemand.Trim(),
                                psStatus.Trim(),
                                satCode.Trim(),
                                shortDescription.Trim(),
                                size.Trim(),
                                standardCost.Trim(),
                                statsCode.Trim(),
                                tariffCode.Trim(),
                                territory.Trim(),
                                title.Trim(),
                                udex.Trim(),
                                upc.Trim(),
                                DbUtil.ZeroTrim(weight, 1),
                                DbUtil.ZeroTrim(width, 1)
                        );
                    item.OnSite = onSite;
                    item.Ecommerce_CountryofOrigin = ecommerce_countryOfOrigin;
                    item.Status = status;
                    item.ResetUpdate();
                    item.ItemRow = row;
                }
            }
            return item;
        }

        /// <summary>
        ///     Retrieves a list of search item values
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<SearchItem> RetrieveItemSearchResults(string value)
        {
            List<SearchItem> returnSearchItemList = new List<SearchItem>();

            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveItemSearchValues", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@value", SqlDbType.VarChar).Value = value;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    SearchItem searchItem = new SearchItem();
                    searchItem.ItemId = Convert.ToString(reader["INV_ITEM_ID"]).Trim();
                    searchItem.Description = Convert.ToString(reader["DESCR254"]).Trim();
                    returnSearchItemList.Add(searchItem);
                }
                reader.Close();
            }

            return returnSearchItemList;
        }

        /// <summary>
        ///     Retrieve a list of Item Objects relating to update records for the given item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<ItemObject> RetrieveItemUpdateRecords(string itemId)
        {
            List<ItemObject> items = new List<ItemObject>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveItemUpdateRecord", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = itemId;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string accountingGroup = Convert.ToString(reader["ACCOUNTING_GROUP"]);
                    string altImageFile1 = Convert.ToString(reader["ALT_IMAGE_FILE_1"]);
                    string altImageFile2 = Convert.ToString(reader["ALT_IMAGE_FILE_2"]);
                    string altImageFile3 = Convert.ToString(reader["ALT_IMAGE_FILE_3"]);
                    string altImageFile4 = Convert.ToString(reader["ALT_IMAGE_FILE_4"]);
                    string billOfMaterials = Convert.ToString(reader["BILL_OF_MATERIALS"]);
                    string casepackHeight = Convert.ToString(reader["CASEPACK_HEIGHT"]);
                    string casepackLength = Convert.ToString(reader["CASEPACK_LENGTH"]);
                    string casepackQty = Convert.ToString(reader["CASEPACK_QTY"]);
                    string casepackUpc = Convert.ToString(reader["CASEPACK_UPC"]);
                    string casepackWidth = Convert.ToString(reader["CASEPACK_WIDTH"]);
                    string casepackWeight = Convert.ToString(reader["CASEPACK_WEIGHT"]);
                    string category = Convert.ToString(reader["CATEGORY"]);
                    string category2 = Convert.ToString(reader["CATEGORY2"]);
                    string category3 = Convert.ToString(reader["CATEGORY3"]);
                    string color = Convert.ToString(reader["COLOR"]);
                    string copyright = Convert.ToString(reader["COPYRIGHT"]);
                    string countryOfOrigin = Convert.ToString(reader["COUNTRY_OF_ORIGIN"]);
                    string costProfileGroup = Convert.ToString(reader["COST_PROFILE_GROUP"]);
                    string description = DbUtil.FieldToString(reader["DESCRIPTION"]);
                    string directImport = Convert.ToString(reader["DIRECT_IMPORT"]);
                    string defaultActualCostCad = DbUtil.FieldToString(reader["DEFAULT_ACTUAL_COST_CAD"]);
                    string defaultActualCostUsd = DbUtil.FieldToString(reader["DEFAULT_ACTUAL_COST_USD"]);
                    string duty = Convert.ToString(reader["DUTY"]);
                    string ean = Convert.ToString(reader["EAN"]);
                    string gpc = Convert.ToString(reader["GPC"]);
                    string height = Convert.ToString(reader["HEIGHT"]);
                    string imagePath = Convert.ToString(reader["IMAGE_PATH"]);
                    string innerpackHeight = Convert.ToString(reader["INNERPACK_HEIGHT"]);
                    string innerpackLength = Convert.ToString(reader["INNERPACK_LENGTH"]);
                    string innerpackQuantity = Convert.ToString(reader["INNERPACK_QTY"]);
                    string innerpackUpc = Convert.ToString(reader["INNERPACK_UPC"]);
                    string innerpackWidth = Convert.ToString(reader["INNERPACK_WIDTH"]);
                    string innerpackWeight = Convert.ToString(reader["INNERPACK_WEIGHT"]);
                    string isbn = Convert.ToString(reader["ISBN"]);
                    string itemFamily = Convert.ToString(reader["ITEM_FAMILY"]);
                    string itemGroup = Convert.ToString(reader["ITEM_GROUP"]);
                    string itemKeywords = Convert.ToString(reader["ITEM_KEYWORDS"]);
                    string language = Convert.ToString(reader["LANGUAGE"]);
                    string license = Convert.ToString(reader["LICENSE"]);
                    string licenseBeginDate = DbUtil.TrimDate(reader["LICENSE_BEGIN_DATE"]);
                    string listPriceUS = Convert.ToString(reader["LIST_PRICE_USD"]);
                    string listPriceCN = Convert.ToString(reader["LIST_PRICE_CAD"]);
                    string listPriceMX = Convert.ToString(reader["LIST_PRICE_MXN"]);
                    string length = Convert.ToString(reader["LENGTH"]);
                    string metaDescription = Convert.ToString(reader["META_DESCRIPTION"]);
                    string mfgSource = Convert.ToString(reader["MFG_SOURCE"]);
                    string msrp = Convert.ToString(reader["MSRP"]);
                    string msrpCad = Convert.ToString(reader["MSRP_CAD"]);
                    string msrpMxn = Convert.ToString(reader["MSRP_MXN"]);
                    // string newDate = Convert.ToString(reader["NEW_DATE"]);
                    string itemCategory = Convert.ToString(reader["ITEM_CATEGORY"]);
                    string printOnDemand = Convert.ToString(reader["PRINT_ON_DEMAND"]);
                    string productFormat = Convert.ToString(reader["PRODUCT_FORMAT"]);
                    string productGroup = Convert.ToString(reader["PRODUCT_GROUP"]);
                    string productIdTranslation = Convert.ToString(reader["PRODUCT_ID_TRANSLATION"]);
                    // string productType = Convert.ToString(reader["ATTRIBUTE_SET"]);
                    string productLine = Convert.ToString(reader["PRODUCT_LINE"]);
                    string productQty = Convert.ToString(reader["PROD_QTY"]);
                    string property = Convert.ToString(reader["PROPERTY"]);
                    string pricingGroup = Convert.ToString(reader["PRICING_GROUP"]);
                    string psStatus = Convert.ToString(reader["PS_STATUS"]);
                    string satCode = Convert.ToString(reader["SAT_CODE"]);
                    string sellOnAllPosters = Convert.ToString(reader["SELL_ON_ALLPOSTERS"]);
                    string sellOnAmazon = Convert.ToString(reader["SELL_ON_AMAZON"]);
                    string sellOnFanatics = Convert.ToString(reader["SELL_ON_FANATICS"]);
                    string sellOnHayneedle = Convert.ToString(reader["SELL_ON_HAYNEEDLE"]);
                    string sellOnTarget = Convert.ToString(reader["SELL_ON_TARGET"]);
                    string sellOnWalmart = Convert.ToString(reader["SELL_ON_WALMART"]);
                    string sellOnWayfair = Convert.ToString(reader["SELL_ON_WAYFAIR"]);
                    string sellOnTrends = Convert.ToString(reader["SELL_ON_WEB"]);
                    string shortDescription = Convert.ToString(reader["SHORT_DESC"]);
                    string size = Convert.ToString(reader["SIZE"]);
                    string standardCost = Convert.ToString(reader["STANDARD_COST"]);
                    string statsCode = Convert.ToString(reader["STATS_CODE"]);
                    string status = Convert.ToString(reader["ITEM_INPUT_STATUS"]);
                    string tariffCode = Convert.ToString(reader["TARIFF_CODE"]);
                    string territory = Convert.ToString(reader["TERRITORY"]);
                    string title = Convert.ToString(reader["TITLE"]);
                    string udex = Convert.ToString(reader["UDEX"]);
                    string upc = Convert.ToString(reader["UPC"]);
                    string weight = Convert.ToString(reader["WEIGHT"]);
                    string width = Convert.ToString(reader["WIDTH"]);
                    // string inStockDate = isdate[0];
                    string inStockDate = DbUtil.TrimDate(reader["IN_STOCK_DATE"]);
                    string ecommerce_itemName = Convert.ToString(reader["A_ITEM_NAME"]);
                    string ecommerce_modelName = Convert.ToString(reader["A_MODEL_NAME"]);
                    string ecommerce_productCategory = Convert.ToString(reader["A_PRODUCT_CATEGORY"]);
                    string ecommerce_productSubcategory = Convert.ToString(reader["A_PRODUCT_SUBCATEGORY"]);
                    string ecommerce_asin = Convert.ToString(reader["A_ASIN"]);
                    string ecommerce_bullet1 = Convert.ToString(reader["A_BULLET_1"]);
                    string ecommerce_bullet2 = Convert.ToString(reader["A_BULLET_2"]);
                    string ecommerce_bullet3 = Convert.ToString(reader["A_BULLET_3"]);
                    string ecommerce_bullet4 = Convert.ToString(reader["A_BULLET_4"]);
                    string ecommerce_bullet5 = Convert.ToString(reader["A_BULLET_5"]);
                    string ecommerce_description = Convert.ToString(reader["A_PRODUCT_DESCRIPTION"]);
                    string ecommerce_externalIdType = Convert.ToString(reader["A_EXTERNAL_ID_TYPE"]);
                    string ecommerce_externalId = Convert.ToString(reader["A_EXTERNAL_ID"]);
                    string ecommerce_searchTerms = Convert.ToString(reader["A_SEARCH_TERMS"]);
                    string ecommerce_imageUrl1 = Convert.ToString(reader["A_IMAGE_URL_1"]);
                    string ecommerce_imageUrl2 = Convert.ToString(reader["A_IMAGE_URL_2"]);
                    string ecommerce_imageUrl3 = Convert.ToString(reader["A_IMAGE_URL_3"]);
                    string ecommerce_imageUrl4 = Convert.ToString(reader["A_IMAGE_URL_4"]);
                    string ecommerce_imageUrl5 = Convert.ToString(reader["A_IMAGE_URL_5"]);
                    string ecommerce_size = Convert.ToString(reader["A_SIZE"]);
                    string ecommerce_upc = Convert.ToString(reader["A_UPC"]);
                    string ecommerce_cost = Convert.ToString(reader["A_COST"]);
                    string ecommerce_msrp = Convert.ToString(reader["A_MSRP"]);
                    string ecommerce_manufacturerName = Convert.ToString(reader["A_MANUFACTURER_NAME"]);
                    // string ecommerce_countryOfOrigin = Convert.ToString(reader["A_COUNTRY_OF_ORIGIN"]);
                    string ecommerce_length = Convert.ToString(reader["A_ITEM_LENGTH"]);
                    string ecommerce_height = Convert.ToString(reader["A_ITEM_HEIGHT"]);
                    string ecommerce_width = Convert.ToString(reader["A_ITEM_WIDTH"]);
                    string ecommerce_weight = Convert.ToString(reader["A_ITEM_WEIGHT"]);
                    string ecommerce_packageLength = Convert.ToString(reader["A_PACKAGE_LENGTH"]);
                    string ecommerce_packageHeight = Convert.ToString(reader["A_PACKAGE_HEIGHT"]);
                    string ecommerce_packageWeight = Convert.ToString(reader["A_PACKAGE_WEIGHT"]);
                    string ecommerce_packageWidth = Convert.ToString(reader["A_PACKAGE_WIDTH"]);
                    string ecommerce_pageQty = Convert.ToString(reader["A_PAGE_COUNT"]);
                    string ecommerce_components = Convert.ToString(reader["A_COMPONENTS"]);
                    string userName = Convert.ToString(reader["USERNAME"]);
                    string recordDate = Convert.ToString(reader["INPUT_DATE"]);

                    List<ChildElement> idTranslations = new List<ChildElement>();
                    if (!string.IsNullOrEmpty(productIdTranslation))
                    {
                        foreach (string x in productIdTranslation.Split(','))
                        {
                            ChildElement idTranslation = new ChildElement(x, itemId);
                            idTranslations.Add(idTranslation);
                        }
                    }

                    List<ChildElement> billOfMaterialsList = new List<ChildElement>();
                    if (!string.IsNullOrEmpty(billOfMaterials))
                    {
                        foreach (string x in billOfMaterials.Split(','))
                        {
                            ChildElement billOfMaterial = new ChildElement(x, itemId);
                            billOfMaterialsList.Add(billOfMaterial);
                        }
                    }
                    ItemObject item = new ItemObject(
                                status,
                                altImageFile1,
                                altImageFile2,
                                altImageFile3,
                                altImageFile4,
                                sellOnAllPosters.Trim(),
                                sellOnAmazon.Trim(),
                                sellOnFanatics.Trim(),
                                sellOnHayneedle.Trim(),
                                sellOnTarget.Trim(),
                                sellOnTrends.Trim(),
                                sellOnWalmart.Trim(),
                                sellOnWayfair.Trim(),
                                ecommerce_asin.Trim(),
                                ecommerce_bullet1.Trim(),
                                ecommerce_bullet2.Trim(),
                                ecommerce_bullet3.Trim(),
                                ecommerce_bullet4.Trim(),
                                ecommerce_bullet5.Trim(),
                                ecommerce_components.Trim(),
                                DbUtil.ZeroTrim(ecommerce_cost.Trim(), 2),
                                ecommerce_externalId.Trim(),
                                ecommerce_externalIdType.Trim(),
                                ecommerce_imageUrl1.Trim(),
                                ecommerce_imageUrl2.Trim(),
                                ecommerce_imageUrl3.Trim(),
                                ecommerce_imageUrl4.Trim(),
                                ecommerce_imageUrl5.Trim(),
                                DbUtil.ZeroTrim(ecommerce_height.Trim(), 1),
                                DbUtil.ZeroTrim(ecommerce_length.Trim(), 1),
                                ecommerce_itemName.Trim(),
                                DbUtil.ZeroTrim(ecommerce_weight.Trim(), 1),
                                DbUtil.ZeroTrim(ecommerce_width.Trim(), 1),
                                ecommerce_modelName.Trim(),
                                DbUtil.ZeroTrim(ecommerce_packageHeight.Trim(), 1),
                                DbUtil.ZeroTrim(ecommerce_packageLength.Trim(), 1),
                                DbUtil.ZeroTrim(ecommerce_packageWeight.Trim(), 1),
                                DbUtil.ZeroTrim(ecommerce_packageWidth.Trim(), 1),
                                DbUtil.ZeroTrim(ecommerce_pageQty.Trim(), 1),
                                ecommerce_productCategory.Trim(),
                                ecommerce_description.Trim(),
                                ecommerce_productSubcategory.Trim(),
                                ecommerce_manufacturerName.Trim(),
                                DbUtil.ZeroTrim(ecommerce_msrp.Trim(), 2),
                                ecommerce_searchTerms.Trim(),
                                ecommerce_size.Trim(),
                                ecommerce_upc.Trim(),
                                accountingGroup.Trim(),
                                billOfMaterialsList,
                                DbUtil.ZeroTrim(casepackHeight, 1),
                                DbUtil.ZeroTrim(casepackLength, 1),
                                casepackQty.Trim(),
                                casepackUpc.Trim(),
                                DbUtil.ZeroTrim(casepackWidth, 1),
                                DbUtil.ZeroTrim(casepackWeight, 1),
                                category,
                                "",
                                "",
                                color.Trim(),
                                copyright.Trim(),
                                countryOfOrigin.Trim(),
                                costProfileGroup.Trim(),
                                DbUtil.ZeroTrim(defaultActualCostUsd, 2),
                                DbUtil.ZeroTrim(defaultActualCostCad, 2),
                                description.Trim(),
                                directImport.Trim(),
                                duty.Trim(),
                                ean.Trim(),
                                gpc.Trim(),
                                DbUtil.ZeroTrim(height, 1),
                                imagePath.Trim(),
                                DbUtil.ZeroTrim(innerpackHeight, 1),
                                DbUtil.ZeroTrim(innerpackLength, 1),
                                innerpackQuantity.Trim(),
                                innerpackUpc.Trim(),
                                DbUtil.ZeroTrim(innerpackWidth, 1),
                                DbUtil.ZeroTrim(innerpackWeight, 1),
                                DbUtil.TrimDate(inStockDate),
                                isbn.Trim(),
                                itemCategory.Trim(),
                                itemFamily.Trim(),
                                itemGroup.Trim(),
                                itemId,
                                itemKeywords.Trim(),
                                language.Trim(),
                                DbUtil.ZeroTrim(length, 1),
                                license.Trim(),
                                DbUtil.TrimDate(licenseBeginDate),
                                DbUtil.ZeroTrim(listPriceCN.Trim(), 2),
                                DbUtil.ZeroTrim(listPriceUS.Trim(), 2),
                                DbUtil.ZeroTrim(listPriceMX.Trim(), 2),
                                metaDescription.Trim(),
                                mfgSource.Trim(),
                                DbUtil.ZeroTrim(msrp.Trim(), 2),
                                DbUtil.ZeroTrim(msrpCad.Trim(), 2),
                                DbUtil.ZeroTrim(msrpMxn.Trim(), 2),
                                productFormat.Trim(),
                                productGroup.Trim(),
                                idTranslations,
                                productLine.Trim(),
                                productQty.Trim(),
                                property.Trim(),
                                pricingGroup.Trim(),
                                printOnDemand.Trim(),
                                psStatus.Trim(),
                                satCode.Trim(),
                                shortDescription.Trim(),
                                size.Trim(),
                                standardCost.Trim(),
                                statsCode.Trim(),
                                tariffCode.Trim(),
                                territory.Trim(),
                                title.Trim(),
                                udex.Trim(),
                                upc.Trim(),
                                DbUtil.ZeroTrim(weight, 1),
                                DbUtil.ZeroTrim(width, 1)
                        );
                    // item.Ecommerce_CountryofOrigin = ecommerce_countryOfOrigin;
                    item.UserName = userName;
                    item.RecordDate = recordDate;
                    item.Status = status;
                    items.Add(item);
                }
            }
            return items;
        }
        /// <summary>
        ///     Retrieves product format values from db
        /// </summary>
        /// <returns>list of product formats</returns>
        public List<string> RetrieveProductFormats(string productLine)
        {
            List<string> Values = new List<string>();
            Values.Add("");
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetProductFormats", sqlConnection);
                sqlCommand.Parameters.Add("@prodLine", SqlDbType.VarChar).Value = productLine;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string productFormat = Convert.ToString(reader["PROD_FORMAT"]).Trim();
                    if (Values.IndexOf(productFormat) == -1)
                    {
                        Values.Add(productFormat);
                    }
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieves list of property values
        /// </summary>
        /// <param name="license">license parent of desired properties. "" returns all properties</param>
        /// <returns></returns>
        public List<string> RetrievePropertyList(string license)
        {
            List<string> Values = new List<string>();
            Values.Add("");
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetPropertyList", sqlConnection);
                sqlCommand.Parameters.Add("@license", SqlDbType.VarChar).Value = license;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string property = Convert.ToString(reader["PROPERTY_RETURN"]).Trim();
                    if (Values.IndexOf(property) == -1)
                    {
                        Values.Add(property);
                    }
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Selects all of the info for a given item from the db. If assigned type 2 only retrieves information from db not included in spreadsheet
        /// </summary>
        /// <param name="item"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public ItemObject RetrieveWebsiteItem(string idInput)
        {
            ItemObject item = new ItemObject();
            item.ItemId = idInput;
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_SelectWebsiteItem", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = idInput;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    //remove the time from date values
                    string[] isdate = Convert.ToString(reader["IN_STOCK_DATE"]).Split(' ');
                    string[] lbDate = Convert.ToString(reader["LICENSE_BEGIN_DATE"]).Split(' ');
                    string category = Convert.ToString(reader["CATEGORY"]).Trim();
                    item.Copyright = Convert.ToString(reader["COPYRIGHT"]).Trim();
                    item.Height = DbUtil.ZeroTrim(Convert.ToString(reader["INV_ITEM_HEIGHT"]), 1);
                    item.ItemKeywords = Convert.ToString(reader["ITEM_KEYWORDS"]).Trim();
                    item.License = Convert.ToString(reader["LICENSE"]).Trim();
                    item.LicenseBeginDate = lbDate[0];
                    item.ListPriceUsd = DbUtil.ZeroTrim(Convert.ToString(reader["LISTUS"]), 2);
                    item.ListPriceCad = DbUtil.ZeroTrim(Convert.ToString(reader["LISTCN"]), 2);
                    item.Length = DbUtil.ZeroTrim(Convert.ToString(reader["INV_ITEM_LENGTH"]), 1);
                    item.MetaDescription = Convert.ToString(reader["META_DESCRIPTION"]).Trim();
                    item.Description = Convert.ToString(reader["DESCR254"]).Trim();
                    item.Msrp = DbUtil.ZeroTrim(Convert.ToString(reader["MSRP1"]), 2);
                    item.MsrpCad = DbUtil.ZeroTrim(Convert.ToString(reader["MSRP2"]), 2);
                    item.NewDate = Convert.ToString(reader["NEW_DATE"]).Trim();
                    item.ShortDescription = Convert.ToString(reader["SHORT_DESC"]).Trim();
                    item.Title = Convert.ToString(reader["TITLE"]).Trim();
                    item.Territory = Convert.ToString(reader["TERRITORY"]).Trim();
                    item.Language = Convert.ToString(reader["LANGUAGE"]).Trim();
                    item.Upc = Convert.ToString(reader["UPC_ID"]).Trim();
                    item.Weight = DbUtil.ZeroTrim(Convert.ToString(reader["INV_ITEM_WEIGHT"]), 1);
                    item.Width = DbUtil.ZeroTrim(Convert.ToString(reader["INV_ITEM_WIDTH"]), 1);
                    item.InStockDate = isdate[0];
                    item.Property = Convert.ToString(reader["PROPERTY"]).Trim();
                    item.ProductQty = Convert.ToString(reader["PROD_QTY"]).Trim();
                    item.ProductLine = Convert.ToString(reader["PROD_LINE"]).Trim();
                    item.Active = Convert.ToInt32(reader["ACTIVE"]);
                    item.Size = Convert.ToString(reader["SIZE"]).Trim();
                    item.OnSite = Convert.ToString(reader["ON_SITE"]);
                    if (string.IsNullOrEmpty(item.Title))
                    {
                        item.Title = DbUtil.FieldToString(reader["SHORT_DESC"]).Trim();
                    }

                    List<string> Categories = DbUtil.ParseCategories(category);
                    int catCount = 1;
                    foreach (string cat in Categories)
                    {
                        switch (catCount)
                        {
                            case 1:
                                item.Category = cat;
                                break;
                            case 2:
                                item.Category2 = cat;
                                break;
                            case 3:
                                item.Category3 = cat;
                                break;
                        }
                        catCount++;
                    }
                }
            }
            return item;
        }

        #endregion // Retrieval Methods



        #region Update Methods

        /// <summary>
        ///     Removes a category and all of it's aliases from the db
        /// </summary>
        /// <param name="category">Category to be removed</param>
        public bool UpdateCategory(string category, string oldCategory)
        {
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName,DbName,DbPassword,IsLocalTest).GetConnection(IsLocalTest))
            {
                using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_UpdateCategory", sqlTransaction.Connection, sqlTransaction);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@category", SqlDbType.VarChar).Value = category;
                    sqlCommand.Parameters.Add("@oldCategory", SqlDbType.VarChar).Value = oldCategory;
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
            }
            return true;
        }

        /// <summary>
        ///     Update the On Site flag for items that have been uploaded to trendsinternational.com
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public bool UpdateOnSite(string itemId)
        {
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_UpdateOnSite", sqlTransaction.Connection, sqlTransaction);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar).Value = itemId;
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
            }
            return true;
        }

        #endregion // Update Methods
        
        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the itemRepository
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbPassword"></param>
        /// <param name="dbServerName"></param>
        /// <param name="isLocalTest"></param>
        public ItemRepository(string dbName, string dbPassword, string dbServerName, bool isLocalTest)
        {
            this.DbServerName = dbServerName;
            this.DbName = dbName;
            this.DbPassword = dbPassword;
            this.IsLocalTest = isLocalTest;
        }

        #endregion // Constructor

    }
}
