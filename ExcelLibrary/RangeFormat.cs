using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace ExcelLibrary
{

	/// <summary>
	///		This class contains formatting information about about Excel range.
	/// </summary>
	public class RangeFormat
	{

		#region Public Properties

		/// <summary>
		///		Gets or sets this range's interior background color.
		/// </summary>
		public XlRgbColor? BackgroundColor { get; set; }

		/// <summary>
		///		Gets or sets a flag that indicates whether this range is bold.
		/// </summary>
		public bool? Bold { get; set; }

		/// <summary>
		///		Gets or sets a list of this range's border styles.
		/// </summary>
		public List<CellBorder> Borders { get; set; }

		/// <summary>
		///		Gets or sets this range's font color.
		/// </summary>
		public XlRgbColor? FontColor { get; set; }

		/// <summary>
		///		Gets or sets this range's font size.
		/// </summary>
		public int? FontSize { get; set; }

		/// <summary>
		///		Gets or sets this range's horizontal text alignment.
		/// </summary>
		public XlHAlign? HorizontalAlignment { get; set; }

		/// <summary>
		///		Gets or sets this range's number format.
		/// </summary>
		public string NumberFormat { get; set; }

		/// <summary>
		///		Gets or sets this row's "wrap text" flag.
		/// </summary>
		public bool? WrapText { get; set; }

		#endregion	// Public Properties

		#region Constructors

		/// <summary>
		///		RangeFormat constructor.
		/// </summary>
		public RangeFormat()
		{
			this.Borders = new List<CellBorder>();
		}

		#endregion	// Constructors

	}

}
