using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using OdinModels;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using Odin.Data;

namespace OdinServices
{
    public class ExcelService
    {
        #region Properties

        private Microsoft.Office.Interop.Excel.Application app = null;

        private Microsoft.Office.Interop.Excel.Workbook workbook = null;

        private Microsoft.Office.Interop.Excel.Worksheet worksheet = null;

        /// <summary>
        ///     List of all letters in the alphabet
        /// </summary>
        public string[] Alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        
        /// <summary>
        ///     Gets or sets the ftp service
        /// </summary>
        public FtpService FtpService { get; set; }

        /// <summary>
        ///     Gets or sets the itemservice
        /// </summary>
        public ItemService ItemService { get; set; }

        /// <summary>
        ///     Gets or sets the optionService
        /// </summary>
        public OptionService OptionService { get; set; }

        /// <summary>
        ///     Gets or sets the requestnum
        /// </summary>
        int RequestNum { get; set; }

        public IRequestRepository RequestRepository { get; set; }
        
        public ITemplateRepository TemplateRepository { get; set; }

        /// <summary>
        ///     Gets or sets the LayoutList
        /// </summary>
        public List<Layout> LayoutList
        {
            get { return _layoutList; }
            set { _layoutList = value; }
        }
        private List<Layout> _layoutList = new List<Layout>();

        #region HeaderLists
              
        /// <summary>
        ///     List of headers for the item template
        /// </summary>
        public List<string> ItemHeaders = new List<string>();

        /// <summary>
        ///     List of headers for the template template
        /// </summary>
        public List<string> TemplateHeaders = new List<string>();

        #endregion // HeaderLists

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Writes out the field name as the first row of template
        /// </summary>
        /// <param name="excelCells"></param>
        public void AddHeaders(ObservableCollection<ExcelCell> excelCells)
        {
            int count = 1;
            foreach (ExcelCell header in excelCells)
            {
                worksheet.Cells[1, count] = header.Field;
                count++;
            }
        }

        /// <summary>
        ///     Inserts a row of data for the given item into an excel sheet
        /// </summary>
        /// <param name="excelCells"></param>
        /// <param name="item"></param>
        /// <param name="row"></param>
        public void AddRowData(ObservableCollection<ExcelCell> excelCells, ItemObject item, int row, string customer)
        {
            int columnCount = 1;
            foreach(ExcelCell cell in excelCells)
            {
                string cellValue = RetrieveCellValue(cell.Field, item, customer);
                // if(CheckNumberFormat(cell.Field))
                // {
                worksheet.Cells[row, columnCount].NumberFormat = "@";
                // }
                worksheet.Cells[row, columnCount] = cellValue;

                columnCount++;
            }
        }
                
        /// <summary>
        ///     Check if the given field is designated as requiring number formating
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool CheckNumberFormat(string value)
        {
            if(value == "UPC" || value == "Ecommerce UPC" || value == "Ecommerce External ID")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Create a excell documents for a given list of items
        /// </summary>
        /// <param name="workbookType"></param>
        /// <param name="itemsList"></param>
        /// <returns></returns>
        public void CreateExcelSheet(ObservableCollection<ItemObject> itemsList, ObservableCollection<ExcelCell> excelCells, string customer)
        {
            string strFilePath;
            bool createFile = true;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel Workbooks (*.xlsx)|*.xlsx";
            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            strFilePath = dlg.FileName;
            Cursor.Show();
            app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            workbook = app.Workbooks.Add(1);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
            AddHeaders(excelCells);

            int row = 2;
            foreach (ItemObject item in itemsList)
            {
                AddRowData(excelCells, item, row, customer);
                row++;
            }
            if (createFile)
            {
                workbook.SaveAs(strFilePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                         Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing,
                                         Type.Missing, Type.Missing, Type.Missing);
                Cursor.Hide();
                workbook.ReadOnly.Equals(false);
                workbook.Close();
                MessageBox.Show("Excel Document is Complete. " + strFilePath);
            }        
        }
                
        #region Add data methods
                        
        /// <summary>
        ///     Inserts a row of data for the template export file
        /// </summary>
        /// <param name="template"></param>
        /// <param name="row"></param>
        private void AddTemplateData(Template template, int row)
        {
            worksheet.Cells[row, 1] = template.TemplateId; //Template ID
            worksheet.Cells[row, 2] = template.ItemGroup; //Item Group
            worksheet.Cells[row, 3] = template.ItemFamily; //Item Family
            worksheet.Cells[row, 4] = template.ItemCategory; //Item Category
            worksheet.Cells[row, 5] = template.CostProfileGroup; //Cost Profile Group
            worksheet.Cells[row, 6] = template.MfgSource; //Mfg Source
            worksheet.Cells[row, 7] = template.Weight; //Item Weight
            worksheet.Cells[row, 8] = template.Length; //Item Length
            worksheet.Cells[row, 9] = template.Height; //Item Height
            worksheet.Cells[row, 10] = template.Width; //Item Width
            worksheet.Cells[row, 11] = template.TariffCode; //Tariff Code
            worksheet.Cells[row, 12] = template.CountryOfOrigin; //Country of Origin
            worksheet.Cells[row, 13] = template.DefaultActualCostUsd; //Default Actual Cost USD
            worksheet.Cells[row, 14] = template.DefaultActualCostCad; //Default Actual Cost CAD
            worksheet.Cells[row, 15] = template.PricingGroup; //Price Group (Product)
            worksheet.Cells[row, 16] = template.AccountingGroup; //Acctg Group (Product)
            worksheet.Cells[row, 17] = template.ListPriceUsd; //List Price (USD)
            worksheet.Cells[row, 18] = template.ListPriceCad; //List Price (CAD)
            worksheet.Cells[row, 19] = template.ListPriceMxn; //List Price (MXN)
            worksheet.Cells[row, 20] = template.Msrp; //MSRP
            worksheet.Cells[row, 21] = template.MsrpCad; //MSRP CAD
            worksheet.Cells[row, 22] = template.MsrpMxn; //MSRP MXN
            worksheet.Cells[row, 23] = template.Udex; //UDEX
            worksheet.Cells[row, 24] = template.Gpc; //GPC
            worksheet.Cells[row, 25] = template.PrintOnDemand; // Print On Demand
            worksheet.Cells[row, 26] = template.ProductGroup; //Product Group
            worksheet.Cells[row, 27] = template.ProductLine; //Product Line
            worksheet.Cells[row, 28] = template.ProductFormat; //Product Format
            worksheet.Cells[row, 29] = template.CasepackHeight; //Casepack Height
            worksheet.Cells[row, 30] = template.CasepackLength; //Casepack Length
            worksheet.Cells[row, 31] = template.CasepackWeight; //Casepack Weight
            worksheet.Cells[row, 32] = template.CasepackWidth; //Casepack Width
            worksheet.Cells[row, 33] = template.CasepackQty; //Casepack Qty
            worksheet.Cells[row, 34] = template.InnerpackHeight; //Innerpack Height
            worksheet.Cells[row, 35] = template.InnerpackLength; //Innerpack Length
            worksheet.Cells[row, 36] = template.InnerpackWeight; //Innerpack Weight
            worksheet.Cells[row, 37] = template.InnerpackWidth; //Innerpack Width
            worksheet.Cells[row, 38] = template.InnerpackQuantity; //Innerpack Qty
            worksheet.Cells[row, 39] = template.Category; //Category
            worksheet.Cells[row, 40] = template.Category2; //Category2
            worksheet.Cells[row, 41] = template.Category3; //Category3
            worksheet.Cells[row, 42] = template.Copyright; //Copyright
            worksheet.Cells[row, 43] = template.MetaDescription; //Meta Description
            worksheet.Cells[row, 44] = template.Size; //Size
            worksheet.Cells[row, 45] = template.EcommerceBullet1; //Ecommerce Bullet 1
            worksheet.Cells[row, 46] = template.EcommerceBullet2; //Ecommerce Bullet 2
            worksheet.Cells[row, 47] = template.EcommerceBullet3; //Ecommerce Bullet 3
            worksheet.Cells[row, 48] = template.EcommerceBullet4; //Ecommerce Bullet 4
            worksheet.Cells[row, 49] = template.EcommerceBullet5; //Ecommerce Bullet 5
            worksheet.Cells[row, 50] = template.EcommerceComponents; //Ecommerce Components
            worksheet.Cells[row, 51] = template.EcommerceCost; //Ecommerce Cost
            worksheet.Cells[row, 52] = template.EcommerceExternalIdType; //Ecommerce External ID Type
            worksheet.Cells[row, 53] = template.EcommerceItemHeight; //Ecommerce Item Height
            worksheet.Cells[row, 54] = template.EcommerceItemLength; //Ecommerce Item Length
            worksheet.Cells[row, 55] = template.EcommerceItemWeight; //Ecommerce Item Weight
            worksheet.Cells[row, 56] = template.EcommerceItemWidth; //Ecommerce Item Width
            worksheet.Cells[row, 57] = template.EcommerceModelName; //Ecommerce Model Name
            worksheet.Cells[row, 58] = template.EcommercePackageHeight; //Ecommerce Package Height
            worksheet.Cells[row, 59] = template.EcommercePackageLength; //Ecommerce Package Length
            worksheet.Cells[row, 60] = template.EcommercePackageWeight; //Ecommerce Package Weight
            worksheet.Cells[row, 61] = template.EcommercePackageWidth; //Ecommerce Package Width
            worksheet.Cells[row, 62] = template.EcommercePageQty; //Ecommerce Page Count
            worksheet.Cells[row, 63] = template.EcommerceProductCategory; //Ecommerce Product Category
            worksheet.Cells[row, 64] = template.EcommerceProductDescription; //Ecommerce Product Description
            worksheet.Cells[row, 65] = template.EcommerceProductSubcategory; //Ecommerce Product Subcategory
            worksheet.Cells[row, 66] = template.EcommerceManufacturerName; //Ecommerce Manufacturer Name
            worksheet.Cells[row, 67] = template.EcommerceMsrp; //Ecommerce Msrp
            worksheet.Cells[row, 68] = template.EcommerceSize; //Ecommerce Size
            worksheet.Cells[row, 69] = template.WebsitePrice; // Website Price
        }

        #endregion // Add data methods

        #region Modifier Methods

        /// <summary>
        ///     Lowercases the string and replaces the spaces with dashes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ModifyImageUrl(string value)
        {
            value = value.ToLower();
            value = value.Trim();
            value = value.Replace(' ', '-');
            return value;
        }

        /// <summary>
        ///     Converts the existing image path to reflect the location of additional images
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ModifyAdditionalImageUrl(string value)
        {
            string[] pathParts = value.Split('/');
            string fileName = pathParts[pathParts.Length - 1];
            string result = "http://trendsinternational.com/media/externalCaptures/" + fileName;
            result = result.Replace(" ", "%20");
            return result;
        }

        /// <summary>
        ///     Creates a combined bullet point seperated string for the items bullet points
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string ModifyBulletedCopy(ItemObject item)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(item.Ecommerce_Bullet1)) { result += "\u2022" + item.Ecommerce_Bullet1; }
            if (!string.IsNullOrEmpty(item.Ecommerce_Bullet2)) { result += "\r\n\u2022" + item.Ecommerce_Bullet2; }
            if (!string.IsNullOrEmpty(item.Ecommerce_Bullet3)) { result += "\r\n\u2022" + item.Ecommerce_Bullet3; }
            if (!string.IsNullOrEmpty(item.Ecommerce_Bullet4)) { result += "\r\n\u2022" + item.Ecommerce_Bullet4; }
            if (!string.IsNullOrEmpty(item.Ecommerce_Bullet5)) { result += "\r\n\u2022" + item.Ecommerce_Bullet5; }
            return result;
        }

