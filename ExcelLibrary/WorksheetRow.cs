using System.Collections.Generic;

namespace ExcelLibrary
{

	/// <summary>
	///		This class contains information about a row in an Excel worksheet.
	/// </summary>
	public class WorksheetRow
	{

		#region Public Properties

		/// <summary>
		///		Gets a list that contains each of the cell values in this row.
		/// </summary>
		public List<string> CellValues { get; private set; }

		#endregion	// Public Properties

		#region Constructors

		/// <summary>
		///		WorksheetRow constructor.
		/// </summary>
		public WorksheetRow()
		{
			this.CellValues = new List<string>();
		}

		#endregion	// Constructors

	}

}
