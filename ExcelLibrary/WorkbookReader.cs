using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using Microsoft.Office.Interop.Excel;
using System.Windows.Input;
using System.Reflection;
using Microsoft.Win32;
using System.Windows.Forms;

namespace ExcelLibrary
{
    public class WorkbookReader : IWorkbookReader
	{
		#region Properties

		string FileName { get; set; }

        private Microsoft.Office.Interop.Excel.Application appExcel;
        private Workbook newWorkbook = null;
        private Worksheet CurrentWorksheet = null;

		#endregion // Properties

		#region Methods
        
        /// <summary>
        ///     Initializes excel sheet reading
        /// </summary>
        /// <param name="path">Excel file location</param>
        private void OpenWorkbook(String path)
        {
            appExcel = new Microsoft.Office.Interop.Excel.Application();
           

            if (System.IO.File.Exists(path))
            {
                // then go and load this into excel
                newWorkbook = appExcel.Workbooks.Open(path, true, true);
                CurrentWorksheet = (Worksheet)appExcel.ActiveWorkbook.ActiveSheet;
            }
            else
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
                appExcel = null;
            }

        }
        
        /// <summary>
        ///     Read cell value from excell sheet
        /// </summary>
        /// <param name="m">Row Number</param>
        /// <param name="a">Collumn Letter</param>
        /// <returns></returns>
        private string getValue(int m, string a, Range range)
        {
            string newValue = string.Empty;
            string rowCol = a + m.ToString();

            try
            {
                newValue = range.get_Range(rowCol).Value.ToString().Trim();
            }
            catch
            {
                newValue = "";
            }

            return newValue;
        }

        /// <summary>
        ///     Method to close excel connection
        /// </summary>
        /// 
        private void excel_close()
        {
            if (appExcel != null)
            {
                try
                {
                    newWorkbook.Close();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
                    appExcel = null;
                    CurrentWorksheet = null;
                }
                catch (Exception ex)
                {                    
                    appExcel = null;
                }
                finally
                {
                    GC.Collect();
                }
            }
        }        
        
        /// <summary>
        ///     Read item ids from excell sheet
        /// </summary>
        /// <param name="fileName">excell file path</param>
        /// <returns></returns>
        /// 
        public List<string> RetrieveIds(string fileName)
        {
            List<string> itemList = new List<string>();
            OpenWorkbook(fileName);

            Range UsedRange = CurrentWorksheet.UsedRange;
            int n = UsedRange.Row + UsedRange.Rows.Count - 1;
            int o = 0;

            Range range = CurrentWorksheet.get_Range("A2", "A3" + n.ToString());
            while (o++ < n)
            {
                bool nullFields = true;

                if (!(string.IsNullOrEmpty(range.get_Range("A" + o.ToString()).Text.ToString())))
                {
                    nullFields = false;
                }

                if (nullFields == false)
                {
                    string newItem = getValue(o, "A", range);
                    itemList.Add(newItem);
                }
            }

            excel_close();

            return itemList;
        }

        /// <summary>
        /// Reads values from the columns designated in the header obj, header obj must be set - otherwise all values will be blank
        /// </summary>
        /// <param name="i">row number</param>
        /// <returns>Item object populated with spreadsheet data</returns>
        public WorksheetData ReadWorksheet(string fileName)
        {
            WorksheetData worksheetData = new WorksheetData();
            OpenWorkbook(fileName);
            Range range = this.CurrentWorksheet.UsedRange;
            object[,] cellData = range.Value;
            if (cellData != null)
            {
                for (int row = 1; row <= cellData.GetLength(0); row++)
                {
                    if (row > 1)
                    {
                        worksheetData.CellData.Add(new List<string>());
                    }
                    for (int column = 1; column <= cellData.GetLength(1); column++)
                    {
                        if (cellData[row, 1] == null || string.IsNullOrEmpty(cellData[row, 1].ToString()))
                        {
                            break;
                        }
                        if (row == 1)
                        {
                            worksheetData.ColumnHeaders.Add(Convert.ToString(cellData[row, column]));
                        }
                        else
                        {
                            worksheetData.CellData[row - 2].Add(Convert.ToString(cellData[row, column]));
                        }
                    }
                }
            }
            return worksheetData;
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the WorkbookReader
        /// </summary>
        public WorkbookReader()
        {
        }

        #endregion // Constructor
    }
}