        /// <summary>
        ///     Adds (1) to all components that don't have a parenthetical number
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        public string ModifyComponents(string components)
        {
            string result = string.Empty;

            string[] componentList = components.Split('^');
            foreach (string x in componentList)
            {
                if (x.Contains("("))
                {
                    result += x + "^";
                }
                else
                {
                    result += x + "(1)^";
                }
            }
            result = result.TrimEnd('^');
            return result;
        }

        /// <summary>
        ///     Merge ecommerce bullet fields into a single comman delimited string
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string MergeBullets(ItemObject item)
        {
            string returnValue = string.Empty;
            returnValue += item.Ecommerce_Bullet1;
            returnValue += ", " + item.Ecommerce_Bullet2;
            returnValue += ", " + item.Ecommerce_Bullet3;
            if (!string.IsNullOrEmpty(item.Ecommerce_Bullet4))
            {
                returnValue += ", " + item.Ecommerce_Bullet4;
            }
            if (!string.IsNullOrEmpty(item.Ecommerce_Bullet5))
            {
                returnValue += ", " + item.Ecommerce_Bullet5;
            }
            return returnValue;
        }

        /// <summary>
        ///     removes prefix from sku and appends the number to the end of the keywords
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public string ModifyKeywords(string sku, string keywords)
        {
            string value;
            string skuInt = Regex.Replace(sku, "[^0-9.]", "");
            keywords = keywords.Replace(';', ',');
            if (!keywords.EndsWith(","))
            {
                keywords = keywords + ", ";
            }
            value = keywords + skuInt;
            return value;
        }

