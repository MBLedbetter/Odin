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
    public class CacheRepository
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the Database name
        /// </summary>
        private static string DbName { get; set; }

        /// <summary>
        ///     Gets or sets the database password
        /// </summary>
        private static string DbPassword { get; set; }

        /// <summary>
        ///     Gets or sets the database serverName
        /// </summary>
        private static string DbServerName { get; set; }

        /// <summary>
        ///     Flag for if local test
        /// </summary>
        private static bool IsLocalTest { get; set; }

        #endregion // Properties

        #region Methods

        /*
        #region Retrieval Methods
        
        /// <summary>
        ///     Retrieves Accounting Group values from DB
        /// </summary>
        /// <returns>List of Accounting Group values</returns>
        private static List<string> RetrieveAccountingtGroupList()
        {
            List<string> Values = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetAcctGroupList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string accountingGroup = Convert.ToString(reader["PRODUCT_GROUP"]).Trim();
                    if (Values.IndexOf(accountingGroup) == -1)
                    {
                        Values.Add(accountingGroup.Trim());
                    }
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieve and Organize all category/parent categories
        /// </summary>
        private static List<string> RetrieveWebsiteCategories()
        {
            List<string> values = new List<string>();
            values.Add("");
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetWebCategories", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string value = Convert.ToString(reader["CATEGORY"]);
                    if (!String.IsNullOrEmpty(value))
                    {
                        values.Add(value.Trim());
                    }
                }
                reader.Close();
            }
            return values;
        }

        /// <summary>
        ///     Retrieves a dictionary of categories and their coresponding ids
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> RetrieveCategoryList()
        {
            Dictionary<string, string> returnValues = new Dictionary<string, string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveCategoryList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string id = Convert.ToString(reader["ID"]).Trim();
                    string category = Convert.ToString(reader["CATEGOry"]).Trim();
                    if (!returnValues.ContainsKey(id))
                    {
                        returnValues.Add(id, category);
                    }
                }
                reader.Close();
            }
            return returnValues;
        }

        /// <summary>
        ///     Retrieves list of the Cost Profile Groups from the DB
        /// </summary>
        /// <returns>List of Cost Profile Groups</returns>
        private static List<string> RetrieveCostProfileGroups()
        {
            List<string> Values = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetPsCmGroupDefn", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string costProfileGroup = Convert.ToString(reader["CM_GROUP"]).Trim();
                    if (Values.IndexOf(costProfileGroup) == -1)
                    {
                        Values.Add(costProfileGroup.Trim());
                    }
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieves list of countries of origin from db
        /// </summary>
        /// <returns>List of countries of origin</returns>
        private static List<string> RetrieveCountriesOfOrigin()
        {
            List<string> Values = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetCountryTbl", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string countryOfOrigin = Convert.ToString(reader["Country"]).Trim();
                    if (Values.IndexOf(countryOfOrigin) == -1)
                    {
                        Values.Add(countryOfOrigin);
                    }
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Returns the full name of the country of origin abreviation
        /// </summary>
        /// <param name="value">Country of orign Abbreviation</param>
        /// <returns>Full Country of Origin Name</returns>
        private static Dictionary<string, string> RetrieveCountryOfOriginFull()
        {
            Dictionary<string, string> returnValues = new Dictionary<string, string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveCountryOfOriginFull", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string code = Convert.ToString(reader["COUNTRY"]).Trim();
                    string name = Convert.ToString(reader["DESCR"]).Trim();
                    if (!returnValues.ContainsKey(code))
                    {
                        returnValues.Add(code, name);
                    }
                }
                reader.Close();
            }
            return returnValues;
        }

        /// <summary>
        ///     Retrieves a key value pair list of customer names and their coresponding customer ID from the 
        ///     ODIN_CUSTOMER_CONVERSION table.
        /// </summary>
        /// <returns></returns>
        private static List<KeyValuePair<string, string>> RetrieveCustomerIdConversions()
        {
            List<KeyValuePair<string, string>> Values = new List<KeyValuePair<string, string>>();

            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveCustomerIdConversions", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string custName = Convert.ToString(reader["CUST_NAME"]).Trim();
                    string custId = Convert.ToString(reader["CORPORATE_CUST_ID"]).Trim();
                    Values.Add(new KeyValuePair<string, string>(custName, custId));
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Get list of appropriate External Id types for Amazon Products
        /// </summary>
        /// <returns>List of External Id Types</returns>
        private static List<string> RetrieveEcommerce_ExternalIdType()
        {
            List<string> Types = new List<string>();
            Types.Add("");
            Types.Add("ISBN");
            Types.Add("EAN");
            Types.Add("UPC");
            Types.Add("UPC (12-digits)");

            return Types;
        }

        /// <summary>
        ///     Retrieves a list of all ecommerce upc/item id key value pairs
        /// </summary>
        /// <param name="UPC"></param>
        /// <returns>list of existing item Ids with matching UPCs</returns>
        private static List<KeyValuePair<string, string>> RetrieveEcommerceUPCs()
        {
            List<KeyValuePair<string, string>> returnValues = new List<KeyValuePair<string, string>>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveEcommerceUPCs", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string itemId = Convert.ToString(reader["INV_ITEM_ID"]).Trim();
                    string upcId = Convert.ToString(reader["UPC_OVERRIDE"]).Trim();
                    returnValues.Add(new KeyValuePair<string, string>(upcId, itemId));
                }
                reader.Close();
            }
            return returnValues;
        }

        /// <summary>
        ///     Retrieves a List of exception values for a given field
        /// </summary>
        /// <param name="field">Field being granted the exception</param>
        /// <param name="exceptionTrigger">Field that exception looks to</param>
        /// <param name="exceptionResult">What the exception allows.</param>
        /// <returns></returns>
        private static List<string> RetrieveExceptions(string field, string exceptionTrigger, string exceptionResult)
        {
            List<string> exceptions = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveExceptions", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@field", SqlDbType.VarChar).Value = field;
                sqlCommand.Parameters.Add("@exceptionTrigger", SqlDbType.VarChar).Value = exceptionTrigger;
                sqlCommand.Parameters.Add("@exceptionResult", SqlDbType.VarChar).Value = exceptionResult;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    exceptions.Add(Convert.ToString(reader["EXCEPTION_VALUE"]).Trim());
                }
            }
            return exceptions;
        }

        /// <summary>
        ///     Retrieve list of InvItemGroups for dropdown and validation form
        /// </summary>
        /// <returns>List of InvItemGroup values</returns>
        private static List<string> RetrieveItemGroups()
        {
            List<string> Values = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetInvItemGroup", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string itemGroup = Convert.ToString(reader["INV_ITEM_GROUP"]).Trim();
                    if (Values.IndexOf(itemGroup) == -1)
                    {
                        Values.Add(itemGroup);
                    }
                }
                reader.Close();
            }
            return Values;
        }
        
        /// <summary>
        ///     Retrieves a list of all existing item ids
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static List<string> RetrieveItemIds()
        {
            List<string> itemIdList = new List<string>();

            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveItemIds", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string itemId = Convert.ToString(reader["INV_ITEM_ID"]).Trim();
                    itemIdList.Add(itemId);
                }
                reader.Close();
            }

            return itemIdList;
        }

        /// <summary>
        ///     Retrieves a list of user records
        /// </summary>
        /// <returns>List of user records</returns>
        private static List<ItemRecord> RetrieveItemRecords()
        {
            List<ItemRecord> records = new List<ItemRecord>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveItemRecords", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string itemId = Convert.ToString(reader["INV_ITEM_ID"]).Trim();
                    string inputDate = Convert.ToString(reader["INPUT_DATE"]).Trim();
                    string recordStatus = Convert.ToString(reader["ITEM_INPUT_STATUS"]).Trim();
                    string userName = Convert.ToString(reader["USERNAME"]).Trim();
                    ItemRecord record = new ItemRecord(inputDate, itemId, recordStatus, userName);
                    records.Add(record);
                }
                reader.Close();
            }
            return records;
        }
        

        /// <summary>
        ///     Retrieve list of available web languages
        /// </summary>
        /// <returns>List of web languages</returns>
        private static List<string> RetrieveLanguages()
        {
            List<string> Languages = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetWebLanguage", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string value = Convert.ToString(reader["LANGUAGE"]).Trim();
                    Languages.Add(value);
                }
                reader.Close();
            }
            return Languages;
        }

        /// <summary>
        ///     Retrieves list of web licenses for the dropdown selection 
        /// </summary>
        /// <returns>List of web licenses</returns>
        private static List<string> RetrieveLicenseList()
        {
            List<string> values = new List<string>();
            values.Add("");
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetWebLicense", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    values.Add(Convert.ToString(reader["LICENSE"]).Trim());
                }
                reader.Close();
            }
            return values;
        }

        /// <summary>
        ///     Retrieves List of Meta Descriptions
        /// </summary>
        /// <returns></returns>
        private static List<string> RetrieveMetaDescriptionList()
        {
            List<string> Values = new List<string>();
            Values.Add("");
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetMetaDescriptionList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Values.Add(Convert.ToString(reader["META_DESCRIPTION"]).Trim());
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieves Pricing Group values from DB
        /// </summary>
        /// <returns>List of Pricing Group values</returns>
        private static List<string> RetrievePriceGroupList()
        {
            List<string> Values = new List<string>();
            Values.Add("");
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetPriceGroupList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string pricingGroup = Convert.ToString(reader["PRODUCT_GROUP"]).Trim();
                    if (Values.IndexOf(pricingGroup) == -1)
                    {
                        Values.Add(pricingGroup);
                    }
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieves item category values form prodcatgrytabl for drop down options
        /// </summary>
        /// <returns>List of item category values</returns>
        private static List<string> RetrieveProductCategories()
        {
            List<string> Values = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetProdCatgryTbl", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string itemCategory = Convert.ToString(reader["PROD_CATEGORY"]).Trim();
                    if (Values.IndexOf(itemCategory) == -1)
                    {
                        Values.Add(itemCategory);
                    }
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieves product format values from db
        /// </summary>
        /// <returns>list of product formats</returns>
        private static List<ProductFormat> RetrieveProductFormatList()
        {
            List<ProductFormat> Values = new List<ProductFormat>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetProductFormatList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string productFormat = Convert.ToString(reader["PROD_FORMAT"]).Trim();
                    string productLine = Convert.ToString(reader["PROD_LINE"]).Trim();
                    string productGroup = Convert.ToString(reader["PROD_GROUP"]).Trim();
                    Values.Add(new ProductFormat(productFormat, productLine, productGroup));
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieves list of Product Groups
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private static List<string> RetrieveProductGroupList()
        {
            List<string> Values = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetProductGroups", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string productGroup = Convert.ToString(reader["PROD_GROUP"]).Trim();
                    if (Values.IndexOf(productGroup) == -1)
                    {
                        Values.Add(productGroup);
                    }
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieves list of Product Id Translations for a given item
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private static List<ChildElement> RetrieveProductIdTranslationList()
        {
            List<ChildElement> productIdTranslationReturn = new List<ChildElement>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveProductIdTranslationList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string TPID = Convert.ToString(reader["TO_PRODUCT_ID"]).Trim();
                    string FPID = Convert.ToString(reader["FROM_PRODUCT_ID"]).Trim();
                    int PQTY = Convert.ToInt32(reader["TO_QTY"]);
                    ChildElement productIdTranslation = new ChildElement(TPID, FPID, PQTY);
                    productIdTranslationReturn.Add(productIdTranslation);

                }
                reader.Close();
            }
            return productIdTranslationReturn;
        }

        /// <summary>
        ///     Retrieve list of all product lines from db.
        /// </summary>
        /// <returns>List of all product lines</returns>
        private static List<KeyValuePair<string, string>> RetrieveProductLines()
        {
            List<KeyValuePair<string, string>> Values = new List<KeyValuePair<string, string>>();

            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetAllProductLines", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string productLine = Convert.ToString(reader["PROD_LINE"]).Trim();
                    string productGroup = Convert.ToString(reader["PROD_GROUP"]).Trim();
                    Values.Add(new KeyValuePair<string, string>(productGroup, productLine));
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieve list of ps Statuses from db.
        /// </summary>
        /// <returns>List of product lines</returns>
        private static List<string> RetrievePsStatuses()
        {
            List<string> Values = new List<string>();
            Values.Add("");
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrievePsStatuses", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string psStatusId = Convert.ToString(reader["STATUS_CD"]).Trim();
                    Values.Add(psStatusId);
                }
                reader.Close();
            }
            Values.Sort();
            return Values;
        }

        /// <summary>
        ///     Retrieves a list of special characters that are not allowed for peoplesoft fields
        /// </summary>
        /// <returns>list of special characters</returns>
        private static List<string> RetrieveSpecialCharacters()
        {
            List<string> Values = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetSpecialCharacters", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string character = Convert.ToString(reader["CHARACTER"]).Trim();
                    Values.Add(character);
                }
                reader.Close();
            }
            return Values;
        }

        private static List<string> RetrieveRequestStatuses()
        {
            List<string> results = new List<string>();
            results.Add("Pending");
            results.Add("Completed");
            results.Add("Canceled");
            results.Add("Incomplete");
            return results;
        }

        /// <summary>
        ///     Retrieves all the Tariff Code values from the DB
        /// </summary>
        /// <returns>List of tarriff codes</returns>
        private static List<string> RetrieveTarriffCodeList()
        {
            List<string> Values = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetHrmnTariffCd", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string tariffCode = Convert.ToString(reader["HARMONIZED_CD"]).Trim();
                    if (Values.IndexOf(tariffCode) == -1)
                    {
                        Values.Add(tariffCode);
                    }
                }
                reader.Close();
            }
            Values.Sort();
            return Values;
        }

        /// <summary>
        ///     Retrieve list of available territories
        /// </summary>
        /// <returns>List of territories</returns>
        private static List<string> RetrieveTerritories()
        {
            List<string> Territories = new List<string>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetWebTerritory", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string value = Convert.ToString(reader["TERRITORY"]).Trim();
                    Territories.Add(value);
                }
                reader.Close();
            }
            Territories.Sort();
            return Territories;
        }

        /// <summary>
        ///     Retrieves a dictionary of all tool tips
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> RetrieveToolTips()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveToolTips", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = Convert.ToString(reader["NAME"]).Trim();
                        string value = Convert.ToString(reader["VALUE"]).Trim();
                        result.Add(name, value);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex.ToString());
            }
            return result;
        }

        /// <summary>
        ///     Retrieve a list of user names
        /// </summary>
        /// <returns></returns>
        private static List<string> RetrieveUserNames()
        {
            List<string> Values = new List<string>();
            Values.Add("");
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveUserNames", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string UserName = Convert.ToString(reader["UserName"]).Trim();
                    Values.Add(UserName);
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieve a list of user roles
        /// </summary>
        /// <returns></returns>
        private static List<string> RetrieveUserRoles()
        {
            List<string> Values = new List<string>();
            Values.Add("");
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetRolePermissionList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string RoleName = Convert.ToString(reader["Role"]).Trim();
                    if (!Values.Contains(RoleName))
                    {
                        Values.Add(RoleName);
                    }
                }
                reader.Close();
            }
            return Values;
        }

        /// <summary>
        ///     Retrieves a list of all existing upc / item id & ecommerceUpc / item id key value pairs
        /// </summary>
        /// <returns></returns>
        private static List<KeyValuePair<string, string>> RetrieveUpcAll()
        {
            List<KeyValuePair<string, string>> returnValues = RetrieveUpcs();
            returnValues.AddRange(RetrieveEcommerceUPCs());
            return returnValues;
        }

        /// <summary>
        ///     Retrieves a list of all existing upc / item id key value pairs
        /// </summary>
        /// <returns></returns>
        private static List<KeyValuePair<string, string>> RetrieveUpcs()
        {
            List<KeyValuePair<string, string>> returnValues = new List<KeyValuePair<string, string>>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveUpcAll", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string itemId = Convert.ToString(reader["INV_ITEM_ID"]).Trim();
                    string upcId = Convert.ToString(reader["UPC_ID"]).Trim();

                    returnValues.Add(new KeyValuePair<string, string>(upcId, itemId));
                }
                reader.Close();
            }
            return returnValues;
        }

        #endregion // Retrieval Methods
        */
        /*
        /// <summary>
        ///     Sets the Global Data Values
        /// </summary>
        public static void SetGlobalValues()
        {
            GlobalData.AccountingGroups = RetrieveAccountingtGroupList();
            GlobalData.CategoryList = RetrieveCategoryList();
            GlobalData.CostProfileGroups = RetrieveCostProfileGroups();
            GlobalData.CountriesOfOrigin = RetrieveCountriesOfOrigin();
            GlobalData.Customers = RetrieveCustomerIdConversions();
            GlobalData.CustomerIdConversions = RetrieveCustomerIdConversions();
            GlobalData.FullCountryOfOriginList = RetrieveCountryOfOriginFull();
            GlobalData.ExternalIdTypes = RetrieveEcommerce_ExternalIdType();
            GlobalData.ItemGroups = RetrieveItemGroups();
            GlobalData.ItemIds = RetrieveItemIds();
            GlobalData.ItemRecords = RetrieveItemRecords();
            GlobalData.Languages = RetrieveLanguages();
            GlobalData.Licenses = RetrieveLicenseList();
            GlobalData.MetaDescriptions = RetrieveMetaDescriptionList();
            GlobalData.ProductCategories = RetrieveProductCategories();
            GlobalData.ProductFormats = RetrieveProductFormatList();
            GlobalData.ProductGoups = RetrieveProductGroupList();
            GlobalData.ProductIdTranslationList = RetrieveProductIdTranslationList();
            GlobalData.ProductLines = RetrieveProductLines();
            GlobalData.PricingGroups = RetrievePriceGroupList();
            GlobalData.PsStatuses = RetrievePsStatuses();
            GlobalData.RequestStatus = RetrieveRequestStatuses();
            GlobalData.SpecialCharacters = RetrieveSpecialCharacters();
            GlobalData.TariffCodes = RetrieveTarriffCodeList();
            GlobalData.Territories = RetrieveTerritories();
            GlobalData.ToolTips = RetrieveToolTips();
            GlobalData.UpcProductFormatExceptions = RetrieveExceptions("UPC", "PRODUCT_FORMAT", "EMPTY UPC");
            GlobalData.Upcs = RetrieveUpcAll();
            GlobalData.UserNames = RetrieveUserNames();
            GlobalData.UserRoles = RetrieveUserRoles();
            GlobalData.WebCategories_Category = RetrieveWebsiteCategories();
            GlobalData.WebCategories_Category2 = RetrieveWebsiteCategories();
        }
        */
        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the CacheRepository. Responsible for retrieving all the initial cached values for Odin
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbPassword"></param>
        /// <param name="dbServerName"></param>
        /// <param name="isLocalTest"></param>
        public CacheRepository(string dbName, string dbPassword, string dbServerName, bool isLocalTest)
        {
            DbServerName = dbServerName;
            DbName = dbName;
            DbPassword = dbPassword;
            IsLocalTest = isLocalTest;
        }
        #endregion // Constructor
    }
}
