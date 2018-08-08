using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OdinRepositories
{
    public interface ITemplateRepository
    {
        bool InsertExcelLayoutColumn(ExcelCell value, SqlTransaction transaction);
        bool InsertExcelLayoutColumns(ObservableCollection<ExcelCell> cellList);
        bool InsertExcelLayout(int id, string value, string customer, string productType);
        bool InsertTemplate(Template value);
        bool RemoveExcelLayoutColumns(string layoutId);
        bool RemoveTemplate(string templateName);
        List<string> RetrieveFieldValues();
        ObservableCollection<ExcelCell> RetrieveExcelLayoutData(string layoutName);
        string RetrieveExcelLayoutId(string layoutName);
        List<Layout> RetrieveExcelLayouts();
        Template RetrieveTemplate(string name);
        bool UpdateTemplate(Template template, string status);
        List<string> RetrieveTemplateNameList();
    }
}
