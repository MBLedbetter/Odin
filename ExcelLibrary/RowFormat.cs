namespace ExcelLibrary
{

	/// <summary>
	///		This class defines formatting information for a single row or a range of contiguous
	///		rows in an Excel worksheet.
	/// </summary>
	public class RowFormat : RangeFormat
	{

		#region Public Properties

		/// <summary>
		///		Gets or sets the 1-based index of the bottom row that this formatting 
		///		information applies to.
		/// </summary>
		public int BottomRowNumber { get; set; }

		/// <summary>
		///		Gets or sets this row's height.
		/// </summary>
		public decimal? Height { get; set; }

		/// <summary>
		///		Gets or sets the 1-based index of the top row that this formatting information
		///		applies to.
		/// </summary>
		public int TopRowNumber { get; set; }

		#endregion	// Public Properties

		#region Constructors

		/// <summary>
		///		This constructor creats a RowFormat object that applies to a single row.
		/// </summary>
		/// 
		/// <param name="rowNumber">
		///		The 1-based index of the row that this formatting information applies to.
		///	</param>
		public RowFormat(int rowNumber)
		{
			this.BottomRowNumber = rowNumber;
			this.TopRowNumber = rowNumber;
		}

		/// <summary>
		///		This constructor creates a RowFormat object that applies to a range of contiguous
		///		rows.
		/// </summary>
		/// 
		/// <param name="topRowNumber">
		///		The 1-based index of the top row that this formatting information applies to.
		///	</param>
		///	
		/// <param name="bottomRowNumber">
		///		The 1-based index of the bottom row that this formatting information applies to.
		///	</param>
		public RowFormat(int topRowNumber, int bottomRowNumber)
		{
			this.BottomRowNumber = bottomRowNumber;
			this.TopRowNumber = topRowNumber;
		}

		#endregion	// Constructors

	}

}
