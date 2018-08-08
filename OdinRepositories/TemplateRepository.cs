using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OdinRepositories
{
    public class TemplateRepository : ITemplateRepository
    {
        #region Properties

        public Boolean IsTest()
        {
            return false;
        }

        private string DbServerName { get; set; }

        private string DbName { get; set; }

        private string DbPassword { get; set; }

        private bool IsLocalTest { get; set; }

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Inserts a column data into EXCEL_LAYOUT_DATA
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool InsertExcelLayoutColumn(ExcelCell value, SqlTransaction transaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_InsertExcelLayoutColumn", transaction.Connection, transaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@layoutId", SqlDbType.VarChar).Value = value.ExcelId;
                sqlCommand.Parameters.Add("@columnNumber", SqlDbType.Int).Value = Convert.ToInt32(value.ColumnNumber);
                sqlCommand.Parameters.Add("@field", SqlDbType.VarChar).Value = value.Field;
                sqlCommand.Parameters.Add("@option", SqlDbType.VarChar).Value = value.Option;
                sqlCommand.Parameters.Add("@customer", SqlDbType.VarChar).Value = value.Customer;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("InsertExcelLayoutColumn failed: " + ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Establish connection and run InsertExcelLayoutColumn foreach cell in list
        /// </summary>
        /// <param name="cellList"></param>
        /// <returns></returns>
        public bool InsertExcelLayoutColumns(ObservableCollection<ExcelCell> cellList)
        {
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                try
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        foreach (ExcelCell cell in cellList)
                        {
                            InsertExcelLayoutColumn(cell, sqlTransaction);
                        }
                        sqlTransaction.Commit();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("InsertExcelLayoutColumns failed: " + ex.ToString());
                    ErrorLog.LogError(ex.ToString());
                }
            }
            return false;
        }

        /// <summary>
        ///     Inserts a column data into ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <param name="layoutName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool InsertExcelLayout(int id, string layoutName, string customer, string productType)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_InsertExcelLayoutId", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@layoutId", SqlDbType.VarChar).Value = id;
                        sqlCommand.Parameters.Add("@layoutName", SqlDbType.VarChar).Value = layoutName;
                        sqlCommand.Parameters.Add("@customer", SqlDbType.VarChar).Value = customer;
                        sqlCommand.Parameters.Add("@productType", SqlDbType.VarChar).Value = productType;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("InsertExcelLayoutName failed: " + ex.ToString());
                ErrorLog.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Insert a template into the db
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public bool InsertTemplate(Template template)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_InsertTemplate", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@templateId", SqlDbType.VarChar).Value = template.TemplateId;
                        sqlCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = Environment.UserName.ToUpper();
                        sqlCommand.Parameters.Add("@accountingGroup", SqlDbType.VarChar).Value = template.AccountingGroup;
                        sqlCommand.Parameters.Add("@casepackHeight", SqlDbType.VarChar).Value = template.CasepackHeight;
                        sqlCommand.Parameters.Add("@casepackLength", SqlDbType.VarChar).Value = template.CasepackLength;
                        sqlCommand.Parameters.Add("@casepackQty", SqlDbType.VarChar).Value = template.CasepackQty;
                        sqlCommand.Parameters.Add("@casepackWidth", SqlDbType.VarChar).Value = template.CasepackWidth;
                        sqlCommand.Parameters.Add("@casepackWeight", SqlDbType.VarChar).Value = template.CasepackWeight;
                        sqlCommand.Parameters.Add("@category", SqlDbType.VarChar).Value = template.Category;
                        sqlCommand.Parameters.Add("@category2", SqlDbType.VarChar).Value = template.Category2;
                        sqlCommand.Parameters.Add("@category3", SqlDbType.VarChar).Value = template.Category3;
                        sqlCommand.Parameters.Add("@copyright", SqlDbType.VarChar).Value = template.Copyright;
                        sqlCommand.Parameters.Add("@costProfileGroup", SqlDbType.VarChar).Value = template.CostProfileGroup;
                        sqlCommand.Parameters.Add("@defaultActualCostUsd", SqlDbType.VarChar).Value = template.DefaultActualCostUsd;
                        sqlCommand.Parameters.Add("@defaultActualCostCad", SqlDbType.VarChar).Value = template.DefaultActualCostCad;
                        sqlCommand.Parameters.Add("@duty", SqlDbType.VarChar).Value = template.Duty;
                        sqlCommand.Parameters.Add("@gpc", SqlDbType.VarChar).Value = template.Gpc;
                        sqlCommand.Parameters.Add("@height", SqlDbType.VarChar).Value = template.Height;
                        sqlCommand.Parameters.Add("@innerpackHeight", SqlDbType.VarChar).Value = template.InnerpackHeight;
                        sqlCommand.Parameters.Add("@innerpackLength", SqlDbType.VarChar).Value = template.InnerpackLength;
                        sqlCommand.Parameters.Add("@innerpackQty", SqlDbType.VarChar).Value = template.InnerpackQuantity;
                        sqlCommand.Parameters.Add("@innerpackWidth", SqlDbType.VarChar).Value = template.InnerpackWidth;
                        sqlCommand.Parameters.Add("@innerpackWeight", SqlDbType.VarChar).Value = template.InnerpackWeight;
                        sqlCommand.Parameters.Add("@itemCategory", SqlDbType.VarChar).Value = template.ItemCategory;
                        sqlCommand.Parameters.Add("@itemFamily", SqlDbType.VarChar).Value = template.ItemFamily;
                        sqlCommand.Parameters.Add("@itemGroup", SqlDbType.VarChar).Value = template.ItemGroup;
                        sqlCommand.Parameters.Add("@length", SqlDbType.VarChar).Value = template.Length;
                        sqlCommand.Parameters.Add("@listPriceCad", SqlDbType.VarChar).Value = template.ListPriceCad;
                        sqlCommand.Parameters.Add("@listPriceUsd", SqlDbType.VarChar).Value = template.ListPriceUsd;
                        sqlCommand.Parameters.Add("@listPriceMxn", SqlDbType.VarChar).Value = template.ListPriceMxn;
                        sqlCommand.Parameters.Add("@metaDescription", SqlDbType.VarChar).Value = template.MetaDescription;
                        sqlCommand.Parameters.Add("@mfgSource", SqlDbType.VarChar).Value = template.MfgSource;
                        sqlCommand.Parameters.Add("@msrp", SqlDbType.VarChar).Value = template.Msrp;
                        sqlCommand.Parameters.Add("@msrpCad", SqlDbType.VarChar).Value = template.MsrpCad;
                        sqlCommand.Parameters.Add("@msrpMxn", SqlDbType.VarChar).Value = template.MsrpMxn;
                        sqlCommand.Parameters.Add("@printOnDemand", SqlDbType.VarChar).Value = template.PrintOnDemand;
                        sqlCommand.Parameters.Add("@productFormat", SqlDbType.VarChar).Value = template.ProductFormat;
                        sqlCommand.Parameters.Add("@productGroup", SqlDbType.VarChar).Value = template.ProductGroup;
                        sqlCommand.Parameters.Add("@productLine", SqlDbType.VarChar).Value = template.ProductLine;
                        sqlCommand.Parameters.Add("@productQty", SqlDbType.VarChar).Value = template.ProductQty;
                        sqlCommand.Parameters.Add("@pricingGroup", SqlDbType.VarChar).Value = template.PricingGroup;
                        sqlCommand.Parameters.Add("@psStatus", SqlDbType.VarChar).Value = template.PsStatus;
                        sqlCommand.Parameters.Add("@satCode", SqlDbType.VarChar).Value = template.SatCode;
                        sqlCommand.Parameters.Add("@size", SqlDbType.VarChar).Value = template.Size;
                        sqlCommand.Parameters.Add("@tariffCode", SqlDbType.VarChar).Value = template.TariffCode;
                        sqlCommand.Parameters.Add("@udex", SqlDbType.VarChar).Value = template.Udex;
                        sqlCommand.Parameters.Add("@weight", SqlDbType.VarChar).Value = template.Weight;
                        sqlCommand.Parameters.Add("@width", SqlDbType.VarChar).Value = template.Width;
                        sqlCommand.Parameters.Add("@ecommerceBullet1", SqlDbType.VarChar).Value = template.EcommerceBullet1;
                        sqlCommand.Parameters.Add("@ecommerceBullet2", SqlDbType.VarChar).Value = template.EcommerceBullet2;
                        sqlCommand.Parameters.Add("@ecommerceBullet3", SqlDbType.VarChar).Value = template.EcommerceBullet3;
                        sqlCommand.Parameters.Add("@ecommerceBullet4", SqlDbType.VarChar).Value = template.EcommerceBullet4;
                        sqlCommand.Parameters.Add("@ecommerceBullet5", SqlDbType.VarChar).Value = template.EcommerceBullet5;
                        sqlCommand.Parameters.Add("@ecommerceComponents", SqlDbType.VarChar).Value = template.EcommerceComponents;
                        sqlCommand.Parameters.Add("@ecommerceCost", SqlDbType.VarChar).Value = template.EcommerceCost;
                        sqlCommand.Parameters.Add("@ecommerceExternalIdType", SqlDbType.VarChar).Value = template.EcommerceExternalIdType;
                        sqlCommand.Parameters.Add("@ecommerceItemHeight", SqlDbType.VarChar).Value = template.EcommerceItemHeight;
                        sqlCommand.Parameters.Add("@ecommerceItemLength", SqlDbType.VarChar).Value = template.EcommerceItemLength;
                        sqlCommand.Parameters.Add("@ecommerceItemWeight", SqlDbType.VarChar).Value = template.EcommerceItemWeight;
                        sqlCommand.Parameters.Add("@ecommerceItemWidth", SqlDbType.VarChar).Value = template.EcommerceItemWidth;
                        sqlCommand.Parameters.Add("@ecommerceModelName", SqlDbType.VarChar).Value = template.EcommerceModelName;
                        sqlCommand.Parameters.Add("@ecommercePackageLength", SqlDbType.VarChar).Value = template.EcommercePackageLength;
                        sqlCommand.Parameters.Add("@ecommercePackageHeight", SqlDbType.VarChar).Value = template.EcommercePackageHeight;
                        sqlCommand.Parameters.Add("@ecommercePackageWeight", SqlDbType.VarChar).Value = template.EcommercePackageWeight;
                        sqlCommand.Parameters.Add("@ecommercePackageWidth", SqlDbType.VarChar).Value = template.EcommercePackageWidth;
                        sqlCommand.Parameters.Add("@ecommercePageQty", SqlDbType.VarChar).Value = template.EcommercePageQty;
                        sqlCommand.Parameters.Add("@ecommerceProductCategory", SqlDbType.VarChar).Value = template.EcommerceProductCategory;
                        sqlCommand.Parameters.Add("@ecommerceProductDescription", SqlDbType.VarChar).Value = template.EcommerceProductDescription;
                        sqlCommand.Parameters.Add("@ecommerceProductSubcategory", SqlDbType.VarChar).Value = template.EcommerceProductSubcategory;
                        sqlCommand.Parameters.Add("@ecommerceManufacturerName", SqlDbType.VarChar).Value = template.EcommerceManufacturerName;
                        sqlCommand.Parameters.Add("@ecommerceMsrp", SqlDbType.VarChar).Value = template.EcommerceMsrp;
                        sqlCommand.Parameters.Add("@ecommerceSize", SqlDbType.VarChar).Value = template.EcommerceSize;
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
        ///     Removes all column data for the given layout from EXCEL_LAYOUT_DATA
        /// </summary>
        /// <param name="layoutId"></param>
        /// <returns></returns>
        public bool RemoveExcelLayoutColumns(string layoutId)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_RemoveExcelLayoutColumns", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@layoutId", SqlDbType.VarChar).Value = layoutId;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("RemoveExcelLayoutColumns Failed: " + ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Remove a selected template from the db
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public bool RemoveTemplate(string templateName)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
                {
                    SqlCommand sqlCommand = new SqlCommand("Odin_RemoveTemplate", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@templateId", SqlDbType.VarChar).Value = templateName;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///     Retrieves a list of excel columns from ODIN_EXCEL_LAYOUT_DATA
        /// </summary>
        /// <param name="layoutName"></param>
        /// <returns></returns>
        public ObservableCollection<ExcelCell> RetrieveExcelLayoutData(string layoutName)
        {
            ObservableCollection<ExcelCell> excelCells = new ObservableCollection<ExcelCell>();

            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveExcelLayoutData", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@layoutName", SqlDbType.VarChar).Value = layoutName;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string layoutId = Convert.ToString(reader["LAYOUT_ID"]).Trim();
                    int columnNumber = Convert.ToInt32(reader["COLUMN_NUMBER"]);
                    string field = Convert.ToString(reader["FIELD"]).Trim();
                    string option = Convert.ToString(reader["OPTION"]).Trim();
                    string customer = Convert.ToString(reader["CUSTOMER"]).Trim();
                    ExcelCell cell = new ExcelCell(layoutId, columnNumber, field, option, customer);
                    excelCells.Add(cell);
                }
                reader.Close();
            }
            return excelCells;
        }

        /// <summary>
        ///     Retrieves the coresponding layout id for the given layout name from ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <param name="layoutName"></param>
        /// <returns></returns>
        public string RetrieveExcelLayoutId(string layoutName)
        {
            string result = "";

            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveExcelLayoutId", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@layoutName", SqlDbType.VarChar).Value = layoutName;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    result = Convert.ToString(reader["LAYOUT_ID"]).Trim();
                }
                reader.Close();
            }
            return result;
        }

        /// <summary>
        ///     Retrieves a list of existing excel layout names from ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <returns></returns>
        public List<Layout> RetrieveExcelLayouts()
        {
            List<Layout> excelLayouts = new List<Layout>();

            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveExcelLayouts", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {

                    string layoutName = Convert.ToString(reader["LAYOUT_NAME"]).Trim();
                    string layoutId = Convert.ToString(reader["LAYOUT_ID"]).Trim();
                    string customer = Convert.ToString(reader["CUSTOMER"]).Trim();
                    string productType = Convert.ToString(reader["PRODUCT_TYPE"]).Trim();
                    Layout layout = new Layout(layoutName, layoutId, customer, productType);
                    excelLayouts.Add(layout);
                }
                reader.Close();
            }
            return excelLayouts;
        }

        /// <summary>
        ///     Retrieves a list of available field values from ODIN_FIELD_VALUES
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveFieldValues()
        {
            List<string> FieldValues = new List<string>();

            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveFieldValues", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string templateName = Convert.ToString(reader["FIELD_VALUE"]).Trim();
                    FieldValues.Add(templateName);
                }
                reader.Close();
            }
            return FieldValues;
        }

        /// <summary>
        ///     Retrieve a List of names for all existing templates
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveTemplateNameList()
        {
            List<string> TemplateNames = new List<string>();
            
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveTemplateNames", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string templateName = Convert.ToString(reader["TEMPLATE_ID"]).Trim();
                    if (TemplateNames.IndexOf(templateName) == -1)
                    {
                        TemplateNames.Add(templateName);
                    }
                }
                reader.Close();
            }
            return TemplateNames;
        }

        /// <summary>
        ///     Retrieves a template from the db
        /// </summary>
        /// <returns></returns>
        public Template RetrieveTemplate(string name)
        {
            Template template = new Template();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_RetrieveTemplate", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@templateId", SqlDbType.VarChar).Value = name;
                SqlDataReader reader = sqlCommand.ExecuteReader();                
                while (reader.Read())
                {
                    template.TemplateId = Convert.ToString(reader["TEMPLATE_ID"]);
                    template.AccountingGroup = Convert.ToString(reader["ACCOUNTING_GROUP"]);
                    template.CasepackHeight = Convert.ToString(reader["CASEPACK_HEIGHT"]);
                    template.CasepackLength = Convert.ToString(reader["CASEPACK_LENGTH"]);
                    template.CasepackQty = Convert.ToString(reader["CASEPACK_QTY"]);
                    template.CasepackWidth = Convert.ToString(reader["CASEPACK_WIDTH"]);
                    template.CasepackWeight = Convert.ToString(reader["CASEPACK_WEIGHT"]);
                    template.Category = Convert.ToString(reader["CATEGORY"]);
                    template.Category2 = Convert.ToString(reader["CATEGORY2"]);
                    template.Category3 = Convert.ToString(reader["CATEGORY3"]);
                    template.Copyright = Convert.ToString(reader["COPYRIGHT"]);
                    template.CostProfileGroup = Convert.ToString(reader["COST_PROFILE_GROUP"]);
                    template.DefaultActualCostCad = Convert.ToString(reader["DEFAULT_ACTUAL_COST_CAD"]);
                    template.DefaultActualCostUsd = Convert.ToString(reader["DEFAULT_ACTUAL_COST_USD"]);
                    template.Duty = Convert.ToString(reader["DUTY"]);
                    template.Gpc = Convert.ToString(reader["GPC"]);
                    template.Height = Convert.ToString(reader["HEIGHT"]);
                    template.InnerpackHeight = Convert.ToString(reader["INNERPACK_HEIGHT"]);
                    template.InnerpackLength = Convert.ToString(reader["INNERPACK_LENGTH"]);
                    template.InnerpackQuantity = Convert.ToString(reader["INNERPACK_QTY"]);
                    template.InnerpackWeight = Convert.ToString(reader["INNERPACK_WEIGHT"]);
                    template.InnerpackWidth = Convert.ToString(reader["INNERPACK_WIDTH"]);
                    template.ItemCategory = Convert.ToString(reader["ITEM_CATEGORY"]);
                    template.ItemFamily = Convert.ToString(reader["ITEM_FAMILY"]);
                    template.ItemGroup = Convert.ToString(reader["ITEM_GROUP"]);
                    template.Length = Convert.ToString(reader["LENGTH"]);
                    template.ListPriceCad = Convert.ToString(reader["LIST_PRICE_CAD"]);
                    template.ListPriceMxn = Convert.ToString(reader["LIST_PRICE_MXN"]);
                    template.ListPriceUsd = Convert.ToString(reader["LIST_PRICE_USD"]);
                    template.MetaDescription = Convert.ToString(reader["META_DESCRIPTION"]);
                    template.MfgSource = Convert.ToString(reader["MFG_SOURCE"]);
                    template.Msrp = Convert.ToString(reader["MSRP"]);
                    template.MsrpCad = Convert.ToString(reader["MSRP_CAD"]);
                    template.MsrpMxn = Convert.ToString(reader["MSRP_MXN"]);
                    template.PrintOnDemand = Convert.ToString(reader["PRINT_ON_DEMAND"]);
                    template.ProductGroup = Convert.ToString(reader["PRODUCT_GROUP"]);
                    template.ProductLine = Convert.ToString(reader["PRODUCT_LINE"]);
                    template.ProductFormat = Convert.ToString(reader["PRODUCT_FORMAT"]);
                    template.ProductQty = Convert.ToString(reader["PROD_QTY"]);
                    template.PricingGroup = Convert.ToString(reader["PRICING_GROUP"]);
                    template.PsStatus = Convert.ToString(reader["PS_STATUS"]);
                    template.SatCode = Convert.ToString(reader["SAT_CODE"]);
                    template.Size = Convert.ToString(reader["SIZE"]);
                    template.TariffCode = Convert.ToString(reader["TARIFF_CODE"]);
                    template.Udex = Convert.ToString(reader["UDEX"]);
                    template.Weight = Convert.ToString(reader["WEIGHT"]);
                    template.Width = Convert.ToString(reader["WIDTH"]);
                    template.EcommerceBullet1 = Convert.ToString(reader["ECOMMERCE_BULLET_1"]);
                    template.EcommerceBullet2 = Convert.ToString(reader["ECOMMERCE_BULLET_2"]);
                    template.EcommerceBullet3 = Convert.ToString(reader["ECOMMERCE_BULLET_3"]);
                    template.EcommerceBullet4 = Convert.ToString(reader["ECOMMERCE_BULLET_4"]);
                    template.EcommerceBullet5 = Convert.ToString(reader["ECOMMERCE_BULLET_5"]);
                    template.EcommerceComponents = Convert.ToString(reader["ECOMMERCE_COMPONENTS"]);
                    template.EcommerceCost = Convert.ToString(reader["ECOMMERCE_COST"]);
                    template.EcommerceExternalIdType = Convert.ToString(reader["ECOMMERCE_EXTERNAL_ID_TYPE"]);
                    template.EcommerceItemHeight = Convert.ToString(reader["ECOMMERCE_ITEM_HEIGHT"]);
                    template.EcommerceItemLength = Convert.ToString(reader["ECOMMERCE_ITEM_LENGTH"]);
                    template.EcommerceItemWeight = Convert.ToString(reader["ECOMMERCE_ITEM_WEIGHT"]);
                    template.EcommerceItemWidth = Convert.ToString(reader["ECOMMERCE_ITEM_WIDTH"]);
                    template.EcommerceModelName = Convert.ToString(reader["ECOMMERCE_MODEL_NAME"]);
                    template.EcommercePackageLength = Convert.ToString(reader["ECOMMERCE_PACKAGE_LENGTH"]);
                    template.EcommercePackageHeight = Convert.ToString(reader["ECOMMERCE_PACKAGE_HEIGHT"]);
                    template.EcommercePackageWeight = Convert.ToString(reader["ECOMMERCE_PACKAGE_WEIGHT"]);
                    template.EcommercePackageWidth = Convert.ToString(reader["ECOMMERCE_PACKAGE_WIDTH"]);
                    template.EcommercePageQty = Convert.ToString(reader["ECOMMERCE_PAGE_COUNT"]);
                    template.EcommerceProductCategory = Convert.ToString(reader["ECOMMERCE_PRODUCT_CATEGORY"]);
                    template.EcommerceProductDescription = Convert.ToString(reader["ECOMMERCE_PRODUCT_DESCRIPTION"]);
                    template.EcommerceProductSubcategory = Convert.ToString(reader["ECOMMERCE_PRODUCT_SUBCATEGORY"]);
                    template.EcommerceManufacturerName = Convert.ToString(reader["ECOMMERCE_MANUFACTURER_NAME"]);
                    template.EcommerceMsrp = Convert.ToString(reader["ECOMMERCE_MSRP"]);
                    template.EcommerceSize = Convert.ToString(reader["ECOMMERCE_SIZE"]);
                }
                reader.Close();
            }
            return template;
        }

        /// <summary>
        ///     Updates an existing template
        /// </summary>
        /// <returns></returns>
        public bool UpdateTemplate(Template template, string status)
        {
            try
            {
                RemoveTemplate(template.TemplateId);
                if (status != "Remove")
                {
                    InsertTemplate(template);
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }


        #endregion // Methods

        #region Constructor
        
        /// <summary>
        ///     Constructs a Template Repository
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbPassword"></param>
        /// <param name="dbServerName"></param>
        /// <param name="isLocalTest"></param>
        public TemplateRepository(string dbName, string dbPassword, string dbServerName, bool isLocalTest)
        {
            this.DbServerName = dbServerName;
            this.DbName = dbName;
            this.DbPassword = dbPassword;
            this.IsLocalTest = isLocalTest;
        }
        #endregion // Constructor
    }
}
