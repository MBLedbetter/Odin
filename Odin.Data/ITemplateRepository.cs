using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Odin.Data
{
    public interface ITemplateRepository
    {
        #region Public Methods

        #region Public Insert Methods

        /// <summary>
        ///     Runs InsertExcelLayoutColumn foreach object in the cellList
        /// </summary>
        /// <param name="cellList"></param>
        /// <returns></returns>
        void InsertExcelLayoutColumns(ObservableCollection<ExcelCell> cellList);

        /// <summary>
        ///     Inserts a column data into ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <param name="layoutName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        void InsertExcelLayout(string layoutName, string customer, string productType);

        /// <summary>
        ///     Insert a template into the db
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        void InsertTemplate(Template template);

        #endregion // Public Insert Methods

        #region Public Removal Methods

        /// <summary>
        ///     Removes layout data associate with the given layout id
        /// </summary>
        /// <param name="layoutName"></param>
        void RemoveExcelLayout(int layoutId);

        /// <summary>
        ///     Removes all column data for the given layout from EXCEL_LAYOUT_DATA
        /// </summary>
        /// <param name="layoutId"></param>
        /// <returns></returns>
        void RemoveExcelLayoutColumns(int layoutId);

        /// <summary>
        ///     Remove the given template from ODIN_ITEM_TEMPLATES
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        void RemoveTemplate(string templateId);

        #endregion // Public Removal Methods

        #region Public Retrieval Methods

        /// <summary>
        ///     Retrieves a list of excel columns from ODIN_EXCEL_LAYOUT_DATA
        /// </summary>
        /// <param name="layoutName"></param>
        /// <returns></returns>
        ObservableCollection<ExcelCell> RetrieveExcelLayoutData(string layoutName);

        /// <summary>
        ///     Retrieves the coresponding layout id for the given layout name from ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <param name="layoutName"></param>
        /// <returns></returns>
        int RetrieveExcelLayoutId(string layoutName);

        /// <summary>
        ///     Retrieves a list of existing excel layout names from ODIN_EXCEL_LAYOUT_IDS
        /// </summary>
        /// <returns></returns>
        List<Layout> RetrieveExcelLayouts();

        /// <summary>
        ///     Retrieves a list of available field values from ODIN_FIELD_VALUES
        /// </summary>
        /// <returns></returns>
        List<string> RetrieveFieldValues();

        /// <summary>
        ///     Retrieve a List of names for all existing templates
        /// </summary>
        /// <returns></returns>
        List<string> RetrieveTemplateNameList();

        /// <summary>
        ///     Retrieves a template from the db
        /// </summary>
        /// <returns></returns>
        Template RetrieveTemplate(string templateId);

        #endregion // Public Retrieval Methods

        #region Public Update Methods

        /// <summary>
        ///     Updates an existing template
        /// </summary>
        /// <returns></returns>
        void UpdateTemplate(Template template, string status);

        #endregion // Public Update Methods

        #endregion // Public Methods
    }
}
