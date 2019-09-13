namespace ExcelLibrary
{

	/// <summary>
	///		This class contains information about a column in an Excel worksheet.
	/// </summary>
	public class WorksheetColumn
	{

		#region Public Properties

		/// <summary>
		///		Gets or sets a ColumnFormat object that contains information about this column's
		///		formatting.  If this property is null, then no special formatting will be applied
		///		to this column.
		/// </summary>
		public ColumnFormat Format { get; set; }

		/// <summary>
		///		Gets or sets this column's heading text.
		/// </summary>
		public string HeadingText { get; set; }

		#endregion	// Public Properties

		#region Constructors

		/// <summary>
		///		WorksheetColumn constructor.
		/// </summary>
		/// 
		/// <param name="headingText">
		///		This column's heading text.
		///	</param>
		public WorksheetColumn(string headingText)
		{
			this.HeadingText = headingText;
		}

		#endregion	// Constructors

	}

}
