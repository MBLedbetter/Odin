
namespace ExcelLibrary
{

	/// <summary>
	///		This class defines formatting information for a single cell or a range of contiguous 
	///		cells in an Excel worksheet.
	/// </summary>
	public class CellFormat : RangeFormat
	{

		#region Public Properties

		/// <summary>
		///		Gets or sets the 1-based row number of the bottom of this range.
		/// </summary>
		public int BottomRowNumber { get; set; }

		/// <summary>
		///		Gets or sets the 1-based column number of the left side of this range.
		///	</summary>
		public int LeftColumnNumber { get; set; }

		/// <summary>
		///		Gets or sets the 1-based column number of the right side of this range.
		///	</summary>
		public int RightColumnNumber { get; set; }

		/// <summary>
		///		Gets or sets the 1-based row number of the top of this range.
		/// </summary>
		public int TopRowNumber { get; set; }

		#endregion	// Public Properties

		#region Constructors

		/// <summary>
		///		This constructor creates a CellFormat object for a single cell.
		/// </summary>
		/// 
		/// <param name="rowNumber">
		///		The 1-based row number of this cell.
		///	</param>
		/// 
		/// <param name="columnNumber">
		///		The 1-based column number of this cell.
		///	</param>
		public CellFormat(int rowNumber, int columnNumber)
		{
			this.BottomRowNumber = rowNumber;
			this.LeftColumnNumber = columnNumber;
			this.RightColumnNumber = columnNumber;
			this.TopRowNumber = rowNumber;
		}

		/// <summary>
		///		This constructor creates a CellFormat object for a range of contiguous cells.
		/// </summary>
		/// 
		/// <param name="topRowNumber">
		///		The 1-based row number of the top of this range.
		///	</param>
		/// 
		/// <param name="leftColumnNumber">
		///		The 1-based column number of the left side of this range.
		///	</param>
		/// 
		/// <param name="bottomRowNumber">
		///		The 1-based row number of the bottom of this range.
		///	</param>
		/// 
		/// <param name="rightColumnNumber">
		///		The 1-based column number of the right side of this range.
		///	</param>
		public CellFormat(int topRowNumber, int leftColumnNumber, int bottomRowNumber, int rightColumnNumber)
		{
			this.BottomRowNumber = bottomRowNumber;
			this.LeftColumnNumber = leftColumnNumber;
			this.RightColumnNumber = rightColumnNumber;
			this.TopRowNumber = topRowNumber;
		}

		#endregion	// Constructors

	}

}
