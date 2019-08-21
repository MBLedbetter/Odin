namespace ExcelLibrary
{
	
	/// <summary>
	///		This class defines formatting information for a single column or a range of continguous
	///		columns in an Excel worksheet.
	/// </summary>
	public class ColumnFormat : RangeFormat
	{

		#region Public Properties

		/// <summary>
		///		Gets or sets the 1-based index of the leftmost column that this formatting 
		///		information applies to.
		/// </summary>
		public int LeftColumnNumber { get; set; }

		/// <summary>
		///		Gets or sets the 1-based index of the rightmost column that this formatting
		///		information applies to.
		/// </summary>
		public int RightColumnNumber { get; set; }

		/// <summary>
		///		Gets or sets this column's width.
		/// </summary>
		public decimal? Width { get; set; }

		#endregion	// Public Properties

		#region Constructors

		/// <summary>
		///		This constructor creates a ColumnFormat object that applies to a single column.
		/// </summary>
		/// 
		/// <param name="columnNumber">
		///		The 1-based index of the column that this formatting information applies to.
		///	</param>
		public ColumnFormat(int columnNumber)
		{
			this.LeftColumnNumber = columnNumber;
			this.RightColumnNumber = columnNumber;
		}

		/// <summary>
		///		This constructors creates a ColumFormat object that applies to a range of 
		///		contiguous columns.
		/// </summary>
		/// 
		/// <param name="leftColumnNumber">
		///		The 1-based index of the leftmost column that this formatting information applies
		///		to.
		///	</param>
		///	
		/// <param name="rightColumnNumber">
		///		The 1-based index of the rightmost column that this formatting information applies
		///		to.
		///	</param>
		public ColumnFormat(int leftColumnNumber, int rightColumnNumber)
		{
			this.LeftColumnNumber = leftColumnNumber;
			this.RightColumnNumber = rightColumnNumber;
		}

		#endregion	// Constructors

	}

}
