using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelLibrary;

namespace OdinTests.Helpers
{
    class FakeWorkbookReader : IWorkbookReader
    {
        #region Public Properties

        public List<string> ColumnHeaders { get; private set; }

        public List<List<string>> ExcelData { get; private set; }

        #endregion // Public Properties

        #region Methods

        public WorksheetData ReadWorksheet(string fileName)
        {
            WorksheetData worksheetData = new WorksheetData();
            for (int i = 0; i < ColumnHeaders.Count(); i++)
            {
                worksheetData.ColumnHeaders.Add(this.ColumnHeaders[i]);
            }
            for (int row = 0; row < ExcelData.Count(); row++)
            {
                worksheetData.CellData.Add(new List<string>());
                for (int column = 0; column < ExcelData[row].Count(); column++)
                {
                    worksheetData.CellData[worksheetData.CellData.Count - 1].Add(ExcelData[row][column]);
                }
            }
            return worksheetData;
        }

        public void AddWorksheetRow() 
        {
            this.ExcelData.Add(new List<string>());        
        }

        public void AddCellValue(string value)
        {
            this.ExcelData[ExcelData.Count - 1].Add(value);
        }

        #endregion // Methods

        #region Constructor

        public FakeWorkbookReader()
        {
            this.ColumnHeaders = new List<string>();
            this.ExcelData = new List<List<string>>();
        }

        #endregion // Constructor
    }
}
