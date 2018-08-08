using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelLibrary;

namespace Odin.Services.Tests.Helpers
{
    class FakeWorkbookReader : IWorkbookReader
    {
        #region Public Properties

        public List<string> ColumnHeaders { get; private set; }

        public List<List<string>> ExcellData { get; private set; }

        #endregion // Public Properties

        #region Methods

        public WorksheetData ReadWorksheet(string fileName)
        {
            WorksheetData worksheetData = new WorksheetData();
            for (int i = 0; i < ColumnHeaders.Count(); i++)
            {
                worksheetData.ColumnHeaders.Add(this.ColumnHeaders[i]);
            }
            for (int row = 0; row < ExcellData.Count(); row++)
            {
                worksheetData.CellData.Add(new List<string>());
                for (int column = 0; column < ExcellData[row].Count(); column++)
                {
                    worksheetData.CellData[worksheetData.CellData.Count - 1].Add(ExcellData[row][column]);
                }
            }
            return worksheetData;
        }

        public void AddWorksheetRow() 
        {
            this.ExcellData.Add(new List<string>());        
        }

        public void AddCellValue(string value)
        {
            this.ExcellData[ExcellData.Count - 1].Add(value);
        }

        #endregion // Methods

        #region Constructor

        public FakeWorkbookReader()
        {
            this.ColumnHeaders = new List<string>();
            this.ExcellData = new List<List<string>>();
        }

        #endregion // Constructor
    }
}