        /// <summary>
        ///     If the file exists on externalCaptures return filepath
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string SetImagePath(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (FtpService != null)
                {
                    if (FtpService.CheckFile(filePath))
                    {
                        return ModifyAdditionalImageUrl(filePath);
                    }
                }
                else
                {
                    MessageBox.Show("FTP connection was unable to be made. Image Url could not be generated.");
                }
            }
            return ModifyImageUrl(filePath);
        }

        /// <summary>
        ///     Sorts a list of items into groups based on the non-prefixed item sku. Will return a list of grouped item numbers with a coresponding
        ///     list of prefixes.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<KeyValuePair<string, List<ItemObject>>> SortAmazonItemVariations(ObservableCollection<ItemObject> items)
        {
            List<KeyValuePair<string, ItemObject>> initialList = new List<KeyValuePair<string, ItemObject>>();
            List<KeyValuePair<string, List<ItemObject>>> resultList = new List<KeyValuePair<string, List<ItemObject>>>();
            List<string> existingItemIds = new List<string>();
            foreach (ItemObject item in items)
            {
                if (item.ItemId.Substring(0, 2) == "RP")
                {
                    initialList.Add(new KeyValuePair<string, ItemObject>(item.ItemId.Substring(2), item));
                    if (!existingItemIds.Contains(item.ItemId.Substring(2)))
                    {
                        existingItemIds.Add(item.ItemId.Substring(2));
                    }
                }
                else if (item.ItemId.Substring(0, 2) == "FR")
                {
                    initialList.Add(new KeyValuePair<string, ItemObject>(item.ItemId.Substring(2), item));
                    if (!existingItemIds.Contains(item.ItemId.Substring(2)))
                    {
                        existingItemIds.Add(item.ItemId.Substring(2));
                    }
                }
                else if (item.ItemId.Substring(0, 3) == "POD")
                {
                    initialList.Add(new KeyValuePair<string, ItemObject>(item.ItemId.Substring(3), item));
                    if (!existingItemIds.Contains(item.ItemId.Substring(3)))
                    {
                        existingItemIds.Add(item.ItemId.Substring(3));
                    }
                }
            }
            foreach (string itemId in existingItemIds)
            {
                List<ItemObject> idList = new List<ItemObject>();
                foreach (KeyValuePair<string, ItemObject> x in initialList)
                {
                    if (x.Key == itemId)
                    {
                        idList.Add(x.Value);
                    }
                }
                KeyValuePair<string, List<ItemObject>> z = new KeyValuePair<string, List<ItemObject>>(itemId, idList);
                resultList.Add(z);
            }
            return resultList;
        }

        /// <summary>
        ///     Trims amazon keywords down to maximum field value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string TrimSearchTerms(string value, string customer)
        {
            if (customer == "AMAZON")
            {
                if (value.Length > 385)
                {
                    value = value.Substring(0, 385);
                    while (!value.EndsWith(";"))
                    {
                        value = value.Remove(value.Length - 1, 1);
                    }
                    return value;
                }
            }
            return value;            
        }

        #endregion // Modifier Methods

        #region Insert Methods

        /// <summary>
        ///     Establish connection and run InsertExcelLayoutColumn foreach cell in list
        /// </summary>
        /// <param name="cellList"></param>
        /// <returns></returns>
        public void InsertExcelLayoutColumns(ObservableCollection<ExcelCell> cellList)
        {
            TemplateRepository.InsertExcelLayoutColumns(cellList);
        }

        /// <summary>
        ///     Inserts a column data into ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <param name="layoutName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public void InsertExcelLayout(string layoutName, string customer, string productType)
        {
            TemplateRepository.InsertExcelLayout(layoutName, customer, productType);
            RetrieveExcelLayouts();
        }

        #endregion // Insert Methods

        /// <summary>
        ///     Create a excell documents for a given list of items
        /// </summary>
        /// <param name="workbookType"></param>
        /// <param name="itemsList"></param>
        /// <returns></returns>
        public bool CreateItemWorkbook(string layoutName, ObservableCollection<ItemObject> itemsList)
        {
            ObservableCollection<ExcelCell> excelCells = RetrieveExcelLayoutData(layoutName);
            string customer = RetrieveExcelLayoutCustomer(layoutName);
            CreateExcelSheet(itemsList, excelCells, customer);
            return true;
        }

        /// <summary>
        ///     Creates comman seperated string of headers for the magento csv file
        /// </summary>
        /// <returns></returns>
        private string CreateMagentoHeaders()
        {
            string value = string.Empty;

            value += "sku,";
            value += "_store,";
            value += "_attribute_set,";
            value += "_type,";
            value += "_category,";
            value += "_root_category,";
            value += "_product_websites,";
            value += "color,";
            value += "cost,";
            value += "country_of_manufacture,";
            value += "created_at,";
            value += "has_options,";
            value += "height,";
            value += "language,";
            value += "legal,";
            value += "license,";
            value += "license_2,";
            value += "license_end_date,";
            value += "meta_description,";
            value += "meta_keyword,";
            value += "meta_title,";
            value += "msrp,";
            value += "msrpcan,";
            value += "msrp_display_actual_price_type,";
            value += "msrp_enabled,";
            value += "name,";
            value += "date_added,";
            value += "news_from_date,";
            value += "news_to_date,";
            value += "options_container,";
            value += "price,";
            value += "pricecan,";
            value += "required_options,";
            value += "short_description,";
            value += "status,";
            value += "tax_class_id,";
            value += "territory,";
            value += "upc,";
            value += "updated_at,";
            value += "url_key,";
            value += "url_path,";
            value += "visibility,";
            value += "weight,";
            value += "width,";
            value += "size,";
            value += "min_qty,";
            value += "pack_qty,";
            value += "use_config_min_qty,";
            value += "is_qty_decimal,";
            value += "backorders,";
            value += "use_config_backorders,";
            value += "min_sale_qty,";
            value += "use_config_min_sale_qty,";
            value += "max_sale_qty,";
            value += "use_config_max_sale_qty,";
            value += "is_in_stock,";
            value += "notify_stock_qty,";
            value += "use_config_notify_stock_qty,";
            value += "manage_stock,";
            value += "use_config_manage_stock,";
            value += "stock_status_changed_auto,";
            value += "use_config_qty_increments,";
            value += "qty_increments,";
            value += "use_config_enable_qty_inc,";
            value += "enable_qty_increments,";
            value += "is_decimal_divided,";
            value += "_links_related_sku,";
            value += "_links_related_position,";
            value += "_media_attribute_id,";
            value += "_media_position,";
            value += "_media_is_disabled,";
            value += "qty,";
            value += "license_begin_date";

            return value;
        }

        /// <summary>
        ///     Create a excell document for a given list of items
        /// </summary>
        /// <param name="workbookType"></param>
        /// <param name="itemsList"></param>
        /// <returns></returns>
        public void CreateTemplateWorkbook(List<Template> templateList = null)
        {
            string strFilePath;
            List<Template> TemplateList = new List<Template>();
            if (templateList == null)
            {
                TemplateList.Add(new Template());
            }
            else
            {
                TemplateList = templateList;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel Workbooks (*.xlsx)|*.xlsx";
            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            strFilePath = dlg.FileName;
            Cursor.Show();
            app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            workbook = app.Workbooks.Add(1);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            int row = 2;
            WriteHeaders(this.TemplateHeaders);
            foreach (Template template in TemplateList)
            {
                AddTemplateData(template, row);
                row++;
            }
            workbook.SaveAs(strFilePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                     Type.Missing, XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing,
                                     Type.Missing, Type.Missing, Type.Missing);
            Cursor.Hide();
            MessageBox.Show("Excel Document is Complete. " + strFilePath);
        }
        
        public List<string> NewCategories(string cat1, string cat2, string cat3)
        {
            List<string> results = new List<string>();
            string[] inputs = { cat1, cat2, cat3 };

            foreach (string input in inputs)
            {
                if (!string.IsNullOrEmpty(input))
                {
                    string currentCat = string.Empty;
                    string category = input;
                    string[] subCategories = category.Split(':');
                    for (int x = 0; x < subCategories.Length; x++)
                    {
                        if (string.IsNullOrEmpty(currentCat))
                        {
                            currentCat = subCategories[x].Trim();
                        }
                        else
                        {
                            currentCat += "/" + subCategories[x].Trim();
                        }

                        if (!string.IsNullOrEmpty(currentCat))
                        {
                            if (!results.Contains(currentCat))
                            {
                                results.Add(currentCat);
                            }
                        }
                    }
                }
            }

            return results;
        }

        /// <summary>
        ///     Populates the template header list
        /// </summary>
        public void PopulateTemplateHeaders()
        {
            this.TemplateHeaders.Add("Template ID");
            this.TemplateHeaders.Add("Item Group");
            this.TemplateHeaders.Add("Item Family");
            this.TemplateHeaders.Add("Item Category");
            this.TemplateHeaders.Add("Cost Profile Group");
            this.TemplateHeaders.Add("Mfg Source");
            this.TemplateHeaders.Add("Item Weight");
            this.TemplateHeaders.Add("Item Length");
            this.TemplateHeaders.Add("Item Height");
            this.TemplateHeaders.Add("Item Width");
            this.TemplateHeaders.Add("Tariff Code");
            this.TemplateHeaders.Add("Country of Origin");
            this.TemplateHeaders.Add("Default Actual Cost USD");
            this.TemplateHeaders.Add("Default Actual Cost CAD");
            this.TemplateHeaders.Add("Price Group (Product)");
            this.TemplateHeaders.Add("Acctg Group (Product)");
            this.TemplateHeaders.Add("List Price (USD)");
            this.TemplateHeaders.Add("List Price (CAD)");
            this.TemplateHeaders.Add("List Price (MXN)");
            this.TemplateHeaders.Add("MSRP");
            this.TemplateHeaders.Add("MSRP CAD");
            this.TemplateHeaders.Add("MSRP MXN");
            this.TemplateHeaders.Add("UDEX");
            this.TemplateHeaders.Add("GPC");
            this.TemplateHeaders.Add("Print On Demand");
            this.TemplateHeaders.Add("Product Group");
            this.TemplateHeaders.Add("Product Line");
            this.TemplateHeaders.Add("Product Format");
            this.TemplateHeaders.Add("Casepack Height");
            this.TemplateHeaders.Add("Casepack Length");
            this.TemplateHeaders.Add("Casepack Weight");
            this.TemplateHeaders.Add("Casepack Width");
            this.TemplateHeaders.Add("Casepack Qty");
            this.TemplateHeaders.Add("Innerpack Height");
            this.TemplateHeaders.Add("Innerpack Length");
            this.TemplateHeaders.Add("Innerpack Weight");
            this.TemplateHeaders.Add("Innerpack Width");
            this.TemplateHeaders.Add("Innerpack Qty");
            this.TemplateHeaders.Add("Category");
            this.TemplateHeaders.Add("Category2");
            this.TemplateHeaders.Add("Category3");
            this.TemplateHeaders.Add("Copyright");
            this.TemplateHeaders.Add("Meta Description");
            this.TemplateHeaders.Add("Size");
            this.TemplateHeaders.Add("Ecommerce Bullet 1");
            this.TemplateHeaders.Add("Ecommerce Bullet 2");
            this.TemplateHeaders.Add("Ecommerce Bullet 3");
            this.TemplateHeaders.Add("Ecommerce Bullet 4");
            this.TemplateHeaders.Add("Ecommerce Bullet 5");
            this.TemplateHeaders.Add("Ecommerce Components");
            this.TemplateHeaders.Add("Ecommerce Cost");
            this.TemplateHeaders.Add("Ecommerce External ID Type");
            this.TemplateHeaders.Add("Ecommerce Item Height");
            this.TemplateHeaders.Add("Ecommerce Item Length");
            this.TemplateHeaders.Add("Ecommerce Item Weight");
            this.TemplateHeaders.Add("Ecommerce Item Width");
            this.TemplateHeaders.Add("Ecommerce Model Name");
            this.TemplateHeaders.Add("Ecommerce Package Height");
            this.TemplateHeaders.Add("Ecommerce Package Length");
            this.TemplateHeaders.Add("Ecommerce Package Weight");
            this.TemplateHeaders.Add("Ecommerce Package Width");
            this.TemplateHeaders.Add("Ecommerce Product Category");
            this.TemplateHeaders.Add("Ecommerce Product Description");
            this.TemplateHeaders.Add("Ecommerce Product Subcategory");
            this.TemplateHeaders.Add("Ecommerce Manufacturer Name");
            this.TemplateHeaders.Add("Ecommerce Msrp");
            this.TemplateHeaders.Add("Ecommerce Size");
            this.TemplateHeaders.Add("Website Price");
        }
        
        #region Removal Methods
        
        /// <summary>
        ///     Removes layout data associate with the given layout id from EXCEL_LAYOUT_DATA and EXCEL_LAYOUT_IDS
        /// </summary>
        /// <param name="layoutName"></param>
        public void RemoveExcelLayout(int layoutId)
        {
            TemplateRepository.RemoveExcelLayout(layoutId);
            TemplateRepository.RemoveExcelLayoutColumns(layoutId);
        }

        /// <summary>
        ///     Removes all column data for the given layout
        /// </summary>
        /// <param name="layoutId"></param>
        /// <returns></returns>
        public void RemoveExcelLayoutColumns(int layoutId)
        {
            TemplateRepository.RemoveExcelLayoutColumns(layoutId);
        }

        #endregion // Removal Methods

        #region Retrieval Methods

        /// <summary>
        ///     Reads the fieldname and associates the coresponding value from the item
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public string RetrieveCellValue(string fieldName, ItemObject item, string customer)
        {
            if (!string.IsNullOrEmpty(fieldName))
            {
                if (fieldName.Substring(0, 1) == "\"")
                {
                    return fieldName.Replace("\"", "");
                }
            }
            switch (fieldName)
            {
                case "-EMPTY-":
                    return "";
                case "Acctg Group (Product)":
                    return item.AccountingGroup;
                case "Bill Of Materials":
                    return item.ReturnBillOfMaterials();
                case "Batteries Needed":
                    return "";
                case "Battery Cell Type":
                    return ReturnBatteryCellType(item.PricingGroup);
                case "Brand Name":
                    return ReturnBrandName(item.ProductLine);
                case "Browse Keyword":
                    return ReturnBrowseKeyword(item.Ecommerce_ProductSubcategory);
                case "Casepack Height":
                    return item.CasepackHeight;
                case "Casepack Length":
                    return item.CasepackLength;
                case "Casepack Weight":
                    return item.CasepackWeight;
                case "Casepack Width":
                    return item.CasepackWidth;
                case "Casepack Qty":
                    return (!string.IsNullOrEmpty(item.CasepackQty)) ? item.CasepackQty : "0";
                case "Category":
                    return item.Category;
                case "Category2":
                    return item.Category2;
                case "Category3":
                    return item.Category3;
                case "Copyright":
                    return item.Copyright;
                case "Cost Profile Group":
                    return item.CostProfileGroup;
                case "Country of Origin":
                    return item.CountryOfOrigin;
                case "Country of Origin Full":
                    return ItemService.RetrieveFullCountryOfOrigin(item.CountryOfOrigin);
                case "Country of Origin - Country Code":
                    return ItemService.RetrieveFullCountryOfOrigin(item.CountryOfOrigin) + " - " + item.CountryOfOrigin;
                case "Default Actual Cost CAD":
                    return item.DefaultActualCostCad;
                case "Default Actual Cost USD":
                    return item.DefaultActualCostUsd;
                case "Description":
                    return item.Description;
                case "Direct Import":
                    return item.DirectImport;
                case "EAN":
                    return item.Ean;
                case "Ecommerce ASIN":
                    return item.Ecommerce_Asin;
                case "Ecommerce Bullet ALL":
                    return MergeBullets(item);
                case "Ecommerce Bullet ALL Bulleted":
                    return ModifyBulletedCopy(item);
                case "Ecommerce Bullet 1":
                    return item.Ecommerce_Bullet1;
                case "Ecommerce Bullet 2":
                    return item.Ecommerce_Bullet2;
                case "Ecommerce Bullet 3":
                    return item.Ecommerce_Bullet3;
                case "Ecommerce Bullet 4":
                    return item.Ecommerce_Bullet4;
                case "Ecommerce Bullet 5":
                    return item.Ecommerce_Bullet5;
                case "Ecommerce Components":
                    return ModifyComponents(item.Ecommerce_Components);
                case "Ecommerce Components Count":
                    return ReturnNumberOfComponents(item.Ecommerce_Components);
                case "Ecommerce Cost":
                    return item.Ecommerce_Cost;
                case "Ecommerce Country of Origin":
                    return item.Ecommerce_CountryofOrigin;
                case "Ecommerce External ID":
                    return item.Ecommerce_ExternalId;
                case "Ecommerce External ID Type":
                    return item.Ecommerce_ExternalIdType;
                case "Ecommerce Image Path 1":
                    return SetImagePath(item.Ecommerce_ImagePath1);
                case "Ecommerce Image Path 2":
                    return SetImagePath(item.Ecommerce_ImagePath2);
                case "Ecommerce Image Path 3":
                    return SetImagePath(item.Ecommerce_ImagePath3);
                case "Ecommerce Image Path 4":
                    return SetImagePath(item.Ecommerce_ImagePath4);
                case "Ecommerce Image Path 5":
                    return SetImagePath(item.Ecommerce_ImagePath5);
                case "Ecommerce Item Height":
                    return item.Ecommerce_ItemHeight;
                case "Ecommerce Item Length":
                    return item.Ecommerce_ItemLength;
                case "Ecommerce Item Name":
                    return item.Ecommerce_ItemName;
                case "Ecommerce Item Weight":
                    return item.Ecommerce_ItemWeight;
                case "Ecommerce Item Weight (milliliters)":
                    return DbUtil.ConvertToMilliliters(item.Ecommerce_ItemWeight);
                case "Ecommerce Item Width":
                    return item.Ecommerce_ItemWidth;
                case "Ecommerce Model Name":
                    return item.Ecommerce_ModelName;
                case "Ecommerce Package Height":
                    return item.Ecommerce_PackageHeight;
                case "Ecommerce Package Length":
                    return item.Ecommerce_PackageLength;
                case "Ecommerce Package Weight":
                    return item.Ecommerce_PackageWeight;
                case "Ecommerce Package Width":
                    return item.Ecommerce_PackageWidth;
                case "Ecommerce Page Qty":
                    return item.Ecommerce_PageQty;
                case "Ecommerce Product Category":
                    return item.Ecommerce_ProductCategory;
                case "Ecommerce Product Description":
                    return item.Ecommerce_ProductDescription;
                case "Ecommerce Product Subcategory":
                    return item.Ecommerce_ProductSubcategory;
                case "Ecommerce Manufacturer Name":
                    return item.Ecommerce_ManufacturerName;
                case "Ecommerce Msrp":
                    return item.Ecommerce_Msrp;
                case "Ecommerce Search Terms":
                    return TrimSearchTerms(item.Ecommerce_SearchTerms, customer);
                case "Ecommerce Size":
                    return item.Ecommerce_Size;
                case "Ecommerce Upc":
                    return item.Ecommerce_Upc;
                case "GPC":
                    return item.Gpc;
                case "Image Path":
                    return item.ImagePath;
                case "Image Path 1":
                    return item.ImagePath;
                case "Image Path 2":
                    return item.AltImageFile1;
                case "Image Path 3":
                    return item.AltImageFile2;
                case "Image Path 4":
                    return item.AltImageFile3;
                case "Image Path 5":
                    return item.AltImageFile4;
                case "In Stock Date":
                    return item.InStockDate;
                case "Innerpack Height":
                    return item.InnerpackHeight;
                case "Innerpack Length":
                    return item.InnerpackLength;
                case "Innerpack Weight":
                    return item.InnerpackWeight;
                case "Innerpack Width":
                    return item.InnerpackWidth;
                case "Innerpack Qty":
                    return item.InnerpackQuantity;
                case "ISBN":
                    return item.Isbn;
                case "Item Category":
                    return item.ItemCategory;
                case "Item Family":
                    return item.ItemFamily;
                case "Item Group":
                    return item.ItemGroup;
                case "Item Height":
                    return item.Height;
                case "Item Keywords":
                    return item.ItemKeywords;
                case "Item ID":
                    return item.ItemId;
                case "Item ID + EC":
                    return item.ItemId + "EC";
                case "Item Length":
                    return item.Length;
                case "Item Weight":
                    return item.Weight;
                case "Item Width":
                    return item.Width;
                case "Label Color":
                    return item.Color;
                case "Language":
                    return item.Language;
                case "License":
                    return item.License;
                case "License Begin Date":
                    return item.LicenseBeginDate;
                case "List Price (CAD)":
                    return item.ListPriceCad;
                case "List Price (MXN)":
                    return item.ListPriceMxn;
                case "List Price (USD)":
                    return item.ListPriceUsd;
                case "Meta Description":
                    return item.MetaDescription;
                case "Mfg Source":
                    return item.MfgSource;
                case "MSRP":
                    return item.Msrp;
                case "MSRP CAD":
                    return item.MsrpCad;
                case "MSRP MXN":
                    return item.MsrpMxn;
                case "Price Group (Product)":
                    return item.PricingGroup;
                case "Print On Demand":
                    return item.PrintOnDemand;
                case "Product Format":
                    return item.ProductFormat;
                case "Product Group":
                    return item.ProductGroup;
                case "Product ID":
                    return item.ItemId;
                case "Product Id Translation":
                    return item.ReturnProductIdTranslations();
                case "Product Line":
                    return item.ProductLine;
                case "Product Qty":
                    return item.ProductQty;
                case "Property":
                    return item.Property;
                case "PS Status":
                    return item.PsStatus;
                case "SAT Code":
                    return item.SatCode;
                case "Sell On All Posters":
                    return item.SellOnAllPosters;
                case "Sell On Amazon":
                    return item.SellOnAmazon;
                case "Sell On Fanatics":
                    return item.SellOnFanatics;
                case "Sell On Guitar Center":
                    return item.SellOnGuitarCenter;
                case "Sell On Hayneedle":
                    return item.SellOnHayneedle;
                case "Sell On Target":
                    return item.SellOnTarget;
                case "Sell On Trends":
                    return item.SellOnTrends;
                case "Sell On Walmart":
                    return item.SellOnWalmart;
                case "Sell On Wayfair":
                    return item.SellOnWayfair;
                case "Short Description":
                    return item.ShortDescription;
                case "Size":
                    return item.Size;
                case "Stats Code":
                    return item.StatsCode;
                case "Tariff Code":
                    return item.TariffCode;
                case "Territory":
                    return item.Territory;
                case "Title":
                    return item.Title;
                case "UDEX":
                    return item.Udex;
                case "UPC":
                    return item.Upc;
                case "Variant Attribute Name":
                    return ReturnVariantAttributeName(item.ItemId, customer);
                case "Variant Group Id":
                    return ReturnVariantGroupId(item.ItemId);
                case "Website Price":
                    return item.WebsitePrice;
            }
            return "";
        }

        /// <summary>
        ///     Retrieves the coresponding layout id for the given layout
        /// </summary>
        /// <param name="layoutName"></param>
        /// <returns></returns>
        public string RetrieveExcelLayoutCustomer(string layoutName)
        {
            foreach (Layout layout in LayoutList)
            {
                if (layout.Name == layoutName)
                {
                    return layout.Customer;
                }
            }
            return "";
        }

        /// <summary>
        ///     Retrieves the coresponding layout id for the given layout
        /// </summary>
        /// <param name="layoutName"></param>
        /// <returns></returns>
        public int RetrieveExcelLayoutId(string layoutName)
        {
            return TemplateRepository.RetrieveExcelLayoutId(layoutName);
        }

        /// <summary>
        ///     Retrieves the coresponding productType for the given layout
        /// </summary>
        /// <param name="layoutName"></param>
        /// <returns></returns>
        public string RetrieveExcelLayoutProductType(string layoutName)
        {
            foreach (Layout layout in LayoutList)
            {
                if (layout.Name == layoutName)
                {
                    return layout.ProductType;
                }
            }
            return "";
        }

        /// <summary>
        ///     Retrieves a list of excel columns for the given layout name
        /// </summary>
        /// <param name="layoutName"></param>
        /// <returns></returns>
        public ObservableCollection<ExcelCell> RetrieveExcelLayoutData(string layoutName)
        {
            return TemplateRepository.RetrieveExcelLayoutData(layoutName);
        }

        /// <summary>
        ///     Retrieves a sorted list of existing excel layout names
        /// </summary>
        /// <returns></returns>
        public List<Layout> RetrieveExcelLayouts()
        {
            List<Layout> result = TemplateRepository.RetrieveExcelLayouts();
            return result;
        }

        /// <summary>
        ///     Retrieves a sorted list of available field values
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveFieldValues()
        {
            return TemplateRepository.RetrieveFieldValues();
        }

        /// <summary>
        ///     Checks pricing group to determine if batteries are needed for this product
        /// </summary>
        /// <param name="pricingGroup"></param>
        /// <returns></returns>
        public string ReturnBatteriesNeeded(string pricingGroup)
        {
            switch (pricingGroup)
            {
                case "PENPRO1PK":
                    return "Yes";
                case "PENGLOW1PK":
                    return "Yes";
                case "DisplaysTI":
                    return "Yes";
            }
            return "No";
        }

        /// <summary>
        ///     Checks pricing group to determine the battery cell type. Returns "Nonstandard battery" or ""
        /// </summary>
        /// <param name="pricingGroup"></param>
        /// <returns></returns>
        public string ReturnBatteryCellType(string pricingGroup)
        {
            switch (pricingGroup)
            {
                case "PENPRO1PK":
                    return "Nonstandard battery";
                case "PENGLOW1PK":
                    return "Nonstandard battery";
                case "DisplaysTI":
                    return "Nonstandard battery";
            }
            return "";
        }

        /// <summary>
        ///     Determines the Brand Name based on the product line provided. Return brand name or blank.
        /// </summary>
        /// <param name="prodLine"></param>
        /// <returns></returns>
        public string ReturnBrandName(string prodLine)
        {
            switch (prodLine)
            {
                case "Bookmarks":
                    return "Antioch";
                case "Gift Wrap":
                    return "Sandylion (SADE7)";
                case "Inkworks":
                    return "InkWorks (INKWA)";
                case "Journals":
                    return "Trends Journals";
                case "Paper Art":
                    return "SandyLion (SADE7)";
                case "Decals":
                    return "SandyLion (SADE7)";
                case "Office & Education":
                    return "SandyLion (SADE7)";
                case "Kid's Stickers":
                    return "SandyLion (SADE7)";
                case "Tattoos":
                    return "SandyLion (SADE7)";
            }
            return "";
        }

        /// <summary>
        ///     Returns a browse keyword based on the Ecommerce Product Subcategory.
        /// </summary>
        /// <param name="prodSubcategory"></param>
        /// <returns></returns>
        public string ReturnBrowseKeyword(string prodSubcategory)
        {
            switch (prodSubcategory)
            {
                case "Paper Crafts":
                    return "art-paper-products";
                case "Scrapbooking":
                    return "scrapbooking-supplies";                
            }
            return prodSubcategory;
        }
        
        /// <summary>
        ///     Iterates through Alphabet and assigns the alpha collumn name of the number given
        /// </summary>
        /// <param name="i">the column for alpha name retrieval</param>
        /// <returns>alpha collumn name</returns>
        public string ReturnColumLetter(int columnNumber)
        {
            string value = string.Empty;
            if (columnNumber <= Alphabet.Count())
            {
                value = Alphabet[columnNumber - 1];
            }
            else
            {
                int set = columnNumber / 26;
                int letter = columnNumber - (set * 26);
                if (letter == 0) { letter = 26; }
                if (columnNumber % 26 == 0)
                {
                    value = Alphabet[set - 2].ToString() + Alphabet[letter - 1];
                }
                else
                {
                    value = Alphabet[set - 1].ToString() + Alphabet[letter - 1];
                }
            }
            return value;
        }

        /// <summary>
        ///     Reads the number of each component contained in an item and returns the total amount of items.
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        public string ReturnNumberOfComponents(string components)
        {
            int componentCount = 0;
            string[] componentList = components.Split('^');
            foreach(string x in componentList)
            {
                if(x.Contains("("))
                {
                    string[] y = x.Split('(');
                    string z = y[1].Replace(")", "");
                    if (DbUtil.IsNumber(z))
                    {
                        componentCount += Convert.ToInt32(z);
                    }
                    else
                    {
                        componentCount += 1;
                    }
                }
                else
                {
                    componentCount += 1;
                }
            }

            return componentCount.ToString();
        }

        /// <summary>
        ///     Combines the license and property values for website if property exists.
        /// </summary>
        /// <param name="license"></param>
        /// <param name="property"></param>
        /// <returns>Valid Magento property value</returns>
        public string ReturnProperty(string license, string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return "";
            }
            else
            {
                return license + ": " + property;
            }
        }

        public string ReturnRequestNum()
        {
            return Convert.ToString(RequestNum);
        }

        /// <summary>
        ///     Returns the Variant Attribute Name based on the item it prefix
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public string ReturnVariantAttributeName(string itemId, string customer)
        {
            string style = "Unframed Version";

            if (itemId.Substring(0, 2) == "FR")
            {
                if (itemId.Contains("SIL"))
                {
                    style = "Silver Framed Version";
                }
                else if (itemId.Contains("BLK"))
                {
                    style = "Black Framed Version";
                }
                else
                {
                    style = "Framed Version";
                }
            }
            if (itemId.Substring(0, 3) == "POD")
            {
                style = "Premium Unframed";
                if (customer == "Walmart")
                {
                    style = "Premium Unframed Version";
                }
            }
            return style;
        }

        /// <summary>
        ///     Strips the prefixes and suffixes off the item id and returns the varient group id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public string ReturnVariantGroupId(string itemId)
        {
            List<string> filters = new List<string>();
            string result = itemId.Trim();
            foreach (string x in GlobalData.VariantGroupExclusionOptions)
            {
                filters.Add(x.Trim());
            }
            filters.Sort((a, b) => b.Length.CompareTo(a.Length));
            foreach (string x in filters)
            {
                result = result.Replace(x, "");
            }
            return result;
        }

        #endregion // Retrieval Methods
        
        /// <summary>
        ///     Submit data for a request submission
        /// </summary>
        /// <param name="Items"></param>
        public void SubmitRequest(ObservableCollection<ItemObject> Items, string status, string Comment)
        {
            RequestNum = Convert.ToInt32(RequestRepository.RetrieveSubmitRequestNumber());
            RequestRepository.SubmitRequest(Items, status, Comment, RequestNum);
        }
        
        /// <summary>
        ///     Writes out the first row it headers into the template file
        /// </summary>
        /// <param name="headers"></param>
        public void WriteHeaders(List<string> headers)
        {
            int count = 1;
            foreach (string header in headers)
            {
                worksheet.Cells[1, count] = header;
                count++;
            }
        }

        /// <summary>
        ///     Writes out the data for the magento upload file
        /// </summary>
        /// <param name="itemList"></param>
        /// <param name="requestId"></param>
        /// <param name="requestType"></param>
        public void WriteMagentoCsv(ObservableCollection<ItemObject> itemList, string requestId, string requestType)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<string> CSV_Add = new List<string>();
            List<string> CSV_Add_Image = new List<string>();
            List<string> CSV_REMOVE = new List<string>();
            CSV_Add.Add(CreateMagentoHeaders());
            CSV_REMOVE.Add("sku,status");
            CSV_Add_Image.Add("sku, image, thumbnail, small_image");
            foreach (ItemObject item in itemList)
            {
                if ((requestType == "Add") || (requestType == "Update"))
                {
                    string newString = string.Empty;
                    string newdate = "";
                    string USDPrice = item.ListPriceUsd;
                    string CADPrice = item.ListPriceCad;
                    string productFormat = DbUtil.ReplaceCharacters(item.ProductFormat);
                    string category = string.Empty;
                    // Replace size placeholder with blank
                    if (item.Size == "'' x '' x ''")
                    {
                        item.Size = "";
                    }

                    List<string> cats = this.NewCategories(item.Category, item.Category2, item.Category3);
                    if (!string.IsNullOrEmpty(item.NewDate))
                    {
                        DateTime dt = Convert.ToDateTime(item.NewDate);
                        newdate = dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString() + " 12:00";
                    }
                    else
                    {
                        DateTime dt = DateTime.Now;
                        newdate = dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString() + " 12:00";

                    }
                    string inStockDate = string.IsNullOrEmpty(item.InStockDate) ? newdate : item.InStockDate;
                    //remove zeros at the end of dimensions
                    string length = item.Length;
                    string format = DbUtil.ReplaceCharacters(item.ProductFormat).Trim();
                    // string title = string.IsNullOrEmpty(item.Title) ? item.Description.Replace(item.MetaDescription, "") : item.Title;
                    string title = DbUtil.ReplaceQuotes(item.Title);
                    string metaDescription = DbUtil.ReplaceQuotes(item.MetaDescription);
                    newString += "\"" + item.ItemId.Trim() + "\","; /* "sku" */
                    newString += "default,"; /* "_store" */
                    newString += "\"" + ItemService.SetProductType(cats) + "\","; /* "_attribute_set" */
                    newString += "\"simple\","; /* _type */
                    newString += ",";/* _category */
                    newString += "\"Default Category\","; /* _root_category */
                    newString += "\"base\","; /* _product_websites */
                    newString += ","; /* color */
                    newString += ","; /* cost */
                    newString += ","; /* country_of_manufacture */
                    newString += "\"" + newdate + "\","; /* created_at */
                    newString += "\"0\","; /* has_options */
                    newString += "\"" + item.Height + "\","; /* height */
                    newString += "\"" + DbUtil.OrderLanguage(item.Language) + "\","; /* language */
                    newString += "\"" + item.Copyright + "\","; /* legal */
                    newString += "\"" + item.License.Trim() + "\","; /* license */
                    newString += "\"" + ReturnProperty(item.License.Trim(), item.Property.Trim()) + "\","; /* property */
                    newString += ","; /* "license_end_date" */
                    newString += "\"" + metaDescription.Trim() + "\","; /* meta_description */
                    newString += "\"" + ModifyKeywords(item.ItemId, item.ItemKeywords).Trim() + "\","; /* meta_keyword */
                    newString += "\"" + title.Trim() + "\","; /* meta_title */
                    newString += "\"" + item.Msrp.Trim() + "\","; /* msrp */
                    newString += "\"" + item.MsrpCad.Trim() + "\","; /* msrpcan */
                    newString += "\"Use config\","; /* msrp_display_actual_price_type */
                    newString += "\"Use config\","; /* msrp_enabled */
                    newString += "\"" + title.Trim() + "\","; /* name */
                    newString += "\"" + DateTime.Today.ToString() + "\","; /* date_added */
                    newString += "\"" + DateTime.Today.ToString() + "\","; /* news_from_date */
                    newString += "\"" + ItemService.RetrieveNewToDate("") + "\","; /* news_to_date */
                    newString += "\"Product Info Column\","; /* options_container */
                    newString += "\"" + ItemService.ReturnItemPrice(USDPrice.Trim(), item.ProductQty) + "\","; /* price */
                    newString += "\"" + ItemService.ReturnItemPrice(CADPrice.Trim(), item.ProductQty) + "\","; /* pricecan */
                    newString += "\"0\","; /* required_options */
                    newString += "\"" + item.ShortDescription.Trim() + "\","; /* short_description */
                    newString += "\"1\","; /* status */
                    newString += "\"0\","; /* tax_class_id */
                    newString += "\"" + DbUtil.OrderTerritory(item.Territory.Trim()) + "\","; /* territory */
                    newString += "\"" + item.Upc.Trim() + "\","; /* upc */
                    newString += ","; /* updated_at */
                    newString += "\"" + item.ItemId.Trim() + "\","; /* url_key */
                    newString += "\"" + item.ItemId.Trim() + ".html\","; /* url_path */
                    newString += "\"4\",";/* visibility */
                    newString += "\"" + item.Weight.Trim() + "\","; /* weight */
                    newString += "\"" + item.Width + "\","; /* width */
                    newString += "\"" + item.Size.Replace("\"", "''").Trim() + "\","; /* size */
                    newString += "\"0\","; /* min_qty */
                    newString += "\"" + item.ProductQty.Trim() + "\",";  /* pack_qty */
                    newString += "\"1\","; /* use_config_min_qty */
                    newString += "\"0\","; /* is_qty_decimal */
                    newString += "\"0\","; /* backorders */
                    newString += "\"1\","; /* use_config_backorders */
                    newString += "\"1\","; /* min_sale_qty */
                    newString += "\"1\","; /* use_config_min_sale_qty */
                    newString += "\"0\","; /* max_sale_qty */
                    newString += "\"1\","; /* use_config_min_qty */
                    newString += "\"0\","; /* is_in_stock */
                    newString += "\"1\","; /* "notify_stock_qty" */
                    newString += "\"1\","; /* "use_config_notify_stock_qty" */
                    newString += "\"0\","; /* "manage_stock" */
                    newString += "\"1\","; /* "use_config_manage_stock" */
                    newString += "\"1\","; /* "stock_status_changed_auto" */
                    newString += "\"1\","; /* "use_config_qty_increments" */
                    newString += "\"0\","; /* qty_increments */
                    newString += "\"1\",";/* use_config_enable_qty_inc */
                    newString += "\"0\","; /* enable_qty_increments */
                    newString += "\"0\","; /*is_decimal_divided */
                    newString += "\"\","; /*_links_related_sku */
                    newString += "\"0\","; /*_links_related_position */
                    newString += "\"88\","; /* _media_attribute_id */
                    newString += "\"2\","; /* _media_position */
                    newString += "\"0\","; /* _media_is_disabled */
                    if (item.OnSite != "Y")
                    {
                        newString += "\"0\","; /* qty */
                        newString += "\"" + "1/1/1970" + "\""; /* "license_begin_date" */
                    }
                    CSV_Add.Add(newString);
                    if (item.Territory.Contains("CAN") || item.Territory.Contains("WW"))
                    {
                        string canPrice = "";
                        canPrice += ","; /* "sku" */
                        canPrice += "\"can_view\","; /* "_store" */
                        canPrice += ","; /* "_attribute_set" */
                        canPrice += "\"simple\","; /* _type */
                        canPrice += "\"All Products\",";/* _category */
                        canPrice += "\"Default Category\","; /* _root_category */
                        canPrice += "\"can_website\","; /* _product_websites */
                        canPrice += ","; /* color */
                        canPrice += ","; /* cost */
                        canPrice += ","; /* country_of_manufacture */
                        canPrice += ","; /* created_at */
                        canPrice += ","; /* has_options */
                        canPrice += ","; /* height */
                        canPrice += ","; /* language */
                        canPrice += ","; /* legal */
                        canPrice += ","; /* license */
                        canPrice += ","; /* property */
                        canPrice += ","; /* license_end_date */
                        canPrice += ","; /* meta_description */
                        canPrice += ","; /* meta_keyword */
                        canPrice += ","; /* meta_title */
                        canPrice += "\"" + item.MsrpCad.Trim() + "\","; /* msrp */
                        canPrice += ","; /* msrpcan */
                        canPrice += ","; /* msrp_display_actual_price_type */
                        canPrice += ","; /* msrp_enabled */
                        canPrice += ","; /* name */
                        canPrice += ","; /* date_added */
                        canPrice += ","; /* news_from_date */
                        canPrice += ","; /* news_to_date */
                        canPrice += ","; /* options_container */
                        canPrice += "\"" + ItemService.ReturnItemPrice(CADPrice.Trim(), item.ProductQty) + "\","; /* price */
                        canPrice += "\"" + ItemService.ReturnItemPrice(CADPrice.Trim(), item.ProductQty) + "\","; /* pricecan */
                        canPrice += "\"0\","; /* required_options */
                        canPrice += "\"" + item.ShortDescription.Trim() + "\","; /* short_description */
                        canPrice += "\"1\","; /* status */
                        canPrice += "\"4\","; /* tax_class_id */
                        CSV_Add.Add(canPrice);
                    }
                    else
                    {
                        string canPrice = "";
                        canPrice += ","; /* "sku" */
                        canPrice += ","; /* "_store" */
                        canPrice += ","; /* "_attribute_set" */
                        canPrice += ","; /* _type */
                        canPrice += "\"All Products\",";/* _category */
                        canPrice += "\"Default Category\""; /* _root_category */
                        CSV_Add.Add(canPrice);
                    }
                    if (cats.Count > 0)
                    {
                        int catCount = 0;
                        while (catCount < cats.Count)
                        {
                            string meow = cats[catCount].Replace("\"", "\'\'");
                            string catString = "";
                            catString += ","; /* "sku" */
                            catString += ","; /* "_store" */
                            catString += ","; /* "_attribute_set" */
                            catString += ","; /* _type */
                            catString += "\"" + DbUtil.ReplaceQuotes(meow) + "\",";/* _category */
                            catString += "\"Default Category\","; /* _root_category */

                            CSV_Add.Add(catString);
                            catCount++;
                        }
                    }

                    if (item.ItemId.ToUpper().Substring(0, 2) == "RP")
                    {
                        string img = "/" + item.ItemId.Substring(2, item.ItemId.Length - 2) + ".jpg";
                        CSV_Add_Image.Add(item.ItemId + ", " + img + ", " + img + ", " + img);
                    }
                    else
                    {
                        string img = "/" + item.ItemId + ".jpg";
                        CSV_Add_Image.Add(item.ItemId + ", " + img + ", " + img + ", " + img);
                    }
                }

                else if (requestType == "Remove")
                {
                    string newString = string.Empty;
                    newString = item.ItemId.Trim() + ",2";
                    CSV_REMOVE.Add(newString);
                }

                if (CSV_REMOVE.Count > 1)
                {
                    int RemoveLength = CSV_REMOVE.Count;
                    string filePath = desktop + @"\Request-" + "-" + requestId + "_Remove_New.csv";
                    string delimiter = ",";

                    StringBuilder sb = new StringBuilder();
                    for (int index = 0; index < RemoveLength; index++)
                        sb.AppendLine(string.Join(delimiter, CSV_REMOVE[index]));

                    File.WriteAllText(filePath, sb.ToString());
                }
                if (CSV_Add.Count > 1)
                {
                    string csvFilePath = desktop + @"\Request-" + "-" + requestId + "_Au_New.csv";
                    string csvImageFilePath = desktop + @"\Request-" + "-" + requestId + "_Au_Images.csv";
                    string delimiter = ",";
                    StringBuilder sb = new StringBuilder();
                    StringBuilder sbl = new StringBuilder();
                    StringBuilder sbi = new StringBuilder();
                    for (int index = 0; index < CSV_Add.Count; index++)
                    {
                        sb.AppendLine(string.Join(delimiter, CSV_Add[index]));
                    }
                    for (int index = 0; index < CSV_Add_Image.Count; index++)
                    {
                        sbi.AppendLine(string.Join(delimiter, CSV_Add_Image[index]));
                    }
                    File.WriteAllText(csvFilePath, sb.ToString());
                    File.WriteAllText(csvImageFilePath, sbi.ToString());


                }
            } // End foreach (Request request in requests)
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the excel service
        /// </summary>
        /// <param name="isTest"></param>
        /// <param name="itemService"></param>
        /// <param name="requestReposiory"></param>
        public ExcelService(bool isTest, ItemService itemService, OptionService optionService, ITemplateRepository templateRepository, IRequestRepository requestReposiory)
        {
            if (!GlobalData.FtpUserexceptions.Contains(GlobalData.UserName))
            {
                this.FtpService = new FtpService();
            }
            else
            {
                this.FtpService = null;
            }
            this.ItemService = itemService ?? throw new ArgumentNullException("itemService");
            this.RequestRepository = requestReposiory ?? throw new ArgumentNullException("requestReposiory");
            this.OptionService = optionService ?? throw new ArgumentNullException("optionService");
            this.TemplateRepository = templateRepository ?? throw new ArgumentNullException("templateRepository");
            PopulateTemplateHeaders();
            this.LayoutList = RetrieveExcelLayouts();
        }

        #endregion // Constructor
    }
}
