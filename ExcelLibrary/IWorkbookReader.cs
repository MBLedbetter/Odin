﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelLibrary
{
    public interface IWorkbookReader
    {
        WorksheetData ReadWorksheet(string fileName);
    }
}
