
namespace ExcelLibrary
{

	/// <summary>
	///		This class defines information about a range of cells in a worksheet which will be 
	///		merged.
	/// </summary>
	public class CellMergeRange
	{

		#region Public Properties

		/// <summary>
		///		Gets or sets the 1-based row number of the lower right cell in this range.
		/// </summary>
		public int BottomRowNumber { get; set; }

		/// <summary>
		///		Gets or sets the 1-based column number of the upper left cell in this range.
		/// </summary>
		public int LeftColumnNumber { get; set; }

		/// <summary>
		///		Gets or sets the 1-based column number of the lower right cell in this range.
		/// </summary>
		public int RightColumnNumber { get; set; }

		/// <summary>
		///		Gets or sets the 1-based row number of the upper right cell in this range.
		/// </summary>
		public int TopRowNumber { get; set; }

		#endregion	// Public Properties

		#region Constructors

		/// <summary>
		///		CellMergeRange constructor.
		/// </summary>
		/// 
		/// <param name="topRowNumber">
		///		The 1-based row number of the upper left cell in this range.
		///	</param>
		/// 
		/// <param name="rightColumnNumber">
		///		The 1-based column number of the lower right cell in this range.
		///	</param>
		/// 
		/// <param name="leftColumnNumber">
		///		The 1-based column number of the upper left cell in this range.
		///	</param>
		/// 
		/// <param name="bottomRowNumber">
		///		The 1-based row number of the lower right cell in this range.
		///	</param>
		public CellMergeRange( int topRowNumber, int leftColumnNumber, int bottomRowNumber, int rightColumnNumber)
		{
			this.BottomRowNumber = bottomRowNumber;
			this.LeftColumnNumber = leftColumnNumber;
			this.RightColumnNumber = rightColumnNumber;
			this.TopRowNumber = topRowNumber;
		}

		#endregion	// Constructors

	}

}
