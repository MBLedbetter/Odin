using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelLibrary
{
    public class WorksheetData
    {
        #region Properties

        public List<string> ColumnHeaders { get; private set; }

        /// <summary>
        ///     Gets a 2d array that contains a worksheets data. The first index indicates row
        ///     index and the 2nd index is the column index.
        /// </summary>
        public List<List<string>> CellData { get; private set; }

        #endregion // Properties
        
        public string GetValue(int row, params string[] columnHeaders)
        {
            foreach (string columnHeader in columnHeaders)
            {
                for (int column = 0; column < this.ColumnHeaders.Count; column++)
                {
                    if (this.ColumnHeaders[column] != null && row < this.CellData.Count && column < this.CellData[row].Count && this.CellData[row][column]!=null)
                    {
                        if (this.ColumnHeaders[column].ToUpper().Replace(" ", "") == columnHeader.ToUpper().Replace(" ", ""))
                        {
                            return this.CellData[row][column];
                        }
                    }
                }
            }
            return "";
        }

        #region Constructor
        public WorksheetData()
        {
            this.ColumnHeaders = new List<string>();
            this.CellData = new List<List<string>>();
        }
        #endregion // Constructor
    }
}
